namespace xtraForm.Modulos.Ventas
{
    partial class frmPedido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPedido));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.NUEVO = new DevExpress.XtraBars.BarButtonItem();
            this.MODIFICAR = new DevExpress.XtraBars.BarButtonItem();
            this.ELIMINAR = new DevExpress.XtraBars.BarButtonItem();
            this.FILTRO = new DevExpress.XtraBars.BarButtonItem();
            this.DESCARGAR = new DevExpress.XtraBars.BarButtonItem();
            this.APROBAR = new DevExpress.XtraBars.BarButtonItem();
            this.DESAPROBAR = new DevExpress.XtraBars.BarButtonItem();
            this.COPIAR = new DevExpress.XtraBars.BarButtonItem();
            this.REFRESH = new DevExpress.XtraBars.BarButtonItem();
            this.FACTURAR = new DevExpress.XtraBars.BarButtonItem();
            this.FACTURACIONLOTE = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(713, 315);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridControl1_KeyPress);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FooterPanel.Font = new System.Drawing.Font("Calibri", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.FooterPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView1.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.AppearancePrint.FooterPanel.Font = new System.Drawing.Font("Calibri", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.AppearancePrint.FooterPanel.Options.UseFont = true;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 45;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowIncrementalSearch = true;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsHint.ShowFooterHints = false;
            this.gridView1.OptionsMenu.ShowConditionalFormattingItem = true;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.UseIndicatorForSelection = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.GridView1_CustomDrawRowIndicator);
            this.gridView1.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridView1_PopupMenuShowing);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.NUEVO),
            new DevExpress.XtraBars.LinkPersistInfo(this.MODIFICAR),
            new DevExpress.XtraBars.LinkPersistInfo(this.ELIMINAR),
            new DevExpress.XtraBars.LinkPersistInfo(this.FILTRO),
            new DevExpress.XtraBars.LinkPersistInfo(this.DESCARGAR),
            new DevExpress.XtraBars.LinkPersistInfo(this.APROBAR),
            new DevExpress.XtraBars.LinkPersistInfo(this.DESAPROBAR),
            new DevExpress.XtraBars.LinkPersistInfo(this.COPIAR),
            new DevExpress.XtraBars.LinkPersistInfo(this.REFRESH),
            new DevExpress.XtraBars.LinkPersistInfo(this.FACTURAR),
            new DevExpress.XtraBars.LinkPersistInfo(this.FACTURACIONLOTE)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // NUEVO
            // 
            this.NUEVO.Caption = "Nuevo";
            this.NUEVO.Id = 0;
            this.NUEVO.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("NUEVO.ImageOptions.SvgImage")));
            this.NUEVO.Name = "NUEVO";
            this.NUEVO.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.NUEVO_ItemClick);
            // 
            // MODIFICAR
            // 
            this.MODIFICAR.Caption = "Modificar";
            this.MODIFICAR.Id = 1;
            this.MODIFICAR.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("MODIFICAR.ImageOptions.SvgImage")));
            this.MODIFICAR.Name = "MODIFICAR";
            this.MODIFICAR.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.MODIFICAR_ItemClick);
            // 
            // ELIMINAR
            // 
            this.ELIMINAR.Caption = "Eliminar";
            this.ELIMINAR.Id = 2;
            this.ELIMINAR.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("ELIMINAR.ImageOptions.SvgImage")));
            this.ELIMINAR.Name = "ELIMINAR";
            this.ELIMINAR.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ELIMINAR_ItemClick);
            // 
            // FILTRO
            // 
            this.FILTRO.Caption = "Filtro";
            this.FILTRO.Id = 3;
            this.FILTRO.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("FILTRO.ImageOptions.SvgImage")));
            this.FILTRO.Name = "FILTRO";
            this.FILTRO.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.FILTRO_ItemClick);
            // 
            // DESCARGAR
            // 
            this.DESCARGAR.Caption = "Descargar";
            this.DESCARGAR.Id = 4;
            this.DESCARGAR.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("DESCARGAR.ImageOptions.SvgImage")));
            this.DESCARGAR.Name = "DESCARGAR";
            this.DESCARGAR.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.DESCARGAR_ItemClick);
            // 
            // APROBAR
            // 
            this.APROBAR.Caption = "Aprobar";
            this.APROBAR.Id = 6;
            this.APROBAR.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("APROBAR.ImageOptions.SvgImage")));
            this.APROBAR.Name = "APROBAR";
            this.APROBAR.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.APROBAR_ItemClick);
            // 
            // DESAPROBAR
            // 
            this.DESAPROBAR.Caption = "Desaprobar";
            this.DESAPROBAR.Id = 7;
            this.DESAPROBAR.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("DESAPROBAR.ImageOptions.SvgImage")));
            this.DESAPROBAR.Name = "DESAPROBAR";
            this.DESAPROBAR.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.DESAPROBAR_ItemClick);
            // 
            // COPIAR
            // 
            this.COPIAR.Caption = "Copiar";
            this.COPIAR.Id = 8;
            this.COPIAR.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("COPIAR.ImageOptions.SvgImage")));
            this.COPIAR.Name = "COPIAR";
            this.COPIAR.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.COPIAR_ItemClick);
            // 
            // REFRESH
            // 
            this.REFRESH.Caption = "Refrescar";
            this.REFRESH.Id = 9;
            this.REFRESH.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("REFRESH.ImageOptions.SvgImage")));
            this.REFRESH.Name = "REFRESH";
            this.REFRESH.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.REFRESH_ItemClick);
            // 
            // FACTURAR
            // 
            this.FACTURAR.Caption = "Facturar";
            this.FACTURAR.Id = 5;
            this.FACTURAR.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("FACTURAR.ImageOptions.SvgImage")));
            this.FACTURAR.Name = "FACTURAR";
            this.FACTURAR.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.FACTURAR_ItemClick);
            // 
            // FACTURACIONLOTE
            // 
            this.FACTURACIONLOTE.Caption = "Facturacion en lote";
            this.FACTURACIONLOTE.Id = 10;
            this.FACTURACIONLOTE.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("FACTURACIONLOTE.ImageOptions.SvgImage")));
            this.FACTURACIONLOTE.Name = "FACTURACIONLOTE";
            this.FACTURACIONLOTE.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.FACTURACIONLOTE_ItemClick);
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.NUEVO,
            this.MODIFICAR,
            this.ELIMINAR,
            this.FILTRO,
            this.DESCARGAR,
            this.FACTURAR,
            this.APROBAR,
            this.DESAPROBAR,
            this.COPIAR,
            this.REFRESH,
            this.FACTURACIONLOTE});
            this.barManager1.MaxItemId = 12;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(713, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 315);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(713, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 315);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(713, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 315);
            // 
            // frmPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 315);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmPedido";
            this.Text = "frmPedido";
            this.Load += new System.EventHandler(this.frmPedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarButtonItem NUEVO;
        private DevExpress.XtraBars.BarButtonItem MODIFICAR;
        private DevExpress.XtraBars.BarButtonItem ELIMINAR;
        private DevExpress.XtraBars.BarButtonItem FILTRO;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem DESCARGAR;
        private DevExpress.XtraBars.BarButtonItem FACTURAR;
        private DevExpress.XtraBars.BarButtonItem APROBAR;
        private DevExpress.XtraBars.BarButtonItem DESAPROBAR;
        private DevExpress.XtraBars.BarButtonItem COPIAR;
        private DevExpress.XtraBars.BarButtonItem REFRESH;
        private DevExpress.XtraBars.BarButtonItem FACTURACIONLOTE;
    }
}