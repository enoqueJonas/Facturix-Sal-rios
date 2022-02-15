namespace Facturix_Salários.Formularios
{
    partial class frmTerminarProcessamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTerminarProcessamento));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRegressar = new System.Windows.Forms.Button();
            this.rtxtFuncProcessados = new System.Windows.Forms.RichTextBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRegressar);
            this.groupBox2.Location = new System.Drawing.Point(12, 340);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(364, 79);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // btnRegressar
            // 
            this.btnRegressar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRegressar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegressar.ForeColor = System.Drawing.Color.Black;
            this.btnRegressar.Image = ((System.Drawing.Image)(resources.GetObject("btnRegressar.Image")));
            this.btnRegressar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRegressar.Location = new System.Drawing.Point(146, 11);
            this.btnRegressar.Margin = new System.Windows.Forms.Padding(2);
            this.btnRegressar.Name = "btnRegressar";
            this.btnRegressar.Size = new System.Drawing.Size(69, 60);
            this.btnRegressar.TabIndex = 6;
            this.btnRegressar.TabStop = false;
            this.btnRegressar.Text = "Regressar";
            this.btnRegressar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRegressar.UseVisualStyleBackColor = true;
            this.btnRegressar.Click += new System.EventHandler(this.btnRegressar_Click);
            // 
            // rtxtFuncProcessados
            // 
            this.rtxtFuncProcessados.Location = new System.Drawing.Point(12, 12);
            this.rtxtFuncProcessados.Name = "rtxtFuncProcessados";
            this.rtxtFuncProcessados.Size = new System.Drawing.Size(364, 322);
            this.rtxtFuncProcessados.TabIndex = 6;
            this.rtxtFuncProcessados.Text = "";
            // 
            // frmTerminarProcessamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(391, 429);
            this.Controls.Add(this.rtxtFuncProcessados);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmTerminarProcessamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Processamento";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTerminarProcessamento_FormClosing);
            this.Load += new System.EventHandler(this.frmTerminarProcessamento_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTerminarProcessamento_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmTerminarProcessamento_KeyPress);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRegressar;
        public System.Windows.Forms.RichTextBox rtxtFuncProcessados;
    }
}