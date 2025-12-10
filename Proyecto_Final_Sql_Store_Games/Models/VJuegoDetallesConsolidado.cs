using System;
using System.Collections.Generic;

namespace Proyecto_Final_Sql_Store_Games.Models;

public partial class VJuegoDetallesConsolidado
{
    public int IdJuego { get; set; }

    public string NombreProducto { get; set; } = null!;

    public decimal PrecioBase { get; set; }

    public DateTime? FechaLanzamiento { get; set; }

    public string Desarrollador { get; set; } = null!;

    public string? Publicador { get; set; }

    public string GeneroPrincipal { get; set; } = null!;

    public int? TotalReseñasDummy { get; set; }

    public bool EstadoJuego { get; set; }

    public string? CreadoPor { get; set; }

    public DateTime FechaCreacion { get; set; }
}
