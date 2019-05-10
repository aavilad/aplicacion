using CrystalDecisions.CrystalReports.Engine;
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
        string sql;
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            using (var Context = new Model.LiderAppEntities())
            {
                var vista = new Reportes.Modulos.Distribucion.frm1();
                vista.Show();
            }
        }
    }
}