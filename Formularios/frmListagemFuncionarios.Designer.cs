namespace Facturix_Salários.Formularios
{
    partial class frmListagemFuncionarios
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
            this.dataFuncionarios = new System.Windows.Forms.DataGridView();
            this.btnContinuar = new System.Windows.Forms.Button();
            this.btnSelecionarTodos = new System.Windows.Forms.Button();
            this.lblEstado = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataFuncionarios)).BeginInit();
            this.SuspendLayout();
            // 
            // dataFuncionarios
            // 
            this.dataFuncionarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataFuncionarios.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataFuncionarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataFuncionarios.Location = new System.Drawing.Point(24, 27);
            this.dataFuncionarios.Name = "dataFuncionarios";
            this.dataFuncionarios.RowHeadersVisible = false;
            this.dataFuncionarios.Size = new System.Drawing.Size(894, 468);
            this.dataFuncionarios.TabIndex = 0;
            // 
            // btnContinuar
            // 
            this.btnContinuar.Location = new System.Drawing.Point(804, 513);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(114, 30);
            this.btnContinuar.TabIndex = 1;
            this.btnContinuar.Text = "Processar Sal.";
            this.btnContinuar.UseVisualStyleBackColor = true;
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
            // 
            // btnSelecionarTodos
            // 
            this.btnSelecionarTodos.Location = new System.Drawing.Point(24, 512);
            this.btnSelecionarTodos.Name = "btnSelecionarTodos";
            this.btnSelecionarTodos.Size = new System.Drawing.Size(114, 30);
            this.btnSelecionarTodos.TabIndex = 1;
            this.btnSelecionarTodos.Text = "Selecionar Todos";
            this.btnSelecionarTodos.UseVisualStyleBackColor = true;
            this.btnSelecionarTodos.Click += new System.EventHandler(this.btnSelecionarTodos_Click);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(380, 224);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(169, 31);
            this.lblEstado.TabIndex = 2;
            this.lblEstado.Text = "Sem Registo";
            this.lblEstado.Visible = false;
            // 
            // frmListagemFuncionarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(942, 555);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.btnSelecionarTodos);
            this.Controls.Add(this.btnContinuar);
            this.Controls.Add(this.dataFuncionarios);
            this.Name = "frmListagemFuncionarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listagem de Funcionários";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmListagemFuncionarios_FormClosing);
            this.Load += new System.EventHandler(this.frmListagemFuncionarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataFuncionarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataFuncionarios;
        private System.Windows.Forms.Button btnContinuar;
        private System.Windows.Forms.Button btnSelecionarTodos;
        private System.Windows.Forms.Label lblEstado;
    }
}