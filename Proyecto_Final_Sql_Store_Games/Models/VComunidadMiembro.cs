using System;
using System.Collections.Generic;

namespace Proyecto_Final_Sql_Store_Games.Models;

public partial class VComunidadMiembro
{
    public int IdComunidad { get; set; }

    public string NombreComunidad { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? Creador { get; set; }

    public DateTime FechaCreacion { get; set; }

    public int? TotalMiembrosActivos { get; set; }
}
