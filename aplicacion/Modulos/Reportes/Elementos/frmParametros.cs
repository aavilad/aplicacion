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

namespace xtraForm.Modulos.Reportes.Elementos
{
    public partial class frmParametros : DevExpress.XtraEditors.XtraForm
    {
        DateTimePicker Fecha = new DateTimePicker();
        CheckBox Verdad = new CheckBox();
        DataGridViewTextBoxCell Cbx = new DataGridViewTextBoxCell();
        Rectangle _rectangle;
        public frmParametros()
        {
            InitializeComponent();
            dataGridView1.Controls.Add(Fecha);
            dataGridView1.Controls.Add(Verdad);
            Fecha.Visible = false;
            Verdad.Visible = false;
            Fecha.Format = DateTimePickerFormat.Custom;
            Fecha.TextChanged += new EventHandler(Fecha_Seleccion);
            Verdad.CheckedChanged += new EventHandler(Verdad_Seleccion);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 2:
                    dataGridView1.Rows[e.RowIndex].Selected = true;
                    if (dataGridView1.Rows[e.RowIndex].Cells["Tipo"].Value.ToString() == "datetime")
                    {
                        _rectangle = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                        Fecha.Size = new Size(_rectangle.Width, _rectangle.Height);
                        Fecha.Location = new Point(_rectangle.X, _rectangle.Y);
                        Fecha.Visible = true;
                    }
                    else if (dataGridView1.Rows[e.RowIndex].Cells["Tipo"].Value.ToString() == "bool")
                    {
                        DataGridViewCheckBoxCell cellSelecion = dataGridView1.Rows[e.RowIndex].Cells[2] as DataGridViewCheckBoxCell;
                    }
                    break;

            }
        }
        void Fecha_Seleccion(object sender,EventArgs e)
        {
            dataGridView1.CurrentCell.Value = Fecha.Text.ToString();
        }
        void Verdad_Seleccion(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell.Value = Verdad.CheckState ;
        }

        private void dataGridView1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            Fecha.Visible = false;
        }

        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            Fecha.Visible = false;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            Fecha.Visible = false;
        }
    }
}