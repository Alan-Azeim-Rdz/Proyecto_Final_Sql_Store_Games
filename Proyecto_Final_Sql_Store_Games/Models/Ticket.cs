using System;
using System.Collections.Generic;

namespace Proyecto_Final_Sql_Store_Games.Models;

public partial class Ticket
{
    public int Id { get; set; }

    public string Contenido { get; set; } = null!;

    public int IdUsuario { get; set; }

    public int IdRazon { get; set; }

    public int? IdSupervisor { get; set; }

    public bool Status { get; set; }

    public int? IdUserCreate { get; set; }

    public DateTime DateCreate { get; set; }

    public int? IdUserUpdate { get; set; }

    public DateTime? DateUpdate { get; set; }

    public int? IdUserDelete { get; set; }

    public DateTime? DateDelete { get; set; }

    public virtual Rason IdRazonNavigation { get; set; } = null!;

    public virtual Admin? IdSupervisorNavigation { get; set; }

    public virtual Usuario? IdUserCreateNavigation { get; set; }

    public virtual Usuario? IdUserDeleteNavigation { get; set; }

    public virtual Usuario? IdUserUpdateNavigation { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
