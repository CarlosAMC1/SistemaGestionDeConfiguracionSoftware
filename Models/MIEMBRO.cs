namespace SistemaGestionDeConfiguracionSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MIEMBRO")]
    public partial class MIEMBRO
    {
        [Key]
        public int ID_MIEMBRO { get; set; }

        public int ID_GRUPO { get; set; }

        public int ID_USUARIO { get; set; }

        public int ID_PROYECTO { get; set; }

        public int ID_TIPOUSUARIO { get; set; }

        public virtual GRUPO GRUPO { get; set; }

        public virtual PROYECTO PROYECTO { get; set; }

        public virtual TIPO_USUARIO TIPO_USUARIO { get; set; }

        public virtual USUARIO USUARIO { get; set; }
    }
}
