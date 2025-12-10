using System;
using System.Collections.Generic;

namespace Proyecto_Final_Sql_Store_Games.Models;

public partial class VReseñasDetallada
{
    public int IdReseña { get; set; }

    public string NombreProducto { get; set; } = null!;

    public string AutorReseña { get; set; } = null!;

    public string Comentario { get; set; } = null!;

    public int PuntuacionProxy { get; set; }

    public DateTime FechaPublicacion { get; set; }
}
