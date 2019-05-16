namespace xtraForm.Modulos.Reportes.Modulos.Ventas
{
    partial class RptAvanceVentasSpring
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
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RptAvanceVentasSpring));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrPivotGrid1 = new DevExpress.XtraReports.UI.XRPivotGrid();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.fieldcdOrder1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldcdCreationUser1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldcdStore1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldcdRegion1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fielddtOrder1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldvlDiscountTotal1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldvlTotalOrder1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldvlTotalUnit1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldcdRoute1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldcdStatusOrder1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldcdInvoice1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fielddsDisplayText1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fielddtInvoice1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldvlTotalInvoice1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldnrTotalQuantity1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldcdStatusInvoice1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPivotGrid1});
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
            this.xrPivotGrid1.DataMember = "Query";
            this.xrPivotGrid1.DataSource = this.sqlDataSource1;
            this.xrPivotGrid1.Fields.AddRange(new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField[] {
            this.fieldcdOrder1,
            this.fieldcdCreationUser1,
            this.fieldcdStore1,
            this.fieldcdRegion1,
            this.fielddtOrder1,
            this.fieldvlDiscountTotal1,
            this.fieldvlTotalOrder1,
            this.fieldvlTotalUnit1,
            this.fieldcdRoute1,
            this.fieldcdStatusOrder1,
            this.fieldcdInvoice1,
            this.fielddsDisplayText1,
            this.fielddtInvoice1,
            this.fieldvlTotalInvoice1,
            this.fieldnrTotalQuantity1,
            this.fieldcdStatusInvoice1});
            this.xrPivotGrid1.LocationFloat = new DevExpress.Utils.PointFloat(33.125F, 10.00001F);
            this.xrPivotGrid1.Name = "xrPivotGrid1";
            this.xrPivotGrid1.OptionsPrint.FilterSeparatorBarPadding = 3;
            this.xrPivotGrid1.SizeF = new System.Drawing.SizeF(215F, 50F);
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "conexion";
            this.sqlDataSource1.Name = "sqlDataSource1";
            customSqlQuery1.Name = "Query";
            customSqlQuery1.Sql = "select * from unilever.importorderinvoice(\'20190501\',\'20190531\')";
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // TopMargin
            // 
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // fieldcdOrder1
            // 
            this.fieldcdOrder1.AreaIndex = 0;
            this.fieldcdOrder1.Caption = "cd Order";
            this.fieldcdOrder1.FieldName = "cdOrder";
            this.fieldcdOrder1.Name = "fieldcdOrder1";
            this.fieldcdOrder1.Options.ShowInFilter = true;
            // 
            // fieldcdCreationUser1
            // 
            this.fieldcdCreationUser1.AreaIndex = 1;
            this.fieldcdCreationUser1.Caption = "cd Creation User";
            this.fieldcdCreationUser1.FieldName = "cdCreationUser";
            this.fieldcdCreationUser1.Name = "fieldcdCreationUser1";
            this.fieldcdCreationUser1.Options.ShowInFilter = true;
            // 
            // fieldcdStore1
            // 
            this.fieldcdStore1.AreaIndex = 2;
            this.fieldcdStore1.Caption = "cd Store";
            this.fieldcdStore1.FieldName = "cdStore";
            this.fieldcdStore1.Name = "fieldcdStore1";
            this.fieldcdStore1.Options.ShowInFilter = true;
            // 
            // fieldcdRegion1
            // 
            this.fieldcdRegion1.AreaIndex = 3;
            this.fieldcdRegion1.Caption = "cd Region";
            this.fieldcdRegion1.FieldName = "cdRegion";
            this.fieldcdRegion1.Name = "fieldcdRegion1";
            this.fieldcdRegion1.Options.ShowInFilter = true;
            // 
            // fielddtOrder1
            // 
            this.fielddtOrder1.AreaIndex = 4;
            this.fielddtOrder1.Caption = "dt Order";
            this.fielddtOrder1.FieldName = "dtOrder";
            this.fielddtOrder1.Name = "fielddtOrder1";
            this.fielddtOrder1.Options.ShowInFilter = true;
            // 
            // fieldvlDiscountTotal1
            // 
            this.fieldvlDiscountTotal1.AreaIndex = 5;
            this.fieldvlDiscountTotal1.Caption = "vl Discount Total";
            this.fieldvlDiscountTotal1.FieldName = "vlDiscountTotal";
            this.fieldvlDiscountTotal1.Name = "fieldvlDiscountTotal1";
            this.fieldvlDiscountTotal1.Options.ShowInFilter = true;
            // 
            // fieldvlTotalOrder1
            // 
            this.fieldvlTotalOrder1.AreaIndex = 6;
            this.fieldvlTotalOrder1.Caption = "vl Total Order";
            this.fieldvlTotalOrder1.FieldName = "vlTotalOrder";
            this.fieldvlTotalOrder1.Name = "fieldvlTotalOrder1";
            this.fieldvlTotalOrder1.Options.ShowInFilter = true;
            // 
            // fieldvlTotalUnit1
            // 
            this.fieldvlTotalUnit1.AreaIndex = 7;
            this.fieldvlTotalUnit1.Caption = "vl Total Unit";
            this.fieldvlTotalUnit1.FieldName = "vlTotalUnit";
            this.fieldvlTotalUnit1.Name = "fieldvlTotalUnit1";
            this.fieldvlTotalUnit1.Options.ShowInFilter = true;
            // 
            // fieldcdRoute1
            // 
            this.fieldcdRoute1.AreaIndex = 8;
            this.fieldcdRoute1.Caption = "cd Route";
            this.fieldcdRoute1.FieldName = "cdRoute";
            this.fieldcdRoute1.Name = "fieldcdRoute1";
            this.fieldcdRoute1.Options.ShowInFilter = true;
            // 
            // fieldcdStatusOrder1
            // 
            this.fieldcdStatusOrder1.AreaIndex = 9;
            this.fieldcdStatusOrder1.Caption = "cd Status Order";
            this.fieldcdStatusOrder1.FieldName = "cdStatusOrder";
            this.fieldcdStatusOrder1.Name = "fieldcdStatusOrder1";
            this.fieldcdStatusOrder1.Options.ShowInFilter = true;
            // 
            // fieldcdInvoice1
            // 
            this.fieldcdInvoice1.AreaIndex = 10;
            this.fieldcdInvoice1.Caption = "cd Invoice";
            this.fieldcdInvoice1.FieldName = "cdInvoice";
            this.fieldcdInvoice1.Name = "fieldcdInvoice1";
            this.fieldcdInvoice1.Options.ShowInFilter = true;
            // 
            // fielddsDisplayText1
            // 
            this.fielddsDisplayText1.AreaIndex = 11;
            this.fielddsDisplayText1.Caption = "ds Display Text";
            this.fielddsDisplayText1.FieldName = "dsDisplayText";
            this.fielddsDisplayText1.Name = "fielddsDisplayText1";
            this.fielddsDisplayText1.Options.ShowInFilter = true;
            // 
            // fielddtInvoice1
            // 
            this.fielddtInvoice1.AreaIndex = 12;
            this.fielddtInvoice1.Caption = "dt Invoice";
            this.fielddtInvoice1.FieldName = "dtInvoice";
            this.fielddtInvoice1.Name = "fielddtInvoice1";
            this.fielddtInvoice1.Options.ShowInFilter = true;
            // 
            // fieldvlTotalInvoice1
            // 
            this.fieldvlTotalInvoice1.AreaIndex = 13;
            this.fieldvlTotalInvoice1.Caption = "vl Total Invoice";
            this.fieldvlTotalInvoice1.FieldName = "vlTotalInvoice";
            this.fieldvlTotalInvoice1.Name = "fieldvlTotalInvoice1";
            this.fieldvlTotalInvoice1.Options.ShowInFilter = true;
            // 
            // fieldnrTotalQuantity1
            // 
            this.fieldnrTotalQuantity1.AreaIndex = 14;
            this.fieldnrTotalQuantity1.Caption = "nr Total Quantity";
            this.fieldnrTotalQuantity1.FieldName = "nrTotalQuantity";
            this.fieldnrTotalQuantity1.Name = "fieldnrTotalQuantity1";
            this.fieldnrTotalQuantity1.Options.ShowInFilter = true;
            // 
            // fieldcdStatusInvoice1
            // 
            this.fieldcdStatusInvoice1.AreaIndex = 15;
            this.fieldcdStatusInvoice1.Caption = "cd Status Invoice";
            this.fieldcdStatusInvoice1.FieldName = "cdStatusInvoice";
            this.fieldcdStatusInvoice1.Name = "fieldcdStatusInvoice1";
            this.fieldcdStatusInvoice1.Options.ShowInFilter = true;
            // 
            // RptAvanceVentasSpring
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.Version = "18.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRPivotGrid xrPivotGrid1;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldcdOrder1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldcdCreationUser1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldcdStore1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldcdRegion1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fielddtOrder1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldvlDiscountTotal1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldvlTotalOrder1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldvlTotalUnit1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldcdRoute1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldcdStatusOrder1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldcdInvoice1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fielddsDisplayText1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fielddtInvoice1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldvlTotalInvoice1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldnrTotalQuantity1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldcdStatusInvoice1;
    }
}
