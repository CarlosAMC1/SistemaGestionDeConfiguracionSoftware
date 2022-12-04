namespace SistemaGestionDeConfiguracionSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("SOLICITUDCAMBIO")]
    public partial class SOLICITUDCAMBIO
    {
        [Key]
        public int ID_SOLICITUD { get; set; }

        [Column(TypeName = "date")]
        public DateTime FECHA_INICIO { get; set; }

        [Column(TypeName = "date")]
        public DateTime FECHA_FIN { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string DESCRIPCION { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string ID_Proyecto { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string ID_MIEMBRO { get; set; }

        public List<SOLICITUDCAMBIO> Listar()
        {
            var sc = new List<SOLICITUDCAMBIO>();
            try
            {
                using (var db = new Model1())
                {
                    sc = db.SOLICITUDCAMBIO.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return sc;

        }
        public SOLICITUDCAMBIO Obtener(int id)
        {
            var sc = new SOLICITUDCAMBIO();

            try
            {
                using (var db = new Model1())
                {
                    sc = db.SOLICITUDCAMBIO
                        .Where(x => x.ID_SOLICITUD == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return sc;
        }


        //guardar solicitud
        public void Guardar()
        {
            try
            {
                using (var db = new Model1())
                {
                    if (this.ID_SOLICITUD > 0)
                    {
                        db.Entry(this).State = EntityState.Modified; //existe
                    }
                    else
                    {
                        db.Entry(this).State = EntityState.Added; //nuevo registro
                    }
                    db.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
