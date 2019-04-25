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
using System.Data.Entity.SqlServer;

namespace xtraForm.Modulos.Elementos
{
    public partial class frmFacturacion : DevExpress.XtraEditors.XtraForm
    {
        public frmFacturacion()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            var proceso = new Libreria.Proceso();
            if (proceso.MensagePregunta("¿Cancelar?") == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void frmFacturacion_Load(object sender, EventArgs e)
        {

        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            var Fecha = Convert.ToDateTime(FechaProceso.EditValue).DayOfWeek;
            if (FechaProceso.EditValue != null)
            {
                if (CheckRuta.Checked)
                {
                    using (var Contex = new Model.LiderAppEntities())
                    {
                        RutaReparto.Properties.DataSource = (from p in Contex.RUTAS.AsEnumerable()
                                                             join q in Contex.REPARTO.AsEnumerable() on p.codigo equals q.Ruta
                                                             where p.Activo.Equals(true) && q.Dia == (int)Fecha//SqlFunctions.DatePart("weekday", Fecha)
                                                             select new { Codigo = p.codigo.Trim(), Descripcion = p.codigo.Trim()+" : "+p.descripcion.Trim() }).ToList();
                        RutaReparto.Properties.DisplayMember = "Descripcion";
                        RutaReparto.Properties.ValueMember = "Codigo";
                        RutaReparto.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descripcion", ""));
                    }
                }
            }
            else
            {
                MessageBox.Show("seleccione una fecha de proceso.");
            }
        }
    }
}