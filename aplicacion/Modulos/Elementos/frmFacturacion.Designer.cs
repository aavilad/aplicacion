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
            this.checkEdit2 = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.CheckRuta = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.FechaProceso = new DevExpress.XtraEditors.DateEdit();
            this.RutaReparto = new DevExpress.XtraEditors.LookUpEdit();
            this.BtnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.BtnAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.Vendedor = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckRuta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FechaProceso.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FechaProceso.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RutaReparto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vendedor.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // checkEdit2
            // 
            this.checkEdit2.Location = new System.Drawing.Point(22, 110);
            this.checkEdit2.Name = "checkEdit2";
            this.checkEdit2.Properties.Caption = "Generar canje por vendedor";
            this.checkEdit2.Size = new System.Drawing.Size(191, 20);
            this.checkEdit2.TabIndex = 16;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(70, 136);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(49, 13);
            this.labelControl3.TabIndex = 14;
            this.labelControl3.Text = "Vendedor:";
            // 
            // CheckRuta
            // 
            this.CheckRuta.Location = new System.Drawing.Point(22, 49);
            this.CheckRuta.Name = "CheckRuta";
            this.CheckRuta.Properties.Caption = "Generar canje por ruta de reparto";
            this.CheckRuta.Size = new System.Drawing.Size(191, 20);
            this.CheckRuta.TabIndex = 13;
            this.CheckRuta.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(70, 79);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(77, 13);
            this.labelControl2.TabIndex = 11;
            this.labelControl2.Text = "Ruta de reparto:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(22, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(87, 13);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "Fecha de proceso :";
            // 
            // FechaProceso
            // 
            this.FechaProceso.EditValue = null;
            this.FechaProceso.Location = new System.Drawing.Point(128, 12);
            this.FechaProceso.Name = "FechaProceso";
            this.FechaProceso.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FechaProceso.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FechaProceso.Size = new System.Drawing.Size(120, 20);
            this.FechaProceso.TabIndex = 9;
            // 
            // RutaReparto
            // 
            this.RutaReparto.Location = new System.Drawing.Point(152, 75);
            this.RutaReparto.Name = "RutaReparto";
            this.RutaReparto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RutaReparto.Properties.DisplayFormat.FormatString = "d";
            this.RutaReparto.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.RutaReparto.Properties.EditFormat.FormatString = "d";
            this.RutaReparto.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.RutaReparto.Properties.NullText = "";
            this.RutaReparto.Size = new System.Drawing.Size(246, 20);
            this.RutaReparto.TabIndex = 12;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(323, 166);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(75, 23);
            this.BtnCancelar.TabIndex = 17;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Location = new System.Drawing.Point(242, 166);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(75, 23);
            this.BtnAceptar.TabIndex = 18;
            this.BtnAceptar.Text = "Aceptar";
            // 
            // Vendedor
            // 
            this.Vendedor.Location = new System.Drawing.Point(152, 132);
            this.Vendedor.Name = "Vendedor";
            this.Vendedor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Vendedor.Properties.DisplayFormat.FormatString = "d";
            this.Vendedor.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.Vendedor.Properties.EditFormat.FormatString = "d";
            this.Vendedor.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.Vendedor.Size = new System.Drawing.Size(246, 20);
            this.Vendedor.TabIndex = 15;
            // 
            // frmFacturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 201);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.checkEdit2);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.CheckRuta);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.FechaProceso);
            this.Controls.Add(this.RutaReparto);
            this.Controls.Add(this.Vendedor);
            this.MaximizeBox = false;
            this.Name = "frmFacturacion";
            this.Load += new System.EventHandler(this.frmFacturacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckRuta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FechaProceso.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FechaProceso.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RutaReparto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vendedor.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit checkEdit2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.CheckEdit CheckRuta;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit FechaProceso;
        private DevExpress.XtraEditors.LookUpEdit RutaReparto;
        private DevExpress.XtraEditors.SimpleButton BtnCancelar;
        private DevExpress.XtraEditors.SimpleButton BtnAceptar;
        private DevExpress.XtraEditors.CheckedComboBoxEdit Vendedor;
    }
}