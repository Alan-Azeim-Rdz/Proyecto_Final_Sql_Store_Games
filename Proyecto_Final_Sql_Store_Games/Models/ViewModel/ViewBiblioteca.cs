namespace Proyecto_Final_Sql_Store_Games.Models.ViewModel
{
    public class ViewBiblioteca
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string TipoProducto { get; set; } // 'Juego' o 'DLC'
        public DateTime FechaAdquisicion { get; set; } // Fecha de la venta
        public decimal PrecioPagado { get; set; }
        public string Desarrolladora { get; set; }
        public string Distribuidora { get; set; }
        public string Genero { get; set; }
        public string? JuegoBase { get; set; }
        public DateTime FechaLanzamientoProducto { get; set; }
        public bool EsActivo { get; set; } // Indica si el producto está activo (no reembolsado)
    }
}
