using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System;
using System.Linq;
using System.Windows.Forms;

namespace xtraForm.Maestro
{
    public partial class frmVendedor : DevExpress.XtraEditors.XtraForm
    {
        Libreria.Entidad entidad = new Libreria.Entidad();

        public frmVendedor()
        {
            InitializeComponent();
        }

        public delegate void campos(string Codigo, string Nombre);

        public event campos pasar;

        private void Valores()
        {
            if (gridView1.RowCount > 0)
            {
                entidad.codigo = gridView1.GetFocusedRowCellValue("Codigo").ToString();
                entidad.nombre = gridView1.GetFocusedRowCellValue("Nombre").ToString();
                pasar(entidad.codigo, entidad.nombre);
                this.Close();
            }
        }
        private void frmVendedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
                this.Close();
        }

        private void gridControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
                Valores();
        }

        private void GridView1_DoubleClick(object sender, EventArgs e)
        {
            DXMouseEventArgs ea = e as DXMouseEventArgs;
            GridView view = sender as GridView;
            GridHitInfo info = view.CalcHitInfo(ea.Location);
            if (info.InRow || info.InRowCell)
                Valores();
        }
    }
}