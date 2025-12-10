using System;
using System.Collections.Generic;

namespace Proyecto_Final_Sql_Store_Games.Models;

public partial class VTopTagsMasUsado
{
    public int IdTag { get; set; }

    public string NombreTag { get; set; } = null!;

    public int? FrecuenciaTotal { get; set; }
}
