namespace xtraForm.Modulos.Elementos
{
    partial class frmComprobante
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule7 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule4 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule5 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.btnFueraRuta = new DevExpress.XtraEditors.CheckButton();
            this.CodigoFP = new DevExpress.XtraEditors.LabelControl();
            this.txtformaPago = new DevExpress.XtraEditors.LabelControl();
            this.labelControl20 = new DevExpress.XtraEditors.LabelControl();
            this.txtcdGestion = new DevExpress.XtraEditors.TextEdit();
            this.xtraOpenFileDialog1 = new DevExpress.XtraEditors.XtraOpenFileDialog(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDetalle = new System.Windows.Forms.TabPage();
            this.ANULADO = new DevExpress.XtraEditors.LabelControl();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantpedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TpPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioNeto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Recargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bonif = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Credito = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Afecto = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IDBonificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabReparto = new System.Windows.Forms.TabPage();
            this.txtcdProvincia = new DevExpress.XtraEditors.TextEdit();
            this.txtcdDistrito = new DevExpress.XtraEditors.TextEdit();
            this.txtcdZona = new DevExpress.XtraEditors.TextEdit();
            this.labelControl19 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.txtnmZona = new DevExpress.XtraEditors.TextEdit();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.txtnmDistrito = new DevExpress.XtraEditors.TextEdit();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.txtnmProvincia = new DevExpress.XtraEditors.TextEdit();
            this.txtnmDireccion = new DevExpress.XtraEditors.ButtonEdit();
            this.btnCredito = new DevExpress.XtraEditors.CheckButton();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.dateEntrega = new DevExpress.XtraEditors.DateEdit();
            this.dateEmision = new DevExpress.XtraEditors.DateEdit();
            this.txtnmCliente = new DevExpress.XtraEditors.ButtonEdit();
            this.txtcdCLiente = new DevExpress.XtraEditors.ButtonEdit();
            this.txtnmVendedor = new DevExpress.XtraEditors.ButtonEdit();
            this.txtcdVendedor = new DevExpress.XtraEditors.ButtonEdit();
            this.btnPrecio = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.btnConsultar = new DevExpress.XtraEditors.SimpleButton();
            this.btnImportar = new DevExpress.XtraEditors.SimpleButton();
            this.btnDescuento = new DevExpress.XtraEditors.SimpleButton();
            this.btnBonificar = new DevExpress.XtraEditors.SimpleButton();
            this.btnStock = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.btnAgregar = new DevExpress.XtraEditors.SimpleButton();
            this.btnQuitar = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.txtValorImporteTotal = new DevExpress.XtraEditors.TextEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txtValorRecargo = new DevExpress.XtraEditors.TextEdit();
            this.txtValorDescuento = new DevExpress.XtraEditors.TextEdit();
            this.txtValorSubtotal = new DevExpress.XtraEditors.TextEdit();
            this.txtValorImpuesto = new DevExpress.XtraEditors.TextEdit();
            this.txtValorInafecto = new DevExpress.XtraEditors.TextEdit();
            this.txtValorAfecto = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtnmAlmacen = new DevExpress.XtraEditors.ButtonEdit();
            this.txtcdAlmacen = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.buttonEdit5 = new DevExpress.XtraEditors.ButtonEdit();
            this.buttonEdit6 = new DevExpress.XtraEditors.ButtonEdit();
            this.textEdit4 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txttipoDocumento = new DevExpress.XtraEditors.ButtonEdit();
            this.txtdocCliente = new DevExpress.XtraEditors.TextEdit();
            this.txtObservacion = new DevExpress.XtraEditors.MemoEdit();
            this.txtcdDocumento = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcdGestion.Properties)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabReparto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtcdProvincia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcdDistrito.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcdZona.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtnmZona.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtnmDistrito.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtnmProvincia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtnmDireccion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEntrega.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEntrega.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEmision.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEmision.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtnmCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcdCLiente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtnmVendedor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcdVendedor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorImporteTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorRecargo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorDescuento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorSubtotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorImpuesto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorInafecto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorAfecto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtnmAlmacen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcdAlmacen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit5.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit6.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txttipoDocumento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdocCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtObservacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcdDocumento.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFueraRuta
            // 
            this.btnFueraRuta.Location = new System.Drawing.Point(675, 93);
            this.btnFueraRuta.Name = "btnFueraRuta";
            this.btnFueraRuta.Size = new System.Drawing.Size(81, 23);
            this.btnFueraRuta.TabIndex = 111;
            this.btnFueraRuta.Text = "Fuera De Ruta";
            // 
            // CodigoFP
            // 
            this.CodigoFP.Location = new System.Drawing.Point(533, 66);
            this.CodigoFP.Name = "CodigoFP";
            this.CodigoFP.Size = new System.Drawing.Size(43, 13);
            this.CodigoFP.TabIndex = 110;
            this.CodigoFP.Text = "CodigoFP";
            this.CodigoFP.Visible = false;
            // 
            // txtformaPago
            // 
            this.txtformaPago.Appearance.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtformaPago.Appearance.Options.UseFont = true;
            this.txtformaPago.Appearance.Options.UseTextOptions = true;
            this.txtformaPago.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtformaPago.Enabled = false;
            this.txtformaPago.Location = new System.Drawing.Point(501, 47);
            this.txtformaPago.Name = "txtformaPago";
            this.txtformaPago.Size = new System.Drawing.Size(106, 13);
            this.txtformaPago.TabIndex = 109;
            this.txtformaPago.Text = "DescripcionFormaPago";
            // 
            // labelControl20
            // 
            this.labelControl20.Location = new System.Drawing.Point(389, 98);
            this.labelControl20.Name = "labelControl20";
            this.labelControl20.Size = new System.Drawing.Size(37, 13);
            this.labelControl20.TabIndex = 108;
            this.labelControl20.Text = "Gestion";
            // 
            // txtcdGestion
            // 
            this.txtcdGestion.EditValue = "01";
            this.txtcdGestion.Location = new System.Drawing.Point(433, 95);
            this.txtcdGestion.Name = "txtcdGestion";
            this.txtcdGestion.Properties.Appearance.Options.UseTextOptions = true;
            this.txtcdGestion.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtcdGestion.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtcdGestion.Size = new System.Drawing.Size(56, 20);
            this.txtcdGestion.TabIndex = 107;
            // 
            // xtraOpenFileDialog1
            // 
            this.xtraOpenFileDialog1.FileName = "xtraOpenFileDialog1";
            this.xtraOpenFileDialog1.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            this.xtraOpenFileDialog1.ShowDragDropConfirmation = true;
            this.xtraOpenFileDialog1.ShowHelp = true;
            this.xtraOpenFileDialog1.Title = "Importar Archivo";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabDetalle);
            this.tabControl1.Controls.Add(this.tabReparto);
            this.tabControl1.Location = new System.Drawing.Point(12, 121);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(825, 272);
            this.tabControl1.TabIndex = 106;
            // 
            // tabDetalle
            // 
            this.tabDetalle.Controls.Add(this.ANULADO);
            this.tabDetalle.Controls.Add(this.dataGridView1);
            this.tabDetalle.Location = new System.Drawing.Point(4, 22);
            this.tabDetalle.Margin = new System.Windows.Forms.Padding(0);
            this.tabDetalle.Name = "tabDetalle";
            this.tabDetalle.Size = new System.Drawing.Size(817, 246);
            this.tabDetalle.TabIndex = 0;
            this.tabDetalle.Text = "Detalle";
            this.tabDetalle.UseVisualStyleBackColor = true;
            // 
            // ANULADO
            // 
            this.ANULADO.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.ANULADO.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.ANULADO.Appearance.Font = new System.Drawing.Font("Bernard MT Condensed", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ANULADO.Appearance.ForeColor = System.Drawing.Color.LightCoral;
            this.ANULADO.Appearance.Options.UseBackColor = true;
            this.ANULADO.Appearance.Options.UseFont = true;
            this.ANULADO.Appearance.Options.UseForeColor = true;
            this.ANULADO.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.ANULADO.Location = new System.Drawing.Point(281, 100);
            this.ANULADO.Name = "ANULADO";
            this.ANULADO.Size = new System.Drawing.Size(254, 47);
            this.ANULADO.TabIndex = 112;
            this.ANULADO.Text = "A  N  U  L  A  D  O";
            this.ANULADO.Parent = dataGridView1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Calibri", 8.25F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Descripcion,
            this.Cantidad,
            this.cantpedido,
            this.Unidad,
            this.TpPrecio,
            this.PrecioUnitario,
            this.PrecioNeto,
            this.Total,
            this.Descuento,
            this.Recargo,
            this.Bonif,
            this.Credito,
            this.Afecto,
            this.IDBonificacion});
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Calibri", 8.25F);
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(111)))));
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(817, 246);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.Width = 60;
            // 
            // Descripcion
            // 
            this.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            // 
            // Cantidad
            // 
            dataGridViewCellStyle10.Format = "N2";
            dataGridViewCellStyle10.NullValue = "0.00";
            this.Cantidad.DefaultCellStyle = dataGridViewCellStyle10;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            this.Cantidad.Width = 55;
            // 
            // cantpedido
            // 
            this.cantpedido.HeaderText = "cantidadPedido";
            this.cantpedido.Name = "cantpedido";
            this.cantpedido.ReadOnly = true;
            this.cantpedido.Visible = false;
            // 
            // Unidad
            // 
            this.Unidad.HeaderText = "Unidad";
            this.Unidad.Name = "Unidad";
            this.Unidad.ReadOnly = true;
            this.Unidad.Width = 50;
            // 
            // TpPrecio
            // 
            this.TpPrecio.HeaderText = "TPr";
            this.TpPrecio.Name = "TpPrecio";
            this.TpPrecio.ReadOnly = true;
            this.TpPrecio.Width = 30;
            // 
            // PrecioUnitario
            // 
            dataGridViewCellStyle11.Format = "N2";
            dataGridViewCellStyle11.NullValue = "0.00";
            this.PrecioUnitario.DefaultCellStyle = dataGridViewCellStyle11;
            this.PrecioUnitario.HeaderText = "PrecioUnit";
            this.PrecioUnitario.Name = "PrecioUnitario";
            this.PrecioUnitario.ReadOnly = true;
            this.PrecioUnitario.Width = 60;
            // 
            // PrecioNeto
            // 
            this.PrecioNeto.HeaderText = "PrecioNeto";
            this.PrecioNeto.Name = "PrecioNeto";
            this.PrecioNeto.ReadOnly = true;
            this.PrecioNeto.Width = 55;
            // 
            // Total
            // 
            dataGridViewCellStyle12.Format = "N2";
            dataGridViewCellStyle12.NullValue = "0.00";
            this.Total.DefaultCellStyle = dataGridViewCellStyle12;
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.Width = 60;
            // 
            // Descuento
            // 
            dataGridViewCellStyle13.Format = "N2";
            dataGridViewCellStyle13.NullValue = "0.00";
            this.Descuento.DefaultCellStyle = dataGridViewCellStyle13;
            this.Descuento.HeaderText = "Descuento";
            this.Descuento.Name = "Descuento";
            this.Descuento.ReadOnly = true;
            this.Descuento.Width = 60;
            // 
            // Recargo
            // 
            dataGridViewCellStyle14.Format = "N2";
            dataGridViewCellStyle14.NullValue = "0.00";
            this.Recargo.DefaultCellStyle = dataGridViewCellStyle14;
            this.Recargo.HeaderText = "Recargo";
            this.Recargo.Name = "Recargo";
            this.Recargo.ReadOnly = true;
            this.Recargo.Width = 60;
            // 
            // Bonif
            // 
            this.Bonif.HeaderText = "Bonif";
            this.Bonif.Name = "Bonif";
            this.Bonif.ReadOnly = true;
            this.Bonif.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Bonif.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Bonif.Width = 30;
            // 
            // Credito
            // 
            this.Credito.HeaderText = "Credito";
            this.Credito.Name = "Credito";
            this.Credito.ReadOnly = true;
            this.Credito.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Credito.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Credito.Width = 30;
            // 
            // Afecto
            // 
            this.Afecto.HeaderText = "Afecto";
            this.Afecto.Name = "Afecto";
            this.Afecto.ReadOnly = true;
            this.Afecto.Width = 30;
            // 
            // IDBonificacion
            // 
            this.IDBonificacion.HeaderText = "IDBonificacion";
            this.IDBonificacion.Name = "IDBonificacion";
            this.IDBonificacion.ReadOnly = true;
            this.IDBonificacion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IDBonificacion.Visible = false;
            // 
            // tabReparto
            // 
            this.tabReparto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tabReparto.Controls.Add(this.txtcdProvincia);
            this.tabReparto.Controls.Add(this.txtcdDistrito);
            this.tabReparto.Controls.Add(this.txtcdZona);
            this.tabReparto.Controls.Add(this.labelControl19);
            this.tabReparto.Controls.Add(this.labelControl18);
            this.tabReparto.Controls.Add(this.txtnmZona);
            this.tabReparto.Controls.Add(this.labelControl17);
            this.tabReparto.Controls.Add(this.txtnmDistrito);
            this.tabReparto.Controls.Add(this.labelControl16);
            this.tabReparto.Controls.Add(this.txtnmProvincia);
            this.tabReparto.Controls.Add(this.txtnmDireccion);
            this.tabReparto.Location = new System.Drawing.Point(4, 22);
            this.tabReparto.Margin = new System.Windows.Forms.Padding(0);
            this.tabReparto.Name = "tabReparto";
            this.tabReparto.Size = new System.Drawing.Size(817, 246);
            this.tabReparto.TabIndex = 1;
            this.tabReparto.Text = "Reparto";
            // 
            // txtcdProvincia
            // 
            this.txtcdProvincia.Enabled = false;
            this.txtcdProvincia.Location = new System.Drawing.Point(398, 120);
            this.txtcdProvincia.Name = "txtcdProvincia";
            this.txtcdProvincia.Size = new System.Drawing.Size(100, 20);
            this.txtcdProvincia.TabIndex = 11;
            this.txtcdProvincia.Visible = false;
            // 
            // txtcdDistrito
            // 
            this.txtcdDistrito.Enabled = false;
            this.txtcdDistrito.Location = new System.Drawing.Point(398, 88);
            this.txtcdDistrito.Name = "txtcdDistrito";
            this.txtcdDistrito.Size = new System.Drawing.Size(100, 20);
            this.txtcdDistrito.TabIndex = 10;
            this.txtcdDistrito.Visible = false;
            // 
            // txtcdZona
            // 
            this.txtcdZona.Enabled = false;
            this.txtcdZona.Location = new System.Drawing.Point(400, 56);
            this.txtcdZona.Name = "txtcdZona";
            this.txtcdZona.Size = new System.Drawing.Size(100, 20);
            this.txtcdZona.TabIndex = 9;
            this.txtcdZona.Visible = false;
            // 
            // labelControl19
            // 
            this.labelControl19.Location = new System.Drawing.Point(9, 121);
            this.labelControl19.Name = "labelControl19";
            this.labelControl19.Size = new System.Drawing.Size(44, 13);
            this.labelControl19.TabIndex = 7;
            this.labelControl19.Text = "Provincia";
            // 
            // labelControl18
            // 
            this.labelControl18.Location = new System.Drawing.Point(9, 89);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new System.Drawing.Size(36, 13);
            this.labelControl18.TabIndex = 5;
            this.labelControl18.Text = "Distrito";
            // 
            // txtnmZona
            // 
            this.txtnmZona.Location = new System.Drawing.Point(99, 56);
            this.txtnmZona.Name = "txtnmZona";
            this.txtnmZona.Size = new System.Drawing.Size(287, 20);
            this.txtnmZona.TabIndex = 4;
            // 
            // labelControl17
            // 
            this.labelControl17.Location = new System.Drawing.Point(9, 57);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(68, 13);
            this.labelControl17.TabIndex = 3;
            this.labelControl17.Text = "Zona De Venta";
            // 
            // txtnmDistrito
            // 
            this.txtnmDistrito.Location = new System.Drawing.Point(99, 88);
            this.txtnmDistrito.Name = "txtnmDistrito";
            this.txtnmDistrito.Size = new System.Drawing.Size(287, 20);
            this.txtnmDistrito.TabIndex = 2;
            // 
            // labelControl16
            // 
            this.labelControl16.Location = new System.Drawing.Point(9, 25);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(81, 13);
            this.labelControl16.TabIndex = 1;
            this.labelControl16.Text = "Direccion Cliente";
            // 
            // txtnmProvincia
            // 
            this.txtnmProvincia.Location = new System.Drawing.Point(99, 120);
            this.txtnmProvincia.Name = "txtnmProvincia";
            this.txtnmProvincia.Size = new System.Drawing.Size(220, 20);
            this.txtnmProvincia.TabIndex = 0;
            // 
            // txtnmDireccion
            // 
            this.txtnmDireccion.Location = new System.Drawing.Point(99, 24);
            this.txtnmDireccion.Name = "txtnmDireccion";
            this.txtnmDireccion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtnmDireccion.Size = new System.Drawing.Size(287, 20);
            this.txtnmDireccion.TabIndex = 6;
            // 
            // btnCredito
            // 
            this.btnCredito.Location = new System.Drawing.Point(762, 93);
            this.btnCredito.Name = "btnCredito";
            this.btnCredito.Size = new System.Drawing.Size(75, 23);
            this.btnCredito.TabIndex = 77;
            this.btnCredito.Text = "Credito";
            // 
            // dxValidationProvider1
            // 
            this.dxValidationProvider1.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Manual;
            // 
            // dateEntrega
            // 
            this.dateEntrega.EditValue = null;
            this.dateEntrega.Location = new System.Drawing.Point(741, 66);
            this.dateEntrega.Name = "dateEntrega";
            this.dateEntrega.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEntrega.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEntrega.Size = new System.Drawing.Size(96, 20);
            this.dateEntrega.TabIndex = 83;
            conditionValidationRule7.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.NotEquals;
            conditionValidationRule7.ErrorText = "Fecha no puede estar vacio.";
            conditionValidationRule7.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information;
            this.dxValidationProvider1.SetValidationRule(this.dateEntrega, conditionValidationRule7);
            // 
            // dateEmision
            // 
            this.dateEmision.EditValue = null;
            this.dateEmision.Location = new System.Drawing.Point(741, 40);
            this.dateEmision.Name = "dateEmision";
            this.dateEmision.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEmision.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEmision.Size = new System.Drawing.Size(96, 20);
            this.dateEmision.TabIndex = 82;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.NotEquals;
            conditionValidationRule1.ErrorText = "Fecha no debe estar vacia.";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information;
            this.dxValidationProvider1.SetValidationRule(this.dateEmision, conditionValidationRule1);
            // 
            // txtnmCliente
            // 
            this.txtnmCliente.Location = new System.Drawing.Point(137, 38);
            this.txtnmCliente.Name = "txtnmCliente";
            this.txtnmCliente.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtnmCliente.Size = new System.Drawing.Size(198, 20);
            this.txtnmCliente.TabIndex = 62;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "Nombre de cliente no puede estar vacio";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information;
            this.dxValidationProvider1.SetValidationRule(this.txtnmCliente, conditionValidationRule2);
            // 
            // txtcdCLiente
            // 
            this.txtcdCLiente.Location = new System.Drawing.Point(66, 38);
            this.txtcdCLiente.Name = "txtcdCLiente";
            this.txtcdCLiente.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtcdCLiente.Size = new System.Drawing.Size(65, 20);
            this.txtcdCLiente.TabIndex = 61;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule3.ErrorText = "Codigo de cliente no puede estar en blanco";
            conditionValidationRule3.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information;
            this.dxValidationProvider1.SetValidationRule(this.txtcdCLiente, conditionValidationRule3);
            // 
            // txtnmVendedor
            // 
            this.txtnmVendedor.Location = new System.Drawing.Point(137, 69);
            this.txtnmVendedor.Name = "txtnmVendedor";
            this.txtnmVendedor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtnmVendedor.Size = new System.Drawing.Size(198, 20);
            this.txtnmVendedor.TabIndex = 58;
            conditionValidationRule4.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule4.ErrorText = "Nombre de vendedor no puede estar vacio";
            conditionValidationRule4.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information;
            this.dxValidationProvider1.SetValidationRule(this.txtnmVendedor, conditionValidationRule4);
            // 
            // txtcdVendedor
            // 
            this.txtcdVendedor.Location = new System.Drawing.Point(66, 69);
            this.txtcdVendedor.Name = "txtcdVendedor";
            this.txtcdVendedor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtcdVendedor.Size = new System.Drawing.Size(65, 20);
            this.txtcdVendedor.TabIndex = 57;
            conditionValidationRule5.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule5.ErrorText = "Codigo de vendedor no puede estar vacio";
            conditionValidationRule5.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information;
            this.dxValidationProvider1.SetValidationRule(this.txtcdVendedor, conditionValidationRule5);
            // 
            // btnPrecio
            // 
            this.btnPrecio.Location = new System.Drawing.Point(497, 400);
            this.btnPrecio.Name = "btnPrecio";
            this.btnPrecio.Size = new System.Drawing.Size(75, 23);
            this.btnPrecio.TabIndex = 67;
            this.btnPrecio.Text = "Precio";
            // 
            // labelControl15
            // 
            this.labelControl15.Location = new System.Drawing.Point(12, 427);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(76, 13);
            this.labelControl15.TabIndex = 104;
            this.labelControl15.Text = "Observaciones_";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(62, 400);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(75, 23);
            this.btnConsultar.TabIndex = 74;
            this.btnConsultar.Text = "Consultar";
            // 
            // btnImportar
            // 
            this.btnImportar.Location = new System.Drawing.Point(149, 400);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(75, 23);
            this.btnImportar.TabIndex = 73;
            this.btnImportar.Text = "Importar";
            // 
            // btnDescuento
            // 
            this.btnDescuento.Location = new System.Drawing.Point(236, 400);
            this.btnDescuento.Name = "btnDescuento";
            this.btnDescuento.Size = new System.Drawing.Size(75, 23);
            this.btnDescuento.TabIndex = 72;
            this.btnDescuento.Text = "Descuento";
            // 
            // btnBonificar
            // 
            this.btnBonificar.Location = new System.Drawing.Point(323, 400);
            this.btnBonificar.Name = "btnBonificar";
            this.btnBonificar.Size = new System.Drawing.Size(75, 23);
            this.btnBonificar.TabIndex = 71;
            this.btnBonificar.Text = "Bonificar";
            // 
            // btnStock
            // 
            this.btnStock.Location = new System.Drawing.Point(410, 400);
            this.btnStock.Name = "btnStock";
            this.btnStock.Size = new System.Drawing.Size(75, 23);
            this.btnStock.TabIndex = 68;
            this.btnStock.Text = "Stock";
            // 
            // simpleButton5
            // 
            this.simpleButton5.Location = new System.Drawing.Point(584, 400);
            this.simpleButton5.Name = "simpleButton5";
            this.simpleButton5.Size = new System.Drawing.Size(75, 23);
            this.simpleButton5.TabIndex = 66;
            this.simpleButton5.Text = "Unidad";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(671, 400);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 64;
            this.btnAgregar.Text = "Agregar";
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(758, 400);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(75, 23);
            this.btnQuitar.TabIndex = 65;
            this.btnQuitar.Text = "Quitar";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(758, 538);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 87;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(666, 538);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 86;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // labelControl14
            // 
            this.labelControl14.Location = new System.Drawing.Point(449, 486);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(65, 13);
            this.labelControl14.TabIndex = 103;
            this.labelControl14.Text = "Valor Recargo";
            // 
            // labelControl13
            // 
            this.labelControl13.Location = new System.Drawing.Point(449, 460);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(77, 13);
            this.labelControl13.TabIndex = 102;
            this.labelControl13.Text = "Valor descuento";
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(449, 433);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(67, 13);
            this.labelControl12.TabIndex = 101;
            this.labelControl12.Text = "Valor subtotal";
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(659, 512);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(63, 13);
            this.labelControl11.TabIndex = 100;
            this.labelControl11.Text = "Importe total";
            // 
            // txtValorImporteTotal
            // 
            this.txtValorImporteTotal.Location = new System.Drawing.Point(737, 508);
            this.txtValorImporteTotal.Name = "txtValorImporteTotal";
            this.txtValorImporteTotal.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.txtValorImporteTotal.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtValorImporteTotal.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtValorImporteTotal.Properties.Mask.EditMask = "c";
            this.txtValorImporteTotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtValorImporteTotal.Size = new System.Drawing.Size(96, 20);
            this.txtValorImporteTotal.TabIndex = 99;
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(659, 486);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(72, 13);
            this.labelControl10.TabIndex = 98;
            this.labelControl10.Text = "Valor impuesto";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(658, 460);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(66, 13);
            this.labelControl9.TabIndex = 97;
            this.labelControl9.Text = "Valor inafecto";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(658, 433);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(57, 13);
            this.labelControl8.TabIndex = 96;
            this.labelControl8.Text = "Valor afecto";
            // 
            // txtValorRecargo
            // 
            this.txtValorRecargo.Location = new System.Drawing.Point(537, 482);
            this.txtValorRecargo.Name = "txtValorRecargo";
            this.txtValorRecargo.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.txtValorRecargo.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtValorRecargo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtValorRecargo.Properties.Mask.EditMask = "c";
            this.txtValorRecargo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtValorRecargo.Size = new System.Drawing.Size(96, 20);
            this.txtValorRecargo.TabIndex = 95;
            // 
            // txtValorDescuento
            // 
            this.txtValorDescuento.Location = new System.Drawing.Point(537, 456);
            this.txtValorDescuento.Name = "txtValorDescuento";
            this.txtValorDescuento.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.txtValorDescuento.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtValorDescuento.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtValorDescuento.Properties.Mask.EditMask = "c";
            this.txtValorDescuento.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtValorDescuento.Size = new System.Drawing.Size(96, 20);
            this.txtValorDescuento.TabIndex = 94;
            // 
            // txtValorSubtotal
            // 
            this.txtValorSubtotal.Location = new System.Drawing.Point(537, 429);
            this.txtValorSubtotal.Name = "txtValorSubtotal";
            this.txtValorSubtotal.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.txtValorSubtotal.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtValorSubtotal.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtValorSubtotal.Properties.Mask.EditMask = "c";
            this.txtValorSubtotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtValorSubtotal.Size = new System.Drawing.Size(96, 20);
            this.txtValorSubtotal.TabIndex = 93;
            // 
            // txtValorImpuesto
            // 
            this.txtValorImpuesto.Location = new System.Drawing.Point(737, 482);
            this.txtValorImpuesto.Name = "txtValorImpuesto";
            this.txtValorImpuesto.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.txtValorImpuesto.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtValorImpuesto.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtValorImpuesto.Properties.Mask.EditMask = "c";
            this.txtValorImpuesto.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtValorImpuesto.Size = new System.Drawing.Size(96, 20);
            this.txtValorImpuesto.TabIndex = 92;
            // 
            // txtValorInafecto
            // 
            this.txtValorInafecto.Location = new System.Drawing.Point(737, 456);
            this.txtValorInafecto.Name = "txtValorInafecto";
            this.txtValorInafecto.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.txtValorInafecto.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtValorInafecto.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtValorInafecto.Properties.Mask.EditMask = "c";
            this.txtValorInafecto.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtValorInafecto.Size = new System.Drawing.Size(96, 20);
            this.txtValorInafecto.TabIndex = 91;
            // 
            // txtValorAfecto
            // 
            this.txtValorAfecto.Location = new System.Drawing.Point(737, 429);
            this.txtValorAfecto.Name = "txtValorAfecto";
            this.txtValorAfecto.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.txtValorAfecto.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtValorAfecto.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtValorAfecto.Properties.Mask.EditMask = "c";
            this.txtValorAfecto.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtValorAfecto.Size = new System.Drawing.Size(96, 20);
            this.txtValorAfecto.TabIndex = 90;
            // 
            // labelControl7
            // 
            this.labelControl7.Enabled = false;
            this.labelControl7.Location = new System.Drawing.Point(12, 103);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(41, 13);
            this.labelControl7.TabIndex = 89;
            this.labelControl7.Text = "Almacen";
            // 
            // txtnmAlmacen
            // 
            this.txtnmAlmacen.Enabled = false;
            this.txtnmAlmacen.Location = new System.Drawing.Point(137, 99);
            this.txtnmAlmacen.Name = "txtnmAlmacen";
            this.txtnmAlmacen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtnmAlmacen.Size = new System.Drawing.Size(198, 20);
            this.txtnmAlmacen.TabIndex = 85;
            // 
            // txtcdAlmacen
            // 
            this.txtcdAlmacen.Enabled = false;
            this.txtcdAlmacen.Location = new System.Drawing.Point(66, 99);
            this.txtcdAlmacen.Name = "txtcdAlmacen";
            this.txtcdAlmacen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtcdAlmacen.Size = new System.Drawing.Size(65, 20);
            this.txtcdAlmacen.TabIndex = 88;
            // 
            // labelControl6
            // 
            this.labelControl6.Enabled = false;
            this.labelControl6.Location = new System.Drawing.Point(12, 12);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(49, 13);
            this.labelControl6.TabIndex = 84;
            this.labelControl6.Text = "Operacion";
            // 
            // buttonEdit5
            // 
            this.buttonEdit5.Enabled = false;
            this.buttonEdit5.Location = new System.Drawing.Point(137, 9);
            this.buttonEdit5.Name = "buttonEdit5";
            this.buttonEdit5.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEdit5.Size = new System.Drawing.Size(198, 20);
            this.buttonEdit5.TabIndex = 76;
            // 
            // buttonEdit6
            // 
            this.buttonEdit6.Enabled = false;
            this.buttonEdit6.Location = new System.Drawing.Point(66, 9);
            this.buttonEdit6.Name = "buttonEdit6";
            this.buttonEdit6.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEdit6.Size = new System.Drawing.Size(65, 20);
            this.buttonEdit6.TabIndex = 79;
            // 
            // textEdit4
            // 
            this.textEdit4.Enabled = false;
            this.textEdit4.Location = new System.Drawing.Point(341, 9);
            this.textEdit4.Name = "textEdit4";
            this.textEdit4.Size = new System.Drawing.Size(96, 20);
            this.textEdit4.TabIndex = 80;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(670, 70);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(66, 13);
            this.labelControl5.TabIndex = 75;
            this.labelControl5.Text = "Fecha Entrega";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 73);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(46, 13);
            this.labelControl4.TabIndex = 70;
            this.labelControl4.Text = "Vendedor";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 42);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(34, 13);
            this.labelControl3.TabIndex = 69;
            this.labelControl3.Text = "Cliente";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(670, 44);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(65, 13);
            this.labelControl2.TabIndex = 60;
            this.labelControl2.Text = "FechaEmision";
            // 
            // labelControl1
            // 
            this.labelControl1.Enabled = false;
            this.labelControl1.Location = new System.Drawing.Point(476, 16);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(55, 13);
            this.labelControl1.TabIndex = 59;
            this.labelControl1.Text = "Documento";
            // 
            // txttipoDocumento
            // 
            this.txttipoDocumento.Enabled = false;
            this.txttipoDocumento.Location = new System.Drawing.Point(537, 12);
            this.txttipoDocumento.Name = "txttipoDocumento";
            this.txttipoDocumento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txttipoDocumento.Size = new System.Drawing.Size(198, 20);
            this.txttipoDocumento.TabIndex = 81;
            // 
            // txtdocCliente
            // 
            this.txtdocCliente.Location = new System.Drawing.Point(341, 38);
            this.txtdocCliente.Name = "txtdocCliente";
            this.txtdocCliente.Size = new System.Drawing.Size(96, 20);
            this.txtdocCliente.TabIndex = 63;
            // 
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(12, 451);
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(425, 98);
            this.txtObservacion.TabIndex = 78;
            // 
            // txtcdDocumento
            // 
            this.txtcdDocumento.Enabled = false;
            this.txtcdDocumento.Location = new System.Drawing.Point(741, 12);
            this.txtcdDocumento.Name = "txtcdDocumento";
            this.txtcdDocumento.Size = new System.Drawing.Size(96, 20);
            this.txtcdDocumento.TabIndex = 105;
            // 
            // frmComprobante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 572);
            this.Controls.Add(this.btnFueraRuta);
            this.Controls.Add(this.CodigoFP);
            this.Controls.Add(this.txtformaPago);
            this.Controls.Add(this.labelControl20);
            this.Controls.Add(this.txtcdGestion);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCredito);
            this.Controls.Add(this.btnPrecio);
            this.Controls.Add(this.labelControl15);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.btnImportar);
            this.Controls.Add(this.btnDescuento);
            this.Controls.Add(this.btnBonificar);
            this.Controls.Add(this.btnStock);
            this.Controls.Add(this.simpleButton5);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.labelControl14);
            this.Controls.Add(this.labelControl13);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.txtValorImporteTotal);
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.txtValorRecargo);
            this.Controls.Add(this.txtValorDescuento);
            this.Controls.Add(this.txtValorSubtotal);
            this.Controls.Add(this.txtValorImpuesto);
            this.Controls.Add(this.txtValorInafecto);
            this.Controls.Add(this.txtValorAfecto);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.txtnmAlmacen);
            this.Controls.Add(this.txtcdAlmacen);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.buttonEdit5);
            this.Controls.Add(this.buttonEdit6);
            this.Controls.Add(this.textEdit4);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.dateEntrega);
            this.Controls.Add(this.dateEmision);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtnmCliente);
            this.Controls.Add(this.txtcdCLiente);
            this.Controls.Add(this.txtnmVendedor);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txttipoDocumento);
            this.Controls.Add(this.txtcdVendedor);
            this.Controls.Add(this.txtdocCliente);
            this.Controls.Add(this.txtObservacion);
            this.Controls.Add(this.txtcdDocumento);
            this.Name = "frmComprobante";
            this.Text = "frmComprobate";
            this.Load += new System.EventHandler(this.frmComprobante_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtcdGestion.Properties)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabDetalle.ResumeLayout(false);
            this.tabDetalle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabReparto.ResumeLayout(false);
            this.tabReparto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtcdProvincia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcdDistrito.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcdZona.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtnmZona.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtnmDistrito.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtnmProvincia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtnmDireccion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEntrega.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEntrega.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEmision.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEmision.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtnmCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcdCLiente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtnmVendedor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcdVendedor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorImporteTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorRecargo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorDescuento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorSubtotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorImpuesto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorInafecto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorAfecto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtnmAlmacen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcdAlmacen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit5.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit6.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txttipoDocumento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdocCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtObservacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcdDocumento.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraEditors.CheckButton btnFueraRuta;
        public DevExpress.XtraEditors.LabelControl CodigoFP;
        public DevExpress.XtraEditors.LabelControl txtformaPago;
        private DevExpress.XtraEditors.LabelControl labelControl20;
        public DevExpress.XtraEditors.TextEdit txtcdGestion;
        private DevExpress.XtraEditors.XtraOpenFileDialog xtraOpenFileDialog1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabDetalle;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantpedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn TpPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioNeto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Recargo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Bonif;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Credito;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Afecto;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDBonificacion;
        private System.Windows.Forms.TabPage tabReparto;
        public DevExpress.XtraEditors.TextEdit txtcdProvincia;
        public DevExpress.XtraEditors.TextEdit txtcdDistrito;
        public DevExpress.XtraEditors.TextEdit txtcdZona;
        private DevExpress.XtraEditors.LabelControl labelControl19;
        private DevExpress.XtraEditors.LabelControl labelControl18;
        public DevExpress.XtraEditors.TextEdit txtnmZona;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        public DevExpress.XtraEditors.TextEdit txtnmDistrito;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        public DevExpress.XtraEditors.TextEdit txtnmProvincia;
        public DevExpress.XtraEditors.ButtonEdit txtnmDireccion;
        public DevExpress.XtraEditors.CheckButton btnCredito;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        public DevExpress.XtraEditors.DateEdit dateEntrega;
        public DevExpress.XtraEditors.DateEdit dateEmision;
        public DevExpress.XtraEditors.ButtonEdit txtnmCliente;
        public DevExpress.XtraEditors.ButtonEdit txtcdCLiente;
        public DevExpress.XtraEditors.ButtonEdit txtnmVendedor;
        public DevExpress.XtraEditors.ButtonEdit txtcdVendedor;
        private DevExpress.XtraEditors.SimpleButton btnPrecio;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.SimpleButton btnConsultar;
        private DevExpress.XtraEditors.SimpleButton btnImportar;
        private DevExpress.XtraEditors.SimpleButton btnDescuento;
        private DevExpress.XtraEditors.SimpleButton btnBonificar;
        private DevExpress.XtraEditors.SimpleButton btnStock;
        private DevExpress.XtraEditors.SimpleButton simpleButton5;
        private DevExpress.XtraEditors.SimpleButton btnAgregar;
        private DevExpress.XtraEditors.SimpleButton btnQuitar;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnAceptar;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        public DevExpress.XtraEditors.TextEdit txtValorImporteTotal;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        public DevExpress.XtraEditors.TextEdit txtValorRecargo;
        public DevExpress.XtraEditors.TextEdit txtValorDescuento;
        public DevExpress.XtraEditors.TextEdit txtValorSubtotal;
        public DevExpress.XtraEditors.TextEdit txtValorImpuesto;
        public DevExpress.XtraEditors.TextEdit txtValorInafecto;
        public DevExpress.XtraEditors.TextEdit txtValorAfecto;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.TextEdit txtdocCliente;
        public DevExpress.XtraEditors.MemoEdit txtObservacion;
        public DevExpress.XtraEditors.TextEdit txtcdDocumento;
        public DevExpress.XtraEditors.ButtonEdit txtnmAlmacen;
        public DevExpress.XtraEditors.ButtonEdit txtcdAlmacen;
        public DevExpress.XtraEditors.ButtonEdit buttonEdit5;
        public DevExpress.XtraEditors.ButtonEdit buttonEdit6;
        public DevExpress.XtraEditors.TextEdit textEdit4;
        public DevExpress.XtraEditors.ButtonEdit txttipoDocumento;
        public DevExpress.XtraEditors.LabelControl ANULADO;
    }
}