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
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;

namespace xtraForm.Modulos.Elementos
{
    public partial class frmZone : DevExpress.XtraEditors.XtraForm
    {
        public delegate void Variables(string Codigo, string Descripcion, bool Venta, bool Reparto, bool Estado,bool Riesgo);
        public event Variables pasar;
        public frmZone()
        {
            InitializeComponent();
        }

        private void CANCELAR_Click(object sender, EventArgs e)
        {
            var Rutina = new Libreria.Rutina();
            if (Rutina.MensagePregunta("¿Continuar?") == DialogResult.Yes)
                this.Close();
        }

        private void FrmZone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Escape)
                CANCELAR_Click(sender, e);
        }

        private void ACEPTAR_Click(object sender, EventArgs e)
        {
            try
            {
                string ZCodigo = Convert.ToString(CODIGO.EditValue);
                string ZDescripcion = Convert.ToString(DESCRIPCION.EditValue);
                bool ZVenta = Convert.ToBoolean(VENTA.Checked);
                bool ZReparto = Convert.ToBoolean(REPARTO.Checked);
                bool ZEstado = Convert.ToBoolean(ESTADO.Checked);
                bool ZRiesgo = Convert.ToBoolean(RIESGO.Checked);
                pasar(ZCodigo, ZDescripcion, ZVenta, ZReparto, ZEstado, ZRiesgo);
                this.Close();
            }
            catch (DbEntityValidationException t)
            {
                foreach (DbEntityValidationResult item in t.EntityValidationErrors)
                {
                    DbEntityEntry entry = item.Entry;
                    string entityTypeName = entry.Entity.GetType().Name;
                    foreach (DbValidationError subItem in item.ValidationErrors)
                    {
                        string message = string.Format("Error '{0}' occurred in {1} at {2}", subItem.ErrorMessage, entityTypeName, subItem.PropertyName);
                        XtraMessageBox.Show(message);
                    }
                }
            }

        }
    }
}