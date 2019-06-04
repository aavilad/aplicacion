using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xtraForm.Model;

namespace xtraForm.Modulos.Distribucion
{
    public partial class frmRutas : DevExpress.XtraEditors.XtraForm
    {
        public string Tabla;
        public string NModulo;
        List<string> Lista;
        public frmRutas()
        {
            InitializeComponent();
        }

        private void GridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            MenuPrincipal.ShowPopup(gridControl1.PointToScreen(e.Point));
        }
        void Refrescar()
        {
            using (var CTX = new LiderEntities())
            {
                var FiltroDetalle = CTX.Filtroes.Where(w => w.tabla == Tabla).OrderBy(o => o.Orden).ToList();
                Lista = new List<string>();
                Lista.Clear();
                foreach (var X in FiltroDetalle)
                {
                    string Campo = X.campo;
                    string Condicion = X.condicion;
                    string Valor = X.valor;
                    string Operador = X.union;
                    Lista.Add(Tabla + "." + "[" + Campo + "]" + Condicion + "'" + Valor + "'" + Operador);
                }
                Condicion(string.Join(" ", Lista.ToArray()));
            }
        }
        void Condicion(string cadena)
        {
            using (var CTX = new LiderEntities())
            {
                var Rutina = new Libreria.Rutina();
                string Query = Convert.ToString(CTX.VistaAdministrativas.Where(x => x.IDModulo == (CTX.Moduloes.Where(a => a.Nombre == NModulo).Select(b => b.PKID)).FirstOrDefault()).Select(a => a.Vista.Trim()).FirstOrDefault());
                try
                {
                    gridControl1.DataSource = null;
                    gridView1.Columns.Clear();
                    if (cadena.Length == 0)
                    {
                        Rutina.consultar(Query, Tabla);
                        gridControl1.DataSource = Rutina.ds.Tables[Tabla];
                        gridView1.BestFitColumns();
                    }
                    else
                    {
                        Rutina.consultar(Query + " having " + cadena, Tabla);
                        gridControl1.DataSource = Rutina.ds.Tables[Tabla];
                        gridView1.BestFitColumns();
                    }
                }
                catch
                {
                    gridControl1.DataSource = null;
                    gridControl1.Refresh();
                }
            }
        }
    }
}