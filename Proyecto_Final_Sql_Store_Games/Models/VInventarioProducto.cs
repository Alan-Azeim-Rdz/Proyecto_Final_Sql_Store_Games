using System;
using System.Collections.Generic;

namespace Proyecto_Final_Sql_Store_Games.Models;

public partial class VInventarioProducto
{
    public int IdProducto { get; set; }

    public string NombreProducto { get; set; } = null!;

    public decimal PrecioActual { get; set; }

    public string TipoProducto { get; set; } = null!;

    public bool EstadoProducto { get; set; }

    public DateTime FechaRegistro { get; set; }
}
