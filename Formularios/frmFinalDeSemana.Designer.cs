namespace Facturix_Salários.Formularios
{
    partial class frmFinalDeSemana
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFinalDeSemana));
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnSeguinte = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFinalDeSemana = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chbSabado = new System.Windows.Forms.CheckBox();
            this.chbDomingo = new System.Windows.Forms.CheckBox();
            this.chbSexta = new System.Windows.Forms.CheckBox();
            this.chbQuinta = new System.Windows.Forms.CheckBox();
            this.chbQuarta = new System.Windows.Forms.CheckBox();
            this.chbTerca = new System.Windows.Forms.CheckBox();
            this.chbDomingoT = new System.Windows.Forms.CheckBox();
            this.chbSabadoT = new System.Windows.Forms.CheckBox();
            this.chbSextaT = new System.Windows.Forms.CheckBox();
            this.chbQuintaT = new System.Windows.Forms.CheckBox();
            this.chbQuartaT = new System.Windows.Forms.CheckBox();
            this.chbTercaT = new System.Windows.Forms.CheckBox();
            this.chbSegundaT = new System.Windows.Forms.CheckBox();
            this.chbDomingoM = new System.Windows.Forms.CheckBox();
            this.chbSabadoM = new System.Windows.Forms.CheckBox();
            this.chbSextaM = new System.Windows.Forms.CheckBox();
            this.chbQuintaM = new System.Windows.Forms.CheckBox();
            this.chbQuartaM = new System.Windows.Forms.CheckBox();
            this.chbTercaM = new System.Windows.Forms.CheckBox();
            this.chbSegundaM = new System.Windows.Forms.CheckBox();
            this.chbSegunda = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.lblCancelar = new System.Windows.Forms.Label();
            this.lblConfirmar = new System.Windows.Forms.Label();
            this.lblRemover = new System.Windows.Forms.Label();
            this.lblEditar = new System.Windows.Forms.Label();
            this.lblAdicionar = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAnterior
            // 
            this.btnAnterior.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnterior.Location = new System.Drawing.Point(472, 492);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(75, 23);
            this.btnAnterior.TabIndex = 16;
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
            this.btnSeguinte.TabIndex = 17;
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
            this.textBox3.TabIndex = 15;
            this.textBox3.Text = "Por favor, informe o final de semana da empresa. Diferentes trabalhadores podem t" +
    "er finais de semana diferentes.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Passo à passo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Final de Semana:";
            // 
            // cbFinalDeSemana
            // 
            this.cbFinalDeSemana.FormattingEnabled = true;
            this.cbFinalDeSemana.Location = new System.Drawing.Point(313, 71);
            this.cbFinalDeSemana.Name = "cbFinalDeSemana";
            this.cbFinalDeSemana.Size = new System.Drawing.Size(264, 21);
            this.cbFinalDeSemana.TabIndex = 18;
            this.cbFinalDeSemana.SelectedIndexChanged += new System.EventHandler(this.cbFinalDeSemana_SelectedIndexChanged);
            this.cbFinalDeSemana.TextChanged += new System.EventHandler(this.cbFinalDeSemana_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chbSabado);
            this.panel1.Controls.Add(this.chbDomingo);
            this.panel1.Controls.Add(this.chbSexta);
            this.panel1.Controls.Add(this.chbQuinta);
            this.panel1.Controls.Add(this.chbQuarta);
            this.panel1.Controls.Add(this.chbTerca);
            this.panel1.Controls.Add(this.chbDomingoT);
            this.panel1.Controls.Add(this.chbSabadoT);
            this.panel1.Controls.Add(this.chbSextaT);
            this.panel1.Controls.Add(this.chbQuintaT);
            this.panel1.Controls.Add(this.chbQuartaT);
            this.panel1.Controls.Add(this.chbTercaT);
            this.panel1.Controls.Add(this.chbSegundaT);
            this.panel1.Controls.Add(this.chbDomingoM);
            this.panel1.Controls.Add(this.chbSabadoM);
            this.panel1.Controls.Add(this.chbSextaM);
            this.panel1.Controls.Add(this.chbQuintaM);
            this.panel1.Controls.Add(this.chbQuartaM);
            this.panel1.Controls.Add(this.chbTercaM);
            this.panel1.Controls.Add(this.chbSegundaM);
            this.panel1.Controls.Add(this.chbSegunda);
            this.panel1.Location = new System.Drawing.Point(313, 119);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(264, 193);
            this.panel1.TabIndex = 19;
            // 
            // chbSabado
            // 
            this.chbSabado.AutoSize = true;
            this.chbSabado.Enabled = false;
            this.chbSabado.Location = new System.Drawing.Point(18, 132);
            this.chbSabado.Name = "chbSabado";
            this.chbSabado.Size = new System.Drawing.Size(63, 17);
            this.chbSabado.TabIndex = 0;
            this.chbSabado.Text = "Sábado";
            this.chbSabado.UseVisualStyleBackColor = true;
            // 
            // chbDomingo
            // 
            this.chbDomingo.AutoSize = true;
            this.chbDomingo.Enabled = false;
            this.chbDomingo.Location = new System.Drawing.Point(18, 155);
            this.chbDomingo.Name = "chbDomingo";
            this.chbDomingo.Size = new System.Drawing.Size(68, 17);
            this.chbDomingo.TabIndex = 0;
            this.chbDomingo.Text = "Domingo";
            this.chbDomingo.UseVisualStyleBackColor = true;
            // 
            // chbSexta
            // 
            this.chbSexta.AutoSize = true;
            this.chbSexta.Enabled = false;
            this.chbSexta.Location = new System.Drawing.Point(18, 109);
            this.chbSexta.Name = "chbSexta";
            this.chbSexta.Size = new System.Drawing.Size(79, 17);
            this.chbSexta.TabIndex = 0;
            this.chbSexta.Text = "Sexta-Feira";
            this.chbSexta.UseVisualStyleBackColor = true;
            // 
            // chbQuinta
            // 
            this.chbQuinta.AutoSize = true;
            this.chbQuinta.Enabled = false;
            this.chbQuinta.Location = new System.Drawing.Point(18, 86);
            this.chbQuinta.Name = "chbQuinta";
            this.chbQuinta.Size = new System.Drawing.Size(83, 17);
            this.chbQuinta.TabIndex = 0;
            this.chbQuinta.Text = "Quinta-Feira";
            this.chbQuinta.UseVisualStyleBackColor = true;
            // 
            // chbQuarta
            // 
            this.chbQuarta.AutoSize = true;
            this.chbQuarta.Enabled = false;
            this.chbQuarta.Location = new System.Drawing.Point(18, 63);
            this.chbQuarta.Name = "chbQuarta";
            this.chbQuarta.Size = new System.Drawing.Size(84, 17);
            this.chbQuarta.TabIndex = 0;
            this.chbQuarta.Text = "Quarta-Feira";
            this.chbQuarta.UseVisualStyleBackColor = true;
            // 
            // chbTerca
            // 
            this.chbTerca.AutoSize = true;
            this.chbTerca.Enabled = false;
            this.chbTerca.Location = new System.Drawing.Point(18, 40);
            this.chbTerca.Name = "chbTerca";
            this.chbTerca.Size = new System.Drawing.Size(80, 17);
            this.chbTerca.TabIndex = 0;
            this.chbTerca.Text = "Terça-Feira";
            this.chbTerca.UseVisualStyleBackColor = true;
            // 
            // chbDomingoT
            // 
            this.chbDomingoT.AutoSize = true;
            this.chbDomingoT.Enabled = false;
            this.chbDomingoT.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chbDomingoT.Location = new System.Drawing.Point(194, 155);
            this.chbDomingoT.Name = "chbDomingoT";
            this.chbDomingoT.Size = new System.Drawing.Size(54, 17);
            this.chbDomingoT.TabIndex = 0;
            this.chbDomingoT.Text = "Tarde";
            this.chbDomingoT.UseVisualStyleBackColor = true;
            this.chbDomingoT.CheckedChanged += new System.EventHandler(this.chbDomingoT_CheckedChanged);
            // 
            // chbSabadoT
            // 
            this.chbSabadoT.AutoSize = true;
            this.chbSabadoT.Enabled = false;
            this.chbSabadoT.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chbSabadoT.Location = new System.Drawing.Point(194, 132);
            this.chbSabadoT.Name = "chbSabadoT";
            this.chbSabadoT.Size = new System.Drawing.Size(54, 17);
            this.chbSabadoT.TabIndex = 0;
            this.chbSabadoT.Text = "Tarde";
            this.chbSabadoT.UseVisualStyleBackColor = true;
            this.chbSabadoT.CheckedChanged += new System.EventHandler(this.chbSabadoT_CheckedChanged);
            // 
            // chbSextaT
            // 
            this.chbSextaT.AutoSize = true;
            this.chbSextaT.Enabled = false;
            this.chbSextaT.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chbSextaT.Location = new System.Drawing.Point(194, 109);
            this.chbSextaT.Name = "chbSextaT";
            this.chbSextaT.Size = new System.Drawing.Size(54, 17);
            this.chbSextaT.TabIndex = 0;
            this.chbSextaT.Text = "Tarde";
            this.chbSextaT.UseVisualStyleBackColor = true;
            this.chbSextaT.CheckedChanged += new System.EventHandler(this.chbSextaT_CheckedChanged);
            // 
            // chbQuintaT
            // 
            this.chbQuintaT.AutoSize = true;
            this.chbQuintaT.Enabled = false;
            this.chbQuintaT.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chbQuintaT.Location = new System.Drawing.Point(194, 86);
            this.chbQuintaT.Name = "chbQuintaT";
            this.chbQuintaT.Size = new System.Drawing.Size(54, 17);
            this.chbQuintaT.TabIndex = 0;
            this.chbQuintaT.Text = "Tarde";
            this.chbQuintaT.UseVisualStyleBackColor = true;
            this.chbQuintaT.CheckedChanged += new System.EventHandler(this.chbQuintaT_CheckedChanged);
            // 
            // chbQuartaT
            // 
            this.chbQuartaT.AutoSize = true;
            this.chbQuartaT.Enabled = false;
            this.chbQuartaT.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chbQuartaT.Location = new System.Drawing.Point(194, 63);
            this.chbQuartaT.Name = "chbQuartaT";
            this.chbQuartaT.Size = new System.Drawing.Size(54, 17);
            this.chbQuartaT.TabIndex = 0;
            this.chbQuartaT.Text = "Tarde";
            this.chbQuartaT.UseVisualStyleBackColor = true;
            this.chbQuartaT.CheckedChanged += new System.EventHandler(this.chbQuartaT_CheckedChanged);
            // 
            // chbTercaT
            // 
            this.chbTercaT.AutoSize = true;
            this.chbTercaT.Enabled = false;
            this.chbTercaT.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chbTercaT.Location = new System.Drawing.Point(194, 41);
            this.chbTercaT.Name = "chbTercaT";
            this.chbTercaT.Size = new System.Drawing.Size(54, 17);
            this.chbTercaT.TabIndex = 0;
            this.chbTercaT.Text = "Tarde";
            this.chbTercaT.UseVisualStyleBackColor = true;
            this.chbTercaT.CheckedChanged += new System.EventHandler(this.chbTercaT_CheckedChanged);
            // 
            // chbSegundaT
            // 
            this.chbSegundaT.AutoSize = true;
            this.chbSegundaT.Enabled = false;
            this.chbSegundaT.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chbSegundaT.Location = new System.Drawing.Point(194, 18);
            this.chbSegundaT.Name = "chbSegundaT";
            this.chbSegundaT.Size = new System.Drawing.Size(54, 17);
            this.chbSegundaT.TabIndex = 0;
            this.chbSegundaT.Text = "Tarde";
            this.chbSegundaT.UseVisualStyleBackColor = true;
            this.chbSegundaT.CheckedChanged += new System.EventHandler(this.chbSegundaT_CheckedChanged);
            // 
            // chbDomingoM
            // 
            this.chbDomingoM.AutoSize = true;
            this.chbDomingoM.Enabled = false;
            this.chbDomingoM.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chbDomingoM.Location = new System.Drawing.Point(129, 155);
            this.chbDomingoM.Name = "chbDomingoM";
            this.chbDomingoM.Size = new System.Drawing.Size(59, 17);
            this.chbDomingoM.TabIndex = 0;
            this.chbDomingoM.Text = "Manhã";
            this.chbDomingoM.UseVisualStyleBackColor = true;
            this.chbDomingoM.CheckedChanged += new System.EventHandler(this.chbDomingoM_CheckedChanged);
            // 
            // chbSabadoM
            // 
            this.chbSabadoM.AutoSize = true;
            this.chbSabadoM.Enabled = false;
            this.chbSabadoM.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chbSabadoM.Location = new System.Drawing.Point(129, 132);
            this.chbSabadoM.Name = "chbSabadoM";
            this.chbSabadoM.Size = new System.Drawing.Size(59, 17);
            this.chbSabadoM.TabIndex = 0;
            this.chbSabadoM.Text = "Manhã";
            this.chbSabadoM.UseVisualStyleBackColor = true;
            this.chbSabadoM.CheckedChanged += new System.EventHandler(this.chbSabadoM_CheckedChanged);
            // 
            // chbSextaM
            // 
            this.chbSextaM.AutoSize = true;
            this.chbSextaM.Enabled = false;
            this.chbSextaM.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chbSextaM.Location = new System.Drawing.Point(129, 109);
            this.chbSextaM.Name = "chbSextaM";
            this.chbSextaM.Size = new System.Drawing.Size(59, 17);
            this.chbSextaM.TabIndex = 0;
            this.chbSextaM.Text = "Manhã";
            this.chbSextaM.UseVisualStyleBackColor = true;
            this.chbSextaM.CheckedChanged += new System.EventHandler(this.chbSextaM_CheckedChanged);
            // 
            // chbQuintaM
            // 
            this.chbQuintaM.AutoSize = true;
            this.chbQuintaM.Enabled = false;
            this.chbQuintaM.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chbQuintaM.Location = new System.Drawing.Point(129, 86);
            this.chbQuintaM.Name = "chbQuintaM";
            this.chbQuintaM.Size = new System.Drawing.Size(59, 17);
            this.chbQuintaM.TabIndex = 0;
            this.chbQuintaM.Text = "Manhã";
            this.chbQuintaM.UseVisualStyleBackColor = true;
            this.chbQuintaM.CheckedChanged += new System.EventHandler(this.chbQuintaM_CheckedChanged);
            // 
            // chbQuartaM
            // 
            this.chbQuartaM.AutoSize = true;
            this.chbQuartaM.Enabled = false;
            this.chbQuartaM.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chbQuartaM.Location = new System.Drawing.Point(129, 63);
            this.chbQuartaM.Name = "chbQuartaM";
            this.chbQuartaM.Size = new System.Drawing.Size(59, 17);
            this.chbQuartaM.TabIndex = 0;
            this.chbQuartaM.Text = "Manhã";
            this.chbQuartaM.UseVisualStyleBackColor = true;
            this.chbQuartaM.CheckedChanged += new System.EventHandler(this.chbQuartaM_CheckedChanged);
            // 
            // chbTercaM
            // 
            this.chbTercaM.AutoSize = true;
            this.chbTercaM.Enabled = false;
            this.chbTercaM.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chbTercaM.Location = new System.Drawing.Point(129, 41);
            this.chbTercaM.Name = "chbTercaM";
            this.chbTercaM.Size = new System.Drawing.Size(59, 17);
            this.chbTercaM.TabIndex = 0;
            this.chbTercaM.Text = "Manhã";
            this.chbTercaM.UseVisualStyleBackColor = true;
            this.chbTercaM.CheckedChanged += new System.EventHandler(this.chbTercaM_CheckedChanged);
            // 
            // chbSegundaM
            // 
            this.chbSegundaM.AutoSize = true;
            this.chbSegundaM.Enabled = false;
            this.chbSegundaM.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chbSegundaM.Location = new System.Drawing.Point(129, 18);
            this.chbSegundaM.Name = "chbSegundaM";
            this.chbSegundaM.Size = new System.Drawing.Size(59, 17);
            this.chbSegundaM.TabIndex = 0;
            this.chbSegundaM.Text = "Manhã";
            this.chbSegundaM.UseVisualStyleBackColor = true;
            this.chbSegundaM.CheckedChanged += new System.EventHandler(this.chbSegundaM_CheckedChanged);
            this.chbSegundaM.CheckStateChanged += new System.EventHandler(this.chbSegundaM_CheckStateChanged);
            // 
            // chbSegunda
            // 
            this.chbSegunda.AutoSize = true;
            this.chbSegunda.Enabled = false;
            this.chbSegunda.Location = new System.Drawing.Point(18, 18);
            this.chbSegunda.Name = "chbSegunda";
            this.chbSegunda.Size = new System.Drawing.Size(95, 17);
            this.chbSegunda.TabIndex = 0;
            this.chbSegunda.Text = "Segunda-Feira";
            this.chbSegunda.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(218, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Tempo:";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnCancelar);
            this.panel2.Controls.Add(this.btnConfirmar);
            this.panel2.Controls.Add(this.btnRemover);
            this.panel2.Controls.Add(this.btnEditar);
            this.panel2.Controls.Add(this.btnAdicionar);
            this.panel2.Location = new System.Drawing.Point(249, 11);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(188, 37);
            this.panel2.TabIndex = 20;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelar.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.btnCancelar.Location = new System.Drawing.Point(151, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(30, 30);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            this.btnCancelar.MouseEnter += new System.EventHandler(this.btnCancelar_MouseEnter);
            this.btnCancelar.MouseLeave += new System.EventHandler(this.btnCancelar_MouseLeave);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnConfirmar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConfirmar.BackgroundImage")));
            this.btnConfirmar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConfirmar.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.btnConfirmar.Location = new System.Drawing.Point(114, 2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(30, 30);
            this.btnConfirmar.TabIndex = 2;
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            this.btnConfirmar.MouseEnter += new System.EventHandler(this.btnConfirmar_MouseEnter);
            this.btnConfirmar.MouseLeave += new System.EventHandler(this.btnConfirmar_MouseLeave);
            // 
            // btnRemover
            // 
            this.btnRemover.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnRemover.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRemover.BackgroundImage")));
            this.btnRemover.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRemover.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemover.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.btnRemover.Location = new System.Drawing.Point(77, 2);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(30, 30);
            this.btnRemover.TabIndex = 2;
            this.btnRemover.UseVisualStyleBackColor = false;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            this.btnRemover.MouseEnter += new System.EventHandler(this.btnRemover_MouseEnter);
            this.btnRemover.MouseLeave += new System.EventHandler(this.btnRemover_MouseLeave);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditar.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.btnEditar.Location = new System.Drawing.Point(40, 2);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(30, 30);
            this.btnEditar.TabIndex = 2;
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            this.btnEditar.MouseEnter += new System.EventHandler(this.btnEditar_MouseEnter);
            this.btnEditar.MouseLeave += new System.EventHandler(this.btnEditar_MouseLeave);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnAdicionar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAdicionar.BackgroundImage")));
            this.btnAdicionar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAdicionar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdicionar.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.btnAdicionar.Location = new System.Drawing.Point(3, 2);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(30, 30);
            this.btnAdicionar.TabIndex = 2;
            this.btnAdicionar.UseVisualStyleBackColor = false;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            this.btnAdicionar.MouseEnter += new System.EventHandler(this.btnAdicionar_MouseEnter);
            this.btnAdicionar.MouseLeave += new System.EventHandler(this.btnAdicionar_MouseLeave);
            // 
            // lblCancelar
            // 
            this.lblCancelar.AutoSize = true;
            this.lblCancelar.BackColor = System.Drawing.Color.AliceBlue;
            this.lblCancelar.Location = new System.Drawing.Point(403, 56);
            this.lblCancelar.Name = "lblCancelar";
            this.lblCancelar.Size = new System.Drawing.Size(49, 13);
            this.lblCancelar.TabIndex = 27;
            this.lblCancelar.Text = "Cancelar";
            this.lblCancelar.Visible = false;
            // 
            // lblConfirmar
            // 
            this.lblConfirmar.AutoSize = true;
            this.lblConfirmar.BackColor = System.Drawing.Color.AliceBlue;
            this.lblConfirmar.Location = new System.Drawing.Point(365, 56);
            this.lblConfirmar.Name = "lblConfirmar";
            this.lblConfirmar.Size = new System.Drawing.Size(51, 13);
            this.lblConfirmar.TabIndex = 28;
            this.lblConfirmar.Text = "Confirmar";
            this.lblConfirmar.Visible = false;
            // 
            // lblRemover
            // 
            this.lblRemover.AutoSize = true;
            this.lblRemover.BackColor = System.Drawing.Color.AliceBlue;
            this.lblRemover.Location = new System.Drawing.Point(326, 56);
            this.lblRemover.Name = "lblRemover";
            this.lblRemover.Size = new System.Drawing.Size(50, 13);
            this.lblRemover.TabIndex = 29;
            this.lblRemover.Text = "Remover";
            this.lblRemover.Visible = false;
            // 
            // lblEditar
            // 
            this.lblEditar.AutoSize = true;
            this.lblEditar.BackColor = System.Drawing.Color.AliceBlue;
            this.lblEditar.Location = new System.Drawing.Point(289, 56);
            this.lblEditar.Name = "lblEditar";
            this.lblEditar.Size = new System.Drawing.Size(34, 13);
            this.lblEditar.TabIndex = 30;
            this.lblEditar.Text = "Editar";
            this.lblEditar.Visible = false;
            // 
            // lblAdicionar
            // 
            this.lblAdicionar.AutoSize = true;
            this.lblAdicionar.BackColor = System.Drawing.Color.AliceBlue;
            this.lblAdicionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdicionar.Location = new System.Drawing.Point(246, 56);
            this.lblAdicionar.Name = "lblAdicionar";
            this.lblAdicionar.Size = new System.Drawing.Size(51, 13);
            this.lblAdicionar.TabIndex = 31;
            this.lblAdicionar.Text = "Adicionar";
            this.lblAdicionar.Visible = false;
            // 
            // frmFinalDeSemana
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(670, 537);
            this.Controls.Add(this.lblCancelar);
            this.Controls.Add(this.lblConfirmar);
            this.Controls.Add(this.lblRemover);
            this.Controls.Add(this.lblEditar);
            this.Controls.Add(this.lblAdicionar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cbFinalDeSemana);
            this.Controls.Add(this.btnAnterior);
            this.Controls.Add(this.btnSeguinte);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmFinalDeSemana";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Final de Semana";
            this.Load += new System.EventHandler(this.frmFinalDeSemana_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnSeguinte;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFinalDeSemana;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chbSabado;
        private System.Windows.Forms.CheckBox chbDomingo;
        private System.Windows.Forms.CheckBox chbSexta;
        private System.Windows.Forms.CheckBox chbQuinta;
        private System.Windows.Forms.CheckBox chbQuarta;
        private System.Windows.Forms.CheckBox chbTerca;
        private System.Windows.Forms.CheckBox chbSegunda;
        private System.Windows.Forms.CheckBox chbDomingoT;
        private System.Windows.Forms.CheckBox chbSabadoT;
        private System.Windows.Forms.CheckBox chbSextaT;
        private System.Windows.Forms.CheckBox chbQuintaT;
        private System.Windows.Forms.CheckBox chbQuartaT;
        private System.Windows.Forms.CheckBox chbTercaT;
        private System.Windows.Forms.CheckBox chbSegundaT;
        private System.Windows.Forms.CheckBox chbDomingoM;
        private System.Windows.Forms.CheckBox chbSabadoM;
        private System.Windows.Forms.CheckBox chbSextaM;
        private System.Windows.Forms.CheckBox chbQuintaM;
        private System.Windows.Forms.CheckBox chbQuartaM;
        private System.Windows.Forms.CheckBox chbTercaM;
        private System.Windows.Forms.CheckBox chbSegundaM;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Label lblCancelar;
        private System.Windows.Forms.Label lblConfirmar;
        private System.Windows.Forms.Label lblRemover;
        private System.Windows.Forms.Label lblEditar;
        private System.Windows.Forms.Label lblAdicionar;
    }
}