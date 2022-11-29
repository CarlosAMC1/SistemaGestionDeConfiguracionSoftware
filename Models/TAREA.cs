namespace SistemaGestionDeConfiguracionSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TAREA")]
    public partial class TAREA
    {
        [Key]
        public int ID_TAREA { get; set; }

        [StringLength(50)]
        public string NOMBRE { get; set; }

        [Column(TypeName = "text")]
        public string JUSTIFICACION { get; set; }

        [StringLength(50)]
        public string CODIGO { get; set; }
    }
}
