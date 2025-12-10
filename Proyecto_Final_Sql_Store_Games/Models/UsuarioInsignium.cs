using System;
using System.Collections.Generic;

namespace Proyecto_Final_Sql_Store_Games.Models;

public partial class UsuarioInsignium
{
    public int Id { get; set; }

    public int IdUsuario { get; set; }

    public int IdInsignia { get; set; }

    public DateTime? FechaObtencion { get; set; }

    public bool Status { get; set; }

    public int? IdUserCreate { get; set; }

    public DateTime DateCreate { get; set; }

    public int? IdUserUpdate { get; set; }

    public DateTime? DateUpdate { get; set; }

    public int? IdUserDelete { get; set; }

    public DateTime? DateDelete { get; set; }

    public virtual Insignium IdInsigniaNavigation { get; set; } = null!;

    public virtual Usuario? IdUserCreateNavigation { get; set; }

    public virtual Usuario? IdUserDeleteNavigation { get; set; }

    public virtual Usuario? IdUserUpdateNavigation { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
