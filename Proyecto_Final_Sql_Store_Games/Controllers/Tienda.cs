using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Final_Sql_Store_Games.Models;
using Proyecto_Final_Sql_Store_Games.Models.ViewModel;
using System;
using System.Linq;

namespace Proyecto_Final_Sql_Store_Games.Controllers
{
    public class TiendaController : Controller
    {
        private readonly Db_Contexto _context;

        public TiendaController(Db_Contexto context)
        {
            _context = context;
        }

        public IActionResult Index(
     string SearchString,
     string sortOrder,
     string filterDistribuidora,
     string filterDesarrolladora,
     int pageNumber = 1)
        {
            int pageSize = 10;

            // 1. Configuración de ViewData para mantener el estado de la vista
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NombreSortParm"] = sortOrder == "name_asc" ? "name_desc" : "name_asc";
            ViewData["PrecioSortParm"] = sortOrder == "precio_asc" ? "precio_desc" : "precio_asc";
            ViewData["FechaCreacionSortParm"] = sortOrder == "fecha_asc" ? "fecha_desc" : "fecha_asc";
            ViewData["DesarrolladoraSortParm"] = sortOrder == "desarrolladora_asc" ? "desarrolladora_desc" : "desarrolladora_asc";
            ViewData["DistribuidoraSortParm"] = sortOrder == "distribuidora_asc" ? "distribuidora_desc" : "distribuidora_asc";
            ViewData["GeneroSortParm"] = sortOrder == "genero_asc" ? "genero_desc" : "genero_asc";

            ViewData["CurrentFilter"] = SearchString;
            ViewData["CurrentFilterDistribuidora"] = filterDistribuidora;
            ViewData["CurrentFilterDesarrolladora"] = filterDesarrolladora;

            // 2. Obtener el ID del usuario logueado
            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            int? idUsuario = null;
            if (userIdClaim != null)
                idUsuario = int.Parse(userIdClaim.Value);

            // 3. Obtener los productos comprados por el usuario
            var productosComprados = new List<int>();
            if (idUsuario.HasValue)
            {
                productosComprados = _context.Venta
                    .Where(v => v.IdUsuario == idUsuario && v.Status)
                    .Join(_context.DetalleVenta,
                          v => v.Id,
                          dv => dv.IdVenta,
                          (v, dv) => dv.IdProducto)
                    .Distinct()
                    .ToList();
            }

            // 4. Consulta de Juegos Base
            var juegosBase = _context.Juegos
                .Include(j => j.IdDesarrolladoraNavigation)
                .Include(j => j.IdDistribuidoraNavigation)
                .Include(j => j.IdGeneroNavigation)
                .Include(j => j.IdProductoNavigation)
                .Where(j => j.IdProductoNavigation.IdCategoria == 1)
                .Where(j => !productosComprados.Contains(j.IdProductoNavigation.Id))
                .Select(j => new ViewTienda
                {
                    TipoProducto = "Juego Base",
                    IdProducto = j.IdProductoNavigation.Id,
                    Nombre = j.IdProductoNavigation.Nombre,
                    Precio = j.IdProductoNavigation.Precio,
                    Desarrolladora = j.IdDesarrolladoraNavigation.Nombre,
                    Distribuidora = j.IdDistribuidoraNavigation.Nombre,
                    Genero = j.IdGeneroNavigation.Nombre,
                    FechaCreacion = j.IdProductoNavigation.DateCreate
                });

            // 5. Consulta de DLCs
            var dlcs = _context.Dlcs
                .Include(d => d.IdDesarrolladoraNavigation)
                .Include(d => d.IdDistribuidoraNavigation)
                .Include(d => d.IdGeneroNavigation)
                .Include(d => d.IdProductoNavigation)
                .Where(d => d.IdProductoNavigation.IdCategoria == 2)
                .Where(d => !productosComprados.Contains(d.IdProductoNavigation.Id))
                .Select(d => new ViewTienda
                {
                    TipoProducto = "DLC",
                    IdProducto = d.IdProductoNavigation.Id,
                    Nombre = d.IdProductoNavigation.Nombre,
                    Precio = d.IdProductoNavigation.Precio,
                    Desarrolladora = d.IdDesarrolladoraNavigation != null ? d.IdDesarrolladoraNavigation.Nombre : "Desconocida",
                    Distribuidora = d.IdDistribuidoraNavigation != null ? d.IdDistribuidoraNavigation.Nombre : "Desconocida",
                    Genero = d.IdGeneroNavigation != null ? d.IdGeneroNavigation.Nombre : "Desconocido",
                    FechaCreacion = d.IdProductoNavigation.DateCreate
                });

            // 6. UNION ALL y ORDENACIÓN inicial
            var todosProductos = juegosBase.Concat(dlcs);

            // 7. Filtros
            if (!string.IsNullOrEmpty(SearchString))
            {
                todosProductos = todosProductos
                    .Where(p => p.Nombre.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(filterDistribuidora))
            {
                todosProductos = todosProductos
                    .Where(p => p.Distribuidora.Contains(filterDistribuidora));
            }
            if (!string.IsNullOrEmpty(filterDesarrolladora))
            {
                todosProductos = todosProductos
                    .Where(p => p.Desarrolladora.Contains(filterDesarrolladora));
            }

            // 8. Ordenación dinámica
            switch (sortOrder)
            {
                case "name_desc":
                    todosProductos = todosProductos.OrderByDescending(p => p.Nombre);
                    break;
                case "name_asc":
                    todosProductos = todosProductos.OrderBy(p => p.Nombre);
                    break;
                case "precio_desc":
                    todosProductos = todosProductos.OrderByDescending(p => p.Precio);
                    break;
                case "precio_asc":
                    todosProductos = todosProductos.OrderBy(p => p.Precio);
                    break;
                case "fecha_desc":
                    todosProductos = todosProductos.OrderByDescending(p => p.FechaCreacion);
                    break;
                case "fecha_asc":
                    todosProductos = todosProductos.OrderBy(p => p.FechaCreacion);
                    break;
                case "desarrolladora_desc":
                    todosProductos = todosProductos.OrderByDescending(p => p.Desarrolladora);
                    break;
                case "desarrolladora_asc":
                    todosProductos = todosProductos.OrderBy(p => p.Desarrolladora);
                    break;
                case "distribuidora_desc":
                    todosProductos = todosProductos.OrderByDescending(p => p.Distribuidora);
                    break;
                case "distribuidora_asc":
                    todosProductos = todosProductos.OrderBy(p => p.Distribuidora);
                    break;
                case "genero_desc":
                    todosProductos = todosProductos.OrderByDescending(p => p.Genero);
                    break;
                case "genero_asc":
                    todosProductos = todosProductos.OrderBy(p => p.Genero);
                    break;
                default:
                    todosProductos = todosProductos.OrderBy(p => p.Nombre);
                    break;
            }

            // 9. Paginación
            var totalCount = todosProductos.Count();
            var pagedProductos = todosProductos
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            int totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            ViewBag.CurrentPage = pageNumber;
            ViewBag.TotalPages = totalPages;

            return View(pagedProductos);
        }

    }
}
