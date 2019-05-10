using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xtraForm.Filtros
{
    public partial class DetallePromocional : DevExpress.XtraEditors.XtraForm
    {
        public delegate void variable(string fecha);
        public event variable pasar;
        public DetallePromocional()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Libreria.Proceso proceso = new Libreria.Proceso();
            if (proceso.MensageError("¿Cancelar?") == DialogResult.Yes)
                this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            pasar(Convert.ToDateTime(FechaProceso.EditValue).ToString("yyyyMMdd"));
            this.Close();
        }
    }
}