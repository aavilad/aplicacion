using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xtraForm.Model;
namespace xtraForm.Modulos.Elementos
{
    public partial class frmClienteDireccion : DevExpress.XtraEditors.XtraForm
    {
        Libreria.Proceso proceso = new Libreria.Proceso();
        public delegate void Variables(string _Direccion, string _Ditstrito, string _Provincia, string _Departamento);
        public event Variables pasar;
        public frmClienteDireccion() => InitializeComponent();

        private void Cancelar_Click(object sender, EventArgs e)
        {
            if (proceso.MensageError("¿cancelar?") == DialogResult.Yes)
                this.Close();
        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            string _Direccion = Direccion.Text.Trim();
            string _Distrito = Convert.ToString(Distrito.EditValue);
            string _provincia = Convert.ToString(Provincia.EditValue);
            string _Departamento = Convert.ToString(Departamento.EditValue);
            pasar(_Direccion, _Distrito, _provincia, _Departamento);
            this.Close();
        }

        private void frmClienteDireccion_Load(object sender, EventArgs e)
        {
            using (var CTX = new LiderEntities())
            {
                Distrito.Properties.DataSource = CTX.Distritoes.ToList();
                Distrito.Properties.DisplayMember = "descrip";
                Distrito.Properties.ValueMember = "iddistrito";
                Distrito.Properties.Columns.Add(new LookUpColumnInfo("descrip", string.Empty));
                //
                Provincia.Properties.DataSource = CTX.provincias.ToList();
                Provincia.Properties.DisplayMember = "descrip";
                Provincia.Properties.ValueMember = "idprovincia";
                Provincia.Properties.Columns.Add(new LookUpColumnInfo("descrip", string.Empty));
                //
                Departamento.Properties.DataSource = CTX.Departamentoes.ToList();
                Departamento.Properties.DisplayMember = "descrip";
                Departamento.Properties.ValueMember = "iddpto";
                Departamento.Properties.Columns.Add(new LookUpColumnInfo("descrip", string.Empty));
            }


        }
    }
}