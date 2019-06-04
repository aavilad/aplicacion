using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System;
using System.Linq;
using System.Windows.Forms;
using xtraForm.Model;

namespace xtraForm.Maestro
{
    public partial class frmProducto : DevExpress.XtraEditors.XtraForm
    {
        public bool Ex = false;
        public delegate void variables(string codigo, string descripcion, string unidad);
        public event variables pasar;
        public frmProducto()
        {
            InitializeComponent();
        }

        private void insertar()
        {
            try
            {
                if (gridView1.SelectedRowsCount > 0)
                {
                    foreach (var i in gridView1.GetSelectedRows())
                    {
                        string Codigo = Convert.ToString(gridView1.GetRowCellValue(i, "Codigo"));
                        string Descripcion = Convert.ToString(gridView1.GetRowCellValue(i, "Descripcion"));
                        string Unidad = Convert.ToString(gridView1.GetRowCellValue(i, "Unidad"));
                        pasar(Codigo, Descripcion, Unidad);
                    }
                    this.Close();
                }
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }

        private void gridControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
                insertar();
        }

        private void frmProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
                this.Close();
        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            if (!Ex)
                using (var CTX = new LiderEntities())
                {
                    var Product = from pd in CTX.PRODUCTOes
                                  where pd.Activo == true
                                  select new
                                  {
                                      Codigo = pd.Producto1.Trim(),
                                      Descripcion = pd.Descripcion.Trim(),
                                      Unidad = pd.UniMed.Trim(),
                                      Fisico = pd.StockAc,
                                      Disponible = (pd.StockAc - (pd.StockAc - pd.StockDia))
                                  };
                    gridControl1.DataSource = Product.ToList();
                }
        }

        private void ACEPTAR_Click(object sender, EventArgs e) => insertar();

        private void GridView1_DoubleClick(object sender, EventArgs e)
        {
            var proceso = new Libreria.Rutina();
            DXMouseEventArgs ea = e as DXMouseEventArgs;
            GridView view = sender as GridView;
            GridHitInfo info = view.CalcHitInfo(ea.Location);
            if (info.InRow || info.InRowCell)
                insertar();
        }
    }
}