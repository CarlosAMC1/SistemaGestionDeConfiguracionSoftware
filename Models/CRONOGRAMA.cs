namespace SistemaGestionDeConfiguracionSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CRONOGRAMA")]
    public partial class CRONOGRAMA
    {
        [Key]
        public int ID_CRONOGRAMA { get; set; }

        public int ID_PROYECTO { get; set; }

        public int PORCENTAJE_AVANCE { get; set; }

        [Column(TypeName = "date")]
        public DateTime FECHA_INICIO { get; set; }

        [Column(TypeName = "date")]
        public DateTime FECHA_FIN { get; set; }

        [StringLength(50)]
        public string TAREA_FINALIZADA { get; set; }

        [StringLength(50)]
        public string TAREA_ENPROCESO { get; set; }

        [StringLength(50)]
        public string TAREA_ABIERTA { get; set; }

        public int? ID_METODOLOGIA { get; set; }

        public int? ID_FASE { get; set; }

        [StringLength(50)]
        public string VERSION_ACTUAL { get; set; }

        [StringLength(50)]
        public string ECS { get; set; }

        public int? ID_MIEMBRO { get; set; }

        public virtual ETAPA ETAPA { get; set; }
        public virtual PROYECTO  PROYECTO { get; set; }
        public virtual METODOLOGIA METODOLOGIA { get; set; }
    }
}
