namespace Proyecto_Final_Sql_Store_Games.Models.ViewModel
{
    // Este ViewModel corresponde a las columnas de la consulta SQL
    public class ViewTiendaItem
    {
        public int ProductoId { get; set; }
        public string ProductoNombre { get; set; } = null!;
        public int? RarezaId { get; set; } // ID de la rareza
        public string ItemRareza { get; set; } // Nombre de la rareza
        public decimal ProductoPrecio { get; set; }
        public string? JuegoOrigenNombre { get; set; } // Nombre del Producto (Juego Origen)
        public string? CategoriaNombre { get; set; } // Siempre "Item" si p.IdCategoria = 3
    }
}