namespace xtraForm.Modulos.Reportes.Modulos.Ventas.Cubos
{
    partial class UnileverDms
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
            this.pivotGridControl1 = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.lider2018DataSet1 = new xtraForm.Lider2018DataSet();
            this.fieldcdOrder1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldcdCreationUser1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldcdStore1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldcdRegion1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fielddtOrder1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldvlDiscountTotal1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldvlTotalOrder1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldvlTotalUnit1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldcdRoute1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldcdStatusOrder1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldcdInvoice1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fielddsDisplayText1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fielddtInvoice1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldvlTotalInvoice1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldnrTotalQuantity1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldcdStatusInvoice1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.BUSCAR = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lider2018DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // pivotGridControl1
            // 
            this.pivotGridControl1.DataMember = "importorderinvoice";
            this.pivotGridControl1.DataSource = this.lider2018DataSet1;
            this.pivotGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pivotGridControl1.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
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
            this.pivotGridControl1.Location = new System.Drawing.Point(200, 0);
            this.pivotGridControl1.Name = "pivotGridControl1";
            this.pivotGridControl1.Size = new System.Drawing.Size(630, 427);
            this.pivotGridControl1.TabIndex = 0;
            // 
            // lider2018DataSet1
            // 
            this.lider2018DataSet1.DataSetName = "Lider2018DataSet";
            this.lider2018DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fieldcdOrder1
            // 
            this.fieldcdOrder1.AreaIndex = 0;
            this.fieldcdOrder1.Caption = "cd Order";
            this.fieldcdOrder1.FieldName = "cdOrder";
            this.fieldcdOrder1.Name = "fieldcdOrder1";
            // 
            // fieldcdCreationUser1
            // 
            this.fieldcdCreationUser1.AreaIndex = 1;
            this.fieldcdCreationUser1.Caption = "cd Creation User";
            this.fieldcdCreationUser1.FieldName = "cdCreationUser";
            this.fieldcdCreationUser1.Name = "fieldcdCreationUser1";
            // 
            // fieldcdStore1
            // 
            this.fieldcdStore1.AreaIndex = 2;
            this.fieldcdStore1.Caption = "cd Store";
            this.fieldcdStore1.FieldName = "cdStore";
            this.fieldcdStore1.Name = "fieldcdStore1";
            // 
            // fieldcdRegion1
            // 
            this.fieldcdRegion1.AreaIndex = 3;
            this.fieldcdRegion1.Caption = "cd Region";
            this.fieldcdRegion1.FieldName = "cdRegion";
            this.fieldcdRegion1.Name = "fieldcdRegion1";
            // 
            // fielddtOrder1
            // 
            this.fielddtOrder1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fielddtOrder1.AreaIndex = 0;
            this.fielddtOrder1.Caption = "dt Order";
            this.fielddtOrder1.FieldName = "dtOrder";
            this.fielddtOrder1.Name = "fielddtOrder1";
            // 
            // fieldvlDiscountTotal1
            // 
            this.fieldvlDiscountTotal1.AreaIndex = 4;
            this.fieldvlDiscountTotal1.Caption = "vl Discount Total";
            this.fieldvlDiscountTotal1.FieldName = "vlDiscountTotal";
            this.fieldvlDiscountTotal1.Name = "fieldvlDiscountTotal1";
            // 
            // fieldvlTotalOrder1
            // 
            this.fieldvlTotalOrder1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldvlTotalOrder1.AreaIndex = 0;
            this.fieldvlTotalOrder1.Caption = "vl Total Order";
            this.fieldvlTotalOrder1.FieldName = "vlTotalOrder";
            this.fieldvlTotalOrder1.Name = "fieldvlTotalOrder1";
            // 
            // fieldvlTotalUnit1
            // 
            this.fieldvlTotalUnit1.AreaIndex = 5;
            this.fieldvlTotalUnit1.Caption = "vl Total Unit";
            this.fieldvlTotalUnit1.FieldName = "vlTotalUnit";
            this.fieldvlTotalUnit1.Name = "fieldvlTotalUnit1";
            // 
            // fieldcdRoute1
            // 
            this.fieldcdRoute1.AreaIndex = 6;
            this.fieldcdRoute1.Caption = "cd Route";
            this.fieldcdRoute1.FieldName = "cdRoute";
            this.fieldcdRoute1.Name = "fieldcdRoute1";
            // 
            // fieldcdStatusOrder1
            // 
            this.fieldcdStatusOrder1.AreaIndex = 7;
            this.fieldcdStatusOrder1.Caption = "cd Status Order";
            this.fieldcdStatusOrder1.FieldName = "cdStatusOrder";
            this.fieldcdStatusOrder1.Name = "fieldcdStatusOrder1";
            // 
            // fieldcdInvoice1
            // 
            this.fieldcdInvoice1.AreaIndex = 8;
            this.fieldcdInvoice1.Caption = "cd Invoice";
            this.fieldcdInvoice1.FieldName = "cdInvoice";
            this.fieldcdInvoice1.Name = "fieldcdInvoice1";
            // 
            // fielddsDisplayText1
            // 
            this.fielddsDisplayText1.AreaIndex = 9;
            this.fielddsDisplayText1.Caption = "ds Display Text";
            this.fielddsDisplayText1.FieldName = "dsDisplayText";
            this.fielddsDisplayText1.Name = "fielddsDisplayText1";
            // 
            // fielddtInvoice1
            // 
            this.fielddtInvoice1.AreaIndex = 10;
            this.fielddtInvoice1.Caption = "dt Invoice";
            this.fielddtInvoice1.FieldName = "dtInvoice";
            this.fielddtInvoice1.Name = "fielddtInvoice1";
            // 
            // fieldvlTotalInvoice1
            // 
            this.fieldvlTotalInvoice1.AreaIndex = 11;
            this.fieldvlTotalInvoice1.Caption = "vl Total Invoice";
            this.fieldvlTotalInvoice1.FieldName = "vlTotalInvoice";
            this.fieldvlTotalInvoice1.Name = "fieldvlTotalInvoice1";
            // 
            // fieldnrTotalQuantity1
            // 
            this.fieldnrTotalQuantity1.AreaIndex = 12;
            this.fieldnrTotalQuantity1.Caption = "nr Total Quantity";
            this.fieldnrTotalQuantity1.FieldName = "nrTotalQuantity";
            this.fieldnrTotalQuantity1.Name = "fieldnrTotalQuantity1";
            // 
            // fieldcdStatusInvoice1
            // 
            this.fieldcdStatusInvoice1.AreaIndex = 13;
            this.fieldcdStatusInvoice1.Caption = "cd Status Invoice";
            this.fieldcdStatusInvoice1.FieldName = "cdStatusInvoice";
            this.fieldcdStatusInvoice1.Name = "fieldcdStatusInvoice1";
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl",
            "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl"});
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel1.ID = new System.Guid("20b2beb4-8dcf-456c-ab7c-a18da1f907f0");
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel1.SavedSizeFactor = 0D;
            this.dockPanel1.Size = new System.Drawing.Size(200, 427);
            this.dockPanel1.Text = "dockPanel1";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.layoutControl1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(3, 30);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(193, 394);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.BUSCAR);
            this.layoutControl1.Controls.Add(this.dateEdit2);
            this.layoutControl1.Controls.Add(this.dateEdit1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(307, 362, 650, 400);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(193, 394);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem2});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(193, 394);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(12, 28);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Size = new System.Drawing.Size(169, 20);
            this.dateEdit1.StyleController = this.layoutControl1;
            this.dateEdit1.TabIndex = 4;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.dateEdit1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(173, 40);
            this.layoutControlItem1.Text = "Fecha Inicio:";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(59, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 106);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(173, 268);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // dateEdit2
            // 
            this.dateEdit2.EditValue = null;
            this.dateEdit2.Location = new System.Drawing.Point(12, 68);
            this.dateEdit2.Name = "dateEdit2";
            this.dateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Size = new System.Drawing.Size(169, 20);
            this.dateEdit2.StyleController = this.layoutControl1;
            this.dateEdit2.TabIndex = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.dateEdit2;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 40);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(173, 40);
            this.layoutControlItem2.Text = "Fecha Fin:";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(59, 13);
            // 
            // BUSCAR
            // 
            this.BUSCAR.Location = new System.Drawing.Point(98, 92);
            this.BUSCAR.Name = "BUSCAR";
            this.BUSCAR.Size = new System.Drawing.Size(83, 22);
            this.BUSCAR.StyleController = this.layoutControl1;
            this.BUSCAR.TabIndex = 6;
            this.BUSCAR.Text = "Buscar";
            this.BUSCAR.Click += new System.EventHandler(this.BUSCAR_Click);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.BUSCAR;
            this.layoutControlItem3.Location = new System.Drawing.Point(86, 80);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(87, 26);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 80);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(86, 26);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // UnileverDms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 427);
            this.Controls.Add(this.pivotGridControl1);
            this.Controls.Add(this.dockPanel1);
            this.Name = "UnileverDms";
            this.Text = "UnileverDms";
            this.Load += new System.EventHandler(this.UnileverDms_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lider2018DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraPivotGrid.PivotGridControl pivotGridControl1;
        private Lider2018DataSet lider2018DataSet1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldcdOrder1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldcdCreationUser1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldcdStore1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldcdRegion1;
        private DevExpress.XtraPivotGrid.PivotGridField fielddtOrder1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldvlDiscountTotal1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldvlTotalOrder1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldvlTotalUnit1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldcdRoute1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldcdStatusOrder1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldcdInvoice1;
        private DevExpress.XtraPivotGrid.PivotGridField fielddsDisplayText1;
        private DevExpress.XtraPivotGrid.PivotGridField fielddtInvoice1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldvlTotalInvoice1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldnrTotalQuantity1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldcdStatusInvoice1;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.DateEdit dateEdit2;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton BUSCAR;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
    }
}