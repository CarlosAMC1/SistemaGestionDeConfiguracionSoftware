namespace SistemaGestionDeConfiguracionSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("GRUPO")]
    public partial class GRUPO
    {
        [Key]
        public int ID_GRUPO { get; set; }

        public int ID_PROYECTO { get; set; }

        [Required]
        [StringLength(45)]
        public string nombre { get; set; }

        public virtual PROYECTO PROYECTO { get; set; }

        //Metodo Listar
        public List<GRUPO> Listar()
        {
            var Grupo = new List<GRUPO>();
            try
            {
                using (var db = new Model1())
                {
                    Grupo = db.GRUPO.Include("PROYECTO").ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return Grupo;
        }
        //metodo obtener
        public GRUPO Obtener(int id)
        {
            var Grupo = new GRUPO();
            try
            {
                using (var db = new Model1())
                {
                    Grupo = db.GRUPO.Include("PROYECTO").Where(x => x.ID_GRUPO == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return Grupo;
        }


        //Metodo Buscar --> devolver collection
        public List<GRUPO> Buscar(string Criterio)
        {
            var Grupo = new List<GRUPO>();
            try
            {
                using (var db = new Model1())
                {
                    Grupo = db.GRUPO.Include("PROYECTO").Where(x => x.PROYECTO.NOMBRE.ToString().Contains(Criterio)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return Grupo;
        }

        //Metodo Guardar
        public void Guardar()
        {
            try
            {
                using (var db = new Model1())
                {
                    if (this.ID_GRUPO > 0) //Modificar registro
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else //Agregar Nuevo Registro
                    {
                        db.Entry(this).State = EntityState.Added;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Metodo ELiminar
        public void Eliminar()
        {
            try
            {
                using (var db = new Model1())
                {
                    db.Entry(this).State = EntityState.Deleted;
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
