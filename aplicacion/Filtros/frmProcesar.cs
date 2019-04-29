using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace xtraForm.Filtros
{
    public partial class frmProcesar : DevExpress.XtraEditors.XtraForm
    {
        Libreria.Proceso proceso = new Libreria.Proceso();
        Libreria.Entidad entidad = new Libreria.Entidad();
        Libreria.maestroBonif_Reglas ejecutar = new Libreria.maestroBonif_Reglas();
        public frmProcesar()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (proceso.MensageError("desea cancelar") == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            List<string> lista = new List<string>();
            foreach (var fila in gridView1.GetSelectedRows())
            {
                lista.Add("'" + gridView1.GetDataRow(fila)["Codigo"].ToString() + "'");
            }
            string codigos = string.Join(",", lista.ToArray());
            //
            entidad.fecha = Convert.ToDateTime(FechaProceso.EditValue).ToString("yyyyMMdd");
            if (FechaProceso.EditValue != null)
            {
                Modulos.Elementos.frmMsg frmmensage = new Modulos.Elementos.frmMsg();
                if (proceso.MensagePregunta("Desea Continua") == DialogResult.Yes)
                {
                    if (gridView1.SelectedRowsCount > 0)
                    {
                        splashScreenManager1.SplashFormStartPosition = SplashFormStartPosition.Default;
                        frmmensage.Show();
                        splashScreenManager1.ShowWaitForm();
                        //evento # 01
                        using (var Context = new Model.LiderAppEntities())
                        {
                            Context.Database.SqlQuery<string>("exec sp_stock_sistema @Fecha,2", DateTime.Now.Date.ToString("yyyyMMdd"));
                            Context.Database.SqlQuery<string>("exec sp_stock_sistema_web @Fecha,2", DateTime.Now.Date.ToString("yyyyMMdd"));
                        }
                        ejecutar.horasBonificacion();
                        ejecutar.deleteBonificacion(entidad.fecha);
                        //evento # 02
                        var bonificacion = proceso.ConsultarTabla_("Bonificacion", "(Activo = 1) AND ('" + entidad.fecha + "' >= Desde AND '" + entidad.fecha + "' <= Hasta)");
                        if (bonificacion.Rows.Count != 0)
                        {
                            foreach (DataRow drb in bonificacion.Rows)
                            {
                                entidad.existe = false;
                                entidad.idbonificacion = Convert.ToInt32(drb["PKID"]);
                                entidad.codigoregalo = drb["cdProductoRegalo"].ToString();
                                entidad.cantidadminima = Convert.ToDecimal(drb["CantidadMinima"]);
                                entidad.cantidadmaxima = Convert.ToInt32(drb["CantidadMaxima"]);
                                entidad.cantidadobsequio = Convert.ToInt32(drb["CantidadRegalo"]);
                                entidad.cantidadmaximacliente = Convert.ToInt32(drb["CantidadMaximaPorCliente"]);
                                entidad.cantidadstock = Convert.ToInt32(drb["Stock"]);
                                entidad.cantidadstockentregado = Convert.ToInt32(drb["StockEntregado"]);
                                entidad.exclusion = Convert.ToBoolean(drb["TieneExclusion"]);
                                entidad.codigoexclusion = Convert.ToInt32(drb["IDBonifcacionExcluida"]);
                                entidad.tipomecanica = Convert.ToInt32(drb["TipoMecanica"]);
                                entidad.idasociado = proceso.ConsultarEntero("IDAsociado", "ItemBonificacion", "IDBonificacion = " + entidad.idbonificacion);
                                entidad.codigoasociado = proceso.ConsultarCadena("Codigo", "TipoAsociado", "PKID = " + entidad.idasociado);
                                if (entidad.idasociado == 4)
                                {
                                    if (entidad.tipomecanica == 1)
                                    {
                                        entidad.table = proceso.EvaluarBonificacion(
                                                        @"
                                                    (dbo.Vva_Pedido.FechaEmision = '" + entidad.fecha + @"') AND
                                                    (dbo.Producto." + entidad.codigoasociado + @" in (SELECT cdProductoColeccion
                                                                           FROM dbo.ItemBonificacion
                                                                           WHERE (IDBonificacion = " + entidad.idbonificacion + @"))) AND
                                                    ( (dbo.Vva_Pedido.IDVend IN (" + codigos + @"))) AND
                                                    (dbo.Vva_Pedido.Procesado = 0)  AND (dbo.Vva_Pedido.Bajado is null)
                                                    ",
                                                        @"
                                                    (SUM (dbo.Vva_ItemPedido.Cantidad) >= " + entidad.cantidadminima + ")");
                                        entidad.suma = ((int)(from R in entidad.table.AsEnumerable() select Convert.ToDecimal(R["Cantidad"])).Sum() / entidad.cantidadminima) * entidad.cantidadobsequio;
                                        if (proceso.ExistenciaStock(entidad.codigoregalo, 0, entidad.suma))
                                        {
                                            foreach (DataRow F00 in entidad.table.Rows)
                                            {
                                                entidad.codigopedido = F00["NrPedido"].ToString();
                                                entidad.cantidadvendida = Convert.ToDecimal(F00["Cantidad"].ToString());
                                                entidad.cantidadtotalregalo = (int)(entidad.cantidadvendida / entidad.cantidadminima) * entidad.cantidadobsequio;
                                                if (!entidad.exclusion)
                                                {
                                                    if (entidad.cantidadmaximacliente > 0 && entidad.cantidadtotalregalo <= entidad.cantidadmaximacliente)
                                                    {
                                                        ejecutar.insertObsequio(entidad.idbonificacion, entidad.codigopedido, entidad.codigoregalo, entidad.cantidadtotalregalo);
                                                    }
                                                    else if (entidad.cantidadmaximacliente > 0 && entidad.cantidadtotalregalo > entidad.cantidadmaximacliente)
                                                    {
                                                        ejecutar.insertObsequio(entidad.idbonificacion, entidad.codigopedido, entidad.codigoregalo, entidad.cantidadmaximacliente);
                                                    }
                                                    else
                                                    {
                                                        ejecutar.insertObsequio(entidad.idbonificacion, entidad.codigopedido, entidad.codigoregalo, entidad.cantidadtotalregalo);
                                                    }
                                                }
                                                else
                                                {
                                                    foreach (DataRow F01 in proceso.ConsultarTabla_("DETPEDIDO", "pedido = '" + entidad.codigopedido + "'").Rows)
                                                    {
                                                        if (Convert.ToInt32(F01["IDBonificacion"] is DBNull ? 0 : F01["IDBonificacion"]) > 0)
                                                        {
                                                            if (entidad.codigoexclusion == Convert.ToInt32(F01["IDBonificacion"] is DBNull ? 0 : F01["IDBonificacion"]))
                                                            {
                                                                entidad.existe = true;
                                                            }
                                                        }
                                                    }
                                                    if (!entidad.existe)
                                                    {
                                                        if (entidad.cantidadmaximacliente > 0 && entidad.cantidadtotalregalo <= entidad.cantidadmaximacliente)
                                                        {
                                                            ejecutar.insertObsequio(entidad.idbonificacion, entidad.codigopedido, entidad.codigoregalo, entidad.cantidadtotalregalo);
                                                        }
                                                        else if (entidad.cantidadmaximacliente > 0 && entidad.cantidadtotalregalo > entidad.cantidadmaximacliente)
                                                        {
                                                            ejecutar.insertObsequio(entidad.idbonificacion, entidad.codigopedido, entidad.codigoregalo, entidad.cantidadmaximacliente);
                                                        }
                                                        else
                                                        {
                                                            ejecutar.insertObsequio(entidad.idbonificacion, entidad.codigopedido, entidad.codigoregalo, entidad.cantidadtotalregalo);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (entidad.suma != 0)
                                            {
                                                frmmensage.dataGridView1.Rows.Add(entidad.codigoregalo, proceso.ConsultarCadena("Descripcion", "producto", "producto = '" + entidad.codigoregalo + "'"),
                                                entidad.suma, proceso.ConsultarCadena("StockAc", "Producto", "producto = '" + entidad.codigoregalo + "'"));
                                            }
                                        }
                                    }
                                    if (entidad.tipomecanica == 2)
                                    {
                                        entidad.table = proceso.EvaluarBonificacion(
                                                       @"
                                                    (dbo.Vva_Pedido.FechaEmision = '" + entidad.fecha + @"') AND
                                                    (dbo.Producto." + entidad.codigoasociado + @" in (SELECT cdProductoColeccion
                                                                           FROM dbo.ItemBonificacion
                                                                           WHERE (IDBonificacion = " + entidad.idbonificacion + @"))) AND
                                                    ( (dbo.Vva_Pedido.IDVend IN (" + codigos + @"))) AND
                                                    (dbo.Vva_Pedido.Procesado = 0) AND (dbo.Vva_Pedido.Bajado is null)
                                                    ",
                                                       @"(SUM (dbo.Vva_ItemPedido.Cantidad) >= " + entidad.cantidadminima + ") " +
                                                       "and (SUM (dbo.Vva_ItemPedido.Cantidad) < " + entidad.cantidadmaxima + ")");
                                        entidad.suma = ((int)(from R in entidad.table.AsEnumerable() select Convert.ToDecimal(R["Cantidad"])).Sum() / entidad.cantidadminima) * entidad.cantidadobsequio;
                                        if (proceso.ExistenciaStock(entidad.codigoregalo, 0, entidad.suma))
                                        {
                                            foreach (DataRow F00 in entidad.table.Rows)
                                            {
                                                entidad.codigopedido = F00["NrPedido"].ToString();
                                                entidad.cantidadvendida = Convert.ToDecimal(F00["Cantidad"].ToString());
                                                entidad.cantidadtotalregalo = (int)(entidad.cantidadvendida / entidad.cantidadminima) * entidad.cantidadobsequio;
                                                if (!entidad.exclusion)
                                                {
                                                    if (entidad.cantidadmaximacliente > 0 && entidad.cantidadtotalregalo <= entidad.cantidadmaximacliente)
                                                    {
                                                        ejecutar.insertObsequio(entidad.idbonificacion, entidad.codigopedido, entidad.codigoregalo, entidad.cantidadtotalregalo);
                                                    }
                                                    else if (entidad.cantidadmaximacliente > 0 && entidad.cantidadtotalregalo > entidad.cantidadmaximacliente)
                                                    {
                                                        ejecutar.insertObsequio(entidad.idbonificacion, entidad.codigopedido, entidad.codigoregalo, entidad.cantidadmaximacliente);
                                                    }
                                                    else
                                                    {
                                                        ejecutar.insertObsequio(entidad.idbonificacion, entidad.codigopedido, entidad.codigoregalo, entidad.cantidadtotalregalo);
                                                    }
                                                }
                                                else
                                                {
                                                    foreach (DataRow F01 in proceso.ConsultarTabla_("DETPEDIDO", "pedido = '" + entidad.codigopedido + "'").Rows)
                                                    {
                                                        if (Convert.ToInt32(F01["IDBonificacion"] is DBNull ? 0 : F01["IDBonificacion"]) > 0)
                                                        {
                                                            if (entidad.codigoexclusion == Convert.ToInt32(F01["IDBonificacion"] is DBNull ? 0 : F01["IDBonificacion"]))
                                                            {
                                                                entidad.existe = true;
                                                            }
                                                        }
                                                    }
                                                    if (!entidad.existe)
                                                    {
                                                        if (entidad.cantidadmaximacliente > 0 && entidad.cantidadtotalregalo <= entidad.cantidadmaximacliente)
                                                        {
                                                            ejecutar.insertObsequio(entidad.idbonificacion, entidad.codigopedido, entidad.codigoregalo, entidad.cantidadtotalregalo);
                                                        }
                                                        else if (entidad.cantidadmaximacliente > 0 && entidad.cantidadtotalregalo > entidad.cantidadmaximacliente)
                                                        {
                                                            ejecutar.insertObsequio(entidad.idbonificacion, entidad.codigopedido, entidad.codigoregalo, entidad.cantidadmaximacliente);
                                                        }
                                                        else
                                                        {
                                                            ejecutar.insertObsequio(entidad.idbonificacion, entidad.codigopedido, entidad.codigoregalo, entidad.cantidadtotalregalo);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (entidad.suma != 0)
                                            {
                                                frmmensage.dataGridView1.Rows.Add(entidad.codigoregalo, proceso.ConsultarCadena("Descripcion", "producto", "producto = '" + entidad.codigoregalo + "'"),
                                                entidad.suma, proceso.ConsultarCadena("StockAc", "Producto", "producto = '" + entidad.codigoregalo + "'"));
                                            }
                                        }
                                    }
                                    if (entidad.tipomecanica == 3)
                                    {
                                        proceso.consultar(@"
                                        SELECT
                                            Vva_Pedido.NrPedido, SUM (Vva_ItemPedido.Cantidad * Vva_ItemPedido.Precio) AS Cantidad
                                        FROM
                                            Vva_Pedido INNER JOIN Vva_ItemPedido ON Vva_Pedido.NrPedido = Vva_ItemPedido.NrPedido INNER JOIN PRODUCTO
                                            ON Vva_ItemPedido.IDProducto = PRODUCTO.Producto
                                        WHERE
                                            (Vva_Pedido.FechaEmision = '" + entidad.fecha + "') AND PRODUCTO." + entidad.codigoasociado + @" in (SELECT cdProductoColeccion
                                            FROM ItemBonificacion WHERE (IDBonificacion = " + entidad.idbonificacion + @")) AND ( (Vva_Pedido.IDVend IN (" + codigos + @"))) AND
                                            (Vva_Pedido.Procesado = 0)  AND (dbo.Vva_Pedido.Bajado is null)
                                        GROUP BY Vva_Pedido.NrPedido
                                        HAVING
                                        (SUM (Vva_ItemPedido.Cantidad * Vva_ItemPedido.Precio) >= " + entidad.cantidadminima + ")", "Soles");
                                        entidad.table = proceso.ds.Tables["Soles"];
                                        entidad.suma = ((int)(from R in entidad.table.AsEnumerable() select Convert.ToDecimal(R["Cantidad"])).Sum() / entidad.cantidadminima) * entidad.cantidadobsequio;
                                        if (proceso.ExistenciaStock(entidad.codigoregalo, 0, entidad.suma))
                                        {
                                            foreach (DataRow F00 in entidad.table.Rows)
                                            {
                                                entidad.codigopedido = F00["NrPedido"].ToString();
                                                entidad.cantidadvendida = Convert.ToDecimal(F00["Cantidad"].ToString());
                                                entidad.cantidadtotalregalo = (int)(entidad.cantidadvendida / entidad.cantidadminima) * entidad.cantidadobsequio;

                                                if (!entidad.exclusion)
                                                {
                                                    if (entidad.cantidadmaximacliente > 0 && entidad.cantidadtotalregalo <= entidad.cantidadmaximacliente)
                                                    {
                                                        ejecutar.insertObsequio(entidad.idbonificacion, entidad.codigopedido, entidad.codigoregalo, entidad.cantidadtotalregalo);
                                                    }
                                                    else if (entidad.cantidadmaximacliente > 0 && entidad.cantidadtotalregalo > entidad.cantidadmaximacliente)
                                                    {
                                                        ejecutar.insertObsequio(entidad.idbonificacion, entidad.codigopedido, entidad.codigoregalo, entidad.cantidadmaximacliente);
                                                    }
                                                    else
                                                    {
                                                        ejecutar.insertObsequio(entidad.idbonificacion, entidad.codigopedido, entidad.codigoregalo, entidad.cantidadtotalregalo);
                                                    }
                                                }
                                                else
                                                {
                                                    foreach (DataRow F01 in proceso.ConsultarTabla_("DETPEDIDO", "pedido = '" + entidad.codigopedido + "'").Rows)
                                                    {
                                                        if (Convert.ToInt32(F01["IDBonificacion"] is DBNull ? 0 : F01["IDBonificacion"]) > 0)
                                                        {
                                                            if (entidad.codigoexclusion == Convert.ToInt32(F01["IDBonificacion"] is DBNull ? 0 : F01["IDBonificacion"]))
                                                            {
                                                                entidad.existe = true;
                                                            }
                                                        }
                                                    }
                                                    if (!entidad.existe)
                                                    {
                                                        if (entidad.cantidadmaximacliente > 0 && entidad.cantidadtotalregalo <= entidad.cantidadmaximacliente)
                                                        {
                                                            ejecutar.insertObsequio(entidad.idbonificacion, entidad.codigopedido, entidad.codigoregalo, entidad.cantidadtotalregalo);
                                                        }
                                                        else if (entidad.cantidadmaximacliente > 0 && entidad.cantidadtotalregalo > entidad.cantidadmaximacliente)
                                                        {
                                                            ejecutar.insertObsequio(entidad.idbonificacion, entidad.codigopedido, entidad.codigoregalo, entidad.cantidadmaximacliente);
                                                        }
                                                        else
                                                        {
                                                            ejecutar.insertObsequio(entidad.idbonificacion, entidad.codigopedido, entidad.codigoregalo, entidad.cantidadtotalregalo);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (entidad.suma != 0)
                                            {
                                                frmmensage.dataGridView1.Rows.Add(entidad.codigoregalo, proceso.ConsultarCadena("Descripcion", "producto", "producto = '" + entidad.codigoregalo + "'"),
                                                entidad.suma, proceso.ConsultarCadena("StockAc", "Producto", "producto = '" + entidad.codigoregalo + "'"));
                                            }
                                        }
                                    }
                                    if (entidad.tipomecanica == 4)
                                    {
                                        proceso.consultar(@"
                                         SELECT
                                            Vva_Pedido.NrPedido,
                                            SUM (Vva_ItemPedido.Cantidad * Vva_ItemPedido.Precio) AS Cantidad
                                        FROM
                                            Vva_Pedido INNER JOIN Vva_ItemPedido ON Vva_Pedido.NrPedido = Vva_ItemPedido.NrPedido INNER JOIN PRODUCTO
                                            ON Vva_ItemPedido.IDProducto = PRODUCTO.Producto
                                        WHERE
                                            (Vva_Pedido.FechaEmision = '" + entidad.fecha + "') AND PRODUCTO." + entidad.codigoasociado + @" in (SELECT cdProductoColeccion
                                            FROM ItemBonificacion WHERE (IDBonificacion = " + entidad.idbonificacion + @")) AND ( (Vva_Pedido.IDVend IN (" + codigos + @"))) AND
                                            (Vva_Pedido.Procesado = 0)  AND (dbo.Vva_Pedido.Bajado is null)
                                        GROUP BY Vva_Pedido.NrPedido
                                        HAVING
                                        (SUM (Vva_ItemPedido.Cantidad * Vva_ItemPedido.Precio) >= " + entidad.cantidadminima + ") and (SUM (Vva_ItemPedido.Cantidad * Vva_ItemPedido.Precio) < " + entidad.cantidadmaxima + ")", "Soles");
                                        entidad.table = proceso.ds.Tables["Soles"];
                                        entidad.suma = ((int)(from R in entidad.table.AsEnumerable() select Convert.ToDecimal(R["Cantidad"])).Sum() / entidad.cantidadminima) * entidad.cantidadobsequio;
                                        if (proceso.ExistenciaStock(entidad.codigoregalo, 0, entidad.suma))
                                        {
                                            foreach (DataRow F00 in entidad.table.Rows)
                                            {
                                                entidad.codigopedido = F00["NrPedido"].ToString();
                                                entidad.cantidadvendida = Convert.ToDecimal(F00["Cantidad"].ToString());
                                                entidad.cantidadtotalregalo = (int)(entidad.cantidadvendida / entidad.cantidadminima) * entidad.cantidadobsequio;
                                                if (!entidad.exclusion)
                                                {
                                                    if (entidad.cantidadmaximacliente > 0 && entidad.cantidadtotalregalo <= entidad.cantidadmaximacliente)
                                                    {
                                                        ejecutar.insertObsequio(entidad.idbonificacion, entidad.codigopedido, entidad.codigoregalo, entidad.cantidadtotalregalo);
                                                    }
                                                    else if (entidad.cantidadmaximacliente > 0 && entidad.cantidadtotalregalo > entidad.cantidadmaximacliente)
                                                    {
                                                        ejecutar.insertObsequio(entidad.idbonificacion, entidad.codigopedido, entidad.codigoregalo, entidad.cantidadmaximacliente);
                                                    }
                                                    else
                                                    {
                                                        ejecutar.insertObsequio(entidad.idbonificacion, entidad.codigopedido, entidad.codigoregalo, entidad.cantidadtotalregalo);
                                                    }
                                                }
                                                else
                                                {
                                                    foreach (DataRow F01 in proceso.ConsultarTabla_("DETPEDIDO", "pedido = '" + entidad.codigopedido + "'").Rows)
                                                    {
                                                        if (Convert.ToInt32(F01["IDBonificacion"] is DBNull ? 0 : F01["IDBonificacion"]) > 0)
                                                        {
                                                            if (entidad.codigoexclusion == Convert.ToInt32(F01["IDBonificacion"] is DBNull ? 0 : F01["IDBonificacion"]))
                                                            {
                                                                entidad.existe = true;
                                                            }
                                                        }
                                                    }
                                                    if (!entidad.existe)
                                                    {
                                                        if (entidad.cantidadmaximacliente > 0 && entidad.cantidadtotalregalo <= entidad.cantidadmaximacliente)
                                                        {
                                                            ejecutar.insertObsequio(entidad.idbonificacion, entidad.codigopedido, entidad.codigoregalo, entidad.cantidadtotalregalo);
                                                        }
                                                        else if (entidad.cantidadmaximacliente > 0 && entidad.cantidadtotalregalo > entidad.cantidadmaximacliente)
                                                        {
                                                            ejecutar.insertObsequio(entidad.idbonificacion, entidad.codigopedido, entidad.codigoregalo, entidad.cantidadmaximacliente);
                                                        }
                                                        else
                                                        {
                                                            ejecutar.insertObsequio(entidad.idbonificacion, entidad.codigopedido, entidad.codigoregalo, entidad.cantidadtotalregalo);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (entidad.suma != 0)
                                            {
                                                frmmensage.dataGridView1.Rows.Add(entidad.codigoregalo, proceso.ConsultarCadena("Descripcion", "producto", "producto = '" + entidad.codigoregalo + "'"),
                                                                 entidad.suma, proceso.ConsultarCadena("StockAc", "Producto", "producto = '" + entidad.codigoregalo + "'"));
                                            }
                                        }
                                    }
                                }
                            }
                            splashScreenManager1.CloseWaitForm();
                            if (frmmensage.dataGridView1.Rows.Count == 0)
                            {
                                frmmensage.dataGridView1.Rows.Add(string.Empty, "!! PROMOCIONES INSERTADAS CON EXITO !!", string.Empty, string.Empty);
                                this.Close();
                            }
                        }
                        else
                        {
                            splashScreenManager1.CloseWaitForm();
                            frmmensage.dataGridView1.Rows.Add(string.Empty, " !! NO EXISTEN REGLAS DESIGNADAS PARA ESTE DIA !!  ", string.Empty, string.Empty);
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No existen vendedores seleccionados");
                    }
                    using (var Context = new Model.LiderAppEntities())
                    {
                        Context.Database.SqlQuery<string>("exec sp_stock_sistema @Fecha,2", DateTime.Now.Date.ToString("yyyyMMdd"));
                        Context.Database.SqlQuery<string>("exec sp_stock_sistema_web @Fecha,2", DateTime.Now.Date.ToString("yyyyMMdd"));
                    }

                }
                //ejecutar.Descargar_Pedidos_Web(entidad.fecha);

            }
            else
            {
                MessageBox.Show("No existe Fecha para procesar promociones");
            }
        }
    }
}