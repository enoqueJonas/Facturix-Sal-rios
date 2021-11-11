namespace Facturix_Salários.Formularios.Definicoes
{
    partial class frmEnrollDetail
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
            this.clb_Fp = new System.Windows.Forms.CheckedListBox();
            this.cbo_Role = new System.Windows.Forms.ComboBox();
            this.txt_UserId = new System.Windows.Forms.TextBox();
            this.lbl_Role = new System.Windows.Forms.Label();
            this.lbl_UserId = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // clb_Fp
            // 
            this.clb_Fp.Enabled = false;
            this.clb_Fp.FormattingEnabled = true;
            this.clb_Fp.Items.AddRange(new object[] {
            "FP 0",
            "FP 1",
            "FP 2",
            "FP 3",
            "FP 4",
            "FP 5",
            "FP 6",
            "FP 7",
            "FP 8",
            "FP 9",
            "PWD",
            "Card"});
            this.clb_Fp.Location = new System.Drawing.Point(12, 70);
            this.clb_Fp.MultiColumn = true;
            this.clb_Fp.Name = "clb_Fp";
            this.clb_Fp.Size = new System.Drawing.Size(244, 124);
            this.clb_Fp.TabIndex = 9;
            // 
            // cbo_Role
            // 
            this.cbo_Role.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_Role.Enabled = false;
            this.cbo_Role.FormattingEnabled = true;
            this.cbo_Role.Items.AddRange(new object[] {
            "普通用户",
            "超级管理员",
            "登记管理者",
            "查询管理者"});
            this.cbo_Role.Location = new System.Drawing.Point(83, 42);
            this.cbo_Role.Name = "cbo_Role";
            this.cbo_Role.Size = new System.Drawing.Size(173, 21);
            this.cbo_Role.TabIndex = 8;
            // 
            // txt_UserId
            // 
            this.txt_UserId.BackColor = System.Drawing.Color.White;
            this.txt_UserId.Location = new System.Drawing.Point(83, 13);
            this.txt_UserId.Name = "txt_UserId";
            this.txt_UserId.ReadOnly = true;
            this.txt_UserId.Size = new System.Drawing.Size(173, 20);
            this.txt_UserId.TabIndex = 6;
            // 
            // lbl_Role
            // 
            this.lbl_Role.AutoSize = true;
            this.lbl_Role.Location = new System.Drawing.Point(12, 45);
            this.lbl_Role.Name = "lbl_Role";
            this.lbl_Role.Size = new System.Drawing.Size(50, 13);
            this.lbl_Role.TabIndex = 7;
            this.lbl_Role.Text = "Privilege:";
            this.lbl_Role.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_UserId
            // 
            this.lbl_UserId.AutoSize = true;
            this.lbl_UserId.Location = new System.Drawing.Point(24, 16);
            this.lbl_UserId.Name = "lbl_UserId";
            this.lbl_UserId.Size = new System.Drawing.Size(46, 13);
            this.lbl_UserId.TabIndex = 5;
            this.lbl_UserId.Text = "User ID:";
            this.lbl_UserId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmEnrollDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(269, 206);
            this.Controls.Add(this.clb_Fp);
            this.Controls.Add(this.cbo_Role);
            this.Controls.Add(this.txt_UserId);
            this.Controls.Add(this.lbl_Role);
            this.Controls.Add(this.lbl_UserId);
            this.Name = "frmEnrollDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enroll Detail";
            this.Load += new System.EventHandler(this.frmEnrollDetail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clb_Fp;
        private System.Windows.Forms.ComboBox cbo_Role;
        private System.Windows.Forms.TextBox txt_UserId;
        private System.Windows.Forms.Label lbl_Role;
        private System.Windows.Forms.Label lbl_UserId;
    }
}