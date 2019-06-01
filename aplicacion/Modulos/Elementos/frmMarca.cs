using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xtraForm.Model;

namespace xtraForm.Modulos.Elementos
{
    public partial class frmMarca : DevExpress.XtraEditors.XtraForm
    {
        public delegate void Variables(string MarcaCodigo, string MarcaOrden, string MarcaProveedor, string MarcaLinea, string MarcaDescripcion, string MarcaAbreviacion);
        public event Variables pasar;
        public frmMarca()
        {
            InitializeComponent();
        }

        private void frmMarca_Load(object sender, EventArgs e)
        {
            using (var Context = new LiderEntities())
            {
                txtMarcaProveedor.Properties.DataSource = Context.PROVEEDORs.Select(x => new { Codigo = x.Proveedor1.Trim(), Nombre = x.RazonSocial.Trim() }).ToList();
                txtMarcaProveedor.Properties.DisplayMember = "Nombre";
                txtMarcaProveedor.Properties.ValueMember = "Codigo";
                txtMarcaProveedor.Properties.Columns.Add(new LookUpColumnInfo("Nombre", string.Empty));
                txtMarcaLinea.Properties.DataSource = Context.LINEAs.Select(x => new { Codigo = x.Linea1.Trim(), Nombre = x.Descripcion.Trim() }).ToList();
                txtMarcaLinea.Properties.DisplayMember = "Nombre";
                txtMarcaLinea.Properties.ValueMember = "Codigo";
                txtMarcaLinea.Properties.Columns.Add(new LookUpColumnInfo("Nombre", string.Empty));

            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            var proceso = new Libreria.Rutina();
            if (proceso.MensagePregunta("¿Continuar?") == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                string MarcaCodigo = txtMarcaCodigo.Text.Trim();
                string MarcaOrden = txtMarcaOrden.Text.Trim();
                string MarcaProveedor = Convert.ToString(txtMarcaProveedor.EditValue).Trim();
                string MarcaLinea = Convert.ToString(txtMarcaLinea.EditValue).Trim();
                string MarcaDescripcion = txtMarcaDescripcion.Text.Trim();
                string MarcaAbreviacion = txtMarcaAbreviacion.Text.Trim();
                if (dxValidationProvider1.Validate())
                {
                    pasar(MarcaCodigo, MarcaOrden, MarcaProveedor, MarcaLinea, MarcaDescripcion, MarcaAbreviacion);
                    this.Close();
                }
            }
            catch (SqlException t)
            {
                MessageBox.Show(t.Message);
            }
        }
    }
}