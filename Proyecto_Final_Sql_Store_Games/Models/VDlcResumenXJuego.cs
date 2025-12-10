using System;
using System.Collections.Generic;

namespace Proyecto_Final_Sql_Store_Games.Models;

public partial class VDlcResumenXJuego
{
    public int IdDlc { get; set; }

    public string NombreDlc { get; set; } = null!;

    public string JuegoBase { get; set; } = null!;

    public decimal PrecioBase { get; set; }

    public DateTime FechaRegistroDlc { get; set; }

    public bool EstadoDlc { get; set; }

    public string? CreadoPor { get; set; }

    public DateTime FechaCreacion { get; set; }
}
