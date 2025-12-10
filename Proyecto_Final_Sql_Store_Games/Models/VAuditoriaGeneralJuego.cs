using System;
using System.Collections.Generic;

namespace Proyecto_Final_Sql_Store_Games.Models;

public partial class VAuditoriaGeneralJuego
{
    public int IdJuegoInterno { get; set; }

    public string NombreJuego { get; set; } = null!;

    public string? CreadoPor { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string? ModificadoPor { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? EliminadoPor { get; set; }

    public DateTime? FechaEliminacion { get; set; }

    public bool Status { get; set; }
}
