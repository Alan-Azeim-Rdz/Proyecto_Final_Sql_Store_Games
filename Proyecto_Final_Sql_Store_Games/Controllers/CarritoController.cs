using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_Sql_Store_Games.Models.ViewModel;
using Proyecto_Final_Sql_Store_Games.Models;
using System.Collections.Generic;
using Proyecto_Final_Sql_Store_Games.Helpers;
using System.Linq;
using Newtonsoft.Json;
using System;
using System.Security.Claims;
using System.IO; // Necesario para MemoryStream (ClosedXML)
using ClosedXML.Excel; // Necesario para XLSX
using System.Xml.Linq; // Necesario para XML

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

        // ... (Acción Agregar permanece sin cambios) ...
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
                                join r in _context.Rareza on i.IdRareza equals r.Id into rarezaGroup
                                from r in rarezaGroup.DefaultIfEmpty()
                                where p.Id == idProducto
                                select new ViewTiendaItem
                                {
                                    ProductoId = p.Id,
                                    ProductoNombre = p.Nombre,
                                    RarezaId = r != null ? r.Id : (int?)null,
                                    ItemRareza = r != null ? r.Nombre : "Desconocida",
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


        // ... (Acción Index permanece sin cambios) ...
        [HttpGet]
        public IActionResult Index()
        {
            var cesta = HttpContext.Session.GetObjectFromJson<CestaViewModel>("Cesta") ?? new CestaViewModel();
            ViewBag.MetodosPago = _context.MetodoPagos.Where(m => m.Status).ToList();
            ViewBag.Monedas = _context.Moneda.Where(m => m.Status).ToList();
            return View(cesta);
        }

        // ... (Acción Comprar permanece sin cambios, solo se asegura de que ViewBag.ReciboJson esté cargado) ...
        [HttpPost]
        public IActionResult Comprar(string metodoPago, string moneda)
        {
            var cesta = HttpContext.Session.GetObjectFromJson<CestaViewModel>("Cesta") ?? new CestaViewModel();
            if (string.IsNullOrEmpty(metodoPago) || string.IsNullOrEmpty(moneda))
            {
                ViewBag.MetodosPago = _context.MetodoPagos.Where(m => m.Status).ToList();
                ViewBag.Monedas = _context.Moneda.Where(m => m.Status).ToList();
                ModelState.AddModelError("", "Debes seleccionar un método de pago y una moneda.");
                return View("Index", cesta);
            }

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                ModelState.AddModelError("", "No se pudo identificar el usuario.");
                ViewBag.MetodosPago = _context.MetodoPagos.Where(m => m.Status).ToList();
                ViewBag.Monedas = _context.Moneda.Where(m => m.Status).ToList();
                return View("Index", cesta);
            }
            int idUsuario = int.Parse(userIdClaim.Value);

            var hoy = DateTime.Now;
            var eventoActivo = _context.Eventos.FirstOrDefault(e => e.Status && e.FechaInicio <= hoy && e.FechaFin >= hoy);
            if (eventoActivo == null)
            {
                eventoActivo = _context.Eventos.FirstOrDefault(e => e.Id == 1);
            }
            int descuento = eventoActivo?.PorcentajeDescuentoGlobal ?? 0;

            var totalSinDescuento = cesta.Items.Sum(i => i.ProductoPrecio) + cesta.JuegosYDlcs.Sum(j => j.Precio);
            var total = totalSinDescuento;
            if (descuento > 0)
            {
                total = totalSinDescuento - (totalSinDescuento * descuento / 100m);
            }

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

            if (darPuntos && !pagoConPuntos)
            {
                puntosOtorgados = _random.Next(10, 51);
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
                    Porcentaje = _random.Next(5, 21),
                    Status = true,
                    DateCreate = DateTime.Now,
                    IdUserCreate = idUsuario
                };
                _context.Cupons.Add(cuponOtorgado);
                _context.SaveChanges();
            }

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

            // Recibo JSON para mostrar y descargar (lo generamos antes de limpiar la cesta)
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
            var recibo = new
            {
                Productos = productos,
                MetodoPago = metodoPagoObj?.Nombre,
                Moneda = moneda,
                TotalSinDescuento = totalSinDescuento,
                DescuentoEvento = descuento,
                TotalFinal = total,
                PuntosOtorgados = puntosOtorgados,
                CuponOtorgado = cuponOtorgado?.Nombre
            };

            // Limpiar la cesta DESPUÉS de usarla para generar el recibo
            HttpContext.Session.SetObjectAsJson("Cesta", new CestaViewModel());

            ViewBag.ReciboJson = JsonConvert.SerializeObject(recibo, Formatting.Indented);
            return View("Recibo");
        }

        #region Acciones de Descarga

        // 2. Descarga XLSX (usa ClosedXML)
        [HttpGet]
        public IActionResult DescargarXlsx(string reciboJson)
        {
            var recibo = JsonConvert.DeserializeObject<dynamic>(reciboJson);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Detalle Compra");
                int currentRow = 1;

                // Títulos de la factura
                worksheet.Cell(currentRow, 1).Value = "REPORTE DE COMPRA";
                worksheet.Range(currentRow, 1, currentRow, 3).Merge().Style.Font.SetBold();
                currentRow++;
                worksheet.Cell(currentRow, 1).Value = "Fecha:";
                worksheet.Cell(currentRow, 2).Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                currentRow++;
                worksheet.Cell(currentRow, 1).Value = "Método de Pago:";
                worksheet.Cell(currentRow, 2).Value = (string)recibo.MetodoPago;
                currentRow++;
                worksheet.Cell(currentRow, 1).Value = "Moneda:";
                worksheet.Cell(currentRow, 2).Value = (string)recibo.Moneda;
                currentRow += 2; // Dos saltos de línea

                // Cabecera de la tabla de productos
                worksheet.Cell(currentRow, 1).Value = "Tipo";
                worksheet.Cell(currentRow, 2).Value = "Nombre del Producto";
                worksheet.Cell(currentRow, 3).Value = "Precio Unitario";
                worksheet.Range(currentRow, 1, currentRow, 3).Style.Font.SetBold();
                currentRow++;

                // Detalle de productos
                foreach (var producto in recibo.Productos)
                {
                    worksheet.Cell(currentRow, 1).Value = (string)producto.Tipo;
                    worksheet.Cell(currentRow, 2).Value = (string)producto.Nombre;
                    worksheet.Cell(currentRow, 3).Value = (decimal)producto.PrecioUnitario;
                    worksheet.Cell(currentRow, 3).Style.NumberFormat.Format = $"#0.00 \"{(string)recibo.Moneda}\"";
                    currentRow++;
                }

                // Resumen
                currentRow++;
                worksheet.Cell(currentRow, 2).Value = "Subtotal:";
                worksheet.Cell(currentRow, 3).Value = (decimal)recibo.TotalSinDescuento;
                worksheet.Cell(currentRow, 3).Style.NumberFormat.Format = $"#0.00 \"{(string)recibo.Moneda}\"";
                currentRow++;
                worksheet.Cell(currentRow, 2).Value = $"Descuento Evento ({(int)recibo.DescuentoEvento}%):";
                worksheet.Cell(currentRow, 3).Value = (decimal)recibo.TotalSinDescuento - (decimal)recibo.TotalFinal;
                worksheet.Cell(currentRow, 3).Style.NumberFormat.Format = $"#0.00 \"{(string)recibo.Moneda}\"";
                worksheet.Cell(currentRow, 3).Style.Font.SetFontColor(XLColor.Green);
                currentRow++;
                worksheet.Cell(currentRow, 2).Value = "TOTAL FINAL:";
                worksheet.Cell(currentRow, 3).Value = (decimal)recibo.TotalFinal;
                worksheet.Cell(currentRow, 3).Style.NumberFormat.Format = $"#0.00 \"{(string)recibo.Moneda}\"";
                worksheet.Cell(currentRow, 3).Style.Font.SetBold();

                // Ajustar ancho de columnas
                worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        $"recibo_compra_{DateTime.Now.ToString("yyyyMMddHHmmss")}.xlsx");
                }
            }
        }

        // 3. Descarga CSV (usa ClosedXML para mayor control, aunque se puede hacer con StringBuilder)
        [HttpGet]
        public IActionResult DescargarCsv(string reciboJson)
        {
            var recibo = JsonConvert.DeserializeObject<dynamic>(reciboJson);
            var csvContent = new System.Text.StringBuilder();

            // Agregar metadatos
            csvContent.AppendLine($"\"Fecha\",\"Método de Pago\",\"Moneda\"");
            csvContent.AppendLine($"\"{DateTime.Now.ToString("dd/MM/yyyy HH:mm")}\",\"{(string)recibo.MetodoPago}\",\"{(string)recibo.Moneda}\"");
            csvContent.AppendLine(); // Línea en blanco

            // Cabecera de productos
            csvContent.AppendLine("\"Tipo\",\"Nombre del Producto\",\"Precio Unitario\"");

            // Detalle de productos
            foreach (var producto in recibo.Productos)
            {
                // Reemplazar comillas y comas en nombres para evitar problemas de formato CSV
                string nombre = ((string)producto.Nombre).Replace("\"", "\"\"");
                csvContent.AppendLine($"\"{(string)producto.Tipo}\",\"{nombre}\",\"{(decimal)producto.PrecioUnitario}\"");
            }
            csvContent.AppendLine(); // Línea en blanco

            // Resumen
            csvContent.AppendLine($",\"Subtotal:\",\"{(decimal)recibo.TotalSinDescuento}\"");
            csvContent.AppendLine($",\"Descuento Evento ({(int)recibo.DescuentoEvento}%)\",\"{(decimal)recibo.TotalSinDescuento - (decimal)recibo.TotalFinal}\"");
            csvContent.AppendLine($",\"TOTAL FINAL:\",\"{(decimal)recibo.TotalFinal}\"");


            var bytes = System.Text.Encoding.UTF8.GetBytes(csvContent.ToString());
            return File(bytes, "text/csv", $"recibo_compra_{DateTime.Now.ToString("yyyyMMddHHmmss")}.csv");
        }

        // 4. Descarga XML (usa System.Xml.Linq)
        [HttpGet]
        public IActionResult DescargarXml(string reciboJson)
        {
            var recibo = JsonConvert.DeserializeObject<dynamic>(reciboJson);

            // ********* CORRECCIÓN DEL ERROR CS1977 *********
            // Convertimos la colección dynamic de Newtonsoft.Json a IEnumerable<dynamic>
            IEnumerable<dynamic> productosLista = recibo.Productos;

            var root = new XElement("ReciboDeCompra",
                new XElement("Metadatos",
                    new XElement("Fecha", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    new XElement("MetodoPago", (string)recibo.MetodoPago),
                    new XElement("Moneda", (string)recibo.Moneda)
                ),
                new XElement("Productos",
                    // Aplicamos Select sobre la lista ya tipificada como IEnumerable<dynamic>
                    productosLista.Select(p => new XElement("Producto",
                        new XAttribute("Tipo", (string)p.Tipo),
                        new XElement("Nombre", (string)p.Nombre),
                        new XElement("PrecioUnitario", (decimal)p.PrecioUnitario)
                    ))
                ),
                new XElement("Resumen",
                    new XElement("TotalSinDescuento", (decimal)recibo.TotalSinDescuento),
                    new XElement("DescuentoEventoPorcentaje", (int)recibo.DescuentoEvento),
                    new XElement("TotalFinal", (decimal)recibo.TotalFinal),
                    new XElement("PuntosOtorgados", (int)recibo.PuntosOtorgados),
                    new XElement("CuponOtorgado", (string)recibo.CuponOtorgado)
                )
            );

            using (var stream = new MemoryStream())
            {
                root.Save(stream);
                var content = stream.ToArray();
                return File(content, "application/xml", $"recibo_compra_{DateTime.Now.ToString("yyyyMMddHHmmss")}.xml");
            }
        }
        #endregion
    }
}