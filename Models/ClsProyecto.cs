using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaGestionDeConfiguracionSoftware.Models
{
    [Table("PROYECTO")]
    public class ClsProyecto
    {
        [Key]
        public int ID_PROYECYO { get; set; }

        [Required]
        [StringLength(50)]
        public string NOMBRE { get; set; }

        [Required]
        [StringLength(60)]
        public string DESCRIPCION { get; set; }

        public int ID_CLIENTE { get; set; }

        public int ID_METODOLOGIA { get; set; }

        public bool? ESTADO { get; set; }

        public int ID_JEFEPROYECTO { get; set; }

        [Column(TypeName = "date")]
        public DateTime FECHA_INICIO { get; set; }

        [Column(TypeName = "date")]
        public DateTime FECHA_FIN { get; set; }

        public virtual ClsMetodologia METODOLOGIA { get; set; }

        public virtual ClsUsuario USUARIO { get; set; }

        public virtual ClsUsuario USUARIO1 { get; set; }
    }
}