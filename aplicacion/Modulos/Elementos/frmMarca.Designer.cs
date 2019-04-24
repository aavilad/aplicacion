namespace xtraForm.Modulos.Elementos
{
    partial class frmMarca
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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule6 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule7 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule4 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtMarcaCodigo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtMarcaAbreviacion = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.BtnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.BtnAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.txtMarcaProveedor = new DevExpress.XtraEditors.LookUpEdit();
            this.txtMarcaLinea = new DevExpress.XtraEditors.LookUpEdit();
            this.txtMarcaDescripcion = new DevExpress.XtraEditors.TextEdit();
            this.txtMarcaOrden = new DevExpress.XtraEditors.SpinEdit();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtMarcaCodigo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMarcaAbreviacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMarcaProveedor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMarcaLinea.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMarcaDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMarcaOrden.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(4, 84);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(59, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Descripcion:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(4, 8);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(35, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Codigo:";
            // 
            // txtMarcaCodigo
            // 
            this.txtMarcaCodigo.Location = new System.Drawing.Point(69, 5);
            this.txtMarcaCodigo.Name = "txtMarcaCodigo";
            this.txtMarcaCodigo.Size = new System.Drawing.Size(113, 20);
            this.txtMarcaCodigo.TabIndex = 2;
            conditionValidationRule6.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule6.ErrorText = "This value is not valid";
            conditionValidationRule6.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information;
            this.dxValidationProvider1.SetValidationRule(this.txtMarcaCodigo, conditionValidationRule6);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(4, 32);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(52, 13);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "Proveedor:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(4, 58);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(29, 13);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Linea:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(4, 110);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(59, 13);
            this.labelControl5.TabIndex = 9;
            this.labelControl5.Text = "Abreviacion:";
            // 
            // txtMarcaAbreviacion
            // 
            this.txtMarcaAbreviacion.Location = new System.Drawing.Point(69, 105);
            this.txtMarcaAbreviacion.Name = "txtMarcaAbreviacion";
            this.txtMarcaAbreviacion.Size = new System.Drawing.Size(326, 20);
            this.txtMarcaAbreviacion.TabIndex = 8;
            conditionValidationRule7.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule7.ErrorText = "This value is not valid";
            conditionValidationRule7.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information;
            this.dxValidationProvider1.SetValidationRule(this.txtMarcaAbreviacion, conditionValidationRule7);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(232, 8);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(32, 13);
            this.labelControl6.TabIndex = 11;
            this.labelControl6.Text = "Orden:";
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(320, 131);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(75, 23);
            this.BtnCancelar.TabIndex = 12;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Location = new System.Drawing.Point(232, 131);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(75, 23);
            this.BtnAceptar.TabIndex = 13;
            this.BtnAceptar.Text = "Aceptar";
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // txtMarcaProveedor
            // 
            this.txtMarcaProveedor.Location = new System.Drawing.Point(69, 30);
            this.txtMarcaProveedor.Name = "txtMarcaProveedor";
            this.txtMarcaProveedor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtMarcaProveedor.Properties.NullText = "";
            this.txtMarcaProveedor.Size = new System.Drawing.Size(326, 20);
            this.txtMarcaProveedor.TabIndex = 6;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "This value is not valid";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information;
            this.dxValidationProvider1.SetValidationRule(this.txtMarcaProveedor, conditionValidationRule1);
            // 
            // txtMarcaLinea
            // 
            this.txtMarcaLinea.Location = new System.Drawing.Point(69, 55);
            this.txtMarcaLinea.Name = "txtMarcaLinea";
            this.txtMarcaLinea.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtMarcaLinea.Properties.NullText = "";
            this.txtMarcaLinea.Size = new System.Drawing.Size(326, 20);
            this.txtMarcaLinea.TabIndex = 4;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "This value is not valid";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information;
            this.dxValidationProvider1.SetValidationRule(this.txtMarcaLinea, conditionValidationRule2);
            // 
            // txtMarcaDescripcion
            // 
            this.txtMarcaDescripcion.Location = new System.Drawing.Point(69, 80);
            this.txtMarcaDescripcion.Name = "txtMarcaDescripcion";
            this.txtMarcaDescripcion.Size = new System.Drawing.Size(326, 20);
            this.txtMarcaDescripcion.TabIndex = 0;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule3.ErrorText = "This value is not valid";
            conditionValidationRule3.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information;
            this.dxValidationProvider1.SetValidationRule(this.txtMarcaDescripcion, conditionValidationRule3);
            // 
            // txtMarcaOrden
            // 
            this.txtMarcaOrden.Location = new System.Drawing.Point(282, 5);
            this.txtMarcaOrden.Name = "txtMarcaOrden";
            this.txtMarcaOrden.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtMarcaOrden.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.txtMarcaOrden.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txtMarcaOrden.Size = new System.Drawing.Size(113, 20);
            this.txtMarcaOrden.TabIndex = 10;
            conditionValidationRule4.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule4.ErrorText = "This value is not valid";
            conditionValidationRule4.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information;
            this.dxValidationProvider1.SetValidationRule(this.txtMarcaOrden, conditionValidationRule4);
            // 
            // dxValidationProvider1
            // 
            this.dxValidationProvider1.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Manual;
            // 
            // frmMarca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 161);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.txtMarcaAbreviacion);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtMarcaCodigo);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtMarcaDescripcion);
            this.Controls.Add(this.txtMarcaProveedor);
            this.Controls.Add(this.txtMarcaLinea);
            this.Controls.Add(this.txtMarcaOrden);
            this.MaximizeBox = false;
            this.Name = "frmMarca";
            this.Load += new System.EventHandler(this.frmMarca_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtMarcaCodigo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMarcaAbreviacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMarcaProveedor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMarcaLinea.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMarcaDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMarcaOrden.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.SimpleButton BtnCancelar;
        private DevExpress.XtraEditors.SimpleButton BtnAceptar;
        public DevExpress.XtraEditors.TextEdit txtMarcaCodigo;
        public DevExpress.XtraEditors.TextEdit txtMarcaAbreviacion;
        public DevExpress.XtraEditors.TextEdit txtMarcaDescripcion;
        public DevExpress.XtraEditors.LookUpEdit txtMarcaProveedor;
        public DevExpress.XtraEditors.LookUpEdit txtMarcaLinea;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        public DevExpress.XtraEditors.SpinEdit txtMarcaOrden;
    }
}