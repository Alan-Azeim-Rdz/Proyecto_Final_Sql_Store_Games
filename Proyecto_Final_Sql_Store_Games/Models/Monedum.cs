using System;
using System.Collections.Generic;

namespace Proyecto_Final_Sql_Store_Games.Models;

public partial class Monedum
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public bool Status { get; set; }

    public int? IdUserCreate { get; set; }

    public DateTime DateCreate { get; set; }

    public int? IdUserUpdate { get; set; }

    public DateTime? DateUpdate { get; set; }

    public int? IdUserDelete { get; set; }

    public DateTime? DateDelete { get; set; }

    public virtual ICollection<BolsaPunto> BolsaPuntos { get; set; } = new List<BolsaPunto>();

    public virtual ICollection<Cartera> Carteras { get; set; } = new List<Cartera>();

    public virtual Usuario? IdUserCreateNavigation { get; set; }

    public virtual Usuario? IdUserDeleteNavigation { get; set; }

    public virtual Usuario? IdUserUpdateNavigation { get; set; }

    public virtual ICollection<MetodoPago> MetodoPagos { get; set; } = new List<MetodoPago>();

    public virtual ICollection<TarjetaRegalo> TarjetaRegalos { get; set; } = new List<TarjetaRegalo>();
}
