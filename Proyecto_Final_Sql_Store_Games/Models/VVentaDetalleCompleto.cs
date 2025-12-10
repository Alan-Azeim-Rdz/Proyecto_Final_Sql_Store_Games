using System;
using System.Collections.Generic;

namespace Proyecto_Final_Sql_Store_Games.Models;

public partial class VVentaDetalleCompleto
{
    public int IdVenta { get; set; }

    public DateTime FechaVenta { get; set; }

    public string Cliente { get; set; } = null!;

    public string EmailCliente { get; set; } = null!;

    public string NombreProducto { get; set; } = null!;

    public int Cantidad { get; set; }

    public double PrecioUnitarioHistorico { get; set; }

    public double SubtotalLinea { get; set; }

    public double? MontoTotalCalculado { get; set; }

    public string MetodoPago { get; set; } = null!;

    public DateTime FechaCreacionVenta { get; set; }
}
