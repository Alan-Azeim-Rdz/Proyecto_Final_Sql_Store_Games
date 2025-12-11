using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Final_Sql_Store_Games.Models;
using Proyecto_Final_Sql_Store_Games.Models.ViewModel;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Proyecto_Final_Sql_Store_Games.Controllers
{
    [Authorize]
    public class TiendaItemsController : Controller
    {
        private readonly Db_Contexto _context;

        public TiendaItemsController(Db_Contexto context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(
            string searchString,
            int? filterRareza, // Parámetro para el filtro de Rareza
            int pageNumber = 1,
            int pageSize = 10)
        {
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1) pageSize = 10;
            searchString = searchString ?? "";

            // 1. Consulta Base LINQ (Replicando los LEFT JOINs)
            var itemsQuery = (from p in _context.Productos
                                  // LEFT JOIN con Item
                              join i in _context.Items on p.Id equals i.IdProducto into itemGroup
                              from i in itemGroup.DefaultIfEmpty()

                                  // LEFT JOIN con Producto (Juego Origen)
                              join p2 in _context.Productos on i.IdJuegoOrigen equals p2.Id into juegoGroup
                              from p2 in juegoGroup.DefaultIfEmpty()

                                  // LEFT JOIN con Categoria
                              join c in _context.Categoria on p.IdCategoria equals c.Id into categoriaGroup
                              from c in categoriaGroup.DefaultIfEmpty()

                              where p.IdCategoria == 3 // Filtro: Solo productos de tipo "Item"
                              select new
                              {
                                  p.Id,
                                  p.Nombre,
                                  i.Rareza,
                                  p.Precio,
                                  JuegoOrigenNombre = p2.Nombre,
                                  CategoriaNombre = c.Nombre
                              })
                              .OrderBy(x => x.Nombre)
                              .AsQueryable();

            // 2. Aplicación Condicional de Filtros
            if (!string.IsNullOrEmpty(searchString))
            {
                itemsQuery = itemsQuery.Where(x => x.Nombre.Contains(searchString));
            }

            if (filterRareza.HasValue)
            {
                // Solo aplica el filtro si Rareza no es null y coincide con el filtro
                itemsQuery = itemsQuery.Where(x => x.Rareza.HasValue && x.Rareza.Value == filterRareza.Value);
            }

            // 3. Paginación y Proyección
            var totalCount = await itemsQuery.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            var skip = (pageNumber - 1) * pageSize;

            // Proyectar al ViewModel ViewTiendaItem antes de ToListAsync
            var items = await itemsQuery
                .Skip(skip)
                .Take(pageSize)
                .Select(x => new ViewTiendaItem // <--- ¡Esto es crucial!
                {
                    ProductoId = x.Id,
                    ProductoNombre = x.Nombre,
                    ItemRareza = x.Rareza,
                    ProductoPrecio = x.Precio,
                    JuegoOrigenNombre = x.JuegoOrigenNombre,
                    CategoriaNombre = x.CategoriaNombre
                })
                .ToListAsync();

            // 4. Pasar la información de paginación y filtros a la vista
            ViewBag.CurrentPage = pageNumber;
            ViewBag.TotalPages = totalPages;
            ViewBag.SearchString = searchString;
            ViewBag.FilterRareza = filterRareza; // Pasa el valor del filtro seleccionado
            ViewBag.PageSize = pageSize;

            return View(items);
        }
    }
}