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
    
    public partial class CLIENTE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CLIENTE()
        {
            this.PEDIDO = new HashSet<PEDIDO>();
        }
    
        public string Cliente1 { get; set; }
        public string Zona { get; set; }
        public string TipoCli { get; set; }
        public string Ruc { get; set; }
        public string Estado { get; set; }
        public System.DateTime FechIng { get; set; }
        public Nullable<int> TopeCredito { get; set; }
        public string DNI { get; set; }
        public string Telefono { get; set; }
        public decimal Saldo { get; set; }
        public bool Credito { get; set; }
        public string Alias { get; set; }
        public string Direccion { get; set; }
        public string iddistrito { get; set; }
        public string IdNegocio { get; set; }
        public string nuevo { get; set; }
        public Nullable<System.DateTime> ultmod { get; set; }
        public string usuario { get; set; }
        public string observacion { get; set; }
        public string ap_paterno { get; set; }
        public string ap_materno { get; set; }
        public string nombre1 { get; set; }
        public string nombre2 { get; set; }
        public string codbase { get; set; }
        public string codant { get; set; }
        public Nullable<byte> clasecli { get; set; }
        public string ptollegada { get; set; }
        public string distllegada { get; set; }
        public decimal porcentaje { get; set; }
        public string RAZ { get; set; }
        public string control { get; set; }
        public bool agente_ret { get; set; }
        public bool agente_per { get; set; }
        public bool agente_userf { get; set; }
        public Nullable<decimal> X { get; set; }
        public Nullable<decimal> Y { get; set; }
        public string CodVen1 { get; set; }
        public Nullable<short> dia1 { get; set; }
        public Nullable<int> sec { get; set; }
        public string CodVen2 { get; set; }
        public Nullable<short> dia2 { get; set; }
        public Nullable<byte> EstadoCli { get; set; }
        public string Correo { get; set; }
    
        public virtual ZONA ZONA1 { get; set; }
        public virtual Distrito Distrito { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PEDIDO> PEDIDO { get; set; }
    }
}
