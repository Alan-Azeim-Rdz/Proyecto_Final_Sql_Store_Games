namespace Proyecto_Final_Sql_Store_Games.Models.ViewModel
{
    public class ViewInventarioItem
    {
        public int IdProducto { get; set; }

        // Nombre del ítem (Producto)
        public string Nombre { get; set; } = null!;

        // Siempre será "Item"
        public string TipoProducto { get; set; } = "Item";

        // Fecha de la compra (venta)
        public DateTime FechaAdquisicion { get; set; }

        // Precio que pagó el usuario
        public decimal PrecioPagado { get; set; }

        // Rareza numérica que viene de Item.Rareza
        public int? Rareza { get; set; }

        // Tipo de ítem (nombre desde TipoItem)
        public string TipoItem { get; set; } = null!;

        // Juego del que proviene el ítem
        public string JuegoOrigen { get; set; } = null!;
    }
}
