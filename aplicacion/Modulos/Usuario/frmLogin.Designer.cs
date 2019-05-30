using System.Windows.Forms;

namespace xtraForm.Modulos.Usuario
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.UsuarioID = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.UsuarioPass = new DevExpress.XtraEditors.TextEdit();
            this.Entrar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.UsuarioID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsuarioPass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // UsuarioID
            // 
            this.UsuarioID.Location = new System.Drawing.Point(22, 78);
            this.UsuarioID.Name = "UsuarioID";
            this.UsuarioID.Properties.ContextImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("UsuarioID.Properties.ContextImageOptions.Image")));
            this.UsuarioID.Size = new System.Drawing.Size(169, 20);
            this.UsuarioID.TabIndex = 5;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "Campo usuario no puede permanecer vacio";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information;
            this.dxValidationProvider1.SetValidationRule(this.UsuarioID, conditionValidationRule2);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(22, 111);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(58, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Contraseña:";
            // 
            // UsuarioPass
            // 
            this.UsuarioPass.Location = new System.Drawing.Point(22, 130);
            this.UsuarioPass.Name = "UsuarioPass";
            this.UsuarioPass.Properties.ContextImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("UsuarioPass.Properties.ContextImageOptions.Image")));
            this.UsuarioPass.Properties.UseSystemPasswordChar = true;
            this.UsuarioPass.Size = new System.Drawing.Size(169, 20);
            this.UsuarioPass.TabIndex = 6;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule3.ErrorText = "Campo contraseña no puede permanecer vacio";
            conditionValidationRule3.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information;
            this.dxValidationProvider1.SetValidationRule(this.UsuarioPass, conditionValidationRule3);
            // 
            // Entrar
            // 
            this.Entrar.Location = new System.Drawing.Point(116, 185);
            this.Entrar.Name = "Entrar";
            this.Entrar.Size = new System.Drawing.Size(75, 23);
            this.Entrar.TabIndex = 4;
            this.Entrar.Text = "Entrar";
            this.Entrar.Click += new System.EventHandler(this.Entrar_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(22, 55);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Usuario:";
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(213, 228);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.UsuarioPass);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.Entrar);
            this.Controls.Add(this.UsuarioID);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.UsuarioID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsuarioPass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit UsuarioID;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit UsuarioPass;
        private DevExpress.XtraEditors.SimpleButton Entrar;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
    }
}