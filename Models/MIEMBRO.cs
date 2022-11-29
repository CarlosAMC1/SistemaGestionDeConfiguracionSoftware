namespace SistemaGestionDeConfiguracionSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("MIEMBRO")]
    public partial class MIEMBRO
    {
        [Key]
        public int ID_MIEMBRO { get; set; }

        public int ID_GRUPO { get; set; }

        public int ID_USUARIO { get; set; }

        public int ID_PROYECTO { get; set; }

        public int ID_TIPOUSUARIO { get; set; }

        public virtual USUARIO USUARIO { get; set; }
        public virtual TIPO_USUARIO TIPO_USUARIO { get; set; }
        public virtual PROYECTO PROYECTO { get; set; }
        public virtual GRUPO GRUPO { get; set; }


        public List<MIEMBRO> ListarTodo()
        {
            var miembro = new List<MIEMBRO>();

            try
            {
                using (var db = new Model1())
                {
                    miembro = db.MIEMBRO.Include("GRUPO")
                        .Include("USUARIO")
                        .Include("PROYECTO")
                        .Include("TIPO_USUARIO")
                        .ToList();
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return miembro;
        }

        public void Guardar()
        {
            try
            {
                using (var db = new Model1())
                {
                    if (this.ID_MIEMBRO > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        db.Entry(this).State = EntityState.Added;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public MIEMBRO ObtenerMiembro(int id)
        {
            var miembro = new MIEMBRO();

            try
            {
                using (var db = new Model1())
                {
                    miembro = db.MIEMBRO
                        .Where(x => x.ID_MIEMBRO == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return miembro;
        }

        public void Eliminar()
        {
            var miembro = ObtenerMiembro(ID_MIEMBRO);
            this.ID_MIEMBRO = miembro.ID_PROYECTO;
            this.ID_GRUPO = miembro.ID_GRUPO;
            this.ID_PROYECTO = miembro.ID_PROYECTO;
            this.ID_USUARIO = miembro.ID_MIEMBRO;
            this.ID_TIPOUSUARIO = miembro.ID_TIPOUSUARIO;
            try
            {
                using (var db = new Model1())
                {
                    if (this.ID_GRUPO > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }


    }
}
