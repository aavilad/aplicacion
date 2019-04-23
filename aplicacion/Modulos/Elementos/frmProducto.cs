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
using DevExpress.XtraEditors.Controls;

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
                TxtNmProveedor.Properties.DataSource = Context.PROVEEDOR.Select(p => new { Codigo = p.Proveedor1.Trim(),Nombre = p.RazonSocial.Trim() }).ToList();
                TxtNmProveedor.Properties.DisplayMember = "Nombre";
                TxtNmProveedor.Properties.ValueMember = "Codigo";
                LookUpColumnInfoCollection Columna = TxtNmProveedor.Properties.Columns;
                Columna.Add(new LookUpColumnInfo("Nombre", ""));
            }
                
        }
    }
}