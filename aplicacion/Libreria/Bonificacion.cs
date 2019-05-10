using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xtraForm.Libreria
{
    class Bonificacion
    {
        public int Id { get; set; }
        public string Mecanica { get; set; }
        public int TipoMecanica { get; set; }
        public string CodigoTipoMecanica { get; set; }
        public string DescripcionTipoMecanica { get; set; }
        public string CodigoObsequio { get; set; }
        public decimal CantidadMinima { get; set; }
        public int CantidadMaxima { get; set; }
        public int CantidadObsequio { get; set; }
        public int MaximoPorCliente { get; set; }
        public decimal Stock { get; set; }
        public int Asignaciones { get; set; }
        public bool Exclusion { get; set; }
        public int IdExclusion { get; set; }
        public string CodigoVenta { get; set; }
        public string Proveedor { get; set; }
        public string Desde { get; set; }
        public string Hasta { get; set; }
        public bool Activo { get; set; }
        public string IdItemBonificacion { get; set; }
        public int IdAsociado { get; set; }
        public string CodigoAsociado { get; set; }

    }
}
