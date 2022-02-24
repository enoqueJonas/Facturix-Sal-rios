namespace Facturix_Salários.Formularios
{
    partial class frmConsultarContualidade
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultarContualidade));
            this.dataFuncionarios = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRegressar = new System.Windows.Forms.Button();
            this.lblEstado = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDiasTrabalhados = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAusencias = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHorasNoMes = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHorasPorSemana = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nrAno = new System.Windows.Forms.NumericUpDown();
            this.cbMes = new System.Windows.Forms.ComboBox();
            this.nrRegistonr = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataFuncionarios)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nrAno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrRegistonr)).BeginInit();
            this.SuspendLayout();
            // 
            // dataFuncionarios
            // 
            this.dataFuncionarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataFuncionarios.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataFuncionarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataFuncionarios.Location = new System.Drawing.Point(12, 83);
            this.dataFuncionarios.Name = "dataFuncionarios";
            this.dataFuncionarios.RowHeadersVisible = false;
            this.dataFuncionarios.Size = new System.Drawing.Size(712, 350);
            this.dataFuncionarios.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnImprimir);
            this.groupBox2.Controls.Add(this.btnRegressar);
            this.groupBox2.Location = new System.Drawing.Point(12, 488);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(712, 79);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // btnRegressar
            // 
            this.btnRegressar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRegressar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegressar.ForeColor = System.Drawing.Color.Black;
            this.btnRegressar.Image = ((System.Drawing.Image)(resources.GetObject("btnRegressar.Image")));
            this.btnRegressar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRegressar.Location = new System.Drawing.Point(429, 12);
            this.btnRegressar.Margin = new System.Windows.Forms.Padding(2);
            this.btnRegressar.Name = "btnRegressar";
            this.btnRegressar.Size = new System.Drawing.Size(69, 60);
            this.btnRegressar.TabIndex = 6;
            this.btnRegressar.TabStop = false;
            this.btnRegressar.Text = "Regressar";
            this.btnRegressar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRegressar.UseVisualStyleBackColor = true;
            this.btnRegressar.Click += new System.EventHandler(this.btnRegressar_Click);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(286, 201);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(169, 31);
            this.lblEstado.TabIndex = 7;
            this.lblEstado.Text = "Sem Registo";
            this.lblEstado.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 459);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Dias Trabalhados:";
            // 
            // txtDiasTrabalhados
            // 
            this.txtDiasTrabalhados.Enabled = false;
            this.txtDiasTrabalhados.Location = new System.Drawing.Point(104, 456);
            this.txtDiasTrabalhados.Name = "txtDiasTrabalhados";
            this.txtDiasTrabalhados.ReadOnly = true;
            this.txtDiasTrabalhados.Size = new System.Drawing.Size(43, 20);
            this.txtDiasTrabalhados.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(622, 459);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Ausências:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtAusencias
            // 
            this.txtAusencias.Enabled = false;
            this.txtAusencias.Location = new System.Drawing.Point(681, 456);
            this.txtAusencias.Name = "txtAusencias";
            this.txtAusencias.ReadOnly = true;
            this.txtAusencias.Size = new System.Drawing.Size(43, 20);
            this.txtAusencias.TabIndex = 9;
            this.txtAusencias.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(400, 459);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Horas Trabalhadas no Mês:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtHorasNoMes
            // 
            this.txtHorasNoMes.Enabled = false;
            this.txtHorasNoMes.Location = new System.Drawing.Point(535, 456);
            this.txtHorasNoMes.Name = "txtHorasNoMes";
            this.txtHorasNoMes.ReadOnly = true;
            this.txtHorasNoMes.Size = new System.Drawing.Size(43, 20);
            this.txtHorasNoMes.TabIndex = 9;
            this.txtHorasNoMes.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(186, 459);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Horas Trabalhadas por dia:";
            // 
            // txtHorasPorSemana
            // 
            this.txtHorasPorSemana.Enabled = false;
            this.txtHorasPorSemana.Location = new System.Drawing.Point(321, 456);
            this.txtHorasPorSemana.Name = "txtHorasPorSemana";
            this.txtHorasPorSemana.ReadOnly = true;
            this.txtHorasPorSemana.Size = new System.Drawing.Size(43, 20);
            this.txtHorasPorSemana.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(547, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Mês:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(286, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Ano:";
            // 
            // nrAno
            // 
            this.nrAno.Location = new System.Drawing.Point(315, 15);
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
            this.nrAno.Size = new System.Drawing.Size(150, 20);
            this.nrAno.TabIndex = 22;
            this.nrAno.Value = new decimal(new int[] {
            2022,
            0,
            0,
            0});
            this.nrAno.ValueChanged += new System.EventHandler(this.nrAno_ValueChanged_1);
            // 
            // cbMes
            // 
            this.cbMes.FormattingEnabled = true;
            this.cbMes.Items.AddRange(new object[] {
            "",
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
            this.cbMes.Location = new System.Drawing.Point(574, 14);
            this.cbMes.Name = "cbMes";
            this.cbMes.Size = new System.Drawing.Size(150, 21);
            this.cbMes.TabIndex = 11;
            this.cbMes.SelectedIndexChanged += new System.EventHandler(this.cbMes_SelectedIndexChanged);
            // 
            // nrRegistonr
            // 
            this.nrRegistonr.Location = new System.Drawing.Point(74, 15);
            this.nrRegistonr.Name = "nrRegistonr";
            this.nrRegistonr.Size = new System.Drawing.Size(150, 20);
            this.nrRegistonr.TabIndex = 23;
            this.nrRegistonr.ValueChanged += new System.EventHandler(this.nrRegistonr_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Registo n°:";
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.ForeColor = System.Drawing.Color.Black;
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnImprimir.Location = new System.Drawing.Point(200, 14);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(2);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(69, 60);
            this.btnImprimir.TabIndex = 40;
            this.btnImprimir.TabStop = false;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.LightSkyBlue;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(12, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(618, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Nota: Na coluna \"Data\", o vermelho indica que o dia foi não contado como dia trab" +
    "alhado e o verde indica que o dia foi contado.";
            // 
            // frmConsultarContualidade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(736, 571);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.nrRegistonr);
            this.Controls.Add(this.txtAusencias);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nrAno);
            this.Controls.Add(this.cbMes);
            this.Controls.Add(this.txtHorasPorSemana);
            this.Controls.Add(this.txtHorasNoMes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDiasTrabalhados);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dataFuncionarios);
            this.Name = "frmConsultarContualidade";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar Pontualidade";
            this.Load += new System.EventHandler(this.frmConsultarContualidade_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataFuncionarios)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nrAno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrRegistonr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRegressar;
        private System.Windows.Forms.Label lblEstado;
        public System.Windows.Forms.DataGridView dataFuncionarios;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDiasTrabalhados;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAusencias;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHorasNoMes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHorasPorSemana;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nrAno;
        private System.Windows.Forms.ComboBox cbMes;
        public System.Windows.Forms.NumericUpDown nrRegistonr;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Label label8;
    }
}