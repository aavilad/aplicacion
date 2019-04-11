using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xtraForm.Libreria
{
    class Pedido
    {
        public string NumeroPedido { get; set; }
        public string CodigoVendedor { get; set; }
        public string NombreVendedor { get; set; }
        public string CodigoCliente { get; set; }
        public string NombreCliente { get; set; }
        public string DocumentoCliente { get; set; }
        public string DireccionCliente { get; set; }
        public string ZonaCliente { get; set; }
        public string DistritoCliente { get; set; }
        public string ProvinciaCliente { get; set; }
        public string Gestion { get; set; }
        public string FechaEmision { get; set; }
        public string FechaEntrega { get; set; }
        public bool Credito { get; set; }
        public string FormaPago { get; set; }
        public decimal ValorSubtotal { get; set; }
        public decimal ValorDescuento { get; set; }
        public decimal ValorRecargo { get; set; }
        public decimal ValorAfecto { get; set; }
        public decimal ValorInafecto { get; set; }
        public decimal ValorImpuesto { get; set; }
        public decimal ValorTotal { get; set; }
        public int TipoLista { get; set; }
    }
}
