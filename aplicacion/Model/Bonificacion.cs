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
    
    public partial class Bonificacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bonificacion()
        {
            this.ItemBonificacion = new HashSet<ItemBonificacion>();
        }
    
        public int PKID { get; set; }
        public string Mecanica { get; set; }
        public int TipoMecanica { get; set; }
        public string cdProductoRegalo { get; set; }
        public decimal CantidadMinima { get; set; }
        public string CantidadMaxima { get; set; }
        public string CantidadRegalo { get; set; }
        public string CantidadMaximaPorCliente { get; set; }
        public decimal Stock { get; set; }
        public decimal StockEntregado { get; set; }
        public bool TieneExclusion { get; set; }
        public int IDBonifcacionExcluida { get; set; }
        public string cdProductoVenta { get; set; }
        public string IDProveedor { get; set; }
        public System.DateTime Desde { get; set; }
        public System.DateTime Hasta { get; set; }
        public bool Activo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemBonificacion> ItemBonificacion { get; set; }
    }
}