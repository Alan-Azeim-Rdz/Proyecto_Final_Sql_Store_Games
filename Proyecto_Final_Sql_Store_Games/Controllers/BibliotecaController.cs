using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Final_Sql_Store_Games.Models;
using Proyecto_Final_Sql_Store_Games.Models.ViewModel;
using System.Globalization;
using System.Linq;
using System.Security.Claims;        // 👈 IMPORTANTE para leer el usuario logeado
using Microsoft.AspNetCore.Authorization;

namespace Proyecto_Final_Sql_Store_Games.Controllers
{
    [Authorize] // 👈 Para que solo usuarios logeados puedan ver la Biblioteca
    public class BibliotecaController : Controller
    {
        private readonly Db_Contexto _context;

        public BibliotecaController(Db_Contexto context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(
            string sortOrder,
            string SearchString,
            string filterTipoProducto,
            string filterDesarrolladora,
            string filterDistribuidora,
            string filterGenero,
            int? pageNumber)
        {
            // 0. OBTENER ID DEL USUARIO LOGEADO DESDE LOS CLAIMS
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
            {
                // Si por alguna razón no hay usuario logeado, lo mando a Login
                return RedirectToAction("Login", "Account");
            }

            int idUsuarioLogeado = int.Parse(userIdClaim.Value);

            // 1. Configuración de ViewData para mantener el estado de la vista
            ViewData["CurrentSort"] = sortOrder;

            ViewData["NombreSortParm"] = String.IsNullOrEmpty(sortOrder) ? "nombre_desc" : "";
            ViewData["TipoSortParm"] = sortOrder == "Tipo" ? "tipo_desc" : "Tipo";
            ViewData["DesarrolladoraSortParm"] = sortOrder == "Desarrolladora" ? "desarrolladora_desc" : "Desarrolladora";
            ViewData["DistribuidoraSortParm"] = sortOrder == "Distribuidora" ? "distribuidora_desc" : "Distribuidora";
            ViewData["GeneroSortParm"] = sortOrder == "Genero" ? "genero_desc" : "Genero";
            ViewData["FechaAdquisicionSortParm"] = sortOrder == "FechaAdquisicion" ? "fechaadquisicion_desc" : "FechaAdquisicion";

            ViewData["CurrentFilterNombre"] = SearchString;
            ViewData["CurrentFilterTipoProducto"] = filterTipoProducto;
            ViewData["CurrentFilterDesarrolladora"] = filterDesarrolladora;
            ViewData["CurrentFilterDistribuidora"] = filterDistribuidora;
            ViewData["CurrentFilterGenero"] = filterGenero;

            // 2. Consulta Consolidada de la Biblioteca

            // Paso A: Obtener los productos del usuario y su precio de compra
            var productosComprados = _context.Venta
                .Where(v => v.IdUsuario == idUsuarioLogeado && v.Status == true) // 👈 USAMOS EL USUARIO LOGEADO
                .Join(_context.DetalleVenta,
                      v => v.Id,
                      dv => dv.IdVenta,
                      (v, dv) => new { dv.IdProducto, dv.PrecioUnitario, v.DateCreate })
                .Distinct()
                .AsQueryable();

            // Paso B: Juegos
            var bibliotecaJuegos = (from comprado in productosComprados
                                    join p in _context.Productos on comprado.IdProducto equals p.Id
                                    join j in _context.Juegos on p.Id equals j.IdProducto
                                    join d in _context.Desarrolladoras on j.IdDesarrolladora equals d.Id
                                    join dist in _context.Distribuidoras on j.IdDistribuidora equals dist.Id
                                    join g in _context.Generos on j.IdGenero equals g.Id
                                    select new ViewBiblioteca
                                    {
                                        IdProducto = p.Id,
                                        Nombre = p.Nombre,
                                        TipoProducto = "Juego",
                                        FechaAdquisicion = comprado.DateCreate,
                                        PrecioPagado = (decimal)comprado.PrecioUnitario,
                                        Desarrolladora = d.Nombre,
                                        Distribuidora = dist.Nombre,
                                        Genero = g.Nombre,
                                        FechaLanzamientoProducto = j.FechaLanzamiento ?? DateTime.MinValue,
                                        JuegoBase = null
                                    });

            // Paso C: DLCs
            var bibliotecaDlcs = (from comprado in productosComprados
                                  join p in _context.Productos on comprado.IdProducto equals p.Id
                                  join dlc in _context.Dlcs on p.Id equals dlc.IdProducto
                                  join d in _context.Desarrolladoras on dlc.IdDesarrolladora equals d.Id
                                  join dist in _context.Distribuidoras on dlc.IdDistribuidora equals dist.Id
                                  join g in _context.Generos on dlc.IdGenero equals g.Id
                                  join juegoBaseP in _context.Productos on dlc.IdJuegoBase equals juegoBaseP.Id
                                  select new ViewBiblioteca
                                  {
                                      IdProducto = p.Id,
                                      Nombre = p.Nombre,
                                      TipoProducto = "DLC",
                                      FechaAdquisicion = comprado.DateCreate,
                                      PrecioPagado = (decimal)comprado.PrecioUnitario,
                                      Desarrolladora = d.Nombre,
                                      Distribuidora = dist.Nombre,
                                      Genero = g.Nombre,
                                      FechaLanzamientoProducto = p.DateCreate,
                                      JuegoBase = juegoBaseP.Nombre
                                  });

            // Concatenar Juegos + DLCs
            IQueryable<ViewBiblioteca> productos = bibliotecaJuegos.Concat(bibliotecaDlcs);

            // 3. Filtros
            if (!String.IsNullOrEmpty(SearchString))
            {
                productos = productos.Where(s =>
                    s.Nombre.Contains(SearchString) ||
                    (s.JuegoBase != null && s.JuegoBase.Contains(SearchString)));
            }

            if (!String.IsNullOrEmpty(filterTipoProducto))
            {
                productos = productos.Where(s => s.TipoProducto.Contains(filterTipoProducto));
            }

            if (!String.IsNullOrEmpty(filterDesarrolladora))
            {
                productos = productos.Where(s => s.Desarrolladora.Contains(filterDesarrolladora));
            }

            if (!String.IsNullOrEmpty(filterDistribuidora))
            {
                productos = productos.Where(s => s.Distribuidora.Contains(filterDistribuidora));
            }

            if (!String.IsNullOrEmpty(filterGenero))
            {
                productos = productos.Where(s => s.Genero.Contains(filterGenero));
            }

            // 4. Ordenamiento
            productos = sortOrder switch
            {
                "nombre_desc" => productos.OrderByDescending(s => s.Nombre),
                "Tipo" => productos.OrderBy(s => s.TipoProducto).ThenBy(s => s.Nombre),
                "tipo_desc" => productos.OrderByDescending(s => s.TipoProducto).ThenBy(s => s.Nombre),
                "Desarrolladora" => productos.OrderBy(s => s.Desarrolladora).ThenBy(s => s.Nombre),
                "desarrolladora_desc" => productos.OrderByDescending(s => s.Desarrolladora).ThenBy(s => s.Nombre),
                "Distribuidora" => productos.OrderBy(s => s.Distribuidora).ThenBy(s => s.Nombre),
                "distribuidora_desc" => productos.OrderByDescending(s => s.Distribuidora).ThenBy(s => s.Nombre),
                "Genero" => productos.OrderBy(s => s.Genero).ThenBy(s => s.Nombre),
                "genero_desc" => productos.OrderByDescending(s => s.Genero).ThenBy(s => s.Nombre),
                "FechaAdquisicion" => productos.OrderBy(s => s.FechaAdquisicion).ThenBy(s => s.Nombre),
                "fechaadquisicion_desc" => productos.OrderByDescending(s => s.FechaAdquisicion).ThenBy(s => s.Nombre),
                _ => productos.OrderBy(s => s.Nombre),
            };

            // 5. Paginación
            int pageSize = 10;
            int count = await productos.CountAsync();
            int totalPages = (int)Math.Ceiling((double)count / pageSize);

            int currentPage = pageNumber ?? 1;
            ViewBag.CurrentPage = currentPage;
            ViewBag.TotalPages = totalPages;
            ViewBag.HasPreviousPage = (currentPage > 1);
            ViewBag.HasNextPage = (currentPage < totalPages);

            var items = await productos
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return View(items);
        }
    }
}
