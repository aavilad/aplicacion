using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace xtraForm.Filtros
{
    public partial class frmFiltros : DevExpress.XtraEditors.XtraForm
    {
        public delegate void variables(string sql);
        public event variables pasar;
        public string tabla;
        Libreria.Proceso procesar = new Libreria.Proceso();
        public frmFiltros()
        {
            InitializeComponent();
            dataGridView1.RowTemplate.Height = 20;
            llenar_cbox();
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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
        void llenar_cbox()
        {

            DataTable tablaCondicion = new DataTable();
            tablaCondicion.Columns.Add("condicion", typeof(System.String));
            tablaCondicion.Columns.Add("Valor", typeof(System.String));
            tablaCondicion.Rows.Add(string.Empty);
            tablaCondicion.Rows.Add("igual a", "=");
            tablaCondicion.Rows.Add("mayor igual", ">=");
            tablaCondicion.Rows.Add("menor igual", "<=");
            tablaCondicion.Rows.Add("es como", "like");
            cboxCondicion.DataSource = tablaCondicion;
            cboxCondicion.DisplayMember = "condicion";
            cboxCondicion.ValueMember = "Valor";
            //
            DataTable tablaunion = new DataTable();
            tablaunion.Columns.Add("Y/O", typeof(System.String));
            tablaunion.Columns.Add("Valor", typeof(System.String));
            tablaunion.Rows.Add(string.Empty, string.Empty);
            tablaunion.Rows.Add("Y", "and");
            tablaunion.Rows.Add("O", "or");

            cboxUnion.DataSource = tablaunion;
            cboxUnion.DisplayMember = "Y/O";
            cboxUnion.ValueMember = "Valor";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cboxCampo.Text.Length > 0 && cboxCondicion.Text.Length > 0 && txtValor.Text.Length > 0)
            {
                dataGridView1.Rows.Add(cboxCampo.SelectedValue, cboxCondicion.SelectedValue, txtValor.Text, cboxUnion.SelectedValue);
                cboxCampo.Text = string.Empty;
                cboxCondicion.Text = string.Empty;
                txtValor.Text = string.Empty;
                cboxUnion.Text = string.Empty;
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            List<string> lista = new List<string>();
            foreach (DataGridViewRow dgv in dataGridView1.Rows)
            {
                lista.Add("[" + dgv.Cells[0].Value + "]" + " " + dgv.Cells[1].Value + " " + "'" + dgv.Cells[2].Value.ToString() + "'" + " " + dgv.Cells[3].Value);
            }
            string query = string.Join(" ", lista.ToArray());
            pasar(query);
            if (procesar.ExistenciaCampo("PKID", "filtro", " tabla = '" + tabla + "'"))
            {
                procesar.eliminar("Filtro", "tabla = '" + tabla + "'");
                foreach (DataGridViewRow dgv in dataGridView1.Rows)
                {
                    procesar.insertar("insert Filtro values(newid(),'" + dgv.Cells[0].Value + "','" + dgv.Cells[1].Value + "','" + dgv.Cells[2].Value.ToString() + "','" + dgv.Cells[3].Value + "','" + tabla + "')");
                }
            }
            else
            {
                foreach (DataGridViewRow dgv in dataGridView1.Rows)
                {
                    procesar.insertar("insert Filtro values(newid(),'" + dgv.Cells[0].Value + "','" + dgv.Cells[1].Value + "','" + dgv.Cells[2].Value.ToString() + "','" + dgv.Cells[3].Value + "','" + tabla + "')");
                }
            }

            this.Close();

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
    }
}