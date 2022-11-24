namespace SistemaGestionDeConfiguracionSoftware.Models.bd
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("METODOLOGIA")]
    public partial class METODOLOGIA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public METODOLOGIA()
        {
            CRONOGRAMA = new HashSet<CRONOGRAMA>();
            PLANTILLAECS = new HashSet<PLANTILLAECS>();
            PROYECTO = new HashSet<PROYECTO>();
        }

        [Key]
        public int ID_METODOLOGIA { get; set; }

        [StringLength(20)]
        public string DESCRIPCION { get; set; }

        public bool? ESTADO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CRONOGRAMA> CRONOGRAMA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PLANTILLAECS> PLANTILLAECS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROYECTO> PROYECTO { get; set; }
    }
}
