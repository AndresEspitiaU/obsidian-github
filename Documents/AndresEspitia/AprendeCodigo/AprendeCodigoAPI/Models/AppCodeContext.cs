using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AprendeCodigoAPI.Models;

public partial class AppCodeContext : DbContext
{
    public AppCodeContext()
    {
    }

    public AppCodeContext(DbContextOptions<AppCodeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CategoriasCurso> CategoriasCursos { get; set; }

    public virtual DbSet<ComentariosLeccion> ComentariosLeccions { get; set; }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<Ejercicio> Ejercicios { get; set; }

    public virtual DbSet<IntentosEjercicio> IntentosEjercicios { get; set; }

    public virtual DbSet<Leccione> Lecciones { get; set; }

    public virtual DbSet<ProgresoLeccione> ProgresoLecciones { get; set; }

    public virtual DbSet<RecursosLeccion> RecursosLeccions { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<TiposEjercicio> TiposEjercicios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuariosCurso> UsuariosCursos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=mssql-188335-0.cloudclusters.net,13026;Initial Catalog=AprendeCodigo;Persist Security Info=False;User ID=andres;Password=Soypipe23@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoriasCurso>(entity =>
        {
            entity.HasKey(e => e.CategoriaId).HasName("PK__Categori__F353C1E52D589E94");

            entity.ToTable("CategoriasCurso");

            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<ComentariosLeccion>(entity =>
        {
            entity.HasKey(e => e.ComentarioId).HasName("PK__Comentar__F1844938A1494416");

            entity.ToTable("ComentariosLeccion");

            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Likes).HasDefaultValue(0);

            entity.HasOne(d => d.Leccion).WithMany(p => p.ComentariosLeccions)
                .HasForeignKey(d => d.LeccionId)
                .HasConstraintName("FK__Comentari__Lecci__76969D2E");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .HasConstraintName("FK__Comentari__Paren__797309D9");

            entity.HasOne(d => d.Usuario).WithMany(p => p.ComentariosLeccions)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Comentari__Usuar__778AC167");
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.CursoId).HasName("PK__Cursos__7E0235D7523A09C9");

            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.ImagenUrl)
                .HasMaxLength(500)
                .HasColumnName("ImagenURL");
            entity.Property(e => e.Nivel).HasMaxLength(20);
            entity.Property(e => e.Titulo).HasMaxLength(100);

            entity.HasOne(d => d.Categoria).WithMany(p => p.Cursos)
                .HasForeignKey(d => d.CategoriaId)
                .HasConstraintName("FK__Cursos__Categori__5070F446");
        });

        modelBuilder.Entity<Ejercicio>(entity =>
        {
            entity.HasKey(e => e.EjercicioId).HasName("PK__Ejercici__812226417B694DF3");

            entity.Property(e => e.ConfiguracionJson).HasColumnName("ConfiguracionJSON");
            entity.Property(e => e.SolucionJson).HasColumnName("SolucionJSON");
            entity.Property(e => e.Titulo).HasMaxLength(100);

            entity.HasOne(d => d.Leccion).WithMany(p => p.Ejercicios)
                .HasForeignKey(d => d.LeccionId)
                .HasConstraintName("FK__Ejercicio__Lecci__628FA481");

            entity.HasOne(d => d.TipoEjercicio).WithMany(p => p.Ejercicios)
                .HasForeignKey(d => d.TipoEjercicioId)
                .HasConstraintName("FK__Ejercicio__TipoE__6383C8BA");
        });

        modelBuilder.Entity<IntentosEjercicio>(entity =>
        {
            entity.HasKey(e => e.IntentoId).HasName("PK__Intentos__F1BF512E963E2946");

            entity.ToTable("IntentosEjercicio");

            entity.Property(e => e.FechaIntento)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.RespuestaJson).HasColumnName("RespuestaJSON");

            entity.HasOne(d => d.Ejercicio).WithMany(p => p.IntentosEjercicios)
                .HasForeignKey(d => d.EjercicioId)
                .HasConstraintName("FK__IntentosE__Ejerc__72C60C4A");

            entity.HasOne(d => d.Usuario).WithMany(p => p.IntentosEjercicios)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__IntentosE__Usuar__71D1E811");
        });

