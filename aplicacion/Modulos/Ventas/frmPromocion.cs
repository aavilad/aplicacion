﻿using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using xtraForm.Model;

namespace xtraForm.Modulos.Ventas
{
    public partial class frmPromocion : DevExpress.XtraEditors.XtraForm
    {
        public string Tabla;
        public string NModulo;
        Libreria.Ejecutar ejecutar = new Libreria.Ejecutar();
        Libreria.Rutina proceso = new Libreria.Rutina();
        private bool Existe = false;

        public frmPromocion()
        {
            InitializeComponent();

        }
        void Refrescar()
        {
            try
            {
                using (var CTX = new LiderEntities())
                {
                    List<string> Lista = new List<string>();
                    var Result = CTX.Filtroes.Where(w => w.tabla == Tabla).OrderBy(o => o.Orden);
                    foreach (var X in Result)
                        Lista.Add(Tabla + "." + "[" + X.campo + "]" + X.condicion + "'" + X.valor + "'" + X.union);
                    string cadena = string.Join(" ", Lista.ToArray());
                    condicion(cadena);
                }
            }
            catch (Exception t)
            {
                MessageBox.Show(t.Message);
            }
        }

        void condicion(string cadena)
        {
            using (var Context = new LiderEntities())
            {
                string Query = Convert.ToString(Context.VistaAdministrativas.Where(x => x.IDModulo == (Context.Moduloes.Where(a => a.Nombre == NModulo).Select(b => b.PKID)).FirstOrDefault()).Select(a => a.Vista.Trim()).FirstOrDefault());
                try
                {
                    if (cadena.Length == 0)
                    {
                        proceso.consultar(Query, Tabla);
                        gridcontrolBonificacion.DataSource = proceso.ds.Tables[Tabla];
                        gridView1.Columns[0].Visible = true;
                        gridView1.Columns["Proveedor"].GroupIndex = 1;
                        gridView1.Columns["TipoMecanica"].GroupIndex = 2;
                        gridView1.GroupRowHeight = 1;
                        gridView1.RowHeight = 1;
                        gridView1.BestFitColumns();
                    }
                    else
                    {
                        proceso.consultar(Query + " where " + cadena, Tabla);
                        gridcontrolBonificacion.DataSource = proceso.ds.Tables[Tabla];
                        gridView1.Columns[0].Visible = true;
                        gridView1.Columns["Proveedor"].GroupIndex = 1;
                        gridView1.Columns["TipoMecanica"].GroupIndex = 2;
                        gridView1.GroupRowHeight = 1;
                        gridView1.RowHeight = 1;
                        gridView1.BestFitColumns();
                    }
                }
                catch (Exception t)
                {
                    XtraMessageBox.Show(t.Message);
                    gridcontrolBonificacion.DataSource = null;
                    gridcontrolBonificacion.Refresh();
                }
            }
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView view = (GridView)sender;
            if (e.RowHandle >= 0)
            {
                bool estado = Convert.ToBoolean(view.GetRowCellValue(e.RowHandle, "Activo"));
                if (estado == false)
                    e.Appearance.ForeColor = Color.LightGray;
                else if (Convert.ToDecimal(proceso.ConsultarCadena("iif(stockac = stockdia,stockac,stockac-(stockac-stockdia))", "producto", "producto = '" + view.GetRowCellValue(e.RowHandle, "cdProductoRegalo").ToString() + "'")) <= 0)
                    e.Appearance.ForeColor = Color.LightPink;
            }
        }

        private void NUEVO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Elementos.frmReglaBonificacion frmreglabonificacion = new Elementos.frmReglaBonificacion();
            frmreglabonificacion.pasar += new Elementos.frmReglaBonificacion.variable(Entidad_Bonificacion);
            frmreglabonificacion.Show();
        }

        private void Entidad_Bonificacion(int PKID, string Mecanica, int TipoMecanica, string CodigoObsequio, decimal CantidadMinima, int CantidadMaxima, int CantidadObsequio, int MaximoPorCliente, decimal Stock, bool Exclusion, int PkidExclusion, string CodigoVenta, string Proveedor, string Desde, string Hasta, bool Activo, int IDAsociado, DataGridView dgv)
        {
            Bonificacion Bn = new Bonificacion();
            Bn.PKID = 
        }

