namespace SistemaGestionDeConfiguracionSoftware.Models.bd
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ETAPA")]
    public partial class ETAPA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ETAPA()
        {
            CRONOGRAMA = new HashSet<CRONOGRAMA>();
            PLANTILLAECS = new HashSet<PLANTILLAECS>();
        }

        [Key]
        public int ID_ETAPA { get; set; }

        [StringLength(50)]
        public string DESCRIPCION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CRONOGRAMA> CRONOGRAMA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PLANTILLAECS> PLANTILLAECS { get; set; }
    }
}
