namespace Facturix_Salários.Formularios
{
    partial class frmRemuneracoes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRemuneracoes));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRegistoNr = new System.Windows.Forms.TextBox();
            this.txtPercentagem = new System.Windows.Forms.TextBox();
            this.cbGrupo = new System.Windows.Forms.ComboBox();
            this.cbNatureza = new System.Windows.Forms.ComboBox();
            this.cbQuantidade = new System.Windows.Forms.ComboBox();
            this.chbSegurancaSocial = new System.Windows.Forms.CheckBox();
            this.chbIrps = new System.Windows.Forms.CheckBox();
            this.chbSeguro = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl6 = new System.Windows.Forms.Label();
            this.lbl5 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl7 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.cbInsento = new System.Windows.Forms.ComboBox();
            this.cbValorUnit = new System.Windows.Forms.ComboBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbl10 = new System.Windows.Forms.Label();
            this.lbl9 = new System.Windows.Forms.Label();
            this.lbl8 = new System.Windows.Forms.Label();
            this.btnRegressar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Registo n°:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Grupo:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Natureza:";
            this.label3.Click += new System.EventHandler(this.label2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Percentagem:";
            this.label4.Click += new System.EventHandler(this.label2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Quantidade:";
            this.label5.Click += new System.EventHandler(this.label2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Valor Unit.:";
            this.label6.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtRegistoNr
            // 
            this.txtRegistoNr.Location = new System.Drawing.Point(96, 15);
            this.txtRegistoNr.Name = "txtRegistoNr";
            this.txtRegistoNr.Size = new System.Drawing.Size(100, 20);
            this.txtRegistoNr.TabIndex = 1;
            this.txtRegistoNr.TextChanged += new System.EventHandler(this.txtRegistoNr_TextChanged);
            // 
            // txtPercentagem
            // 
            this.txtPercentagem.Location = new System.Drawing.Point(96, 41);
            this.txtPercentagem.Name = "txtPercentagem";
            this.txtPercentagem.Size = new System.Drawing.Size(100, 20);
            this.txtPercentagem.TabIndex = 1;
            this.txtPercentagem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPercentagem_KeyDown);
            // 
            // cbGrupo
            // 
            this.cbGrupo.FormattingEnabled = true;
            this.cbGrupo.Items.AddRange(new object[] {
            "Vencimento",
            "Subsídio de Alimentação",
            "Subsídio de Transporte",
            "Subsídio de Natal",
            "Subsídio de Comunicação",
            "Subsídio de Falhas",
            "Subsídio de Férias",
            "Subsídio de Turnos",
            "Ajuda De Custos",
            "Diuturnidades",
            "Hora Suplementar",
            "Outras Remunerações Regulares",
            "Outras Remunerações irregulares",
            "Falta(Vencimento)",
            "Falta(Turno)",
            "Falta(Alimentação)"});
            this.cbGrupo.Location = new System.Drawing.Point(96, 67);
            this.cbGrupo.Name = "cbGrupo";
            this.cbGrupo.Size = new System.Drawing.Size(229, 21);
            this.cbGrupo.TabIndex = 2;
            this.cbGrupo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbGrupo_KeyDown);
            // 
            // cbNatureza
            // 
            this.cbNatureza.FormattingEnabled = true;
            this.cbNatureza.Items.AddRange(new object[] {
            "A- Ajudas De Custo e Transportes",
            "B- Prémios, bónus e outros mensais",
            "C- Comissões",
            "D- Compensação por cessação do contrato",
            "E- Subsídio de férias ",
            "F- Honorários de prestação de serviços",
            "G- Subsídios singulares mensais",
            "H- Subsídio de Natal",
            "I-  Prémios, bónus e outros não mensais",
            "J- Subsídio de Alimentação",
            "K- Trabalho suplementar",
            "L- Trabalho nocturno",
            "M-  Subsídios regulares mensais",
            "N- Férias pagas não gozadas",
            "O- Diferenças de vencimento ",
            "P- Compensação do contrato interminente"});
            this.cbNatureza.Location = new System.Drawing.Point(96, 94);
            this.cbNatureza.Name = "cbNatureza";
            this.cbNatureza.Size = new System.Drawing.Size(229, 21);
            this.cbNatureza.TabIndex = 3;
            this.cbNatureza.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbNatureza_KeyDown);
            // 
            // cbQuantidade
            // 
            this.cbQuantidade.FormattingEnabled = true;
            this.cbQuantidade.Items.AddRange(new object[] {
            "Definido pelo utilizador",
            "1 Unidade",
            "Dias de Vencimento",
            "Dias de Alimentação"});
            this.cbQuantidade.Location = new System.Drawing.Point(96, 121);
            this.cbQuantidade.Name = "cbQuantidade";
            this.cbQuantidade.Size = new System.Drawing.Size(229, 21);
            this.cbQuantidade.TabIndex = 4;
            this.cbQuantidade.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbQuantidade_KeyDown);
            // 
            // chbSegurancaSocial
            // 
            this.chbSegurancaSocial.AutoSize = true;
            this.chbSegurancaSocial.Location = new System.Drawing.Point(20, 19);
            this.chbSegurancaSocial.Name = "chbSegurancaSocial";
            this.chbSegurancaSocial.Size = new System.Drawing.Size(110, 17);
            this.chbSegurancaSocial.TabIndex = 3;
            this.chbSegurancaSocial.Text = "Segurança Social";
            this.chbSegurancaSocial.UseVisualStyleBackColor = true;
            // 
            // chbIrps
            // 
            this.chbIrps.AutoSize = true;
            this.chbIrps.Location = new System.Drawing.Point(20, 42);
            this.chbIrps.Name = "chbIrps";
            this.chbIrps.Size = new System.Drawing.Size(51, 17);
            this.chbIrps.TabIndex = 3;
            this.chbIrps.Text = "IRPS";
            this.chbIrps.UseVisualStyleBackColor = true;
            // 
            // chbSeguro
            // 
            this.chbSeguro.AutoSize = true;
            this.chbSeguro.Location = new System.Drawing.Point(20, 65);
            this.chbSeguro.Name = "chbSeguro";
            this.chbSeguro.Size = new System.Drawing.Size(60, 17);
            this.chbSeguro.TabIndex = 3;
            this.chbSeguro.Text = "Seguro";
            this.chbSeguro.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl6);
            this.groupBox1.Controls.Add(this.lbl5);
            this.groupBox1.Controls.Add(this.lbl4);
            this.groupBox1.Controls.Add(this.lbl3);
            this.groupBox1.Controls.Add(this.lbl2);
            this.groupBox1.Controls.Add(this.lbl7);
            this.groupBox1.Controls.Add(this.lbl1);
            this.groupBox1.Controls.Add(this.cbNatureza);
            this.groupBox1.Controls.Add(this.cbInsento);
            this.groupBox1.Controls.Add(this.cbValorUnit);
            this.groupBox1.Controls.Add(this.cbQuantidade);
            this.groupBox1.Controls.Add(this.cbGrupo);
            this.groupBox1.Controls.Add(this.txtValor);
            this.groupBox1.Controls.Add(this.txtPercentagem);
            this.groupBox1.Controls.Add(this.txtRegistoNr);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(21, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(345, 210);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // lbl6
            // 
            this.lbl6.AutoSize = true;
            this.lbl6.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbl6.Location = new System.Drawing.Point(6, 151);
            this.lbl6.Name = "lbl6";
            this.lbl6.Size = new System.Drawing.Size(13, 13);
            this.lbl6.TabIndex = 3;
            this.lbl6.Text = "6";
            this.lbl6.Visible = false;
            // 
            // lbl5
            // 
            this.lbl5.AutoSize = true;
            this.lbl5.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbl5.Location = new System.Drawing.Point(6, 125);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(13, 13);
            this.lbl5.TabIndex = 3;
            this.lbl5.Text = "5";
            this.lbl5.Visible = false;
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbl4.Location = new System.Drawing.Point(6, 97);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(13, 13);
            this.lbl4.TabIndex = 3;
            this.lbl4.Text = "4";
            this.lbl4.Visible = false;
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbl3.Location = new System.Drawing.Point(6, 71);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(13, 13);
            this.lbl3.TabIndex = 3;
            this.lbl3.Text = "3";
            this.lbl3.Visible = false;
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbl2.Location = new System.Drawing.Point(6, 44);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(13, 13);
            this.lbl2.TabIndex = 3;
            this.lbl2.Text = "2";
            this.lbl2.Visible = false;
            // 
            // lbl7
            // 
            this.lbl7.AutoSize = true;
            this.lbl7.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbl7.Location = new System.Drawing.Point(6, 178);
            this.lbl7.Name = "lbl7";
            this.lbl7.Size = new System.Drawing.Size(13, 13);
            this.lbl7.TabIndex = 3;
            this.lbl7.Text = "7";
            this.lbl7.Visible = false;
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbl1.Location = new System.Drawing.Point(6, 18);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(13, 13);
            this.lbl1.TabIndex = 3;
            this.lbl1.Text = "1";
            this.lbl1.Visible = false;
            // 
            // cbInsento
            // 
            this.cbInsento.FormattingEnabled = true;
            this.cbInsento.Items.AddRange(new object[] {
            "Definido pelo utilizador",
            "5% do vencimento base"});
            this.cbInsento.Location = new System.Drawing.Point(96, 174);
            this.cbInsento.Name = "cbInsento";
            this.cbInsento.Size = new System.Drawing.Size(159, 21);
            this.cbInsento.TabIndex = 6;
            this.cbInsento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbInsento_KeyDown);
            // 
            // cbValorUnit
            // 
            this.cbValorUnit.FormattingEnabled = true;
            this.cbValorUnit.Items.AddRange(new object[] {
            "Definido pelo utilizador",
            "1 dia de Vencimento",
            "1 dia de Alimentação",
            "1 hora de vencimento",
            "1 diuturnidade"});
            this.cbValorUnit.Location = new System.Drawing.Point(96, 147);
            this.cbValorUnit.Name = "cbValorUnit";
            this.cbValorUnit.Size = new System.Drawing.Size(229, 21);
            this.cbValorUnit.TabIndex = 5;
            this.cbValorUnit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbValorUnit_KeyDown);
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(261, 175);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(64, 20);
            this.txtValor.TabIndex = 7;
            this.txtValor.Text = "MZN";
            this.txtValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValor.Click += new System.EventHandler(this.txtValor_Click);
            this.txtValor.TextChanged += new System.EventHandler(this.txtValor_TextChanged);
            this.txtValor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtValor_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Isento Até:";
            this.label7.Click += new System.EventHandler(this.label2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chbSeguro);
            this.groupBox2.Controls.Add(this.chbIrps);
            this.groupBox2.Controls.Add(this.chbSegurancaSocial);
            this.groupBox2.Controls.Add(this.lbl10);
            this.groupBox2.Controls.Add(this.lbl9);
            this.groupBox2.Controls.Add(this.lbl8);
            this.groupBox2.Location = new System.Drawing.Point(381, 79);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(134, 94);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Descontos";
            // 
            // lbl10
            // 
            this.lbl10.AutoSize = true;
            this.lbl10.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl10.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbl10.Location = new System.Drawing.Point(6, 66);
            this.lbl10.Name = "lbl10";
            this.lbl10.Size = new System.Drawing.Size(19, 13);
            this.lbl10.TabIndex = 3;
            this.lbl10.Text = "10";
            this.lbl10.Visible = false;
            // 
            // lbl9
            // 
            this.lbl9.AutoSize = true;
            this.lbl9.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl9.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbl9.Location = new System.Drawing.Point(6, 43);
            this.lbl9.Name = "lbl9";
            this.lbl9.Size = new System.Drawing.Size(13, 13);
            this.lbl9.TabIndex = 3;
            this.lbl9.Text = "9";
            this.lbl9.Visible = false;
            // 
            // lbl8
            // 
            this.lbl8.AutoSize = true;
            this.lbl8.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl8.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbl8.Location = new System.Drawing.Point(6, 20);
            this.lbl8.Name = "lbl8";
            this.lbl8.Size = new System.Drawing.Size(13, 13);
            this.lbl8.TabIndex = 3;
            this.lbl8.Text = "8";
            this.lbl8.Visible = false;
            // 
            // btnRegressar
            // 
            this.btnRegressar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRegressar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegressar.Image = ((System.Drawing.Image)(resources.GetObject("btnRegressar.Image")));
            this.btnRegressar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRegressar.Location = new System.Drawing.Point(408, 9);
            this.btnRegressar.Margin = new System.Windows.Forms.Padding(2);
            this.btnRegressar.Name = "btnRegressar";
            this.btnRegressar.Size = new System.Drawing.Size(69, 60);
            this.btnRegressar.TabIndex = 3007;
            this.btnRegressar.Text = "Regressar";
            this.btnRegressar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRegressar.UseVisualStyleBackColor = true;
            this.btnRegressar.Click += new System.EventHandler(this.btnRegressar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmar.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirmar.Image")));
            this.btnConfirmar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnConfirmar.Location = new System.Drawing.Point(212, 9);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(69, 60);
            this.btnConfirmar.TabIndex = 3006;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancelar.Location = new System.Drawing.Point(114, 9);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(69, 60);
            this.btnCancelar.TabIndex = 3009;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEliminar.Location = new System.Drawing.Point(309, 9);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(69, 60);
            this.btnEliminar.TabIndex = 3008;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnAdicionar);
            this.panel1.Controls.Add(this.btnRegressar);
            this.panel1.Controls.Add(this.btnConfirmar);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnEliminar);
            this.panel1.Location = new System.Drawing.Point(21, 239);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(494, 77);
            this.panel1.TabIndex = 3010;
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAdicionar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdicionar.Image = ((System.Drawing.Image)(resources.GetObject("btnAdicionar.Image")));
            this.btnAdicionar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAdicionar.Location = new System.Drawing.Point(17, 9);
            this.btnAdicionar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(69, 60);
            this.btnAdicionar.TabIndex = 3010;
            this.btnAdicionar.Text = "\r\nAdicionar";
            this.btnAdicionar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // frmRemuneracoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(535, 330);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.Name = "frmRemuneracoes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Remunerações";
            this.Load += new System.EventHandler(this.frmRemuneracoes_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRemuneracoes_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRegressar;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Label lbl6;
        private System.Windows.Forms.Label lbl5;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lbl9;
        private System.Windows.Forms.Label lbl8;
        private System.Windows.Forms.Label lbl7;
        public System.Windows.Forms.TextBox txtRegistoNr;
        public System.Windows.Forms.TextBox txtPercentagem;
        public System.Windows.Forms.ComboBox cbGrupo;
        public System.Windows.Forms.ComboBox cbNatureza;
        public System.Windows.Forms.ComboBox cbQuantidade;
        public System.Windows.Forms.CheckBox chbSegurancaSocial;
        public System.Windows.Forms.CheckBox chbIrps;
        public System.Windows.Forms.CheckBox chbSeguro;
        public System.Windows.Forms.ComboBox cbInsento;
        public System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl10;
        public System.Windows.Forms.ComboBox cbValorUnit;
    }
}