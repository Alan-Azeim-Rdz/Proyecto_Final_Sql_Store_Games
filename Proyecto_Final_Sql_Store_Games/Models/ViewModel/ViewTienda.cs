namespace Proyecto_Final_Sql_Store_Games.Models.ViewModel
{
    public class ViewTienda
    {
        // Tipo de producto: 'Juego Base' o 'DLC'
        public string TipoProducto { get; set; }

        // Identificador del producto (clave principal en Producto)
        public int IdProducto { get; set; }

        public string Nombre { get; set; }
        public decimal Precio { get; set; }

        public string Desarrolladora { get; set; }
        public string Distribuidora { get; set; }
        public string Genero { get; set; }

        // Si lo necesitas para otra cosa, se puede seguir usando
        public int IdJuego { get; set; }

        public DateTime FechaCreacion { get; set; }

        // Ya no se muestra en la tabla, pero la propiedad puede quedarse
        public string Clasificacion { get; set; }
    }
}
