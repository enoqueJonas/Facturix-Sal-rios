namespace Facturix_Salários.Formularios.Definicoes
{
    partial class frmSlog
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
            this.lvw_SLogList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chk_NewFlag = new System.Windows.Forms.CheckBox();
            this.dtp_End = new System.Windows.Forms.DateTimePicker();
            this.dtp_Begin = new System.Windows.Forms.DateTimePicker();
            this.btn_DownloadNew = new System.Windows.Forms.Button();
            this.btn_DownloadHistory = new System.Windows.Forms.Button();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.lbl_EndDate = new System.Windows.Forms.Label();
            this.lbl_BeginDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lvw_SLogList
            // 
            this.lvw_SLogList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvw_SLogList.FullRowSelect = true;
            this.lvw_SLogList.GridLines = true;
            this.lvw_SLogList.HideSelection = false;
            this.lvw_SLogList.Location = new System.Drawing.Point(12, 14);
            this.lvw_SLogList.MultiSelect = false;
            this.lvw_SLogList.Name = "lvw_SLogList";
            this.lvw_SLogList.Size = new System.Drawing.Size(637, 383);
            this.lvw_SLogList.TabIndex = 21;
            this.lvw_SLogList.UseCompatibleStateImageBehavior = false;
            this.lvw_SLogList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "SN";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ID de Adiministrador";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "ID de Utilizador";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Operação";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Cadastro";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Data";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 150;
            // 
            // chk_NewFlag
            // 
            this.chk_NewFlag.AutoSize = true;
            this.chk_NewFlag.Location = new System.Drawing.Point(456, 409);
            this.chk_NewFlag.Name = "chk_NewFlag";
            this.chk_NewFlag.Size = new System.Drawing.Size(139, 17);
            this.chk_NewFlag.TabIndex = 29;
            this.chk_NewFlag.Text = "Clear New Slog Position";
            this.chk_NewFlag.UseVisualStyleBackColor = true;
            this.chk_NewFlag.Visible = false;
            // 
            // dtp_End
            // 
            this.dtp_End.CustomFormat = "yyyy-MM-dd";
            this.dtp_End.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_End.Location = new System.Drawing.Point(266, 404);
            this.dtp_End.Name = "dtp_End";
            this.dtp_End.Size = new System.Drawing.Size(120, 20);
            this.dtp_End.TabIndex = 28;
            // 
            // dtp_Begin
            // 
            this.dtp_Begin.CustomFormat = "yyyy-MM-dd";
            this.dtp_Begin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_Begin.Location = new System.Drawing.Point(53, 404);
            this.dtp_Begin.Name = "dtp_Begin";
            this.dtp_Begin.Size = new System.Drawing.Size(120, 20);
            this.dtp_Begin.TabIndex = 27;
            // 
            // btn_DownloadNew
            // 
            this.btn_DownloadNew.Location = new System.Drawing.Point(332, 437);
            this.btn_DownloadNew.Name = "btn_DownloadNew";
            this.btn_DownloadNew.Size = new System.Drawing.Size(103, 25);
            this.btn_DownloadNew.TabIndex = 24;
            this.btn_DownloadNew.Text = "Obter Novo";
            this.btn_DownloadNew.UseVisualStyleBackColor = true;
            this.btn_DownloadNew.Click += new System.EventHandler(this.btn_DownloadNew_Click);
            // 
            // btn_DownloadHistory
            // 
            this.btn_DownloadHistory.Location = new System.Drawing.Point(441, 437);
            this.btn_DownloadHistory.Name = "btn_DownloadHistory";
            this.btn_DownloadHistory.Size = new System.Drawing.Size(103, 25);
            this.btn_DownloadHistory.TabIndex = 25;
            this.btn_DownloadHistory.Text = "Obter Todo";
            this.btn_DownloadHistory.UseVisualStyleBackColor = true;
            this.btn_DownloadHistory.Click += new System.EventHandler(this.btn_DownloadHistory_Click);
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(550, 435);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(99, 25);
            this.btn_Clear.TabIndex = 26;
            this.btn_Clear.Text = "Limpar Todo";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // lbl_EndDate
            // 
            this.lbl_EndDate.AutoSize = true;
            this.lbl_EndDate.Location = new System.Drawing.Point(236, 407);
            this.lbl_EndDate.Name = "lbl_EndDate";
            this.lbl_EndDate.Size = new System.Drawing.Size(26, 13);
            this.lbl_EndDate.TabIndex = 23;
            this.lbl_EndDate.Text = "Até:";
            this.lbl_EndDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_BeginDate
            // 
            this.lbl_BeginDate.AutoSize = true;
            this.lbl_BeginDate.Location = new System.Drawing.Point(12, 408);
            this.lbl_BeginDate.Name = "lbl_BeginDate";
            this.lbl_BeginDate.Size = new System.Drawing.Size(24, 13);
            this.lbl_BeginDate.TabIndex = 22;
            this.lbl_BeginDate.Text = "De:";
            this.lbl_BeginDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmSlog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(661, 477);
            this.Controls.Add(this.lvw_SLogList);
            this.Controls.Add(this.chk_NewFlag);
            this.Controls.Add(this.dtp_End);
            this.Controls.Add(this.dtp_Begin);
            this.Controls.Add(this.btn_DownloadNew);
            this.Controls.Add(this.btn_DownloadHistory);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.lbl_EndDate);
            this.Controls.Add(this.lbl_BeginDate);
            this.Name = "frmSlog";
            this.Text = "frmSlog";
            this.Load += new System.EventHandler(this.frmSlog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvw_SLogList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.CheckBox chk_NewFlag;
        private System.Windows.Forms.DateTimePicker dtp_End;
        private System.Windows.Forms.DateTimePicker dtp_Begin;
        private System.Windows.Forms.Button btn_DownloadNew;
        private System.Windows.Forms.Button btn_DownloadHistory;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Label lbl_EndDate;
        private System.Windows.Forms.Label lbl_BeginDate;
    }
}