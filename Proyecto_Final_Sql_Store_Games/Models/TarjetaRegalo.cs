using System;
using System.Collections.Generic;

namespace Proyecto_Final_Sql_Store_Games.Models;

public partial class TarjetaRegalo
{
    public int Id { get; set; }

    public string Codigo { get; set; } = null!;

    public decimal Saldo { get; set; }

    public int IdMoneda { get; set; }

    public DateTime? FechaVencimiento { get; set; }

    public bool EsDigital { get; set; }

    public bool EstaCanjeada { get; set; }

    public DateTime? FechaCanje { get; set; }

    public int? IdUsuarioCanje { get; set; }

    public bool Status { get; set; }

    public DateTime DateCreate { get; set; }

    public int? IdUserCreate { get; set; }

    public int? IdUserUpdate { get; set; }

    public DateTime? DateUpdate { get; set; }

    public int? IdUserDelete { get; set; }

    public DateTime? DateDelete { get; set; }

    public virtual Monedum IdMonedaNavigation { get; set; } = null!;

    public virtual Usuario? IdUserCreateNavigation { get; set; }

    public virtual Usuario? IdUserDeleteNavigation { get; set; }

    public virtual Usuario? IdUserUpdateNavigation { get; set; }

    public virtual Usuario? IdUsuarioCanjeNavigation { get; set; }
}
