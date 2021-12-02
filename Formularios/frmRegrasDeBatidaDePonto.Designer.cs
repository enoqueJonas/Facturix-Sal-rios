namespace Facturix_Salários.Formularios
{
    partial class frmRegrasDeBatidaDePonto
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
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnSeguinte = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cbIntervaloMinimo = new System.Windows.Forms.CheckBox();
            this.cbDiaDeTrabalho = new System.Windows.Forms.CheckBox();
            this.nrIntervaloMinimoBatida = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nrHorasTrabalho = new System.Windows.Forms.NumericUpDown();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cbSaida = new System.Windows.Forms.ComboBox();
            this.chbSaida = new System.Windows.Forms.CheckBox();
            this.cbEntrada = new System.Windows.Forms.ComboBox();
            this.chbEntrada = new System.Windows.Forms.CheckBox();
            this.chbSaidaAdiantada = new System.Windows.Forms.CheckBox();
            this.chbFalta = new System.Windows.Forms.CheckBox();
            this.cbAtraso = new System.Windows.Forms.CheckBox();
            this.nrSaidaAdiantada = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.nrFalta = new System.Windows.Forms.NumericUpDown();
            this.nrEntradaAtraso = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.nrAlmoco = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.chbHorasExtraordianarias = new System.Windows.Forms.CheckBox();
            this.chbAlmoco = new System.Windows.Forms.CheckBox();
            this.chbHorasExtra = new System.Windows.Forms.CheckBox();
            this.nrHorasExtra = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nrIntervaloMinimoBatida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrHorasTrabalho)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nrSaidaAdiantada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrFalta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrEntradaAtraso)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nrAlmoco)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrHorasExtra)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAnterior
            // 
            this.btnAnterior.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnterior.Location = new System.Drawing.Point(471, 494);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(75, 23);
            this.btnAnterior.TabIndex = 11;
            this.btnAnterior.Text = "Anterior";
            this.btnAnterior.UseVisualStyleBackColor = true;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // btnSeguinte
            // 
            this.btnSeguinte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeguinte.Location = new System.Drawing.Point(578, 494);
            this.btnSeguinte.Name = "btnSeguinte";
            this.btnSeguinte.Size = new System.Drawing.Size(75, 23);
            this.btnSeguinte.TabIndex = 12;
            this.btnSeguinte.Text = "Seguinte";
            this.btnSeguinte.UseVisualStyleBackColor = true;
            this.btnSeguinte.Click += new System.EventHandler(this.btnSeguinte_Click);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Location = new System.Drawing.Point(18, 52);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(169, 81);
            this.textBox3.TabIndex = 7;
            this.textBox3.Text = "Por favor, defina os parâmetros corretos de acordo com o sistema de avaliação de " +
    "desempenho da empresa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Passo à passo:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(224, 31);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(429, 326);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cbIntervaloMinimo);
            this.tabPage1.Controls.Add(this.cbDiaDeTrabalho);
            this.tabPage1.Controls.Add(this.nrIntervaloMinimoBatida);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.nrHorasTrabalho);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(421, 300);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Normal";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cbIntervaloMinimo
            // 
            this.cbIntervaloMinimo.AutoSize = true;
            this.cbIntervaloMinimo.Location = new System.Drawing.Point(25, 55);
            this.cbIntervaloMinimo.Name = "cbIntervaloMinimo";
            this.cbIntervaloMinimo.Size = new System.Drawing.Size(171, 17);
            this.cbIntervaloMinimo.TabIndex = 15;
            this.cbIntervaloMinimo.Text = "Intervalo Minimo entre Batidas:";
            this.cbIntervaloMinimo.UseVisualStyleBackColor = true;
            // 
            // cbDiaDeTrabalho
            // 
            this.cbDiaDeTrabalho.AutoSize = true;
            this.cbDiaDeTrabalho.Location = new System.Drawing.Point(25, 21);
            this.cbDiaDeTrabalho.Name = "cbDiaDeTrabalho";
            this.cbDiaDeTrabalho.Size = new System.Drawing.Size(105, 17);
            this.cbDiaDeTrabalho.TabIndex = 15;
            this.cbDiaDeTrabalho.Text = "Dia de Trabalho:";
            this.cbDiaDeTrabalho.UseVisualStyleBackColor = true;
            // 
            // nrIntervaloMinimoBatida
            // 
            this.nrIntervaloMinimoBatida.Location = new System.Drawing.Point(208, 54);
            this.nrIntervaloMinimoBatida.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nrIntervaloMinimoBatida.Name = "nrIntervaloMinimoBatida";
            this.nrIntervaloMinimoBatida.Size = new System.Drawing.Size(46, 20);
            this.nrIntervaloMinimoBatida.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(268, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "minutos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(268, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "horas";
            // 
            // nrHorasTrabalho
            // 
            this.nrHorasTrabalho.Location = new System.Drawing.Point(208, 20);
            this.nrHorasTrabalho.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nrHorasTrabalho.Name = "nrHorasTrabalho";
            this.nrHorasTrabalho.Size = new System.Drawing.Size(46, 20);
            this.nrHorasTrabalho.TabIndex = 11;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cbSaida);
            this.tabPage2.Controls.Add(this.chbSaida);
            this.tabPage2.Controls.Add(this.cbEntrada);
            this.tabPage2.Controls.Add(this.chbEntrada);
            this.tabPage2.Controls.Add(this.chbSaidaAdiantada);
            this.tabPage2.Controls.Add(this.chbFalta);
            this.tabPage2.Controls.Add(this.cbAtraso);
            this.tabPage2.Controls.Add(this.nrSaidaAdiantada);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.nrFalta);
            this.tabPage2.Controls.Add(this.nrEntradaAtraso);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(421, 300);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Atraso";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cbSaida
            // 
            this.cbSaida.FormattingEnabled = true;
            this.cbSaida.Items.AddRange(new object[] {
            "Falta",
            "Dia Trabalhado"});
            this.cbSaida.Location = new System.Drawing.Point(249, 156);
            this.cbSaida.Name = "cbSaida";
            this.cbSaida.Size = new System.Drawing.Size(103, 21);
            this.cbSaida.TabIndex = 12;
            // 
            // chbSaida
            // 
            this.chbSaida.AutoSize = true;
            this.chbSaida.Location = new System.Drawing.Point(25, 158);
            this.chbSaida.Name = "chbSaida";
            this.chbSaida.Size = new System.Drawing.Size(191, 17);
            this.chbSaida.TabIndex = 11;
            this.chbSaida.Text = "Se não registar a saída considerar:";
            this.chbSaida.UseVisualStyleBackColor = true;
            // 
            // cbEntrada
            // 
            this.cbEntrada.FormattingEnabled = true;
            this.cbEntrada.Items.AddRange(new object[] {
            "Falta",
            "Dia Trabalhado"});
            this.cbEntrada.Location = new System.Drawing.Point(249, 120);
            this.cbEntrada.Name = "cbEntrada";
            this.cbEntrada.Size = new System.Drawing.Size(103, 21);
            this.cbEntrada.TabIndex = 12;
            // 
            // chbEntrada
            // 
            this.chbEntrada.AutoSize = true;
            this.chbEntrada.Location = new System.Drawing.Point(25, 122);
            this.chbEntrada.Name = "chbEntrada";
            this.chbEntrada.Size = new System.Drawing.Size(200, 17);
            this.chbEntrada.TabIndex = 11;
            this.chbEntrada.Text = "Se não registar a entrada considerar:";
            this.chbEntrada.UseVisualStyleBackColor = true;
            // 
            // chbSaidaAdiantada
            // 
            this.chbSaidaAdiantada.AutoSize = true;
            this.chbSaidaAdiantada.Location = new System.Drawing.Point(25, 88);
            this.chbSaidaAdiantada.Name = "chbSaidaAdiantada";
            this.chbSaidaAdiantada.Size = new System.Drawing.Size(189, 17);
            this.chbSaidaAdiantada.TabIndex = 11;
            this.chbSaidaAdiantada.Text = "Considerar Saída Adiantada Após:";
            this.chbSaidaAdiantada.UseVisualStyleBackColor = true;
            // 
            // chbFalta
            // 
            this.chbFalta.AutoSize = true;
            this.chbFalta.Location = new System.Drawing.Point(25, 54);
            this.chbFalta.Name = "chbFalta";
            this.chbFalta.Size = new System.Drawing.Size(132, 17);
            this.chbFalta.TabIndex = 11;
            this.chbFalta.Text = "Considerar Falta Após:";
            this.chbFalta.UseVisualStyleBackColor = true;
            // 
            // cbAtraso
            // 
            this.cbAtraso.AutoSize = true;
            this.cbAtraso.Location = new System.Drawing.Point(25, 21);
            this.cbAtraso.Name = "cbAtraso";
            this.cbAtraso.Size = new System.Drawing.Size(149, 17);
            this.cbAtraso.TabIndex = 11;
            this.cbAtraso.Text = "Entrada com Atraso Após:";
            this.cbAtraso.UseVisualStyleBackColor = true;
            // 
            // nrSaidaAdiantada
            // 
            this.nrSaidaAdiantada.Location = new System.Drawing.Point(249, 87);
            this.nrSaidaAdiantada.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nrSaidaAdiantada.Name = "nrSaidaAdiantada";
            this.nrSaidaAdiantada.Size = new System.Drawing.Size(46, 20);
            this.nrSaidaAdiantada.TabIndex = 10;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(309, 87);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "minutos";
            // 
            // nrFalta
            // 
            this.nrFalta.Location = new System.Drawing.Point(249, 53);
            this.nrFalta.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nrFalta.Name = "nrFalta";
            this.nrFalta.Size = new System.Drawing.Size(46, 20);
            this.nrFalta.TabIndex = 6;
            // 
            // nrEntradaAtraso
            // 
            this.nrEntradaAtraso.Location = new System.Drawing.Point(249, 20);
            this.nrEntradaAtraso.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nrEntradaAtraso.Name = "nrEntradaAtraso";
            this.nrEntradaAtraso.Size = new System.Drawing.Size(46, 20);
            this.nrEntradaAtraso.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(309, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "minutos";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(309, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "minutos";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.nrAlmoco);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.chbHorasExtraordianarias);
            this.tabPage3.Controls.Add(this.chbAlmoco);
            this.tabPage3.Controls.Add(this.chbHorasExtra);
            this.tabPage3.Controls.Add(this.nrHorasExtra);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(421, 300);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Horas Extra";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // nrAlmoco
            // 
            this.nrAlmoco.Location = new System.Drawing.Point(202, 51);
            this.nrAlmoco.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nrAlmoco.Name = "nrAlmoco";
            this.nrAlmoco.Size = new System.Drawing.Size(46, 20);
            this.nrAlmoco.TabIndex = 15;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(266, 53);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(43, 13);
            this.label14.TabIndex = 14;
            this.label14.Text = "minutos";
            // 
            // chbHorasExtraordianarias
            // 
            this.chbHorasExtraordianarias.AutoSize = true;
            this.chbHorasExtraordianarias.Location = new System.Drawing.Point(17, 84);
            this.chbHorasExtraordianarias.Name = "chbHorasExtraordianarias";
            this.chbHorasExtraordianarias.Size = new System.Drawing.Size(271, 17);
            this.chbHorasExtraordianarias.TabIndex = 12;
            this.chbHorasExtraordianarias.Text = "Considerar fim de semana como horas extraordinária";
            this.chbHorasExtraordianarias.UseVisualStyleBackColor = true;
            this.chbHorasExtraordianarias.CheckedChanged += new System.EventHandler(this.checkBox9_CheckedChanged);
            // 
            // chbAlmoco
            // 
            this.chbAlmoco.AutoSize = true;
            this.chbAlmoco.Location = new System.Drawing.Point(17, 52);
            this.chbAlmoco.Name = "chbAlmoco";
            this.chbAlmoco.Size = new System.Drawing.Size(124, 17);
            this.chbAlmoco.TabIndex = 12;
            this.chbAlmoco.Text = "Tempo para Almoço:";
            this.chbAlmoco.UseVisualStyleBackColor = true;
            this.chbAlmoco.CheckedChanged += new System.EventHandler(this.checkBox9_CheckedChanged);
            // 
            // chbHorasExtra
            // 
            this.chbHorasExtra.AutoSize = true;
            this.chbHorasExtra.Location = new System.Drawing.Point(17, 20);
            this.chbHorasExtra.Name = "chbHorasExtra";
            this.chbHorasExtra.Size = new System.Drawing.Size(169, 17);
            this.chbHorasExtra.TabIndex = 12;
            this.chbHorasExtra.Text = "Considerar Horas Extras Após:";
            this.chbHorasExtra.UseVisualStyleBackColor = true;
            // 
            // nrHorasExtra
            // 
            this.nrHorasExtra.Location = new System.Drawing.Point(202, 19);
            this.nrHorasExtra.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nrHorasExtra.Name = "nrHorasExtra";
            this.nrHorasExtra.Size = new System.Drawing.Size(46, 20);
            this.nrHorasExtra.TabIndex = 4;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(266, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 13);
            this.label13.TabIndex = 3;
            this.label13.Text = "minutos";
            // 
            // frmRegrasDeBatidaDePonto
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
            this.Name = "frmRegrasDeBatidaDePonto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Regras de Batida de Ponto";
            this.Load += new System.EventHandler(this.frmRegrasDeBatidaDePonto_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nrIntervaloMinimoBatida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrHorasTrabalho)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nrSaidaAdiantada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrFalta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrEntradaAtraso)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nrAlmoco)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrHorasExtra)).EndInit();
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
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nrHorasTrabalho;
        private System.Windows.Forms.NumericUpDown nrIntervaloMinimoBatida;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nrFalta;
        private System.Windows.Forms.NumericUpDown nrEntradaAtraso;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nrSaidaAdiantada;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox cbAtraso;
        private System.Windows.Forms.CheckBox chbSaidaAdiantada;
        private System.Windows.Forms.CheckBox chbFalta;
        private System.Windows.Forms.CheckBox cbDiaDeTrabalho;
        private System.Windows.Forms.CheckBox cbIntervaloMinimo;
        private System.Windows.Forms.CheckBox chbEntrada;
        private System.Windows.Forms.ComboBox cbEntrada;
        private System.Windows.Forms.ComboBox cbSaida;
        private System.Windows.Forms.CheckBox chbSaida;
        private System.Windows.Forms.CheckBox chbHorasExtra;
        private System.Windows.Forms.NumericUpDown nrHorasExtra;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown nrAlmoco;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox chbAlmoco;
        private System.Windows.Forms.CheckBox chbHorasExtraordianarias;
    }
}