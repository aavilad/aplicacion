using xtraForm.Model;
using xtraForm.Model.Conexion.edmx.Conexion.tt;

namespace xtraForm.Modulos.Elementos
{
    partial class prueba
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.vvaVendedorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.vvaVendedorBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.colTipoPersona = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colDoc_Identidad = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colActivo = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTpLista = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colIDGrupo = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.vvaVendedorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vvaVendedorBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // vvaVendedorBindingSource
            // 
            this.vvaVendedorBindingSource.DataSource = typeof(Vva_Vendedor);
            // 
            // treeList1
            // 
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colTipoPersona,
            this.colDoc_Identidad,
            this.colActivo,
            this.colTpLista,
            this.colIDGrupo});
            this.treeList1.DataSource = this.vvaVendedorBindingSource1;
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.KeyFieldName = "IDFzaVentas";
            this.treeList1.Location = new System.Drawing.Point(0, 0);
            this.treeList1.Name = "treeList1";
            this.treeList1.ParentFieldName = "Nombre_Vendedor";
            this.treeList1.Size = new System.Drawing.Size(451, 262);
            this.treeList1.TabIndex = 0;
            // 
            // vvaVendedorBindingSource1
            // 
            this.vvaVendedorBindingSource1.DataSource = typeof(Vva_Vendedor);
            // 
            // colTipoPersona
            // 
            this.colTipoPersona.FieldName = "TipoPersona";
            this.colTipoPersona.Name = "colTipoPersona";
            this.colTipoPersona.Visible = true;
            this.colTipoPersona.VisibleIndex = 0;
            // 
            // colDoc_Identidad
            // 
            this.colDoc_Identidad.FieldName = "Doc_Identidad";
            this.colDoc_Identidad.Name = "colDoc_Identidad";
            this.colDoc_Identidad.Visible = true;
            this.colDoc_Identidad.VisibleIndex = 1;
            // 
            // colActivo
            // 
            this.colActivo.FieldName = "Activo";
            this.colActivo.Name = "colActivo";
            this.colActivo.Visible = true;
            this.colActivo.VisibleIndex = 2;
            // 
            // colTpLista
            // 
            this.colTpLista.FieldName = "TpLista";
            this.colTpLista.Name = "colTpLista";
            this.colTpLista.Visible = true;
            this.colTpLista.VisibleIndex = 3;
            // 
            // colIDGrupo
            // 
            this.colIDGrupo.FieldName = "IDGrupo";
            this.colIDGrupo.Name = "colIDGrupo";
            this.colIDGrupo.Visible = true;
            this.colIDGrupo.VisibleIndex = 4;
            // 
            // prueba
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 262);
            this.Controls.Add(this.treeList1);
            this.Name = "prueba";
            this.Text = "prueba";
            ((System.ComponentModel.ISupportInitialize)(this.vvaVendedorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vvaVendedorBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource vvaVendedorBindingSource;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTipoPersona;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDoc_Identidad;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colActivo;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTpLista;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colIDGrupo;
        private System.Windows.Forms.BindingSource vvaVendedorBindingSource1;
    }
}