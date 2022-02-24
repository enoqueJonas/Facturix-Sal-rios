namespace Facturix_Salários.Formularios
{
    partial class frmListagemDeFuncionariosDiasDeTrabalho
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListagemDeFuncionariosDiasDeTrabalho));
            this.lblEstado = new System.Windows.Forms.Label();
            this.btnSelecionarTodos = new System.Windows.Forms.Button();
            this.btnContinuar = new System.Windows.Forms.Button();
            this.dataFuncionarios = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataFuncionarios)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(380, 216);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(169, 31);
            this.lblEstado.TabIndex = 6;
            this.lblEstado.Text = "Sem Registo";
            this.lblEstado.Visible = false;
            // 
            // btnSelecionarTodos
            // 
            this.btnSelecionarTodos.Location = new System.Drawing.Point(24, 504);
            this.btnSelecionarTodos.Name = "btnSelecionarTodos";
            this.btnSelecionarTodos.Size = new System.Drawing.Size(121, 31);
            this.btnSelecionarTodos.TabIndex = 4;
            this.btnSelecionarTodos.Text = "&Selecionar Todos";
            this.btnSelecionarTodos.UseVisualStyleBackColor = true;
            this.btnSelecionarTodos.Click += new System.EventHandler(this.btnSelecionarTodos_Click);
            // 
            // btnContinuar
            // 
            this.btnContinuar.Image = ((System.Drawing.Image)(resources.GetObject("btnContinuar.Image")));
            this.btnContinuar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnContinuar.Location = new System.Drawing.Point(797, 504);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(121, 31);
            this.btnContinuar.TabIndex = 5;
            this.btnContinuar.Text = "Consultar";
            this.btnContinuar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnContinuar.UseVisualStyleBackColor = true;
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
            // 
            // dataFuncionarios
            // 
            this.dataFuncionarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataFuncionarios.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataFuncionarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataFuncionarios.Location = new System.Drawing.Point(24, 19);
            this.dataFuncionarios.Name = "dataFuncionarios";
            this.dataFuncionarios.RowHeadersVisible = false;
            this.dataFuncionarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataFuncionarios.Size = new System.Drawing.Size(894, 468);
            this.dataFuncionarios.TabIndex = 3;
            // 
            // frmListagemDeFuncionariosDiasDeTrabalho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(942, 551);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.btnSelecionarTodos);
            this.Controls.Add(this.btnContinuar);
            this.Controls.Add(this.dataFuncionarios);
            this.Name = "frmListagemDeFuncionariosDiasDeTrabalho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listagem de Funcionário ";
            this.Load += new System.EventHandler(this.frmListagemDeFuncionariosDiasDeTrabalho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataFuncionarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Button btnSelecionarTodos;
        private System.Windows.Forms.Button btnContinuar;
        private System.Windows.Forms.DataGridView dataFuncionarios;
    }
}