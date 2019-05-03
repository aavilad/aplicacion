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
                SELECT       PROVEEDOR.RazonSocial AS Proveedor,RTRIM(Vva_Producto.Codigo) AS Codigo, RTRIM(Vva_Producto.Descripcion) AS Descripcion, RTRIM(Vva_Producto.Unidad) AS Unidad, 
                                         SUM(Vva_ItemTicketv.Cantidad) AS Cantidad, RTRIM( CONCAT('Rv', Vva_Ticketv.IDVendedor)) AS Rv,
                                         Vva_Producto.RowNber
                FROM            RUTAS INNER JOIN
                                         REPARTO ON RUTAS.codigo = REPARTO.Ruta INNER JOIN
                                         ZONA_PERSONAL INNER JOIN
                                         ZONA ON ZONA_PERSONAL.Zona = ZONA.Zona INNER JOIN
                                         Vva_Ticketv INNER JOIN
                                         Vva_ItemTicketv ON Vva_Ticketv.NrDoc = Vva_ItemTicketv.NrDoc AND Vva_Ticketv.TpDoc = Vva_ItemTicketv.TpDoc INNER JOIN
                                         Vva_Producto ON Vva_ItemTicketv.IDProducto = Vva_Producto.Codigo ON ZONA_PERSONAL.Personal = Vva_Ticketv.IDVendedor ON 
                                         REPARTO.Personal = ZONA_PERSONAL.Personal INNER JOIN
                                         PROVEEDOR ON Vva_Producto.IDProv = PROVEEDOR.Proveedor
                WHERE        (Vva_Ticketv.Fecha = '"+Fecha+@"') AND (REPARTO.Ruta = '"+Ruta_+ @"') AND (REPARTO.Dia = DATEPART(w, '" + Fecha + @"')) AND (Vva_Ticketv.Anulado = 0) AND 
                                         (Vva_Ticketv.Gestion = '" + Gestion_+ @"') AND (Vva_Ticketv.Procesado = " + Facturado + @")
                GROUP BY Vva_Producto.Codigo, Vva_Producto.Descripcion, Vva_Producto.Unidad, Vva_Ticketv.IDVendedor, PROVEEDOR.RazonSocial, Vva_Producto.RowNber
                order by RazonSocial,RowNber", "L1");
                proceso.consultar(@"select a = STUFF((
                SELECT'  '+concat('''',rtrim(ZONA.Descripcion),'''')
                FROM            ZONA INNER JOIN
                                         ZONA_PERSONAL ON ZONA.Zona = ZONA_PERSONAL.Zona INNER JOIN
                                         REPARTO ON ZONA_PERSONAL.Personal = REPARTO.Personal
                WHERE        (REPARTO.Ruta ='" + Ruta_ + @"') AND (REPARTO.Dia = DATEPART(w, '" + Fecha + @"')) and (ZONA_PERSONAL.Numero = DATEPART(w, '" + Fecha + @"')) for xml path('')),1,1,' ')", "L2");
                var Tabla0 = proceso.ds.Tables["L1"];
                var Tabla1 = proceso.ds.Tables["L2"];
                ReportDataSource DS0 = new ReportDataSource("Listado", Tabla0);
                ReportDataSource DS1 = new ReportDataSource("Listado", Tabla1);
                reportViewer1.LocalReport.DataSources.Add(DS0);
                reportViewer1.LocalReport.DataSources.Add(DS1);
                reportViewer1.LocalReport.ReportPath = @"C:\Online\Poject\aplicacion\aplicacion\Reportes\Elementos\Distribucion\ListadoPorRutas.rdlc";
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