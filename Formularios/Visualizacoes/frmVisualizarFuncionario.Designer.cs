namespace Facturix_Salários
{
    partial class frmVisualizarFuncionario
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVisualizarFuncionario));
            this.dataFuncionarios = new System.Windows.Forms.DataGridView();
            this.txtLocalizar = new System.Windows.Forms.TextBox();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnRegressar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNumeroFuncionarios = new System.Windows.Forms.Label();
            this.txtNumeroFuncionarios = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataFuncionarios)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataFuncionarios
            // 
            this.dataFuncionarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataFuncionarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataFuncionarios.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataFuncionarios.Location = new System.Drawing.Point(19, 38);
            this.dataFuncionarios.Name = "dataFuncionarios";
            this.dataFuncionarios.RowHeadersVisible = false;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dataFuncionarios.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataFuncionarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataFuncionarios.Size = new System.Drawing.Size(852, 477);
            this.dataFuncionarios.TabIndex = 0;
            this.dataFuncionarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataFuncionarios_CellClick);
            this.dataFuncionarios.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataFuncionarios_CellDoubleClick);
            // 
            // txtLocalizar
            // 
            this.txtLocalizar.Location = new System.Drawing.Point(71, 8);
            this.txtLocalizar.Name = "txtLocalizar";
            this.txtLocalizar.Size = new System.Drawing.Size(800, 20);
            this.txtLocalizar.TabIndex = 1;
            this.txtLocalizar.TextChanged += new System.EventHandler(this.txtLocalizar_TextChanged);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAdicionar.BackgroundImage")));
            this.btnAdicionar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAdicionar.Location = new System.Drawing.Point(12, 23);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(102, 40);
            this.btnAdicionar.TabIndex = 2;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConsultar.BackgroundImage")));
            this.btnConsultar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnConsultar.Location = new System.Drawing.Point(12, 81);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(102, 40);
            this.btnConsultar.TabIndex = 3;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminar.BackgroundImage")));
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnEliminar.Enabled = false;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Location = new System.Drawing.Point(12, 137);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(102, 40);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnImprimir.Enabled = false;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Location = new System.Drawing.Point(12, 200);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(102, 40);
            this.btnImprimir.TabIndex = 5;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnRegressar
            // 
            this.btnRegressar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRegressar.Location = new System.Drawing.Point(12, 259);
            this.btnRegressar.Name = "btnRegressar";
            this.btnRegressar.Size = new System.Drawing.Size(102, 40);
            this.btnRegressar.TabIndex = 6;
            this.btnRegressar.Text = "Regressar";
            this.btnRegressar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRegressar.UseVisualStyleBackColor = true;
            this.btnRegressar.Click += new System.EventHandler(this.btnRegressar_Click);
            this.btnRegressar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnRegre);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Localizar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 26);
            this.label2.TabIndex = 8;
            this.label2.Text = "Número de Funcionários \r\n          cadastrados ";
            // 
            // lblNumeroFuncionarios
            // 
            this.lblNumeroFuncionarios.AutoSize = true;
            this.lblNumeroFuncionarios.Location = new System.Drawing.Point(60, 453);
            this.lblNumeroFuncionarios.Name = "lblNumeroFuncionarios";
            this.lblNumeroFuncionarios.Size = new System.Drawing.Size(0, 13);
            this.lblNumeroFuncionarios.TabIndex = 9;
            // 
            // txtNumeroFuncionarios
            // 
            this.txtNumeroFuncionarios.Enabled = false;
            this.txtNumeroFuncionarios.Location = new System.Drawing.Point(36, 49);
            this.txtNumeroFuncionarios.Name = "txtNumeroFuncionarios";
            this.txtNumeroFuncionarios.ReadOnly = true;
            this.txtNumeroFuncionarios.Size = new System.Drawing.Size(57, 20);
            this.txtNumeroFuncionarios.TabIndex = 10;
            this.txtNumeroFuncionarios.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnConsultar);
            this.panel1.Controls.Add(this.btnAdicionar);
            this.panel1.Controls.Add(this.btnEliminar);
            this.panel1.Controls.Add(this.btnImprimir);
            this.panel1.Controls.Add(this.btnRegressar);
            this.panel1.Location = new System.Drawing.Point(10, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(128, 324);
            this.panel1.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.lblNumeroFuncionarios);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Location = new System.Drawing.Point(8, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(151, 543);
            this.panel2.TabIndex = 12;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.txtNumeroFuncionarios);
            this.panel4.Location = new System.Drawing.Point(10, 428);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(128, 86);
            this.panel4.TabIndex = 12;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txtLocalizar);
            this.panel3.Controls.Add(this.dataFuncionarios);
            this.panel3.Location = new System.Drawing.Point(181, 11);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(891, 544);
            this.panel3.TabIndex = 13;
            // 
            // frmVisualizarFuncionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1084, 567);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.KeyPreview = true;
            this.Name = "frmVisualizarFuncionario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visualização de Funcionários";
            this.Load += new System.EventHandler(this.frmVisualizarF_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmVisualizarF_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmVisualizarF_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.dataFuncionarios)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataFuncionarios;
        private System.Windows.Forms.TextBox txtLocalizar;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnRegressar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNumeroFuncionarios;
        private System.Windows.Forms.TextBox txtNumeroFuncionarios;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
    }
}