using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_Sql_Store_Games.Models.ViewModel;
using Proyecto_Final_Sql_Store_Games.Models;
using System.Collections.Generic;
using Proyecto_Final_Sql_Store_Games.Helpers;
using System.Linq;
using Newtonsoft.Json;
using System;
using System.Security.Claims;

namespace Proyecto_Final_Sql_Store_Games.Controllers
{
    public class CarritoController : Controller
    {
        private readonly Db_Contexto _context;
        private readonly Random _random = new Random();

        public CarritoController(Db_Contexto context)
        {
            _context = context;
        }

        // Agrega un producto a la cesta (por id)
        [HttpPost]
        public IActionResult Agregar(int idProducto, string origen)
        {
            var cesta = HttpContext.Session.GetObjectFromJson<CestaViewModel>("Cesta") ?? new CestaViewModel();

            // Buscar el producto por id y agregarlo a la cesta con toda la información
            var producto = _context.Productos.FirstOrDefault(p => p.Id == idProducto);
            if (producto != null)
            {
                // Verificar si es un Item
                if (producto.IdCategoria == 3)
                {
                    var item = (from p in _context.Productos
                                join i in _context.Items on p.Id equals i.IdProducto
                                join p2 in _context.Productos on i.IdJuegoOrigen equals p2.Id into juegoGroup
                                from p2 in juegoGroup.DefaultIfEmpty()
                                join c in _context.Categoria on p.IdCategoria equals c.Id into categoriaGroup
                                from c in categoriaGroup.DefaultIfEmpty()
                                where p.Id == idProducto
                                select new ViewTiendaItem
                                {
                                    ProductoId = p.Id,
                                    ProductoNombre = p.Nombre,
                                    ItemRareza = i.Rareza,
                                    ProductoPrecio = p.Precio,
                                    JuegoOrigenNombre = p2 != null ? p2.Nombre : null,
                                    CategoriaNombre = c != null ? c.Nombre : null
                                }).FirstOrDefault();
                    if (item != null)
                    {
                        cesta.Items.Add(item);
                    }
                }
                // Verificar si es un Juego o DLC
                else if (producto.IdCategoria == 1 || producto.IdCategoria == 2)
                {
                    var juegoODlc = (from p in _context.Productos
                                     join j in _context.Juegos on p.Id equals j.IdProducto into juegoGroup
                                     from j in juegoGroup.DefaultIfEmpty()
                                     join d in _context.Desarrolladoras on j.IdDesarrolladora equals d.Id into desarrolladoraGroup
                                     from d in desarrolladoraGroup.DefaultIfEmpty()
                                     join dist in _context.Distribuidoras on j.IdDistribuidora equals dist.Id into distribuidoraGroup
                                     from dist in distribuidoraGroup.DefaultIfEmpty()
                                     join g in _context.Generos on j.IdGenero equals g.Id into generoGroup
                                     from g in generoGroup.DefaultIfEmpty()
                                     where p.Id == idProducto && p.IdCategoria == 1
                                     select new ViewTienda
                                     {
                                         TipoProducto = "Juego Base",
                                         IdProducto = p.Id,
                                         Nombre = p.Nombre,
                                         Precio = p.Precio,
                                         Desarrolladora = d != null ? d.Nombre : "Desconocida",
                                         Distribuidora = dist != null ? dist.Nombre : "Desconocida",
                                         Genero = g != null ? g.Nombre : "Desconocido",
                                         FechaCreacion = p.DateCreate,
                                         Clasificacion = ""
                                     }).FirstOrDefault();
                    if (juegoODlc == null)
                    {
                        // Si no es juego, buscar si es DLC
                        juegoODlc = (from p in _context.Productos
                                     join dlc in _context.Dlcs on p.Id equals dlc.IdProducto
                                     join d in _context.Desarrolladoras on dlc.IdDesarrolladora equals d.Id into desarrolladoraGroup
                                     from d in desarrolladoraGroup.DefaultIfEmpty()
                                     join dist in _context.Distribuidoras on dlc.IdDistribuidora equals dist.Id into distribuidoraGroup
                                     from dist in distribuidoraGroup.DefaultIfEmpty()
                                     join g in _context.Generos on dlc.IdGenero equals g.Id into generoGroup
                                     from g in generoGroup.DefaultIfEmpty()
                                     where p.Id == idProducto && p.IdCategoria == 2
                                     select new ViewTienda
                                     {
                                         TipoProducto = "DLC",
                                         IdProducto = p.Id,
                                         Nombre = p.Nombre,
                                         Precio = p.Precio,
                                         Desarrolladora = d != null ? d.Nombre : "Desconocida",
                                         Distribuidora = dist != null ? dist.Nombre : "Desconocida",
                                         Genero = g != null ? g.Nombre : "Desconocido",
                                         FechaCreacion = p.DateCreate,
                                         Clasificacion = ""
                                     }).FirstOrDefault();
                    }
                    if (juegoODlc != null)
                    {
                        cesta.JuegosYDlcs.Add(juegoODlc);
                    }
                }
            }

            HttpContext.Session.SetObjectAsJson("Cesta", cesta);
            // Redirigir según el origen
            if (origen == "Tienda")
                return RedirectToAction("Index", "Tienda");
            else
                return RedirectToAction("Index", "TiendaItems");
        }

