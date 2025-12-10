using System;
using System.Collections.Generic;

namespace Proyecto_Final_Sql_Store_Games.Models;

public partial class IdiomaDlc
{
    public int IdDlc { get; set; }

    public int IdIdioma { get; set; }

    public DateTime DateCreate { get; set; }

    public int Id { get; set; }

    public int? IdUserCreate { get; set; }

    public bool Status { get; set; }

    public int? IdUserUpdate { get; set; }

    public DateTime? DateUpdate { get; set; }

    public int? IdUserDelete { get; set; }

    public DateTime? DateDelete { get; set; }

    public virtual Dlc IdDlcNavigation { get; set; } = null!;

    public virtual Idioma IdIdiomaNavigation { get; set; } = null!;

    public virtual Usuario? IdUserCreateNavigation { get; set; }

    public virtual Usuario? IdUserDeleteNavigation { get; set; }

    public virtual Usuario? IdUserUpdateNavigation { get; set; }
}
