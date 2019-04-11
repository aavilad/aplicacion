using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace xtraForm.Maestro
{
    public partial class frmPesos : DevExpress.XtraEditors.XtraForm
    {
        Libreria.Maestra maestro = new Libreria.Maestra();
        public frmPesos()
        {
            InitializeComponent();
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            {
                var grid = sender as DataGridView;
                var rowIdx = (e.RowIndex + 1).ToString();

                var centerFormat = new StringFormat()
                {
                    // right alignment might actually make more sense for numbers
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
                e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
            }
        }

        private void frmPesos_Load(object sender, EventArgs e)
        {
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView1.RowTemplate.Height = 18;
        }

        private void filtarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtros.frmfilPesos frmfiltropesos = new Filtros.frmfilPesos();
            frmfiltropesos.pasar += new Filtros.frmfilPesos.variable(condicion);
            frmfiltropesos.Show();
            //proceso.consultar(entidad.sql,"pesos");

        }
        void condicion(string fecha, string vendedor, string ruta, bool procesado)
        {
            foreach (DataRow F00 in maestro.Pesos(fecha, vendedor, ruta, procesado).Rows)
            {
                dataGridView1.Rows.Add(F00["TipoDoc"], F00["Pedido"], F00["documento"], F00["Cliente"], F00["Nombre"], F00["Producto"], F00["Descripcion"], F00["UniMed"], F00["Cantidad"]);
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView1.BeginEdit(true);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell = dataGridView1.CurrentRow.Cells["Disponible"];
        }
    }
}