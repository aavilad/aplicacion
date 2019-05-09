namespace xtraForm.Modulos.Reportes.Modulos.Distribucion
{
    partial class frmcs
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.DataAccess.EntityFramework.EFConnectionParameters efConnectionParameters1 = new DevExpress.DataAccess.EntityFramework.EFConnectionParameters();
            DevExpress.XtraReports.Parameters.DynamicListLookUpSettings dynamicListLookUpSettings1 = new DevExpress.XtraReports.Parameters.DynamicListLookUpSettings();
            DevExpress.XtraReports.Parameters.DynamicListLookUpSettings dynamicListLookUpSettings2 = new DevExpress.XtraReports.Parameters.DynamicListLookUpSettings();
            this.efDataSource1 = new DevExpress.DataAccess.EntityFramework.EFDataSource(this.components);
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrPivotGrid1 = new DevExpress.XtraReports.UI.XRPivotGrid();
            this.fieldProveedor1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldCodigo1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldDescripcion1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldUnidad1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldCantidad1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldVendedor1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldOrden1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldZona1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Ruta = new DevExpress.XtraReports.Parameters.Parameter();
            this.Fecha = new DevExpress.XtraReports.Parameters.Parameter();
            this.Gestion = new DevExpress.XtraReports.Parameters.Parameter();
            ((System.ComponentModel.ISupportInitialize)(this.efDataSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // efDataSource1
            // 
            efConnectionParameters1.ConnectionString = "";
            efConnectionParameters1.ConnectionStringName = "conexion";
            efConnectionParameters1.Source = typeof(xtraForm.Model.LiderAppEntities);
            this.efDataSource1.ConnectionParameters = efConnectionParameters1;
            this.efDataSource1.Name = "efDataSource1";
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPivotGrid1});
            this.Detail.HeightF = 146.875F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrPivotGrid1
            // 
            this.xrPivotGrid1.Appearance.Cell.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.xrPivotGrid1.Appearance.CustomTotalCell.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.xrPivotGrid1.Appearance.FieldHeader.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.xrPivotGrid1.Appearance.FieldValue.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.xrPivotGrid1.Appearance.FieldValueGrandTotal.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.xrPivotGrid1.Appearance.FieldValueTotal.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.xrPivotGrid1.Appearance.GrandTotalCell.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.xrPivotGrid1.Appearance.Lines.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.xrPivotGrid1.Appearance.TotalCell.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.xrPivotGrid1.DataMember = "Vva_ListadoPorRuta";
            this.xrPivotGrid1.DataSource = this.efDataSource1;
            this.xrPivotGrid1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Tag", "[Vva_ListadoPorRuta].[Cantidad]")});
            this.xrPivotGrid1.Fields.AddRange(new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField[] {
            this.fieldProveedor1,
            this.fieldCodigo1,
            this.fieldDescripcion1,
            this.fieldUnidad1,
            this.fieldCantidad1,
            this.fieldVendedor1,
            this.fieldOrden1,
            this.fieldZona1});
            this.xrPivotGrid1.LocationFloat = new DevExpress.Utils.PointFloat(50.04171F, 10.00001F);
            this.xrPivotGrid1.Name = "xrPivotGrid1";
            this.xrPivotGrid1.OptionsPrint.FilterSeparatorBarPadding = 3;
            this.xrPivotGrid1.SizeF = new System.Drawing.SizeF(736.9583F, 124.375F);
            // 
            // fieldProveedor1
            // 
            this.fieldProveedor1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldProveedor1.AreaIndex = 0;
            this.fieldProveedor1.Caption = "Proveedor";
            this.fieldProveedor1.FieldName = "Proveedor";
            this.fieldProveedor1.Name = "fieldProveedor1";
            this.fieldProveedor1.Options.ShowInFilter = true;
            // 
            // fieldCodigo1
            // 
            this.fieldCodigo1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldCodigo1.AreaIndex = 1;
            this.fieldCodigo1.Caption = "Codigo";
            this.fieldCodigo1.FieldName = "Codigo";
            this.fieldCodigo1.Name = "fieldCodigo1";
            this.fieldCodigo1.Options.ShowInFilter = true;
            // 
            // fieldDescripcion1
            // 
            this.fieldDescripcion1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldDescripcion1.AreaIndex = 2;
            this.fieldDescripcion1.Caption = "Descripcion";
            this.fieldDescripcion1.FieldName = "Descripcion";
            this.fieldDescripcion1.Name = "fieldDescripcion1";
            this.fieldDescripcion1.Options.ShowInFilter = true;
            // 
            // fieldUnidad1
            // 
            this.fieldUnidad1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldUnidad1.AreaIndex = 3;
            this.fieldUnidad1.Caption = "Unidad";
            this.fieldUnidad1.FieldName = "Unidad";
            this.fieldUnidad1.Name = "fieldUnidad1";
            this.fieldUnidad1.Options.ShowInFilter = true;
            // 
            // fieldCantidad1
            // 
            this.fieldCantidad1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldCantidad1.AreaIndex = 0;
            this.fieldCantidad1.Caption = "Cantidad";
            this.fieldCantidad1.FieldName = "Cantidad";
            this.fieldCantidad1.Name = "fieldCantidad1";
            this.fieldCantidad1.Options.ShowInFilter = true;
            // 
            // fieldVendedor1
            // 
            this.fieldVendedor1.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.fieldVendedor1.AreaIndex = 0;
            this.fieldVendedor1.Caption = "Vendedor";
            this.fieldVendedor1.FieldName = "Vendedor";
            this.fieldVendedor1.Name = "fieldVendedor1";
            this.fieldVendedor1.Options.ShowInFilter = true;
            // 
            // fieldOrden1
            // 
            this.fieldOrden1.AreaIndex = 0;
            this.fieldOrden1.Caption = "Orden";
            this.fieldOrden1.FieldName = "Orden";
            this.fieldOrden1.Name = "fieldOrden1";
            this.fieldOrden1.Options.ShowInFilter = true;
            // 
            // fieldZona1
            // 
            this.fieldZona1.AreaIndex = 1;
            this.fieldZona1.Caption = "Zona";
            this.fieldZona1.FieldName = "Zona";
            this.fieldZona1.Name = "fieldZona1";
            this.fieldZona1.Options.ShowInFilter = true;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 25.08334F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 33F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Ruta
            // 
            this.Ruta.Description = "Ruta";
            dynamicListLookUpSettings1.DataAdapter = null;
            dynamicListLookUpSettings1.DataMember = "RUTAS";
            dynamicListLookUpSettings1.DataSource = this.efDataSource1;
            dynamicListLookUpSettings1.DisplayMember = "codigo";
            dynamicListLookUpSettings1.ValueMember = "codigo";
            this.Ruta.LookUpSettings = dynamicListLookUpSettings1;
            this.Ruta.Name = "Ruta";
            // 
            // Fecha
            // 
            this.Fecha.Description = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.Type = typeof(System.DateTime);
            // 
            // Gestion
            // 
            this.Gestion.Description = "Gestion";
            dynamicListLookUpSettings2.DataAdapter = null;
            dynamicListLookUpSettings2.DataMember = "Gestion";
            dynamicListLookUpSettings2.DataSource = this.efDataSource1;
            dynamicListLookUpSettings2.DisplayMember = "codigo";
            dynamicListLookUpSettings2.ValueMember = "codigo";
            this.Gestion.LookUpSettings = dynamicListLookUpSettings2;
            this.Gestion.Name = "Gestion";
            // 
            // frmcs
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.efDataSource1});
            this.DataMember = "Vva_ListadoPorRuta";
            this.DataSource = this.efDataSource1;
            this.FilterString = "[Ruta] = ?Ruta And [Fecha] = ?Fecha And [Gestion] = ?Gestion";
            this.Font = new System.Drawing.Font("Calibri", 9F);
            this.Margins = new System.Drawing.Printing.Margins(26, 27, 25, 33);
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.Ruta,
            this.Fecha,
            this.Gestion});
            this.Version = "18.1";
            ((System.ComponentModel.ISupportInitialize)(this.efDataSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.DataAccess.EntityFramework.EFDataSource efDataSource1;
        private DevExpress.XtraReports.UI.XRPivotGrid xrPivotGrid1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldProveedor1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldCodigo1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldDescripcion1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldUnidad1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldCantidad1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldVendedor1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldOrden1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldZona1;
        private DevExpress.XtraReports.Parameters.Parameter Ruta;
        private DevExpress.XtraReports.Parameters.Parameter Fecha;
        private DevExpress.XtraReports.Parameters.Parameter Gestion;
    }
}