        private void COPIAR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Modificar();
        }

        private void Modificar()
        {
            if (gridView1.SelectedRowsCount > 0)
                using (var CTX = new LiderEntities())
                {
                    Elementos.frmReglaBonificacion frmreglabonificacion = new Elementos.frmReglaBonificacion();
                    frmreglabonificacion.pasar += new Elementos.frmReglaBonificacion.variable(Entidad_Bonificacion_);
                    int Id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("PKID"));
                    var Result = CTX.Bonificacions.Where(w => w.PKID == Id);
                    string Mecanica = Result.Select(s => s.Mecanica).FirstOrDefault();
                    int TipoMecanica = Result.Select(s => s.TipoMecanica).FirstOrDefault();
                    string CodigoTipoMecanica = CTX.TipoBonificacions.Where(w => w.PKID == TipoMecanica).Select(s => s.Codigo).FirstOrDefault();
                    string DescripcionTipoMecanica = CTX.TipoBonificacions.Where(w => w.PKID == TipoMecanica).Select(s => s.Descripcion).FirstOrDefault();
                    string Proveedor = Result.Select(s => s.IDProveedor).FirstOrDefault();
                    string ProveedorNombre = CTX.PROVEEDORs.Where(w => w.Proveedor1 == Proveedor.Trim()).Select(s => s.RazonSocial).FirstOrDefault();
                    string CodigoObsequio = Result.Select(s => s.cdProductoRegalo).FirstOrDefault();
                    string DescripcionObsequio = CTX.PRODUCTOes.Where(w => w.Producto1 == CodigoObsequio).Select(s => s.Descripcion).FirstOrDefault();
                    bool Exclusion = Result.Select(s => s.TieneExclusion).FirstOrDefault();
                    int IdExclusion = Result.Select(s => s.IDBonifcacionExcluida).FirstOrDefault();
                    string CodigoVenta = Result.Select(s => s.cdProductoVenta).FirstOrDefault();
                    string DescripcionVenta = CTX.PRODUCTOes.Where(w => w.Producto1 == CodigoVenta).Select(s => s.Descripcion).FirstOrDefault();
                    decimal CantidadMinima = Result.Select(s => s.CantidadMinima).FirstOrDefault();
                    int CantidadMaxima = Result.Select(s => s.CantidadMaxima).FirstOrDefault();
                    int CantidadObsequio = Result.Select(s => s.CantidadRegalo).FirstOrDefault();
                    int MaximoPorCliente = Result.Select(s => s.CantidadMaximaPorCliente).FirstOrDefault();
                    decimal Stock = Result.Select(s => s.Stock).FirstOrDefault();
                    DateTime Desde = Result.Select(s => s.Desde).FirstOrDefault();
                    DateTime Hasta = Result.Select(s => s.Hasta).FirstOrDefault();
                    bool Activo = Result.Select(s => s.Activo).FirstOrDefault();
                    int IdAsociado = CTX.ItemBonificacions.Where(w => w.IDBonificacion == Id).Select(s => s.IDAsociado).FirstOrDefault();
                    string CodigoAsociado = CTX.TipoAsociadoes.Where(w => w.PKID == IdAsociado).Select(s => s.Codigo).FirstOrDefault();
                    var Coleccion = CTX.ItemBonificacions.Where(w => w.IDBonificacion == Id);
                    frmreglabonificacion.IDControl.Text = Convert.ToString(Id);
                    frmreglabonificacion.IDBonificacion.EditValue = CodigoTipoMecanica;
                    frmreglabonificacion.nmBonificacion.Text = DescripcionTipoMecanica;
                    frmreglabonificacion.DetalleMecanica.Text = Mecanica;
                    frmreglabonificacion.IDProveedor.Text = Proveedor;
                    frmreglabonificacion.NmProveedor.Text = ProveedorNombre;
                    frmreglabonificacion.IDObsequio.Text = CodigoObsequio;
                    frmreglabonificacion.NmObsequio.Text = DescripcionObsequio;
                    frmreglabonificacion.TieneExclusion.Checked = Exclusion;
                    frmreglabonificacion.IDExclusion.EditValue = Exclusion is false ? string.Empty : Convert.ToString(IdExclusion);
                    frmreglabonificacion.NmExclusion.Text = Exclusion is false ? string.Empty : Mecanica;
                    frmreglabonificacion.IDCanje.Text = CodigoVenta;
                    frmreglabonificacion.NmCanje.Text = DescripcionVenta;
                    frmreglabonificacion.CantidadMaxima.Value = CantidadMaxima;
                    frmreglabonificacion.CantidadMinima.Value = CantidadMinima;
                    frmreglabonificacion.CantidadRegalo.Value = CantidadObsequio;
                    frmreglabonificacion.CantidadMaximaCliente.EditValue = MaximoPorCliente;
                    frmreglabonificacion.StockPromocional.Value = Stock;
                    frmreglabonificacion.fechaDesde.EditValue = Convert.ToDateTime(Desde).ToString("dd/MM/yyyy");
                    frmreglabonificacion.fechaHasta.EditValue = Convert.ToDateTime(Hasta).ToString("dd/MM/yyyy");
                    frmreglabonificacion.Estado.Checked = Activo;
                    frmreglabonificacion.dataGridView1.Rows.Clear();
                    switch (CodigoAsociado)
                    {
                        case "Marca":
                            frmreglabonificacion.cdMarca.Checked = true;
                            break;
                        case "Linea":
                            frmreglabonificacion.cdLinea.Checked = true;
                            break;
                        case "Grupo":
                            frmreglabonificacion.cdGrupo.Checked = true;
                            break;
                        case "Producto":
                            frmreglabonificacion.cdProducto.Checked = true;
                            break;
                    }
                    foreach (var X in Coleccion)
                    {
                        string Codigo = X.cdProductoColeccion;
                        string Descripcion = CTX.PRODUCTOes.Where(w => w.Producto1 == Codigo).Select(s => s.Descripcion).FirstOrDefault();
                        frmreglabonificacion.dataGridView1.Rows.Add(Codigo, Descripcion);
                    }
                    if (TipoMecanica == 1 || TipoMecanica == 3)
                        frmreglabonificacion.CantidadMaxima.Enabled = false;
                    else
                        frmreglabonificacion.CantidadMaxima.Enabled = true;

                    frmreglabonificacion.StartPosition = FormStartPosition.CenterScreen;
                    frmreglabonificacion.Show();
                }
        }

        private void Entidad_Bonificacion_(int PKID, string Mecanica, int TipoMecanica, string CodigoObsequio, decimal CantidadMinima, int CantidadMaxima, int CantidadObsequio, int MaximoPorCliente, decimal Stock, bool Exclusion, int PkidExclusion, string CodigoVenta, string Proveedor, string Desde, string Hasta, bool Activo, int IDAsociado, DataGridView dgv)
        {
            throw new NotImplementedException();
        }

        private void MODIFICAR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Existe = true;
            Modificar();
        }

        private void FILTRO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (var Context = new LiderEntities())
            {
                Filtros.frmFiltros filtro = new Filtros.frmFiltros();
                DataGridViewComboBoxColumn i = filtro.dataGridView1.Columns["Index1"] as DataGridViewComboBoxColumn;
                i.DataSource = Context.FiltroConfiguracions.Where(a => a.Tipo == "CONDICION").ToArray();
                i.DisplayMember = "Descripcion";
                i.ValueMember = "Codigo";
                DataGridViewComboBoxColumn j = filtro.dataGridView1.Columns["Index3"] as DataGridViewComboBoxColumn;
                j.DataSource = Context.FiltroConfiguracions.Where(a => a.Tipo == "OPERADOR").ToList();
                j.DisplayMember = "Descripcion";
                j.ValueMember = "Codigo";
                DataGridViewComboBoxColumn k = filtro.dataGridView1.Columns["Index0"] as DataGridViewComboBoxColumn;
                k.DataSource = Context.Database.SqlQuery<string>(Libreria.Constante.Mapa_Table + "'" + Tabla + "'").ToList();
                filtro.pasar += new Filtros.frmFiltros.variables(condicion);
                filtro.StartPosition = FormStartPosition.CenterScreen;
                foreach (var fila in Context.Filtroes.Where(w => w.tabla.Equals(Tabla)).ToList())
                    filtro.dataGridView1.Rows.Add(fila.campo, fila.condicion, fila.valor, fila.union);
                filtro.entidad = Tabla;
                filtro.ShowDialog();
            }
        }

        private void ELIMINAR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
                if (proceso.MensagePregunta("¿desea continuar?") == DialogResult.Yes)
                {
                    Elementos.frmMsg frmmensage = new Elementos.frmMsg();
                    frmmensage.Scm03.SplashFormStartPosition = SplashFormStartPosition.Default;
                    frmmensage.dataGridView1.Columns[0].HeaderText = "Mecanica";
                    frmmensage.dataGridView1.Columns[0].Width = 200;
                    frmmensage.dataGridView1.Columns[1].HeaderText = "Resultado";
                    frmmensage.dataGridView1.Columns[1].Width = 100;
                    frmmensage.dataGridView1.Columns[2].HeaderText = string.Empty;
                    frmmensage.dataGridView1.Columns[3].HeaderText = string.Empty;
                    frmmensage.Show();
                    frmmensage.Scm03.ShowWaitForm();
                    foreach (var bonificacion in gridView1.GetSelectedRows())
                    {
                        var x = Convert.ToInt32(gridView1.GetDataRow(bonificacion)["PKID"]);
                        if (proceso.ExistenciaCampo("pkid", "Bonificacion", "pkid = " + x))
                            frmmensage.dataGridView1.Rows.Add(gridView1.GetDataRow(bonificacion)["Mecanica"].ToString(), ejecutar.DeleteBonificacion(x),
                            string.Empty, string.Empty);
                    }
                    frmmensage.Scm03.CloseWaitForm();
                    Refrescar();
                }
        }

        private void gridView1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            MenuPrincipal.ShowPopup(gridcontrolBonificacion.PointToScreen(e.Point));
        }

        private void frmPromocion_Load(object sender, EventArgs e) => Refrescar();

        private void REFRESH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => Refrescar();

        private void GridView1_DoubleClick(object sender, EventArgs e)
        {
            DXMouseEventArgs ea = e as DXMouseEventArgs;
            GridView view = sender as GridView;
            GridHitInfo info = view.CalcHitInfo(ea.Location);
            if (info.InRowCell)
            {
                Existe = true;
                Modificar();
            }
        }
    }
}