using System;
using System.Collections.Generic;

namespace Proyecto_Final_Sql_Store_Games.Models;

public partial class VUsuarioPerfilCompleto
{
    public int IdUsuario { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string TipoUsuario { get; set; } = null!;

    public string PaisRegistro { get; set; } = null!;

    public string? MonedaPreferida { get; set; }

    public DateTime FechaRegistro { get; set; }

    public bool EstadoCuenta { get; set; }
}
