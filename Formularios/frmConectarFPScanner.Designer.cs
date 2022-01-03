namespace Facturix_Salários.Conexoes
{
    partial class frmConectarFPScanner
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
            this.btn_RealTimeLog = new System.Windows.Forms.Button();
            this.group = new System.Windows.Forms.GroupBox();
            this.btn_GlogManagement = new System.Windows.Forms.Button();
            this.btn_SlogManagement = new System.Windows.Forms.Button();
            this.btn_EnrollManagement = new System.Windows.Forms.Button();
            this.btn_SystemSetting = new System.Windows.Forms.Button();
            this.btn_AlarmSetting = new System.Windows.Forms.Button();
            this.btn_AttendanceSetting = new System.Windows.Forms.Button();
            this.btn_AccessSetting = new System.Windows.Forms.Button();
            this.btn_CloseDevice = new System.Windows.Forms.Button();
            this.btn_OpenDevice = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.p2pServerTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.p2pAddrTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.p2pRadioButton = new System.Windows.Forms.RadioButton();
            this.nud_Port = new System.Windows.Forms.NumericUpDown();
            this.nud_Pwd = new System.Windows.Forms.NumericUpDown();
            this.nud_DN = new System.Windows.Forms.NumericUpDown();
            this.cbo_BaudRate = new System.Windows.Forms.ComboBox();
            this.cbo_COMM = new System.Windows.Forms.ComboBox();
            this.lbl_BaudRate = new System.Windows.Forms.Label();
            this.lbl_COMM = new System.Windows.Forms.Label();
            this.rdb_TCP = new System.Windows.Forms.RadioButton();
            this.rdb_COMM = new System.Windows.Forms.RadioButton();
            this.rdb_USB = new System.Windows.Forms.RadioButton();
            this.txt_IP = new System.Windows.Forms.TextBox();
            this.lbl_Port = new System.Windows.Forms.Label();
            this.lbl_IP = new System.Windows.Forms.Label();
            this.lbl_ConnectionPwd = new System.Windows.Forms.Label();
            this.lbl_DeviceId = new System.Windows.Forms.Label();
            this.group.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Port)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Pwd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_DN)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_RealTimeLog
            // 
            this.btn_RealTimeLog.Location = new System.Drawing.Point(262, 246);
            this.btn_RealTimeLog.Name = "btn_RealTimeLog";
            this.btn_RealTimeLog.Size = new System.Drawing.Size(156, 25);
            this.btn_RealTimeLog.TabIndex = 9;
            this.btn_RealTimeLog.Text = "Relatório em Tempo Real";
            this.btn_RealTimeLog.UseVisualStyleBackColor = true;
            this.btn_RealTimeLog.Visible = false;
            this.btn_RealTimeLog.Click += new System.EventHandler(this.btn_RealTimeLog_Click);
            // 
            // group
            // 
            this.group.Controls.Add(this.btn_GlogManagement);
            this.group.Controls.Add(this.btn_SlogManagement);
            this.group.Controls.Add(this.btn_EnrollManagement);
            this.group.Controls.Add(this.btn_SystemSetting);
            this.group.Location = new System.Drawing.Point(256, 57);
            this.group.Name = "group";
            this.group.Size = new System.Drawing.Size(333, 94);
            this.group.TabIndex = 8;
            this.group.TabStop = false;
            this.group.Text = "Funções";
            // 
            // btn_GlogManagement
            // 
            this.btn_GlogManagement.Location = new System.Drawing.Point(6, 54);
            this.btn_GlogManagement.Name = "btn_GlogManagement";
            this.btn_GlogManagement.Size = new System.Drawing.Size(156, 25);
            this.btn_GlogManagement.TabIndex = 6;
            this.btn_GlogManagement.Text = "Relatório de Ponto";
            this.btn_GlogManagement.UseVisualStyleBackColor = true;
            this.btn_GlogManagement.Click += new System.EventHandler(this.btn_GlogManagement_Click);
            // 
            // btn_SlogManagement
            // 
            this.btn_SlogManagement.Location = new System.Drawing.Point(173, 22);
            this.btn_SlogManagement.Name = "btn_SlogManagement";
            this.btn_SlogManagement.Size = new System.Drawing.Size(156, 25);
            this.btn_SlogManagement.TabIndex = 5;
            this.btn_SlogManagement.Text = "Relatório do Sistema";
            this.btn_SlogManagement.UseVisualStyleBackColor = true;
            this.btn_SlogManagement.Click += new System.EventHandler(this.btn_SlogManagement_Click);
            // 
            // btn_EnrollManagement
            // 
            this.btn_EnrollManagement.Location = new System.Drawing.Point(173, 54);
            this.btn_EnrollManagement.Name = "btn_EnrollManagement";
            this.btn_EnrollManagement.Size = new System.Drawing.Size(156, 25);
            this.btn_EnrollManagement.TabIndex = 4;
            this.btn_EnrollManagement.Text = "Gestão de Funcionários";
            this.btn_EnrollManagement.UseVisualStyleBackColor = true;
            this.btn_EnrollManagement.Click += new System.EventHandler(this.btn_EnrollManagement_Click);
            // 
            // btn_SystemSetting
            // 
            this.btn_SystemSetting.Location = new System.Drawing.Point(6, 22);
            this.btn_SystemSetting.Name = "btn_SystemSetting";
            this.btn_SystemSetting.Size = new System.Drawing.Size(156, 25);
            this.btn_SystemSetting.TabIndex = 0;
            this.btn_SystemSetting.Text = "Definições de Sistema";
            this.btn_SystemSetting.UseVisualStyleBackColor = true;
            this.btn_SystemSetting.Click += new System.EventHandler(this.btn_SystemSetting_Click);
            // 
            // btn_AlarmSetting
            // 
            this.btn_AlarmSetting.Location = new System.Drawing.Point(433, 246);
            this.btn_AlarmSetting.Name = "btn_AlarmSetting";
            this.btn_AlarmSetting.Size = new System.Drawing.Size(156, 25);
            this.btn_AlarmSetting.TabIndex = 1;
            this.btn_AlarmSetting.Text = "Definições de Alarme";
            this.btn_AlarmSetting.UseVisualStyleBackColor = true;
            this.btn_AlarmSetting.Visible = false;
            this.btn_AlarmSetting.Click += new System.EventHandler(this.btn_AlarmSetting_Click);
            // 
            // btn_AttendanceSetting
            // 
            this.btn_AttendanceSetting.Location = new System.Drawing.Point(433, 215);
            this.btn_AttendanceSetting.Name = "btn_AttendanceSetting";
            this.btn_AttendanceSetting.Size = new System.Drawing.Size(156, 25);
            this.btn_AttendanceSetting.TabIndex = 3;
            this.btn_AttendanceSetting.Text = "Definições de Mensagens";
            this.btn_AttendanceSetting.UseVisualStyleBackColor = true;
            this.btn_AttendanceSetting.Visible = false;
            this.btn_AttendanceSetting.Click += new System.EventHandler(this.btn_AttendanceSetting_Click);
            // 
            // btn_AccessSetting
            // 
            this.btn_AccessSetting.Location = new System.Drawing.Point(262, 214);
            this.btn_AccessSetting.Name = "btn_AccessSetting";
            this.btn_AccessSetting.Size = new System.Drawing.Size(156, 25);
            this.btn_AccessSetting.TabIndex = 2;
            this.btn_AccessSetting.Text = "Controle de Acesso";
            this.btn_AccessSetting.UseVisualStyleBackColor = true;
            this.btn_AccessSetting.Visible = false;
            this.btn_AccessSetting.Click += new System.EventHandler(this.btn_AccessSetting_Click);
            // 
            // btn_CloseDevice
            // 
            this.btn_CloseDevice.Location = new System.Drawing.Point(357, 26);
            this.btn_CloseDevice.Name = "btn_CloseDevice";
            this.btn_CloseDevice.Size = new System.Drawing.Size(95, 25);
            this.btn_CloseDevice.TabIndex = 7;
            this.btn_CloseDevice.Text = "Disconectar";
            this.btn_CloseDevice.UseVisualStyleBackColor = true;
            this.btn_CloseDevice.Click += new System.EventHandler(this.btn_CloseDevice_Click_1);
            // 
            // btn_OpenDevice
            // 
            this.btn_OpenDevice.Location = new System.Drawing.Point(256, 26);
            this.btn_OpenDevice.Name = "btn_OpenDevice";
            this.btn_OpenDevice.Size = new System.Drawing.Size(95, 25);
            this.btn_OpenDevice.TabIndex = 6;
            this.btn_OpenDevice.Text = "Conectar";
            this.btn_OpenDevice.UseVisualStyleBackColor = true;
            this.btn_OpenDevice.Click += new System.EventHandler(this.btn_OpenDevice_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.p2pServerTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.p2pAddrTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.p2pRadioButton);
            this.groupBox1.Controls.Add(this.nud_Port);
            this.groupBox1.Controls.Add(this.nud_Pwd);
            this.groupBox1.Controls.Add(this.nud_DN);
            this.groupBox1.Controls.Add(this.cbo_BaudRate);
            this.groupBox1.Controls.Add(this.cbo_COMM);
            this.groupBox1.Controls.Add(this.lbl_BaudRate);
            this.groupBox1.Controls.Add(this.lbl_COMM);
            this.groupBox1.Controls.Add(this.rdb_TCP);
            this.groupBox1.Controls.Add(this.rdb_COMM);
            this.groupBox1.Controls.Add(this.rdb_USB);
            this.groupBox1.Controls.Add(this.txt_IP);
            this.groupBox1.Controls.Add(this.lbl_Port);
            this.groupBox1.Controls.Add(this.lbl_IP);
            this.groupBox1.Controls.Add(this.lbl_ConnectionPwd);
            this.groupBox1.Controls.Add(this.lbl_DeviceId);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(238, 335);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informação da Conexão";
            // 
            // p2pServerTextBox
            // 
            this.p2pServerTextBox.Location = new System.Drawing.Point(88, 309);
            this.p2pServerTextBox.Name = "p2pServerTextBox";
            this.p2pServerTextBox.Size = new System.Drawing.Size(144, 20);
            this.p2pServerTextBox.TabIndex = 22;
            this.p2pServerTextBox.Text = "s1.weixinac.com";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 313);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Servidor P2P:";
            // 
            // p2pAddrTextBox
            // 
            this.p2pAddrTextBox.Location = new System.Drawing.Point(88, 278);
            this.p2pAddrTextBox.Name = "p2pAddrTextBox";
            this.p2pAddrTextBox.Size = new System.Drawing.Size(144, 20);
            this.p2pAddrTextBox.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 282);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "P2P:";
            // 
            // p2pRadioButton
            // 
            this.p2pRadioButton.AutoSize = true;
            this.p2pRadioButton.Location = new System.Drawing.Point(6, 258);
            this.p2pRadioButton.Name = "p2pRadioButton";
            this.p2pRadioButton.Size = new System.Drawing.Size(45, 17);
            this.p2pRadioButton.TabIndex = 18;
            this.p2pRadioButton.TabStop = true;
            this.p2pRadioButton.Text = "P2P";
            this.p2pRadioButton.UseVisualStyleBackColor = true;
            // 
            // nud_Port
            // 
            this.nud_Port.Location = new System.Drawing.Point(88, 231);
            this.nud_Port.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nud_Port.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_Port.Name = "nud_Port";
            this.nud_Port.Size = new System.Drawing.Size(144, 20);
            this.nud_Port.TabIndex = 14;
            this.nud_Port.Value = new decimal(new int[] {
            5500,
            0,
            0,
            0});
            // 
            // nud_Pwd
            // 
            this.nud_Pwd.Location = new System.Drawing.Point(88, 44);
            this.nud_Pwd.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nud_Pwd.Name = "nud_Pwd";
            this.nud_Pwd.Size = new System.Drawing.Size(120, 20);
            this.nud_Pwd.TabIndex = 3;
            // 
            // nud_DN
            // 
            this.nud_DN.Location = new System.Drawing.Point(88, 15);
            this.nud_DN.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nud_DN.Name = "nud_DN";
            this.nud_DN.Size = new System.Drawing.Size(120, 20);
            this.nud_DN.TabIndex = 1;
            this.nud_DN.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbo_BaudRate
            // 
            this.cbo_BaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_BaudRate.FormattingEnabled = true;
            this.cbo_BaudRate.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cbo_BaudRate.Location = new System.Drawing.Point(88, 150);
            this.cbo_BaudRate.Name = "cbo_BaudRate";
            this.cbo_BaudRate.Size = new System.Drawing.Size(120, 21);
            this.cbo_BaudRate.TabIndex = 9;
            // 
            // cbo_COMM
            // 
            this.cbo_COMM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_COMM.FormattingEnabled = true;
            this.cbo_COMM.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8"});
            this.cbo_COMM.Location = new System.Drawing.Point(88, 121);
            this.cbo_COMM.Name = "cbo_COMM";
            this.cbo_COMM.Size = new System.Drawing.Size(120, 21);
            this.cbo_COMM.TabIndex = 7;
            // 
            // lbl_BaudRate
            // 
            this.lbl_BaudRate.AutoSize = true;
            this.lbl_BaudRate.Location = new System.Drawing.Point(13, 153);
            this.lbl_BaudRate.Name = "lbl_BaudRate";
            this.lbl_BaudRate.Size = new System.Drawing.Size(78, 13);
            this.lbl_BaudRate.TabIndex = 8;
            this.lbl_BaudRate.Text = "Taxa de trans.:";
            this.lbl_BaudRate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_COMM
            // 
            this.lbl_COMM.AutoSize = true;
            this.lbl_COMM.Location = new System.Drawing.Point(13, 125);
            this.lbl_COMM.Name = "lbl_COMM";
            this.lbl_COMM.Size = new System.Drawing.Size(50, 13);
            this.lbl_COMM.TabIndex = 6;
            this.lbl_COMM.Text = "ComPort:";
            this.lbl_COMM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rdb_TCP
            // 
            this.rdb_TCP.AutoSize = true;
            this.rdb_TCP.Location = new System.Drawing.Point(8, 178);
            this.rdb_TCP.Name = "rdb_TCP";
            this.rdb_TCP.Size = new System.Drawing.Size(111, 17);
            this.rdb_TCP.TabIndex = 10;
            this.rdb_TCP.TabStop = true;
            this.rdb_TCP.Text = "Conexão de Rede";
            this.rdb_TCP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdb_TCP.UseVisualStyleBackColor = true;
            // 
            // rdb_COMM
            // 
            this.rdb_COMM.AutoSize = true;
            this.rdb_COMM.Location = new System.Drawing.Point(8, 98);
            this.rdb_COMM.Name = "rdb_COMM";
            this.rdb_COMM.Size = new System.Drawing.Size(96, 17);
            this.rdb_COMM.TabIndex = 5;
            this.rdb_COMM.TabStop = true;
            this.rdb_COMM.Text = "Conexão Serial";
            this.rdb_COMM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdb_COMM.UseVisualStyleBackColor = true;
            // 
            // rdb_USB
            // 
            this.rdb_USB.AutoSize = true;
            this.rdb_USB.Checked = true;
            this.rdb_USB.Location = new System.Drawing.Point(8, 74);
            this.rdb_USB.Name = "rdb_USB";
            this.rdb_USB.Size = new System.Drawing.Size(92, 17);
            this.rdb_USB.TabIndex = 4;
            this.rdb_USB.TabStop = true;
            this.rdb_USB.Text = "Conexão USB";
            this.rdb_USB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdb_USB.UseVisualStyleBackColor = true;
            // 
            // txt_IP
            // 
            this.txt_IP.Location = new System.Drawing.Point(88, 202);
            this.txt_IP.Name = "txt_IP";
            this.txt_IP.Size = new System.Drawing.Size(144, 20);
            this.txt_IP.TabIndex = 12;
            this.txt_IP.Text = "192.168.001.235";
            // 
            // lbl_Port
            // 
            this.lbl_Port.AutoSize = true;
            this.lbl_Port.Location = new System.Drawing.Point(13, 233);
            this.lbl_Port.Name = "lbl_Port";
            this.lbl_Port.Size = new System.Drawing.Size(61, 13);
            this.lbl_Port.TabIndex = 13;
            this.lbl_Port.Text = "Porta UDP:";
            this.lbl_Port.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_IP
            // 
            this.lbl_IP.AutoSize = true;
            this.lbl_IP.Location = new System.Drawing.Point(13, 205);
            this.lbl_IP.Name = "lbl_IP";
            this.lbl_IP.Size = new System.Drawing.Size(20, 13);
            this.lbl_IP.TabIndex = 11;
            this.lbl_IP.Text = "IP:";
            this.lbl_IP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_ConnectionPwd
            // 
            this.lbl_ConnectionPwd.AutoSize = true;
            this.lbl_ConnectionPwd.Location = new System.Drawing.Point(13, 47);
            this.lbl_ConnectionPwd.Name = "lbl_ConnectionPwd";
            this.lbl_ConnectionPwd.Size = new System.Drawing.Size(73, 13);
            this.lbl_ConnectionPwd.TabIndex = 2;
            this.lbl_ConnectionPwd.Text = "Chave Comm:";
            this.lbl_ConnectionPwd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_DeviceId
            // 
            this.lbl_DeviceId.AutoSize = true;
            this.lbl_DeviceId.Location = new System.Drawing.Point(13, 18);
            this.lbl_DeviceId.Name = "lbl_DeviceId";
            this.lbl_DeviceId.Size = new System.Drawing.Size(63, 13);
            this.lbl_DeviceId.TabIndex = 0;
            this.lbl_DeviceId.Text = "ID do Disp.:";
            this.lbl_DeviceId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmConectarFPScanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(599, 360);
            this.Controls.Add(this.btn_RealTimeLog);
            this.Controls.Add(this.group);
            this.Controls.Add(this.btn_AlarmSetting);
            this.Controls.Add(this.btn_CloseDevice);
            this.Controls.Add(this.btn_OpenDevice);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_AttendanceSetting);
            this.Controls.Add(this.btn_AccessSetting);
            this.Name = "frmConectarFPScanner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conectar Scanner";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmConectarFPScanner_FormClosing);
            this.Load += new System.EventHandler(this.frmConectarFPScanner_Load);
            this.group.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Port)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Pwd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_DN)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_RealTimeLog;
        private System.Windows.Forms.GroupBox group;
        private System.Windows.Forms.Button btn_GlogManagement;
        private System.Windows.Forms.Button btn_SlogManagement;
        private System.Windows.Forms.Button btn_AlarmSetting;
        private System.Windows.Forms.Button btn_AttendanceSetting;
        private System.Windows.Forms.Button btn_EnrollManagement;
        private System.Windows.Forms.Button btn_AccessSetting;
        private System.Windows.Forms.Button btn_SystemSetting;
        private System.Windows.Forms.Button btn_CloseDevice;
        private System.Windows.Forms.Button btn_OpenDevice;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox p2pServerTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox p2pAddrTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton p2pRadioButton;
        private System.Windows.Forms.NumericUpDown nud_Port;
        private System.Windows.Forms.NumericUpDown nud_Pwd;
        private System.Windows.Forms.NumericUpDown nud_DN;
        private System.Windows.Forms.ComboBox cbo_BaudRate;
        private System.Windows.Forms.ComboBox cbo_COMM;
        private System.Windows.Forms.Label lbl_BaudRate;
        private System.Windows.Forms.Label lbl_COMM;
        private System.Windows.Forms.RadioButton rdb_TCP;
        private System.Windows.Forms.RadioButton rdb_COMM;
        private System.Windows.Forms.RadioButton rdb_USB;
        private System.Windows.Forms.TextBox txt_IP;
        private System.Windows.Forms.Label lbl_Port;
        private System.Windows.Forms.Label lbl_IP;
        private System.Windows.Forms.Label lbl_ConnectionPwd;
        private System.Windows.Forms.Label lbl_DeviceId;
    }
}