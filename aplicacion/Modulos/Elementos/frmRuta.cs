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
    public partial class frmRuta : DevExpress.XtraEditors.XtraForm
    {
        public delegate void Variables(string Codigo, string Descripcion, bool Activo);
        public event Variables pasar;
        public frmRuta()
        {
            InitializeComponent();
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            var Rutina = new Libreria.Rutina();
            if (Rutina.MensagePregunta("¿Continuar?") == DialogResult.Yes)
                this.Close();
        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            if (Validar.Validate())
            {
                try
                {
                    string RCodigo = Convert.ToString(Codigo.EditValue);
                    string RDescripcion = Convert.ToString(Descripcion.EditValue);
                    bool RActivo = Activo.Checked;
                    pasar(RCodigo, RDescripcion, RActivo);
                    this.Close();
                }
                catch (DbEntityValidationException t)
                {
                    var Formulario = new Elementos.frmResult();
                    foreach (DbEntityValidationResult item in t.EntityValidationErrors)
                    {
                        DbEntityEntry entry = item.Entry;
                        string entityTypeName = entry.Entity.GetType().Name;
                        foreach (DbValidationError subItem in item.ValidationErrors)
                        {
                            string message = string.Format("Error '{0}' occurred in {1} at {2}", subItem.ErrorMessage, entityTypeName, subItem.PropertyName);
                            Formulario.MemoEd.Text += message + "\n";
                            Formulario.Show();
                        }
                    }
                }
            }

        }
    }
}