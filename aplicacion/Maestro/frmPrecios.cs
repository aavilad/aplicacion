using System;
using System.Linq;

namespace xtraForm.Maestro
{
    public partial class frmPrecios : DevExpress.XtraEditors.XtraForm
    {
        public delegate void variables(decimal precio, string cadena);
        public event variables pasar;
        Libreria.Entidad entidad = new Libreria.Entidad();
        public frmPrecios()
        {
            InitializeComponent();
        }

        private void vGridControl1_DoubleClick(object sender, EventArgs e)
        {
            entidad.precio = Convert.ToDecimal(vGridControl1.FocusedRow.Properties.Value);
            entidad.codigo = vGridControl1.FocusedRow.Properties.Caption;
            if (entidad.codigo.Trim() == "Prec Men Contado")
            {
                entidad.codigoauxiliar = "1";
            }
            else if (entidad.codigo.Trim() == "Prec May Contado")
            {
                entidad.codigoauxiliar = "2";
            }
            else if (entidad.codigo.Trim() == "Prec Men Credito")
            {
                entidad.codigoauxiliar = "4";
            }
            else if (entidad.codigo.Trim() == "Prec May Credito")
            {
                entidad.codigoauxiliar = "3";
            }
            else if (entidad.codigo.Trim() == "Prec Especial")
            {
                entidad.codigoauxiliar = "5";
            }
            else if (entidad.codigo.Trim() == "Prec SEspecial")
            {
                entidad.codigoauxiliar = "6";
            }
            else if (entidad.codigo.Trim() == "Prec SS Especial")
            {
                entidad.codigoauxiliar = "7";
            }

            pasar(entidad.precio, entidad.codigoauxiliar);
            this.Close();
        }
    }
}