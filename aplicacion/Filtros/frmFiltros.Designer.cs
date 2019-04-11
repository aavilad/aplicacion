namespace xtraForm.Filtros
{
    partial class frmFiltros
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Campo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Condicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Union = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgregar = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.cboxCampo = new System.Windows.Forms.ComboBox();
            this.cboxCondicion = new System.Windows.Forms.ComboBox();
            this.txtValor = new DevExpress.XtraEditors.TextEdit();
            this.cboxUnion = new System.Windows.Forms.ComboBox();
            this.btnQuitar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValor.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Campo,
            this.Condicion,
            this.Valor,
            this.Union});
            this.dataGridView1.Location = new System.Drawing.Point(0, 24);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(505, 169);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // Campo
            // 
            this.Campo.HeaderText = "Campo";
            this.Campo.Name = "Campo";
            this.Campo.ReadOnly = true;
            this.Campo.Width = 121;
            // 
            // Condicion
            // 
            this.Condicion.HeaderText = "Condicion";
            this.Condicion.Name = "Condicion";
            this.Condicion.ReadOnly = true;
            this.Condicion.Width = 121;
            // 
            // Valor
            // 
            this.Valor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            // 
            // Union
            // 
            this.Union.HeaderText = "Y/O";
            this.Union.Name = "Union";
            this.Union.Width = 121;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(349, 195);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(430, 222);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(349, 222);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // cboxCampo
            // 
            this.cboxCampo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboxCampo.FormattingEnabled = true;
            this.cboxCampo.Location = new System.Drawing.Point(42, 3);
            this.cboxCampo.Name = "cboxCampo";
            this.cboxCampo.Size = new System.Drawing.Size(121, 21);
            this.cboxCampo.TabIndex = 4;
            // 
            // cboxCondicion
            // 
            this.cboxCondicion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboxCondicion.FormattingEnabled = true;
            this.cboxCondicion.Location = new System.Drawing.Point(163, 3);
            this.cboxCondicion.Name = "cboxCondicion";
            this.cboxCondicion.Size = new System.Drawing.Size(121, 21);
            this.cboxCondicion.TabIndex = 5;
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(284, 3);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(100, 20);
            this.txtValor.TabIndex = 6;
            // 
            // cboxUnion
            // 
            this.cboxUnion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboxUnion.FormattingEnabled = true;
            this.cboxUnion.Location = new System.Drawing.Point(384, 3);
            this.cboxUnion.Name = "cboxUnion";
            this.cboxUnion.Size = new System.Drawing.Size(121, 21);
            this.cboxUnion.TabIndex = 7;
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(430, 195);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(75, 23);
            this.btnQuitar.TabIndex = 8;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // frmFiltros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 249);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.cboxUnion);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.cboxCondicion);
            this.Controls.Add(this.cboxCampo);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmFiltros";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValor.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnAgregar;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnAceptar;
        private System.Windows.Forms.ComboBox cboxCondicion;
        private DevExpress.XtraEditors.TextEdit txtValor;
        private System.Windows.Forms.ComboBox cboxUnion;
        public System.Windows.Forms.ComboBox cboxCampo;
        private DevExpress.XtraEditors.SimpleButton btnQuitar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Campo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Condicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Union;
        public System.Windows.Forms.DataGridView dataGridView1;
    }
}