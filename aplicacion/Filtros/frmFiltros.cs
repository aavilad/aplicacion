using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace xtraForm.Filtros
{
    public partial class frmFiltros : DevExpress.XtraEditors.XtraForm
    {
        public string entidad;
        public delegate void variables(string sql);
        public event variables pasar;
        Libreria.Proceso procesar = new Libreria.Proceso();
        public frmFiltros()
        {
            InitializeComponent();
            dataGridView1.RowTemplate.Height = 20;
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> lista = new List<string>();
                foreach (DataGridViewRow dgv in dataGridView1.Rows)
                {
                    lista.Add(entidad + "." + "[" + dgv.Cells[0].Value + "]" + " " + dgv.Cells[1].Value + " " + "'" + dgv.Cells[2].Value.ToString() + "'" + " " + dgv.Cells[3].Value);
                }
                string query = string.Join(" ", lista.ToArray());
                pasar(query);
                if (procesar.ExistenciaCampo("PKID", "filtro", " tabla = '" + entidad + "'"))
                {
                    procesar.eliminar("Filtro", "tabla = '" + entidad + "'");
                    foreach (DataGridViewRow dgv in dataGridView1.Rows)
                    {
                        procesar.insertar("insert Filtro values(newid(),'" + dgv.Cells[0].Value + "','" + dgv.Cells[1].Value + "','" + dgv.Cells[2].Value.ToString() + "','" + dgv.Cells[3].Value + "','" + entidad + "')");
                    }
                }
                else
                {
                    foreach (DataGridViewRow dgv in dataGridView1.Rows)
                    {
                        procesar.insertar("insert Filtro values(newid(),'" + dgv.Cells[0].Value + "','" + dgv.Cells[1].Value + "','" + dgv.Cells[2].Value.ToString() + "','" + dgv.Cells[3].Value + "','" + entidad + "')");
                    }
                }
                this.Close();
            }
            catch (Exception t)
            {
                MessageBox.Show(t.Message);
            }


        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (procesar.MensagePregunta("cancelar proceso") == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridView1.BeginEdit(true);
            }
            catch { }

        }
    }
}