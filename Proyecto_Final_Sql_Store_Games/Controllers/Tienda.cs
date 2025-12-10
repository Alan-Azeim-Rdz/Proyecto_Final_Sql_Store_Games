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

            // --- 1. Consulta de Juegos Base ---
            var juegosBase = _context.Juegos
                .Include(j => j.IdDesarrolladoraNavigation)
                .Include(j => j.IdDistribuidoraNavigation)
                .Include(j => j.IdGeneroNavigation)
                .Include(j => j.IdProductoNavigation)
                .Where(j => j.IdProductoNavigation.IdCategoria == 1)
                .Select(j => new ViewTienda
                {
                    TipoProducto = "Juego Base",
                    IdProducto = j.IdProductoNavigation.Id,  // 👈 Importante para el botón de cesta
                    Nombre = j.IdProductoNavigation.Nombre,
                    Precio = j.IdProductoNavigation.Precio,
                    Desarrolladora = j.IdDesarrolladoraNavigation.Nombre,
                    Distribuidora = j.IdDistribuidoraNavigation.Nombre,
                    Genero = j.IdGeneroNavigation.Nombre,
                    FechaCreacion = j.IdProductoNavigation.DateCreate
                });

            // --- 2. Consulta de DLCs ---
            var dlcs = _context.Dlcs
                .Include(d => d.IdDesarrolladoraNavigation)
                .Include(d => d.IdDistribuidoraNavigation)
                .Include(d => d.IdGeneroNavigation)
                .Include(d => d.IdProductoNavigation)
                .Where(d => d.IdProductoNavigation.IdCategoria == 2)
                .Select(d => new ViewTienda
                {
                    TipoProducto = "DLC",
                    IdProducto = d.IdProductoNavigation.Id,  // 👈 También aquí
                    Nombre = d.IdProductoNavigation.Nombre,
                    Precio = d.IdProductoNavigation.Precio,
                    Desarrolladora = d.IdDesarrolladoraNavigation != null ? d.IdDesarrolladoraNavigation.Nombre : "Desconocida",
                    Distribuidora = d.IdDistribuidoraNavigation != null ? d.IdDistribuidoraNavigation.Nombre : "Desconocida",
                    Genero = d.IdGeneroNavigation != null ? d.IdGeneroNavigation.Nombre : "Desconocido",
                    FechaCreacion = d.IdProductoNavigation.DateCreate
                });

            // --- 3. UNION ALL y ORDENACIÓN inicial ---
            var todosProductos = juegosBase.Concat(dlcs)
                .OrderByDescending(p => p.TipoProducto)
                .ThenBy(p => p.Nombre);

            IQueryable<ViewTienda> productosFiltrados = todosProductos;

            // --- Filtros ---
            if (!string.IsNullOrEmpty(SearchString))
            {
                productosFiltrados = productosFiltrados
                    .Where(p => p.Nombre.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(filterDistribuidora))
            {
                productosFiltrados = productosFiltrados
                    .Where(p => p.Distribuidora.Contains(filterDistribuidora));
            }

            if (!string.IsNullOrEmpty(filterDesarrolladora))
            {
                productosFiltrados = productosFiltrados
                    .Where(p => p.Desarrolladora.Contains(filterDesarrolladora));
            }

            // --- Ordenación dinámica ---
            switch (sortOrder)
            {
                case "name_asc":
                    productosFiltrados = productosFiltrados.OrderBy(p => p.Nombre);
                    break;
                case "date_desc":
                    productosFiltrados = productosFiltrados.OrderByDescending(p => p.FechaCreacion);
                    break;
                default:
                    productosFiltrados = productosFiltrados.OrderBy(p => p.Nombre);
                    break;
            }

            // --- Paginado ---
            var totalCount = productosFiltrados.Count();
            var pagedProductos = productosFiltrados
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            int totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            // --- Datos para la vista ---
            ViewBag.CurrentPage = pageNumber;
            ViewBag.TotalPages = totalPages;

            // Para que coincidan con tu vista:
            ViewData["CurrentFilter"] = SearchString;
            ViewData["CurrentSort"] = sortOrder;
            ViewData["CurrentFilterDistribuidora"] = filterDistribuidora;
            ViewData["CurrentFilterDesarrolladora"] = filterDesarrolladora;

            return View(pagedProductos);
        }
    }
}
