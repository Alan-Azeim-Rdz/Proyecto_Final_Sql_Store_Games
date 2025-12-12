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
     string sortOrder,
     string searchString,
     int? filterRareza, // Parámetro para el filtro de Rareza
     int pageNumber = 1,
     int pageSize = 10)
        {
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1) pageSize = 10;
            searchString = searchString ?? "";

            // 1. Configuración de ViewData para los parámetros de ordenación
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NombreSortParm"] = String.IsNullOrEmpty(sortOrder) ? "nombre_desc" : "";
            ViewData["RarezaSortParm"] = sortOrder == "Rareza" ? "rareza_desc" : "Rareza";
            ViewData["PrecioSortParm"] = sortOrder == "Precio" ? "precio_desc" : "Precio";
            ViewData["JuegoOrigenSortParm"] = sortOrder == "JuegoOrigen" ? "juegoOrigen_desc" : "JuegoOrigen";
            ViewData["CategoriaSortParm"] = sortOrder == "Categoria" ? "categoria_desc" : "Categoria";

            // 2. Consulta Base LINQ (Replicando los LEFT JOINs)
            var itemsQuery = (from p in _context.Productos
                              join i in _context.Items on p.Id equals i.IdProducto into itemGroup
                              from i in itemGroup.DefaultIfEmpty()
                              join p2 in _context.Productos on i.IdJuegoOrigen equals p2.Id into juegoGroup
                              from p2 in juegoGroup.DefaultIfEmpty()
                              join c in _context.Categoria on p.IdCategoria equals c.Id into categoriaGroup
                              from c in categoriaGroup.DefaultIfEmpty()
                              join r in _context.Rareza on i.IdRareza equals r.Id into rarezaGroup  // JOIN con la tabla Rareza
                              from r in rarezaGroup.DefaultIfEmpty()  // Tomar el nombre de la rareza
                              where p.IdCategoria == 3 // Filtro: Solo productos de tipo "Item"
                              select new
                              {
                                  p.Id,
                                  p.Nombre,
                                  RarezaId = r != null ? r.Id : (int?)null, // Proyectar el ID de rareza
                                  RarezaNombre = r.Nombre,  // Obtenemos el nombre de la rareza en vez del ID
                                  p.Precio,
                                  JuegoOrigenNombre = p2.Nombre,
                                  CategoriaNombre = c.Nombre
                              })
                              .AsQueryable();

            // 3. Aplicación Condicional de Filtros
            if (!string.IsNullOrEmpty(searchString))
            {
                itemsQuery = itemsQuery.Where(x => x.Nombre.Contains(searchString));
            }

            if (filterRareza.HasValue)
            {
                // Filtrar por el ID de rareza, no por el nombre
                itemsQuery = itemsQuery.Where(x => x.RarezaNombre != null && x.RarezaId == filterRareza.Value);
            }

            // 4. Ordenamiento
            itemsQuery = sortOrder switch
            {
                "nombre_desc" => itemsQuery.OrderByDescending(x => x.Nombre),
                "Rareza" => itemsQuery.OrderBy(x => x.RarezaNombre).ThenBy(x => x.Nombre),
                "rareza_desc" => itemsQuery.OrderByDescending(x => x.RarezaNombre).ThenBy(x => x.Nombre),
                "Precio" => itemsQuery.OrderBy(x => x.Precio).ThenBy(x => x.Nombre),
                "precio_desc" => itemsQuery.OrderByDescending(x => x.Precio).ThenBy(x => x.Nombre),
                "JuegoOrigen" => itemsQuery.OrderBy(x => x.JuegoOrigenNombre).ThenBy(x => x.Nombre),
                "juegoOrigen_desc" => itemsQuery.OrderByDescending(x => x.JuegoOrigenNombre).ThenBy(x => x.Nombre),
                "Categoria" => itemsQuery.OrderBy(x => x.CategoriaNombre).ThenBy(x => x.Nombre),
                "categoria_desc" => itemsQuery.OrderByDescending(x => x.CategoriaNombre).ThenBy(x => x.Nombre),
                _ => itemsQuery.OrderBy(x => x.Nombre),
            };

            // 5. Paginación y Proyección
            var totalCount = await itemsQuery.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            var skip = (pageNumber - 1) * pageSize;

            var items = await itemsQuery
                .Skip(skip)
                .Take(pageSize)
                .Select(x => new ViewTiendaItem
                {
                    ProductoId = x.Id,
                    ProductoNombre = x.Nombre,
                    ItemRareza = x.RarezaNombre,  // Nombre de la rareza
                    ProductoPrecio = x.Precio,
                    JuegoOrigenNombre = x.JuegoOrigenNombre,
                    CategoriaNombre = x.CategoriaNombre
                })
                .ToListAsync();

            // 6. Pasar la información de paginación y filtros a la vista
            ViewBag.CurrentPage = pageNumber;
            ViewBag.TotalPages = totalPages;
            ViewBag.SearchString = searchString;
            ViewBag.FilterRareza = filterRareza; // Pasa el valor del filtro seleccionado
            ViewBag.PageSize = pageSize;

            return View(items);
        }




    }
}