namespace Proyecto_Final_Sql_Store_Games.Models.ViewModel
{
    public class ViewTienda
    {
        // --- Propiedades que están causando el error ---
        public string TipoProducto { get; set; } // Nuevo campo: 'Juego Base' o 'DLC'
        public string Nombre { get; set; }
        public decimal Precio { get; set; } // O usa 'double' o el tipo que corresponda en tu BD

        // --- Propiedades que ya usabas o necesitas para la consulta unificada ---
        public string Desarrolladora { get; set; }
        public string Distribuidora { get; set; }
        public string Genero { get; set; }

        // Si la consulta las sigue necesitando o las usas para ordenar:
        public int IdJuego { get; set; }
        public DateTime FechaCreacion { get; set; } // Asumiendo que la fecha de creación del producto está en Producto
        public string Clasificacion { get; set; }
    }
}