        // Muestra la cesta actual
        [HttpGet]
        public IActionResult Index()
        {
            // Obtener la cesta de la sesión o crear una nueva
            var cesta = HttpContext.Session.GetObjectFromJson<CestaViewModel>("Cesta") ?? new CestaViewModel();

            // Llenar combos con datos de la base de datos
            ViewBag.MetodosPago = _context.MetodoPagos.Where(m => m.Status).ToList();
            ViewBag.Monedas = _context.Moneda.Where(m => m.Status).ToList();

            // Retornar la vista con la cesta
            return View(cesta);
        }

        // Procesa la compra y muestra el recibo en JSON
        [HttpPost]
        public IActionResult Comprar(string metodoPago, string moneda)
        {
            // Obtener la cesta de la sesión o crear una nueva
            var cesta = HttpContext.Session.GetObjectFromJson<CestaViewModel>("Cesta") ?? new CestaViewModel();

            // Validar que se haya seleccionado un método de pago y una moneda
            if (string.IsNullOrEmpty(metodoPago) || string.IsNullOrEmpty(moneda))
            {
                ViewBag.MetodosPago = _context.MetodoPagos.Where(m => m.Status).ToList();
                ViewBag.Monedas = _context.Moneda.Where(m => m.Status).ToList();
                ModelState.AddModelError("", "Debes seleccionar un método de pago y una moneda.");
                return View("Index", cesta);
            }

            // Obtener usuario logueado
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                ModelState.AddModelError("", "No se pudo identificar el usuario.");
                ViewBag.MetodosPago = _context.MetodoPagos.Where(m => m.Status).ToList();
                ViewBag.Monedas = _context.Moneda.Where(m => m.Status).ToList();
                return View("Index", cesta);
            }
            int idUsuario = int.Parse(userIdClaim.Value);

            // Buscar evento activo
            var hoy = DateTime.Now;
            var eventoActivo = _context.Eventos.FirstOrDefault(e => e.Status && e.FechaInicio <= hoy && e.FechaFin >= hoy);
            if (eventoActivo == null)
            {
                eventoActivo = _context.Eventos.FirstOrDefault(e => e.Id == 1); // Evento 'ninguno'
            }
            int descuento = eventoActivo?.PorcentajeDescuentoGlobal ?? 0;

            // Calcular total con descuento
            var totalSinDescuento = cesta.Items.Sum(i => i.ProductoPrecio) + cesta.JuegosYDlcs.Sum(j => j.Precio);
            var total = totalSinDescuento;
            if (descuento > 0)
            {
                total = totalSinDescuento - (totalSinDescuento * descuento / 100m);
            }

            // Manejo de puntos y cupones
            var comprasUsuario = _context.Venta.Count(v => v.IdUsuario == idUsuario);
            bool darPuntos = (comprasUsuario + 1) % 2 == 0;
            bool darCupon = (comprasUsuario + 1) % 5 == 0;
            int puntosOtorgados = 0;
            Cupon? cuponOtorgado = null;
            BolsaPunto? bolsa = _context.BolsaPuntos.FirstOrDefault(b => b.IdUsuario == idUsuario);
            if (bolsa == null)
            {
                bolsa = new BolsaPunto
                {
                    IdUsuario = idUsuario,
                    Cantidad = 0,
                    Status = true,
                    DateCreate = DateTime.Now,
                    IdUserCreate = idUsuario
                };
                _context.BolsaPuntos.Add(bolsa);
                _context.SaveChanges();
            }

