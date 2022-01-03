namespace Facturix_Salários.Formularios
{
    partial class frmAdicionarRemuneracao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdicionarRemuneracao));
            this.label1 = new System.Windows.Forms.Label();
            this.cbRemuneracoes = new System.Windows.Forms.ComboBox();
            this.txtval = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtqtd = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRegressar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.txtIdRemuneracao = new System.Windows.Forms.TextBox();
            this.txtIdFuncionario = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo de Remuneração:";
            // 
            // cbRemuneracoes
            // 
            this.cbRemuneracoes.FormattingEnabled = true;
            this.cbRemuneracoes.Location = new System.Drawing.Point(150, 23);
            this.cbRemuneracoes.Name = "cbRemuneracoes";
            this.cbRemuneracoes.Size = new System.Drawing.Size(242, 21);
            this.cbRemuneracoes.TabIndex = 1;
            this.cbRemuneracoes.SelectedIndexChanged += new System.EventHandler(this.cbRemuneracoes_SelectedIndexChanged);
            this.cbRemuneracoes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbRemuneracoes_KeyDown);
            // 
            // txtval
            // 
            this.txtval.Location = new System.Drawing.Point(150, 73);
            this.txtval.Name = "txtval";
            this.txtval.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtval.Size = new System.Drawing.Size(100, 20);
            this.txtval.TabIndex = 4;
            this.txtval.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtval_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Valor Unitário:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Quantidade:";
            // 
            // txtqtd
            // 
            this.txtqtd.Location = new System.Drawing.Point(150, 47);
            this.txtqtd.Name = "txtqtd";
            this.txtqtd.Size = new System.Drawing.Size(100, 20);
            this.txtqtd.TabIndex = 2;
            this.txtqtd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtqtd_KeyDown);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnRegressar);
            this.panel1.Controls.Add(this.btnConfirmar);
            this.panel1.Location = new System.Drawing.Point(31, 99);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(361, 69);
            this.panel1.TabIndex = 3;
            // 
            // btnRegressar
            // 
            this.btnRegressar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRegressar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegressar.ForeColor = System.Drawing.Color.Black;
            this.btnRegressar.Image = ((System.Drawing.Image)(resources.GetObject("btnRegressar.Image")));
            this.btnRegressar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRegressar.Location = new System.Drawing.Point(254, 3);
            this.btnRegressar.Margin = new System.Windows.Forms.Padding(2);
            this.btnRegressar.Name = "btnRegressar";
            this.btnRegressar.Size = new System.Drawing.Size(69, 60);
            this.btnRegressar.TabIndex = 900002;
            this.btnRegressar.TabStop = false;
            this.btnRegressar.Text = "Regressar";
            this.btnRegressar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRegressar.UseVisualStyleBackColor = true;
            this.btnRegressar.Click += new System.EventHandler(this.btnRegressar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmar.ForeColor = System.Drawing.Color.Black;
            this.btnConfirmar.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirmar.Image")));
            this.btnConfirmar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnConfirmar.Location = new System.Drawing.Point(35, 3);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(69, 60);
            this.btnConfirmar.TabIndex = 900001;
            this.btnConfirmar.TabStop = false;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // txtIdRemuneracao
            // 
            this.txtIdRemuneracao.Location = new System.Drawing.Point(292, 73);
            this.txtIdRemuneracao.Name = "txtIdRemuneracao";
            this.txtIdRemuneracao.Size = new System.Drawing.Size(100, 20);
            this.txtIdRemuneracao.TabIndex = 5;
            this.txtIdRemuneracao.Visible = false;
            this.txtIdRemuneracao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIdRemuneracao_KeyDown);
            // 
            // txtIdFuncionario
            // 
            this.txtIdFuncionario.Location = new System.Drawing.Point(292, 47);
            this.txtIdFuncionario.Name = "txtIdFuncionario";
            this.txtIdFuncionario.Size = new System.Drawing.Size(100, 20);
            this.txtIdFuncionario.TabIndex = 3;
            this.txtIdFuncionario.Visible = false;
            this.txtIdFuncionario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIdFuncionario_KeyDown);
            // 
            // frmAdicionarRemuneracao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(420, 173);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtIdFuncionario);
            this.Controls.Add(this.txtIdRemuneracao);
            this.Controls.Add(this.txtqtd);
            this.Controls.Add(this.txtval);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbRemuneracoes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "frmAdicionarRemuneracao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adicionar Remuneração";
            this.Load += new System.EventHandler(this.frmAdicionarRemuneracao_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAdicionarRemuneracao_KeyDown);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRegressar;
        private System.Windows.Forms.Button btnConfirmar;
        public System.Windows.Forms.ComboBox cbRemuneracoes;
        public System.Windows.Forms.TextBox txtval;
        public System.Windows.Forms.TextBox txtqtd;
        public System.Windows.Forms.TextBox txtIdRemuneracao;
        public System.Windows.Forms.TextBox txtIdFuncionario;
    }
}