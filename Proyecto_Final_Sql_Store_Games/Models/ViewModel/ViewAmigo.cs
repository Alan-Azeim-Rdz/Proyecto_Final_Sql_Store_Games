namespace Proyecto_Final_Sql_Store_Games.Models.ViewModel
{
    public class ViewAmigo
    {
        public int IdAmigo { get; set; }  // Id del amigo
        public string Nombre { get; set; } = null!; // Nombre del amigo
        public string Correo { get; set; } = null!; // Correo del amigo
        public bool EsAmigo { get; set; }  // Si es amigo o no
    }
}