            // Si paga con puntos, validar y descontar
            var metodoPagoObj = _context.MetodoPagos.FirstOrDefault(m => m.Id.ToString() == metodoPago);
            bool pagoConPuntos = metodoPagoObj != null && metodoPagoObj.Nombre.ToLower().Contains("punto");
            if (pagoConPuntos)
            {
                if (bolsa.Cantidad == null || bolsa.Cantidad < (int)Math.Ceiling(total))
                {
                    ModelState.AddModelError("", "No tienes suficientes puntos para realizar la compra.");
                    ViewBag.MetodosPago = _context.MetodoPagos.Where(m => m.Status).ToList();
                    ViewBag.Monedas = _context.Moneda.Where(m => m.Status).ToList();
                    return View("Index", cesta);
                }
                bolsa.Cantidad -= (int)Math.Ceiling(total);
                bolsa.IdUserUpdate = idUsuario;
                bolsa.DateUpdate = DateTime.Now;
                _context.BolsaPuntos.Update(bolsa);
                _context.SaveChanges();
            }

            // Otorgar puntos/cupon si corresponde
            if (darPuntos && !pagoConPuntos)
            {
                puntosOtorgados = _random.Next(10, 51); // Aleatorio entre 10 y 50
                bolsa.Cantidad = (bolsa.Cantidad ?? 0) + puntosOtorgados;
                bolsa.IdUserUpdate = idUsuario;
                bolsa.DateUpdate = DateTime.Now;
                _context.BolsaPuntos.Update(bolsa);
                _context.SaveChanges();
            }
            if (darCupon && !pagoConPuntos)
            {
                cuponOtorgado = new Cupon
                {
                    Nombre = $"Cupón-{Guid.NewGuid().ToString().Substring(0, 8)}",
                    Porcentaje = _random.Next(5, 21), // 5% a 20%
                    Status = true,
                    DateCreate = DateTime.Now,
                    IdUserCreate = idUsuario
                };
                _context.Cupons.Add(cuponOtorgado);
                _context.SaveChanges();
            }

            // Crear factura
            var factura = new Factura
            {
                Descripcion = "Compra en Steam",
                Fecha = DateTime.Now,
                Status = true,
                DateCreate = DateTime.Now,
                IdUserCreate = idUsuario
            };
            _context.Facturas.Add(factura);
            _context.SaveChanges();

            // Crear venta
            var venta = new Venta
            {
                Estado = "Completada",
                IdUsuario = idUsuario,
                IdMetodoPago = int.Parse(metodoPago),
                IdFactura = factura.Id,
                Status = true,
                DateCreate = DateTime.Now,
                IdUserCreate = idUsuario,
                IdEvento = eventoActivo?.Id ?? 1,
                IdCupon = cuponOtorgado?.Id
            };
            _context.Venta.Add(venta);
            _context.SaveChanges();

            // Crear detalles de venta para items
            foreach (var item in cesta.Items)
            {
                var detalle = new DetalleVentum
                {
                    IdVenta = venta.Id,
                    IdProducto = item.ProductoId,
                    Cantidad = 1,
                    PrecioUnitario = (double)item.ProductoPrecio,
                    Status = true,
                    DateCreate = DateTime.Now,
                    IdUserCreate = idUsuario
                };
                _context.DetalleVenta.Add(detalle);
            }
            // Crear detalles de venta para juegos y dlcs
            foreach (var prod in cesta.JuegosYDlcs)
            {
                var detalle = new DetalleVentum
                {
                    IdVenta = venta.Id,
                    IdProducto = prod.IdProducto,
                    Cantidad = 1,
                    PrecioUnitario = (double)prod.Precio,
                    Status = true,
                    DateCreate = DateTime.Now,
                    IdUserCreate = idUsuario
                };
                _context.DetalleVenta.Add(detalle);
            }
            _context.SaveChanges();

            // Limpiar la cesta
            HttpContext.Session.SetObjectAsJson("Cesta", new CestaViewModel());

            // Recibo JSON para mostrar y descargar
            var productos = new List<object>();
            productos.AddRange(cesta.Items.Select(i => new {
                Tipo = "Item",
                Nombre = i.ProductoNombre,
                PrecioUnitario = i.ProductoPrecio
            }));
            productos.AddRange(cesta.JuegosYDlcs.Select(j => new {
                Tipo = j.TipoProducto,
                Nombre = j.Nombre,
                PrecioUnitario = j.Precio
            }));
            var recibo = new {
                Productos = productos,
                MetodoPago = metodoPagoObj?.Nombre,
                Moneda = moneda,
                TotalSinDescuento = totalSinDescuento,
                DescuentoEvento = descuento,
                TotalFinal = total,
                PuntosOtorgados = puntosOtorgados,
                CuponOtorgado = cuponOtorgado?.Nombre
            };
            ViewBag.ReciboJson = JsonConvert.SerializeObject(recibo, Formatting.Indented);
            return View("Recibo");
        }
    }
}
