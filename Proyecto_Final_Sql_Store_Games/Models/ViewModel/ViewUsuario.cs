namespace Proyecto_Final_Sql_Store_Games.Models.ViewModel
{
    public class ViewUsuario
    {
        public int IdUsuario { get; set; }  // Id del usuario
        public string Nombre { get; set; } = null!; // Nombre del usuario
        public int CantidadJuegos { get; set; }  // Cantidad de juegos/DLCs
        public int CantidadItems { get; set; }  // Cantidad de ítems
    }
}
