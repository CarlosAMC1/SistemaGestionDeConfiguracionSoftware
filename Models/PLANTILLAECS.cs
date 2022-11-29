namespace SistemaGestionDeConfiguracionSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PLANTILLAECS
    {
        [Key]
        public int ID_PLANTILLAECS { get; set; }

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

        public int? ID_ECS { get; set; }

        public int? ID_MIEMBRO { get; set; }

        public virtual ECS ECS { get; set; }

        public virtual ETAPA ETAPA { get; set; }

        public virtual METODOLOGIA METODOLOGIA { get; set; }
    }
}
