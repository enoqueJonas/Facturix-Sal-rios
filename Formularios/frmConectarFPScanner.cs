using System;
using System.Windows.Forms;
using Riss.Devices;
using ZDC2911Demo.Entity;
using Facturix_Salários.IConvert;
using Facturix_Salários.Formularios.Definicoes;

namespace Facturix_Salários.Conexoes
{
    public partial class frmConectarFPScanner : Form
    {

        private Device device;
        private DeviceConnection deviceConnection;
        private DeviceCommEty deviceEty;

        public frmConectarFPScanner()
        {
            InitializeComponent();
        }
        private void frmConectarFPScanner_Load(object sender, EventArgs e)
        {
            cbo_COMM.SelectedIndex = 0;
            cbo_BaudRate.SelectedIndex = 0;
            btn_CloseDevice.Enabled = false;
            SetButtonEnabled(false);
        }

        public void SetButtonEnabled(bool flag)
        {
            foreach (Control c in group.Controls)
            {
                if (c.GetType().Equals(typeof(Button)))
                {
                    c.Enabled = flag;
                }
            }
        }

        #region Device: Open, Close
        private void btn_OpenDevice_Click(object sender, EventArgs e)
        {
            try
            {
                device = new Device();
                device.DN = (int)nud_DN.Value;
                device.Password = nud_Pwd.Value.ToString();
                device.Model = "ZDC2911";
                device.ConnectionModel = 5;

                if (rdb_USB.Checked)
                {
                    device.CommunicationType = CommunicationType.Usb;
                }
                else if (rdb_TCP.Checked)
                {
                    if (string.IsNullOrEmpty(txt_IP.Text.Trim()))
                    {
                        MessageBox.Show("Insira o endereço IP", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_IP.Focus();
                        return;
                    }

                    if (false == ConvertObject.IsCorrenctIP(txt_IP.Text.Trim()))
                    {
                        MessageBox.Show("Endereço IP ilegal", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_IP.Focus();
                        return;
                    }

                    device.IpAddress = txt_IP.Text.Trim();
                    device.IpPort = (int)nud_Port.Value;
                    device.CommunicationType = CommunicationType.Tcp;
                }
                else if (rdb_COMM.Checked)
                {
                    device.SerialPort = Convert.ToInt32(cbo_COMM.SelectedItem.ToString().Replace("COM", string.Empty));
                    device.Baudrate = Convert.ToInt32(cbo_BaudRate.SelectedItem);
                    device.CommunicationType = CommunicationType.Serial;
                }
                else if (p2pRadioButton.Checked)
                {
                    device.CommunicationType = CommunicationType.P2P;
                    device.SerialNumber = p2pAddrTextBox.Text.Trim();  //20130819
                    Riss.Devices.P2pUtils.SetP2pServerIpAddress(p2pServerTextBox.Text.Trim());
                }

                deviceConnection = DeviceConnection.CreateConnection(ref device);

                if (deviceConnection.Open() > 0)
                {
                    deviceEty = new DeviceCommEty();
                    deviceEty.Device = device;
                    deviceEty.DeviceConnection = deviceConnection;
                    btn_CloseDevice.Enabled = true;
                    SetButtonEnabled(true);
                    btn_OpenDevice.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Falha ao conectar dispositivo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_CloseDevice_Click(object sender, EventArgs e)
        {
            deviceConnection.Close();
            btn_CloseDevice.Enabled = false;
            SetButtonEnabled(false);
            btn_OpenDevice.Enabled = true;
            device = null;
            deviceConnection = null;
            deviceEty = null;
        }
        #endregion

        private void btn_RealTimeLog_Click(object sender, EventArgs e)
        {
        }

        private void btn_SystemSetting_Click(object sender, EventArgs e)
        {
            frmDefinicoesDoSistemaFPScanner f = new frmDefinicoesDoSistemaFPScanner(deviceEty);
            f.Show();
        }

        private void btn_EnrollManagement_Click(object sender, EventArgs e)
        {
            frmGestaoDeFuncionarios f = new frmGestaoDeFuncionarios(deviceEty);       
            f.Show();
        }

        private void btn_AlarmSetting_Click(object sender, EventArgs e)
        {
            frmDefinicoesDeAlarme f = new frmDefinicoesDeAlarme();
            f.Show();
        }

        private void btn_CloseDevice_Click_1(object sender, EventArgs e)
        {
            deviceConnection.Close();
            btn_CloseDevice.Enabled = false;
            SetButtonEnabled(false);
            btn_OpenDevice.Enabled = true;
            device = null;
            deviceConnection = null;
            deviceEty = null;
        }

        private void btn_AccessSetting_Click(object sender, EventArgs e)
        {
            frmDefinicoesDeControleDeAcesso f = new frmDefinicoesDeControleDeAcesso(deviceEty);
            f.Show();
        }

        private void btn_GlogManagement_Click(object sender, EventArgs e)
        {
            frmGlog f = new frmGlog(deviceEty);
            f.Show();
        }

        private void btn_SlogManagement_Click(object sender, EventArgs e)
        {
            frmSlog f = new frmSlog(deviceEty);
            f.Show();
        }

        private void btn_AttendanceSetting_Click(object sender, EventArgs e)
        {

        }
    }
}
