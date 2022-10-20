using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SistemaGestionDeConfiguracionSoftware.Models
{
    [Table("METODOLOGIA")]
    public class ClsMetodologia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ClsMetodologia()
        {
            ETAPA = new HashSet<ClsEtapa>();
            PROYECTO = new HashSet<ClsProyecto>();
        }

        [Key]
        public int ID_METODOLOGIA { get; set; }

        [StringLength(20)]
        public string DESCRIPCION { get; set; }

        public bool? ESTADO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClsEtapa> ETAPA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClsProyecto> PROYECTO { get; set; }

        public List<ClsMetodologia> ListarTodo()
        {
            var metodologia = new List<ClsMetodologia>();

            try
            {
                using (var db = new ClsModeloSGCS())
                {
                    metodologia = db.METODOLOGIA.ToList();
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return metodologia;
        }

        public void Guardar()
        {
            try
            {
                using (var db = new ClsModeloSGCS())
                {
                    if (this.ID_METODOLOGIA > 0)
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

        public ClsMetodologia ObtenerMetodologia(int id)
        {
            var metodologia = new ClsMetodologia();

            try
            {
                using (var db = new ClsModeloSGCS())
                {
                    metodologia = db.METODOLOGIA
                        .Where(x => x.ID_METODOLOGIA == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return metodologia;
        }

        public void Eliminar()
        {
            var metodologia = ObtenerMetodologia(ID_METODOLOGIA);
            this.ID_METODOLOGIA = metodologia.ID_METODOLOGIA;
            this.DESCRIPCION = metodologia.DESCRIPCION;
            this.ESTADO = false;
            try
            {
                using (var db = new ClsModeloSGCS())
                {
                    if (this.ID_METODOLOGIA > 0)
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

        public void Habilitar()
        {
            var metodologia = ObtenerMetodologia(ID_METODOLOGIA);
            this.ID_METODOLOGIA = metodologia.ID_METODOLOGIA;
            this.DESCRIPCION = metodologia.DESCRIPCION;
            this.ESTADO = true;
            try
            {
                using (var db = new ClsModeloSGCS())
                {
                    if (this.ID_METODOLOGIA > 0)
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