using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace xtraForm.Modulos.Elementos
{
    public partial class frmTipoCp : DevExpress.XtraEditors.XtraForm
    {
        public delegate void valores(int ID,string Tcodigo,string Tdescripcion,string Tserie,string Tnumero,string Tsigno,string Tsunat);
        public event valores pasar;
        public frmTipoCp()
        {
            InitializeComponent();
        }

        private void CANCELAR_Click(object sender, EventArgs e)
        {
            var proceso = new Libreria.Proceso();
            if (proceso.MensagePregunta("¿Continuar?") == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void ACEPTAR_Click(object sender, EventArgs e)
        {
            string Tcodigo = CODIGO.Text.Trim();
            string Tdescripcion = DESCRIPCION.Text.Trim();
            string Tserie = SERIE.Text.Trim();
            string Tnumero = NUMERO.Text.Trim();
            string Tsigno = SIGNO.Text.Trim();
            string Tsunat = CODIGOSUNAT.Text.Trim();
            pasar(Convert.ToInt32(IDF.Text.Trim()),Tcodigo, Tdescripcion, Tserie, Tnumero, Tsigno, Tsunat);
            this.Close();
        }
    }
}