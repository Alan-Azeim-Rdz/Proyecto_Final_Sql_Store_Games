namespace Proyecto_Final_Sql_Store_Games.Models
{
    public class Rareza
    {
        public int Id { get; set; }            // Llave primaria
        public string Nombre { get; set; }     // Nombre de la rareza
        public bool Status { get; set; }

        public int? IdUserCreate { get; set; }

        public DateTime DateCreate { get; set; }

        public int? IdUserUpdate { get; set; }

        public DateTime? DateUpdate { get; set; }

        public int? IdUserDelete { get; set; }

        public DateTime? DateDelete { get; set; }

        public virtual Usuario? IdUserCreateNavigation { get; set; }

        public virtual Usuario? IdUserDeleteNavigation { get; set; }

        public virtual Usuario? IdUserUpdateNavigation { get; set; }
    }
}
