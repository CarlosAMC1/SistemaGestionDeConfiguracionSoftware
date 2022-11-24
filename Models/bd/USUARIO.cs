namespace SistemaGestionDeConfiguracionSoftware.Models.bd
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("USUARIO")]
    public partial class USUARIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USUARIO()
        {
            PROYECTO = new HashSet<PROYECTO>();
            PROYECTO1 = new HashSet<PROYECTO>();
        }

        [Key]
        public int ID_USUARIO { get; set; }

        [Required]
        [StringLength(60)]
        public string NOMBRE { get; set; }

        [Required]
        [StringLength(60)]
        public string APELLIDO { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        [StringLength(15)]
        public string CODIGO { get; set; }

        [StringLength(15)]
        public string TELEFONO { get; set; }

        [Required]
        [StringLength(50)]
        public string EMAIL { get; set; }

        [Required]
        [StringLength(80)]
        public string PASSWORD { get; set; }

        public int ID_TIPOUSUARIO { get; set; }

        public bool? ESTADO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROYECTO> PROYECTO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROYECTO> PROYECTO1 { get; set; }

        public virtual TIPO_USUARIO TIPO_USUARIO { get; set; }
    }
}
