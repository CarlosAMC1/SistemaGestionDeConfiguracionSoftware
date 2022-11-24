namespace SistemaGestionDeConfiguracionSoftware.Models.bd
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ECS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ECS()
        {
            PLANTILLAECS = new HashSet<PLANTILLAECS>();
        }

        [Key]
        public int ID_ECS { get; set; }

        [StringLength(50)]
        public string DESCRIPCION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PLANTILLAECS> PLANTILLAECS { get; set; }
    }
}
