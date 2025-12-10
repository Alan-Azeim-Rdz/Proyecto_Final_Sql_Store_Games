using System;
using System.Collections.Generic;

namespace Proyecto_Final_Sql_Store_Games.Models;

public partial class Dlc
{
    public int IdProducto { get; set; }

    public int IdJuegoBase { get; set; }

    public bool Status { get; set; }

    public DateTime DateCreate { get; set; }

    public int? IdUserCreate { get; set; }

    public int? IdUserUpdate { get; set; }

    public DateTime? DateUpdate { get; set; }

    public int? IdUserDelete { get; set; }

    public DateTime? DateDelete { get; set; }

    public int Id { get; set; }

    public int? IdGenero { get; set; }

    public int? IdClasificacion { get; set; }

    public int IdDistribuidora { get; set; }

    public int IdDesarrolladora { get; set; }

    public virtual ICollection<DlcTag> DlcTags { get; set; } = new List<DlcTag>();

    public virtual Clasificacion? IdClasificacionNavigation { get; set; }

    public virtual Desarrolladora IdDesarrolladoraNavigation { get; set; } = null!;

    public virtual Distribuidora IdDistribuidoraNavigation { get; set; } = null!;

    public virtual Genero? IdGeneroNavigation { get; set; }

    public virtual Juego IdJuegoBaseNavigation { get; set; } = null!;

    public virtual Producto IdProductoNavigation { get; set; } = null!;

    public virtual Usuario? IdUserCreateNavigation { get; set; }

    public virtual Usuario? IdUserDeleteNavigation { get; set; }

    public virtual Usuario? IdUserUpdateNavigation { get; set; }

    public virtual ICollection<IdiomaDlc> IdiomaDlcs { get; set; } = new List<IdiomaDlc>();

    public virtual ICollection<Reseña> Reseñas { get; set; } = new List<Reseña>();
}
