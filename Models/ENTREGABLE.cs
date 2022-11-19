namespace SistemaGestionDeConfiguracionSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;

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

      
    }
}
