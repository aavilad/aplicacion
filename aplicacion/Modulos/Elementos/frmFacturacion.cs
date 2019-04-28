﻿using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.SqlServer;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            using (var context = new Model.LiderAppEntities())
            {
                SerieFacturas.Properties.ShowHeader = false;
                SerieFacturas.Properties.DisplayMember = "Serie";
                SerieFacturas.Properties.ValueMember = "ID";
                SerieFacturas.Properties.Columns.Add(new LookUpColumnInfo("Detalle", "", 10));
                SerieFacturas.Properties.DataSource =
                    context.DOCTIPO.Where(x => x.codigo == "01").
                    Select(a => new { ID = a.PKID, Serie = a.Serie.Trim(), Detalle = a.Serie.Trim() + ":" + a.Descripcion.Trim() }).ToList();

                SerieBoletas.Properties.ShowHeader = false;
                SerieBoletas.Properties.DisplayMember = "Serie";
                SerieBoletas.Properties.ValueMember = "ID";
                SerieBoletas.Properties.Columns.Add(new LookUpColumnInfo("Detalle", "", 10));
                SerieBoletas.Properties.DataSource =
                    context.DOCTIPO.Where(x => x.codigo == "03").
                    Select(a => new { ID = a.PKID, Serie = a.Serie.Trim(), Detalle = a.Serie.Trim() + ":" + a.Descripcion.Trim() }).ToList();

                Gestion.Properties.ShowHeader = false;
                Gestion.Properties.DisplayMember = "codigo";
                Gestion.Properties.ValueMember = "codigo";
                Gestion.Properties.Columns.Add(new LookUpColumnInfo("codigo", "", 10));
                Gestion.Properties.DataSource = context.Gestion.ToList();
            }


        }

        private void FechaProceso_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void ChVendedor_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            if (flRuta.Checked)
            {
                using (var Context = new Model.LiderAppEntities())
                {
                    gridControl1.DataSource =
                    (from p in Context.RUTAS.AsEnumerable()
                     join q in Context.REPARTO.AsEnumerable() on p.codigo equals q.Ruta
                     where p.Activo.Equals(true) && q.Dia == (int)Convert.ToDateTime(FechaProceso.Value).DayOfWeek
                     select new { Codigo = p.codigo.Trim(), Descripcion = p.descripcion.Trim() }).Distinct().ToList();
                    gridView1.OptionsView.ColumnAutoWidth = false;
                    gridView1.OptionsView.ShowGroupPanel = false;
                    gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
                    gridView1.BestFitColumns();
                    gridView1.OptionsBehavior.Editable = false;
                    gridView1.OptionsBehavior.ReadOnly = true;
                    gridView1.OptionsSelection.MultiSelect = true;
                    gridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
                }
            }
            else if (flVendedor.Checked)
            {
                using (var Context = new Model.LiderAppEntities())
                {
                    gridControl1.DataSource =
                    (from p in Context.Vva_Vendedor.AsEnumerable()
                     join q in Context.FuerzaVentas.AsEnumerable() on p.IDFzaVentas equals q.fzavtas
                     where p.Activo.Equals(true)
                     select new { FzaVentas = q.descrip.Trim(), Codigo = p.Codigo_vendedor.Trim(), Descripcion = p.Nombre_Vendedor.Trim() }).ToList();
                    gridView1.OptionsView.ColumnAutoWidth = false;
                    gridView1.OptionsView.ShowGroupPanel = false;
                    gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
                    gridView1.BestFitColumns();
                    gridView1.OptionsBehavior.Editable = false;
                    gridView1.OptionsBehavior.ReadOnly = true;
                    gridView1.OptionsSelection.MultiSelect = true;
                    gridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
                    gridView1.Columns["FzaVentas"].GroupIndex = 0;
                }
            }
        }

        private void flRuta_CheckedChanged(object sender, EventArgs e)
        {
            if (flRuta.Checked)
            {
                flVendedor.Checked = false;
            }
        }

        private void flVendedor_CheckedChanged(object sender, EventArgs e)
        {
            if (flVendedor.Checked)
            {
                flRuta.Checked = false;
            }
        }

        private void SerieFacturas_EditValueChanged(object sender, EventArgs e)
        {
            using (var Context = new Model.LiderAppEntities())
            {
                FCorrelativo.EditValue = Context.DOCTIPO.Where(x => x.PKID == (int)SerieFacturas.EditValue).Select(s => s.Numero).FirstOrDefault();
                DescripcionF.EditValue = Context.DOCTIPO.Where(x => x.PKID == (int)SerieFacturas.EditValue).Select(s => s.Descripcion).FirstOrDefault();
            }

        }

        private void SerieBoletas_EditValueChanged(object sender, EventArgs e)
        {
            using (var Context = new Model.LiderAppEntities())
            {
                BCorrelativo.EditValue = Context.DOCTIPO.Where(x => x.PKID == (int)SerieBoletas.EditValue).Select(s => s.Numero).FirstOrDefault();
                DescripcionB.EditValue = Context.DOCTIPO.Where(x => x.PKID == (int)SerieBoletas.EditValue).Select(s => s.Descripcion).FirstOrDefault();
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider1.Validate())
            {
                if (gridView1.SelectedRowsCount > 0)
                {
                    GeneraDocumentos();
                }
                else
                {
                    MessageBox.Show("Selecione al menos un item de la lista.");
                }
            }
        }
        void GeneraDocumentos()
        {
            var fecha = Convert.ToDateTime(FechaProceso.Value).ToString();
            if (flRuta.Checked)
            {
                var Campos = new List<string>();
                foreach (var i in gridView1.GetSelectedRows())
                {
                    Campos.Add("'" + Convert.ToString(gridView1.GetRowCellValue(i, "Codigo")) + "'");
                }
                string cadena = string.Join(",", Campos.ToArray());
                using (var Context = new Model.LiderAppEntities())
                {
                    var Pedidos = (from p in Context.Vva_Pedido.AsEnumerable()
                                   join r in Context.REPARTO.AsEnumerable() on p.IDVend equals r.Personal
                                   where p.FechaEmision == Convert.ToDateTime(FechaProceso.Value).Date &&
                                   r.Dia == (int)Convert.ToDateTime(FechaProceso.Value).DayOfWeek &&
                                   cadena.Contains(r.Ruta) && p.Aprobado == true && p.Procesado == true
                                   select new { Pedido = p.NrPedido, Persona = p.TpPersona, Tipo = p.TpDoc }).ToList();
                    foreach (var fila in Pedidos)
                    {
                        //Context.sp_genera_documento(fila.Pedido, Convert.ToInt32(fila.Persona), fila.Tipo);
                    }
                    //var Documentos = (from p in Context.DOCUMENTO.AsEnumerable()
                    //                 join r in Pedidos on p.Pedido equals r.Pedido
                    //                 select new { Pedido = p.Documento1.Trim(), Tipo = p.TipoDoc.Trim() }).ToList();
                    //foreach (var fila in Documentos)
                    //{
                    //    if (fila.Tipo == "B")
                    //    {
                    //        var Numero = Convert.ToInt32(BCorrelativo.EditValue).ToString("D8");
                    //        var serie = Convert.ToString(SerieBoletas.EditValue);
                    //        var NumeroComprobante = serie + Numero;
                    //    }
                       
                    //}
                }
            }
            else if (flVendedor.Checked)
            {
                var Campos = new List<string>();
                foreach (var i in gridView1.GetSelectedRows())
                {
                    Campos.Add("'" + Convert.ToString(gridView1.GetRowCellValue(i, "Codigo")) + "'");
                }
                string cadena = string.Join(",", Campos.ToArray());
                using (var Context = new Model.LiderAppEntities())
                {
                    var Pedidos = (from p in Context.Vva_Pedido.AsEnumerable()
                                   where p.FechaEmision == Convert.ToDateTime(FechaProceso.Value).Date && cadena.Contains(p.IDVend) && p.Aprobado == true && p.Procesado == false
                                   select new { Pedido = p.NrPedido, Persona = p.TpPersona, Tipo = p.TpDoc }).ToList();
                    foreach (var fila in Pedidos)
                    {
                        Context.sp_genera_documento(fila.Pedido, Convert.ToInt32(fila.Persona), fila.Tipo);
                    }
                }
            }
        }

    }
}