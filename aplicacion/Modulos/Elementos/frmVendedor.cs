using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xtraForm.Model;

namespace xtraForm.Modulos.Elementos
{
    public partial class frmVendedor : DevExpress.XtraEditors.XtraForm
    {
        public bool Ex;
        public delegate void Variable(string Codigo, int PersonaTp, string Nombre, string Documento, string FIngreso, string FNacimiento, string NTelefono, bool Comision,
            bool Activo, decimal Sueldo, bool EVendedor, int Clase, string Grupo, string GrupoK, string Distrito, int FVenta, bool Novedad, bool Dmd, decimal pParticipa,
            decimal pCuota, string SCodigo);
        public event Variable pasar;

        public frmVendedor()
        {
            InitializeComponent();
        }

        private void CANCELAR_Click(object sender, EventArgs e)
        {
            var proceso = new Libreria.Rutina();
            if (proceso.MensagePregunta("¿Continuar?") == DialogResult.Yes)
                this.Close();
        }

        private void frmVendedor_Load(object sender, EventArgs e)
        {
            using (var CTX = new LiderEntities())
            {
                FVENTAS.Properties.DataSource = CTX.FuerzaVentas.Where(x => x.Activo == true).ToList();
                FVENTAS.Properties.DisplayMember = "descrip";
                FVENTAS.Properties.ValueMember = "fzavtas";
                FVENTAS.Properties.Columns.Add(new LookUpColumnInfo("descrip", string.Empty));
            }
        }

        private void ACEPTAR_Click(object sender, EventArgs e)
        {
            using (var CTX = new LiderEntities())
            {
                if (Validar.Validate())
                {
                    try
                    {

                        string Codigo = Convert.ToString(CODIGO.EditValue).Trim();
                        int PersonaTp = 1;
                        string Nombre = Convert.ToString(NOMBRES.EditValue).Trim();
                        string Documento = Convert.ToString(DIDENTIDAD.EditValue).Trim();
                        string FIngreso = Convert.ToDateTime(FINGRESO.EditValue).ToString("dd/MM/yyyy");
                        string FNacimiento = Convert.ToDateTime(FCUMPLEAÑO.EditValue).ToString("dd/MM/yyyy");
                        string NTelefono = Convert.ToString(TELEFONO.EditValue).Trim();
                        bool Comision = COMISION.Checked;
                        bool Activo = ACTIVO.Checked;
                        decimal Sueldo = (decimal)0.00;
                        bool EVendedor = true;
                        int Clase = Convert.ToInt32(PRECIOESCALA.SelectedIndex) + 1;
                        string Grupo = " ";
                        string GrupoK = " ";
                        string Distrito = "130101";
                        int FVenta = Convert.ToInt32(FVENTAS.EditValue);
                        bool Novedad = NOVEDAD.Checked;
                        bool Dmd = false;
                        decimal pParticipa = (decimal)0.00;
                        decimal pCuota = (decimal)0.00;
                        string SCodigo = " ";
                        pasar(Codigo, PersonaTp, Nombre, Documento, FIngreso, FNacimiento, NTelefono, Comision, Activo, Sueldo, EVendedor, Clase, Grupo, GrupoK, Distrito, FVenta, Novedad,
                        Dmd, pParticipa, pCuota, SCodigo);
                        this.Close();
                    }
                    catch (DbEntityValidationException t)
                    {
                        foreach (var eve in t.EntityValidationErrors)
                        {
                            foreach (var ve in eve.ValidationErrors)
                            {
                                MessageBox.Show("- Property: \"" + ve.PropertyName + "\", Error: \"" + ve.ErrorMessage + "\"");
                            }
                        }
                    }
                }
            }

        }
    }
}