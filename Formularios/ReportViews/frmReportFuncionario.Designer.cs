namespace Facturix_Salários
{
    partial class frmReportFuncionario
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
            this.crDataTable = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.reportFuncionario1 = new Facturix_Salários.Reports.reportFuncionario();
            this.SuspendLayout();
            // 
            // crDataTable
            // 
            this.crDataTable.ActiveViewIndex = 0;
            this.crDataTable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crDataTable.Cursor = System.Windows.Forms.Cursors.Default;
            this.crDataTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crDataTable.Location = new System.Drawing.Point(0, 0);
            this.crDataTable.Name = "crDataTable";
            this.crDataTable.ReportSource = this.reportFuncionario1;
            this.crDataTable.Size = new System.Drawing.Size(901, 519);
            this.crDataTable.TabIndex = 0;
            this.crDataTable.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crDataTable.Load += new System.EventHandler(this.crystalReportViewer1_Load);
            // 
            // frmReportFuncionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 519);
            this.Controls.Add(this.crDataTable);
            this.Name = "frmReportFuncionario";
            this.Text = "frmReportFuncionario";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crDataTable;
        private Reports.reportFuncionario reportFuncionario1;
    }
}