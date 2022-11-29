using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SistemaGestionDeConfiguracionSoftware.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<CRONOGRAMA> CRONOGRAMA { get; set; }
        public virtual DbSet<ECS> ECS { get; set; }
        public virtual DbSet<ETAPA> ETAPA { get; set; }
        public virtual DbSet<METODOLOGIA> METODOLOGIA { get; set; }
        public virtual DbSet<MIEMBRO> MIEMBRO { get; set; }
        public virtual DbSet<PLANTILLAECS> PLANTILLAECS { get; set; }
        public virtual DbSet<PROYECTO> PROYECTO { get; set; }
        public virtual DbSet<SOLICITUDCAMBIO> SOLICITUDCAMBIO { get; set; }
        public virtual DbSet<TIPO_USUARIO> TIPO_USUARIO { get; set; }
        public virtual DbSet<USUARIO> USUARIO { get; set; }
        public virtual DbSet<GRUPO> GRUPO { get; set; }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GRUPO>()
               .Property(e => e.nombre)
               .IsUnicode(false);

            modelBuilder.Entity<CRONOGRAMA>()
                .Property(e => e.TAREA_FINALIZADA)
                .IsUnicode(false);

            modelBuilder.Entity<CRONOGRAMA>()
                .Property(e => e.TAREA_ENPROCESO)
                .IsUnicode(false);

            modelBuilder.Entity<CRONOGRAMA>()
                .Property(e => e.TAREA_ABIERTA)
                .IsUnicode(false);

            modelBuilder.Entity<CRONOGRAMA>()
                .Property(e => e.VERSION_ACTUAL)
                .IsUnicode(false);

            modelBuilder.Entity<CRONOGRAMA>()
                .Property(e => e.ECS)
                .IsUnicode(false);

            modelBuilder.Entity<ECS>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<ETAPA>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<ETAPA>()
                .HasMany(e => e.CRONOGRAMA)
                .WithOptional(e => e.ETAPA)
                .HasForeignKey(e => e.ID_FASE);

            modelBuilder.Entity<ETAPA>()
                .HasMany(e => e.PLANTILLAECS)
                .WithOptional(e => e.ETAPA)
                .HasForeignKey(e => e.ID_FASE);

            modelBuilder.Entity<METODOLOGIA>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<METODOLOGIA>()
                .HasMany(e => e.PROYECTO)
                .WithRequired(e => e.METODOLOGIA)
                .WillCascadeOnDelete(false);

            

            modelBuilder.Entity<PLANTILLAECS>()
                .Property(e => e.TAREA_FINALIZADA)
                .IsUnicode(false);

            modelBuilder.Entity<PLANTILLAECS>()
                .Property(e => e.TAREA_ENPROCESO)
                .IsUnicode(false);

            modelBuilder.Entity<PLANTILLAECS>()
                .Property(e => e.TAREA_ABIERTA)
                .IsUnicode(false);

            modelBuilder.Entity<PLANTILLAECS>()
                .Property(e => e.VERSION_ACTUAL)
                .IsUnicode(false);

            modelBuilder.Entity<PROYECTO>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<PROYECTO>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<SOLICITUDCAMBIO>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<SOLICITUDCAMBIO>()
                .Property(e => e.TIPO_CAMBIO)
                .IsUnicode(false);

            modelBuilder.Entity<TIPO_USUARIO>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<TIPO_USUARIO>()
                .HasMany(e => e.USUARIO)
                .WithRequired(e => e.TIPO_USUARIO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.APELLIDO)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.CODIGO)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.TELEFONO)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.PASSWORD)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .HasMany(e => e.PROYECTO)
                .WithRequired(e => e.USUARIO)
                .HasForeignKey(e => e.ID_JEFEPROYECTO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USUARIO>()
                .HasMany(e => e.PROYECTO1)
                .WithRequired(e => e.USUARIO1)
                .HasForeignKey(e => e.ID_CLIENTE)
                .WillCascadeOnDelete(false);
        }
    }
}
