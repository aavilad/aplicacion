using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xtraForm.Model;

namespace xtraForm.Modulos.Elementos
{
    public partial class frmFacturacionPedido : DevExpress.XtraEditors.XtraForm
    {
        public delegate void Variables(string Fecha, int Serie);
        public event Variables pasar;
        public frmFacturacionPedido()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            var proceso = new Libreria.Rutina();
            if (proceso.MensagePregunta("¿Cancelar?") == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            string Fecha_ = Convert.ToDateTime(FechaProceso.EditValue).ToString("yyyyMMdd");
            int Serie = Convert.ToInt32(this.Serie.EditValue);
            pasar(Fecha_, Serie);
        }

        private void frmFacturacionPedido_Load(object sender, EventArgs e)
        {
            using (var context = new LiderEntities())
            {
                Serie.Properties.ShowHeader = false;
                Serie.Properties.DisplayMember = "Serie";
                Serie.Properties.ValueMember = "ID";
                Serie.Properties.Columns.Add(new LookUpColumnInfo("Detalle", string.Empty, 10));
                Serie.Properties.DataSource =
                    context.DOCTIPOes.Where(x => "'03','01'".Contains(x.codigo)).
                    Select(a => new { ID = a.PKID, Serie = a.Serie.Trim(), Detalle = a.Serie.Trim() + ":" + a.Descripcion.Trim() }).ToList();
            }
        }

        private void SerieBoleta_EditValueChanged(object sender, EventArgs e)
        {
            using (var Context = new LiderEntities())
            {
                Numero.EditValue = Context.DOCTIPOes.Where(x => x.PKID == (int)Serie.EditValue).Select(s => s.Numero).FirstOrDefault();
                Descripcion.EditValue = Context.DOCTIPOes.Where(x => x.PKID == (int)Serie.EditValue).Select(s => s.Descripcion).FirstOrDefault();
            }
        }
    }
}