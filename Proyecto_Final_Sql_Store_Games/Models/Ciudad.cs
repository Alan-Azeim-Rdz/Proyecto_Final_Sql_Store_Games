using System;
using System.Collections.Generic;

namespace Proyecto_Final_Sql_Store_Games.Models;

public partial class Ciudad
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int IdEstado { get; set; }

    public bool Status { get; set; }

    public int? IdUserCreate { get; set; }

    public DateTime DateCreate { get; set; }

    public int? IdUserUpdate { get; set; }

    public DateTime? DateUpdate { get; set; }

    public int? IdUserDelete { get; set; }

    public DateTime? DateDelete { get; set; }

    public virtual ICollection<CP> CPs { get; set; } = new List<CP>();

    public virtual ICollection<Direccion> Direccions { get; set; } = new List<Direccion>();

    public virtual Estado IdEstadoNavigation { get; set; } = null!;

    public virtual Usuario? IdUserCreateNavigation { get; set; }

    public virtual Usuario? IdUserDeleteNavigation { get; set; }

    public virtual Usuario? IdUserUpdateNavigation { get; set; }
}
