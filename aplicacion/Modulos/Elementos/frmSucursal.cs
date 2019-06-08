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

namespace xtraForm.Modulos.Elementos
{
    public partial class frmSucursal : DevExpress.XtraEditors.XtraForm
    {
        public delegate void Variable(string Codigo, int PersonaTp, string Nombre, string Documento, string FIngreso, string FNacimiento, string NTelefono, bool Comision,
            bool Activo, decimal Sueldo, bool EVendedor, int Clase, string Grupo, string GrupoK, string Distrito, int FVenta, bool Novedad, bool Dms, decimal pParticipa,
            decimal pCuota, string SCodigo);
        public event Variable pasar;
        public frmSucursal()
        {
            InitializeComponent();
        }

        private void CANCELAR_Click(object sender, EventArgs e)
        {
            var Rutina = new Libreria.Rutina();
            if (Rutina.MensagePregunta("¿Continuar?") == DialogResult.Yes)
                this.Close();
        }

        private void ACEPTAR_Click(object sender, EventArgs e)
        {
            try
            {
                string Codigo = Convert.ToString(CODIGO.EditValue).Trim();
                int PersonaTp = 2;
                string Nombre = Convert.ToString(DESCRIPCION.EditValue).Trim();
                string Documento = "";
                string FIngreso = Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy");
                string FNacimiento = Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy");
                string NTelefono = " ";
                bool Comision = false;
                bool Activo = ESTADO.Checked;
                decimal Sueldo = (decimal)0.00;
                bool EVendedor = true;
                int Clase = 0;
                string Grupo = " ";
                string GrupoK = " ";
                string Distrito = Convert.ToString(IDDISTRITO.EditValue).Trim();
                int FVenta = 0;
                bool Novedad = false;
                bool Dms = false;
                decimal pParticipa = (decimal)0.00;
                decimal pCuota = (decimal)0.00;
                string SCodigo = " ";
                pasar(Codigo, PersonaTp, Nombre, Documento, FIngreso, FNacimiento, NTelefono, Comision, Activo, Sueldo, EVendedor, Clase, Grupo, GrupoK, Distrito, FVenta, Novedad,
                Dms, pParticipa, pCuota, SCodigo);
                this.Close();
            }
            catch (DbEntityValidationException t)
            {
                foreach (var eve in t.EntityValidationErrors)
                    foreach (var ve in eve.ValidationErrors)
                        XtraMessageBox.Show("- Property: \"" + ve.PropertyName + "\", Error: \"" + ve.ErrorMessage + "\"");
            }
        }

        private void FrmSucursal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Escape)
                CANCELAR_Click(sender, e);
        }

        private void IDDISTRITO_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var Formulario = new Maestro.frmDistrito();
            Formulario.pasar += new Maestro.frmDistrito.variables(Entidad_Distrito);
            Formulario.ShowDialog();
        }

        private void Entidad_Distrito(string Codigo, string Descripcion)
        {
            IDDISTRITO.EditValue = Codigo;
            NMDISTRITO.EditValue = Descripcion;
        }
    }
}