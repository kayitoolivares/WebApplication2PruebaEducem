//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication2PruebaEducem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class personal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public personal()
        {
            this.usuario = new HashSet<usuario>();
        }
    
        public int id { get; set; }
        public string apepaterno { get; set; }
        public string apematerno { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public Nullable<System.DateTime> fechadeingreso { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<usuario> usuario { get; set; }
    }
}
