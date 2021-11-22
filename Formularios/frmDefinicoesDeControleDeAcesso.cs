using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Riss.Devices;
using ZDC2911Demo.Entity;

namespace Facturix_Salários.Formularios.Definicoes
{
    public partial class frmDefinicoesDeControleDeAcesso : Form
    {
        private Device device;
        private DeviceConnection deviceConnection;
        public frmDefinicoesDeControleDeAcesso(DeviceCommEty deviceEty)
        {
            InitializeComponent();
            device = deviceEty.Device;
            deviceConnection = deviceEty.DeviceConnection;

            lockComboBox.SelectedIndex = 0;
        }

        private void getAccessControlSettingsLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            object extraProperty = new object();
            object extraData = new object();
            extraData = Global.DeviceBusy;

            try
            {
                bool result = deviceConnection.SetProperty(DeviceProperty.Enable, extraProperty, device, extraData);
                extraData = Zd2911Utils.DeviceAccessControlSettings;
                result = deviceConnection.GetProperty(DeviceProperty.AccessControlSettings, extraProperty, ref device, ref extraData);
                if (result)
                {
                    byte[] data = Encoding.Unicode.GetBytes((string)extraData);
                    WiegandItem.SelectedIndex = data[0];
                    HijackOpenItem.SelectedIndex = data[1];
                    HijackAlarmItem.SelectedIndex = data[2];
                    AntiPassbackItem.SelectedIndex = data[3];

                    FireAlarmItem.SelectedIndex = data[4];
                    HijackFpNoItem.SelectedIndex = data[5];
                    AntiHijackEnableItem.SelectedIndex = data[6];
                    SecondLockItem.SelectedIndex = data[7];

                    StringBuilder pwd = new StringBuilder();
                    for (int i = 0; i < Zd2911Utils.PasswordLength; i++)
                    {
                        pwd.Append((char)data[8 + i]);
                    }
                    HijackPasswordItem.Text = pwd.ToString();

                    OpenDoor1TimeItem.Value = data[16];
                    CheckDoor1StatusItem.SelectedIndex = data[17];
                    OpenDoor1OvertimeAlarmItem.Value = data[18];
                    IllegalOpenDoor1TimeItem.Value = data[19];

                    OpenDoor2TimeItem.Value = data[20];
                    CheckDoor2StatusItem.SelectedIndex = data[21];
                    OpenDoor2OvertimeAlarmItem.Value = data[22];
                    IllegalOpenDoor2TimeItem.Value = data[23];

                    MultOpenEnableItem.SelectedIndex = data[24];
                    LinkageOpenItem.SelectedIndex = data[25];
                    LinkageAlarmItem.SelectedIndex = data[26];
                    AutoUnlock1PassGroupItem.Value = data[27];

                    AutoUnlock2PassGroupItem.Value = data[28];
                    EnableRealyAlarmItem.SelectedIndex = data[29];
                }
                else
                {
                    MessageBox.Show("Get Access control Settings Fail.", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                extraData = Global.DeviceIdle;
                deviceConnection.SetProperty(DeviceProperty.Enable, extraProperty, device, extraData);
            }
        }

        private void setAccessControlSettingsLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            object extraProperty = new object();
            object extraData = new object();
            extraData = Global.DeviceBusy;
            try
            {
                bool result = deviceConnection.SetProperty(DeviceProperty.Enable, extraProperty, device, extraData);

                byte[] data = new byte[Zd2911Utils.AccessControlSettingsSize];
                data[0] = (byte)WiegandItem.SelectedIndex;
                data[1] = (byte)HijackOpenItem.SelectedIndex;
                data[2] = (byte)HijackAlarmItem.SelectedIndex;
                data[3] = (byte)AntiPassbackItem.SelectedIndex;

                data[4] = (byte)FireAlarmItem.SelectedIndex;
                data[5] = (byte)HijackFpNoItem.SelectedIndex;
                data[6] = (byte)AntiHijackEnableItem.SelectedIndex;
                data[7] = (byte)SecondLockItem.SelectedIndex;

                string pwd = HijackPasswordItem.Text;
                for (int i = 0; i < Zd2911Utils.PasswordLength; i++)
                {
                    if (i < (pwd.Length))
                        data[8 + i] = (byte)pwd[i];
                    else
                        data[8 + i] = 0;
                }

                data[16] = (byte)OpenDoor1TimeItem.Value;
                data[17] = (byte)CheckDoor1StatusItem.SelectedIndex;
                data[18] = (byte)OpenDoor1OvertimeAlarmItem.Value;
                data[19] = (byte)IllegalOpenDoor1TimeItem.Value;

                data[20] = (byte)OpenDoor2TimeItem.Value;
                data[21] = (byte)CheckDoor2StatusItem.SelectedIndex;
                data[22] = (byte)OpenDoor2OvertimeAlarmItem.Value;
                data[23] = (byte)IllegalOpenDoor2TimeItem.Value;

                data[24] = (byte)MultOpenEnableItem.SelectedIndex;
                data[25] = (byte)LinkageOpenItem.SelectedIndex;
                data[26] = (byte)LinkageAlarmItem.SelectedIndex;
                data[27] = (byte)AutoUnlock1PassGroupItem.Value;

                data[28] = (byte)AutoUnlock2PassGroupItem.Value;
                data[29] = (byte)EnableRealyAlarmItem.SelectedIndex;
                data[30] = 3;

                extraData = Encoding.Unicode.GetString(data);
                extraProperty = Zd2911Utils.DeviceAccessControlSettings;

                result = deviceConnection.SetProperty(DeviceProperty.AccessControlSettings, extraProperty, device, extraData);

                if (result)
                {
                    MessageBox.Show("Set Access control Success", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Set Access control Fail.", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                extraData = Global.DeviceIdle;
                deviceConnection.SetProperty(DeviceProperty.Enable, extraProperty, device, extraData);
            }
        }

        private void lockOpenButton_Click(object sender, EventArgs e)
        {
            try
            {
                object extraProperty = new object();
                object extraData = new object();
                byte[] data = new byte[8];
                UInt32 paramIndex = Zd2911Utils.DeviceParamLock1Status;
                if (lockComboBox.SelectedIndex == 1)
                    paramIndex = Zd2911Utils.DeviceParamLock2Status;

                Array.Copy(BitConverter.GetBytes(paramIndex), 0, data, 0, 4);
                Array.Copy(BitConverter.GetBytes((UInt32)1), 0, data, 4, 4);    //1 as Open
                extraData = data;
                bool result = deviceConnection.SetProperty(DeviceProperty.SysParam, extraProperty, device, extraData);
                if (result)
                {
                    MessageBox.Show("Open Success", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Open Fail", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lockAutoButton_Click(object sender, EventArgs e)
        {
            try
            {
                object extraProperty = new object();
                object extraData = new object();
                byte[] data = new byte[8];
                UInt32 paramIndex = Zd2911Utils.DeviceParamLock1Status;
                if (lockComboBox.SelectedIndex == 1)
                    paramIndex = Zd2911Utils.DeviceParamLock2Status;

                Array.Copy(BitConverter.GetBytes(paramIndex), 0, data, 0, 4);
                Array.Copy(BitConverter.GetBytes((UInt32)2), 0, data, 4, 4);    //2 as Auto
                extraData = data;
                bool result = deviceConnection.SetProperty(DeviceProperty.SysParam, extraProperty, device, extraData);
                if (result)
                {
                    MessageBox.Show("set Auto mode Success", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("set Auto mode Fail", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lockKeepOpenButton_Click(object sender, EventArgs e)
        {

            try
            {
                object extraProperty = new object();
                object extraData = new object();
                byte[] data = new byte[8];

                UInt32 paramIndex = Zd2911Utils.DeviceParamLock1Status;
                if (lockComboBox.SelectedIndex == 1)
                    paramIndex = Zd2911Utils.DeviceParamLock2Status;

                Array.Copy(BitConverter.GetBytes(paramIndex), 0, data, 0, 4);
                Array.Copy(BitConverter.GetBytes((UInt32)3), 0, data, 4, 4);        //3 as keep open
                extraData = data;
                bool result = deviceConnection.SetProperty(DeviceProperty.SysParam, extraProperty, device, extraData);
                if (result)
                {
                    MessageBox.Show("Keep open Success", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Keep open Fail", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lockKeepCloseButton_Click(object sender, EventArgs e)
        {

            try
            {
                object extraProperty = new object();
                object extraData = new object();
                byte[] data = new byte[8];
                UInt32 paramIndex = Zd2911Utils.DeviceParamLock1Status;
                if (lockComboBox.SelectedIndex == 1)
                    paramIndex = Zd2911Utils.DeviceParamLock2Status;

                Array.Copy(BitConverter.GetBytes(paramIndex), 0, data, 0, 4);
                Array.Copy(BitConverter.GetBytes((UInt32)4), 0, data, 4, 4);        //4 as keep close
                extraData = data;
                bool result = deviceConnection.SetProperty(DeviceProperty.SysParam, extraProperty, device, extraData);
                if (result)
                {
                    MessageBox.Show("Keep Close Success", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Keep Close Fail", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lockGetStatusButton_Click(object sender, EventArgs e)
        {
            try
            {
                object extraProperty = new object();
                object extraData = new object();
                UInt32 paramIndex = Zd2911Utils.DeviceParamLock1Status;
                if (lockComboBox.SelectedIndex == 1)
                    paramIndex = Zd2911Utils.DeviceParamLock2Status;

                extraData = BitConverter.GetBytes(paramIndex);
                bool result = deviceConnection.GetProperty(DeviceProperty.SysParam, extraProperty, ref device, ref extraData);

                if (result)
                {
                    UInt32 paramValue = BitConverter.ToUInt32((byte[])extraData, 0);
                    MessageBox.Show(string.Format("Door sensor = {0}", paramValue), "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Get lock status Fail", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lockGetEventButton_Click(object sender, EventArgs e)
        {
            try
            {
                object extraProperty = new object();
                object extraData = new object();
                UInt32 paramIndex = Zd2911Utils.DeviceParamLock1Event;
                if (lockComboBox.SelectedIndex == 1)
                    paramIndex = Zd2911Utils.DeviceParamLock2Event;

                extraData = BitConverter.GetBytes(paramIndex);
                bool result = deviceConnection.GetProperty(DeviceProperty.SysParam, extraProperty, ref device, ref extraData);

                if (result)
                {
                    UInt32 paramValue = BitConverter.ToUInt32((byte[])extraData, 0);
                    MessageBox.Show(string.Format("Event = {0}", paramValue), "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Get event Fail", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void soundVoiceButton_Click(object sender, EventArgs e)
        {
            try
            {
                int paramIndex = 2;

                object extraProperty = new object();
                object extraData = new object();
                byte[] data = new byte[8];
                Array.Copy(BitConverter.GetBytes(paramIndex), 0, data, 0, 4);
                Array.Copy(BitConverter.GetBytes(soundListComboBox.SelectedIndex), 0, data, 4, 4);
                extraData = data;
                bool result = deviceConnection.SetProperty(DeviceProperty.PowerOff, extraProperty, device, extraData);
                if (result)
                {
                    MessageBox.Show("Voice Success", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Voice Fail", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmDefinicoesDeControleDeAcesso_Load(object sender, EventArgs e)
        {
            InitPassSegmentPanel();
            InitPassGroupPanel();
            InitPassZonePanel();
            InitMultOpenGroupPanel();
        }

        private DateTime InitDate = new DateTime(2000, 1, 1);
        private void InitPassSegmentPanel()
        {
            passSegmentPanel.Controls.Clear();
            for (int i = 0; i < Zd2911Utils.PassItemCount; i++)
            {
                Label label = new Label();
                label.AutoSize = false;
                label.Size = new Size(32, 21);
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Text = (i).ToString();
                passSegmentPanel.Controls.Add(label);

                DateTimePicker startTime = new DateTimePicker();
                startTime.Size = new Size(75, 21);
                startTime.CustomFormat = "HH:mm";
                startTime.Format = DateTimePickerFormat.Custom;
                startTime.Value = InitDate;
                startTime.ShowUpDown = true;
                startTime.Tag = i * 2;
                if (i == 0 || i == (Zd2911Utils.PassItemCount - 1))
                    startTime.Enabled = false;
                passSegmentPanel.Controls.Add(startTime);

                DateTimePicker endTime = new DateTimePicker();
                endTime.Size = new Size(75, 21);
                endTime.CustomFormat = "HH:mm";
                endTime.Format = DateTimePickerFormat.Custom;
                endTime.Value = InitDate;
                endTime.ShowUpDown = true;
                endTime.Tag = i * 2 + 1;
                if (i == 0 || i == (Zd2911Utils.PassItemCount - 1))
                    endTime.Enabled = false;
                passSegmentPanel.Controls.Add(endTime);
            }
        }

        private void InitPassGroupPanel()
        {
            passGroupPanel.Controls.Clear();
            for (int i = 0; i < Zd2911Utils.PassItemCount; i++)
            {
                Label label = new Label();
                label.AutoSize = false;
                label.Size = new Size(32, 21);
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Text = (i).ToString();
                passGroupPanel.Controls.Add(label);

                for (int j = 0; j < 10; j++)
                {
                    NumericUpDown segment = new NumericUpDown();
                    segment.Size = new Size(40, 20);
                    segment.Tag = i * 10 + j;
                    segment.Maximum = 31;
                    segment.Minimum = 0;
                    segment.Value = 0;
                    if (i == 0 || i == (Zd2911Utils.PassItemCount - 1))
                    {
                        segment.Enabled = false;
                    }
                    passGroupPanel.Controls.Add(segment);
                }
            }
        }

        private void InitPassZonePanel()
        {
            passZonePanel.Controls.Clear();
            for (int i = 0; i < Zd2911Utils.PassItemCount; i++)
            {
                Label label = new Label();
                label.AutoSize = false;
                label.Size = new Size(32, 21);
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Text = (i).ToString();
                passZonePanel.Controls.Add(label);

                for (int j = 0; j < 7; j++)
                {
                    NumericUpDown group = new NumericUpDown();
                    group.Size = new Size(60, 20);
                    group.Tag = i * 7 + j;
                    group.Maximum = 31;
                    group.Minimum = 0;
                    group.Value = 0;
                    if (i == 0 || i == (Zd2911Utils.PassItemCount - 1))
                    {
                        group.Enabled = false;
                    }
                    passZonePanel.Controls.Add(group);
                }
            }
        }

        private void InitMultOpenGroupPanel()
        {
            multOpenGroupPanel.Controls.Clear();
            for (int i = 0; i < Zd2911Utils.MultOpenGroupItemCount; i++)
            {
                Label label = new Label();
                label.AutoSize = false;
                label.Size = new Size(32, 21);
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Text = (i).ToString();
                multOpenGroupPanel.Controls.Add(label);

                NumericUpDown group = new NumericUpDown();
                group.Size = new Size(80, 20);
                group.Tag = i;
                group.Maximum = 999;
                group.Minimum = 0;
                group.Value = 0;

                multOpenGroupPanel.Controls.Add(group);
            }
        }

    }
}
