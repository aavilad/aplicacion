namespace xtraForm.Modulos.Elementos
{
    partial class frmClienteDireccion
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
            this.Direccion = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.Cancelar = new DevExpress.XtraEditors.SimpleButton();
            this.Aceptar = new DevExpress.XtraEditors.SimpleButton();
            this.Distrito = new DevExpress.XtraEditors.LookUpEdit();
            this.Provincia = new DevExpress.XtraEditors.LookUpEdit();
            this.Departamento = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.Direccion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Distrito.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Provincia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Departamento.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Direccion
            // 
            this.Direccion.Location = new System.Drawing.Point(86, 10);
            this.Direccion.Name = "Direccion";
            this.Direccion.Properties.Mask.EditMask = "\\p{Lu}+";
            this.Direccion.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.Direccion.Size = new System.Drawing.Size(312, 20);
            this.Direccion.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(8, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(45, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Direccion";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(8, 39);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Distrito";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(8, 65);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(44, 13);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Provincia";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(8, 91);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(70, 13);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "Departamento";
            // 
            // Cancelar
            // 
            this.Cancelar.Location = new System.Drawing.Point(320, 117);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(75, 23);
            this.Cancelar.TabIndex = 8;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.Click += new System.EventHandler(this.Cancelar_Click);
            // 
            // Aceptar
            // 
            this.Aceptar.Location = new System.Drawing.Point(233, 117);
            this.Aceptar.Name = "Aceptar";
            this.Aceptar.Size = new System.Drawing.Size(75, 23);
            this.Aceptar.TabIndex = 9;
            this.Aceptar.Text = "Aceptar";
            this.Aceptar.Click += new System.EventHandler(this.Aceptar_Click);
            // 
            // Distrito
            // 
            this.Distrito.Location = new System.Drawing.Point(86, 36);
            this.Distrito.Name = "Distrito";
            this.Distrito.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Distrito.Properties.NullText = "";
            this.Distrito.Size = new System.Drawing.Size(312, 20);
            this.Distrito.TabIndex = 2;
            // 
            // Provincia
            // 
            this.Provincia.Location = new System.Drawing.Point(86, 62);
            this.Provincia.Name = "Provincia";
            this.Provincia.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Provincia.Properties.NullText = "";
            this.Provincia.Size = new System.Drawing.Size(312, 20);
            this.Provincia.TabIndex = 4;
            // 
            // Departamento
            // 
            this.Departamento.Location = new System.Drawing.Point(86, 88);
            this.Departamento.Name = "Departamento";
            this.Departamento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Departamento.Properties.NullText = "";
            this.Departamento.Size = new System.Drawing.Size(312, 20);
            this.Departamento.TabIndex = 6;
            // 
            // frmClienteDireccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 148);
            this.Controls.Add(this.Aceptar);
            this.Controls.Add(this.Cancelar);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.Direccion);
            this.Controls.Add(this.Distrito);
            this.Controls.Add(this.Provincia);
            this.Controls.Add(this.Departamento);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmClienteDireccion";
            this.Load += new System.EventHandler(this.frmClienteDireccion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Direccion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Distrito.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Provincia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Departamento.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit Direccion;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton Cancelar;
        private DevExpress.XtraEditors.SimpleButton Aceptar;
        private DevExpress.XtraEditors.LookUpEdit Distrito;
        private DevExpress.XtraEditors.LookUpEdit Provincia;
        private DevExpress.XtraEditors.LookUpEdit Departamento;
    }
}