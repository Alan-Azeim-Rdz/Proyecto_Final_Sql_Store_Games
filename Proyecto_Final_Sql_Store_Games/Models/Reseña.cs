using System;
using System.Collections.Generic;

namespace Proyecto_Final_Sql_Store_Games.Models;

public partial class Reseña
{
    public int Id { get; set; }

    public string? Titulo { get; set; }

    public string Contenido { get; set; } = null!;

    public int IdUsuario { get; set; }

    public int IdDlc { get; set; }

    public DateTime FechaPublicacion { get; set; }

    public bool Status { get; set; }

    public int? IdUserCreate { get; set; }

    public DateTime DateCreate { get; set; }

    public int? IdUserUpdate { get; set; }

    public DateTime? DateUpdate { get; set; }

    public int? IdUserDelete { get; set; }

    public DateTime? DateDelete { get; set; }

    public virtual Dlc IdDlcNavigation { get; set; } = null!;

    public virtual Usuario? IdUserCreateNavigation { get; set; }

    public virtual Usuario? IdUserDeleteNavigation { get; set; }

    public virtual Usuario? IdUserUpdateNavigation { get; set; }
}
