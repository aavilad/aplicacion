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
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;

namespace xtraForm.Maestro
{
    public partial class frmRutas : DevExpress.XtraEditors.XtraForm
    {
        public delegate void Variable(string Codigo, string Descripcion);
        public event Variable pasar;
        public frmRutas()
        {
            InitializeComponent();
        }

        private void GridControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
                Valores();
        }

        private void GridView1_DoubleClick(object sender, EventArgs e)
        {
            var proceso = new Libreria.Rutina();
            DXMouseEventArgs ea = e as DXMouseEventArgs;
            GridView view = sender as GridView;
            GridHitInfo info = view.CalcHitInfo(ea.Location);
            if (info.InRow || info.InRowCell)
                Valores();
        }

        private void Valores()
        {
            if (gridView1.SelectedRowsCount == 1)
            {
                string Codigo = Convert.ToString(gridView1.GetFocusedRowCellValue("Codigo"));
                string Nombre = Convert.ToString(gridView1.GetFocusedRowCellValue("Descripcion"));
                pasar(Codigo, Nombre);
                this.Close();
            }
        }
    }
}