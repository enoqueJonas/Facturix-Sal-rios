﻿namespace Facturix_Salários
{
    partial class frmCadastrarSeguro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadastrarSeguro));
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRegressar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.txtPercentagem = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataSeguro = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSeguro)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(121, 74);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(440, 20);
            this.txtNome.TabIndex = 3;
            this.txtNome.TextChanged += new System.EventHandler(this.txtNome_TextChanged);
            this.txtNome.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNome_KeyDown_1);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(121, 12);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(41, 20);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.TabStop = false;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(41, 77);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(44, 13);
            this.Label2.TabIndex = 233;
            this.Label2.Text = "Seguro:";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(41, 12);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(59, 13);
            this.Label1.TabIndex = 232;
            this.Label1.Text = "Registo nº:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnRegressar);
            this.panel1.Controls.Add(this.btnConfirmar);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnAtualizar);
            this.panel1.Controls.Add(this.btnEliminar);
            this.panel1.Controls.Add(this.btnAdicionar);
            this.panel1.Location = new System.Drawing.Point(12, 461);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(592, 74);
            this.panel1.TabIndex = 229;
            // 
            // btnRegressar
            // 
            this.btnRegressar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRegressar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegressar.Image = ((System.Drawing.Image)(resources.GetObject("btnRegressar.Image")));
            this.btnRegressar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRegressar.Location = new System.Drawing.Point(479, 5);
            this.btnRegressar.Margin = new System.Windows.Forms.Padding(2);
            this.btnRegressar.Name = "btnRegressar";
            this.btnRegressar.Size = new System.Drawing.Size(69, 60);
            this.btnRegressar.TabIndex = 3002;
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
            this.btnConfirmar.Location = new System.Drawing.Point(299, 5);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(69, 60);
            this.btnConfirmar.TabIndex = 3001;
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
            this.btnCancelar.Location = new System.Drawing.Point(211, 5);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(69, 60);
            this.btnCancelar.TabIndex = 3005;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAtualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAtualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnAtualizar.Image")));
            this.btnAtualizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAtualizar.Location = new System.Drawing.Point(124, 5);
            this.btnAtualizar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(69, 60);
            this.btnAtualizar.TabIndex = 3004;
            this.btnAtualizar.Text = "Modificar";
            this.btnAtualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEliminar.Location = new System.Drawing.Point(391, 5);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(69, 60);
            this.btnEliminar.TabIndex = 3003;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAdicionar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdicionar.Image = ((System.Drawing.Image)(resources.GetObject("btnAdicionar.Image")));
            this.btnAdicionar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAdicionar.Location = new System.Drawing.Point(35, 5);
            this.btnAdicionar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(69, 60);
            this.btnAdicionar.TabIndex = 3006;
            this.btnAdicionar.Text = "\r\nAdicionar";
            this.btnAdicionar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // txtPercentagem
            // 
            this.txtPercentagem.Location = new System.Drawing.Point(121, 44);
            this.txtPercentagem.Name = "txtPercentagem";
            this.txtPercentagem.Size = new System.Drawing.Size(41, 20);
            this.txtPercentagem.TabIndex = 2;
            this.txtPercentagem.TextChanged += new System.EventHandler(this.txtPercentagem_TextChanged);
            this.txtPercentagem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPercentagem_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 235;
            this.label3.Text = "Percentagem:";
            // 
            // dataSeguro
            // 
            this.dataSeguro.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataSeguro.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataSeguro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataSeguro.Location = new System.Drawing.Point(48, 152);
            this.dataSeguro.Name = "dataSeguro";
            this.dataSeguro.RowHeadersVisible = false;
            this.dataSeguro.Size = new System.Drawing.Size(517, 259);
            this.dataSeguro.TabIndex = 246;
            this.dataSeguro.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataSeguro_CellDoubleClick);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(12, 123);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(592, 323);
            this.panel2.TabIndex = 10;
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lbl2.Location = new System.Drawing.Point(20, 77);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(15, 15);
            this.lbl2.TabIndex = 3005;
            this.lbl2.Text = "2";
            this.lbl2.Visible = false;
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lbl1.Location = new System.Drawing.Point(20, 47);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(15, 15);
            this.lbl1.TabIndex = 3007;
            this.lbl1.Text = "1";
            this.lbl1.Visible = false;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lbl1);
            this.panel3.Controls.Add(this.Label1);
            this.panel3.Controls.Add(this.txtCodigo);
            this.panel3.Controls.Add(this.txtNome);
            this.panel3.Controls.Add(this.lbl2);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.txtPercentagem);
            this.panel3.Controls.Add(this.Label2);
            this.panel3.Location = new System.Drawing.Point(12, 10);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(592, 105);
            this.panel3.TabIndex = 3008;
            // 
            // frmCadastrarSeguro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(616, 546);
            this.Controls.Add(this.dataSeguro);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.KeyPreview = true;
            this.Name = "frmCadastrarSeguro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Seguros";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCadastrarSeguro_FormClosing);
            this.Load += new System.EventHandler(this.frmCadastrarSeguro_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCadastrarSeguro_KeyDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataSeguro)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.TextBox txtNome;
        internal System.Windows.Forms.TextBox txtCodigo;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtPercentagem;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataSeguro;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.Label lbl2;
        internal System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Button btnRegressar;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Panel panel3;
    }
}