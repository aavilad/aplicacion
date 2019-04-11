using System;
using System.Linq;

namespace xtraForm.Filtros
{
    public partial class frmfilPesos : DevExpress.XtraEditors.XtraForm
    {
        public delegate void variable(string fecha, string vendedor, string ruta, bool procesado);
        public event variable pasar;
        Libreria.Entidad entidad = new Libreria.Entidad();
        public frmfilPesos()
        {
            InitializeComponent();
            fechaproceso.EditValue = Convert.ToDateTime(DateTime.Now).ToString("yyyyMMdd");
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {
        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void checkButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkButton1.Checked)
            {
                checkButton1.Text = "Ruta";
            }
            else
            {
                checkButton1.Text = "vendedor";
            }
        }

        private void frmfilPesos_Load(object sender, EventArgs e)
        {
            fechaproceso.EditValue = Convert.ToDateTime(DateTime.Now).ToString("yyyyMMdd");
            checkButton1.Checked = false;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (checkButton1.Checked)
            {
                entidad.codigo = txtcadena.Text;
                entidad.codigoauxiliar = "*";
            }
            else
            {
                entidad.codigo = "*";
                entidad.codigoauxiliar = txtcadena.Text;
            }
            pasar(Convert.ToDateTime(fechaproceso.EditValue).ToString("yyyyMMdd"), entidad.codigoauxiliar, entidad.codigo, checkprocesado.Checked);
            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}