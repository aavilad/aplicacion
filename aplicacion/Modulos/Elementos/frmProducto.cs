using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xtraForm.Modulos.Elementos
{
    public partial class frmProducto : DevExpress.XtraEditors.XtraForm
    {
        public frmProducto()
        {
            InitializeComponent();
        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            using (var Context = new Model.LiderAppEntities())
            {
                TxtNmProveedor.Properties.DataSource = Context.PROVEEDOR.Select(p => new { Codigo = p.Proveedor1.Trim(), Nombre = p.RazonSocial.Trim() }).ToList();
                TxtNmProveedor.Properties.DisplayMember = "Nombre";
                TxtNmProveedor.Properties.ValueMember = "Codigo";
                LookUpColumnInfoCollection ColumnaA = TxtNmProveedor.Properties.Columns;
                ColumnaA.Add(new LookUpColumnInfo("Nombre", ""));
                TxtLinea.Properties.DataSource = Context.LINEA.Select(p => new { Codigo = p.Linea1.Trim(), Descripcion = p.Descripcion.Trim() }).ToList();
                TxtLinea.Properties.DisplayMember = "Descripcion";
                TxtLinea.Properties.ValueMember = "Codigo";
                LookUpColumnInfoCollection ColumnaB = TxtLinea.Properties.Columns;
                ColumnaB.Add(new LookUpColumnInfo("Descripcion", ""));
                TxtMarca.Properties.DataSource = Context.MARCA.Select(p => new { Codigo = p.Marca1.Trim(), Descripcion = p.Descripcion.Trim() }).ToList();
                TxtMarca.Properties.DisplayMember = "Descripcion";
                TxtMarca.Properties.ValueMember = "Codigo";
                LookUpColumnInfoCollection ColumnaC = TxtMarca.Properties.Columns;
                ColumnaC.Add(new LookUpColumnInfo("Descripcion", ""));
                TxtGrupo.Properties.DataSource = Context.grupo.Select(p => new { Codigo = p.grupo1.Trim(), Descripcion = p.descrip.Trim() }).ToList();
                TxtGrupo.Properties.DisplayMember = "Descripcion";
                TxtGrupo.Properties.ValueMember = "Codigo";
                LookUpColumnInfoCollection ColumnaD = TxtGrupo.Properties.Columns;
                ColumnaD.Add(new LookUpColumnInfo("Descripcion", ""));
                TxtClase.Properties.DataSource = Context.clase.Select(p => new { Codigo = p.clase1.Trim(), Descripcion = p.descrip.Trim() }).ToList();
                TxtClase.Properties.DisplayMember = "Descripcion";
                TxtClase.Properties.ValueMember = "Codigo";
                LookUpColumnInfoCollection ColumnaE = TxtClase.Properties.Columns;
                ColumnaE.Add(new LookUpColumnInfo("Descripcion", ""));
                TxtCategoria.Properties.DataSource = Context.categoria.Select(p => new { Codigo = p.categoria1.Trim(), Descripcion = p.descrip.Trim() }).ToList();
                TxtCategoria.Properties.DisplayMember = "Descripcion";
                TxtCategoria.Properties.ValueMember = "Codigo";
                LookUpColumnInfoCollection ColumnaF = TxtCategoria.Properties.Columns;
                ColumnaF.Add(new LookUpColumnInfo("Descripcion", ""));
            }
        }
    }
}