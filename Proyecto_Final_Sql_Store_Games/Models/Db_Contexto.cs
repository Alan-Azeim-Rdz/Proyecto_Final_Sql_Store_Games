using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_Final_Sql_Store_Games.Models;

public partial class Db_Contexto : DbContext
{
    public Db_Contexto()
    {
    }

    public Db_Contexto(DbContextOptions<Db_Contexto> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<AdminComunidad> AdminComunidads { get; set; }

    public virtual DbSet<Amigo> Amigos { get; set; }

    public virtual DbSet<BolsaPunto> BolsaPuntos { get; set; }

    public virtual DbSet<CP> CPs { get; set; }

    public virtual DbSet<Cartera> Carteras { get; set; }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Ciudad> Ciudads { get; set; }

    public virtual DbSet<Clasificacion> Clasificacions { get; set; }

    public virtual DbSet<Comunidad> Comunidads { get; set; }

    public virtual DbSet<Cupon> Cupons { get; set; }

    public virtual DbSet<Desarrolladora> Desarrolladoras { get; set; }

    public virtual DbSet<DetalleVentum> DetalleVenta { get; set; }

    public virtual DbSet<Direccion> Direccions { get; set; }

    public virtual DbSet<Distribuidora> Distribuidoras { get; set; }

    public virtual DbSet<Dlc> Dlcs { get; set; }

    public virtual DbSet<DlcTag> DlcTags { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Evento> Eventos { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<FormaJuego> FormaJuegos { get; set; }

    public virtual DbSet<Genero> Generos { get; set; }

    public virtual DbSet<Idioma> Idiomas { get; set; }

    public virtual DbSet<IdiomaDlc> IdiomaDlcs { get; set; }

    public virtual DbSet<Insignium> Insignia { get; set; }

    public DbSet<Item> Items { get; set; }        // DbSet para la tabla Item

    public DbSet<Rareza> Rareza { get; set; }

    public virtual DbSet<Juego> Juegos { get; set; }

    public virtual DbSet<JuegoFormaJuego> JuegoFormaJuegos { get; set; }

    public virtual DbSet<JuegoIdioma> JuegoIdiomas { get; set; }

    public virtual DbSet<JuegoPlataforma> JuegoPlataformas { get; set; }

    public virtual DbSet<JuegoTag> JuegoTags { get; set; }

    public virtual DbSet<ListaDeseo> ListaDeseos { get; set; }

    public virtual DbSet<Logro> Logros { get; set; }

    public virtual DbSet<MetodoPago> MetodoPagos { get; set; }

    public virtual DbSet<Monedum> Moneda { get; set; }

    public virtual DbSet<MotorGrafico> MotorGraficos { get; set; }

    public virtual DbSet<Pai> Pais { get; set; }

    public virtual DbSet<Plataforma> Plataformas { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Publicacion> Publicacions { get; set; }

    public virtual DbSet<Rason> Rasons { get; set; }

    public virtual DbSet<Recompensa> Recompensas { get; set; }

    public virtual DbSet<Rembolso> Rembolsos { get; set; }

    public virtual DbSet<RequisitoSistema> RequisitoSistemas { get; set; }

    public virtual DbSet<Reseña> Reseñas { get; set; }

    public virtual DbSet<Saga> Sagas { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<TarjetaRegalo> TarjetaRegalos { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<TipoItem> TipoItems { get; set; }

    public virtual DbSet<TipoPublicacion> TipoPublicacions { get; set; }

    public virtual DbSet<TipoRecompensa> TipoRecompensas { get; set; }

    public virtual DbSet<TipoRequisito> TipoRequisitos { get; set; }

    public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioComunidad> UsuarioComunidads { get; set; }

    public virtual DbSet<UsuarioInsignium> UsuarioInsignia { get; set; }

    public virtual DbSet<UsuarioTag> UsuarioTags { get; set; }

    public virtual DbSet<VAuditoriaGeneralJuego> VAuditoriaGeneralJuegos { get; set; }

    public virtual DbSet<VComunidadMiembro> VComunidadMiembros { get; set; }

    public virtual DbSet<VDlcResumenXJuego> VDlcResumenXJuegos { get; set; }

    public virtual DbSet<Inventario> Inventarios { get; set; }

    public virtual DbSet<VInventarioProducto> VInventarioProductos { get; set; }

    public virtual DbSet<VJuegoDetallesConsolidado> VJuegoDetallesConsolidados { get; set; }

    public virtual DbSet<VReseñasDetallada> VReseñasDetalladas { get; set; }

    public virtual DbSet<VTopTagsMasUsado> VTopTagsMasUsados { get; set; }

    public virtual DbSet<VUsuarioPerfilCompleto> VUsuarioPerfilCompletos { get; set; }

    public virtual DbSet<VVentaDetalleCompleto> VVentaDetalleCompletos { get; set; }

    public virtual DbSet<VVentasAnualesXPai> VVentasAnualesXPais { get; set; }

    public virtual DbSet<Venta> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LUX_ALAN\\SQLEXPRESS;Database=STEAM_OG;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Admin__3214EC079968DF28");

            entity.ToTable("Admin");

            entity.HasIndex(e => e.IdUsuario, "UQ__Admin__EF59F76305724C31").IsUnique();

            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.FechaInicioRol)
                .HasColumnType("datetime")
                .HasColumnName("fecha_inicio_rol");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_usuario");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.AdminIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_Admin_UserCreate");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.AdminIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Admin_UserDelete");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.AdminIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Admin_UserUpdate");

            entity.HasOne(d => d.IdUsuarioNavigation).WithOne(p => p.AdminIdUsuarioNavigation)
                .HasForeignKey<Admin>(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Admin_IdUsuario_Funcional");
        });

        modelBuilder.Entity<AdminComunidad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Admin_Co__3214EC073833B672");

            entity.ToTable("Admin_Comunidad");

            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.IdAdmin).HasColumnName("Id_admin");
            entity.Property(e => e.IdComunidad).HasColumnName("Id_comunidad");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.IdAdminNavigation).WithMany(p => p.AdminComunidads)
                .HasForeignKey(d => d.IdAdmin)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AdminComunidad_Admin");

