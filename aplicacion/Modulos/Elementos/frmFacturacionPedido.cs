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

namespace xtraForm.Modulos.Elementos
{
    public partial class frmFacturacionPedido : DevExpress.XtraEditors.XtraForm
    {
        public delegate void Variables(string Fecha, int SerieBoleta, int SerieFactura);
        public event Variables pasar;
        public frmFacturacionPedido()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            var proceso = new Libreria.Proceso();
            if (proceso.MensagePregunta("¿Cancelar?") == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            string Fecha_ = Convert.ToDateTime(dateEdit1.EditValue).ToString("yyyyMMdd");
            int SerieB = Convert.ToInt32(SerieBoleta.EditValue);
            int SerieF = Convert.ToInt32(SerieFacturas.EditValue);
            pasar(Fecha_, SerieB, SerieF);
        }

        private void frmFacturacionPedido_Load(object sender, EventArgs e)
        {
            using (var context = new Model.LiderAppEntities())
            {
                SerieFacturas.Properties.ShowHeader = false;
                SerieFacturas.Properties.DisplayMember = "Serie";
                SerieFacturas.Properties.ValueMember = "ID";
                SerieFacturas.Properties.Columns.Add(new LookUpColumnInfo("Detalle", "", 10));
                SerieFacturas.Properties.DataSource =
                    context.DOCTIPO.Where(x => x.codigo == "01").
                    Select(a => new { ID = a.PKID, Serie = a.Serie.Trim(), Detalle = a.Serie.Trim() + ":" + a.Descripcion.Trim() }).ToList();

                SerieBoleta.Properties.ShowHeader = false;
                SerieBoleta.Properties.DisplayMember = "Serie";
                SerieBoleta.Properties.ValueMember = "ID";
                SerieBoleta.Properties.Columns.Add(new LookUpColumnInfo("Detalle", "", 10));
                SerieBoleta.Properties.DataSource =
                    context.DOCTIPO.Where(x => x.codigo == "03").
                    Select(a => new { ID = a.PKID, Serie = a.Serie.Trim(), Detalle = a.Serie.Trim() + ":" + a.Descripcion.Trim() }).ToList();
            }
        }

        private void SerieBoleta_EditValueChanged(object sender, EventArgs e)
        {
            using (var Context = new Model.LiderAppEntities())
            {
                NumeroBoletas.EditValue = Context.DOCTIPO.Where(x => x.PKID == (int)SerieBoleta.EditValue).Select(s => s.Numero).FirstOrDefault();
                DescripcionBoletas.EditValue = Context.DOCTIPO.Where(x => x.PKID == (int)SerieBoleta.EditValue).Select(s => s.Descripcion).FirstOrDefault();
            }
        }

        private void SerieFacturas_EditValueChanged(object sender, EventArgs e)
        {
            using (var Context = new Model.LiderAppEntities())
            {
                NumeroFacturas.EditValue = Context.DOCTIPO.Where(x => x.PKID == (int)SerieFacturas.EditValue).Select(s => s.Numero).FirstOrDefault();
                DescripcionFacturas.EditValue = Context.DOCTIPO.Where(x => x.PKID == (int)SerieFacturas.EditValue).Select(s => s.Descripcion).FirstOrDefault();
            }
        }
    }
}