using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xtraForm.Libreria
{
    class Producto
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Unidad { get; set; }
        public int TipoPrecio { get; set; }
        public string CodigoPrecio { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal PrecioNeto { get; set; }
        public decimal Descuento { get; set; }
        public decimal Recargo { get; set; }
        public bool Bonificacion { get; set; }
        public bool Afecto { get; set; }

    }
}
