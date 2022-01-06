namespace Facturix_Salários.Formularios
{
    partial class frmConsultarProcessamento
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
            this.txtMes = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Digite em algarismo o mês que pretende consultar";
            // 
            // txtMes
            // 
            this.txtMes.Location = new System.Drawing.Point(89, 52);
            this.txtMes.Name = "txtMes";
            this.txtMes.Size = new System.Drawing.Size(100, 20);
            this.txtMes.TabIndex = 1;
            this.txtMes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMes_KeyPress);
            // 
            // frmConsultarProcessamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(297, 109);
            this.Controls.Add(this.txtMes);
            this.Controls.Add(this.label1);
            this.Name = "frmConsultarProcessamento";
            this.Text = "Consultar Processamento";
            this.Load += new System.EventHandler(this.frmConsultarProcessamento_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmConsultarProcessamento_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmConsultarProcessamento_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMes;
    }
}