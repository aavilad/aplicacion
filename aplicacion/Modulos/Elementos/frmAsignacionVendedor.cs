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
using xtraForm.Model;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;

namespace xtraForm.Modulos.Elementos
{
    public partial class frmAsignacionVendedor : DevExpress.XtraEditors.XtraForm
    {
        public bool Ex;
        DataTable Visitas;
        int Y = 0;

        public frmAsignacionVendedor()
        {
            InitializeComponent();
        }

        public delegate void Variables(DataTable Tabla, string Codigo);

        public event Variables pasar;

        private void ACEPTAR_Click(object sender, EventArgs e)
        {
            int z = 0;
            int index = 0;
            if (Validar.Validate())
            {
                try
                {
                    foreach (DataGridViewRow Fila in dataGridView1.Rows)
                    {
                        foreach (DataGridViewColumn Columna in dataGridView1.Columns)
                            if (dataGridView1.Rows[Fila.Index].Cells[Columna.Index].Value == null)
                            {
                                z += 1;
                                index = Fila.Index;
                            }
                        if (z > 7)
                            dataGridView1.Rows.RemoveAt(index);
                    }
                    string Rv = Convert.ToString(RVCODIGO.EditValue).Trim();
                    foreach (DataGridViewRow R in dataGridView1.Rows)
                    {
                        string Zona = Convert.ToString(dataGridView1.Rows[R.Index].Cells["Codigo"].Value).Trim();
                        foreach (DataGridViewColumn C in dataGridView1.Columns)
                        {
                            string DiaSemana = Convert.ToString(dataGridView1.Columns[C.Index].Name).Trim();
                            switch (dataGridView1.Columns[C.Index].Name)
                            {
                                case "Lunes":
                                    if (Convert.ToBoolean(dataGridView1.Rows[R.Index].Cells[C.Index].Value))
                                        Visitas.Rows.Add(new object[] { Zona, Rv, DiaSemana, 1 });
                                    break;
                                case "Martes":
                                    if (Convert.ToBoolean(dataGridView1.Rows[R.Index].Cells[C.Index].Value))
                                        Visitas.Rows.Add(new object[] { Zona, Rv, DiaSemana, 2 });
                                    break;
                                case "Miercoles":
                                    if (Convert.ToBoolean(dataGridView1.Rows[R.Index].Cells[C.Index].Value))
                                        Visitas.Rows.Add(new object[] { Zona, Rv, DiaSemana, 3 });
                                    break;
                                case "Jueves":
                                    if (Convert.ToBoolean(dataGridView1.Rows[R.Index].Cells[C.Index].Value))
                                        Visitas.Rows.Add(new object[] { Zona, Rv, DiaSemana, 4 });
                                    break;
                                case "Viernes":
                                    if (Convert.ToBoolean(dataGridView1.Rows[R.Index].Cells[C.Index].Value))
                                        Visitas.Rows.Add(new object[] { Zona, Rv, DiaSemana, 5 });
                                    break;
                                case "Sabado":
                                    if (Convert.ToBoolean(dataGridView1.Rows[R.Index].Cells[C.Index].Value))
                                        Visitas.Rows.Add(new object[] { Zona, Rv, DiaSemana, 6 });
                                    break;
                                case "Domingo":
                                    if (Convert.ToBoolean(dataGridView1.Rows[R.Index].Cells[C.Index].Value))
                                        Visitas.Rows.Add(new object[] { Zona, Rv, DiaSemana, 7 });
                                    break;
                            }
                        }
                    }
                    pasar(Visitas, Rv);
                    this.Close();
                }
                catch (DbEntityValidationException t)
                {
                    var Formulario = new Elementos.frmResult();
                    foreach (DbEntityValidationResult item in t.EntityValidationErrors)
                    {
                        DbEntityEntry entry = item.Entry;
                        string entityTypeName = entry.Entity.GetType().Name;
                        foreach (DbValidationError subItem in item.ValidationErrors)
                        {
                            string message = string.Format("Error '{0}' occurred in {1} at {2}", subItem.ErrorMessage, entityTypeName, subItem.PropertyName);
                            Formulario.MemoEd.Text += message + "\n";
                            Formulario.Show();
                        }
                    }
                }
            }
        }

        private void AGREGAR_Click(object sender, EventArgs e)
        {
            if (RVCODIGO.Text.Length > 1 && RVNOMBRE.Text.Length > 4)
            {
                dataGridView1.Rows.Add();
                dataGridView1.BeginEdit(true);
            }
            else
                MessageBox.Show("Ingrese Datos de Vendedor");
        }

