using System;
using System.Collections.Generic;

namespace Proyecto_Final_Sql_Store_Games.Models
{
    public partial class Item
    {
        public int IdProducto { get; set; }

        // Clave foránea para la relación con Rareza
        public int? IdRareza { get; set; } // Cambiado de Rareza a IdRareza

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

        // Propiedad de navegación para la relación con Rareza
        public virtual Rareza? IdRarezaNavigation { get; set; }

        // Relación con otras tablas
        public virtual Juego? IdJuegoOrigenNavigation { get; set; }

        public virtual Producto IdProductoNavigation { get; set; } = null!;

        public virtual TipoItem IdTipoItemNavigation { get; set; } = null!;

        public virtual Usuario? IdUserCreateNavigation { get; set; }

        public virtual Usuario? IdUserDeleteNavigation { get; set; }

        public virtual Usuario? IdUserUpdateNavigation { get; set; }
    }
}
