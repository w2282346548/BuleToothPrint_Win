using InTheHand.Net;
using InTheHand.Net.Ports;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using InTheHand.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuleToothPrint_Win
{
    public partial class Form1 : Form
    {
        BluetoothRadio radio = null;//蓝牙适配器
        BluetoothAddress sendAddress = null;//发送目的地址
        private BluetoothClient blueClient;
        public Form1()
        {
            InitializeComponent();

        }

        private void btnQueryBluetooth_Click(object sender, EventArgs e)
        {
            btnQueryBluetooth.Enabled = false;
            radio = BluetoothRadio.PrimaryRadio;//获取当前PC的蓝牙适配器
            if (radio == null)//检查该电脑蓝牙是否可用
            {
                MessageBox.Show("Bluetooth is not available for this device！", "Tip", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnQueryBluetooth.Enabled = true;
                return;
            }
            else {
                blueClient = new BluetoothClient();
                SelectBluetoothDeviceDialog dialog = new SelectBluetoothDeviceDialog();
                dialog.ShowRemembered = true;//显示已经记住的蓝牙设备
                dialog.ShowAuthenticated = true;//显示认证过的蓝牙设备
                dialog.ShowUnknown = true;//显示位置蓝牙设备

                if (dialog.ShowDialog() == DialogResult.OK) {
                    sendAddress = dialog.SelectedDevice.DeviceAddress;//获取选择的远程蓝牙地址
                }
                if (sendAddress==null)
                {
                    MessageBox.Show("Did not select the Bluetooth device！", "Tip", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnQueryBluetooth.Enabled = true;
                    return;
                }
                else
                {
                    string pin = "1234";//默认的蓝牙pin值
                    if (Connect(sendAddress, pin))
                    {
                        MessageBox.Show("Connect Bluetooth successfully");
                        btnPrint.Enabled = true;
                        btnPrintTestPage.Enabled = true;
                        btnLogout.Enabled = true;
                        btnOneDimensionalCode.Enabled = true;
                        btnPrintQRCode.Enabled = true;
                    }
                    else
                    {
                        btnQueryBluetooth.Enabled = true;
                        MessageBox.Show("Failed to connect to Bluetooth");
                    }
                }
            }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            btnPrint.Enabled = false;
            string msg = txtMsg.Text.ToString();
            if (string.IsNullOrEmpty(msg))
            {
                MessageBox.Show("Please enter a message");
                btnPrint.Enabled = true;
                return;
            }
            else
            {
                int error;
                if (PrintString(msg+"\n", out error))
                {
                    MessageBox.Show("Message has been printed");
                    btnPrint.Enabled = true;
                }
                else {
                    MessageBox.Show("Error printing：" + "Bluetooth is not connected");
                    btnPrint.Enabled = true;
                }
            }
        }


        private void btnPrintTestPage_Click(object sender, EventArgs e)
        {
            btnPrintTestPage.Enabled = false;
            string msg = "";
            int error;
            byte[] cmd = new byte[3];
            cmd[0] = 0x1b;
            cmd[1] = 0x21;
            cmd[2] |= 0x10;
            PrintByte(cmd);// //倍宽、倍高模式
            msg = "Congratulations！\n";
            PrintString(msg + "\n", out error);
            cmd[2] &= 0xEF; //取消倍高、倍宽模式
            PrintByte(cmd);
            msg = "  You have successfully connected our Bluetooth printer！\n\n"
                    + "  The company is a professional engaged in R & D, production, sales of commercial paper printers and bar code scanning equipment in one of the high-tech enterprises.\n\n";
            // + "  欢迎您登录我们的网站来查看我们公司的详细信息:\n"+"     http://www.zjiang.com.\n\n";
            PrintString(msg + "\n", out error);

        }



        private void btnOneDimensionalCode_Click(object sender, EventArgs e)
        {
            btnOneDimensionalCode.Enabled = false;
            byte[] cmd = { 0x1D, 0x6B, 0x41, 0x0C, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x31, 0x32, 0x38 };
            try
            {
                PrintByte(cmd);
                MessageBox.Show("Successfully!");
                btnOneDimensionalCode.Enabled = true;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message.ToString());
                btnOneDimensionalCode.Enabled = true;
            }
        }

        private void btnPrintQRCode_Click(object sender, EventArgs e)
        {
            btnPrintQRCode.Enabled = false;
            byte[] cmd = { 0x1b, 0x5a, 0x01, 0x03, 0x08, 0x09, 0x00, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x0A }; //二维码指令
            try
            {
                PrintByte(cmd);
                MessageBox.Show("Successfully!");
                btnPrintQRCode.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                btnPrintQRCode.Enabled = true;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (blueClient != null)
            {
                blueClient.Close();
                MessageBox.Show("The connection has been closed");
                btnQueryBluetooth.Enabled = true;
                btnLogout.Enabled = false;
                btnOneDimensionalCode.Enabled = false;
                btnPrintQRCode.Enabled = false;
                btnPrint.Enabled = false;
                btnPrintTestPage.Enabled = false;
            }
        }

        /// <summary>
        /// 连接蓝牙
        /// </summary>
        /// <param name="address">蓝牙设备地址</param>
        /// <param name="pwd">连接密码</param>
        /// <returns></returns>
        public bool Connect(BluetoothAddress address, string pwd)
        {
            try
            {
                blueClient.SetPin(address, pwd);
                blueClient.Connect(address, BluetoothService.SerialPort);
 
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }

        /// <summary>
        /// 打印文本
        /// </summary>
        /// <param name="mess"></param>
        /// <returns></returns>
        public bool PrintString(string mess, out int error)
        {
            error = 0;
            try
            {
                if (blueClient.Connected)
                {
                    byte[] OutBuffer;//数据
                    int BufferSize;
                    Encoding targetEncoding;
                    //将[UNICODE编码]转换为[GB码]，仅使用于简体中文版mobile
                    targetEncoding = Encoding.GetEncoding(0);    //得到简体中文字码页的编码方式，因为是简体中文操作系统，参数用0就可以，用936也行。
                    BufferSize = targetEncoding.GetByteCount(mess); //计算对指定字符数组中的所有字符进行编码所产生的字节数           
                    OutBuffer = new byte[BufferSize];
                    OutBuffer = targetEncoding.GetBytes(mess);       //将指定字符数组中的所有字符编码为一个字节序列,完成后outbufer里面即为简体中文编码
                    blueClient.Client.Send(OutBuffer);

                    return true;
                }
                else
                {
                    error = (int)BluetoothErrorEnum.NotConnected;
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return false;
            }
        }

        public void PrintByte(byte[] OutBuffer) {
            blueClient.Client.Send(OutBuffer);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
