namespace xtraForm.Modulos.Elementos
{
    partial class frmSucursal
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.ESTADO = new DevExpress.XtraEditors.CheckEdit();
            this.ACEPTAR = new DevExpress.XtraEditors.SimpleButton();
            this.CANCELAR = new DevExpress.XtraEditors.SimpleButton();
            this.NMDISTRITO = new DevExpress.XtraEditors.TextEdit();
            this.DESCRIPCION = new DevExpress.XtraEditors.TextEdit();
            this.CODIGO = new DevExpress.XtraEditors.TextEdit();
            this.IDDISTRITO = new DevExpress.XtraEditors.ButtonEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ESTADO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NMDISTRITO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DESCRIPCION.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CODIGO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDDISTRITO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.ESTADO);
            this.layoutControl1.Controls.Add(this.ACEPTAR);
            this.layoutControl1.Controls.Add(this.CANCELAR);
            this.layoutControl1.Controls.Add(this.NMDISTRITO);
            this.layoutControl1.Controls.Add(this.DESCRIPCION);
            this.layoutControl1.Controls.Add(this.CODIGO);
            this.layoutControl1.Controls.Add(this.IDDISTRITO);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(252, 339, 650, 400);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(374, 103);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // ESTADO
            // 
            this.ESTADO.Location = new System.Drawing.Point(281, 4);
            this.ESTADO.Name = "ESTADO";
            this.ESTADO.Properties.Caption = "Activo";
            this.ESTADO.Size = new System.Drawing.Size(89, 20);
            this.ESTADO.StyleController = this.layoutControl1;
            this.ESTADO.TabIndex = 10;
            // 
            // ACEPTAR
            // 
            this.ACEPTAR.Location = new System.Drawing.Point(205, 76);
            this.ACEPTAR.Name = "ACEPTAR";
            this.ACEPTAR.Size = new System.Drawing.Size(80, 22);
            this.ACEPTAR.StyleController = this.layoutControl1;
            this.ACEPTAR.TabIndex = 9;
            this.ACEPTAR.Text = "Aceptar";
            this.ACEPTAR.Click += new System.EventHandler(this.ACEPTAR_Click);
            // 
            // CANCELAR
            // 
            this.CANCELAR.Location = new System.Drawing.Point(289, 76);
            this.CANCELAR.Name = "CANCELAR";
            this.CANCELAR.Size = new System.Drawing.Size(81, 22);
            this.CANCELAR.StyleController = this.layoutControl1;
            this.CANCELAR.TabIndex = 8;
            this.CANCELAR.Text = "Cancelar";
            this.CANCELAR.Click += new System.EventHandler(this.CANCELAR_Click);
            // 
            // NMDISTRITO
            // 
            this.NMDISTRITO.Location = new System.Drawing.Point(147, 52);
            this.NMDISTRITO.Name = "NMDISTRITO";
            this.NMDISTRITO.Size = new System.Drawing.Size(223, 20);
            this.NMDISTRITO.StyleController = this.layoutControl1;
            this.NMDISTRITO.TabIndex = 7;
            // 
            // DESCRIPCION
            // 
            this.DESCRIPCION.Location = new System.Drawing.Point(66, 28);
            this.DESCRIPCION.Name = "DESCRIPCION";
            this.DESCRIPCION.Size = new System.Drawing.Size(304, 20);
            this.DESCRIPCION.StyleController = this.layoutControl1;
            this.DESCRIPCION.TabIndex = 5;
            // 
            // CODIGO
            // 
            this.CODIGO.Location = new System.Drawing.Point(66, 4);
            this.CODIGO.Name = "CODIGO";
            this.CODIGO.Size = new System.Drawing.Size(119, 20);
            this.CODIGO.StyleController = this.layoutControl1;
            this.CODIGO.TabIndex = 4;
            // 
            // IDDISTRITO
            // 
            this.IDDISTRITO.Location = new System.Drawing.Point(66, 52);
            this.IDDISTRITO.Name = "IDDISTRITO";
            this.IDDISTRITO.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.IDDISTRITO.Size = new System.Drawing.Size(77, 20);
            this.IDDISTRITO.StyleController = this.layoutControl1;
            this.IDDISTRITO.TabIndex = 6;
            this.IDDISTRITO.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.IDDISTRITO_ButtonClick);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem1,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.emptySpaceItem2,
            this.layoutControlItem7});
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.Root.Size = new System.Drawing.Size(374, 103);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.CODIGO;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(185, 24);
            this.layoutControlItem1.Text = "Codigo:";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(59, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.DESCRIPCION;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(370, 24);
            this.layoutControlItem2.Text = "Descripcion:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(59, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.IDDISTRITO;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(143, 24);
            this.layoutControlItem3.Text = "Distrito:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(59, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(185, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(92, 24);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.NMDISTRITO;
            this.layoutControlItem4.Location = new System.Drawing.Point(143, 48);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(227, 24);
            this.layoutControlItem4.Text = "Descripcion:";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.CANCELAR;
            this.layoutControlItem5.Location = new System.Drawing.Point(285, 72);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(85, 27);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.ACEPTAR;
            this.layoutControlItem6.Location = new System.Drawing.Point(201, 72);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(84, 27);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 72);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(201, 27);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.ESTADO;
            this.layoutControlItem7.Location = new System.Drawing.Point(277, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(93, 24);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // frmSucursal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 103);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmSucursal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sucursal";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmSucursal_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ESTADO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NMDISTRITO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DESCRIPCION.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CODIGO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDDISTRITO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.SimpleButton ACEPTAR;
        private DevExpress.XtraEditors.SimpleButton CANCELAR;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        public DevExpress.XtraEditors.TextEdit CODIGO;
        public DevExpress.XtraEditors.TextEdit DESCRIPCION;
        public DevExpress.XtraEditors.TextEdit NMDISTRITO;
        public DevExpress.XtraEditors.CheckEdit ESTADO;
        public DevExpress.XtraEditors.ButtonEdit IDDISTRITO;
    }
}