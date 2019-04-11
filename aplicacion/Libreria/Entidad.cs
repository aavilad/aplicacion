using DevExpress.XtraEditors;
using System.Data;
using System.Windows.Forms;

namespace xtraForm.Libreria
{
    class Entidad
    {
        public int cantidadauxiliar { get; set; }
        public int index { get; set; }
        public bool exclusion { get; set; }
        public bool estado { get; set; }
        public bool existe { get; set; }
        //

        public string codigoauxiliar { get; set; }
        public string tabla { get; set; }
        public string sql { get; set; }
        public string cadena { get; set; }
        public string codigoasociado { get; set; }
        public string codigoprecio { get; set; }

        //
        public decimal cantidadminima { get; set; }
        public decimal cantidadstock { get; set; }
        public decimal cantidadstockentregado { get; set; }
        public decimal cantidadvendida { get; set; }
        public decimal precio { get; set; }
        public decimal cantidad { get; set; }
        public decimal suma { get; set; }

        //
        public int tipomecanica { get; set; }

        public int i { get; set; }
        public int x { get; set; }
        public int pkid { get; set; }
        public int IDtpbonificacion { get; set; }
        public int iditembonificacion { get; set; }
        public int idbonificacion { get; set; }
        public int cantidadmaxima { get; set; }
        public int cantidadobsequio { get; set; }
        public int cantidadmaximacliente { get; set; }
        public int tipoprecio { get; set; }

        public int cantidadtotalregalo { get; set; }


        public int cantidadentregada { get; set; }
        public int codigoexclusion { get; set; }
        public int idasociado { get; set; }

        //
        public string mecanica { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string Dni { get; set; }
        public string Ruc { get; set; }
        public string documento { get; set; }
        public string tipodocumento { get; set; }
        public string pedido { get; set; }
        public string codigoregalo { get; set; }
        public string codigocanje { get; set; }
        public string codigoproveedor { get; set; }
        public string fechainicio { get; set; }
        public string fechafin { get; set; }
        public string fecha { get; set; }
        public string nombreproveedor { get; set; }
        public string nombreregalo { get; set; }
        public string nombrexclusion { get; set; }
        public string nombreBonificacion { get; set; }
        public string nombrecanje { get; set; }
        public string asociado { get; set; }
        public string codigopedido { get; set; }
        public string descripcion { get; set; }
        public string directorio { get; set; }

        public DataTable table { get; set; }


        //
        public bool validaedit(Control Ctrl)
        {
            int valor = 0;
            foreach (Control ctrl in Ctrl.Controls)
            {
                BaseEdit editor = ctrl as BaseEdit;
                if (editor != null)
                {
                    valor++;
                }
            }
            if (valor > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool validadgv(DataGridView dgv)
        {
            if (dgv.Rows.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
