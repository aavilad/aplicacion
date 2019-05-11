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

namespace xtraForm.Modulos.Compras
{
    public partial class frmCompra : DevExpress.XtraEditors.XtraForm
    {
        public frmCompra()
        {
            InitializeComponent();
        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            popupMenu1.ShowPopup(gridControl1.PointToScreen(e.Point));
        }

        private void FiltroCompra_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}