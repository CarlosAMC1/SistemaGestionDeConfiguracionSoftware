using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SistemaGestionDeConfiguracionSoftware.Models
{
    public class ClsUsuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ClsUsuario()
        {
            PROYECTO = new HashSet<ClsProyecto>();
            PROYECTO1 = new HashSet<ClsProyecto>();
        }

        [Key]
        public int ID_USUARIO { get; set; }

        [Required]
        [StringLength(60)]
        public string NOMBRE { get; set; }

        [Required]
        [StringLength(60)]
        public string APELLIDO { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        [StringLength(15)]
        public string CODIGO { get; set; }

        [StringLength(15)]
        public string TELEFONO { get; set; }

        [Required]
        [StringLength(50)]
        public string EMAIL { get; set; }

        [Required]
        [StringLength(80)]
        public string PASSWORD { get; set; }

        public int ID_TIPOUSUARIO { get; set; }

        public bool? ESTADO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClsProyecto> PROYECTO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClsProyecto> PROYECTO1 { get; set; }

        public virtual ClsTipoUsuario TIPO_USUARIO { get; set; }

        public List<ClsUsuario> ListarTodo()
        {
            var usuarios = new List<ClsUsuario>();

            try
            {
                using (var db = new ClsModeloSGCS())
                {
                    usuarios = db.USUARIO.Include("TIPO_USUARIO").ToList();
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return usuarios;
        }

        public void Guardar()
        {
            this.ESTADO = true;
            try
            {
                using (var db = new ClsModeloSGCS())
                {
                    if (this.ID_USUARIO > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        DateTime now = DateTime.Now;
                        this.FECHA_CREACION = Convert.ToDateTime(now.ToString("yyyy/MM/dd hh:mm:ss"));
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
    }
}