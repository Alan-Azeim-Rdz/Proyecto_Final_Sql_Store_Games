using System;
using System.Collections.Generic;

namespace Proyecto_Final_Sql_Store_Games.Models;

public partial class VVentasAnualesXPai
{
    public string PaisCliente { get; set; } = null!;

    public int? AñoVenta { get; set; }

    public int? TotalVentas { get; set; }

    public double? IngresoTotalCalculado { get; set; }

    public double? VentaPromedioCalculada { get; set; }
}
