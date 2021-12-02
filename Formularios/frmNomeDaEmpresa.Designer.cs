namespace Facturix_Salários.Formularios
{
    partial class frmNomeDaEmpresa
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNomeAbreviado = new System.Windows.Forms.TextBox();
            this.txtNomeDaEmpresa = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.cbLogo = new System.Windows.Forms.CheckBox();
            this.btnAdicionarFoto = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Passo à passo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(226, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nome da Empresa:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(226, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Nome Abreviado da Empresa:";
            // 
            // txtNomeAbreviado
            // 
            this.txtNomeAbreviado.Location = new System.Drawing.Point(392, 57);
            this.txtNomeAbreviado.Name = "txtNomeAbreviado";
            this.txtNomeAbreviado.Size = new System.Drawing.Size(266, 20);
            this.txtNomeAbreviado.TabIndex = 1;
            // 
            // txtNomeDaEmpresa
            // 
            this.txtNomeDaEmpresa.Location = new System.Drawing.Point(392, 28);
            this.txtNomeDaEmpresa.Name = "txtNomeDaEmpresa";
            this.txtNomeDaEmpresa.Size = new System.Drawing.Size(266, 20);
            this.txtNomeDaEmpresa.TabIndex = 1;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Location = new System.Drawing.Point(21, 60);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(169, 81);
            this.textBox3.TabIndex = 1;
            this.textBox3.Text = "Digite o nome e adicione o logotipo \r\nda empresa.";
            // 
            // cbLogo
            // 
            this.cbLogo.AutoSize = true;
            this.cbLogo.Location = new System.Drawing.Point(229, 94);
            this.cbLogo.Name = "cbLogo";
            this.cbLogo.Size = new System.Drawing.Size(50, 17);
            this.cbLogo.TabIndex = 2;
            this.cbLogo.Text = "Logo";
            this.cbLogo.UseVisualStyleBackColor = true;
            // 
            // btnAdicionarFoto
            // 
            this.btnAdicionarFoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionarFoto.Location = new System.Drawing.Point(392, 224);
            this.btnAdicionarFoto.Name = "btnAdicionarFoto";
            this.btnAdicionarFoto.Size = new System.Drawing.Size(146, 23);
            this.btnAdicionarFoto.TabIndex = 3;
            this.btnAdicionarFoto.Text = "Carregar Imagem";
            this.btnAdicionarFoto.UseVisualStyleBackColor = true;
            this.btnAdicionarFoto.Click += new System.EventHandler(this.btnAdicionarFoto_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(583, 502);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Seguinte";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(476, 502);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Anterior";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            // 
            // pbLogo
            // 
            this.pbLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbLogo.Location = new System.Drawing.Point(392, 94);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(146, 124);
            this.pbLogo.TabIndex = 4;
            this.pbLogo.TabStop = false;
            // 
            // frmNomeDaEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(670, 537);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAdicionarFoto);
            this.Controls.Add(this.cbLogo);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.txtNomeDaEmpresa);
            this.Controls.Add(this.txtNomeAbreviado);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "frmNomeDaEmpresa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informação da Empresa";
            this.Load += new System.EventHandler(this.frmNomeDaEmpresa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNomeAbreviado;
        private System.Windows.Forms.TextBox txtNomeDaEmpresa;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.CheckBox cbLogo;
        private System.Windows.Forms.Button btnAdicionarFoto;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pbLogo;
    }
}