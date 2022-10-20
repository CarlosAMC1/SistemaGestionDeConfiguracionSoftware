using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaGestionDeConfiguracionSoftware.Models
{

    [Table("ETAPA")]
    public class ClsEtapa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ClsEtapa()
        {
            ENTREGABLE = new HashSet<ClsEntregable>();
        }

        [Key]
        public int ID_ETAPA { get; set; }

        [Required]
        [StringLength(40)]
        public string NOMBRE { get; set; }

        public int ID_METODOLOGIA { get; set; }

        public bool? ESTADO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClsEntregable> ENTREGABLE { get; set; }

        public virtual ClsMetodologia METODOLOGIA { get; set; }
    }
}