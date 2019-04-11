using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace xtraForm.Libreria
{
    class Clean
    {
        public void ClearAllForm(Control Ctrl)
        {
            if (Ctrl.HasChildren)
            {
                foreach (Control ctrl in Ctrl.Controls)
                {

                    if (ctrl is DevExpress.XtraEditors.TextEdit)
                        (ctrl as DevExpress.XtraEditors.TextEdit).ResetText();

                    if (ctrl is DevExpress.XtraEditors.LookUpEdit)
                        (ctrl as DevExpress.XtraEditors.LookUpEdit).EditValue = 0;

                    if (ctrl is DevExpress.XtraEditors.ButtonEdit)
                        (ctrl as DevExpress.XtraEditors.ButtonEdit).ResetText();

                    if (ctrl is DevExpress.XtraEditors.DateEdit)
                        (ctrl as DevExpress.XtraEditors.DateEdit).ResetText();

                    if (ctrl.HasChildren)
                        ClearAllForm(ctrl);//Recursive
                }
            }
        }
        public void Control_txt(Control Ctrl, DataGridView dg)
        {
            foreach (Control ctrl in Ctrl.Controls)
            {
                BaseEdit editor = ctrl as BaseEdit;
                if (editor != null)
                {
                    editor.EditValue = null;
                }
                ClearAllForm(ctrl);//Recursive
            }
            dg.Rows.Clear();
        }
    }
}