        private void CANCELAR_Click(object sender, EventArgs e)
        {
            var Rutina = new Libreria.Rutina();
            if (Rutina.MensagePregunta("¿Continuar?") == DialogResult.Yes)
                this.Close();
        }
        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!Ex)
            {
                using (var CTX = new LiderEntities())
                {
                    Y = e.RowIndex;
                    switch (dataGridView1.Columns[e.ColumnIndex].Name)
                    {
                        case "Codigo":
                            string Codigo = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Codigo"].Value is DBNull ? "" : dataGridView1.Rows[e.RowIndex].Cells["Codigo"].Value);
                            var Result = CTX.ZONAs.Where(w => w.Activo == true && w.Zona1 == Codigo);
                            if (Result.FirstOrDefault() != null)
                            {
                                if (!Validacion(Result.Select(s => s.Zona1).FirstOrDefault()))
                                {
                                    dataGridView1.Rows[e.RowIndex].Cells["Codigo"].Value = Result.Select(s => s.Zona1).FirstOrDefault();
                                    dataGridView1.Rows[e.RowIndex].Cells["Descripcion"].Value = Result.Select(s => s.Descripcion).FirstOrDefault();
                                    dataGridView1.Rows[e.RowIndex].Cells["Codigo"].ReadOnly = true;
                                    dataGridView1.Rows[e.RowIndex].Cells["Descripcion"].ReadOnly = true;
                                }
                                else
                                {
                                    MessageBox.Show("Zona Repetida.");
                                }
                            }
                            else if (Result.FirstOrDefault() == null && Codigo.Length > 0)
                            {
                                var Formulario = new Elementos.frmZona_();
                                Formulario.pasar += new Elementos.frmZona_.Variables(Entidad_Zonas);
                                Formulario.gridControl1.DataSource = CTX.ZONAs.Where(w => w.Activo == true)
                                    .Select(s => new { Codigo = s.Zona1.Trim(), Descripcion = s.Descripcion.Trim() }).ToList();
                                Formulario.gridView1.BestFitColumns();
                                Formulario.ShowDialog();
                            }
                            break;
                    }
                }
            }
        }
        private void DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowindex = (e.RowIndex + 1).ToString();
            var centerFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowindex, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void DataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells["Codigo"];
                dataGridView1.BeginEdit(true);
            }
        }

        private void DataGridView3_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowindex = (e.RowIndex + 1).ToString();
            var centerFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowindex, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void Entidad_Vendedor(string Codigo, string Nombre)
        {
            RVCODIGO.EditValue = Codigo;
            RVNOMBRE.EditValue = Nombre;
        }

        private void Entidad_Zonas(string Codigo, string Descripcion)
        {
            if (!Validacion(Codigo))
            {
                dataGridView1.Rows[Y].Cells["Codigo"].Value = Codigo;
                dataGridView1.Rows[Y].Cells["Descripcion"].Value = Descripcion;
                dataGridView1.Rows[Y].Cells["Codigo"].ReadOnly = true;
                dataGridView1.Rows[Y].Cells["Descripcion"].ReadOnly = true;
            }
        }

        private void FrmAsignacionVendedor_Load(object sender, EventArgs e)
        {
            Visitas = new DataTable();
            Visitas.Columns.Add("Zona", typeof(System.String));
            Visitas.Columns.Add("Personal", typeof(System.String));
            Visitas.Columns.Add("DiaSemana", typeof(System.String));
            Visitas.Columns.Add("Numero", typeof(System.Int32));
        }

        private void Quitar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
        }

        private void RVCODIGO_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using (var CTX = new LiderEntities())
            {
                List<string> Lista = new List<string>();
                foreach (var U in CTX.REPARTOes.Distinct())
                    Lista.Add("'" + U.Personal + "'");
                string Cadena = string.Join(",", Lista.ToArray());
                var Rv = CTX.PERSONALs.Where(w => w.Activo == true && w.vendedor == true && !Cadena.Contains(w.Personal1));
                var Formulario = new Maestro.frmVendedor();
                Formulario.gridControl1.DataSource = Rv.Select(s => new { Codigo = s.Personal1.Trim(), Nombre = s.Nombre.Trim() }).ToList();
                Formulario.pasar += new Maestro.frmVendedor.campos(Entidad_Vendedor);
                Formulario.gridView1.BestFitColumns();
                Formulario.ShowDialog();
            }
        }

        private bool Validacion(string codigo)
        {
            var T = false;
            if (dataGridView1.Rows.Count > 0)
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    if (codigo == Convert.ToString(dataGridView1.Rows[i].Cells["Codigo"].Value))
                        T = true;
            return T;
        }

        private void RVCODIGO_Properties_EditValueChanged(object sender, EventArgs e)
        {
            using (var CTX = new LiderEntities())
            {
                var Result = CTX.PERSONALs.Where(w => w.Personal1 == RVCODIGO.Text.Trim() && w.vendedor == true && w.Activo == true);
                if (Result.FirstOrDefault() != null && RVCODIGO.Text.Length > 1)
                {
                    RVCODIGO.EditValue = Result.Select(s => s.Personal1).FirstOrDefault().Trim();
                    RVNOMBRE.EditValue = Result.Select(s => s.Nombre).FirstOrDefault().Trim();
                }
                else if (Result.FirstOrDefault() == null && RVCODIGO.Text.Length > 1)
                {
                    var Rv = CTX.PERSONALs.Where(w => w.Activo == true && w.vendedor == true);
                    var Formulario = new Maestro.frmVendedor();
                    Formulario.gridControl1.DataSource = Rv.Select(s => new { Codigo = s.Personal1.Trim(), Nombre = s.Nombre.Trim() }).ToList();
                    Formulario.pasar += new Maestro.frmVendedor.campos(Entidad_Vendedor);
                    Formulario.gridView1.BestFitColumns();
                    Formulario.ShowDialog();
                }
            }
        }
    }
}