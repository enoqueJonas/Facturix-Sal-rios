namespace Facturix_Salários.Formularios
{
    partial class frmProcessamentoIndividual
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProcessamentoIndividual));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTotalDescontar = new System.Windows.Forms.TextBox();
            this.txtadiantamentos = new System.Windows.Forms.TextBox();
            this.txtIpa = new System.Windows.Forms.TextBox();
            this.txtIrps = new System.Windows.Forms.TextBox();
            this.txtemprestimoMedico = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtDataProcessamento = new System.Windows.Forms.DateTimePicker();
            this.dtDataHorasExtraEFaltas = new System.Windows.Forms.DateTimePicker();
            this.cbMes = new System.Windows.Forms.ComboBox();
            this.cbTipoProcessamento = new System.Windows.Forms.ComboBox();
            this.nrAno = new System.Windows.Forms.NumericUpDown();
            this.nrDias = new System.Windows.Forms.NumericUpDown();
            this.nrRegistonr = new System.Windows.Forms.NumericUpDown();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataProcessamentoSalario = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRegressar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtTotalRemuneracoes = new System.Windows.Forms.TextBox();
            this.txtAjudaDeCusto = new System.Windows.Forms.TextBox();
            this.txtSubTransporte = new System.Windows.Forms.TextBox();
            this.txtSubAlimentacao = new System.Windows.Forms.TextBox();
            this.txtVencimento = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nrAno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrDias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrRegistonr)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataProcessamentoSalario)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtTotalDescontar);
            this.groupBox1.Controls.Add(this.txtadiantamentos);
            this.groupBox1.Controls.Add(this.txtIpa);
            this.groupBox1.Controls.Add(this.txtIrps);
            this.groupBox1.Controls.Add(this.txtemprestimoMedico);
            this.groupBox1.Location = new System.Drawing.Point(31, 180);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(297, 151);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Descontos";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(21, 123);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(106, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "Total a Descont.:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(21, 97);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(80, 13);
            this.label17.TabIndex = 14;
            this.label17.Text = "Adiantamentos:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "IPA:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "IRPS:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Empréstimo Médico:";
            // 
            // txtTotalDescontar
            // 
            this.txtTotalDescontar.Location = new System.Drawing.Point(129, 120);
            this.txtTotalDescontar.Name = "txtTotalDescontar";
            this.txtTotalDescontar.Size = new System.Drawing.Size(141, 20);
            this.txtTotalDescontar.TabIndex = 15;
            // 
            // txtadiantamentos
            // 
            this.txtadiantamentos.Location = new System.Drawing.Point(129, 94);
            this.txtadiantamentos.Name = "txtadiantamentos";
            this.txtadiantamentos.Size = new System.Drawing.Size(141, 20);
            this.txtadiantamentos.TabIndex = 15;
            // 
            // txtIpa
            // 
            this.txtIpa.Location = new System.Drawing.Point(129, 67);
            this.txtIpa.Name = "txtIpa";
            this.txtIpa.Size = new System.Drawing.Size(141, 20);
            this.txtIpa.TabIndex = 15;
            // 
            // txtIrps
            // 
            this.txtIrps.Location = new System.Drawing.Point(129, 41);
            this.txtIrps.Name = "txtIrps";
            this.txtIrps.Size = new System.Drawing.Size(141, 20);
            this.txtIrps.TabIndex = 15;
            // 
            // txtemprestimoMedico
            // 
            this.txtemprestimoMedico.Location = new System.Drawing.Point(129, 15);
            this.txtemprestimoMedico.Name = "txtemprestimoMedico";
            this.txtemprestimoMedico.Size = new System.Drawing.Size(141, 20);
            this.txtemprestimoMedico.TabIndex = 15;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtDataProcessamento);
            this.groupBox2.Controls.Add(this.dtDataHorasExtraEFaltas);
            this.groupBox2.Controls.Add(this.cbMes);
            this.groupBox2.Controls.Add(this.cbTipoProcessamento);
            this.groupBox2.Controls.Add(this.nrAno);
            this.groupBox2.Controls.Add(this.nrDias);
            this.groupBox2.Controls.Add(this.nrRegistonr);
            this.groupBox2.Controls.Add(this.txtNome);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(31, 17);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(679, 151);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // dtDataProcessamento
            // 
            this.dtDataProcessamento.CustomFormat = "dd/MM/yyyy";
            this.dtDataProcessamento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDataProcessamento.Location = new System.Drawing.Point(525, 104);
            this.dtDataProcessamento.Name = "dtDataProcessamento";
            this.dtDataProcessamento.Size = new System.Drawing.Size(127, 20);
            this.dtDataProcessamento.TabIndex = 21;
            // 
            // dtDataHorasExtraEFaltas
            // 
            this.dtDataHorasExtraEFaltas.CustomFormat = "dd/MM/yyyy";
            this.dtDataHorasExtraEFaltas.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDataHorasExtraEFaltas.Location = new System.Drawing.Point(351, 103);
            this.dtDataHorasExtraEFaltas.Name = "dtDataHorasExtraEFaltas";
            this.dtDataHorasExtraEFaltas.Size = new System.Drawing.Size(127, 20);
            this.dtDataHorasExtraEFaltas.TabIndex = 22;
            // 
            // cbMes
            // 
            this.cbMes.FormattingEnabled = true;
            this.cbMes.Items.AddRange(new object[] {
            "Vencimento"});
            this.cbMes.Location = new System.Drawing.Point(506, 65);
            this.cbMes.Name = "cbMes";
            this.cbMes.Size = new System.Drawing.Size(146, 21);
            this.cbMes.TabIndex = 19;
            // 
            // cbTipoProcessamento
            // 
            this.cbTipoProcessamento.FormattingEnabled = true;
            this.cbTipoProcessamento.Items.AddRange(new object[] {
            "Vencimento"});
            this.cbTipoProcessamento.Location = new System.Drawing.Point(82, 65);
            this.cbTipoProcessamento.Name = "cbTipoProcessamento";
            this.cbTipoProcessamento.Size = new System.Drawing.Size(152, 21);
            this.cbTipoProcessamento.TabIndex = 20;
            // 
            // nrAno
            // 
            this.nrAno.Location = new System.Drawing.Point(350, 65);
            this.nrAno.Maximum = new decimal(new int[] {
            2300,
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
            this.nrAno.TabIndex = 16;
            this.nrAno.Value = new decimal(new int[] {
            2021,
            0,
            0,
            0});
            // 
            // nrDias
            // 
            this.nrDias.Location = new System.Drawing.Point(82, 104);
            this.nrDias.Name = "nrDias";
            this.nrDias.Size = new System.Drawing.Size(150, 20);
            this.nrDias.TabIndex = 17;
            // 
            // nrRegistonr
            // 
            this.nrRegistonr.Location = new System.Drawing.Point(84, 28);
            this.nrRegistonr.Name = "nrRegistonr";
            this.nrRegistonr.Size = new System.Drawing.Size(150, 20);
            this.nrRegistonr.TabIndex = 18;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(350, 27);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(302, 20);
            this.txtNome.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(259, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Nome:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(486, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Data:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(259, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Faltas/H. Extras:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(259, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Período:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Dias:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Processar:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Registo n°:";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dataProcessamentoSalario);
            this.panel2.Location = new System.Drawing.Point(31, 347);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(679, 162);
            this.panel2.TabIndex = 5;
            // 
            // dataProcessamentoSalario
            // 
            this.dataProcessamentoSalario.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataProcessamentoSalario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataProcessamentoSalario.Location = new System.Drawing.Point(23, 16);
            this.dataProcessamentoSalario.Name = "dataProcessamentoSalario";
            this.dataProcessamentoSalario.RowHeadersVisible = false;
            this.dataProcessamentoSalario.Size = new System.Drawing.Size(628, 123);
            this.dataProcessamentoSalario.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnRegressar);
            this.panel1.Controls.Add(this.btnImprimir);
            this.panel1.Controls.Add(this.btnConfirmar);
            this.panel1.Controls.Add(this.btnMostrar);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Location = new System.Drawing.Point(31, 523);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(679, 74);
            this.panel1.TabIndex = 6;
            // 
            // btnRegressar
            // 
            this.btnRegressar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRegressar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegressar.ForeColor = System.Drawing.Color.Black;
            this.btnRegressar.Image = ((System.Drawing.Image)(resources.GetObject("btnRegressar.Image")));
            this.btnRegressar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRegressar.Location = new System.Drawing.Point(582, 6);
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
            this.btnImprimir.Location = new System.Drawing.Point(450, 6);
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
            this.btnConfirmar.Location = new System.Drawing.Point(301, 6);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(69, 60);
            this.btnConfirmar.TabIndex = 700;
            this.btnConfirmar.TabStop = false;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConfirmar.UseVisualStyleBackColor = true;
            // 
            // btnMostrar
            // 
            this.btnMostrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMostrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMostrar.ForeColor = System.Drawing.Color.Black;
            this.btnMostrar.Image = ((System.Drawing.Image)(resources.GetObject("btnMostrar.Image")));
            this.btnMostrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMostrar.Location = new System.Drawing.Point(23, 6);
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
            this.btnCancelar.Location = new System.Drawing.Point(164, 6);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(69, 60);
            this.btnCancelar.TabIndex = 3000;
            this.btnCancelar.TabStop = false;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.txtTotalRemuneracoes);
            this.groupBox3.Controls.Add(this.txtAjudaDeCusto);
            this.groupBox3.Controls.Add(this.txtSubTransporte);
            this.groupBox3.Controls.Add(this.txtSubAlimentacao);
            this.groupBox3.Controls.Add(this.txtVencimento);
            this.groupBox3.Location = new System.Drawing.Point(413, 180);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(297, 151);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Remunerações";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(17, 123);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(94, 13);
            this.label16.TabIndex = 14;
            this.label16.Text = "Total Remune.:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(18, 97);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 13);
            this.label12.TabIndex = 14;
            this.label12.Text = "Ajuda de Custo:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(18, 70);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(86, 13);
            this.label13.TabIndex = 14;
            this.label13.Text = "Sub. Transporte:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(18, 44);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(93, 13);
            this.label14.TabIndex = 14;
            this.label14.Text = "Sub. Alimentação:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(18, 18);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(66, 13);
            this.label15.TabIndex = 14;
            this.label15.Text = "Vencimento:";
            // 
            // txtTotalRemuneracoes
            // 
            this.txtTotalRemuneracoes.Location = new System.Drawing.Point(129, 120);
            this.txtTotalRemuneracoes.Name = "txtTotalRemuneracoes";
            this.txtTotalRemuneracoes.Size = new System.Drawing.Size(141, 20);
            this.txtTotalRemuneracoes.TabIndex = 15;
            // 
            // txtAjudaDeCusto
            // 
            this.txtAjudaDeCusto.Location = new System.Drawing.Point(129, 94);
            this.txtAjudaDeCusto.Name = "txtAjudaDeCusto";
            this.txtAjudaDeCusto.Size = new System.Drawing.Size(141, 20);
            this.txtAjudaDeCusto.TabIndex = 15;
            // 
            // txtSubTransporte
            // 
            this.txtSubTransporte.Location = new System.Drawing.Point(129, 67);
            this.txtSubTransporte.Name = "txtSubTransporte";
            this.txtSubTransporte.Size = new System.Drawing.Size(141, 20);
            this.txtSubTransporte.TabIndex = 15;
            // 
            // txtSubAlimentacao
            // 
            this.txtSubAlimentacao.Location = new System.Drawing.Point(129, 41);
            this.txtSubAlimentacao.Name = "txtSubAlimentacao";
            this.txtSubAlimentacao.Size = new System.Drawing.Size(141, 20);
            this.txtSubAlimentacao.TabIndex = 15;
            // 
            // txtVencimento
            // 
            this.txtVencimento.Location = new System.Drawing.Point(129, 15);
            this.txtVencimento.Name = "txtVencimento";
            this.txtVencimento.Size = new System.Drawing.Size(141, 20);
            this.txtVencimento.TabIndex = 15;
            // 
            // frmProcessamentoIndividual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(745, 622);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmProcessamentoIndividual";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Processamento Individual";
            this.Load += new System.EventHandler(this.frmProcessamentoIndividual_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nrAno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrDias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrRegistonr)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataProcessamentoSalario)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRegressar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnMostrar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        public System.Windows.Forms.TextBox txtemprestimoMedico;
        public System.Windows.Forms.DateTimePicker dtDataProcessamento;
        public System.Windows.Forms.DateTimePicker dtDataHorasExtraEFaltas;
        public System.Windows.Forms.ComboBox cbMes;
        public System.Windows.Forms.ComboBox cbTipoProcessamento;
        public System.Windows.Forms.NumericUpDown nrAno;
        public System.Windows.Forms.NumericUpDown nrDias;
        public System.Windows.Forms.NumericUpDown nrRegistonr;
        public System.Windows.Forms.TextBox txtNome;
        public System.Windows.Forms.TextBox txtIrps;
        public System.Windows.Forms.TextBox txtIpa;
        public System.Windows.Forms.TextBox txtTotalDescontar;
        public System.Windows.Forms.DataGridView dataProcessamentoSalario;
        public System.Windows.Forms.TextBox txtAjudaDeCusto;
        public System.Windows.Forms.TextBox txtSubTransporte;
        public System.Windows.Forms.TextBox txtSubAlimentacao;
        public System.Windows.Forms.TextBox txtVencimento;
        public System.Windows.Forms.TextBox txtTotalRemuneracoes;
        public System.Windows.Forms.TextBox txtadiantamentos;
    }
}