using System.Collections.Generic;

namespace Proyecto_Final_Sql_Store_Games.Models.ViewModel
{
    public class CestaViewModel
    {
        public List<ViewTiendaItem> Items { get; set; } = new();
        public List<ViewTienda> JuegosYDlcs { get; set; } = new();
        // Puedes agregar más tipos si lo necesitas
    }
}
