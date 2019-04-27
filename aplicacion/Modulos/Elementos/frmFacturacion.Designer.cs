namespace xtraForm.Modulos.Elementos
{
    partial class frmFacturacion
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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.FechaProceso = new DevExpress.XtraEditors.DateEdit();
            this.BtnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.BtnAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.SerieBoletas = new DevExpress.XtraEditors.LookUpEdit();
            this.SerieFacturas = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.BtnFiltrar = new DevExpress.XtraEditors.SimpleButton();
            this.flRuta = new DevExpress.XtraEditors.CheckEdit();
            this.flVendedor = new DevExpress.XtraEditors.CheckEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.FCorrelativo = new DevExpress.XtraEditors.TextEdit();
            this.BCorrelativo = new DevExpress.XtraEditors.TextEdit();
            this.DescripcionB = new DevExpress.XtraEditors.TextEdit();
            this.DescripcionF = new DevExpress.XtraEditors.TextEdit();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.Gestion = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.FechaProceso.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FechaProceso.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SerieBoletas.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SerieFacturas.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flRuta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flVendedor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FCorrelativo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BCorrelativo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescripcionB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescripcionF.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gestion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 16);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(73, 13);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "Fecha emision :";
            // 
            // FechaProceso
            // 
            this.FechaProceso.EditValue = null;
            this.FechaProceso.Location = new System.Drawing.Point(111, 12);
            this.FechaProceso.Name = "FechaProceso";
            this.FechaProceso.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FechaProceso.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FechaProceso.Size = new System.Drawing.Size(128, 20);
            this.FechaProceso.TabIndex = 9;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.AnyOf;
            conditionValidationRule1.ErrorText = "fecha no puede queda vacia.";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information;
            this.dxValidationProvider1.SetValidationRule(this.FechaProceso, conditionValidationRule1);
            this.FechaProceso.EditValueChanged += new System.EventHandler(this.FechaProceso_EditValueChanged);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(304, 6);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(75, 23);
            this.BtnCancelar.TabIndex = 17;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Location = new System.Drawing.Point(223, 6);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(75, 23);
            this.BtnAceptar.TabIndex = 18;
            this.BtnAceptar.Text = "Aceptar";
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // SerieBoletas
            // 
            this.SerieBoletas.Location = new System.Drawing.Point(111, 80);
            this.SerieBoletas.Name = "SerieBoletas";
            this.SerieBoletas.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SerieBoletas.Properties.DisplayFormat.FormatString = "d";
            this.SerieBoletas.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.SerieBoletas.Properties.DropDownRows = 4;
            this.SerieBoletas.Properties.EditFormat.FormatString = "d";
            this.SerieBoletas.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.SerieBoletas.Properties.NullText = "";
            this.SerieBoletas.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.SerieBoletas.Size = new System.Drawing.Size(59, 20);
            this.SerieBoletas.TabIndex = 20;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "Serie de boletas no puede esdtar vacio.";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information;
            this.dxValidationProvider1.SetValidationRule(this.SerieBoletas, conditionValidationRule2);
            this.SerieBoletas.EditValueChanged += new System.EventHandler(this.SerieBoletas_EditValueChanged);
            // 
            // SerieFacturas
            // 
            this.SerieFacturas.Location = new System.Drawing.Point(111, 47);
            this.SerieFacturas.Name = "SerieFacturas";
            this.SerieFacturas.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SerieFacturas.Properties.DisplayFormat.FormatString = "d";
            this.SerieFacturas.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.SerieFacturas.Properties.DropDownRows = 4;
            this.SerieFacturas.Properties.EditFormat.FormatString = "d";
            this.SerieFacturas.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.SerieFacturas.Properties.NullText = "";
            this.SerieFacturas.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.SerieFacturas.Size = new System.Drawing.Size(59, 20);
            this.SerieFacturas.TabIndex = 21;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule3.ErrorText = "Serie facturas no debe estar vacio.";
            conditionValidationRule3.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information;
            this.dxValidationProvider1.SetValidationRule(this.SerieFacturas, conditionValidationRule3);
            this.SerieFacturas.EditValueChanged += new System.EventHandler(this.SerieFacturas_EditValueChanged);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 50);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(67, 13);
            this.labelControl4.TabIndex = 22;
            this.labelControl4.Text = "Serie Factura :";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(12, 84);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(62, 13);
            this.labelControl5.TabIndex = 23;
            this.labelControl5.Text = "Serie Boleta :";
            // 
            // BtnFiltrar
            // 
            this.BtnFiltrar.Location = new System.Drawing.Point(3, 423);
            this.BtnFiltrar.Name = "BtnFiltrar";
            this.BtnFiltrar.Size = new System.Drawing.Size(65, 23);
            this.BtnFiltrar.TabIndex = 27;
            this.BtnFiltrar.Text = "filtrar";
            this.BtnFiltrar.Click += new System.EventHandler(this.BtnFiltrar_Click);
            // 
            // flRuta
            // 
            this.flRuta.Location = new System.Drawing.Point(73, 424);
            this.flRuta.Name = "flRuta";
            this.flRuta.Properties.Caption = "Ruta";
            this.flRuta.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.flRuta.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.flRuta.Size = new System.Drawing.Size(62, 20);
            this.flRuta.TabIndex = 28;
            this.flRuta.CheckedChanged += new System.EventHandler(this.flRuta_CheckedChanged);
            // 
            // flVendedor
            // 
            this.flVendedor.Location = new System.Drawing.Point(141, 424);
            this.flVendedor.Name = "flVendedor";
            this.flVendedor.Properties.Caption = "Vendedor";
            this.flVendedor.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.flVendedor.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.flVendedor.Size = new System.Drawing.Size(75, 20);
            this.flVendedor.TabIndex = 29;
            this.flVendedor.CheckedChanged += new System.EventHandler(this.flVendedor_CheckedChanged);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.BtnCancelar);
            this.panelControl1.Controls.Add(this.BtnAceptar);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 458);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(382, 34);
            this.panelControl1.TabIndex = 30;
            // 
            // FCorrelativo
            // 
            this.FCorrelativo.Location = new System.Drawing.Point(176, 47);
            this.FCorrelativo.Name = "FCorrelativo";
            this.FCorrelativo.Size = new System.Drawing.Size(69, 20);
            this.FCorrelativo.TabIndex = 31;
            // 
            // BCorrelativo
            // 
            this.BCorrelativo.Location = new System.Drawing.Point(176, 80);
            this.BCorrelativo.Name = "BCorrelativo";
            this.BCorrelativo.Size = new System.Drawing.Size(69, 20);
            this.BCorrelativo.TabIndex = 32;
            // 
            // DescripcionB
            // 
            this.DescripcionB.Location = new System.Drawing.Point(251, 80);
            this.DescripcionB.Name = "DescripcionB";
            this.DescripcionB.Size = new System.Drawing.Size(127, 20);
            this.DescripcionB.TabIndex = 34;
            // 
            // DescripcionF
            // 
            this.DescripcionF.Location = new System.Drawing.Point(251, 47);
            this.DescripcionF.Name = "DescripcionF";
            this.DescripcionF.Size = new System.Drawing.Size(127, 20);
            this.DescripcionF.TabIndex = 33;
            // 
            // Gestion
            // 
            this.Gestion.Location = new System.Drawing.Point(304, 12);
            this.Gestion.Name = "Gestion";
            this.Gestion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Gestion.Properties.NullText = "";
            this.Gestion.Size = new System.Drawing.Size(73, 20);
            this.Gestion.TabIndex = 35;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(251, 16);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(42, 13);
            this.labelControl2.TabIndex = 36;
            this.labelControl2.Text = "Gestion :";
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(3, 106);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(375, 311);
            this.gridControl1.TabIndex = 37;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // frmFacturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 492);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.Gestion);
            this.Controls.Add(this.DescripcionB);
            this.Controls.Add(this.DescripcionF);
            this.Controls.Add(this.BCorrelativo);
            this.Controls.Add(this.FCorrelativo);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.flVendedor);
            this.Controls.Add(this.flRuta);
            this.Controls.Add(this.BtnFiltrar);
            this.Controls.Add(this.SerieFacturas);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.SerieBoletas);
            this.Controls.Add(this.FechaProceso);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(398, 530);
            this.MinimumSize = new System.Drawing.Size(398, 530);
            this.Name = "frmFacturacion";
            this.Load += new System.EventHandler(this.frmFacturacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FechaProceso.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FechaProceso.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SerieBoletas.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SerieFacturas.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flRuta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flVendedor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FCorrelativo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BCorrelativo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescripcionB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescripcionF.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gestion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit FechaProceso;
        private DevExpress.XtraEditors.SimpleButton BtnCancelar;
        private DevExpress.XtraEditors.SimpleButton BtnAceptar;
        private DevExpress.XtraEditors.LookUpEdit SerieBoletas;
        private DevExpress.XtraEditors.LookUpEdit SerieFacturas;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SimpleButton BtnFiltrar;
        private DevExpress.XtraEditors.CheckEdit flRuta;
        private DevExpress.XtraEditors.CheckEdit flVendedor;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit FCorrelativo;
        private DevExpress.XtraEditors.TextEdit BCorrelativo;
        private DevExpress.XtraEditors.TextEdit DescripcionB;
        private DevExpress.XtraEditors.TextEdit DescripcionF;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraEditors.LookUpEdit Gestion;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}