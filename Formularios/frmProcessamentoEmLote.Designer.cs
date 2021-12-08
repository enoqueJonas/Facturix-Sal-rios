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
            this.dataProcessamentoSalario = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnRegressar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
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
            "Processar",
            "Anular"});
            this.cbOperacao.Location = new System.Drawing.Point(93, 14);
            this.cbOperacao.Name = "cbOperacao";
            this.cbOperacao.Size = new System.Drawing.Size(107, 21);
            this.cbOperacao.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tipo:";
            // 
            // chbVencimento
            // 
            this.chbVencimento.AutoSize = true;
            this.chbVencimento.Location = new System.Drawing.Point(263, 18);
            this.chbVencimento.Name = "chbVencimento";
            this.chbVencimento.Size = new System.Drawing.Size(82, 17);
            this.chbVencimento.TabIndex = 2;
            this.chbVencimento.Text = "Vencimento";
            this.chbVencimento.UseVisualStyleBackColor = true;
            // 
            // chbSubFerias
            // 
            this.chbSubFerias.AutoSize = true;
            this.chbSubFerias.Location = new System.Drawing.Point(363, 18);
            this.chbSubFerias.Name = "chbSubFerias";
            this.chbSubFerias.Size = new System.Drawing.Size(91, 17);
            this.chbSubFerias.TabIndex = 2;
            this.chbSubFerias.Text = "Sub. de férias";
            this.chbSubFerias.UseVisualStyleBackColor = true;
            this.chbSubFerias.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // chbExtraordinario
            // 
            this.chbExtraordinario.AutoSize = true;
            this.chbExtraordinario.Location = new System.Drawing.Point(471, 18);
            this.chbExtraordinario.Name = "chbExtraordinario";
            this.chbExtraordinario.Size = new System.Drawing.Size(90, 17);
            this.chbExtraordinario.TabIndex = 2;
            this.chbExtraordinario.Text = "Extraordinário";
            this.chbExtraordinario.UseVisualStyleBackColor = true;
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
            this.cbMes.Location = new System.Drawing.Point(758, 17);
            this.cbMes.Name = "cbMes";
            this.cbMes.Size = new System.Drawing.Size(105, 21);
            this.cbMes.TabIndex = 22;
            this.cbMes.SelectedIndexChanged += new System.EventHandler(this.cbMes_SelectedIndexChanged);
            // 
            // nrAno
            // 
            this.nrAno.Location = new System.Drawing.Point(631, 17);
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
            this.label3.Location = new System.Drawing.Point(582, 19);
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
            this.dtFaltasHorasExtra.Location = new System.Drawing.Point(327, 51);
            this.dtFaltasHorasExtra.Name = "dtFaltasHorasExtra";
            this.dtFaltasHorasExtra.Size = new System.Drawing.Size(107, 20);
            this.dtFaltasHorasExtra.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(226, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Faltas/H. Extras:";
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
            this.panel2.Controls.Add(this.dataProcessamentoSalario);
            this.panel2.Location = new System.Drawing.Point(25, 146);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(888, 296);
            this.panel2.TabIndex = 28;
            // 
            // dataProcessamentoSalario
            // 
            this.dataProcessamentoSalario.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataProcessamentoSalario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataProcessamentoSalario.Location = new System.Drawing.Point(23, 20);
            this.dataProcessamentoSalario.Name = "dataProcessamentoSalario";
            this.dataProcessamentoSalario.RowHeadersVisible = false;
            this.dataProcessamentoSalario.Size = new System.Drawing.Size(840, 254);
            this.dataProcessamentoSalario.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnRegressar);
            this.panel3.Controls.Add(this.btnImprimir);
            this.panel3.Controls.Add(this.btnConfirmar);
            this.panel3.Controls.Add(this.btnMostrar);
            this.panel3.Controls.Add(this.btnCancelar);
            this.panel3.Controls.Add(this.btnAtualizar);
            this.panel3.Controls.Add(this.btnEliminar);
            this.panel3.Controls.Add(this.btnAdicionar);
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
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.ForeColor = System.Drawing.Color.Black;
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnImprimir.Location = new System.Drawing.Point(686, 6);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(2);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(69, 60);
            this.btnImprimir.TabIndex = 800;
            this.btnImprimir.TabStop = false;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmar.ForeColor = System.Drawing.Color.Black;
            this.btnConfirmar.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirmar.Image")));
            this.btnConfirmar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnConfirmar.Location = new System.Drawing.Point(466, 6);
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
            // btnMostrar
            // 
            this.btnMostrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMostrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMostrar.ForeColor = System.Drawing.Color.Black;
            this.btnMostrar.Image = ((System.Drawing.Image)(resources.GetObject("btnMostrar.Image")));
            this.btnMostrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMostrar.Location = new System.Drawing.Point(131, 6);
            this.btnMostrar.Margin = new System.Windows.Forms.Padding(2);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(69, 60);
            this.btnMostrar.TabIndex = 20000;
            this.btnMostrar.TabStop = false;
            this.btnMostrar.Text = "Consultar";
            this.btnMostrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMostrar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.ForeColor = System.Drawing.Color.Black;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancelar.Location = new System.Drawing.Point(352, 6);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(69, 60);
            this.btnCancelar.TabIndex = 3000;
            this.btnCancelar.TabStop = false;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAtualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAtualizar.ForeColor = System.Drawing.Color.Black;
            this.btnAtualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnAtualizar.Image")));
            this.btnAtualizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAtualizar.Location = new System.Drawing.Point(240, 6);
            this.btnAtualizar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(69, 60);
            this.btnAtualizar.TabIndex = 2000;
            this.btnAtualizar.TabStop = false;
            this.btnAtualizar.Text = "Modificar";
            this.btnAtualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAtualizar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.ForeColor = System.Drawing.Color.Black;
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEliminar.Location = new System.Drawing.Point(578, 6);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(69, 60);
            this.btnEliminar.TabIndex = 1000;
            this.btnEliminar.TabStop = false;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAdicionar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdicionar.ForeColor = System.Drawing.Color.Black;
            this.btnAdicionar.Image = ((System.Drawing.Image)(resources.GetObject("btnAdicionar.Image")));
            this.btnAdicionar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAdicionar.Location = new System.Drawing.Point(21, 6);
            this.btnAdicionar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(69, 60);
            this.btnAdicionar.TabIndex = 3000;
            this.btnAdicionar.TabStop = false;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAdicionar.UseVisualStyleBackColor = true;
            // 
            // frmProcessamentoEmLote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(938, 556);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmProcessamentoEmLote";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Processamento em lote";
            this.Load += new System.EventHandler(this.frmProcessamentoEmLote_Load);
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
        private System.Windows.Forms.DataGridView dataProcessamentoSalario;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnRegressar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnMostrar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAdicionar;
    }
}