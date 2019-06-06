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

namespace xtraForm.Modulos.Elementos
{
    public partial class frmZona_ : DevExpress.XtraEditors.XtraForm
    {
        public delegate void Variables(string Codigo, string Descripcion);
        public event Variables pasar;
        public frmZona_()
        {
            InitializeComponent();
        }

        private void Entidad_Zona()
        {
            if (gridView1.SelectedRowsCount == 1)
                try
                {
                    string Codigo = Convert.ToString(gridView1.GetFocusedRowCellValue("Codigo"));
                    string Descripcion = Convert.ToString(gridView1.GetFocusedRowCellValue("Descripcion"));
                    pasar(Codigo, Descripcion);
                    this.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
        }

        private void GridView1_DoubleClick(object sender, EventArgs e)
        {
            var proceso = new Libreria.Rutina();
            DXMouseEventArgs ea = e as DXMouseEventArgs;
            GridView view = sender as GridView;
            GridHitInfo info = view.CalcHitInfo(ea.Location);
            if (info.InRow || info.InRowCell)
                Entidad_Zona();
        }

        private void FrmZona_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
                Entidad_Zona();
            if (e.KeyChar == (int)Keys.Escape)
                this.Close();
        }
    }
}