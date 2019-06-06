namespace xtraForm.Modulos.Elementos
{
    partial class frmAsignacionVendedor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.Quitar = new DevExpress.XtraEditors.SimpleButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lunes = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Martes = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Miercoles = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Jueves = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Viernes = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Sabado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Domingo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AGREGAR = new DevExpress.XtraEditors.SimpleButton();
            this.ACEPTAR = new DevExpress.XtraEditors.SimpleButton();
            this.CANCELAR = new DevExpress.XtraEditors.SimpleButton();
            this.RVNOMBRE = new DevExpress.XtraEditors.ButtonEdit();
            this.RVCODIGO = new DevExpress.XtraEditors.ButtonEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleSeparator1 = new DevExpress.XtraLayout.SimpleSeparator();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.Validar = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RVNOMBRE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RVCODIGO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Validar)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.Quitar);
            this.layoutControl1.Controls.Add(this.dataGridView1);
            this.layoutControl1.Controls.Add(this.AGREGAR);
            this.layoutControl1.Controls.Add(this.ACEPTAR);
            this.layoutControl1.Controls.Add(this.CANCELAR);
            this.layoutControl1.Controls.Add(this.RVNOMBRE);
            this.layoutControl1.Controls.Add(this.RVCODIGO);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(400, 338, 650, 400);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(499, 223);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // Quitar
            // 
            this.Quitar.Location = new System.Drawing.Point(77, 195);
            this.Quitar.Name = "Quitar";
            this.Quitar.Size = new System.Drawing.Size(71, 22);
            this.Quitar.StyleController = this.layoutControl1;
            this.Quitar.TabIndex = 10;
            this.Quitar.Text = "Quitar";
            this.Quitar.Click += new System.EventHandler(this.Quitar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Descripcion,
            this.Lunes,
            this.Martes,
            this.Miercoles,
            this.Jueves,
            this.Viernes,
            this.Sabado,
            this.Domingo});
            this.dataGridView1.Location = new System.Drawing.Point(6, 30);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.RowHeadersWidth = 35;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.Height = 18;
            this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(487, 160);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellEndEdit);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.DataGridView1_RowPostPaint);
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.DataGridView1_RowsAdded);
            // 
            // Codigo
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Codigo.DefaultCellStyle = dataGridViewCellStyle1;
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.Width = 80;
            // 
            // Descripcion
            // 
            this.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // Lunes
            // 
            this.Lunes.HeaderText = "L";
            this.Lunes.Name = "Lunes";
            this.Lunes.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Lunes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Lunes.Width = 20;
            // 
            // Martes
            // 
            this.Martes.HeaderText = "M";
            this.Martes.Name = "Martes";
            this.Martes.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Martes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Martes.Width = 20;
            // 
            // Miercoles
            // 
            this.Miercoles.HeaderText = "M";
            this.Miercoles.Name = "Miercoles";
            this.Miercoles.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Miercoles.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Miercoles.Width = 20;
            // 
            // Jueves
            // 
            this.Jueves.HeaderText = "J";
            this.Jueves.Name = "Jueves";
            this.Jueves.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Jueves.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Jueves.Width = 20;
            // 
            // Viernes
            // 
            this.Viernes.HeaderText = "V";
            this.Viernes.Name = "Viernes";
            this.Viernes.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Viernes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Viernes.Width = 20;
            // 
            // Sabado
            // 
            this.Sabado.HeaderText = "S";
            this.Sabado.Name = "Sabado";
            this.Sabado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Sabado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Sabado.Width = 20;
            // 
            // Domingo
            // 
            this.Domingo.HeaderText = "D";
            this.Domingo.Name = "Domingo";
            this.Domingo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Domingo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Domingo.Width = 20;
            // 
            // AGREGAR
            // 
            this.AGREGAR.Location = new System.Drawing.Point(6, 195);
            this.AGREGAR.Name = "AGREGAR";
            this.AGREGAR.Size = new System.Drawing.Size(67, 22);
            this.AGREGAR.StyleController = this.layoutControl1;
            this.AGREGAR.TabIndex = 8;
            this.AGREGAR.Text = "Agregar";
            this.AGREGAR.Click += new System.EventHandler(this.AGREGAR_Click);
            // 
            // ACEPTAR
            // 
            this.ACEPTAR.Location = new System.Drawing.Point(325, 195);
            this.ACEPTAR.Name = "ACEPTAR";
            this.ACEPTAR.Size = new System.Drawing.Size(84, 22);
            this.ACEPTAR.StyleController = this.layoutControl1;
            this.ACEPTAR.TabIndex = 7;
            this.ACEPTAR.Text = "Aceptar";
            this.ACEPTAR.Click += new System.EventHandler(this.ACEPTAR_Click);
            // 
            // CANCELAR
            // 
            this.CANCELAR.Location = new System.Drawing.Point(413, 195);
            this.CANCELAR.Name = "CANCELAR";
            this.CANCELAR.Size = new System.Drawing.Size(80, 22);
            this.CANCELAR.StyleController = this.layoutControl1;
            this.CANCELAR.TabIndex = 6;
            this.CANCELAR.Text = "Cancelar";
            this.CANCELAR.Click += new System.EventHandler(this.CANCELAR_Click);
            // 
            // RVNOMBRE
            // 
            this.RVNOMBRE.Enabled = false;
            this.RVNOMBRE.Location = new System.Drawing.Point(198, 6);
            this.RVNOMBRE.Name = "RVNOMBRE";
            this.RVNOMBRE.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.RVNOMBRE.Size = new System.Drawing.Size(295, 20);
            this.RVNOMBRE.StyleController = this.layoutControl1;
            this.RVNOMBRE.TabIndex = 5;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "Control  contiene valor invalido.";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information;
            this.Validar.SetValidationRule(this.RVNOMBRE, conditionValidationRule1);
            // 
            // RVCODIGO
            // 
            this.RVCODIGO.Location = new System.Drawing.Point(46, 6);
            this.RVCODIGO.Name = "RVCODIGO";
            this.RVCODIGO.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.RVCODIGO.Properties.EditValueChanged += new System.EventHandler(this.RVCODIGO_Properties_EditValueChanged);
            this.RVCODIGO.Size = new System.Drawing.Size(102, 20);
            this.RVCODIGO.StyleController = this.layoutControl1;
            this.RVCODIGO.TabIndex = 4;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "Control  contiene valor invalido.";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information;
            this.Validar.SetValidationRule(this.RVCODIGO, conditionValidationRule2);
            this.RVCODIGO.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.RVCODIGO_ButtonClick);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.emptySpaceItem1,
            this.layoutControlItem7,
            this.layoutControlItem3,
            this.simpleSeparator1,
            this.layoutControlItem4});
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.Root.Size = new System.Drawing.Size(499, 223);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.RVCODIGO;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(146, 24);
            this.layoutControlItem1.Text = "Codigo:";
            this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(35, 13);
            this.layoutControlItem1.TextToControlDistance = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.RVNOMBRE;
            this.layoutControlItem2.Location = new System.Drawing.Point(146, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(345, 24);
            this.layoutControlItem2.Text = "Nombre:";
            this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(41, 13);
            this.layoutControlItem2.TextToControlDistance = 5;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.CANCELAR;
            this.layoutControlItem5.Location = new System.Drawing.Point(407, 189);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(84, 26);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.ACEPTAR;
            this.layoutControlItem6.Location = new System.Drawing.Point(319, 189);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(88, 26);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(146, 189);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(173, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.AGREGAR;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 189);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(71, 26);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.dataGridView1;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(491, 164);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // simpleSeparator1
            // 
            this.simpleSeparator1.AllowHotTrack = false;
            this.simpleSeparator1.Location = new System.Drawing.Point(0, 188);
            this.simpleSeparator1.Name = "simpleSeparator1";
            this.simpleSeparator1.Size = new System.Drawing.Size(491, 1);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.Quitar;
            this.layoutControlItem4.Location = new System.Drawing.Point(71, 189);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(75, 26);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // Validar
            // 
            this.Validar.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Manual;
            // 
            // frmAsignacionVendedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 223);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmAsignacionVendedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asignacion";
            this.Load += new System.EventHandler(this.FrmAsignacionVendedor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RVNOMBRE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RVCODIGO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Validar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton ACEPTAR;
        private DevExpress.XtraEditors.SimpleButton CANCELAR;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.SimpleButton AGREGAR;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Lunes;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Martes;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Miercoles;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Jueves;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Viernes;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Sabado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Domingo;
        private DevExpress.XtraEditors.SimpleButton Quitar;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider Validar;
        public DevExpress.XtraEditors.ButtonEdit RVNOMBRE;
        public DevExpress.XtraEditors.ButtonEdit RVCODIGO;
        public System.Windows.Forms.DataGridView dataGridView1;
    }
}