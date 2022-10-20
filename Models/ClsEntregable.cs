using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaGestionDeConfiguracionSoftware.Models
{
    [Table("ENTREGABLE")]
    public class ClsEntregable
    {
        [Key]
        public int ID_ENTREGABLE { get; set; }

        [Required]
        [StringLength(40)]
        public string NOMBRE { get; set; }

        public int ID_ETAPA { get; set; }

        public bool? ESTADO { get; set; }

        public virtual ClsEtapa ETAPA { get; set; }
    }
}