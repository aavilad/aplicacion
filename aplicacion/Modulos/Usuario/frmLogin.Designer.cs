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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.UsuarioID = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.UsuarioPass = new DevExpress.XtraEditors.TextEdit();
            this.Entrar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.Validar = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.Scm02 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::xtraForm.ProgresoLogin), true, true);
            ((System.ComponentModel.ISupportInitialize)(this.UsuarioID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsuarioPass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Validar)).BeginInit();
            this.SuspendLayout();
            // 
            // UsuarioID
            // 
            this.UsuarioID.Location = new System.Drawing.Point(22, 62);
            this.UsuarioID.Name = "UsuarioID";
            this.UsuarioID.Properties.ContextImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("UsuarioID.Properties.ContextImageOptions.SvgImage")));
            this.UsuarioID.Properties.ContextImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.UsuarioID.Size = new System.Drawing.Size(169, 24);
            this.UsuarioID.TabIndex = 5;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "Campo usuario no puede permanecer vacio";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information;
            this.Validar.SetValidationRule(this.UsuarioID, conditionValidationRule1);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(22, 103);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(58, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Contraseña:";
            // 
            // UsuarioPass
            // 
            this.UsuarioPass.Location = new System.Drawing.Point(22, 127);
            this.UsuarioPass.Name = "UsuarioPass";
            this.UsuarioPass.Properties.ContextImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("UsuarioPass.Properties.ContextImageOptions.SvgImage")));
            this.UsuarioPass.Properties.ContextImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.UsuarioPass.Properties.UseSystemPasswordChar = true;
            this.UsuarioPass.Size = new System.Drawing.Size(169, 24);
            this.UsuarioPass.TabIndex = 6;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "Campo contraseña no puede permanecer vacio";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information;
            this.Validar.SetValidationRule(this.UsuarioPass, conditionValidationRule2);
            // 
            // Entrar
            // 
            this.Entrar.Location = new System.Drawing.Point(116, 177);
            this.Entrar.Name = "Entrar";
            this.Entrar.Size = new System.Drawing.Size(75, 31);
            this.Entrar.TabIndex = 4;
            this.Entrar.Text = "Entrar";
            this.Entrar.Click += new System.EventHandler(this.Entrar_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(22, 36);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Usuario:";
            // 
            // Scm02
            // 
            this.Scm02.ClosingDelay = 500;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(213, 227);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.UsuarioPass);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.Entrar);
            this.Controls.Add(this.UsuarioID);
            this.HelpButton = true;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(229, 266);
            this.MinimumSize = new System.Drawing.Size(213, 257);
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.UsuarioID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsuarioPass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Validar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit UsuarioID;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit UsuarioPass;
        private DevExpress.XtraEditors.SimpleButton Entrar;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider Validar;
        private DevExpress.XtraSplashScreen.SplashScreenManager Scm02;
    }
}