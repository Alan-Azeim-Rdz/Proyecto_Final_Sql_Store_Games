using System;
using System.Collections.Generic;

namespace Proyecto_Final_Sql_Store_Games.Models;

public partial class Item
{
    public int IdProducto { get; set; }

    public int? Rareza { get; set; }

    public int IdTipoItem { get; set; }

    public int? IdJuegoOrigen { get; set; }

    public bool Status { get; set; }

    public DateTime DateCreate { get; set; }

    public int? IdUserCreate { get; set; }

    public int? IdUserUpdate { get; set; }

    public DateTime? DateUpdate { get; set; }

    public int? IdUserDelete { get; set; }

    public DateTime? DateDelete { get; set; }

    public int Id { get; set; }

    public virtual Juego? IdJuegoOrigenNavigation { get; set; }

    public virtual Producto IdProductoNavigation { get; set; } = null!;

    public virtual TipoItem IdTipoItemNavigation { get; set; } = null!;

    public virtual Usuario? IdUserCreateNavigation { get; set; }

    public virtual Usuario? IdUserDeleteNavigation { get; set; }

    public virtual Usuario? IdUserUpdateNavigation { get; set; }
}
