﻿namespace xtraForm.Modulos.Distribucion
{
    partial class frmAsignacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAsignacion));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MenuPrincipal = new DevExpress.XtraBars.PopupMenu(this.components);
            this.NUEVO = new DevExpress.XtraBars.BarButtonItem();
            this.MODIFICAR = new DevExpress.XtraBars.BarButtonItem();
            this.ELIMINAR = new DevExpress.XtraBars.BarButtonItem();
            this.FILTRO = new DevExpress.XtraBars.BarButtonItem();
            this.REFRESH = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MenuPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(630, 245);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FooterPanel.Font = new System.Drawing.Font("Calibri", 6.75F);
            this.gridView1.Appearance.FooterPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridView1.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.AppearancePrint.FooterPanel.Font = new System.Drawing.Font("Calibri", 6.75F);
            this.gridView1.AppearancePrint.FooterPanel.Options.UseFont = true;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 20;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowIncrementalSearch = true;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsHint.ShowFooterHints = false;
            this.gridView1.OptionsMenu.ShowConditionalFormattingItem = true;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.GridView1_PopupMenuShowing);
            this.gridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GridView1_KeyPress);
            this.gridView1.DoubleClick += new System.EventHandler(this.GridView1_DoubleClick);
            // 
            // MenuPrincipal
            // 
            this.MenuPrincipal.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.NUEVO),
            new DevExpress.XtraBars.LinkPersistInfo(this.MODIFICAR),
            new DevExpress.XtraBars.LinkPersistInfo(this.ELIMINAR),
            new DevExpress.XtraBars.LinkPersistInfo(this.FILTRO),
            new DevExpress.XtraBars.LinkPersistInfo(this.REFRESH)});
            this.MenuPrincipal.Manager = this.barManager1;
            this.MenuPrincipal.Name = "MenuPrincipal";
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
            // REFRESH
            // 
            this.REFRESH.Caption = "Refrescar";
            this.REFRESH.Id = 4;
            this.REFRESH.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("REFRESH.ImageOptions.SvgImage")));
            this.REFRESH.Name = "REFRESH";
            this.REFRESH.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.REFRESH_ItemClick);
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
            this.REFRESH});
            this.barManager1.MaxItemId = 5;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(630, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 245);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(630, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 245);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(630, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 245);
            // 
            // frmAsignacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 245);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmAsignacion";
            this.Text = "frmAsignacion";
            this.Load += new System.EventHandler(this.FrmAsignacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MenuPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.PopupMenu MenuPrincipal;
        private DevExpress.XtraBars.BarButtonItem MODIFICAR;
        private DevExpress.XtraBars.BarButtonItem NUEVO;
        private DevExpress.XtraBars.BarButtonItem ELIMINAR;
        private DevExpress.XtraBars.BarButtonItem FILTRO;
        private DevExpress.XtraBars.BarButtonItem REFRESH;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
    }
}