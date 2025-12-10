using System;
using System.Collections.Generic;

namespace Proyecto_Final_Sql_Store_Games.Models;

public partial class Juego
{
    public int IdProducto { get; set; }

    public DateTime? FechaLanzamiento { get; set; }

    public int IdDistribuidora { get; set; }

    public int? IdSaga { get; set; }

    public int? IdMotorGrafico { get; set; }

    public int IdDesarrolladora { get; set; }

    public int IdGenero { get; set; }

    public int? IdClasificacion { get; set; }

    public bool Status { get; set; }

    public DateTime DateCreate { get; set; }

    public int? IdUserCreate { get; set; }

    public int? IdUserUpdate { get; set; }

    public DateTime? DateUpdate { get; set; }

    public int? IdUserDelete { get; set; }

    public DateTime? DateDelete { get; set; }

    public int Id { get; set; }

    public virtual ICollection<Dlc> Dlcs { get; set; } = new List<Dlc>();

    public virtual Clasificacion? IdClasificacionNavigation { get; set; }

    public virtual Desarrolladora IdDesarrolladoraNavigation { get; set; } = null!;

    public virtual Distribuidora IdDistribuidoraNavigation { get; set; } = null!;

    public virtual Genero IdGeneroNavigation { get; set; } = null!;

    public virtual MotorGrafico? IdMotorGraficoNavigation { get; set; }

    public virtual Producto IdProductoNavigation { get; set; } = null!;

    public virtual Saga? IdSagaNavigation { get; set; }

    public virtual Usuario? IdUserCreateNavigation { get; set; }

    public virtual Usuario? IdUserDeleteNavigation { get; set; }

    public virtual Usuario? IdUserUpdateNavigation { get; set; }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();

    public virtual ICollection<JuegoFormaJuego> JuegoFormaJuegos { get; set; } = new List<JuegoFormaJuego>();

    public virtual ICollection<JuegoIdioma> JuegoIdiomas { get; set; } = new List<JuegoIdioma>();

    public virtual ICollection<JuegoPlataforma> JuegoPlataformas { get; set; } = new List<JuegoPlataforma>();

    public virtual ICollection<JuegoTag> JuegoTags { get; set; } = new List<JuegoTag>();

    public virtual ICollection<Logro> Logros { get; set; } = new List<Logro>();

    public virtual ICollection<RequisitoSistema> RequisitoSistemas { get; set; } = new List<RequisitoSistema>();
}
