using System;
using System.Collections.Generic;

namespace Proyecto_Final_Sql_Store_Games.Models;

public partial class Direccion
{
    public int Id { get; set; }

    public string Calle { get; set; } = null!;

    public string? Colonia { get; set; }

    public int IdCP { get; set; }

    public bool Status { get; set; }

    public int? IdUserCreate { get; set; }

    public DateTime DateCreate { get; set; }

    public int? IdUserUpdate { get; set; }

    public DateTime? DateUpdate { get; set; }

    public int? IdUserDelete { get; set; }

    public DateTime? DateDelete { get; set; }

    public int? IdEstado { get; set; }

    public int? IdCiudad { get; set; }

    public int? IdPais { get; set; }

    public virtual CP IdCPNavigation { get; set; } = null!;

    public virtual Ciudad? IdCiudadNavigation { get; set; }

    public virtual Estado? IdEstadoNavigation { get; set; }

    public virtual Pai? IdPaisNavigation { get; set; }

    public virtual Usuario? IdUserCreateNavigation { get; set; }

    public virtual Usuario? IdUserDeleteNavigation { get; set; }

    public virtual Usuario? IdUserUpdateNavigation { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
