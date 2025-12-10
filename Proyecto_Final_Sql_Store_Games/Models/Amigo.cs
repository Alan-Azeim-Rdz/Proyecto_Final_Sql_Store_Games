using System;
using System.Collections.Generic;

namespace Proyecto_Final_Sql_Store_Games.Models;

public partial class Amigo
{
    public int IdUsuario1 { get; set; }

    public int IdUsuario2 { get; set; }

    public DateTime? Fecha { get; set; }

    public bool Status { get; set; }

    public int? IdUserCreate { get; set; }

    public DateTime DateCreate { get; set; }

    public int? IdUserUpdate { get; set; }

    public DateTime? DateUpdate { get; set; }

    public int? IdUserDelete { get; set; }

    public DateTime? DateDelete { get; set; }

    public int Id { get; set; }

    public virtual Usuario? IdUserCreateNavigation { get; set; }

    public virtual Usuario? IdUserDeleteNavigation { get; set; }

    public virtual Usuario? IdUserUpdateNavigation { get; set; }

    public virtual Usuario IdUsuario1Navigation { get; set; } = null!;

    public virtual Usuario IdUsuario2Navigation { get; set; } = null!;
}
