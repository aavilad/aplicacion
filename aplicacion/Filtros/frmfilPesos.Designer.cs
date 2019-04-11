namespace xtraForm.Filtros
{
    partial class frmfilPesos
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
            this.fechaproceso = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.checkButton1 = new DevExpress.XtraEditors.CheckButton();
            this.txtcadena = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.checkprocesado = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaproceso.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaproceso.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcadena.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkprocesado.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // fechaproceso
            // 
            this.fechaproceso.EditValue = null;
            this.fechaproceso.Location = new System.Drawing.Point(93, 9);
            this.fechaproceso.Name = "fechaproceso";
            this.fechaproceso.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaproceso.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaproceso.Size = new System.Drawing.Size(117, 20);
            this.fechaproceso.TabIndex = 0;
            this.fechaproceso.EditValueChanged += new System.EventHandler(this.dateEdit1_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(67, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Fecha Emision";
            this.labelControl1.Click += new System.EventHandler(this.labelControl1_Click);
            // 
            // checkButton1
            // 
            this.checkButton1.Checked = true;
            this.checkButton1.Location = new System.Drawing.Point(12, 31);
            this.checkButton1.Name = "checkButton1";
            this.checkButton1.Size = new System.Drawing.Size(75, 20);
            this.checkButton1.TabIndex = 2;
            this.checkButton1.CheckedChanged += new System.EventHandler(this.checkButton1_CheckedChanged);
            // 
            // txtcadena
            // 
            this.txtcadena.Location = new System.Drawing.Point(93, 31);
            this.txtcadena.Name = "txtcadena";
            this.txtcadena.Size = new System.Drawing.Size(75, 20);
            this.txtcadena.TabIndex = 3;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(153, 54);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(57, 23);
            this.simpleButton1.TabIndex = 4;
            this.simpleButton1.Text = "Aceptar";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(93, 54);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(57, 23);
            this.simpleButton2.TabIndex = 5;
            this.simpleButton2.Text = "Cancelar";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // checkprocesado
            // 
            this.checkprocesado.Location = new System.Drawing.Point(12, 56);
            this.checkprocesado.Name = "checkprocesado";
            this.checkprocesado.Properties.Caption = "Procesado";
            this.checkprocesado.Size = new System.Drawing.Size(75, 20);
            this.checkprocesado.TabIndex = 6;
            // 
            // frmfilPesos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 88);
            this.Controls.Add(this.checkprocesado);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.txtcadena);
            this.Controls.Add(this.checkButton1);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.fechaproceso);
            this.Name = "frmfilPesos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmfilPesos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fechaproceso.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaproceso.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcadena.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkprocesado.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckButton checkButton1;
        public DevExpress.XtraEditors.DateEdit fechaproceso;
        public DevExpress.XtraEditors.TextEdit txtcadena;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.CheckEdit checkprocesado;
    }
}