using System;
using System.Collections.Generic;

namespace Proyecto_Final_Sql_Store_Games.Models
{
    public partial class Inventario
    {
        public int Id { get; set; } // ID único para cada registro en el inventario

        public int IdProducto { get; set; } // ID del producto (puede ser un Juego, DLC o Item)
        public int IdUsuario { get; set; } // ID del usuario que compró el producto

        public DateTime FechaCompra { get; set; } // Fecha en que el usuario compró el producto

        public bool Status { get; set; } // Estado del producto, si está activo en el inventario

        public virtual Producto IdProductoNavigation { get; set; } = null!; // Relación con el producto (Juego, DLC, Item)
        public virtual Usuario IdUsuarioNavigation { get; set; } = null!; // Relación con el usuario
    }
}
