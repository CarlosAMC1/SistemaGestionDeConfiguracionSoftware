namespace SistemaGestionDeConfiguracionSoftware.Models.bd
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MIEMBRO")]
    public partial class MIEMBRO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MIEMBRO()
        {
            CRONOGRAMA = new HashSet<CRONOGRAMA>();
            PLANTILLAECS = new HashSet<PLANTILLAECS>();
            SOLICITUDCAMBIO = new HashSet<SOLICITUDCAMBIO>();
        }

        [Key]
        public int ID_MIEMBRO { get; set; }

        public int? ID_PROYECTO { get; set; }

        [StringLength(50)]
        public string NOMBRE { get; set; }

        [Required]
        [StringLength(50)]
        public string ROL { get; set; }

        [StringLength(50)]
        public string RESPONSABILIDAD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CRONOGRAMA> CRONOGRAMA { get; set; }

        public virtual PROYECTO PROYECTO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PLANTILLAECS> PLANTILLAECS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SOLICITUDCAMBIO> SOLICITUDCAMBIO { get; set; }
    }
}
