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
    
    public partial class PERSONAL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PERSONAL()
        {
            this.DOCUMENTOes = new HashSet<DOCUMENTO>();
            this.PEDIDOes = new HashSet<PEDIDO>();
        }
    
        public string Personal1 { get; set; }
        public string TipoPersona { get; set; }
        public string Nombre { get; set; }
        public string LibElec { get; set; }
        public Nullable<System.DateTime> FechIng { get; set; }
        public Nullable<System.DateTime> FechNac { get; set; }
        public string Telefono { get; set; }
        public bool Comision { get; set; }
        public bool Activo { get; set; }
        public decimal Sueldo { get; set; }
        public byte vendedor { get; set; }
        public int clase { get; set; }
        public string grupo { get; set; }
        public string grupok { get; set; }
        public string distrito { get; set; }
        public string fzavtas { get; set; }
        public bool novedad { get; set; }
        public bool dms { get; set; }
        public decimal pparticipa { get; set; }
        public decimal pcuota { get; set; }
        public string supercodigo { get; set; }
        public string Direccion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DOCUMENTO> DOCUMENTOes { get; set; }
        public virtual FuerzaVenta FuerzaVenta { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PEDIDO> PEDIDOes { get; set; }
    }
}
