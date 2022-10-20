using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaGestionDeConfiguracionSoftware.Models
{
    [Table("TIPO_USUARIO")]
    public class ClsTipoUsuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ClsTipoUsuario()
        {
            USUARIO = new HashSet<ClsUsuario>();
        }

        [Key]
        public int ID_TIPOUSUARIO { get; set; }

        [StringLength(20)]
        public string DESCRIPCION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClsUsuario> USUARIO { get; set; }
    }
}