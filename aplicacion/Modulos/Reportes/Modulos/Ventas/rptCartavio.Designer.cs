namespace xtraForm.Modulos.Reportes.Modulos.Ventas
{
    partial class rptCartavio
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
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter1 = new DevExpress.DataAccess.Sql.QueryParameter();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptCartavio));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.efDataSource1 = new DevExpress.DataAccess.EntityFramework.EFDataSource(this.components);
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.pivotGridField1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.pivotGridField2 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.pivotGridField3 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.pivotGridField4 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.pivotGridField5 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.Fecha = new DevExpress.XtraReports.Parameters.Parameter();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.xrControlStyle1 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.xrPivotGrid1 = new DevExpress.XtraReports.UI.XRPivotGrid();
            this.fieldCodigovendedor1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldNombreVendedor1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldImporte1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldCientes1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldPedidos1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            ((System.ComponentModel.ISupportInitialize)(this.efDataSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.HeightF = 0F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // efDataSource1
            // 
            efConnectionParameters1.ConnectionString = "";
            efConnectionParameters1.ConnectionStringName = "conexion";
            efConnectionParameters1.Source = typeof(xtraForm.Model.LiderAppEntities);
            this.efDataSource1.ConnectionParameters = efConnectionParameters1;
            this.efDataSource1.Name = "efDataSource1";
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 26F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 26F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeader
            // 
            this.ReportHeader.HeightF = 38.00456F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // PageFooter
            // 
            this.PageFooter.Name = "PageFooter";
            // 
            // pivotGridField1
            // 
            this.pivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField1.AreaIndex = 0;
            this.pivotGridField1.FieldName = "PEDIDO";
            this.pivotGridField1.Name = "pivotGridField1";
            this.pivotGridField1.Options.ShowInFilter = true;
            // 
            // pivotGridField2
            // 
            this.pivotGridField2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField2.AreaIndex = 1;
            this.pivotGridField2.Name = "pivotGridField2";
            this.pivotGridField2.Options.ShowInFilter = true;
            // 
            // pivotGridField3
            // 
            this.pivotGridField3.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pivotGridField3.AreaIndex = 0;
            this.pivotGridField3.Name = "pivotGridField3";
            this.pivotGridField3.Options.ShowInFilter = true;
            // 
            // pivotGridField4
            // 
            this.pivotGridField4.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pivotGridField4.AreaIndex = 1;
            this.pivotGridField4.Name = "pivotGridField4";
            this.pivotGridField4.Options.ShowInFilter = true;
            // 
            // pivotGridField5
            // 
            this.pivotGridField5.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pivotGridField5.AreaIndex = 2;
            this.pivotGridField5.Name = "pivotGridField5";
            this.pivotGridField5.Options.ShowInFilter = true;
            // 
            // Fecha
            // 
            this.Fecha.Name = "Fecha";
            this.Fecha.Type = typeof(System.DateTime);
            this.Fecha.ValueInfo = "1753-01-01";
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "conexion";
            this.sqlDataSource1.Name = "sqlDataSource1";
            customSqlQuery1.Name = "Query";
            queryParameter1.Name = "Fecha";
            queryParameter1.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter1.Value = new DevExpress.DataAccess.Expression("[Parameters.Fecha]", typeof(System.DateTime));
            customSqlQuery1.Parameters.Add(queryParameter1);
            customSqlQuery1.Sql = resources.GetString("customSqlQuery1.Sql");
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // xrControlStyle1
            // 
            this.xrControlStyle1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.xrControlStyle1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrControlStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrControlStyle1.Name = "xrControlStyle1";
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
            this.fieldCodigovendedor1,
            this.fieldNombreVendedor1,
            this.fieldImporte1,
            this.fieldCientes1,
            this.fieldPedidos1});
            this.xrPivotGrid1.LocationFloat = new DevExpress.Utils.PointFloat(9.999998F, 0F);
            this.xrPivotGrid1.Name = "xrPivotGrid1";
            this.xrPivotGrid1.OLAPConnectionString = "";
            this.xrPivotGrid1.OptionsPrint.FilterSeparatorBarPadding = 3;
            this.xrPivotGrid1.OptionsPrint.PrintUnusedFilterFields = false;
            this.xrPivotGrid1.OptionsView.ShowDataHeaders = false;
            this.xrPivotGrid1.SizeF = new System.Drawing.SizeF(628.5417F, 67.08333F);
            // 
            // fieldCodigovendedor1
            // 
            this.fieldCodigovendedor1.Appearance.FieldHeader.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldCodigovendedor1.Appearance.FieldValue.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fieldCodigovendedor1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldCodigovendedor1.AreaIndex = 0;
            this.fieldCodigovendedor1.Caption = "Codigo ";
            this.fieldCodigovendedor1.FieldName = "Codigo vendedor";
            this.fieldCodigovendedor1.Name = "fieldCodigovendedor1";
            this.fieldCodigovendedor1.Options.ShowInFilter = true;
            this.fieldCodigovendedor1.Width = 63;
            // 
            // fieldNombreVendedor1
            // 
            this.fieldNombreVendedor1.Appearance.Cell.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.fieldNombreVendedor1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldNombreVendedor1.AreaIndex = 1;
            this.fieldNombreVendedor1.Caption = "Nombre ";
            this.fieldNombreVendedor1.FieldName = "Nombre Vendedor";
            this.fieldNombreVendedor1.Name = "fieldNombreVendedor1";
            this.fieldNombreVendedor1.Options.ShowInFilter = true;
            this.fieldNombreVendedor1.Width = 247;
            // 
            // fieldImporte1
            // 
            this.fieldImporte1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldImporte1.AreaIndex = 2;
            this.fieldImporte1.Caption = "Importe";
            this.fieldImporte1.FieldName = "Importe";
            this.fieldImporte1.Name = "fieldImporte1";
            this.fieldImporte1.Options.ShowInFilter = true;
            // 
            // fieldCientes1
            // 
            this.fieldCientes1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldCientes1.AreaIndex = 1;
            this.fieldCientes1.Caption = "Cientes";
            this.fieldCientes1.FieldName = "Cientes";
            this.fieldCientes1.Name = "fieldCientes1";
            this.fieldCientes1.Options.ShowInFilter = true;
            // 
            // fieldPedidos1
            // 
            this.fieldPedidos1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldPedidos1.AreaIndex = 0;
            this.fieldPedidos1.Caption = "Pedidos";
            this.fieldPedidos1.FieldName = "Pedidos";
            this.fieldPedidos1.Name = "fieldPedidos1";
            this.fieldPedidos1.Options.ShowInFilter = true;
            this.fieldPedidos1.Width = 80;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPivotGrid1});
            this.GroupFooter1.HeightF = 67.70834F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // rptCartavio
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageFooter,
            this.GroupFooter1});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.efDataSource1,
            this.sqlDataSource1});
            this.DataMember = "Query";
            this.DataSource = this.sqlDataSource1;
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.Margins = new System.Drawing.Printing.Margins(28, 39, 26, 26);
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.Fecha});
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.xrControlStyle1});
            this.Version = "18.1";
            ((System.ComponentModel.ISupportInitialize)(this.efDataSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.DataAccess.EntityFramework.EFDataSource efDataSource1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField pivotGridField1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField pivotGridField2;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField pivotGridField3;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField pivotGridField4;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField pivotGridField5;
        private DevExpress.XtraReports.Parameters.Parameter Fecha;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private DevExpress.XtraReports.UI.XRControlStyle xrControlStyle1;
        private DevExpress.XtraReports.UI.XRPivotGrid xrPivotGrid1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldCodigovendedor1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldNombreVendedor1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldImporte1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldCientes1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldPedidos1;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
    }
}
