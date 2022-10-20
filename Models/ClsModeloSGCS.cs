using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SistemaGestionDeConfiguracionSoftware.Models
{
    public class ClsModeloSGCS:DbContext
    {
        public ClsModeloSGCS()
           : base("name=ModeloSGCS")
        {
        }

        public virtual DbSet<ClsEntregable> ENTREGABLE { get; set; }
        public virtual DbSet<ClsEtapa> ETAPA { get; set; }
        public virtual DbSet<ClsMetodologia> METODOLOGIA { get; set; }
        public virtual DbSet<ClsProyecto> PROYECTO { get; set; }
        public virtual DbSet<ClsTipoUsuario> TIPO_USUARIO { get; set; }
        public virtual DbSet<ClsUsuario> USUARIO { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClsEntregable>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<ClsEtapa>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<ClsEtapa>()
                .HasMany(e => e.ENTREGABLE)
                .WithRequired(e => e.ETAPA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ClsMetodologia>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<ClsMetodologia>()
                .HasMany(e => e.ETAPA)
                .WithRequired(e => e.METODOLOGIA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ClsMetodologia>()
                .HasMany(e => e.PROYECTO)
                .WithRequired(e => e.METODOLOGIA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ClsProyecto>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<ClsProyecto>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<ClsTipoUsuario>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<ClsTipoUsuario>()
                .HasMany(e => e.USUARIO)
                .WithRequired(e => e.TIPO_USUARIO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ClsUsuario>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<ClsUsuario>()
                .Property(e => e.APELLIDO)
                .IsUnicode(false);

            modelBuilder.Entity<ClsUsuario>()
                .Property(e => e.CODIGO)
                .IsUnicode(false);

            modelBuilder.Entity<ClsUsuario>()
                .Property(e => e.TELEFONO)
                .IsUnicode(false);

            modelBuilder.Entity<ClsUsuario>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<ClsUsuario>()
                .Property(e => e.PASSWORD)
                .IsUnicode(false);

            modelBuilder.Entity<ClsUsuario>()
                .HasMany(e => e.PROYECTO)
                .WithRequired(e => e.USUARIO)
                .HasForeignKey(e => e.ID_JEFEPROYECTO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ClsUsuario>()
                .HasMany(e => e.PROYECTO1)
                .WithRequired(e => e.USUARIO1)
                .HasForeignKey(e => e.ID_CLIENTE)
                .WillCascadeOnDelete(false);
        }
    }
}