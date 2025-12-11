using System;
using System.Collections.Generic;

namespace Proyecto_Final_Sql_Store_Games.Models;

public partial class Venta
{
    public int Id { get; set; }

    public string Estado { get; set; } = null!;

    public int IdUsuario { get; set; }

    public int IdMetodoPago { get; set; }

    public int IdFactura { get; set; }

    public int? IdRembolso { get; set; }

    public int? IdRecompensa { get; set; }

    public bool Status { get; set; }

    public int? IdUserCreate { get; set; }

    public DateTime DateCreate { get; set; }

    public int? IdUserUpdate { get; set; }

    public DateTime? DateUpdate { get; set; }

    public int? IdUserDelete { get; set; }

    public DateTime? DateDelete { get; set; }

    public int? IdCupon { get; set; }

    public int IdEvento { get; set; }

    public virtual ICollection<DetalleVentum> DetalleVenta { get; set; } = new List<DetalleVentum>();

    public virtual Cupon? IdCuponNavigation { get; set; }

    public virtual Evento IdEventoNavigation { get; set; } = null!;

    public virtual Factura IdFacturaNavigation { get; set; } = null!;

    public virtual MetodoPago IdMetodoPagoNavigation { get; set; } = null!;

    public virtual Recompensa? IdRecompensaNavigation { get; set; }

    public virtual Usuario? IdUserCreateNavigation { get; set; }

    public virtual Usuario? IdUserDeleteNavigation { get; set; }

    public virtual Usuario? IdUserUpdateNavigation { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
