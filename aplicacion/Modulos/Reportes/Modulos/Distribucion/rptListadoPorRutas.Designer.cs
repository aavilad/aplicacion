namespace xtraForm.Modulos.Reportes.Modulos.Distribucion
{
    partial class rptListadoPorRutas
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
            DevExpress.DataAccess.Sql.SelectQuery selectQuery1 = new DevExpress.DataAccess.Sql.SelectQuery();
            DevExpress.DataAccess.Sql.Column column1 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression1 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Table table1 = new DevExpress.DataAccess.Sql.Table();
            DevExpress.DataAccess.Sql.Column column2 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression2 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column3 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression3 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column4 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression4 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column5 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression5 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column6 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression6 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column7 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression7 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column8 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression8 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column9 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression9 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column10 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression10 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column11 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression11 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter1 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter2 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter3 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter4 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter5 = new DevExpress.DataAccess.Sql.QueryParameter();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptListadoPorRutas));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.Fecha = new DevExpress.XtraReports.Parameters.Parameter();
            this.Ruta = new DevExpress.XtraReports.Parameters.Parameter();
            this.xrPivotGrid1 = new DevExpress.XtraReports.UI.XRPivotGrid();
            this.fieldCodigo = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldDescripcion = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldUnidad = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldCantidad = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldVendedor = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldProveedor = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldProveedor1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldCodigo1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldDescripcion1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldUnidad1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldCantidad1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldVendedor1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldOrden1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldZona1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldRuta1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldFecha1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldGestion1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPivotGrid1});
            this.Detail.HeightF = 58.33333F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 28.125F;
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
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "localhost_Lider2018_Connection";
            this.sqlDataSource1.Name = "sqlDataSource1";
            columnExpression1.ColumnName = "Proveedor";
            table1.MetaSerializable = "<Meta X=\"0\" Y=\"10\" Width=\"125\" Height=\"267\" />";
            table1.Name = "Vva_ListadoPorRuta";
            columnExpression1.Table = table1;
            column1.Expression = columnExpression1;
            columnExpression2.ColumnName = "Codigo";
            columnExpression2.Table = table1;
            column2.Expression = columnExpression2;
            columnExpression3.ColumnName = "Descripcion";
            columnExpression3.Table = table1;
            column3.Expression = columnExpression3;
            columnExpression4.ColumnName = "Unidad";
            columnExpression4.Table = table1;
            column4.Expression = columnExpression4;
            columnExpression5.ColumnName = "Cantidad";
            columnExpression5.Table = table1;
            column5.Expression = columnExpression5;
            columnExpression6.ColumnName = "Vendedor";
            columnExpression6.Table = table1;
            column6.Expression = columnExpression6;
            columnExpression7.ColumnName = "Orden";
            columnExpression7.Table = table1;
            column7.Expression = columnExpression7;
            columnExpression8.ColumnName = "Zona";
            columnExpression8.Table = table1;
            column8.Expression = columnExpression8;
            columnExpression9.ColumnName = "Ruta";
            columnExpression9.Table = table1;
            column9.Expression = columnExpression9;
            columnExpression10.ColumnName = "Fecha";
            columnExpression10.Table = table1;
            column10.Expression = columnExpression10;
            columnExpression11.ColumnName = "Gestion";
            columnExpression11.Table = table1;
            column11.Expression = columnExpression11;
            selectQuery1.Columns.Add(column1);
            selectQuery1.Columns.Add(column2);
            selectQuery1.Columns.Add(column3);
            selectQuery1.Columns.Add(column4);
            selectQuery1.Columns.Add(column5);
            selectQuery1.Columns.Add(column6);
            selectQuery1.Columns.Add(column7);
            selectQuery1.Columns.Add(column8);
            selectQuery1.Columns.Add(column9);
            selectQuery1.Columns.Add(column10);
            selectQuery1.Columns.Add(column11);
            selectQuery1.FilterString = "[Vva_ListadoPorRuta.Ruta] = ?Parámetro3 And [Vva_ListadoPorRuta.Fecha] = ?Parámet" +
    "ro2";
            selectQuery1.GroupFilterString = "";
            selectQuery1.Name = "Vva_ListadoPorRuta";
            queryParameter1.Name = "Ruta";
            queryParameter1.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter1.Value = new DevExpress.DataAccess.Expression("[Parameters.Ruta]", typeof(string));
            queryParameter2.Name = "Fecha";
            queryParameter2.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter2.Value = new DevExpress.DataAccess.Expression("[Parameters.Fecha]", typeof(System.DateTime));
            queryParameter3.Name = "Parámetro1";
            queryParameter3.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter3.Value = new DevExpress.DataAccess.Expression("[Parameters.Fecha]", typeof(System.DateTime));
            queryParameter4.Name = "Parámetro2";
            queryParameter4.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter4.Value = new DevExpress.DataAccess.Expression("[Parameters.Fecha]", typeof(System.DateTime));
            queryParameter5.Name = "Parámetro3";
            queryParameter5.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter5.Value = new DevExpress.DataAccess.Expression("[Parameters.Ruta]", typeof(string));
            selectQuery1.Parameters.Add(queryParameter1);
            selectQuery1.Parameters.Add(queryParameter2);
            selectQuery1.Parameters.Add(queryParameter3);
            selectQuery1.Parameters.Add(queryParameter4);
            selectQuery1.Parameters.Add(queryParameter5);
            selectQuery1.Tables.Add(table1);
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            selectQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // Fecha
            // 
            this.Fecha.Description = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.Type = typeof(System.DateTime);
            // 
            // Ruta
            // 
            this.Ruta.Description = "Ruta";
            this.Ruta.Name = "Ruta";
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
            this.xrPivotGrid1.Fields.AddRange(new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField[] {
            this.fieldCodigo,
            this.fieldDescripcion,
            this.fieldUnidad,
            this.fieldCantidad,
            this.fieldVendedor,
            this.fieldProveedor});
            this.xrPivotGrid1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10.00001F);
            this.xrPivotGrid1.Name = "xrPivotGrid1";
            this.xrPivotGrid1.OptionsPrint.FilterSeparatorBarPadding = 3;
            this.xrPivotGrid1.OptionsPrint.PrintColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
            this.xrPivotGrid1.OptionsPrint.PrintDataHeaders = DevExpress.Utils.DefaultBoolean.False;
            this.xrPivotGrid1.OptionsPrint.PrintFilterHeaders = DevExpress.Utils.DefaultBoolean.False;
            this.xrPivotGrid1.OptionsPrint.PrintHorzLines = DevExpress.Utils.DefaultBoolean.False;
            this.xrPivotGrid1.OptionsPrint.PrintRowHeaders = DevExpress.Utils.DefaultBoolean.True;
            this.xrPivotGrid1.OptionsPrint.PrintUnusedFilterFields = false;
            this.xrPivotGrid1.OptionsPrint.PrintVertLines = DevExpress.Utils.DefaultBoolean.False;
            this.xrPivotGrid1.SizeF = new System.Drawing.SizeF(647.3334F, 42.70834F);
            // 
            // fieldCodigo
            // 
            this.fieldCodigo.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldCodigo.AreaIndex = 1;
            this.fieldCodigo.FieldName = "Codigo";
            this.fieldCodigo.Name = "fieldCodigo";
            this.fieldCodigo.Options.ShowInFilter = true;
            this.fieldCodigo.Width = 85;
            // 
            // fieldDescripcion
            // 
            this.fieldDescripcion.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldDescripcion.AreaIndex = 2;
            this.fieldDescripcion.FieldName = "Descripcion";
            this.fieldDescripcion.Name = "fieldDescripcion";
            this.fieldDescripcion.Options.ShowInFilter = true;
            this.fieldDescripcion.Width = 286;
            // 
            // fieldUnidad
            // 
            this.fieldUnidad.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldUnidad.AreaIndex = 3;
            this.fieldUnidad.FieldName = "Unidad";
            this.fieldUnidad.Name = "fieldUnidad";
            this.fieldUnidad.Options.ShowInFilter = true;
            this.fieldUnidad.Width = 41;
            // 
            // fieldCantidad
            // 
            this.fieldCantidad.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldCantidad.AreaIndex = 0;
            this.fieldCantidad.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fieldCantidad.FieldName = "Cantidad";
            this.fieldCantidad.Name = "fieldCantidad";
            this.fieldCantidad.Options.ShowGrandTotal = false;
            this.fieldCantidad.Options.ShowInFilter = true;
            this.fieldCantidad.Options.ShowTotals = false;
            // 
            // fieldVendedor
            // 
            this.fieldVendedor.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.fieldVendedor.AreaIndex = 0;
            this.fieldVendedor.FieldName = "Vendedor";
            this.fieldVendedor.Name = "fieldVendedor";
            this.fieldVendedor.Options.ShowInFilter = true;
            this.fieldVendedor.Width = 36;
            // 
            // fieldProveedor
            // 
            this.fieldProveedor.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldProveedor.AreaIndex = 0;
            this.fieldProveedor.FieldName = "Proveedor";
            this.fieldProveedor.Name = "fieldProveedor";
            this.fieldProveedor.Options.ShowInFilter = true;
            this.fieldProveedor.Width = 105;
            // 
            // fieldProveedor1
            // 
            this.fieldProveedor1.AreaIndex = 0;
            this.fieldProveedor1.Caption = "Proveedor";
            this.fieldProveedor1.FieldName = "Proveedor";
            this.fieldProveedor1.Name = "fieldProveedor1";
            this.fieldProveedor1.Options.ShowInFilter = true;
            // 
            // fieldCodigo1
            // 
            this.fieldCodigo1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldCodigo1.AreaIndex = 0;
            this.fieldCodigo1.Caption = "Codigo";
            this.fieldCodigo1.FieldName = "Codigo";
            this.fieldCodigo1.Name = "fieldCodigo1";
            this.fieldCodigo1.Options.ShowInFilter = true;
            this.fieldCodigo1.Width = 80;
            // 
            // fieldDescripcion1
            // 
            this.fieldDescripcion1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldDescripcion1.AreaIndex = 1;
            this.fieldDescripcion1.Caption = "Descripcion";
            this.fieldDescripcion1.FieldName = "Descripcion";
            this.fieldDescripcion1.Name = "fieldDescripcion1";
            this.fieldDescripcion1.Options.ShowInFilter = true;
            this.fieldDescripcion1.Width = 250;
            // 
            // fieldUnidad1
            // 
            this.fieldUnidad1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldUnidad1.AreaIndex = 2;
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
            this.fieldOrden1.AreaIndex = 1;
            this.fieldOrden1.Caption = "Orden";
            this.fieldOrden1.FieldName = "Orden";
            this.fieldOrden1.Name = "fieldOrden1";
            this.fieldOrden1.Options.ShowInFilter = true;
            // 
            // fieldZona1
            // 
            this.fieldZona1.AreaIndex = 2;
            this.fieldZona1.Caption = "Zona";
            this.fieldZona1.FieldName = "Zona";
            this.fieldZona1.Name = "fieldZona1";
            this.fieldZona1.Options.ShowInFilter = true;
            // 
            // fieldRuta1
            // 
            this.fieldRuta1.AreaIndex = 3;
            this.fieldRuta1.Caption = "Ruta";
            this.fieldRuta1.FieldName = "Ruta";
            this.fieldRuta1.Name = "fieldRuta1";
            this.fieldRuta1.Options.ShowInFilter = true;
            // 
            // fieldFecha1
            // 
            this.fieldFecha1.AreaIndex = 4;
            this.fieldFecha1.Caption = "Fecha";
            this.fieldFecha1.FieldName = "Fecha";
            this.fieldFecha1.Name = "fieldFecha1";
            this.fieldFecha1.Options.ShowInFilter = true;
            // 
            // fieldGestion1
            // 
            this.fieldGestion1.AreaIndex = 5;
            this.fieldGestion1.Caption = "Gestion";
            this.fieldGestion1.FieldName = "Gestion";
            this.fieldGestion1.Name = "fieldGestion1";
            this.fieldGestion1.Options.ShowInFilter = true;
            // 
            // rptListadoPorRutas
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "Vva_ListadoPorRuta";
            this.DataSource = this.sqlDataSource1;
            this.FilterString = "[Fecha] = ?Fecha And [Ruta] = ?Ruta";
            this.Margins = new System.Drawing.Printing.Margins(100, 31, 28, 100);
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.Fecha,
            this.Ruta});
            this.Version = "18.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private DevExpress.XtraReports.Parameters.Parameter Fecha;
        private DevExpress.XtraReports.Parameters.Parameter Ruta;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldProveedor1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldCodigo1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldDescripcion1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldUnidad1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldCantidad1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldVendedor1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldOrden1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldZona1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldRuta1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldFecha1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldGestion1;
        private DevExpress.XtraReports.UI.XRPivotGrid xrPivotGrid1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldCodigo;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldDescripcion;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldUnidad;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldCantidad;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldVendedor;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldProveedor;
    }
}
