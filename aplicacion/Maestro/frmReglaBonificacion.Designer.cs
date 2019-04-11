namespace xtraForm.Maestro
{
    partial class frmReglaBonificacion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cdProducto = new System.Windows.Forms.RadioButton();
            this.btnQuitar = new DevExpress.XtraEditors.SimpleButton();
            this.cdLinea = new System.Windows.Forms.RadioButton();
            this.cdGrupo = new System.Windows.Forms.RadioButton();
            this.cdMarca = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgregar = new DevExpress.XtraEditors.SimpleButton();
            this.nmBonificacion = new DevExpress.XtraEditors.TextEdit();
            this.IDBonificacion = new DevExpress.XtraEditors.ButtonEdit();
            this.Estado = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.fechaDesde = new DevExpress.XtraEditors.DateEdit();
            this.IDCanje = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.fechaHasta = new DevExpress.XtraEditors.DateEdit();
            this.NmExclusion = new DevExpress.XtraEditors.TextEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.NmCanje = new DevExpress.XtraEditors.TextEdit();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.NmObsequio = new DevExpress.XtraEditors.TextEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.DetalleMecanica = new DevExpress.XtraEditors.TextEdit();
            this.TieneExclusion = new DevExpress.XtraEditors.CheckEdit();
            this.NmProveedor = new DevExpress.XtraEditors.TextEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.IDExclusion = new DevExpress.XtraEditors.ButtonEdit();
            this.IDProveedor = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.IDObsequio = new DevExpress.XtraEditors.ButtonEdit();
            this.CantidadMinima = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.CantidadMaxima = new DevExpress.XtraEditors.SpinEdit();
            this.Mecanica = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.StockPromocional = new DevExpress.XtraEditors.SpinEdit();
            this.CantidadRegalo = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.CantidadMaximaCliente = new DevExpress.XtraEditors.SpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmBonificacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDBonificacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Estado.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDesde.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDesde.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDCanje.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaHasta.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaHasta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NmExclusion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NmCanje.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NmObsequio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetalleMecanica.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TieneExclusion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NmProveedor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDExclusion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDProveedor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDObsequio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CantidadMinima.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CantidadMaxima.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockPromocional.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CantidadRegalo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CantidadMaximaCliente.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cdProducto
            // 
            this.cdProducto.AutoSize = true;
            this.cdProducto.Location = new System.Drawing.Point(26, 289);
            this.cdProducto.Name = "cdProducto";
            this.cdProducto.Size = new System.Drawing.Size(68, 17);
            this.cdProducto.TabIndex = 157;
            this.cdProducto.TabStop = true;
            this.cdProducto.Text = "Producto";
            this.cdProducto.UseVisualStyleBackColor = true;
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(353, 287);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(52, 20);
            this.btnQuitar.TabIndex = 156;
            this.btnQuitar.Text = "Quitar";
            // 
            // cdLinea
            // 
            this.cdLinea.AutoSize = true;
            this.cdLinea.Location = new System.Drawing.Point(106, 289);
            this.cdLinea.Name = "cdLinea";
            this.cdLinea.Size = new System.Drawing.Size(51, 17);
            this.cdLinea.TabIndex = 155;
            this.cdLinea.TabStop = true;
            this.cdLinea.Text = "Linea";
            this.cdLinea.UseVisualStyleBackColor = true;
            // 
            // cdGrupo
            // 
            this.cdGrupo.AutoSize = true;
            this.cdGrupo.Location = new System.Drawing.Point(168, 289);
            this.cdGrupo.Name = "cdGrupo";
            this.cdGrupo.Size = new System.Drawing.Size(54, 17);
            this.cdGrupo.TabIndex = 154;
            this.cdGrupo.TabStop = true;
            this.cdGrupo.Text = "Grupo";
            this.cdGrupo.UseVisualStyleBackColor = true;
            // 
            // cdMarca
            // 
            this.cdMarca.AutoSize = true;
            this.cdMarca.Location = new System.Drawing.Point(234, 289);
            this.cdMarca.Name = "cdMarca";
            this.cdMarca.Size = new System.Drawing.Size(55, 17);
            this.cdMarca.TabIndex = 153;
            this.cdMarca.TabStop = true;
            this.cdMarca.Text = "Marca";
            this.cdMarca.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Descripcion});
            this.dataGridView1.Location = new System.Drawing.Point(14, 310);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(404, 118);
            this.dataGridView1.TabIndex = 152;
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Width = 78;
            // 
            // Descripcion
            // 
            this.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(299, 287);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(52, 20);
            this.btnAgregar.TabIndex = 151;
            this.btnAgregar.Text = "Agregar";
            // 
            // nmBonificacion
            // 
            this.nmBonificacion.Enabled = false;
            this.nmBonificacion.Location = new System.Drawing.Point(194, 18);
            this.nmBonificacion.Name = "nmBonificacion";
            this.nmBonificacion.Size = new System.Drawing.Size(224, 20);
            this.nmBonificacion.TabIndex = 149;
            // 
            // IDBonificacion
            // 
            this.IDBonificacion.Location = new System.Drawing.Point(111, 18);
            this.IDBonificacion.Name = "IDBonificacion";
            this.IDBonificacion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.IDBonificacion.Size = new System.Drawing.Size(79, 20);
            this.IDBonificacion.TabIndex = 150;
            // 
            // Estado
            // 
            this.Estado.Location = new System.Drawing.Point(335, 263);
            this.Estado.Name = "Estado";
            this.Estado.Properties.Caption = "";
            this.Estado.Size = new System.Drawing.Size(16, 20);
            this.Estado.TabIndex = 148;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(13, 22);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(80, 13);
            this.labelControl3.TabIndex = 117;
            this.labelControl3.Text = "Tipo Bonificacion";
            // 
            // fechaDesde
            // 
            this.fechaDesde.EditValue = null;
            this.fechaDesde.Location = new System.Drawing.Point(335, 215);
            this.fechaDesde.Name = "fechaDesde";
            this.fechaDesde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaDesde.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaDesde.Size = new System.Drawing.Size(83, 20);
            this.fechaDesde.TabIndex = 128;
            // 
            // IDCanje
            // 
            this.IDCanje.Location = new System.Drawing.Point(111, 164);
            this.IDCanje.Name = "IDCanje";
            this.IDCanje.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.IDCanje.Size = new System.Drawing.Size(79, 20);
            this.IDCanje.TabIndex = 147;
            // 
            // labelControl14
            // 
            this.labelControl14.Location = new System.Drawing.Point(244, 219);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(56, 13);
            this.labelControl14.TabIndex = 129;
            this.labelControl14.Text = "Fecha Inicio";
            // 
            // labelControl13
            // 
            this.labelControl13.Location = new System.Drawing.Point(13, 72);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(49, 13);
            this.labelControl13.TabIndex = 127;
            this.labelControl13.Text = "Proveedor";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 168);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 13);
            this.labelControl1.TabIndex = 145;
            this.labelControl1.Text = "ProductoCanje";
            // 
            // fechaHasta
            // 
            this.fechaHasta.EditValue = null;
            this.fechaHasta.Location = new System.Drawing.Point(335, 239);
            this.fechaHasta.Name = "fechaHasta";
            this.fechaHasta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaHasta.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fechaHasta.Size = new System.Drawing.Size(83, 20);
            this.fechaHasta.TabIndex = 130;
            // 
            // NmExclusion
            // 
            this.NmExclusion.Enabled = false;
            this.NmExclusion.Location = new System.Drawing.Point(194, 139);
            this.NmExclusion.Name = "NmExclusion";
            this.NmExclusion.Size = new System.Drawing.Size(224, 20);
            this.NmExclusion.TabIndex = 135;
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(244, 266);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(32, 13);
            this.labelControl12.TabIndex = 126;
            this.labelControl12.Text = "Estado";
            // 
            // NmCanje
            // 
            this.NmCanje.Enabled = false;
            this.NmCanje.Location = new System.Drawing.Point(194, 164);
            this.NmCanje.Name = "NmCanje";
            this.NmCanje.Size = new System.Drawing.Size(224, 20);
            this.NmCanje.TabIndex = 146;
            // 
            // labelControl15
            // 
            this.labelControl15.Location = new System.Drawing.Point(244, 243);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(58, 13);
            this.labelControl15.TabIndex = 131;
            this.labelControl15.Text = "Fecha Fecha";
            // 
            // NmObsequio
            // 
            this.NmObsequio.Enabled = false;
            this.NmObsequio.Location = new System.Drawing.Point(194, 93);
            this.NmObsequio.Name = "NmObsequio";
            this.NmObsequio.Size = new System.Drawing.Size(224, 20);
            this.NmObsequio.TabIndex = 134;
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(13, 144);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(87, 13);
            this.labelControl11.TabIndex = 125;
            this.labelControl11.Text = "ProductoExclusion";
            // 
            // DetalleMecanica
            // 
            this.DetalleMecanica.Location = new System.Drawing.Point(111, 43);
            this.DetalleMecanica.Name = "DetalleMecanica";
            this.DetalleMecanica.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DetalleMecanica.Size = new System.Drawing.Size(308, 20);
            this.DetalleMecanica.TabIndex = 144;
            // 
            // TieneExclusion
            // 
            this.TieneExclusion.Location = new System.Drawing.Point(111, 116);
            this.TieneExclusion.Name = "TieneExclusion";
            this.TieneExclusion.Properties.Caption = "";
            this.TieneExclusion.Size = new System.Drawing.Size(16, 20);
            this.TieneExclusion.TabIndex = 132;
            // 
            // NmProveedor
            // 
            this.NmProveedor.Enabled = false;
            this.NmProveedor.Location = new System.Drawing.Point(194, 68);
            this.NmProveedor.Name = "NmProveedor";
            this.NmProveedor.Size = new System.Drawing.Size(224, 20);
            this.NmProveedor.TabIndex = 133;
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(13, 120);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(72, 13);
            this.labelControl10.TabIndex = 124;
            this.labelControl10.Text = "Tiene Exclusion";
            // 
            // IDExclusion
            // 
            this.IDExclusion.Location = new System.Drawing.Point(111, 139);
            this.IDExclusion.Name = "IDExclusion";
            this.IDExclusion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.IDExclusion.Size = new System.Drawing.Size(79, 20);
            this.IDExclusion.TabIndex = 143;
            // 
            // IDProveedor
            // 
            this.IDProveedor.Location = new System.Drawing.Point(111, 68);
            this.IDProveedor.Name = "IDProveedor";
            this.IDProveedor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.IDProveedor.Size = new System.Drawing.Size(79, 20);
            this.IDProveedor.TabIndex = 141;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(245, 193);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(87, 13);
            this.labelControl9.TabIndex = 123;
            this.labelControl9.Text = "Stock Promocional";
            // 
            // IDObsequio
            // 
            this.IDObsequio.Location = new System.Drawing.Point(111, 93);
            this.IDObsequio.Name = "IDObsequio";
            this.IDObsequio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.IDObsequio.Size = new System.Drawing.Size(79, 20);
            this.IDObsequio.TabIndex = 142;
            // 
            // CantidadMinima
            // 
            this.CantidadMinima.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.CantidadMinima.Location = new System.Drawing.Point(111, 189);
            this.CantidadMinima.Name = "CantidadMinima";
            this.CantidadMinima.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CantidadMinima.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.CantidadMinima.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.CantidadMinima.Size = new System.Drawing.Size(79, 20);
            this.CantidadMinima.TabIndex = 136;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(13, 268);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(80, 13);
            this.labelControl8.TabIndex = 122;
            this.labelControl8.Text = "Cant Max Cliente";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(13, 243);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(77, 13);
            this.labelControl7.TabIndex = 121;
            this.labelControl7.Text = "Cantidad Regalo";
            // 
            // CantidadMaxima
            // 
            this.CantidadMaxima.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.CantidadMaxima.Location = new System.Drawing.Point(111, 214);
            this.CantidadMaxima.Name = "CantidadMaxima";
            this.CantidadMaxima.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CantidadMaxima.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.CantidadMaxima.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.CantidadMaxima.Size = new System.Drawing.Size(79, 20);
            this.CantidadMaxima.TabIndex = 137;
            // 
            // Mecanica
            // 
            this.Mecanica.Location = new System.Drawing.Point(13, 47);
            this.Mecanica.Name = "Mecanica";
            this.Mecanica.Size = new System.Drawing.Size(46, 13);
            this.Mecanica.TabIndex = 116;
            this.Mecanica.Text = "Mecanica";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(13, 218);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(83, 13);
            this.labelControl6.TabIndex = 120;
            this.labelControl6.Text = "Cantidad Maxima";
            // 
            // StockPromocional
            // 
            this.StockPromocional.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.StockPromocional.Location = new System.Drawing.Point(335, 189);
            this.StockPromocional.Name = "StockPromocional";
            this.StockPromocional.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.StockPromocional.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.StockPromocional.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.StockPromocional.Size = new System.Drawing.Size(83, 20);
            this.StockPromocional.TabIndex = 140;
            // 
            // CantidadRegalo
            // 
            this.CantidadRegalo.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.CantidadRegalo.Location = new System.Drawing.Point(111, 239);
            this.CantidadRegalo.Name = "CantidadRegalo";
            this.CantidadRegalo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CantidadRegalo.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.CantidadRegalo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.CantidadRegalo.Size = new System.Drawing.Size(79, 20);
            this.CantidadRegalo.TabIndex = 138;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(13, 96);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(90, 13);
            this.labelControl4.TabIndex = 118;
            this.labelControl4.Text = "Producto Obsequio";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(13, 193);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(81, 13);
            this.labelControl5.TabIndex = 119;
            this.labelControl5.Text = "Cantidad Minima";
            // 
            // CantidadMaximaCliente
            // 
            this.CantidadMaximaCliente.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.CantidadMaximaCliente.Location = new System.Drawing.Point(111, 264);
            this.CantidadMaximaCliente.Name = "CantidadMaximaCliente";
            this.CantidadMaximaCliente.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CantidadMaximaCliente.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.CantidadMaximaCliente.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.CantidadMaximaCliente.Size = new System.Drawing.Size(79, 20);
            this.CantidadMaximaCliente.TabIndex = 139;
            // 
            // frmReglaBonificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 446);
            this.Controls.Add(this.cdProducto);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.cdLinea);
            this.Controls.Add(this.cdGrupo);
            this.Controls.Add(this.cdMarca);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.nmBonificacion);
            this.Controls.Add(this.IDBonificacion);
            this.Controls.Add(this.Estado);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.fechaDesde);
            this.Controls.Add(this.IDCanje);
            this.Controls.Add(this.labelControl14);
            this.Controls.Add(this.labelControl13);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.fechaHasta);
            this.Controls.Add(this.NmExclusion);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.NmCanje);
            this.Controls.Add(this.labelControl15);
            this.Controls.Add(this.NmObsequio);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.DetalleMecanica);
            this.Controls.Add(this.TieneExclusion);
            this.Controls.Add(this.NmProveedor);
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.IDExclusion);
            this.Controls.Add(this.IDProveedor);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.IDObsequio);
            this.Controls.Add(this.CantidadMinima);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.CantidadMaxima);
            this.Controls.Add(this.Mecanica);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.StockPromocional);
            this.Controls.Add(this.CantidadRegalo);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.CantidadMaximaCliente);
            this.Name = "frmReglaBonificacion";
            this.Text = "frmReglaBonificacion";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmBonificacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDBonificacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Estado.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDesde.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaDesde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDCanje.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaHasta.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fechaHasta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NmExclusion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NmCanje.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NmObsequio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetalleMecanica.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TieneExclusion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NmProveedor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDExclusion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDProveedor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDObsequio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CantidadMinima.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CantidadMaxima.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockPromocional.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CantidadRegalo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CantidadMaximaCliente.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton cdProducto;
        private DevExpress.XtraEditors.SimpleButton btnQuitar;
        private System.Windows.Forms.RadioButton cdLinea;
        private System.Windows.Forms.RadioButton cdGrupo;
        private System.Windows.Forms.RadioButton cdMarca;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private DevExpress.XtraEditors.SimpleButton btnAgregar;
        private DevExpress.XtraEditors.TextEdit nmBonificacion;
        private DevExpress.XtraEditors.ButtonEdit IDBonificacion;
        private DevExpress.XtraEditors.CheckEdit Estado;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit fechaDesde;
        private DevExpress.XtraEditors.ButtonEdit IDCanje;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit fechaHasta;
        private DevExpress.XtraEditors.TextEdit NmExclusion;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.TextEdit NmCanje;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.TextEdit NmObsequio;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.TextEdit DetalleMecanica;
        private DevExpress.XtraEditors.CheckEdit TieneExclusion;
        private DevExpress.XtraEditors.TextEdit NmProveedor;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.ButtonEdit IDExclusion;
        private DevExpress.XtraEditors.ButtonEdit IDProveedor;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.ButtonEdit IDObsequio;
        private DevExpress.XtraEditors.SpinEdit CantidadMinima;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.SpinEdit CantidadMaxima;
        private DevExpress.XtraEditors.LabelControl Mecanica;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.SpinEdit StockPromocional;
        private DevExpress.XtraEditors.SpinEdit CantidadRegalo;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SpinEdit CantidadMaximaCliente;
    }
}