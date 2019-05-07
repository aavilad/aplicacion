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

namespace xtraForm.Modulos.Reportes.Modulos.Distribucion
{
    public partial class frmDistribucion : DevExpress.XtraEditors.XtraForm
    {
        public frmDistribucion()
        {
            InitializeComponent();
        }

        private void frmDistribucion_Load(object sender, EventArgs e)
        {
            using (var Context = new Model.LiderAppEntities())
            {
                var Reportes = Context.Reporte.Where(x => x.Tipo == 2).Select(p => new { ID = p.PKID, Codigo = p.Codigo, Nombre = p.Descripcion }).ToList();
                gridControl1.DataSource = Reportes;
                gridView1.Columns["ID"].Visible = false;
                gridView1.Columns["Nombre"].Width = 600;
                gridView1.OptionsBehavior.Editable = false;
                gridView1.OptionsBehavior.ReadOnly = true;
                gridView1.OptionsView.ColumnAutoWidth = false;
                gridView1.OptionsView.ShowGroupPanel = false;
                gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            using (var Context = new Model.LiderAppEntities())
            {
                var frmparametro = new Reportes.Elementos.frmParametros();
                var IDReporte = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));
                var IDVista = (Context.Reporte.Where(y => y.PKID == IDReporte).Select(z => z.IDVistaReporte)).FirstOrDefault();
                var sql = Context.VistaReporte.Where(x => x.PKID == IDVista).Select(t => t.Comando).FirstOrDefault();
                var parametros = Context.ParametroSQL.Where(x => x.IDVistaReporte == IDVista).Select(p=>new { Campo = p.Campo,Tipo=p.TipoDato}).ToList();
                //foreach (var fila in parametros)
                //{
                //    frmparametro.dataGridView1.Rows.Add(fila.Campo,fila.TipoDato);
                //}
                frmparametro.Show();
                

            }

        }
    }
}