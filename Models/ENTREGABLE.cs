namespace SistemaGestionDeConfiguracionSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("ENTREGABLE")]
    public partial class ENTREGABLE
    {
        [Key]
        public int ID_ENTREGABLE { get; set; }

        [Required]
        [StringLength(40)]
        public string NOMBRE { get; set; }

        public int ID_ETAPA { get; set; }

        public bool? ESTADO { get; set; }

        public virtual ETAPA ETAPA { get; set; }

        //public List<ENTREGABLE> ListarTodo()

        //{
        //    var etapa = new List<ENTREGABLE>();

        //    try
        //    {
        //        using (var db = new Model1())
        //        {
        //            etapa = db.ENTREGABLE.Include("ETAPA").ToList();
        //        }
        //    }

        //    catch (Exception e)

        //    {
        //        throw;
        //    }

        //    return etapa;
        //}

        public void Guardar()
        {
            try
            {
                using (var db = new Model1())
                {
                    if (this.ID_ENTREGABLE > 0)
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

        //public ENTREGABLE ObtenerEntregable(int id)
        //{
        //    var etapa = new ENTREGABLE();

        //    try
        //    {
        //        using (var db = new Model1())
        //        {
        //            etapa = db.ENTREGABLE
        //                .Where(x => x.ID_ENTREGABLE == id)
        //                .SingleOrDefault();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }

        //    return etapa;
        //}

        //public void Eliminar()
        //{
        //    var etapa = ObtenerEntregable(ID_ETAPA);
        //    this.ID_ENTREGABLE= etapa.ID_ENTREGABLE;
        //    this.NOMBRE = etapa.NOMBRE;
        //    this.ID_ETAPA = etapa.ID_ETAPA;
        //    this.ESTADO = false;
        //    try
        //    {
        //        using (var db = new Model1())
        //        {
        //            if (this.ID_ETAPA > 0)
        //            {
        //                db.Entry(this).State = EntityState.Modified;
        //            }
        //            db.SaveChanges();
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw;
        //    }
        //}

        //public void Habilitar()
        //{
        //    var etapa = ObtenerEntregable(ID_ETAPA);
        //    this.ID_ETAPA = etapa.ID_ETAPA;
        //    this.NOMBRE = etapa.NOMBRE;
        //    this.ID_ETAPA = etapa.ID_ETAPA;
        //    this.ESTADO = true;
        //    try
        //    {
        //        using (var db = new Model1())
        //        {
        //            if (this.ID_ETAPA > 0)
        //            {
        //                db.Entry(this).State = EntityState.Modified;
        //            }
        //            db.SaveChanges();
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw;
        //    }
        //}


    }
}
