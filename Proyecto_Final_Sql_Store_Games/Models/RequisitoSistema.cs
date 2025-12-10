using System;
using System.Collections.Generic;

namespace Proyecto_Final_Sql_Store_Games.Models;

public partial class RequisitoSistema
{
    public int Id { get; set; }

    public int IdJuego { get; set; }

    public int IdTipoRequisito { get; set; }

    public string SistemaOperativo { get; set; } = null!;

    public string? Procesador { get; set; }

    public string? MemoriaRam { get; set; }

    public string? TarjetaGrafica { get; set; }

    public string? Almacenamiento { get; set; }

    public bool Status { get; set; }

    public DateTime DateCreate { get; set; }

    public int? IdUserCreate { get; set; }

    public int? IdUserUpdate { get; set; }

    public DateTime? DateUpdate { get; set; }

    public int? IdUserDelete { get; set; }

    public DateTime? DateDelete { get; set; }

    public virtual Juego IdJuegoNavigation { get; set; } = null!;

    public virtual TipoRequisito IdTipoRequisitoNavigation { get; set; } = null!;

    public virtual Usuario? IdUserCreateNavigation { get; set; }

    public virtual Usuario? IdUserDeleteNavigation { get; set; }

    public virtual Usuario? IdUserUpdateNavigation { get; set; }
}
