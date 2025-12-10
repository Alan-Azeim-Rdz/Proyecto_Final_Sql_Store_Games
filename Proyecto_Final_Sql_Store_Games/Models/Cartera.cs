using System;
using System.Collections.Generic;

namespace Proyecto_Final_Sql_Store_Games.Models;

public partial class Cartera
{
    public int Id { get; set; }

    public int? Cantidad { get; set; }

    public int IdUsuario { get; set; }

    public int IdMoneda { get; set; }

    public int? IdMetodoPago { get; set; }

    public bool Status { get; set; }

    public int? IdUserCreate { get; set; }

    public DateTime DateCreate { get; set; }

    public int? IdUserUpdate { get; set; }

    public DateTime? DateUpdate { get; set; }

    public int? IdUserDelete { get; set; }

    public DateTime? DateDelete { get; set; }

    public virtual MetodoPago? IdMetodoPagoNavigation { get; set; }

    public virtual Monedum IdMonedaNavigation { get; set; } = null!;

    public virtual Usuario? IdUserCreateNavigation { get; set; }

    public virtual Usuario? IdUserDeleteNavigation { get; set; }

    public virtual Usuario? IdUserUpdateNavigation { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
