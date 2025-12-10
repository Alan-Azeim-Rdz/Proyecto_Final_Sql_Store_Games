using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Final_Sql_Store_Games.Models;
using Proyecto_Final_Sql_Store_Games.Models.ViewModel;
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

        public IActionResult Index(string SearchString, string sortOrder, string filterDistribuidora, string filterDesarrolladora, int pageNumber = 1)
        {
            int pageSize = 10;

            // --- 1. Consulta de Juegos Base ---
            // Usamos Include antes del Select para cargar las relaciones de Juego
            var juegosBase = _context.Juegos
                .Include(j => j.IdDesarrolladoraNavigation)
                .Include(j => j.IdDistribuidoraNavigation)
                .Include(j => j.IdGeneroNavigation)
                .Include(j => j.IdProductoNavigation) // Incluimos el Producto asociado
                .Where(j => j.IdProductoNavigation.IdCategoria == 1) // Filtramos por Categoría de Producto
                .Select(j => new ViewTienda
                {
                    TipoProducto = "Juego Base",
                    Nombre = j.IdProductoNavigation.Nombre,
                    Precio = j.IdProductoNavigation.Precio,
                    Desarrolladora = j.IdDesarrolladoraNavigation.Nombre,
                    Distribuidora = j.IdDistribuidoraNavigation.Nombre,
                    Genero = j.IdGeneroNavigation.Nombre,
                    FechaCreacion = j.IdProductoNavigation.DateCreate // Añade esto si quieres ordenar por fecha
                });

            // --- 2. Consulta de DLCs ---
            // Usamos Include antes del Select para cargar las relaciones de Dlc
            var dlcs = _context.Dlcs
                .Include(d => d.IdDesarrolladoraNavigation)
                .Include(d => d.IdDistribuidoraNavigation)
                .Include(d => d.IdGeneroNavigation)
                .Include(d => d.IdProductoNavigation) // Incluimos el Producto asociado
                .Where(d => d.IdProductoNavigation.IdCategoria == 2) // Filtramos por Categoría de Producto
                .Select(d => new ViewTienda
                {
                    TipoProducto = "DLC",
                    Nombre = d.IdProductoNavigation.Nombre,
                    Precio = d.IdProductoNavigation.Precio,
                    // Manejamos los posibles nulos para las propiedades de navegación si el Dlc puede tener Desarrolladora/Distribuidora/Género nulo (LEFT JOIN)
                    Desarrolladora = d.IdDesarrolladoraNavigation != null ? d.IdDesarrolladoraNavigation.Nombre : "Desconocida",
                    Distribuidora = d.IdDistribuidoraNavigation != null ? d.IdDistribuidoraNavigation.Nombre : "Desconocida",
                    Genero = d.IdGeneroNavigation != null ? d.IdGeneroNavigation.Nombre : "Desconocido",
                    FechaCreacion = d.IdProductoNavigation.DateCreate // Añade esto si quieres ordenar por fecha
                });

            // --- 3. UNION ALL y ORDENACIÓN inicial ---
            var todosProductos = juegosBase.Concat(dlcs);

            // La consulta SQL original ordena por TipoProducto DESC y luego por Nombre
            todosProductos = todosProductos
                .OrderByDescending(p => p.TipoProducto)
                .ThenBy(p => p.Nombre);

            // Aplicar filtros y ordenación dinámica
            IQueryable<ViewTienda> productosFiltrados = todosProductos;

            // Filtros (sin cambios)
            if (!string.IsNullOrEmpty(SearchString))
            {
                productosFiltrados = productosFiltrados.Where(p => p.Nombre.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(filterDistribuidora))
            {
                productosFiltrados = productosFiltrados.Where(p => p.Distribuidora.Contains(filterDistribuidora));
            }

            if (!string.IsNullOrEmpty(filterDesarrolladora))
            {
                productosFiltrados = productosFiltrados.Where(p => p.Desarrolladora.Contains(filterDesarrolladora));
            }

            // Ordenación dinámica (ajustada para usar la propiedad Nombre o FechaCreacion)
            switch (sortOrder)
            {
                case "name_asc":
                    productosFiltrados = productosFiltrados.OrderBy(p => p.Nombre);
                    break;
                case "date_desc":
                    // Asegúrate de que FechaCreacion esté en ViewTienda y se seleccione arriba
                    productosFiltrados = productosFiltrados.OrderByDescending(p => p.FechaCreacion);
                    break;
                default:
                    productosFiltrados = productosFiltrados.OrderBy(p => p.Nombre);
                    break;
            }

            // Paginado
            var totalCount = productosFiltrados.Count();
            var pagedProductos = productosFiltrados.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            // Calcular total de páginas
            int totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            // Pasar los datos a la vista
            ViewBag.CurrentPage = pageNumber;
            ViewBag.TotalPages = totalPages;
            ViewBag.SearchString = SearchString;
            ViewBag.SortOrder = sortOrder;
            ViewBag.FilterDistribuidora = filterDistribuidora;
            ViewBag.FilterDesarrolladora = filterDesarrolladora;

            return View(pagedProductos);
        }
    }
}
