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
    
    public partial class notaComentario
    {
        public int id { get; set; }
        public Nullable<int> id_usuario { get; set; }
        public Nullable<int> id_nota { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public string contenido { get; set; }
    
        public virtual nota nota { get; set; }
        public virtual usuario usuario { get; set; }
    }
}
