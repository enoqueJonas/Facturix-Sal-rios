namespace Facturix_Salários.Formularios
{
    partial class frmProcessamentoEmLote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProcessamentoEmLote));
            this.label1 = new System.Windows.Forms.Label();
            this.cbOperacao = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chbVencimento = new System.Windows.Forms.CheckBox();
            this.chbSubFerias = new System.Windows.Forms.CheckBox();
            this.chbExtraordinario = new System.Windows.Forms.CheckBox();
            this.cbMes = new System.Windows.Forms.ComboBox();
            this.nrAno = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.dtProcessamento = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dtFaltasHorasExtra = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.dataProcessamentoSalario = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnRegressar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nrAno)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataProcessamentoSalario)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Operação:";
            // 
            // cbOperacao
            // 
            this.cbOperacao.FormattingEnabled = true;
            this.cbOperacao.Items.AddRange(new object[] {
            "Processar"});
            this.cbOperacao.Location = new System.Drawing.Point(93, 14);
            this.cbOperacao.Name = "cbOperacao";
            this.cbOperacao.Size = new System.Drawing.Size(107, 21);
            this.cbOperacao.TabIndex = 1;
            this.cbOperacao.SelectedIndexChanged += new System.EventHandler(this.cbOperacao_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tipo:";
            // 
            // chbVencimento
            // 
            this.chbVencimento.AutoSize = true;
            this.chbVencimento.Location = new System.Drawing.Point(245, 52);
            this.chbVencimento.Name = "chbVencimento";
            this.chbVencimento.Size = new System.Drawing.Size(82, 17);
            this.chbVencimento.TabIndex = 2;
            this.chbVencimento.Text = "Vencimento";
            this.chbVencimento.UseVisualStyleBackColor = true;
            // 
            // chbSubFerias
            // 
            this.chbSubFerias.AutoSize = true;
            this.chbSubFerias.Location = new System.Drawing.Point(345, 52);
            this.chbSubFerias.Name = "chbSubFerias";
            this.chbSubFerias.Size = new System.Drawing.Size(91, 17);
            this.chbSubFerias.TabIndex = 2;
            this.chbSubFerias.Text = "Sub. de férias";
            this.chbSubFerias.UseVisualStyleBackColor = true;
            this.chbSubFerias.Visible = false;
            this.chbSubFerias.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // chbExtraordinario
            // 
            this.chbExtraordinario.AutoSize = true;
            this.chbExtraordinario.Location = new System.Drawing.Point(453, 52);
            this.chbExtraordinario.Name = "chbExtraordinario";
            this.chbExtraordinario.Size = new System.Drawing.Size(90, 17);
            this.chbExtraordinario.TabIndex = 2;
            this.chbExtraordinario.Text = "Extraordinário";
            this.chbExtraordinario.UseVisualStyleBackColor = true;
            this.chbExtraordinario.Visible = false;
            this.chbExtraordinario.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // cbMes
            // 
            this.cbMes.FormattingEnabled = true;
            this.cbMes.Items.AddRange(new object[] {
            "Janeiro",
            "Fevereiro",
            "Março",
            "Abril",
            "Maio",
            "Junho",
            "Julho",
            "Agosto",
            "Setembro",
            "Outubro",
            "Novembro",
            "Dezembro"});
            this.cbMes.Location = new System.Drawing.Point(376, 16);
            this.cbMes.Name = "cbMes";
            this.cbMes.Size = new System.Drawing.Size(105, 21);
            this.cbMes.TabIndex = 22;
            this.cbMes.Visible = false;
            this.cbMes.SelectedIndexChanged += new System.EventHandler(this.cbMes_SelectedIndexChanged);
            // 
            // nrAno
            // 
            this.nrAno.Location = new System.Drawing.Point(257, 17);
            this.nrAno.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nrAno.Minimum = new decimal(new int[] {
            2021,
            0,
            0,
            0});
            this.nrAno.Name = "nrAno";
            this.nrAno.Size = new System.Drawing.Size(111, 20);
            this.nrAno.TabIndex = 21;
            this.nrAno.Value = new decimal(new int[] {
            2021,
            0,
            0,
            0});
            this.nrAno.ValueChanged += new System.EventHandler(this.nrAno_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(208, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Período:";
            // 
            // dtProcessamento
            // 
            this.dtProcessamento.CustomFormat = "dd/MM/yyyy";
            this.dtProcessamento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtProcessamento.Location = new System.Drawing.Point(93, 51);
            this.dtProcessamento.Name = "dtProcessamento";
            this.dtProcessamento.Size = new System.Drawing.Size(107, 20);
            this.dtProcessamento.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Data:";
            // 
            // dtFaltasHorasExtra
            // 
            this.dtFaltasHorasExtra.CustomFormat = "dd/MM/yyyy";
            this.dtFaltasHorasExtra.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFaltasHorasExtra.Location = new System.Drawing.Point(739, 56);
            this.dtFaltasHorasExtra.Name = "dtFaltasHorasExtra";
            this.dtFaltasHorasExtra.Size = new System.Drawing.Size(107, 20);
            this.dtFaltasHorasExtra.TabIndex = 26;
            this.dtFaltasHorasExtra.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(638, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Faltas/H. Extras:";
            this.label6.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dtFaltasHorasExtra);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.dtProcessamento);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cbMes);
            this.panel1.Controls.Add(this.nrAno);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.chbExtraordinario);
            this.panel1.Controls.Add(this.chbSubFerias);
            this.panel1.Controls.Add(this.chbVencimento);
            this.panel1.Controls.Add(this.cbOperacao);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(25, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(888, 104);
            this.panel1.TabIndex = 27;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnRefrescar);
            this.panel2.Controls.Add(this.dataProcessamentoSalario);
            this.panel2.Location = new System.Drawing.Point(25, 139);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(888, 309);
            this.panel2.TabIndex = 28;
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Location = new System.Drawing.Point(23, 280);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(108, 23);
            this.btnRefrescar.TabIndex = 3;
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.UseVisualStyleBackColor = true;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // dataProcessamentoSalario
            // 
            this.dataProcessamentoSalario.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataProcessamentoSalario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataProcessamentoSalario.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataProcessamentoSalario.Location = new System.Drawing.Point(23, 20);
            this.dataProcessamentoSalario.Name = "dataProcessamentoSalario";
            this.dataProcessamentoSalario.RowHeadersVisible = false;
            this.dataProcessamentoSalario.Size = new System.Drawing.Size(836, 254);
            this.dataProcessamentoSalario.TabIndex = 2;
            this.dataProcessamentoSalario.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataProcessamentoSalario_CellBeginEdit);
            this.dataProcessamentoSalario.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataProcessamentoSalario_CellClick);
            this.dataProcessamentoSalario.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataProcessamentoSalario_CellDoubleClick);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnRegressar);
            this.panel3.Controls.Add(this.btnImprimir);
            this.panel3.Controls.Add(this.btnConfirmar);
            this.panel3.Location = new System.Drawing.Point(25, 466);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(888, 74);
            this.panel3.TabIndex = 29;
            // 
            // btnRegressar
            // 
            this.btnRegressar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRegressar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegressar.ForeColor = System.Drawing.Color.Black;
            this.btnRegressar.Image = ((System.Drawing.Image)(resources.GetObject("btnRegressar.Image")));
            this.btnRegressar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRegressar.Location = new System.Drawing.Point(794, 6);
            this.btnRegressar.Margin = new System.Windows.Forms.Padding(2);
            this.btnRegressar.Name = "btnRegressar";
            this.btnRegressar.Size = new System.Drawing.Size(69, 60);
            this.btnRegressar.TabIndex = 900000;
            this.btnRegressar.TabStop = false;
            this.btnRegressar.Text = "Regressar";
            this.btnRegressar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRegressar.UseVisualStyleBackColor = true;
            this.btnRegressar.Click += new System.EventHandler(this.btnRegressar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.ForeColor = System.Drawing.Color.Black;
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnImprimir.Location = new System.Drawing.Point(412, 6);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(2);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(69, 60);
            this.btnImprimir.TabIndex = 800;
            this.btnImprimir.TabStop = false;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmar.ForeColor = System.Drawing.Color.Black;
            this.btnConfirmar.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirmar.Image")));
            this.btnConfirmar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnConfirmar.Location = new System.Drawing.Point(23, 6);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(69, 60);
            this.btnConfirmar.TabIndex = 700;
            this.btnConfirmar.TabStop = false;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // frmProcessamentoEmLote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(939, 556);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmProcessamentoEmLote";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Processamento em lote";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmProcessamentoEmLote_FormClosing);
            this.Load += new System.EventHandler(this.frmProcessamentoEmLote_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmProcessamentoEmLote_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.nrAno)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataProcessamentoSalario)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbOperacao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chbVencimento;
        private System.Windows.Forms.CheckBox chbSubFerias;
        private System.Windows.Forms.CheckBox chbExtraordinario;
        private System.Windows.Forms.ComboBox cbMes;
        private System.Windows.Forms.NumericUpDown nrAno;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtProcessamento;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtFaltasHorasExtra;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnRegressar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnRefrescar;
        public System.Windows.Forms.DataGridView dataProcessamentoSalario;
    }
}