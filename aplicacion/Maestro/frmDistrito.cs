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
using System.Data.Entity;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using xtraForm.Model;

namespace xtraForm.Maestro
{
    public partial class frmDistrito : DevExpress.XtraEditors.XtraForm
    {
        public delegate void variables(string Codigo, string Descripcion);
        public event variables pasar;
        public frmDistrito()
        {
            InitializeComponent();
        }
        private void Entidad_Distrito()
        {
            string Codigo = Convert.ToString(gridView1.GetFocusedRowCellValue("Codigo"));
            string Descripcion = Convert.ToString(gridView1.GetFocusedRowCellValue("Descripcion"));
            pasar(Codigo, Descripcion);
            this.Close();
        }

        private void FrmDistrito_Load(object sender, EventArgs e)
        {
            using (var CTX = new LiderEntities())
            {
                var Lista = from R in CTX.Distritoes select new { Codigo = R.iddistrito,Descripcion = R.descrip};
                gridControl1.DataSource = null;
                gridView1.Columns.Clear();
                gridControl1.DataSource = Lista.ToList();
                gridView1.BestFitColumns();
            }

        }

        private void GridView1_DoubleClick_1(object sender, EventArgs e)
        {
            var proceso = new Libreria.Rutina();
            DXMouseEventArgs ea = e as DXMouseEventArgs;
            GridView view = sender as GridView;
            GridHitInfo info = view.CalcHitInfo(ea.Location);
            if (info.InRow || info.InRowCell)
                Entidad_Distrito();
        }

        private void GridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
                Entidad_Distrito();
        }
    }
}   