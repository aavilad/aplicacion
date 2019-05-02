using DevExpress.XtraEditors;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xtraForm.Reportes.Vistas
{
    public partial class frmVistaPrincipal : DevExpress.XtraEditors.XtraForm
    {
        public frmVistaPrincipal()
        {
            InitializeComponent();
        }

        private void frmVistaPrincipal_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            using (var Context = new Model.LiderAppEntities())
            {
                var proceso = new Libreria.Proceso();
                string Consulta = Context.VistaReporte.Where(x => x.PKID == 1).Select(p => p.Vista).FirstOrDefault();
                reportViewer1.Reset();
                string Fecha = Convert.ToDateTime(FechaProceso.EditValue).ToString("yyyyMMdd");
                int Facturado = checkEdit1.Checked == true ? 1 : 0;
                string Gestion_ = Convert.ToString(Gestion.EditValue);
                string Ruta_ = Convert.ToString(Ruta.EditValue);
                proceso.consultar(@"
                SELECT RTRIM(dbo.Vva_Producto.Codigo) AS Codigo, 
                       RTRIM(dbo.Vva_Producto.Descripcion) AS Descripcion, 
                       RTRIM(dbo.Vva_Producto.Unidad) AS Unidad, 
                       SUM(dbo.Vva_ItemTicketv.Cantidad) AS Cantidad, 
                       RTRIM(Concat('Rv', dbo.Vva_Ticketv.IDVendedor)) AS Rv
                FROM dbo.RUTAS
                     INNER JOIN dbo.REPARTO ON dbo.RUTAS.codigo = dbo.REPARTO.Ruta
                     INNER JOIN dbo.ZONA_PERSONAL
                     INNER JOIN dbo.ZONA ON dbo.ZONA_PERSONAL.Zona = dbo.ZONA.Zona
                     INNER JOIN dbo.Vva_Ticketv
                     INNER JOIN dbo.Vva_ItemTicketv ON dbo.Vva_Ticketv.NrDoc = dbo.Vva_ItemTicketv.NrDoc
                                                       AND dbo.Vva_Ticketv.TpDoc = dbo.Vva_ItemTicketv.TpDoc
                     INNER JOIN dbo.Vva_Producto ON dbo.Vva_ItemTicketv.IDProducto = dbo.Vva_Producto.Codigo ON dbo.ZONA_PERSONAL.Personal = dbo.Vva_Ticketv.IDVendedor ON dbo.REPARTO.Personal = dbo.ZONA_PERSONAL.Personal
                WHERE(dbo.Vva_Ticketv.Fecha = '" + Fecha + @"')
                     AND (dbo.REPARTO.Ruta = '" + Ruta_ + @"')
                     AND (dbo.REPARTO.Dia = DATEPART(w, '" + Fecha + @"'))
                     AND (dbo.Vva_Ticketv.Anulado = 0)
                     AND (dbo.Vva_Ticketv.Gestion = '" + Gestion_ + @"')
                     AND (dbo.Vva_Ticketv.Procesado = " + Facturado + @")
                GROUP BY dbo.Vva_Producto.Codigo, 
                         dbo.Vva_Producto.Descripcion, 
                         dbo.Vva_Producto.Unidad, 
                         dbo.Vva_Ticketv.IDVendedor;", "L1");
                ReportDataSource DS = new ReportDataSource("Listado", proceso.ds.Tables["L1"]);
                reportViewer1.LocalReport.DataSources.Add(DS);
                reportViewer1.LocalReport.ReportPath = @"\Report\Distribucion\ListadoPorRuta.rdlc";
                reportViewer1.RefreshReport();
            }
        }

        private void FechaProceso_EditValueChanged(object sender, EventArgs e)
        {
            using (var Context = new Model.LiderAppEntities())
            {
                var LGestion = (from g in Context.Gestion
                                where g.activa == true
                                select new { Codigo = g.codigo.Trim(), Descripcion = g.codigo.Trim() + ":" + g.descripcion.Trim() });
                var LRutas = (from r in Context.RUTAS.AsEnumerable()
                              join rp in Context.REPARTO.AsEnumerable() on r.codigo equals rp.Ruta
                              where r.Activo == true && rp.Dia == (int)Convert.ToDateTime(FechaProceso.EditValue).DayOfWeek
                              select new { Codigo = r.codigo.Trim(), Descripcion = r.codigo.Trim() + ":" + r.descripcion.Trim() });
                Gestion.Properties.DisplayMember = "Descripcion";
                Gestion.Properties.ValueMember = "Codigo";
                Gestion.Properties.ShowFooter = false;
                Gestion.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descripcion", "", 10));
                Gestion.Properties.DataSource = LGestion.ToList();
                Ruta.Properties.DisplayMember = "Descripcion";
                Ruta.Properties.ValueMember = "Codigo";
                Ruta.Properties.ShowFooter = false;
                Ruta.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descripcion", "", 10));
                Ruta.Properties.DataSource = LRutas.ToList();
            }
        }
    }
}