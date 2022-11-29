namespace SistemaGestionDeConfiguracionSoftware.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GRUPO")]
    public partial class GRUPO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GRUPO()
        {
            MIEMBRO = new HashSet<MIEMBRO>();
        }

        [Key]
        public int ID_GRUPO { get; set; }

        public int ID_PROYECTO { get; set; }

        [Required]
        [StringLength(45)]
        public string nombre { get; set; }

        public virtual PROYECTO PROYECTO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MIEMBRO> MIEMBRO { get; set; }
    }
}
