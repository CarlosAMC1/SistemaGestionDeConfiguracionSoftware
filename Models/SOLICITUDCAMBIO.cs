namespace SistemaGestionDeConfiguracionSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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

        [StringLength(50)]
        public string TIPO_CAMBIO { get; set; }

        public int ID_MIEMBRO { get; set; }

        public virtual MIEMBRO MIEMBRO { get; set; }
    }
}
