using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using xtraForm.Model;

namespace xtraForm.Modulos.Elementos
{
    public partial class frmComprobantes : DevExpress.XtraEditors.XtraForm
    {
        string tabla = "Vva_Cp";
        public string NModulo;
        Libreria.Proceso proceso = new Libreria.Proceso();
        public frmComprobantes()
        {
            InitializeComponent();
        }

        void Refrescar()
        {
            proceso.consultar("select campo, condicion, valor,[union] from filtro where tabla = '" + tabla + "'", tabla);
            List<string> lista_ = new List<string>();
            foreach (DataRow DR_1 in proceso.ds.Tables[tabla].Rows)
                lista_.Add(tabla + "." + "[" + DR_1[0].ToString() + "]" + DR_1[1].ToString() + "'" + DR_1[2].ToString() + "'" + DR_1[3].ToString());
            string cadena = string.Join(" ", lista_.ToArray());
            condicion(cadena);
        }

        void condicion(string cadena)
        {
            using (var Context = new LiderEntities())
            {
                string Query = Convert.ToString(Context.VistaAdministrativas.Where(x => x.IDModulo == (Context.Moduloes.Where(a => a.Nombre == NModulo).Select(b => b.PKID)).FirstOrDefault()).Select(a => a.Vista.Trim()).FirstOrDefault());
                if (cadena.Length == 0)
                {
                    proceso.consultar(Query, tabla);
                    gridControl1.DataSource = proceso.ds.Tables[tabla];
                    gridView1.OptionsView.ColumnAutoWidth = false;
                    gridView1.OptionsBehavior.Editable = false;
                    gridView1.OptionsBehavior.ReadOnly = true;
                    gridView1.OptionsView.ShowGroupPanel = false;
                    gridView1.OptionsView.ShowFooter = true;
                    gridView1.FooterPanelHeight = -2;
                    gridView1.Columns["Valor Venta"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns["afecto"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns["inafecto"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns["igv"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns["Valor Total"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns["Credito"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                    gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
                    gridView1.GroupRowHeight = 1;
                    gridView1.RowHeight = 1;
                    gridView1.Appearance.Row.FontSizeDelta = 0;
                    gridView1.BestFitColumns();
                }
                else
                {
                    try
                    {
                        proceso.consultar(Query + " HAVING " + cadena, tabla);
                        gridControl1.DataSource = proceso.ds.Tables[tabla];
                        gridView1.OptionsView.ColumnAutoWidth = false;
                        gridView1.OptionsBehavior.Editable = false;
                        gridView1.OptionsBehavior.ReadOnly = true;
                        gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
                        gridView1.OptionsView.ShowGroupPanel = false;
                        gridView1.OptionsView.ShowFooter = true;
                        gridView1.Columns["Valor Venta"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                        gridView1.Columns["afecto"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                        gridView1.Columns["inafecto"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                        gridView1.Columns["igv"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                        gridView1.Columns["Valor Total"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                        gridView1.Columns["Credito"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                        gridView1.GroupRowHeight = 1;
                        gridView1.RowHeight = 1;
                        gridView1.Appearance.Row.FontSizeDelta = 0;
                        gridView1.BestFitColumns();
                    }
                    catch
                    {
                        gridControl1.DataSource = null;
                        gridControl1.Refresh();
                    }
                }
            }
        }

        private void ABRIR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (gridView1.SelectedRowsCount > 0)
            {
                var Context = new LiderEntities();
                var frmOpenComprobante = new Elementos.frmComprobante();
                string NumeroComprobante = gridView1.GetFocusedRowCellValue("Comprobante").ToString();
                string PKDocumento = Context.DOCUMENTOes.Where(p => p.Generado.Equals(NumeroComprobante)).Select(a => a.Documento1).FirstOrDefault();
                string PKTipoDoc = Context.DOCUMENTOes.Where(p => p.Generado.Equals(NumeroComprobante)).Select(a => a.TipoDoc).FirstOrDefault();
                string CodigoVendedor = Context.DOCUMENTOes.Where(p => p.Generado.Equals(NumeroComprobante)).Select(a => a.Personal).FirstOrDefault();
                string NombreVendedor = Context.DOCUMENTOes.Where(p => p.Generado.Equals(NumeroComprobante)).Select(a => a.npersonal).FirstOrDefault();
                string CodigoCliente = Context.DOCUMENTOes.Where(p => p.Generado.Equals(NumeroComprobante)).Select(a => a.Cliente).FirstOrDefault();
                string NombreCliente = Context.DOCUMENTOes.Where(p => p.Generado.Equals(NumeroComprobante)).Select(a => a.rsocial.Trim()).FirstOrDefault();
                string DocumentoCliente = Context.Vva_Cliente.Where(p => p.Codigo.Equals(CodigoCliente)).Select(a => a.Documento.Trim()).FirstOrDefault();
                string DireccionCliente = Context.DOCUMENTOes.Where(p => p.Generado.Equals(NumeroComprobante)).Select(a => a.direccion).FirstOrDefault();
                string ZonaCliente = proceso.ConsultarCadena("descripcion", "Zona", "Zona = (select zona from Vva_Cliente where Codigo = '" + CodigoCliente + "')");
                string DistritoCliente = proceso.ConsultarCadena("descrip", "Distrito", "iddistrito = (select distllegada from Documento where Generado = '" + NumeroComprobante + "')");
                string ProvinciaCliente = proceso.ConsultarCadena("descrip", "provincia", " idprovincia = (select idprovincia from Distrito where iddistrito = (select distllegada from Documento where Generado = '" + NumeroComprobante + "'))");
                string Gestion = Context.DOCUMENTOes.Where(p => p.Generado.Equals(NumeroComprobante)).Select(a => a.gestion).FirstOrDefault();
                bool Credito = proceso.ConsultarVerdad("Credito", "Vva_Cp", "Comprobante = '" + NumeroComprobante + "'");
                string FormaPago = proceso.ConsultarCadena("FormaPago", "Pedido", "Pedido = (select top(1)Pedido from documento where generado = '" + NumeroComprobante + "')");
                string FechaEmision = Convert.ToDateTime(proceso.ConsultarCadena("Fecha", "Vva_Cp", "Comprobante = '" + NumeroComprobante + "'")).ToString("dd/MM/yyyy");
                try
                {
                    frmOpenComprobante.txtcdDocumento.Text = NumeroComprobante;
                    frmOpenComprobante.txtcdVendedor.Text = CodigoVendedor;
                    frmOpenComprobante.txtnmVendedor.Text = NombreVendedor;
                    frmOpenComprobante.txtcdCLiente.Text = CodigoCliente;
                    frmOpenComprobante.txtnmCliente.Text = NombreCliente;
                    frmOpenComprobante.txtdocCliente.Text = DocumentoCliente;
                    frmOpenComprobante.txtnmDireccion.EditValue = DireccionCliente;
                    frmOpenComprobante.txtnmZona.EditValue = ZonaCliente;
                    frmOpenComprobante.txtcdZona.EditValue = proceso.ConsultarCadena("Zona", "Vva_Cliente", "Codigo = '" + CodigoCliente + "'");
                    frmOpenComprobante.txtnmDistrito.EditValue = DistritoCliente;
                    frmOpenComprobante.txtcdDistrito.EditValue = proceso.ConsultarCadena("IDDistrito", "Vva_Cliente", "Codigo = '" + CodigoCliente + "'");
                    frmOpenComprobante.txtnmProvincia.EditValue = ProvinciaCliente;
                    frmOpenComprobante.txtcdProvincia.EditValue = proceso.ConsultarCadena("idprovincia", "Distrito", "iddistrito = (select IDDistrito from Vva_Cliente where codigo = '" + CodigoCliente + "')");
                    frmOpenComprobante.txtcdGestion.Text = Gestion;
                    frmOpenComprobante.dateEmision.EditValue = DateTime.Parse(FechaEmision);
                    frmOpenComprobante.dateEntrega.EditValue = DateTime.Parse(FechaEmision).AddDays(1);
                    frmOpenComprobante.btnCredito.Checked = Credito == true ? true : false;
                    frmOpenComprobante.txtformaPago.Text = proceso.ConsultarCadena("Descripcion", "FormaPago", "FormaPago = '" + FormaPago + "'");
                    frmOpenComprobante.CodigoFP.Text = FormaPago;
                    var Items = Context.DETADOCs.Where(w => w.Documento == PKDocumento.Trim() && w.TipoDoc == PKTipoDoc.Trim()).ToList();
                    foreach (var Fila in Items)
                    {
                        string Codigo = Fila.Producto;
                        string Descripcion = Context.PRODUCTOes.Where(w => w.Producto1 == Fila.Producto).Select(x => x.Descripcion).FirstOrDefault().Trim();
                        decimal Cantidad = Convert.ToDecimal(Fila.Cantidad);
                        string Unidad = Context.PRODUCTOes.Where(w => w.Producto1 == Fila.Producto).Select(x => x.UniMed).FirstOrDefault().Trim();
                        decimal PrecioUnitario = Convert.ToDecimal(Fila.PrecioUnitario);
                        decimal PrecioNeto = Convert.ToDecimal(Fila.PrecioNeto);
                        decimal Descuento = Convert.ToDecimal(Fila.Descuento);
                        decimal Recargo = Convert.ToDecimal(Fila.Recargo);
                        bool Bonificacion = Convert.ToBoolean(Fila.Bonif);
                        bool Afecto = Convert.ToBoolean(Fila.Afecto);
                        int IdBonif = Convert.ToInt32(Fila.IDBonificacion) is DBNull ? 0 : Convert.ToInt32(Fila.IDBonificacion);
                        int TipoPrecio = Convert.ToInt32(Fila.TipoPrecio) is DBNull ? 0 : Convert.ToInt32(Fila.TipoPrecio);

                        frmOpenComprobante.dataGridView1.Rows.Add(Codigo, Descripcion, Cantidad, Cantidad, Unidad, TipoPrecio, PrecioUnitario, PrecioNeto,
                            (Cantidad * PrecioNeto), Descuento, Recargo, Bonificacion, Credito, Afecto, IdBonif);
                        frmOpenComprobante.dataGridView1.ReadOnly = true;
                    }

                    frmOpenComprobante.txtValorDescuento.EditValue = (from detalle in frmOpenComprobante.dataGridView1.Rows.Cast<DataGridViewRow>()
                                                                      select (Convert.ToDecimal(detalle.Cells["Descuento"].Value))).Sum().ToString("N2");
                    frmOpenComprobante.txtValorRecargo.EditValue = (from detalle in frmOpenComprobante.dataGridView1.Rows.Cast<DataGridViewRow>()
                                                                    select (Convert.ToDecimal(detalle.Cells["Recargo"].Value))).Sum().ToString("N2");
                    frmOpenComprobante.txtValorSubtotal.EditValue = (from detalle in frmOpenComprobante.dataGridView1.Rows.Cast<DataGridViewRow>()
                                                                     select (Convert.ToDecimal(detalle.Cells["Cantidad"].Value) * Convert.ToDecimal(detalle.Cells["PrecioUnitario"].Value))).Sum().ToString("N2");
                    frmOpenComprobante.txtValorImporteTotal.EditValue = Context.DOCUMENTOes.Where(x => x.Generado == NumeroComprobante).Select(y => y.total).FirstOrDefault();
                    frmOpenComprobante.txtValorImpuesto.EditValue = Context.DOCUMENTOes.Where(x => x.Generado == NumeroComprobante).Select(y => y.igv).FirstOrDefault();
                    frmOpenComprobante.txtValorInafecto.EditValue = Context.DOCUMENTOes.Where(x => x.Generado == NumeroComprobante).Select(y => y.inafecto).FirstOrDefault();
                    frmOpenComprobante.txtValorAfecto.EditValue = Context.DOCUMENTOes.Where(x => x.Generado == NumeroComprobante).Select(y => y.afecto).FirstOrDefault();
                    frmOpenComprobante.StartPosition = FormStartPosition.CenterScreen;
                    //frmpedido.Existe = false;
                    frmOpenComprobante.Show();
                }
                catch (Exception t)
                {
                    MessageBox.Show(t.Message);
                }
            }
        }

        private void NUEVO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Elementos.frmComprobante frmcomprobante = new frmComprobante();
            frmcomprobante.StartPosition = FormStartPosition.CenterScreen;
            frmcomprobante.Show();
        }

        private void ANULAR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frmmensage = new Elementos.frmMsg();
            frmmensage.dataGridView1.Columns[0].HeaderText = "Comprobante";
            frmmensage.dataGridView1.Columns[1].HeaderText = "Mensage";
            frmmensage.dataGridView1.Columns[2].HeaderText = string.Empty;
            frmmensage.dataGridView1.Columns[3].HeaderText = string.Empty;
            frmmensage.dataGridView1.Columns[0].Width = 100;
            using (var Context = new LiderEntities())
            {
                if (gridView1.SelectedRowsCount > 0)
                {
                    var proceso = new Libreria.Proceso();
                    if (proceso.MensagePregunta("¿Desea Continuar?") == DialogResult.Yes)
                    {
                        foreach (var fila in gridView1.GetSelectedRows())
                        {
                            string NumeroComprobante = Convert.ToString(gridView1.GetRowCellValue(fila, "Comprobante")).Trim();
                            string Estado = Context.DOCUMENTOes.Where(x => x.Generado == NumeroComprobante).Select(p => p.Estado).FirstOrDefault().Trim();
                            if (Estado != "A")
                            {
                                var Comprobante = (from c in Context.DOCUMENTOes where c.Generado == NumeroComprobante select c).FirstOrDefault();
                                Comprobante.Estado = "A";
                                frmmensage.dataGridView1.Rows.Add(NumeroComprobante, "Comprobante ha sido anulado con exito.");
                            }
                            else
                            {
                                frmmensage.dataGridView1.Rows.Add(NumeroComprobante, "Comprobante se encuentra anulado.");
                            }
                        }
                        Context.SaveChanges();
                        frmmensage.Show();
                        Refrescar();
                    }
                }
            }
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
                k.DataSource = Context.Database.SqlQuery<string>(Libreria.Constante.Mapa_View + "'Vva_Cp'").ToList();
                filtro.pasar += new Filtros.frmFiltros.variables(condicion);
                filtro.StartPosition = FormStartPosition.CenterScreen;
                foreach (var fila in Context.Filtroes.Where(w => w.tabla.Equals(tabla)).ToList())
                {
                    filtro.dataGridView1.Rows.Add(fila.campo, fila.condicion, fila.valor, fila.union);
                }
                filtro.entidad = tabla;
                filtro.ShowDialog();
            }
        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            popupMenu1.ShowPopup(gridControl1.PointToScreen(e.Point));
        }
    }
}