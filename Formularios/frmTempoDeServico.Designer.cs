namespace Facturix_Salários.Formularios
{
    partial class frmTempoDeServico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTempoDeServico));
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnSeguinte = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancelarHora = new System.Windows.Forms.Button();
            this.btnConfirmarHora = new System.Windows.Forms.Button();
            this.btnRemoverHora = new System.Windows.Forms.Button();
            this.btnEditarHora = new System.Windows.Forms.Button();
            this.btnAdicionarHora = new System.Windows.Forms.Button();
            this.chbDeveCalcularAusencia = new System.Windows.Forms.CheckBox();
            this.chbDeveCalcularAtraso = new System.Windows.Forms.CheckBox();
            this.chbDeveCalcularSaidaAdiantada = new System.Windows.Forms.CheckBox();
            this.chbDeveBaterPonto = new System.Windows.Forms.CheckBox();
            this.chbDeveMarcarPonto = new System.Windows.Forms.CheckBox();
            this.nrForaDeServicoM = new System.Windows.Forms.NumericUpDown();
            this.nrTempoDeServicoM = new System.Windows.Forms.NumericUpDown();
            this.nrForaDeServicoH = new System.Windows.Forms.NumericUpDown();
            this.nrTempoServicoH = new System.Windows.Forms.NumericUpDown();
            this.cbServico = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCancelarTurno = new System.Windows.Forms.Button();
            this.btnConfirmarTurno = new System.Windows.Forms.Button();
            this.btnRemoverTurno = new System.Windows.Forms.Button();
            this.btnEditarTurno = new System.Windows.Forms.Button();
            this.btnAdicionarTurno = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chbNormal = new System.Windows.Forms.CheckBox();
            this.chbNoite = new System.Windows.Forms.CheckBox();
            this.chbTarde = new System.Windows.Forms.CheckBox();
            this.chbManha = new System.Windows.Forms.CheckBox();
            this.cbTurno = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblCancelar = new System.Windows.Forms.Label();
            this.lblConfirmar = new System.Windows.Forms.Label();
            this.lblRemover = new System.Windows.Forms.Label();
            this.lblEditar = new System.Windows.Forms.Label();
            this.lblAdicionar = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nrForaDeServicoM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrTempoDeServicoM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrForaDeServicoH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrTempoServicoH)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAnterior
            // 
            this.btnAnterior.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnterior.Location = new System.Drawing.Point(472, 492);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(75, 23);
            this.btnAnterior.TabIndex = 24;
            this.btnAnterior.Text = "Anterior";
            this.btnAnterior.UseVisualStyleBackColor = true;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // btnSeguinte
            // 
            this.btnSeguinte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeguinte.Location = new System.Drawing.Point(579, 492);
            this.btnSeguinte.Name = "btnSeguinte";
            this.btnSeguinte.Size = new System.Drawing.Size(75, 23);
            this.btnSeguinte.TabIndex = 25;
            this.btnSeguinte.Text = "Seguinte";
            this.btnSeguinte.UseVisualStyleBackColor = true;
            this.btnSeguinte.Click += new System.EventHandler(this.btnSeguinte_Click);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Location = new System.Drawing.Point(19, 50);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(169, 81);
            this.textBox3.TabIndex = 23;
            this.textBox3.Text = "Por favor, adicione o horário normal de trabalho da empresa.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Passo à passo:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(215, 21);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(439, 411);
            this.tabControl1.TabIndex = 26;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblCancelar);
            this.tabPage1.Controls.Add(this.lblConfirmar);
            this.tabPage1.Controls.Add(this.lblRemover);
            this.tabPage1.Controls.Add(this.lblEditar);
            this.tabPage1.Controls.Add(this.lblAdicionar);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.chbDeveCalcularAusencia);
            this.tabPage1.Controls.Add(this.chbDeveCalcularAtraso);
            this.tabPage1.Controls.Add(this.chbDeveCalcularSaidaAdiantada);
            this.tabPage1.Controls.Add(this.chbDeveBaterPonto);
            this.tabPage1.Controls.Add(this.chbDeveMarcarPonto);
            this.tabPage1.Controls.Add(this.nrForaDeServicoM);
            this.tabPage1.Controls.Add(this.nrTempoDeServicoM);
            this.tabPage1.Controls.Add(this.nrForaDeServicoH);
            this.tabPage1.Controls.Add(this.nrTempoServicoH);
            this.tabPage1.Controls.Add(this.cbServico);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(431, 385);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Hora de Trabalho";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnCancelarHora);
            this.panel2.Controls.Add(this.btnConfirmarHora);
            this.panel2.Controls.Add(this.btnRemoverHora);
            this.panel2.Controls.Add(this.btnEditarHora);
            this.panel2.Controls.Add(this.btnAdicionarHora);
            this.panel2.Location = new System.Drawing.Point(20, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(188, 37);
            this.panel2.TabIndex = 5;
            // 
            // btnCancelarHora
            // 
            this.btnCancelarHora.BackColor = System.Drawing.Color.White;
            this.btnCancelarHora.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelarHora.BackgroundImage")));
            this.btnCancelarHora.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelarHora.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelarHora.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCancelarHora.Location = new System.Drawing.Point(151, 1);
            this.btnCancelarHora.Name = "btnCancelarHora";
            this.btnCancelarHora.Size = new System.Drawing.Size(30, 30);
            this.btnCancelarHora.TabIndex = 2;
            this.btnCancelarHora.UseVisualStyleBackColor = false;
            this.btnCancelarHora.MouseEnter += new System.EventHandler(this.btnCancelar_MouseEnter);
            this.btnCancelarHora.MouseLeave += new System.EventHandler(this.btnCancelar_MouseLeave);
            // 
            // btnConfirmarHora
            // 
            this.btnConfirmarHora.BackColor = System.Drawing.Color.Transparent;
            this.btnConfirmarHora.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConfirmarHora.BackgroundImage")));
            this.btnConfirmarHora.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnConfirmarHora.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConfirmarHora.ForeColor = System.Drawing.Color.White;
            this.btnConfirmarHora.Location = new System.Drawing.Point(114, 1);
            this.btnConfirmarHora.Name = "btnConfirmarHora";
            this.btnConfirmarHora.Size = new System.Drawing.Size(30, 30);
            this.btnConfirmarHora.TabIndex = 2;
            this.btnConfirmarHora.UseVisualStyleBackColor = false;
            this.btnConfirmarHora.MouseEnter += new System.EventHandler(this.btnConfirmar_MouseEnter);
            this.btnConfirmarHora.MouseLeave += new System.EventHandler(this.btnConfirmar_MouseLeave);
            // 
            // btnRemoverHora
            // 
            this.btnRemoverHora.BackColor = System.Drawing.Color.Transparent;
            this.btnRemoverHora.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRemoverHora.BackgroundImage")));
            this.btnRemoverHora.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRemoverHora.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemoverHora.ForeColor = System.Drawing.Color.White;
            this.btnRemoverHora.Location = new System.Drawing.Point(77, 2);
            this.btnRemoverHora.Name = "btnRemoverHora";
            this.btnRemoverHora.Size = new System.Drawing.Size(30, 30);
            this.btnRemoverHora.TabIndex = 2;
            this.btnRemoverHora.UseVisualStyleBackColor = false;
            this.btnRemoverHora.MouseEnter += new System.EventHandler(this.btnRemover_MouseEnter);
            this.btnRemoverHora.MouseLeave += new System.EventHandler(this.btnRemover_MouseLeave);
            // 
            // btnEditarHora
            // 
            this.btnEditarHora.BackColor = System.Drawing.Color.Transparent;
            this.btnEditarHora.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditarHora.BackgroundImage")));
            this.btnEditarHora.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditarHora.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditarHora.ForeColor = System.Drawing.Color.White;
            this.btnEditarHora.Location = new System.Drawing.Point(40, 2);
            this.btnEditarHora.Name = "btnEditarHora";
            this.btnEditarHora.Size = new System.Drawing.Size(30, 30);
            this.btnEditarHora.TabIndex = 2;
            this.btnEditarHora.UseVisualStyleBackColor = false;
            this.btnEditarHora.MouseEnter += new System.EventHandler(this.btnEditar_MouseEnter);
            this.btnEditarHora.MouseLeave += new System.EventHandler(this.btnEditar_MouseLeave);
            // 
            // btnAdicionarHora
            // 
            this.btnAdicionarHora.BackColor = System.Drawing.Color.Transparent;
            this.btnAdicionarHora.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAdicionarHora.BackgroundImage")));
            this.btnAdicionarHora.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAdicionarHora.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdicionarHora.ForeColor = System.Drawing.Color.White;
            this.btnAdicionarHora.Location = new System.Drawing.Point(3, 1);
            this.btnAdicionarHora.Name = "btnAdicionarHora";
            this.btnAdicionarHora.Size = new System.Drawing.Size(30, 30);
            this.btnAdicionarHora.TabIndex = 2;
            this.btnAdicionarHora.UseVisualStyleBackColor = false;
            this.btnAdicionarHora.MouseEnter += new System.EventHandler(this.btnAdicionar_MouseEnter);
            this.btnAdicionarHora.MouseLeave += new System.EventHandler(this.btnAdicionar_MouseLeave);
            // 
            // chbDeveCalcularAusencia
            // 
            this.chbDeveCalcularAusencia.AutoSize = true;
            this.chbDeveCalcularAusencia.Location = new System.Drawing.Point(21, 293);
            this.chbDeveCalcularAusencia.Name = "chbDeveCalcularAusencia";
            this.chbDeveCalcularAusencia.Size = new System.Drawing.Size(110, 17);
            this.chbDeveCalcularAusencia.TabIndex = 4;
            this.chbDeveCalcularAusencia.Text = "Calcular ausência";
            this.chbDeveCalcularAusencia.UseVisualStyleBackColor = true;
            // 
            // chbDeveCalcularAtraso
            // 
            this.chbDeveCalcularAtraso.AutoSize = true;
            this.chbDeveCalcularAtraso.Location = new System.Drawing.Point(21, 260);
            this.chbDeveCalcularAtraso.Name = "chbDeveCalcularAtraso";
            this.chbDeveCalcularAtraso.Size = new System.Drawing.Size(96, 17);
            this.chbDeveCalcularAtraso.TabIndex = 4;
            this.chbDeveCalcularAtraso.Text = "Calcular atraso";
            this.chbDeveCalcularAtraso.UseVisualStyleBackColor = true;
            // 
            // chbDeveCalcularSaidaAdiantada
            // 
            this.chbDeveCalcularSaidaAdiantada.AutoSize = true;
            this.chbDeveCalcularSaidaAdiantada.Location = new System.Drawing.Point(21, 227);
            this.chbDeveCalcularSaidaAdiantada.Name = "chbDeveCalcularSaidaAdiantada";
            this.chbDeveCalcularSaidaAdiantada.Size = new System.Drawing.Size(144, 17);
            this.chbDeveCalcularSaidaAdiantada.TabIndex = 4;
            this.chbDeveCalcularSaidaAdiantada.Text = "Calcular saída adiantada";
            this.chbDeveCalcularSaidaAdiantada.UseVisualStyleBackColor = true;
            // 
            // chbDeveBaterPonto
            // 
            this.chbDeveBaterPonto.AutoSize = true;
            this.chbDeveBaterPonto.Location = new System.Drawing.Point(21, 195);
            this.chbDeveBaterPonto.Name = "chbDeveBaterPonto";
            this.chbDeveBaterPonto.Size = new System.Drawing.Size(118, 17);
            this.chbDeveBaterPonto.TabIndex = 4;
            this.chbDeveBaterPonto.Text = "Deve bater o ponto";
            this.chbDeveBaterPonto.UseVisualStyleBackColor = true;
            // 
            // chbDeveMarcarPonto
            // 
            this.chbDeveMarcarPonto.AutoSize = true;
            this.chbDeveMarcarPonto.Location = new System.Drawing.Point(21, 163);
            this.chbDeveMarcarPonto.Name = "chbDeveMarcarPonto";
            this.chbDeveMarcarPonto.Size = new System.Drawing.Size(126, 17);
            this.chbDeveMarcarPonto.TabIndex = 4;
            this.chbDeveMarcarPonto.Text = "Deve marcar o ponto";
            this.chbDeveMarcarPonto.UseVisualStyleBackColor = true;
            // 
            // nrForaDeServicoM
            // 
            this.nrForaDeServicoM.Location = new System.Drawing.Point(244, 127);
            this.nrForaDeServicoM.Name = "nrForaDeServicoM";
            this.nrForaDeServicoM.Size = new System.Drawing.Size(45, 20);
            this.nrForaDeServicoM.TabIndex = 3;
            // 
            // nrTempoDeServicoM
            // 
            this.nrTempoDeServicoM.Location = new System.Drawing.Point(244, 93);
            this.nrTempoDeServicoM.Name = "nrTempoDeServicoM";
            this.nrTempoDeServicoM.Size = new System.Drawing.Size(45, 20);
            this.nrTempoDeServicoM.TabIndex = 3;
            // 
            // nrForaDeServicoH
            // 
            this.nrForaDeServicoH.Location = new System.Drawing.Point(157, 127);
            this.nrForaDeServicoH.Name = "nrForaDeServicoH";
            this.nrForaDeServicoH.Size = new System.Drawing.Size(45, 20);
            this.nrForaDeServicoH.TabIndex = 3;
            // 
            // nrTempoServicoH
            // 
            this.nrTempoServicoH.Location = new System.Drawing.Point(157, 93);
            this.nrTempoServicoH.Name = "nrTempoServicoH";
            this.nrTempoServicoH.Size = new System.Drawing.Size(45, 20);
            this.nrTempoServicoH.TabIndex = 3;
            // 
            // cbServico
            // 
            this.cbServico.FormattingEnabled = true;
            this.cbServico.Location = new System.Drawing.Point(157, 63);
            this.cbServico.Name = "cbServico";
            this.cbServico.Size = new System.Drawing.Size(160, 21);
            this.cbServico.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(295, 129);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "min.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Fora do tempo de serviço:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(206, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "horas";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(295, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "min.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(206, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "horas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Em tempo de serviço:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tempo de serviço:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.cbTurno);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(431, 385);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Turno";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.btnCancelarTurno);
            this.panel3.Controls.Add(this.btnConfirmarTurno);
            this.panel3.Controls.Add(this.btnRemoverTurno);
            this.panel3.Controls.Add(this.btnEditarTurno);
            this.panel3.Controls.Add(this.btnAdicionarTurno);
            this.panel3.Location = new System.Drawing.Point(20, 7);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(188, 37);
            this.panel3.TabIndex = 6;
            // 
            // btnCancelarTurno
            // 
            this.btnCancelarTurno.BackColor = System.Drawing.Color.White;
            this.btnCancelarTurno.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelarTurno.BackgroundImage")));
            this.btnCancelarTurno.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelarTurno.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelarTurno.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCancelarTurno.Location = new System.Drawing.Point(150, 1);
            this.btnCancelarTurno.Name = "btnCancelarTurno";
            this.btnCancelarTurno.Size = new System.Drawing.Size(30, 30);
            this.btnCancelarTurno.TabIndex = 2;
            this.btnCancelarTurno.UseVisualStyleBackColor = false;
            this.btnCancelarTurno.MouseEnter += new System.EventHandler(this.btnCancelar_MouseEnter);
            this.btnCancelarTurno.MouseLeave += new System.EventHandler(this.btnCancelar_MouseLeave);
            // 
            // btnConfirmarTurno
            // 
            this.btnConfirmarTurno.BackColor = System.Drawing.Color.Transparent;
            this.btnConfirmarTurno.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConfirmarTurno.BackgroundImage")));
            this.btnConfirmarTurno.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnConfirmarTurno.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConfirmarTurno.ForeColor = System.Drawing.Color.White;
            this.btnConfirmarTurno.Location = new System.Drawing.Point(114, 1);
            this.btnConfirmarTurno.Name = "btnConfirmarTurno";
            this.btnConfirmarTurno.Size = new System.Drawing.Size(30, 30);
            this.btnConfirmarTurno.TabIndex = 2;
            this.btnConfirmarTurno.UseVisualStyleBackColor = false;
            this.btnConfirmarTurno.MouseEnter += new System.EventHandler(this.btnConfirmar_MouseEnter);
            this.btnConfirmarTurno.MouseLeave += new System.EventHandler(this.btnConfirmar_MouseLeave);
            // 
            // btnRemoverTurno
            // 
            this.btnRemoverTurno.BackColor = System.Drawing.Color.Transparent;
            this.btnRemoverTurno.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRemoverTurno.BackgroundImage")));
            this.btnRemoverTurno.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRemoverTurno.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemoverTurno.ForeColor = System.Drawing.Color.White;
            this.btnRemoverTurno.Location = new System.Drawing.Point(76, 1);
            this.btnRemoverTurno.Name = "btnRemoverTurno";
            this.btnRemoverTurno.Size = new System.Drawing.Size(30, 30);
            this.btnRemoverTurno.TabIndex = 2;
            this.btnRemoverTurno.UseVisualStyleBackColor = false;
            this.btnRemoverTurno.MouseEnter += new System.EventHandler(this.btnRemover_MouseEnter);
            this.btnRemoverTurno.MouseLeave += new System.EventHandler(this.btnRemover_MouseLeave);
            // 
            // btnEditarTurno
            // 
            this.btnEditarTurno.BackColor = System.Drawing.Color.Transparent;
            this.btnEditarTurno.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditarTurno.BackgroundImage")));
            this.btnEditarTurno.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditarTurno.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditarTurno.ForeColor = System.Drawing.Color.White;
            this.btnEditarTurno.Location = new System.Drawing.Point(39, 1);
            this.btnEditarTurno.Name = "btnEditarTurno";
            this.btnEditarTurno.Size = new System.Drawing.Size(30, 30);
            this.btnEditarTurno.TabIndex = 2;
            this.btnEditarTurno.UseVisualStyleBackColor = false;
            this.btnEditarTurno.MouseEnter += new System.EventHandler(this.btnEditar_MouseEnter);
            this.btnEditarTurno.MouseLeave += new System.EventHandler(this.btnEditar_MouseLeave);
            // 
            // btnAdicionarTurno
            // 
            this.btnAdicionarTurno.BackColor = System.Drawing.Color.Transparent;
            this.btnAdicionarTurno.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAdicionarTurno.BackgroundImage")));
            this.btnAdicionarTurno.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAdicionarTurno.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdicionarTurno.ForeColor = System.Drawing.Color.White;
            this.btnAdicionarTurno.Location = new System.Drawing.Point(4, 1);
            this.btnAdicionarTurno.Name = "btnAdicionarTurno";
            this.btnAdicionarTurno.Size = new System.Drawing.Size(30, 30);
            this.btnAdicionarTurno.TabIndex = 2;
            this.btnAdicionarTurno.UseVisualStyleBackColor = false;
            this.btnAdicionarTurno.MouseEnter += new System.EventHandler(this.btnAdicionar_MouseEnter);
            this.btnAdicionarTurno.MouseLeave += new System.EventHandler(this.btnAdicionar_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chbNormal);
            this.panel1.Controls.Add(this.chbNoite);
            this.panel1.Controls.Add(this.chbTarde);
            this.panel1.Controls.Add(this.chbManha);
            this.panel1.Location = new System.Drawing.Point(21, 95);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(187, 166);
            this.panel1.TabIndex = 4;
            // 
            // chbNormal
            // 
            this.chbNormal.AutoSize = true;
            this.chbNormal.Location = new System.Drawing.Point(14, 81);
            this.chbNormal.Name = "chbNormal";
            this.chbNormal.Size = new System.Drawing.Size(131, 17);
            this.chbNormal.TabIndex = 0;
            this.chbNormal.Text = "Normal (08:30 - 17:30)";
            this.chbNormal.UseVisualStyleBackColor = true;
            // 
            // chbNoite
            // 
            this.chbNoite.AutoSize = true;
            this.chbNoite.Location = new System.Drawing.Point(14, 58);
            this.chbNoite.Name = "chbNoite";
            this.chbNoite.Size = new System.Drawing.Size(123, 17);
            this.chbNoite.TabIndex = 0;
            this.chbNoite.Text = "Noite (19:00 - 23:00)";
            this.chbNoite.UseVisualStyleBackColor = true;
            // 
            // chbTarde
            // 
            this.chbTarde.AutoSize = true;
            this.chbTarde.Location = new System.Drawing.Point(14, 35);
            this.chbTarde.Name = "chbTarde";
            this.chbTarde.Size = new System.Drawing.Size(126, 17);
            this.chbTarde.TabIndex = 0;
            this.chbTarde.Text = "Tarde (13:00 - 17:30)";
            this.chbTarde.UseVisualStyleBackColor = true;
            // 
            // chbManha
            // 
            this.chbManha.AutoSize = true;
            this.chbManha.Location = new System.Drawing.Point(14, 12);
            this.chbManha.Name = "chbManha";
            this.chbManha.Size = new System.Drawing.Size(131, 17);
            this.chbManha.TabIndex = 0;
            this.chbManha.Text = "Manhã (08:30 - 12:00)";
            this.chbManha.UseVisualStyleBackColor = true;
            // 
            // cbTurno
            // 
            this.cbTurno.FormattingEnabled = true;
            this.cbTurno.Location = new System.Drawing.Point(62, 57);
            this.cbTurno.Name = "cbTurno";
            this.cbTurno.Size = new System.Drawing.Size(146, 21);
            this.cbTurno.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Turno:";
            // 
            // lblCancelar
            // 
            this.lblCancelar.AutoSize = true;
            this.lblCancelar.BackColor = System.Drawing.Color.AliceBlue;
            this.lblCancelar.Location = new System.Drawing.Point(173, 52);
            this.lblCancelar.Name = "lblCancelar";
            this.lblCancelar.Size = new System.Drawing.Size(49, 13);
            this.lblCancelar.TabIndex = 47;
            this.lblCancelar.Text = "Cancelar";
            this.lblCancelar.Visible = false;
            // 
            // lblConfirmar
            // 
            this.lblConfirmar.AutoSize = true;
            this.lblConfirmar.BackColor = System.Drawing.Color.AliceBlue;
            this.lblConfirmar.Location = new System.Drawing.Point(135, 52);
            this.lblConfirmar.Name = "lblConfirmar";
            this.lblConfirmar.Size = new System.Drawing.Size(51, 13);
            this.lblConfirmar.TabIndex = 48;
            this.lblConfirmar.Text = "Confirmar";
            this.lblConfirmar.Visible = false;
            // 
            // lblRemover
            // 
            this.lblRemover.AutoSize = true;
            this.lblRemover.BackColor = System.Drawing.Color.AliceBlue;
            this.lblRemover.Location = new System.Drawing.Point(96, 52);
            this.lblRemover.Name = "lblRemover";
            this.lblRemover.Size = new System.Drawing.Size(50, 13);
            this.lblRemover.TabIndex = 49;
            this.lblRemover.Text = "Remover";
            this.lblRemover.Visible = false;
            // 
            // lblEditar
            // 
            this.lblEditar.AutoSize = true;
            this.lblEditar.BackColor = System.Drawing.Color.AliceBlue;
            this.lblEditar.Location = new System.Drawing.Point(59, 52);
            this.lblEditar.Name = "lblEditar";
            this.lblEditar.Size = new System.Drawing.Size(34, 13);
            this.lblEditar.TabIndex = 50;
            this.lblEditar.Text = "Editar";
            this.lblEditar.Visible = false;
            // 
            // lblAdicionar
            // 
            this.lblAdicionar.AutoSize = true;
            this.lblAdicionar.BackColor = System.Drawing.Color.AliceBlue;
            this.lblAdicionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdicionar.Location = new System.Drawing.Point(16, 52);
            this.lblAdicionar.Name = "lblAdicionar";
            this.lblAdicionar.Size = new System.Drawing.Size(51, 13);
            this.lblAdicionar.TabIndex = 51;
            this.lblAdicionar.Text = "Adicionar";
            this.lblAdicionar.Visible = false;
            // 
            // frmTempoDeServico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(670, 537);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnAnterior);
            this.Controls.Add(this.btnSeguinte);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label1);
            this.Name = "frmTempoDeServico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuração do Horário";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nrForaDeServicoM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrTempoDeServicoM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrForaDeServicoH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrTempoServicoH)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnSeguinte;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbServico;
        private System.Windows.Forms.Button btnCancelarHora;
        private System.Windows.Forms.Button btnConfirmarHora;
        private System.Windows.Forms.Button btnRemoverHora;
        private System.Windows.Forms.Button btnEditarHora;
        private System.Windows.Forms.Button btnAdicionarHora;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nrTempoDeServicoM;
        private System.Windows.Forms.NumericUpDown nrTempoServicoH;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nrForaDeServicoM;
        private System.Windows.Forms.NumericUpDown nrForaDeServicoH;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chbDeveMarcarPonto;
        private System.Windows.Forms.CheckBox chbDeveBaterPonto;
        private System.Windows.Forms.CheckBox chbDeveCalcularSaidaAdiantada;
        private System.Windows.Forms.CheckBox chbDeveCalcularAusencia;
        private System.Windows.Forms.CheckBox chbDeveCalcularAtraso;
        private System.Windows.Forms.ComboBox cbTurno;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chbTarde;
        private System.Windows.Forms.CheckBox chbManha;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnCancelarTurno;
        private System.Windows.Forms.Button btnConfirmarTurno;
        private System.Windows.Forms.Button btnRemoverTurno;
        private System.Windows.Forms.Button btnEditarTurno;
        private System.Windows.Forms.Button btnAdicionarTurno;
        private System.Windows.Forms.CheckBox chbNormal;
        private System.Windows.Forms.CheckBox chbNoite;
        private System.Windows.Forms.Label lblCancelar;
        private System.Windows.Forms.Label lblConfirmar;
        private System.Windows.Forms.Label lblRemover;
        private System.Windows.Forms.Label lblEditar;
        private System.Windows.Forms.Label lblAdicionar;
    }
}