        modelBuilder.Entity<Leccione>(entity =>
        {
            entity.HasKey(e => e.LeccionId).HasName("PK__Leccione__5C59E7C390AA9A6C");

            entity.Property(e => e.MetadatosJson).HasColumnName("MetadatosJSON");
            entity.Property(e => e.Titulo).HasMaxLength(100);

            entity.HasOne(d => d.Curso).WithMany(p => p.Lecciones)
                .HasForeignKey(d => d.CursoId)
                .HasConstraintName("FK__Lecciones__Curso__571DF1D5");

            entity.HasMany(d => d.Tags).WithMany(p => p.Leccions)
                .UsingEntity<Dictionary<string, object>>(
                    "LeccionesTag",
                    r => r.HasOne<Tag>().WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Lecciones__TagId__5AEE82B9"),
                    l => l.HasOne<Leccione>().WithMany()
                        .HasForeignKey("LeccionId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Lecciones__Lecci__59FA5E80"),
                    j =>
                    {
                        j.HasKey("LeccionId", "TagId").HasName("PK__Leccione__8A0E28597F759592");
                        j.ToTable("LeccionesTags");
                    });
        });

        modelBuilder.Entity<ProgresoLeccione>(entity =>
        {
            entity.HasKey(e => new { e.UsuarioId, e.LeccionId }).HasName("PK__Progreso__0EF879C4AD54325F");

            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValue("No iniciado");
            entity.Property(e => e.FechaCompletado).HasColumnType("datetime");
            entity.Property(e => e.FechaInicio).HasColumnType("datetime");

            entity.HasOne(d => d.Leccion).WithMany(p => p.ProgresoLecciones)
                .HasForeignKey(d => d.LeccionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProgresoL__Lecci__6E01572D");

            entity.HasOne(d => d.Usuario).WithMany(p => p.ProgresoLecciones)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProgresoL__Usuar__6D0D32F4");
        });

        modelBuilder.Entity<RecursosLeccion>(entity =>
        {
            entity.HasKey(e => e.RecursoId).HasName("PK__Recursos__82F2B184FF964326");

            entity.ToTable("RecursosLeccion");

            entity.Property(e => e.Tipo).HasMaxLength(50);
            entity.Property(e => e.Titulo).HasMaxLength(100);
            entity.Property(e => e.Url)
                .HasMaxLength(500)
                .HasColumnName("URL");

            entity.HasOne(d => d.Leccion).WithMany(p => p.RecursosLeccions)
                .HasForeignKey(d => d.LeccionId)
                .HasConstraintName("FK__RecursosL__Lecci__5DCAEF64");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.TagId).HasName("PK__Tags__657CF9AC39B404FF");

            entity.HasIndex(e => e.Nombre, "UQ__Tags__75E3EFCF0F0EF0F6").IsUnique();

            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<TiposEjercicio>(entity =>
        {
            entity.HasKey(e => e.TipoEjercicioId).HasName("PK__TiposEje__1A6C132E9E9DCA50");

            entity.ToTable("TiposEjercicio");

            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuarios__2B3DE7B82539C24E");

            entity.HasIndex(e => e.Username, "UQ__Usuarios__536C85E4544C4F5E").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Usuarios__A9D105347BA495BD").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.HashPassword).HasMaxLength(512);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasMany(d => d.Comentarios).WithMany(p => p.Usuarios)
                .UsingEntity<Dictionary<string, object>>(
                    "LikesComentario",
                    r => r.HasOne<ComentariosLeccion>().WithMany()
                        .HasForeignKey("ComentarioId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__LikesCome__Comen__7E37BEF6"),
                    l => l.HasOne<Usuario>().WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__LikesCome__Usuar__7D439ABD"),
                    j =>
                    {
                        j.HasKey("UsuarioId", "ComentarioId").HasName("PK__LikesCom__B425A32B6C1A24D1");
                        j.ToTable("LikesComentario");
                    });
        });

        modelBuilder.Entity<UsuariosCurso>(entity =>
        {
            entity.HasKey(e => new { e.UsuarioId, e.CursoId }).HasName("PK__Usuarios__4CDDC4E5B252106B");

            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValue("Inscrito");
            entity.Property(e => e.FechaCompletado).HasColumnType("datetime");
            entity.Property(e => e.FechaInscripcion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ProgresoTotal)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.Curso).WithMany(p => p.UsuariosCursos)
                .HasForeignKey(d => d.CursoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UsuariosC__Curso__6754599E");

            entity.HasOne(d => d.Usuario).WithMany(p => p.UsuariosCursos)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UsuariosC__Usuar__66603565");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
