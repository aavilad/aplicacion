using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xtraForm.Model;

namespace xtraForm.Libreria
{
    class Pedido_Bonificar
    {
        void Insertar(
            int CantidadMaximaPorCliente, decimal StockDia, int valor, DataGridView Grid, string cdProductoRegalo, string Descripcion, string UniMed, int PKID)
        {
            if (CantidadMaximaPorCliente > 0 && valor <= CantidadMaximaPorCliente)
            {
                if (StockDia >= valor)
                {
                    Grid.Rows.Add(cdProductoRegalo, Descripcion.Trim(), valor, 0, UniMed.Trim(),1, 0.00, 0.00, 0.00, 0.00, 0.00, true, false, true, PKID);
                    Grid.CurrentRow.ReadOnly = true;
                }
                else
                {
                    MessageBox.Show(Constante.SinStock + " Producto = " + cdProductoRegalo);
                }
            }
            else if (CantidadMaximaPorCliente > 0 && valor > CantidadMaximaPorCliente)
            {
                if (StockDia >= valor)
                {
                    Grid.Rows.Add(cdProductoRegalo, Descripcion.Trim(), CantidadMaximaPorCliente, 0, UniMed.Trim(),1, 0.00, 0.00, 0.00, 0.00, 0.00, true, false, true, PKID);
                    Grid.CurrentRow.ReadOnly = true;
                }
                else
                {
                    MessageBox.Show(Constante.SinStock + " Producto = " + cdProductoRegalo);
                }
            }
            else
            {
                if (StockDia >= valor)
                {
                    Grid.Rows.Add(cdProductoRegalo, Descripcion.Trim(), valor, 0, UniMed.Trim(),1, 0.00, 0.00, 0.00, 0.00, 0.00, true, false, true, PKID);
                    Grid.CurrentRow.ReadOnly = true;
                }
                else
                {
                    MessageBox.Show(Constante.SinStock + " Producto = " + cdProductoRegalo);
                }
            }
        }
        public void Evaluar_Bonificacion(DataGridView Grid, string Fecha)
        {
            var Ex = false;
            var x = 0;
            var y = 0;
            var FechaEmision = DateTime.Parse(Fecha);
            var proceso = new Libreria.Rutina();
            using (var CTX = new LiderEntities())
            {
                proceso.Procedimiento("sp_stock_sistema '" + DateTime.Now.Date.ToString("yyyyMMdd") + "',2");
                proceso.Procedimiento("sp_stock_sistema_web '" + DateTime.Now.Date.ToString("yyyyMMdd") + "',2");

                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(System.Int32));
                dt.Columns.Add("Cantidad", typeof(System.Decimal));
                List<string> lista = new List<string>();

                var bonificacion = from bn in CTX.Bonificacions
                                   where bn.Activo == true && FechaEmision >= bn.Desde && FechaEmision < bn.Hasta
                                   select bn;
                foreach (var Prom in bonificacion)
                {
                    lista.Clear();
                    var Product = CTX.PRODUCTOes.Where(w => w.Producto1 == Prom.cdProductoRegalo).FirstOrDefault();
                    var coleccion = from ibn in CTX.ItemBonificacions where ibn.IDBonificacion == Prom.PKID select ibn;
                    foreach (var items in coleccion)
                    {
                        lista.Add(items.cdProductoColeccion);
                    }
                    string Products = string.Join(",", lista.ToArray());
                    var MCantidad = (from pedido in Grid.Rows.Cast<DataGridViewRow>()
                                     where Products.Contains(pedido.Cells["Codigo"].Value.ToString())
                                     select Convert.ToDecimal(pedido.Cells["Cantidad"].Value)).Sum();
                    var MSoles = (from pedido in Grid.Rows.Cast<DataGridViewRow>()
                                  where Products.Contains(pedido.Cells["Codigo"].Value.ToString())
                                  select Convert.ToDecimal(pedido.Cells["Total"].Value)).Sum();
                    foreach (DataGridViewRow Fila in Grid.Rows)
                    {
                        if (Convert.ToInt32(Fila.Cells["IDBonificacion"].Value == string.Empty ? 0 : Fila.Cells["IDBonificacion"].Value) > 0)
                        {
                            if (Prom.IDBonifcacionExcluida == Convert.ToInt32(Fila.Cells["IDBonificacion"].Value))
                            {
                                Ex = true;
                            }
                        }
                    }
                    if (CTX.ItemBonificacions.Where(w => w.IDBonificacion == Prom.PKID).Select(s => s.IDAsociado).FirstOrDefault() == 4)
                    {
                        if (MCantidad != null && MCantidad > 0)
                        {
                            x = (int)(MCantidad / Prom.CantidadMinima) * Prom.CantidadRegalo;
                            switch (Prom.TipoMecanica)
                            {
                                case 1:
                                    if (MCantidad >= Prom.CantidadMinima)
                                    {
                                        if (!Prom.TieneExclusion)
                                        {
                                            Insertar(Prom.CantidadMaximaPorCliente, Product.StockDia, x, Grid, Prom.cdProductoRegalo, Product.Descripcion.Trim(), Product.UniMed.Trim(), Prom.PKID);
                                        }
                                        else
                                        {
                                            if (!Ex)
                                            {
                                                Insertar(Prom.CantidadMaximaPorCliente, Product.StockDia, x, Grid, Prom.cdProductoRegalo, Product.Descripcion.Trim(), Product.UniMed.Trim(), Prom.PKID);
                                            }
                                        }
                                    }
                                    break;
                                case 2:
                                    if (MCantidad >= Prom.CantidadMinima && MCantidad < Prom.CantidadMaxima)
                                    {
                                        if (!Prom.TieneExclusion)
                                        {
                                            Insertar(Prom.CantidadMaximaPorCliente, Product.StockDia, x, Grid, Prom.cdProductoRegalo, Product.Descripcion.Trim(), Product.UniMed.Trim(), Prom.PKID);
                                        }
                                        else
                                        {
                                            if (!Ex)
                                            {
                                                Insertar(Prom.CantidadMaximaPorCliente, Product.StockDia, x, Grid, Prom.cdProductoRegalo, Product.Descripcion.Trim(), Product.UniMed.Trim(), Prom.PKID);
                                            }
                                        }
                                    }
                                    break;
                            }
                        }
                        if (MSoles != null && MSoles > 0)
                        {
                            y = (int)(MSoles / Prom.CantidadMinima) * Prom.CantidadRegalo;
                            switch (Prom.TipoMecanica)
                            {
                                case 3:
                                    if (MSoles >= Prom.CantidadMinima)
                                    {
                                        if (!Prom.TieneExclusion)
                                        {
                                            Insertar(Prom.CantidadMaximaPorCliente, Product.StockDia, y, Grid, Prom.cdProductoRegalo, Product.Descripcion.Trim(), Product.UniMed.Trim(), Prom.PKID);
                                        }
                                        else
                                        {
                                            if (!Ex)
                                            {
                                                Insertar(Prom.CantidadMaximaPorCliente, Product.StockDia, y, Grid, Prom.cdProductoRegalo, Product.Descripcion.Trim(), Product.UniMed.Trim(), Prom.PKID);
                                            }
                                        }
                                    }
                                    break;
                                case 4:
                                    if (MSoles >= Prom.CantidadMinima && MSoles < Prom.CantidadMaxima)
                                    {
                                        if (!Prom.TieneExclusion)
                                        {
                                            Insertar(Prom.CantidadMaximaPorCliente, Product.StockDia, y, Grid, Prom.cdProductoRegalo, Product.Descripcion.Trim(), Product.UniMed.Trim(), Prom.PKID);
                                        }
                                        else
                                        {
                                            if (!Ex)
                                            {
                                                Insertar(Prom.CantidadMaximaPorCliente, Product.StockDia, y, Grid, Prom.cdProductoRegalo, Product.Descripcion.Trim(), Product.UniMed.Trim(), Prom.PKID);
                                            }
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
        }
    }
}
