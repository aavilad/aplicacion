//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace xtraForm.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class ItemBonificacion
    {
        public int PKID { get; set; }
        public int IDBonificacion { get; set; }
        public string cdProductoColeccion { get; set; }
        public int IDAsociado { get; set; }
    
        public virtual Bonificacion Bonificacion { get; set; }
    }
}