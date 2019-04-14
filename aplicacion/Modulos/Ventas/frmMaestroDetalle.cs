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

namespace xtraForm.Modulos.Ventas
{
    public partial class frmMaestroDetalle : DevExpress.XtraEditors.XtraForm
    {
        public string fecha;
        Libreria.Proceso proceso = new Libreria.Proceso();
        public frmMaestroDetalle()
        {
            InitializeComponent();
        }

        private void gridControl1_Load(object sender, EventArgs e)
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("[Nombre Proveedor]",typeof(System.String));
            tabla.Columns.Add("[Estado]", typeof(System.String));
            tabla.Columns.Add("[Descripcion Promocional]", typeof(System.String));
            tabla.Columns.Add("[Codigo Pedido]", typeof(System.String));
            tabla.Columns.Add("[Codigo Vendedor]", typeof(System.String));
            tabla.Columns.Add("[Nombre Cliente]", typeof(System.String));
            tabla.Columns.Add("[Producto Regalo]", typeof(System.String));
            tabla.Columns.Add("[Unidad]", typeof(System.String));
            tabla.Columns.Add("[Cantidad Vendida]", typeof(System.String));
            tabla.Columns.Add("[Cantidad Regalo]", typeof(System.String));
            tabla.Rows.Clear();
            proceso.consultar("select pkid,tipomecanica from bonificacion where '" + fecha + "' >= Desde and '" + fecha + "' < Hasta and activo = 1", "bonif");
            foreach (DataRow DR_0 in proceso.ds.Tables["bonif"].Rows)
            {
                proceso.consultar("select * from detallepromocional("+DR_0[1]+","+DR_0[0]+",'"+ fecha + "','"+fecha+"')","detalle");
                foreach (DataRow DR_1 in proceso.ds.Tables["detalle"].Rows)
                    tabla.Rows.Add(DR_1[0], DR_1[1], DR_1[2], DR_1[3], DR_1[4], DR_1[5], DR_1[6], DR_1[7], DR_1[8], DR_1[9]);
            }
            gridControl1.DataSource = null;
            gridControl1.DataSource = tabla;
            gridView1.Columns["[Nombre Proveedor]"].GroupIndex = 0;
            gridView1.Columns["[Descripcion Promocional]"].GroupIndex = 1;
            gridView1.Columns["[Nombre Proveedor]"].Caption = "Prov";
            gridView1.Columns["[Descripcion Promocional]"].Caption = "|";
        }
    }
}