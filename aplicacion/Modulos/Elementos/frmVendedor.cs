using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xtraForm.Model;

namespace xtraForm.Modulos.Elementos
{
    public partial class frmVendedor : DevExpress.XtraEditors.XtraForm
    {
        public frmVendedor()
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

        private void frmVendedor_Load(object sender, EventArgs e)
        {
            using (var CTX = new LiderEntities())
            {
                FVENTAS.Properties.DataSource = CTX.FuerzaVentas.Where(x => x.Activo == true).ToList();
                FVENTAS.Properties.DisplayMember = "fzavtas";
                FVENTAS.Properties.ValueMember = "PKID";
                FVENTAS.Properties.Columns.Add(new LookUpColumnInfo("fzavtas", string.Empty));
            }
        }
    }
}