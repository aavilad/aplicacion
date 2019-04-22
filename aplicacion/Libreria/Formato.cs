using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xtraForm.Libreria
{
    class Formato
    {
        public void Grilla(GridView dgc)
        {
            dgc.OptionsBehavior.Editable = false;
            dgc.OptionsBehavior.ReadOnly = true;
            dgc.OptionsView.ColumnAutoWidth = false;
            dgc.OptionsView.ShowGroupPanel = false;
            dgc.OptionsSelection.EnableAppearanceFocusedCell = false;
            dgc.GroupRowHeight = 1;
            dgc.RowHeight = 1;
            dgc.Appearance.Row.FontSizeDelta = 0;
            dgc.BestFitColumns();
        }

    }

}
