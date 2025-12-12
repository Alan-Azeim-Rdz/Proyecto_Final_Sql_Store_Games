using System;
using System.Collections.Generic;

namespace Proyecto_Final_Sql_Store_Games.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? ApellidoP { get; set; }

    public string? ApellidoM { get; set; }

    public string Correo { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public string? Telefono { get; set; }

    public int IdDireccion { get; set; }

    public int IdTipoUsuario { get; set; }

    public bool Status { get; set; }

    public int? IdUserCreate { get; set; }

    public DateTime DateCreate { get; set; }

    public int? IdUserUpdate { get; set; }

    public DateTime? DateUpdate { get; set; }

    public int? IdUserDelete { get; set; }

    public DateTime? DateDelete { get; set; }

    public virtual ICollection<AdminComunidad> AdminComunidadIdUserCreateNavigations { get; set; } = new List<AdminComunidad>();

    public virtual ICollection<AdminComunidad> AdminComunidadIdUserDeleteNavigations { get; set; } = new List<AdminComunidad>();

    public virtual ICollection<AdminComunidad> AdminComunidadIdUserUpdateNavigations { get; set; } = new List<AdminComunidad>();

    public virtual ICollection<Admin> AdminIdUserCreateNavigations { get; set; } = new List<Admin>();

    public virtual ICollection<Admin> AdminIdUserDeleteNavigations { get; set; } = new List<Admin>();

    public virtual ICollection<Admin> AdminIdUserUpdateNavigations { get; set; } = new List<Admin>();

    public virtual Admin? AdminIdUsuarioNavigation { get; set; }

    public virtual ICollection<Amigo> AmigoIdUserCreateNavigations { get; set; } = new List<Amigo>();

    public virtual ICollection<Amigo> AmigoIdUserDeleteNavigations { get; set; } = new List<Amigo>();

    public virtual ICollection<Amigo> AmigoIdUserUpdateNavigations { get; set; } = new List<Amigo>();

    public virtual ICollection<Amigo> AmigoIdUsuario1Navigations { get; set; } = new List<Amigo>();

    public virtual ICollection<Amigo> AmigoIdUsuario2Navigations { get; set; } = new List<Amigo>();

    public virtual ICollection<BolsaPunto> BolsaPuntoIdUserCreateNavigations { get; set; } = new List<BolsaPunto>();

    public virtual ICollection<BolsaPunto> BolsaPuntoIdUserDeleteNavigations { get; set; } = new List<BolsaPunto>();

    public virtual ICollection<BolsaPunto> BolsaPuntoIdUserUpdateNavigations { get; set; } = new List<BolsaPunto>();

    public virtual ICollection<CP> CPIdUserCreateNavigations { get; set; } = new List<CP>();

    public virtual ICollection<CP> CPIdUserDeleteNavigations { get; set; } = new List<CP>();

    public virtual ICollection<CP> CPIdUserUpdateNavigations { get; set; } = new List<CP>();

    public virtual ICollection<Cartera> CarteraIdUserCreateNavigations { get; set; } = new List<Cartera>();

    public virtual ICollection<Cartera> CarteraIdUserDeleteNavigations { get; set; } = new List<Cartera>();

    public virtual ICollection<Cartera> CarteraIdUserUpdateNavigations { get; set; } = new List<Cartera>();

    public virtual Cartera? CarteraIdUsuarioNavigation { get; set; }

    public virtual ICollection<Categorium> CategoriumIdUserCreateNavigations { get; set; } = new List<Categorium>();

    public virtual ICollection<Categorium> CategoriumIdUserDeleteNavigations { get; set; } = new List<Categorium>();

    public virtual ICollection<Categorium> CategoriumIdUserUpdateNavigations { get; set; } = new List<Categorium>();

    public virtual ICollection<Ciudad> CiudadIdUserCreateNavigations { get; set; } = new List<Ciudad>();

    public virtual ICollection<Ciudad> CiudadIdUserDeleteNavigations { get; set; } = new List<Ciudad>();

    public virtual ICollection<Ciudad> CiudadIdUserUpdateNavigations { get; set; } = new List<Ciudad>();

    public virtual ICollection<Clasificacion> ClasificacionIdUserCreateNavigations { get; set; } = new List<Clasificacion>();

    public virtual ICollection<Clasificacion> ClasificacionIdUserDeleteNavigations { get; set; } = new List<Clasificacion>();

    public virtual ICollection<Clasificacion> ClasificacionIdUserUpdateNavigations { get; set; } = new List<Clasificacion>();

    public virtual ICollection<Comunidad> ComunidadIdUserCreateNavigations { get; set; } = new List<Comunidad>();

    public virtual ICollection<Comunidad> ComunidadIdUserDeleteNavigations { get; set; } = new List<Comunidad>();

    public virtual ICollection<Comunidad> ComunidadIdUserUpdateNavigations { get; set; } = new List<Comunidad>();

    public virtual ICollection<Cupon> CuponIdUserCreateNavigations { get; set; } = new List<Cupon>();

    public virtual ICollection<Cupon> CuponIdUserDeleteNavigations { get; set; } = new List<Cupon>();

    public virtual ICollection<Cupon> CuponIdUserUpdateNavigations { get; set; } = new List<Cupon>();

    public virtual ICollection<Desarrolladora> DesarrolladoraIdUserCreateNavigations { get; set; } = new List<Desarrolladora>();

    public virtual ICollection<Desarrolladora> DesarrolladoraIdUserDeleteNavigations { get; set; } = new List<Desarrolladora>();

    public virtual ICollection<Desarrolladora> DesarrolladoraIdUserUpdateNavigations { get; set; } = new List<Desarrolladora>();

    public virtual ICollection<DetalleVentum> DetalleVentumIdUserCreateNavigations { get; set; } = new List<DetalleVentum>();

    public virtual ICollection<DetalleVentum> DetalleVentumIdUserDeleteNavigations { get; set; } = new List<DetalleVentum>();

    public virtual ICollection<DetalleVentum> DetalleVentumIdUserUpdateNavigations { get; set; } = new List<DetalleVentum>();

    public virtual ICollection<Direccion> DireccionIdUserCreateNavigations { get; set; } = new List<Direccion>();

    public virtual ICollection<Direccion> DireccionIdUserDeleteNavigations { get; set; } = new List<Direccion>();

    public virtual ICollection<Direccion> DireccionIdUserUpdateNavigations { get; set; } = new List<Direccion>();

    public virtual ICollection<Distribuidora> DistribuidoraIdUserCreateNavigations { get; set; } = new List<Distribuidora>();

    public virtual ICollection<Distribuidora> DistribuidoraIdUserDeleteNavigations { get; set; } = new List<Distribuidora>();

    public virtual ICollection<Distribuidora> DistribuidoraIdUserUpdateNavigations { get; set; } = new List<Distribuidora>();

    public virtual ICollection<Dlc> DlcIdUserCreateNavigations { get; set; } = new List<Dlc>();

    public virtual ICollection<Dlc> DlcIdUserDeleteNavigations { get; set; } = new List<Dlc>();

    public virtual ICollection<Dlc> DlcIdUserUpdateNavigations { get; set; } = new List<Dlc>();

    public virtual ICollection<DlcTag> DlcTagIdUserCreateNavigations { get; set; } = new List<DlcTag>();

    public virtual ICollection<DlcTag> DlcTagIdUserDeleteNavigations { get; set; } = new List<DlcTag>();

    public virtual ICollection<DlcTag> DlcTagIdUserUpdateNavigations { get; set; } = new List<DlcTag>();

    public virtual ICollection<Estado> EstadoIdUserCreateNavigations { get; set; } = new List<Estado>();

    public virtual ICollection<Estado> EstadoIdUserDeleteNavigations { get; set; } = new List<Estado>();

    public virtual ICollection<Estado> EstadoIdUserUpdateNavigations { get; set; } = new List<Estado>();

    public virtual ICollection<Evento> EventoIdUserCreateNavigations { get; set; } = new List<Evento>();

    public virtual ICollection<Evento> EventoIdUserDeleteNavigations { get; set; } = new List<Evento>();

    public virtual ICollection<Evento> EventoIdUserUpdateNavigations { get; set; } = new List<Evento>();

    public virtual ICollection<Factura> FacturaIdUserCreateNavigations { get; set; } = new List<Factura>();

    public virtual ICollection<Factura> FacturaIdUserDeleteNavigations { get; set; } = new List<Factura>();

    public virtual ICollection<Factura> FacturaIdUserUpdateNavigations { get; set; } = new List<Factura>();

    public virtual ICollection<FormaJuego> FormaJuegoIdUserCreateNavigations { get; set; } = new List<FormaJuego>();

    public virtual ICollection<FormaJuego> FormaJuegoIdUserDeleteNavigations { get; set; } = new List<FormaJuego>();

    public virtual ICollection<FormaJuego> FormaJuegoIdUserUpdateNavigations { get; set; } = new List<FormaJuego>();

    public virtual ICollection<Genero> GeneroIdUserCreateNavigations { get; set; } = new List<Genero>();

    public virtual ICollection<Genero> GeneroIdUserDeleteNavigations { get; set; } = new List<Genero>();

    public virtual ICollection<Genero> GeneroIdUserUpdateNavigations { get; set; } = new List<Genero>();

    public virtual Direccion IdDireccionNavigation { get; set; } = null!;

    public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; } = null!;

    public virtual Usuario? IdUserCreateNavigation { get; set; }

    public virtual Usuario? IdUserDeleteNavigation { get; set; }

    public virtual Usuario? IdUserUpdateNavigation { get; set; }

    public virtual ICollection<IdiomaDlc> IdiomaDlcIdUserCreateNavigations { get; set; } = new List<IdiomaDlc>();

    public virtual ICollection<IdiomaDlc> IdiomaDlcIdUserDeleteNavigations { get; set; } = new List<IdiomaDlc>();

    public virtual ICollection<IdiomaDlc> IdiomaDlcIdUserUpdateNavigations { get; set; } = new List<IdiomaDlc>();

    public virtual ICollection<Idioma> IdiomaIdUserCreateNavigations { get; set; } = new List<Idioma>();

    public virtual ICollection<Idioma> IdiomaIdUserDeleteNavigations { get; set; } = new List<Idioma>();

    public virtual ICollection<Idioma> IdiomaIdUserUpdateNavigations { get; set; } = new List<Idioma>();

    public virtual ICollection<Insignium> InsigniumIdUserCreateNavigations { get; set; } = new List<Insignium>();

    public virtual ICollection<Insignium> InsigniumIdUserDeleteNavigations { get; set; } = new List<Insignium>();

    public virtual ICollection<Insignium> InsigniumIdUserUpdateNavigations { get; set; } = new List<Insignium>();

    public virtual ICollection<Usuario> InverseIdUserCreateNavigation { get; set; } = new List<Usuario>();

    public virtual ICollection<Usuario> InverseIdUserDeleteNavigation { get; set; } = new List<Usuario>();

    public virtual ICollection<Usuario> InverseIdUserUpdateNavigation { get; set; } = new List<Usuario>();

    public virtual ICollection<Item> ItemIdUserCreateNavigations { get; set; } = new List<Item>();

    public virtual ICollection<Item> ItemIdUserDeleteNavigations { get; set; } = new List<Item>();

    public virtual ICollection<Item> ItemIdUserUpdateNavigations { get; set; } = new List<Item>();

    public virtual ICollection<Rareza> RarezaIdUserCreateNavigations { get; set; } = new List<Rareza>();

    public virtual ICollection<Rareza> RarezaIdUserDeleteNavigations { get; set; } = new List<Rareza>();

    public virtual ICollection<Rareza> RarezaIdUserUpdateNavigations { get; set; } = new List<Rareza>();

    public virtual ICollection<JuegoFormaJuego> JuegoFormaJuegoIdUserCreateNavigations { get; set; } = new List<JuegoFormaJuego>();

    public virtual ICollection<JuegoFormaJuego> JuegoFormaJuegoIdUserDeleteNavigations { get; set; } = new List<JuegoFormaJuego>();

    public virtual ICollection<JuegoFormaJuego> JuegoFormaJuegoIdUserUpdateNavigations { get; set; } = new List<JuegoFormaJuego>();

    public virtual ICollection<Juego> JuegoIdUserCreateNavigations { get; set; } = new List<Juego>();

    public virtual ICollection<Juego> JuegoIdUserDeleteNavigations { get; set; } = new List<Juego>();

    public virtual ICollection<Juego> JuegoIdUserUpdateNavigations { get; set; } = new List<Juego>();

    public virtual ICollection<JuegoIdioma> JuegoIdiomaIdUserCreateNavigations { get; set; } = new List<JuegoIdioma>();

    public virtual ICollection<JuegoIdioma> JuegoIdiomaIdUserDeleteNavigations { get; set; } = new List<JuegoIdioma>();

    public virtual ICollection<JuegoIdioma> JuegoIdiomaIdUserUpdateNavigations { get; set; } = new List<JuegoIdioma>();

    public virtual ICollection<JuegoPlataforma> JuegoPlataformaIdUserCreateNavigations { get; set; } = new List<JuegoPlataforma>();

    public virtual ICollection<JuegoPlataforma> JuegoPlataformaIdUserDeleteNavigations { get; set; } = new List<JuegoPlataforma>();

    public virtual ICollection<JuegoPlataforma> JuegoPlataformaIdUserUpdateNavigations { get; set; } = new List<JuegoPlataforma>();

    public virtual ICollection<JuegoTag> JuegoTagIdUserCreateNavigations { get; set; } = new List<JuegoTag>();

    public virtual ICollection<JuegoTag> JuegoTagIdUserDeleteNavigations { get; set; } = new List<JuegoTag>();

    public virtual ICollection<JuegoTag> JuegoTagIdUserUpdateNavigations { get; set; } = new List<JuegoTag>();

    public virtual ListaDeseo? ListaDeseoIdNavigation { get; set; }

    public virtual ICollection<ListaDeseo> ListaDeseoIdUserCreateNavigations { get; set; } = new List<ListaDeseo>();

    public virtual ICollection<ListaDeseo> ListaDeseoIdUserDeleteNavigations { get; set; } = new List<ListaDeseo>();

    public virtual ICollection<ListaDeseo> ListaDeseoIdUserUpdateNavigations { get; set; } = new List<ListaDeseo>();

    public virtual ICollection<Logro> LogroIdUserCreateNavigations { get; set; } = new List<Logro>();

    public virtual ICollection<Logro> LogroIdUserDeleteNavigations { get; set; } = new List<Logro>();

    public virtual ICollection<Logro> LogroIdUserUpdateNavigations { get; set; } = new List<Logro>();

    public virtual ICollection<MetodoPago> MetodoPagoIdUserCreateNavigations { get; set; } = new List<MetodoPago>();

    public virtual ICollection<MetodoPago> MetodoPagoIdUserDeleteNavigations { get; set; } = new List<MetodoPago>();

    public virtual ICollection<MetodoPago> MetodoPagoIdUserUpdateNavigations { get; set; } = new List<MetodoPago>();

    public virtual ICollection<Monedum> MonedumIdUserCreateNavigations { get; set; } = new List<Monedum>();

    public virtual ICollection<Monedum> MonedumIdUserDeleteNavigations { get; set; } = new List<Monedum>();

    public virtual ICollection<Monedum> MonedumIdUserUpdateNavigations { get; set; } = new List<Monedum>();

    public virtual ICollection<MotorGrafico> MotorGraficoIdUserCreateNavigations { get; set; } = new List<MotorGrafico>();

    public virtual ICollection<MotorGrafico> MotorGraficoIdUserDeleteNavigations { get; set; } = new List<MotorGrafico>();

    public virtual ICollection<MotorGrafico> MotorGraficoIdUserUpdateNavigations { get; set; } = new List<MotorGrafico>();

    public virtual ICollection<Pai> PaiIdUserCreateNavigations { get; set; } = new List<Pai>();

    public virtual ICollection<Pai> PaiIdUserDeleteNavigations { get; set; } = new List<Pai>();

    public virtual ICollection<Pai> PaiIdUserUpdateNavigations { get; set; } = new List<Pai>();

    public virtual ICollection<Plataforma> PlataformaIdUserCreateNavigations { get; set; } = new List<Plataforma>();

    public virtual ICollection<Plataforma> PlataformaIdUserDeleteNavigations { get; set; } = new List<Plataforma>();

    public virtual ICollection<Plataforma> PlataformaIdUserUpdateNavigations { get; set; } = new List<Plataforma>();

    public virtual ICollection<Producto> ProductoIdUserCreateNavigations { get; set; } = new List<Producto>();

    public virtual ICollection<Producto> ProductoIdUserDeleteNavigations { get; set; } = new List<Producto>();

    public virtual ICollection<Producto> ProductoIdUserUpdateNavigations { get; set; } = new List<Producto>();

    public virtual ICollection<Publicacion> PublicacionIdUserCreateNavigations { get; set; } = new List<Publicacion>();

    public virtual ICollection<Publicacion> PublicacionIdUserDeleteNavigations { get; set; } = new List<Publicacion>();

    public virtual ICollection<Publicacion> PublicacionIdUserUpdateNavigations { get; set; } = new List<Publicacion>();

    public virtual ICollection<Publicacion> PublicacionIdUsuarioNavigations { get; set; } = new List<Publicacion>();

    public virtual ICollection<Rason> RasonIdUserCreateNavigations { get; set; } = new List<Rason>();

    public virtual ICollection<Rason> RasonIdUserDeleteNavigations { get; set; } = new List<Rason>();

    public virtual ICollection<Rason> RasonIdUserUpdateNavigations { get; set; } = new List<Rason>();

    public virtual ICollection<Recompensa> RecompensaIdUserCreateNavigations { get; set; } = new List<Recompensa>();

    public virtual ICollection<Recompensa> RecompensaIdUserDeleteNavigations { get; set; } = new List<Recompensa>();

    public virtual ICollection<Recompensa> RecompensaIdUserUpdateNavigations { get; set; } = new List<Recompensa>();

    public virtual ICollection<Rembolso> RembolsoIdUserCreateNavigations { get; set; } = new List<Rembolso>();

    public virtual ICollection<Rembolso> RembolsoIdUserDeleteNavigations { get; set; } = new List<Rembolso>();

    public virtual ICollection<Rembolso> RembolsoIdUserUpdateNavigations { get; set; } = new List<Rembolso>();

    public virtual ICollection<Rembolso> RembolsoIdUsuarioNavigations { get; set; } = new List<Rembolso>();

    public virtual ICollection<RequisitoSistema> RequisitoSistemaIdUserCreateNavigations { get; set; } = new List<RequisitoSistema>();

    public virtual ICollection<RequisitoSistema> RequisitoSistemaIdUserDeleteNavigations { get; set; } = new List<RequisitoSistema>();

    public virtual ICollection<RequisitoSistema> RequisitoSistemaIdUserUpdateNavigations { get; set; } = new List<RequisitoSistema>();

    public virtual ICollection<Reseña> ReseñaIdUserCreateNavigations { get; set; } = new List<Reseña>();

    public virtual ICollection<Reseña> ReseñaIdUserDeleteNavigations { get; set; } = new List<Reseña>();

    public virtual ICollection<Reseña> ReseñaIdUserUpdateNavigations { get; set; } = new List<Reseña>();

    public virtual ICollection<Saga> SagaIdUserCreateNavigations { get; set; } = new List<Saga>();

    public virtual ICollection<Saga> SagaIdUserDeleteNavigations { get; set; } = new List<Saga>();

    public virtual ICollection<Saga> SagaIdUserUpdateNavigations { get; set; } = new List<Saga>();

    public virtual ICollection<Tag> TagIdUserCreateNavigations { get; set; } = new List<Tag>();

    public virtual ICollection<Tag> TagIdUserDeleteNavigations { get; set; } = new List<Tag>();

    public virtual ICollection<Tag> TagIdUserUpdateNavigations { get; set; } = new List<Tag>();

    public virtual ICollection<TarjetaRegalo> TarjetaRegaloIdUserCreateNavigations { get; set; } = new List<TarjetaRegalo>();

    public virtual ICollection<TarjetaRegalo> TarjetaRegaloIdUserDeleteNavigations { get; set; } = new List<TarjetaRegalo>();

    public virtual ICollection<TarjetaRegalo> TarjetaRegaloIdUserUpdateNavigations { get; set; } = new List<TarjetaRegalo>();

    public virtual ICollection<TarjetaRegalo> TarjetaRegaloIdUsuarioCanjeNavigations { get; set; } = new List<TarjetaRegalo>();

    public virtual ICollection<Ticket> TicketIdUserCreateNavigations { get; set; } = new List<Ticket>();

    public virtual ICollection<Ticket> TicketIdUserDeleteNavigations { get; set; } = new List<Ticket>();

    public virtual ICollection<Ticket> TicketIdUserUpdateNavigations { get; set; } = new List<Ticket>();

    public virtual ICollection<Ticket> TicketIdUsuarioNavigations { get; set; } = new List<Ticket>();

    public virtual ICollection<TipoItem> TipoItemIdUserCreateNavigations { get; set; } = new List<TipoItem>();

    public virtual ICollection<TipoItem> TipoItemIdUserDeleteNavigations { get; set; } = new List<TipoItem>();

    public virtual ICollection<TipoItem> TipoItemIdUserUpdateNavigations { get; set; } = new List<TipoItem>();

    public virtual ICollection<TipoPublicacion> TipoPublicacionIdUserCreateNavigations { get; set; } = new List<TipoPublicacion>();

    public virtual ICollection<TipoPublicacion> TipoPublicacionIdUserDeleteNavigations { get; set; } = new List<TipoPublicacion>();

    public virtual ICollection<TipoPublicacion> TipoPublicacionIdUserUpdateNavigations { get; set; } = new List<TipoPublicacion>();

    public virtual ICollection<TipoRecompensa> TipoRecompensaIdUserCreateNavigations { get; set; } = new List<TipoRecompensa>();

    public virtual ICollection<TipoRecompensa> TipoRecompensaIdUserDeleteNavigations { get; set; } = new List<TipoRecompensa>();

    public virtual ICollection<TipoRecompensa> TipoRecompensaIdUserUpdateNavigations { get; set; } = new List<TipoRecompensa>();

    public virtual ICollection<TipoRequisito> TipoRequisitoIdUserCreateNavigations { get; set; } = new List<TipoRequisito>();

    public virtual ICollection<TipoRequisito> TipoRequisitoIdUserDeleteNavigations { get; set; } = new List<TipoRequisito>();

    public virtual ICollection<TipoRequisito> TipoRequisitoIdUserUpdateNavigations { get; set; } = new List<TipoRequisito>();

    public virtual ICollection<TipoUsuario> TipoUsuarioIdUserCreateNavigations { get; set; } = new List<TipoUsuario>();

    public virtual ICollection<TipoUsuario> TipoUsuarioIdUserDeleteNavigations { get; set; } = new List<TipoUsuario>();

    public virtual ICollection<TipoUsuario> TipoUsuarioIdUserUpdateNavigations { get; set; } = new List<TipoUsuario>();

    public virtual ICollection<UsuarioComunidad> UsuarioComunidadIdUserCreateNavigations { get; set; } = new List<UsuarioComunidad>();

    public virtual ICollection<UsuarioComunidad> UsuarioComunidadIdUserDeleteNavigations { get; set; } = new List<UsuarioComunidad>();

    public virtual ICollection<UsuarioComunidad> UsuarioComunidadIdUserUpdateNavigations { get; set; } = new List<UsuarioComunidad>();

    public virtual ICollection<UsuarioComunidad> UsuarioComunidadIdUsuarioNavigations { get; set; } = new List<UsuarioComunidad>();

    public virtual ICollection<UsuarioInsignium> UsuarioInsigniumIdUserCreateNavigations { get; set; } = new List<UsuarioInsignium>();

    public virtual ICollection<UsuarioInsignium> UsuarioInsigniumIdUserDeleteNavigations { get; set; } = new List<UsuarioInsignium>();

    public virtual ICollection<UsuarioInsignium> UsuarioInsigniumIdUserUpdateNavigations { get; set; } = new List<UsuarioInsignium>();

    public virtual ICollection<UsuarioInsignium> UsuarioInsigniumIdUsuarioNavigations { get; set; } = new List<UsuarioInsignium>();

    public virtual ICollection<UsuarioTag> UsuarioTagIdUserCreateNavigations { get; set; } = new List<UsuarioTag>();

    public virtual ICollection<UsuarioTag> UsuarioTagIdUserDeleteNavigations { get; set; } = new List<UsuarioTag>();

    public virtual ICollection<UsuarioTag> UsuarioTagIdUserUpdateNavigations { get; set; } = new List<UsuarioTag>();

    public virtual ICollection<Venta> VentumIdUserCreateNavigations { get; set; } = new List<Venta>();

    public virtual ICollection<Venta> VentumIdUserDeleteNavigations { get; set; } = new List<Venta>();

    public virtual ICollection<Venta> VentumIdUserUpdateNavigations { get; set; } = new List<Venta>();

    public virtual ICollection<Venta> VentumIdUsuarioNavigations { get; set; } = new List<Venta>();
}
