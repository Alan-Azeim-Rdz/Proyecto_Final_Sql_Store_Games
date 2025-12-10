using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Final_Sql_Store_Games.Models;
using Proyecto_Final_Sql_Store_Games.Models.ViewModel;
using System.Security.Claims;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_Final_Sql_Store_Games.Controllers
{
    [Authorize]
    public class InventarioController : Controller
    {
        private readonly Db_Contexto _context;

        public InventarioController(Db_Contexto context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(
            string sortOrder,
            string searchString,
            string filterRareza,
            string filterTipoItem,
            int pageNumber = 1)
        {
            // 0. Obtener el ID del usuario logeado
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return RedirectToAction("Login", "Account");
            }

            int idUsuarioLogeado = int.Parse(userIdClaim.Value);

            // 1. Mantener estado en la vista
            ViewData["CurrentSort"] = sortOrder;
            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentFilterRareza"] = filterRareza;
            ViewData["CurrentFilterTipoItem"] = filterTipoItem;

            // 2. Ventas del usuario (solo activas)
            var productosComprados = _context.Venta
                .Where(v => v.IdUsuario == idUsuarioLogeado && v.Status == true)
                .Join(_context.DetalleVenta,
                      v => v.Id,
                      dv => dv.IdVenta,
                      (v, dv) => new { dv.IdProducto, dv.PrecioUnitario, v.DateCreate })
                .AsQueryable();

            // 3. Inventario SOLO de ÍTEMS
            //    Item:
            //      - IdProducto (FK a Producto)
            //      - IdJuegoOrigenNavigation (Juego)
            //      - IdJuegoOrigenNavigation.IdProductoNavigation (Producto nombre del juego)
            //      - IdTipoItemNavigation (TipoItem)
            var query =
                from comprado in productosComprados
                join it in _context.Items
                    .Include(i => i.IdProductoNavigation)
                    .Include(i => i.IdJuegoOrigenNavigation)
                        .ThenInclude(j => j.IdProductoNavigation)
                    .Include(i => i.IdTipoItemNavigation)
                    on comprado.IdProducto equals it.IdProducto
                select new ViewInventarioItem
                {
                    IdProducto = it.IdProducto,
                    Nombre = it.IdProductoNavigation.Nombre,
                    TipoProducto = "Item",
                    FechaAdquisicion = comprado.DateCreate,
                    PrecioPagado = (decimal)comprado.PrecioUnitario,
                    Rareza = it.Rareza,
                    TipoItem = it.IdTipoItemNavigation.Nombre, // asumiendo que TipoItem tiene 'Nombre'
                    JuegoOrigen = it.IdJuegoOrigenNavigation != null
                        ? it.IdJuegoOrigenNavigation.IdProductoNavigation.Nombre
                        : "Sin juego origen"
                };

            // 4. BÚSQUEDA (por nombre de ítem o juego)
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                query = query.Where(i =>
                    i.Nombre.Contains(searchString) ||
                    i.JuegoOrigen.Contains(searchString));
            }

            // 5. FILTRO POR RAREZA
            if (!string.IsNullOrWhiteSpace(filterRareza))
            {
                // Si se puede interpretar como número, filtramos por valor exacto
                if (int.TryParse(filterRareza, out int rarezaNum))
                {
                    query = query.Where(i => i.Rareza == rarezaNum);
                }
                else
                {
                    // Si algún día mapeas rarezas a texto, podrías usar Contains aquí.
                    // Por ahora lo dejamos por si usas algo como "1", "2", etc.
                    query = query.Where(i =>
                        i.Rareza.HasValue &&
                        i.Rareza.Value.ToString().Contains(filterRareza));
                }
            }

            // 6. FILTRO POR TIPO DE ÍTEM
            if (!string.IsNullOrWhiteSpace(filterTipoItem))
            {
                query = query.Where(i => i.TipoItem.Contains(filterTipoItem));
            }

            // 7. ORDENAMIENTO (simple: por nombre o juego)
            switch (sortOrder)
            {
                case "nombre_desc":
                    query = query.OrderByDescending(i => i.Nombre);
                    break;
                case "juego_asc":
                    query = query.OrderBy(i => i.JuegoOrigen).ThenBy(i => i.Nombre);
                    break;
                case "juego_desc":
                    query = query.OrderByDescending(i => i.JuegoOrigen).ThenBy(i => i.Nombre);
                    break;
                default:
                    query = query.OrderBy(i => i.Nombre);
                    break;
            }

            // 8. PAGINADO
            int pageSize = 10;
            int totalCount = await query.CountAsync();
            int totalPages = (int)System.Math.Ceiling(totalCount / (double)pageSize);

            if (pageNumber < 1) pageNumber = 1;
            if (pageNumber > totalPages && totalPages > 0) pageNumber = totalPages;

            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            ViewBag.CurrentPage = pageNumber;
            ViewBag.TotalPages = totalPages;

            return View(items);
        }
    }
}