            entity.HasOne(d => d.IdComunidadNavigation).WithMany(p => p.AdminComunidads)
                .HasForeignKey(d => d.IdComunidad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AdminComunidad_Comunidad");

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.AdminComunidadIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_Admin_Comunidad_UserCreate");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.AdminComunidadIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Admin_Comunidad_UserDelete");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.AdminComunidadIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Admin_Comunidad_UserUpdate");
        });

        modelBuilder.Entity<Amigo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Amigo_NewId");

            entity.ToTable("Amigo");

            entity.HasIndex(e => new { e.IdUsuario1, e.IdUsuario2 }, "UC_Amigo_Usuarios").IsUnique();

            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.IdUsuario1).HasColumnName("Id_usuario_1");
            entity.Property(e => e.IdUsuario2).HasColumnName("Id_usuario_2");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.AmigoIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_Amigo_IdUserCreate_FinalAudit");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.AmigoIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Amigo_IdUserDelete_FinalAudit");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.AmigoIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Amigo_IdUserUpdate_FinalAudit");

            entity.HasOne(d => d.IdUsuario1Navigation).WithMany(p => p.AmigoIdUsuario1Navigations)
                .HasForeignKey(d => d.IdUsuario1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Amigo_Usuario_1");

            entity.HasOne(d => d.IdUsuario2Navigation).WithMany(p => p.AmigoIdUsuario2Navigations)
                .HasForeignKey(d => d.IdUsuario2)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Amigo_Usuario_2");
        });

        modelBuilder.Entity<BolsaPunto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Bolsa_pu__3214EC07ED056067");

            entity.ToTable("Bolsa_puntos");

            entity.HasIndex(e => e.IdUsuario, "UQ_BolsaPuntos_Usuario").IsUnique();

            entity.HasIndex(e => e.IdUsuario, "UQ__Bolsa_pu__EF59F7631340955A").IsUnique();

            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.IdMetodoPago).HasColumnName("Id_metodo_pago");
            entity.Property(e => e.IdMoneda).HasColumnName("Id_moneda");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_usuario");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.IdMetodoPagoNavigation).WithMany(p => p.BolsaPuntos)
                .HasForeignKey(d => d.IdMetodoPago)
                .HasConstraintName("FK_BolsaPuntos_MetodoPago");

            entity.HasOne(d => d.IdMonedaNavigation).WithMany(p => p.BolsaPuntos)
                .HasForeignKey(d => d.IdMoneda)
                .HasConstraintName("FK_BolsaPuntos_Moneda");

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.BolsaPuntoIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_Bolsa_puntos_UserCreate");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.BolsaPuntoIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Bolsa_puntos_UserDelete");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.BolsaPuntoIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Bolsa_puntos_UserUpdate");
        });

        modelBuilder.Entity<CP>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__C_P__3214EC07A83085A4");

            entity.ToTable("C_P");

            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.IdCiudad).HasColumnName("Id_ciudad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.IdCiudadNavigation).WithMany(p => p.CPs)
                .HasForeignKey(d => d.IdCiudad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CP_Ciudad");

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.CPIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_C_P_UserCreate");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.CPIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_C_P_UserDelete");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.CPIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_C_P_UserUpdate");
        });

        modelBuilder.Entity<Cartera>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cartera__3214EC078CDF25E2");

            entity.ToTable("Cartera");

            entity.HasIndex(e => e.IdUsuario, "UQ_Cartera_Usuario").IsUnique();

            entity.HasIndex(e => e.IdUsuario, "UQ__Cartera__EF59F7637CF70EDE").IsUnique();

            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.IdMetodoPago).HasColumnName("Id_metodo_pago");
            entity.Property(e => e.IdMoneda).HasColumnName("Id_moneda");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_usuario");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.IdMetodoPagoNavigation).WithMany(p => p.Carteras)
                .HasForeignKey(d => d.IdMetodoPago)
                .HasConstraintName("FK_Cartera_MetodoPago");

            entity.HasOne(d => d.IdMonedaNavigation).WithMany(p => p.Carteras)
                .HasForeignKey(d => d.IdMoneda)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cartera_Moneda");

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.CarteraIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_Cartera_UserCreate");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.CarteraIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Cartera_UserDelete");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.CarteraIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Cartera_UserUpdate");

            entity.HasOne(d => d.IdUsuarioNavigation).WithOne(p => p.CarteraIdUsuarioNavigation)
                .HasForeignKey<Cartera>(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cartera_Usuario");
        });

        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC071609F8BD");

            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.CategoriumIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_Categoria_UserCreate");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.CategoriumIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Categoria_UserDelete");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.CategoriumIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Categoria_UserUpdate");
        });

        modelBuilder.Entity<Ciudad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ciudad__3214EC07E45E04A6");

            entity.ToTable("Ciudad");

            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.IdEstado).HasColumnName("Id_estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Ciudads)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ciudad_Estado_ReOrg");

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.CiudadIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_Ciudad_UserCreate");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.CiudadIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Ciudad_UserDelete");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.CiudadIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Ciudad_UserUpdate");
        });

        modelBuilder.Entity<Clasificacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clasific__3214EC07644FCC7E");

            entity.ToTable("Clasificacion");

            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.ClasificacionIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_Clasificacion_UserCreate");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.ClasificacionIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Clasificacion_UserDelete");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.ClasificacionIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Clasificacion_UserUpdate");
        });

        modelBuilder.Entity<Comunidad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comunida__3214EC076F255935");

            entity.ToTable("Comunidad");

            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.ComunidadIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_Comunidad_UserCreate");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.ComunidadIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Comunidad_UserDelete");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.ComunidadIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Comunidad_UserUpdate");
        });

        modelBuilder.Entity<Cupon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cupon__3214EC070D6E36B4");

            entity.ToTable("Cupon");

            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Porcentaje).HasColumnName("porcentaje");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.CuponIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_Cupon_UserCreate");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.CuponIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Cupon_UserDelete");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.CuponIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Cupon_UserUpdate");
        });

        modelBuilder.Entity<Desarrolladora>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Desarrol__3214EC07731422B5");

            entity.ToTable("Desarrolladora");

            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.DesarrolladoraIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_Desarrolladora_UserCreate");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.DesarrolladoraIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Desarrolladora_UserDelete");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.DesarrolladoraIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Desarrolladora_UserUpdate");
        });

        modelBuilder.Entity<DetalleVentum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Detalle_Venta_New");

            entity.ToTable("Detalle_Venta");

            entity.HasIndex(e => new { e.IdVenta, e.IdProducto }, "UQ_DetalleVenta_Composite").IsUnique();

            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.IdProducto).HasColumnName("Id_producto");
            entity.Property(e => e.IdVenta).HasColumnName("Id_venta");
            entity.Property(e => e.PrecioUnitario).HasColumnName("precio_unitario");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleVenta_Producto");

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.DetalleVentumIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_Detalle_Venta_UserCreate");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.DetalleVentumIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Detalle_Venta_UserDelete");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.DetalleVentumIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Detalle_Venta_UserUpdate");

            entity.HasOne(d => d.IdVentaNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.IdVenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleVenta_Venta");
        });

        modelBuilder.Entity<Direccion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Direccio__3214EC07C70F2688");

            entity.ToTable("Direccion");

            entity.Property(e => e.Calle)
                .HasMaxLength(100)
                .HasColumnName("calle");
            entity.Property(e => e.Colonia)
                .HasMaxLength(100)
                .HasColumnName("colonia");
            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.IdCP).HasColumnName("Id_c_p");
            entity.Property(e => e.IdCiudad).HasColumnName("Id_ciudad");
            entity.Property(e => e.IdEstado).HasColumnName("Id_estado");
            entity.Property(e => e.IdPais).HasColumnName("Id_pais");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.IdCPNavigation).WithMany(p => p.Direccions)
                .HasForeignKey(d => d.IdCP)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Direccion_CP_Revisada_Final");

            entity.HasOne(d => d.IdCiudadNavigation).WithMany(p => p.Direccions)
                .HasForeignKey(d => d.IdCiudad)
                .HasConstraintName("FK_Direccion_Ciudad");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Direccions)
                .HasForeignKey(d => d.IdEstado)
                .HasConstraintName("FK_Direccion_Estado");

            entity.HasOne(d => d.IdPaisNavigation).WithMany(p => p.Direccions)
                .HasForeignKey(d => d.IdPais)
                .HasConstraintName("FK_Direccion_Pais");

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.DireccionIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_Direccion_UserCreate");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.DireccionIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Direccion_UserDelete");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.DireccionIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Direccion_UserUpdate");
        });

        modelBuilder.Entity<Distribuidora>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Distribu__3214EC071F71B6D2");

            entity.ToTable("Distribuidora");

            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(400)
                .HasColumnName("nombre");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.DistribuidoraIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_Distribuidora_UserCreate");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.DistribuidoraIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Distribuidora_UserDelete");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.DistribuidoraIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Distribuidora_UserUpdate");
        });

        modelBuilder.Entity<Dlc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Dlc_NewId");

            entity.ToTable("Dlc");

            entity.HasIndex(e => e.IdProducto, "UQ_Dlc_IdProducto").IsUnique();

            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.IdClasificacion).HasColumnName("Id_clasificacion");
            entity.Property(e => e.IdDesarrolladora).HasColumnName("Id_desarrolladora");
            entity.Property(e => e.IdDistribuidora).HasColumnName("Id_distribuidora");
            entity.Property(e => e.IdGenero).HasColumnName("Id_genero");
            entity.Property(e => e.IdJuegoBase).HasColumnName("Id_juego_base");
            entity.Property(e => e.IdProducto).HasColumnName("Id_producto");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.IdClasificacionNavigation).WithMany(p => p.Dlcs)
                .HasForeignKey(d => d.IdClasificacion)
                .HasConstraintName("FK_Dlc_Clasificacion");

            entity.HasOne(d => d.IdDesarrolladoraNavigation).WithMany(p => p.Dlcs)
                .HasForeignKey(d => d.IdDesarrolladora)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Dlc_Desarrolladora");

            entity.HasOne(d => d.IdDistribuidoraNavigation).WithMany(p => p.Dlcs)
                .HasForeignKey(d => d.IdDistribuidora)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Dlc_Distribuidora");

            entity.HasOne(d => d.IdGeneroNavigation).WithMany(p => p.Dlcs)
                .HasForeignKey(d => d.IdGenero)
                .HasConstraintName("FK_Dlc_Genero");

            entity.HasOne(d => d.IdJuegoBaseNavigation).WithMany(p => p.Dlcs)
                .HasPrincipalKey(p => p.IdProducto)
                .HasForeignKey(d => d.IdJuegoBase)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Dlc_JuegoBase_Recreated");

            entity.HasOne(d => d.IdProductoNavigation).WithOne(p => p.Dlc)
                .HasForeignKey<Dlc>(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Dlc_Producto");

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.DlcIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_Dlc_UserCreate");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.DlcIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Dlc_UserDelete");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.DlcIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Dlc_UserUpdate");
        });

        modelBuilder.Entity<DlcTag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Dlc_Tag_New");

            entity.ToTable("Dlc_Tag");

            entity.HasIndex(e => new { e.IdDlc, e.IdTag }, "UQ_DlcTag_Composite").IsUnique();

            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.IdDlc).HasColumnName("Id_dlc");
            entity.Property(e => e.IdTag).HasColumnName("Id_tag");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.IdDlcNavigation).WithMany(p => p.DlcTags)
                .HasForeignKey(d => d.IdDlc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DlcTag_Dlc");

            entity.HasOne(d => d.IdTagNavigation).WithMany(p => p.DlcTags)
                .HasForeignKey(d => d.IdTag)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DlcTag_Tag");

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.DlcTagIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_DlcTag_UserCreate_Alter");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.DlcTagIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Dlc_Tag_IdUserDelete_FinalAudit");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.DlcTagIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Dlc_Tag_IdUserUpdate_FinalAudit");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Estado__3214EC07BF1B5485");

            entity.ToTable("Estado");

            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.IdPais).HasColumnName("Id_pais");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.IdPaisNavigation).WithMany(p => p.Estados)
                .HasForeignKey(d => d.IdPais)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Estado_Pais");

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.EstadoIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_Estado_UserCreate");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.EstadoIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Estado_UserDelete");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.EstadoIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Estado_UserUpdate");
        });

        modelBuilder.Entity<Evento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Evento__3214EC0749016356");

            entity.ToTable("Evento");

            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaFin)
                .HasColumnType("datetime")
                .HasColumnName("fecha_fin");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("datetime")
                .HasColumnName("fecha_inicio");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.PorcentajeDescuentoGlobal).HasColumnName("porcentaje_descuento_global");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.EventoIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_Evento_UserCreate");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.EventoIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Evento_UserDelete");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.EventoIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Evento_UserUpdate");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Factura__3214EC0767C80F1D");

            entity.ToTable("Factura");

            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .HasColumnName("descripcion");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.FacturaIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_Factura_UserCreate");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.FacturaIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Factura_UserDelete");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.FacturaIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Factura_UserUpdate");
        });

        modelBuilder.Entity<FormaJuego>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Forma_ju__3214EC07326EE103");

            entity.ToTable("Forma_juego");

            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.FormaJuegoIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_Forma_juego_UserCreate");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.FormaJuegoIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Forma_juego_UserDelete");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.FormaJuegoIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Forma_juego_UserUpdate");
        });

        modelBuilder.Entity<Genero>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Genero__3214EC07232E4F96");

            entity.ToTable("Genero");

            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.GeneroIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_Genero_UserCreate");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.GeneroIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Genero_UserDelete");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.GeneroIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Genero_UserUpdate");
        });

        modelBuilder.Entity<Idioma>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Idioma__3214EC07B23F244D");

            entity.ToTable("Idioma");

            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.IdiomaIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_Idioma_UserCreate");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.IdiomaIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Idioma_UserDelete");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.IdiomaIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Idioma_UserUpdate");
        });

        modelBuilder.Entity<IdiomaDlc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Idioma_Dlc_New");

            entity.ToTable("Idioma_Dlc");

            entity.HasIndex(e => new { e.IdDlc, e.IdIdioma }, "UQ_IdiomaDlc_Composite").IsUnique();

            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.IdDlc).HasColumnName("Id_dlc");
            entity.Property(e => e.IdIdioma).HasColumnName("Id_idioma");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.IdDlcNavigation).WithMany(p => p.IdiomaDlcs)
                .HasForeignKey(d => d.IdDlc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IdiomaDlc_Dlc");

            entity.HasOne(d => d.IdIdiomaNavigation).WithMany(p => p.IdiomaDlcs)
                .HasForeignKey(d => d.IdIdioma)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IdiomaDlc_Idioma");

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.IdiomaDlcIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_IdiomaDlc_UserCreate_Alter");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.IdiomaDlcIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Idioma_Dlc_IdUserDelete_FinalAudit");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.IdiomaDlcIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Idioma_Dlc_IdUserUpdate_FinalAudit");
        });

        modelBuilder.Entity<Insignium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Insignia__3214EC07D8E5979D");

            entity.Property(e => e.Año)
                .HasColumnType("datetime")
                .HasColumnName("año");
            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.InsigniumIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_Insignia_UserCreate");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.InsigniumIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Insignia_UserDelete");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.InsigniumIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Insignia_UserUpdate");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            // Configuración de la clave primaria
            entity.HasKey(e => e.Id).HasName("PK_Item_NewId");

            // Configuración de la tabla
            entity.ToTable("Item");

            // Índice único para el campo IdProducto
            entity.HasIndex(e => e.IdProducto, "UQ_Item_IdProducto").IsUnique();

            // Propiedades de fecha de auditoría
            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")  // Fecha de creación por defecto
                .HasColumnType("datetime");

            entity.Property(e => e.DateDelete).HasColumnType("datetime");

            entity.Property(e => e.DateUpdate).HasColumnType("datetime");

            // Configuración de las propiedades de columnas
            entity.Property(e => e.IdJuegoOrigen).HasColumnName("Id_juego_origen");
            entity.Property(e => e.IdProducto).HasColumnName("Id_producto");
            entity.Property(e => e.IdTipoItem).HasColumnName("Id_tipo_item");
            entity.Property(e => e.IdRareza).HasColumnName("IdRareza");  // Clave foránea para Rareza
            entity.Property(e => e.Status).HasDefaultValue(true);  // Estado activo por defecto

            // Relaciones de claves foráneas

            // Relación con la tabla Juego (IdJuegoOrigen)
            entity.HasOne(d => d.IdJuegoOrigenNavigation)
                .WithMany(p => p.Items)
                .HasPrincipalKey(p => p.IdProducto)  // Relación con IdProducto de Juego
                .HasForeignKey(d => d.IdJuegoOrigen)
                .HasConstraintName("FK_Item_JuegoOrigen");

            // Relación con la tabla Producto (IdProducto)
            entity.HasOne(d => d.IdProductoNavigation)
                .WithOne(p => p.Item)
                .HasForeignKey<Item>(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Item_Producto");

            // Relación con la tabla TipoItem (IdTipoItem)
            entity.HasOne(d => d.IdTipoItemNavigation)
                .WithMany(p => p.Items)
                .HasForeignKey(d => d.IdTipoItem)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Item_Tipo");

            // Relación con la tabla Rareza (IdRareza)
            entity.HasOne(d => d.IdRarezaNavigation)  // Propiedad de navegación hacia Rareza
                .WithMany()  // No hay relación inversa en Rareza
                .HasForeignKey(d => d.IdRareza)  // La clave foránea en Item
                .OnDelete(DeleteBehavior.ClientSetNull)  // En caso de eliminación de Rareza, establecer a NULL
                .HasConstraintName("FK_Item_Rareza");

            // Relaciones de auditoría con la tabla Usuario
            entity.HasOne(d => d.IdUserCreateNavigation)
                .WithMany(p => p.ItemIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_Item_UserCreate");

            entity.HasOne(d => d.IdUserDeleteNavigation)
                .WithMany(p => p.ItemIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Item_UserDelete");

            entity.HasOne(d => d.IdUserUpdateNavigation)
                .WithMany(p => p.ItemIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Item_UserUpdate");
        });


        modelBuilder.Entity<Rareza>(entity =>
        {
            // Configuración de la clave primaria
            entity.HasKey(e => e.Id).HasName("PK__Rareza__3214EC070D6E36B4");

            // Configuración de la tabla
            entity.ToTable("Rareza");

            // Configuración de las propiedades
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");

            entity.Property(e => e.Status)
                .HasDefaultValue(true);  // Estado activo por defecto

            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")  // Fecha de creación por defecto
                .HasColumnType("datetime");

            entity.Property(e => e.DateUpdate)
                .HasColumnType("datetime");

            entity.Property(e => e.DateDelete)
                .HasColumnType("datetime");

            // Configuración de las relaciones
            entity.HasOne(d => d.IdUserCreateNavigation)
                .WithMany(p => p.RarezaIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_Rareza_UserCreate");

            entity.HasOne(d => d.IdUserUpdateNavigation)
                .WithMany(p => p.RarezaIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Rareza_UserUpdate");

            entity.HasOne(d => d.IdUserDeleteNavigation)
                .WithMany(p => p.RarezaIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Rareza_UserDelete");
        });


        modelBuilder.Entity<Juego>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Juego_NewId");

            entity.ToTable("Juego");

            entity.HasIndex(e => e.IdProducto, "UQ_Juego_IdProducto").IsUnique();

            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.FechaLanzamiento)
                .HasColumnType("datetime")
                .HasColumnName("fecha_lanzamiento");
            entity.Property(e => e.IdClasificacion).HasColumnName("Id_clasificacion");
            entity.Property(e => e.IdDesarrolladora).HasColumnName("Id_desarrolladora");
            entity.Property(e => e.IdDistribuidora).HasColumnName("Id_distribuidora");
            entity.Property(e => e.IdGenero).HasColumnName("Id_genero");
            entity.Property(e => e.IdMotorGrafico).HasColumnName("Id_motor_grafico");
            entity.Property(e => e.IdProducto).HasColumnName("Id_producto");
            entity.Property(e => e.IdSaga).HasColumnName("Id_saga");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.IdClasificacionNavigation).WithMany(p => p.Juegos)
                .HasForeignKey(d => d.IdClasificacion)
                .HasConstraintName("FK_Juego_Clasificacion");

            entity.HasOne(d => d.IdDesarrolladoraNavigation).WithMany(p => p.Juegos)
                .HasForeignKey(d => d.IdDesarrolladora)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Juego_Desarrolladora");

            entity.HasOne(d => d.IdDistribuidoraNavigation).WithMany(p => p.Juegos)
                .HasForeignKey(d => d.IdDistribuidora)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Juego_Distribuidora");

            entity.HasOne(d => d.IdGeneroNavigation).WithMany(p => p.Juegos)
                .HasForeignKey(d => d.IdGenero)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Juego_Genero");

            entity.HasOne(d => d.IdMotorGraficoNavigation).WithMany(p => p.Juegos)
                .HasForeignKey(d => d.IdMotorGrafico)
                .HasConstraintName("FK_Juego_MotorGrafico");

            entity.HasOne(d => d.IdProductoNavigation).WithOne(p => p.Juego)
                .HasForeignKey<Juego>(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Juego_Producto");

            entity.HasOne(d => d.IdSagaNavigation).WithMany(p => p.Juegos)
                .HasForeignKey(d => d.IdSaga)
                .HasConstraintName("FK_Juego_Saga");

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.JuegoIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_Juego_UserCreate");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.JuegoIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Juego_UserDelete");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.JuegoIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Juego_UserUpdate");
        });

        modelBuilder.Entity<JuegoFormaJuego>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Juego_Forma_juego_New");

            entity.ToTable("Juego_Forma_juego");

            entity.HasIndex(e => new { e.IdJuego, e.IdFormaJuego }, "UQ_JFJ_Composite").IsUnique();

            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())", "DF_Juego_Forma_juego_DateCreate")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.IdFormaJuego).HasColumnName("Id_forma_juego");
            entity.Property(e => e.IdJuego).HasColumnName("Id_juego");
            entity.Property(e => e.Status).HasDefaultValue(true, "DF_Juego_Forma_juego_Status");

            entity.HasOne(d => d.IdFormaJuegoNavigation).WithMany(p => p.JuegoFormaJuegos)
                .HasForeignKey(d => d.IdFormaJuego)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JuegoFormajuego_Formajuego");

            entity.HasOne(d => d.IdJuegoNavigation).WithMany(p => p.JuegoFormaJuegos)
                .HasForeignKey(d => d.IdJuego)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JuegoFormajuego_Juego");

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.JuegoFormaJuegoIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_JFJ_UserCreate_Alter");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.JuegoFormaJuegoIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Juego_Forma_juego_IdUserDelete_FinalAudit");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.JuegoFormaJuegoIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Juego_Forma_juego_IdUserUpdate_FinalAudit");
        });

        modelBuilder.Entity<JuegoIdioma>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Juego_Idioma_New");

            entity.ToTable("Juego_Idioma");

            entity.HasIndex(e => new { e.IdJuego, e.IdIdioma }, "UQ_JuegoIdio_Composite").IsUnique();

            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())", "DF_Juego_Idioma_DateCreate")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.EsAudio).HasColumnName("es_audio");
            entity.Property(e => e.EsInterfaz).HasColumnName("es_interfaz");
            entity.Property(e => e.EsSubtitulo).HasColumnName("es_subtitulo");
            entity.Property(e => e.IdIdioma).HasColumnName("Id_idioma");
            entity.Property(e => e.IdJuego).HasColumnName("Id_juego");
            entity.Property(e => e.Status).HasDefaultValue(true, "DF_Juego_Idioma_Status");

            entity.HasOne(d => d.IdIdiomaNavigation).WithMany(p => p.JuegoIdiomas)
                .HasForeignKey(d => d.IdIdioma)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JuegoIdioma_Idioma");

            entity.HasOne(d => d.IdJuegoNavigation).WithMany(p => p.JuegoIdiomas)
                .HasPrincipalKey(p => p.IdProducto)
                .HasForeignKey(d => d.IdJuego)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JuegoIdioma_Juego");

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.JuegoIdiomaIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_JuegoIdio_UserCreate_Alter");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.JuegoIdiomaIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Juego_Idioma_IdUserDelete_FinalAudit");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.JuegoIdiomaIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Juego_Idioma_IdUserUpdate_FinalAudit");
        });

        modelBuilder.Entity<JuegoPlataforma>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Juego_Plataforma_New");

            entity.ToTable("Juego_Plataforma");

            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())", "DF_Juego_Plataforma_DateCreate")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.IdJuego).HasColumnName("Id_juego");
            entity.Property(e => e.IdPlataforma).HasColumnName("Id_plataforma");
            entity.Property(e => e.Status).HasDefaultValue(true, "DF_Juego_Plataforma_Status");

            entity.HasOne(d => d.IdJuegoNavigation).WithMany(p => p.JuegoPlataformas)
                .HasPrincipalKey(p => p.IdProducto)
                .HasForeignKey(d => d.IdJuego)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JuegoPlataforma_Juego");

            entity.HasOne(d => d.IdPlataformaNavigation).WithMany(p => p.JuegoPlataformas)
                .HasForeignKey(d => d.IdPlataforma)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JuegoPlataforma_Plataforma");

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.JuegoPlataformaIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_JuegoPlataforma_UserCreate");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.JuegoPlataformaIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Juego_Plataforma_IdUserDelete_FinalAudit");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.JuegoPlataformaIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Juego_Plataforma_IdUserUpdate_FinalAudit");
        });

        modelBuilder.Entity<JuegoTag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Juego_Tag_New");

            entity.ToTable("Juego_Tag");

            entity.HasIndex(e => new { e.IdJuego, e.IdTag }, "UQ_JuegoTag_Composite").IsUnique();

            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())", "DF_Juego_Tag_DateCreate")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.IdJuego).HasColumnName("Id_juego");
            entity.Property(e => e.IdTag).HasColumnName("Id_tag");
            entity.Property(e => e.Status).HasDefaultValue(true, "DF_Juego_Tag_Status");

            entity.HasOne(d => d.IdJuegoNavigation).WithMany(p => p.JuegoTags)
                .HasPrincipalKey(p => p.IdProducto)
                .HasForeignKey(d => d.IdJuego)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JuegoTag_Juego");

            entity.HasOne(d => d.IdTagNavigation).WithMany(p => p.JuegoTags)
                .HasForeignKey(d => d.IdTag)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JuegoTag_Tag");

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.JuegoTagIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_JuegoTag_UserCreate_Alter");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.JuegoTagIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Juego_Tag_IdUserDelete_FinalAudit");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.JuegoTagIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Juego_Tag_IdUserUpdate_FinalAudit");
        });

        modelBuilder.Entity<ListaDeseo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Lista_de__3214EC07319DA3E4");

            entity.ToTable("Lista_deseo");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.Prioridad).HasColumnName("prioridad");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.ListaDeseoIdNavigation)
                .HasForeignKey<ListaDeseo>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ListaDeseo_Usuario");

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.ListaDeseoIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_Lista_deseo_UserCreate");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.ListaDeseoIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Lista_deseo_UserDelete");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.ListaDeseoIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Lista_deseo_UserUpdate");
        });

        modelBuilder.Entity<Logro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Logro__3214EC073022A9D2");

            entity.ToTable("Logro");

            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .HasColumnName("descripcion");
            entity.Property(e => e.IdJuego).HasColumnName("Id_juego");
            entity.Property(e => e.LogoUrl)
                .HasMaxLength(100)
                .HasColumnName("logo_url");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.IdJuegoNavigation).WithMany(p => p.Logros)
                .HasPrincipalKey(p => p.IdProducto)
                .HasForeignKey(d => d.IdJuego)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Logro_Juego_Recreated");

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.LogroIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_Logro_UserCreate");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.LogroIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Logro_UserDelete");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.LogroIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Logro_UserUpdate");
        });

        modelBuilder.Entity<MetodoPago>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Metodo_p__3214EC07D6EC9244");

            entity.ToTable("Metodo_pago");

            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.IdMoneda).HasColumnName("Id_moneda");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.IdMonedaNavigation).WithMany(p => p.MetodoPagos)
                .HasForeignKey(d => d.IdMoneda)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MetodoPago_Moneda");

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.MetodoPagoIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_Metodo_pago_UserCreate");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.MetodoPagoIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Metodo_pago_UserDelete");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.MetodoPagoIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Metodo_pago_UserUpdate");
        });

        modelBuilder.Entity<Monedum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Moneda__3214EC07DFCD6301");

            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.MonedumIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_Moneda_UserCreate");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.MonedumIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Moneda_UserDelete");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.MonedumIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Moneda_UserUpdate");
        });

        modelBuilder.Entity<MotorGrafico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Motor_gr__3214EC07B57C967B");

            entity.ToTable("Motor_grafico");

            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.MotorGraficoIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_Motor_grafico_UserCreate");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.MotorGraficoIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Motor_grafico_UserDelete");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.MotorGraficoIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Motor_grafico_UserUpdate");
        });

        modelBuilder.Entity<Pai>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pais__3214EC0799EBEA9E");

            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.PaiIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_Pais_UserCreate");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.PaiIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Pais_UserDelete");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.PaiIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Pais_UserUpdate");
        });

        modelBuilder.Entity<Plataforma>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Platafor__3214EC0788BAAE2F");

            entity.ToTable("Plataforma");

            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.LogoUrl)
                .HasMaxLength(500)
                .HasColumnName("logo_url");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.PlataformaIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_Plataforma_UserCreate");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.PlataformaIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Plataforma_UserDelete");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.PlataformaIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Plataforma_UserUpdate");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Producto__3214EC07A87D20A4");

            entity.ToTable("Producto");

            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.IdCategoria).HasColumnName("Id_categoria");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Producto_Categoria");

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.ProductoIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_Producto_UserCreate");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.ProductoIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Producto_UserDelete");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.ProductoIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Producto_UserUpdate");
        });

        modelBuilder.Entity<Publicacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Publicac__3214EC079C0D6E5F");

            entity.ToTable("Publicacion");

            entity.Property(e => e.Contenido)
                .HasMaxLength(500)
                .HasColumnName("contenido");
            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.IdComunidad).HasColumnName("Id_comunidad");
            entity.Property(e => e.IdTipoPublicacion).HasColumnName("Id_tipo_publicacion");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_usuario");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.IdComunidadNavigation).WithMany(p => p.Publicacions)
                .HasForeignKey(d => d.IdComunidad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Publicacion_Comunidad");

            entity.HasOne(d => d.IdTipoPublicacionNavigation).WithMany(p => p.Publicacions)
                .HasForeignKey(d => d.IdTipoPublicacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Publicacion_Tipo");

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.PublicacionIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_Publicacion_UserCreate");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.PublicacionIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Publicacion_UserDelete");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.PublicacionIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Publicacion_UserUpdate");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.PublicacionIdUsuarioNavigations)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Publicacion_Usuario");
        });

        modelBuilder.Entity<Rason>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Rason__3214EC0709F7C93B");

            entity.ToTable("Rason");

            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.RasonIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_Razon_UserCreate");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.RasonIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Razon_UserDelete");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.RasonIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Razon_UserUpdate");
        });

        modelBuilder.Entity<Recompensa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Recompen__3214EC07B1982BE7");

            entity.ToTable("Recompensa");

            entity.HasIndex(e => e.IdBolsaPuntos, "UQ__Recompen__9DD81AABFB2315D9").IsUnique();

            entity.HasIndex(e => e.IdCupon, "UQ__Recompen__F98CB48DF00EDECB").IsUnique();

            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .HasColumnName("descripcion");
            entity.Property(e => e.IdBolsaPuntos).HasColumnName("Id_bolsa_puntos");
            entity.Property(e => e.IdCupon).HasColumnName("Id_cupon");
            entity.Property(e => e.IdTipoRecompensa).HasColumnName("Id_tipo_recompensa");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.IdBolsaPuntosNavigation).WithOne(p => p.Recompensa)
                .HasForeignKey<Recompensa>(d => d.IdBolsaPuntos)
                .HasConstraintName("FK_Recompensa_BolsaPuntos");

            entity.HasOne(d => d.IdCuponNavigation).WithOne(p => p.Recompensa)
                .HasForeignKey<Recompensa>(d => d.IdCupon)
                .HasConstraintName("FK_Recompensa_Cupon");

            entity.HasOne(d => d.IdTipoRecompensaNavigation).WithMany(p => p.Recompensas)
                .HasForeignKey(d => d.IdTipoRecompensa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Recompensa_TipoRecompensa");

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.RecompensaIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_Recompensa_UserCreate");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.RecompensaIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Recompensa_UserDelete");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.RecompensaIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Recompensa_UserUpdate");
        });

        modelBuilder.Entity<Rembolso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Rembolso__3214EC07E2055F7C");

            entity.ToTable("Rembolso");

            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_usuario");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.RembolsoIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_Rembolso_UserCreate");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.RembolsoIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Rembolso_UserDelete");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.RembolsoIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Rembolso_UserUpdate");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.RembolsoIdUsuarioNavigations)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rembolso_Usuario");
        });

        modelBuilder.Entity<RequisitoSistema>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Requisit__3214EC07B7095116");

            entity.ToTable("Requisito_Sistema");

            entity.Property(e => e.Almacenamiento)
                .HasMaxLength(50)
                .HasColumnName("almacenamiento");
            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.IdJuego).HasColumnName("Id_juego");
            entity.Property(e => e.IdTipoRequisito).HasColumnName("Id_tipo_requisito");
            entity.Property(e => e.MemoriaRam)
                .HasMaxLength(50)
                .HasColumnName("memoria_ram");
            entity.Property(e => e.Procesador)
                .HasMaxLength(200)
                .HasColumnName("procesador");
            entity.Property(e => e.SistemaOperativo)
                .HasMaxLength(100)
                .HasColumnName("sistema_operativo");
            entity.Property(e => e.Status).HasDefaultValue(true);
            entity.Property(e => e.TarjetaGrafica)
                .HasMaxLength(200)
                .HasColumnName("tarjeta_grafica");

            entity.HasOne(d => d.IdJuegoNavigation).WithMany(p => p.RequisitoSistemas)
                .HasForeignKey(d => d.IdJuego)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RequisitoSistema_Juego");

            entity.HasOne(d => d.IdTipoRequisitoNavigation).WithMany(p => p.RequisitoSistemas)
                .HasForeignKey(d => d.IdTipoRequisito)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Requisito_Tipo_Recreated");

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.RequisitoSistemaIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_Requisito_Sistema_UserCreate");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.RequisitoSistemaIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Requisito_Sistema_UserDelete");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.RequisitoSistemaIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Requisito_Sistema_UserUpdate");
        });

        modelBuilder.Entity<Reseña>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reseña__3214EC0787D38DA2");

            entity.ToTable("Reseña");

            entity.Property(e => e.Contenido).HasColumnName("contenido");
            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.FechaPublicacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_publicacion");
            entity.Property(e => e.IdDlc).HasColumnName("Id_dlc");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_usuario");
            entity.Property(e => e.Status).HasDefaultValue(true);
            entity.Property(e => e.Titulo)
                .HasMaxLength(250)
                .HasColumnName("titulo");

            entity.HasOne(d => d.IdDlcNavigation).WithMany(p => p.Reseñas)
                .HasForeignKey(d => d.IdDlc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reseña_Dlc");

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.ReseñaIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_Reseña_UserCreate_Alter");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.ReseñaIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Reseña_UserDelete_Alter");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.ReseñaIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Reseña_UserUpdate_Alter");
        });

        modelBuilder.Entity<Saga>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Saga__3214EC07DCF021F3");

            entity.ToTable("Saga");

            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(250)
                .HasColumnName("nombre");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.SagaIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_Saga_UserCreate");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.SagaIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Saga_UserDelete");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.SagaIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Saga_UserUpdate");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tag__3214EC070203758D");

            entity.ToTable("Tag");

            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.TagIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_Tag_UserCreate");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.TagIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Tag_UserDelete");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.TagIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Tag_UserUpdate");
        });

        modelBuilder.Entity<TarjetaRegalo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tarjeta___3214EC079FB4179B");

            entity.ToTable("Tarjeta_Regalo");

            entity.HasIndex(e => e.Codigo, "UQ__Tarjeta___40F9A2061D9951F8").IsUnique();

            entity.Property(e => e.Codigo)
                .HasMaxLength(50)
                .HasColumnName("codigo");
            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.EsDigital).HasColumnName("es_digital");
            entity.Property(e => e.EstaCanjeada).HasColumnName("esta_canjeada");
            entity.Property(e => e.FechaCanje)
                .HasColumnType("datetime")
                .HasColumnName("fecha_canje");
            entity.Property(e => e.FechaVencimiento)
                .HasColumnType("datetime")
                .HasColumnName("fecha_vencimiento");
            entity.Property(e => e.IdMoneda).HasColumnName("Id_moneda");
            entity.Property(e => e.IdUsuarioCanje).HasColumnName("Id_usuario_canje");
            entity.Property(e => e.Saldo)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("saldo");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.IdMonedaNavigation).WithMany(p => p.TarjetaRegalos)
                .HasForeignKey(d => d.IdMoneda)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tarjeta_Moneda");

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.TarjetaRegaloIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_Tarjeta_Regalo_UserCreate");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.TarjetaRegaloIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Tarjeta_Regalo_UserDelete");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.TarjetaRegaloIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Tarjeta_Regalo_UserUpdate");

            entity.HasOne(d => d.IdUsuarioCanjeNavigation).WithMany(p => p.TarjetaRegaloIdUsuarioCanjeNavigations)
                .HasForeignKey(d => d.IdUsuarioCanje)
                .HasConstraintName("FK_Tarjeta_Usuario");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ticket__3214EC0759615BC0");

            entity.ToTable("Ticket");

            entity.Property(e => e.Contenido)
                .HasMaxLength(500)
                .HasColumnName("contenido");
            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.IdRazon).HasColumnName("Id_razon");
            entity.Property(e => e.IdSupervisor).HasColumnName("Id_supervisor");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_usuario");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.IdRazonNavigation).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.IdRazon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ticket_Rason");

            entity.HasOne(d => d.IdSupervisorNavigation).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.IdSupervisor)
                .HasConstraintName("FK_Ticket_Supervisor");

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.TicketIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_Ticket_UserCreate");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.TicketIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Ticket_UserDelete");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.TicketIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Ticket_UserUpdate");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.TicketIdUsuarioNavigations)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ticket_Usuario");
        });

        modelBuilder.Entity<TipoItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tipo_ite__3214EC07F7CF18E2");

            entity.ToTable("Tipo_item");

            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.TipoItemIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_Tipo_item_UserCreate");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.TipoItemIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Tipo_item_UserDelete");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.TipoItemIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Tipo_item_UserUpdate");
        });

        modelBuilder.Entity<TipoPublicacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tipo_pub__3214EC07C44BA70A");

            entity.ToTable("Tipo_publicacion");

            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.TipoPublicacionIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_Tipo_publicacion_UserCreate");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.TipoPublicacionIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Tipo_publicacion_UserDelete");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.TipoPublicacionIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Tipo_publicacion_UserUpdate");
        });

        modelBuilder.Entity<TipoRecompensa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tipo_rec__3214EC0788C2DFC3");

            entity.ToTable("Tipo_recompensa");

            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.TipoRecompensaIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_Tipo_recompensa_UserCreate");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.TipoRecompensaIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Tipo_recompensa_UserDelete");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.TipoRecompensaIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Tipo_recompensa_UserUpdate");
        });

        modelBuilder.Entity<TipoRequisito>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tipo_Req__3214EC0781B03AAA");

            entity.ToTable("Tipo_Requisito");

            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.TipoRequisitoIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_Tipo_Requisito_UserCreate");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.TipoRequisitoIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Tipo_Requisito_UserDelete");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.TipoRequisitoIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Tipo_Requisito_UserUpdate");
        });

        modelBuilder.Entity<TipoUsuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tipo_usu__3214EC0721A69817");

            entity.ToTable("Tipo_usuario");

            entity.HasIndex(e => e.Nombre, "UQ__Tipo_usu__72AFBCC66B951CC7").IsUnique();

            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Status).HasDefaultValue(1);

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.TipoUsuarioIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_Tipo_usuario_UserCreate");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.TipoUsuarioIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Tipo_usuario_UserDelete");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.TipoUsuarioIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Tipo_usuario_UserUpdate");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3214EC07F31C1CA7");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Correo, "UQ__Usuario__2A586E0BAAB33390").IsUnique();

            entity.Property(e => e.ApellidoM)
                .HasMaxLength(100)
                .HasColumnName("apellido_M");
            entity.Property(e => e.ApellidoP)
                .HasMaxLength(100)
                .HasColumnName("apellido_P");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(100)
                .HasColumnName("contraseña");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .HasColumnName("correo");
            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.IdDireccion).HasColumnName("Id_direccion");
            entity.Property(e => e.IdTipoUsuario).HasColumnName("Id_tipo_usuario");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Status).HasDefaultValue(true);
            entity.Property(e => e.Telefono)
                .HasMaxLength(500)
                .HasColumnName("telefono");

            entity.HasOne(d => d.IdDireccionNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdDireccion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuario_Direccion");

            entity.HasOne(d => d.IdTipoUsuarioNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdTipoUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuario_TipoUsuario");

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.InverseIdUserCreateNavigation)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_Usuario_UserCreate");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.InverseIdUserDeleteNavigation)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Usuario_UserDelete");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.InverseIdUserUpdateNavigation)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Usuario_UserUpdate");
        });

        modelBuilder.Entity<UsuarioComunidad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Usuario_Comunidad_New");

            entity.ToTable("Usuario_Comunidad");

            entity.HasIndex(e => new { e.IdUsuario, e.IdComunidad }, "UQ_UsuComu_Composite").IsUnique();

            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.IdComunidad).HasColumnName("Id_comunidad");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_usuario");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.IdComunidadNavigation).WithMany(p => p.UsuarioComunidads)
                .HasForeignKey(d => d.IdComunidad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioComunidad_Comunidad");

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.UsuarioComunidadIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_UsuComu_UserCreate_Alter");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.UsuarioComunidadIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Usuario_Comunidad_UserDelete");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.UsuarioComunidadIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Usuario_Comunidad_UserUpdate");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.UsuarioComunidadIdUsuarioNavigations)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioComunidad_Usuario");
        });

        modelBuilder.Entity<UsuarioInsignium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario___3214EC071A78059A");

            entity.ToTable("Usuario_Insignia");

            entity.HasIndex(e => new { e.IdUsuario, e.IdInsignia }, "UQ__Usuario___649753FEE05D6751").IsUnique();

            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.FechaObtencion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_obtencion");
            entity.Property(e => e.IdInsignia).HasColumnName("Id_insignia");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_usuario");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.IdInsigniaNavigation).WithMany(p => p.UsuarioInsignia)
                .HasForeignKey(d => d.IdInsignia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioInsignia_Insignia");

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.UsuarioInsigniumIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_UsuarioInsignia_UserCreate");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.UsuarioInsigniumIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_UsuarioInsignia_UserDelete");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.UsuarioInsigniumIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_UsuarioInsignia_UserUpdate");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.UsuarioInsigniumIdUsuarioNavigations)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioInsignia_Usuario");
        });

        modelBuilder.Entity<UsuarioTag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Usuario_Tag_New");

            entity.ToTable("Usuario_Tag");

            entity.HasIndex(e => new { e.IdUsuario, e.IdTag }, "UQ_UsuarioTag_Composite").IsUnique();

            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.IdTag).HasColumnName("Id_tag");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_usuario");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.UsuarioTagIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_UsuarioTag_UserCreate_Alter");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.UsuarioTagIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Usuario_Tag_UserDelete");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.UsuarioTagIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Usuario_Tag_UserUpdate");
        });

        modelBuilder.Entity<VAuditoriaGeneralJuego>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_Auditoria_General_Juegos");

            entity.Property(e => e.CreadoPor)
                .HasMaxLength(100)
                .HasColumnName("Creado_Por");
            entity.Property(e => e.EliminadoPor)
                .HasMaxLength(100)
                .HasColumnName("Eliminado_Por");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Creacion");
            entity.Property(e => e.FechaEliminacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Eliminacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Modificacion");
            entity.Property(e => e.IdJuegoInterno).HasColumnName("Id_Juego_Interno");
            entity.Property(e => e.ModificadoPor)
                .HasMaxLength(100)
                .HasColumnName("Modificado_Por");
            entity.Property(e => e.NombreJuego)
                .HasMaxLength(255)
                .HasColumnName("Nombre_Juego");
        });

        modelBuilder.Entity<VComunidadMiembro>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_Comunidad_Miembros");

            entity.Property(e => e.Creador).HasMaxLength(100);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Creacion");
            entity.Property(e => e.IdComunidad).HasColumnName("Id_Comunidad");
            entity.Property(e => e.NombreComunidad)
                .HasMaxLength(100)
                .HasColumnName("Nombre_Comunidad");
            entity.Property(e => e.TotalMiembrosActivos).HasColumnName("Total_Miembros_Activos");
        });

        modelBuilder.Entity<VDlcResumenXJuego>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_Dlc_Resumen_x_Juego");

            entity.Property(e => e.CreadoPor)
                .HasMaxLength(100)
                .HasColumnName("Creado_Por");
            entity.Property(e => e.EstadoDlc).HasColumnName("Estado_Dlc");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Creacion");
            entity.Property(e => e.FechaRegistroDlc)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Registro_Dlc");
            entity.Property(e => e.IdDlc).HasColumnName("Id_Dlc");
            entity.Property(e => e.JuegoBase)
                .HasMaxLength(255)
                .HasColumnName("Juego_Base");
            entity.Property(e => e.NombreDlc)
                .HasMaxLength(255)
                .HasColumnName("Nombre_Dlc");
            entity.Property(e => e.PrecioBase)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Precio_Base");
        });

        modelBuilder.Entity<VInventarioProducto>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_Inventario_Productos");

            entity.Property(e => e.EstadoProducto).HasColumnName("Estado_Producto");
            entity.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Registro");
            entity.Property(e => e.IdProducto).HasColumnName("Id_Producto");
            entity.Property(e => e.NombreProducto)
                .HasMaxLength(255)
                .HasColumnName("Nombre_Producto");
            entity.Property(e => e.PrecioActual)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Precio_Actual");
            entity.Property(e => e.TipoProducto)
                .HasMaxLength(100)
                .HasColumnName("Tipo_Producto");
        });

        modelBuilder.Entity<VJuegoDetallesConsolidado>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_Juego_Detalles_Consolidado");

            entity.Property(e => e.CreadoPor)
                .HasMaxLength(100)
                .HasColumnName("Creado_Por");
            entity.Property(e => e.Desarrollador).HasMaxLength(100);
            entity.Property(e => e.EstadoJuego).HasColumnName("Estado_Juego");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Creacion");
            entity.Property(e => e.FechaLanzamiento)
                .HasColumnType("datetime")
                .HasColumnName("fecha_lanzamiento");
            entity.Property(e => e.GeneroPrincipal)
                .HasMaxLength(100)
                .HasColumnName("Genero_Principal");
            entity.Property(e => e.IdJuego).HasColumnName("Id_Juego");
            entity.Property(e => e.NombreProducto)
                .HasMaxLength(255)
                .HasColumnName("Nombre_Producto");
            entity.Property(e => e.PrecioBase)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Precio_Base");
            entity.Property(e => e.Publicador).HasMaxLength(400);
            entity.Property(e => e.TotalReseñasDummy).HasColumnName("Total_Reseñas_Dummy");
        });

        modelBuilder.Entity<VReseñasDetallada>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_Reseñas_Detalladas");

            entity.Property(e => e.AutorReseña)
                .HasMaxLength(100)
                .HasColumnName("Autor_Reseña");
            entity.Property(e => e.FechaPublicacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Publicacion");
            entity.Property(e => e.IdReseña).HasColumnName("Id_Reseña");
            entity.Property(e => e.NombreProducto)
                .HasMaxLength(255)
                .HasColumnName("Nombre_Producto");
            entity.Property(e => e.PuntuacionProxy).HasColumnName("Puntuacion_Proxy");
        });

        modelBuilder.Entity<VTopTagsMasUsado>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_Top_Tags_Mas_Usados");

            entity.Property(e => e.FrecuenciaTotal).HasColumnName("Frecuencia_Total");
            entity.Property(e => e.IdTag).HasColumnName("Id_Tag");
            entity.Property(e => e.NombreTag)
                .HasMaxLength(100)
                .HasColumnName("Nombre_Tag");
        });

        modelBuilder.Entity<VUsuarioPerfilCompleto>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_Usuario_Perfil_Completo");

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.EstadoCuenta).HasColumnName("Estado_Cuenta");
            entity.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Registro");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");
            entity.Property(e => e.MonedaPreferida)
                .HasMaxLength(100)
                .HasColumnName("Moneda_Preferida");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(100)
                .HasColumnName("Nombre_Usuario");
            entity.Property(e => e.PaisRegistro)
                .HasMaxLength(100)
                .HasColumnName("Pais_Registro");
            entity.Property(e => e.TipoUsuario)
                .HasMaxLength(100)
                .HasColumnName("Tipo_Usuario");
        });

        modelBuilder.Entity<VVentaDetalleCompleto>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_Venta_Detalle_Completo");

            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Cliente).HasMaxLength(100);
            entity.Property(e => e.EmailCliente)
                .HasMaxLength(100)
                .HasColumnName("Email_Cliente");
            entity.Property(e => e.FechaCreacionVenta)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Creacion_Venta");
            entity.Property(e => e.FechaVenta)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Venta");
            entity.Property(e => e.IdVenta).HasColumnName("Id_Venta");
            entity.Property(e => e.MetodoPago)
                .HasMaxLength(100)
                .HasColumnName("Metodo_Pago");
            entity.Property(e => e.MontoTotalCalculado).HasColumnName("Monto_Total_Calculado");
            entity.Property(e => e.NombreProducto)
                .HasMaxLength(255)
                .HasColumnName("Nombre_Producto");
            entity.Property(e => e.PrecioUnitarioHistorico).HasColumnName("Precio_Unitario_Historico");
            entity.Property(e => e.SubtotalLinea).HasColumnName("Subtotal_Linea");
        });

        modelBuilder.Entity<VVentasAnualesXPai>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_Ventas_Anuales_x_Pais");

            entity.Property(e => e.AñoVenta).HasColumnName("Año_Venta");
            entity.Property(e => e.IngresoTotalCalculado).HasColumnName("Ingreso_Total_Calculado");
            entity.Property(e => e.PaisCliente)
                .HasMaxLength(100)
                .HasColumnName("Pais_Cliente");
            entity.Property(e => e.TotalVentas).HasColumnName("Total_Ventas");
            entity.Property(e => e.VentaPromedioCalculada).HasColumnName("Venta_Promedio_Calculada");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Venta__3214EC0797A5ADF7");

            entity.HasIndex(e => e.IdRembolso, "UQ_Venta_IdReembolso_Filtro")
                .IsUnique()
                .HasFilter("([Id_rembolso] IS NOT NULL)");

            entity.HasIndex(e => e.IdFactura, "UQ__Venta__A6DB93630C2CA0F1").IsUnique();

            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDelete).HasColumnType("datetime");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime");
            entity.Property(e => e.Estado)
                .HasMaxLength(100)
                .HasColumnName("estado");
            entity.Property(e => e.IdEvento).HasColumnName("Id_evento");
            entity.Property(e => e.IdFactura).HasColumnName("Id_factura");
            entity.Property(e => e.IdMetodoPago).HasColumnName("Id_metodo_pago");
            entity.Property(e => e.IdRecompensa).HasColumnName("Id_recompensa");
            entity.Property(e => e.IdRembolso).HasColumnName("Id_rembolso");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_usuario");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.IdCuponNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdCupon)
                .HasConstraintName("FK_Venta_Cupon");

            entity.HasOne(d => d.IdEventoNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdEvento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Venta_Evento");

            entity.HasOne(d => d.IdFacturaNavigation).WithOne(p => p.Ventum)
                .HasForeignKey<Venta>(d => d.IdFactura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Venta_Factura_Logica");

            entity.HasOne(d => d.IdMetodoPagoNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdMetodoPago)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Venta_MetodoPago");

            entity.HasOne(d => d.IdRecompensaNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdRecompensa)
                .HasConstraintName("FK_Venta_Recompensa");

            entity.HasOne(d => d.IdUserCreateNavigation).WithMany(p => p.VentumIdUserCreateNavigations)
                .HasForeignKey(d => d.IdUserCreate)
                .HasConstraintName("FK_Venta_UserCreate");

            entity.HasOne(d => d.IdUserDeleteNavigation).WithMany(p => p.VentumIdUserDeleteNavigations)
                .HasForeignKey(d => d.IdUserDelete)
                .HasConstraintName("FK_Venta_UserDelete");

            entity.HasOne(d => d.IdUserUpdateNavigation).WithMany(p => p.VentumIdUserUpdateNavigations)
                .HasForeignKey(d => d.IdUserUpdate)
                .HasConstraintName("FK_Venta_UserUpdate");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.VentumIdUsuarioNavigations)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Venta_Usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
