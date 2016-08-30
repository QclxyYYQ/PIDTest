using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PIDtest
{
    public partial class Form1 : Form
    {
        private SerialPort serialPort;
        private Series seriesCur = new Series(), seriesDes = new Series(), seriesPwm = new Series();
        private string unitY = "转每秒";
        private string unitX = "秒";

        public delegate void UpdateUIdelegate(UpdateUIwhich which, string text);
        UpdateUIdelegate updateUIdelegate;

        private short desSpeed = 0;

        enum PackageHead : byte
        {
            Flag_First = 0xFF,
            Flag_Start = 0xF0,
            Flag_Stop = 0x8F,
            Flag_SetPWM = 0x10,
            Flag_SetTar = 0x20,
            Flag_SetPID = 0x24,
            Flag_GetSpeed = 0x25,
            Flag_GetPWM = 0x27,
            Flag_GetPID = 0x26
        }
        public enum UpdateUIwhich
        {
            PID,
            SpeedCurrent,
            SpeedDestination,
            PWMCurrent,
            PWMDestination,
        }
        private Boolean isReceiving = false;
        private int BytesToReceived = 0;
        private int BytesHasRecvived = 0;
        private byte[] bytesBuffer;

        public Form1()
        {
            InitializeComponent();
        }
        private void SerialPort_Init()
        {
            //枚举本机串口号
            string[] portNames = SerialPort.GetPortNames();
            foreach (string name in portNames)
            {
                comboBox_serialNumber.Items.Add(name);
            }
            //默认选中最后一个串口号
            comboBox_serialNumber.SelectedIndex = comboBox_serialNumber.Items.Count - 1;

            //枚举波特率
            string[] baudrates =
            {
                "4800",
                "9600",
                "115200",
            };
            foreach (string baud in baudrates)
            {
                comboBox_baud.Items.Add(baud);
            }
            //comboBox_baud.SelectedIndex = 0;
            comboBox_baud.SelectedIndex = comboBox_baud.Items.Count - 1;
        }
        private void Chart_Init()
        {
            chart1.Series.Clear();

            seriesCur.Color = Color.CornflowerBlue;
            seriesCur.LegendText = "当前速度";
            seriesCur.XAxisType = AxisType.Primary;
            seriesCur.XValueType = ChartValueType.Auto;
            seriesCur.ChartType = SeriesChartType.Line;//SeriesChartType.Spline;
            seriesCur.BorderWidth = 2;

            seriesDes.Color = Color.LimeGreen;
            seriesDes.LegendText = "目标速度";
            seriesDes.ChartType = SeriesChartType.Line;
            seriesDes.BorderWidth = 2;

            seriesPwm.LegendText = "当前PWM";
            seriesPwm.ChartType = SeriesChartType.StackedArea;
            seriesPwm.ChartArea = chart1.ChartAreas[1].Name;

            chart1.ChartAreas[0].Axes[0].Title = unitX;
            chart1.ChartAreas[0].Axes[1].Title = unitY;
            chart1.Series.Add(seriesCur);
            chart1.Series.Add(seriesDes);
            chart1.Series.Add(seriesPwm);

        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            if (serialPort == null)
            {
                serialPort = new SerialPort(
                comboBox_serialNumber.SelectedItem.ToString(),
                Convert.ToInt32(comboBox_baud.SelectedItem.ToString()),
                Parity.None, 8, StopBits.One);
                serialPort.DataReceived += SerialPort_DataReceived;
                try
                {
                    serialPort.Open();
                    btn_connect.Text = "断开串口";
                    label_state_serial.Text = "串口状态：已连接";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    serialPort.Dispose();
                    serialPort = null;
                }
            }
            else
            {
                serialPort.Close();
                serialPort.Dispose();
                serialPort = null;
                btn_connect.Text = "连接串口";
                label_state_serial.Text = "串口状态：未连接";
            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int len = serialPort.BytesToRead;
            byte[] buf = new byte[len];
            serialPort.Read(buf, 0, buf.Length);

            foreach (var b in buf)
            {
                if (isReceiving)
                {
                    if (BytesToReceived == 0)
                    {
                        BytesToReceived = Convert.ToInt32(b);
                        bytesBuffer = new byte[BytesToReceived];

                        //Console.WriteLine("待接收的数据包大小：" + BytesToReceived);
                        continue;
                    }
                    else
                    {
                        bytesBuffer[BytesHasRecvived++] = b;
                        if (BytesHasRecvived >= BytesToReceived)
                        {
                            BytesToReceived = 0;
                            isReceiving = false;

                            //Thread t = new Thread(new ParameterizedThreadStart(SerialPort_DataProcess));
                            //t.IsBackground = true;
                            //t.Start(bytesBuffer);
                            SerialPort_DataProcess(bytesBuffer);
                        }
                    }
                }
                else if (b == (byte)PackageHead.Flag_First)
                {
                    //Console.WriteLine("开始接收数据");
                    BytesToReceived = 0;
                    BytesHasRecvived = 0;
                    isReceiving = true;

                }
            }
        }

        private void SerialPort_DataProcess(object bytesReceived)
        {
            byte[] bytes = bytesReceived as byte[];
            //Console.WriteLine(BitConverter.ToString(bytes));
            switch (bytes[0])
            {
                case (byte)PackageHead.Flag_GetSpeed:
                    //Console.WriteLine(BitConverter.ToInt16(bytes.Skip(1).ToArray(), 0));
                    //textBox_curSpd.Text = BitConverter.ToInt16(bytes.Skip(1).ToArray(), 0).ToString();
                    this.BeginInvoke(updateUIdelegate, UpdateUIwhich.SpeedCurrent, BitConverter.ToInt16(bytes.Skip(1).ToArray(), 0).ToString());
                    break;
                case (byte)PackageHead.Flag_GetPID:
                    //Console.WriteLine("P:" + BitConverter.ToSingle(bytes.Skip(1).ToArray(), 0));
                    //Console.WriteLine("I:" + BitConverter.ToSingle(bytes.Skip(5).ToArray(), 0));
                    //Console.WriteLine("D:" + BitConverter.ToSingle(bytes.Skip(9).ToArray(), 0));
                    string t = BitConverter.ToSingle(bytes.Skip(1).ToArray(), 0) + "," + BitConverter.ToSingle(bytes.Skip(5).ToArray(), 0) + "," + BitConverter.ToSingle(bytes.Skip(9).ToArray(), 0);
                    this.BeginInvoke(updateUIdelegate, UpdateUIwhich.PID, t);

                    break;
                case (byte)PackageHead.Flag_GetPWM:

                    //Console.WriteLine("PWM:" + Convert.ToByte(bytes[1]).ToString());
                    this.BeginInvoke(updateUIdelegate, UpdateUIwhich.PWMCurrent, Convert.ToByte(bytes[1]).ToString());

                    break;
            }
        }
        private void SetPID(float p, float i, float d)
        {
            byte[] pB = BitConverter.GetBytes(p);
            byte[] iB = BitConverter.GetBytes(i);
            byte[] dB = BitConverter.GetBytes(d);
            byte[] buf = new byte[3 + 4 * 3];
            buf[0] = (byte)PackageHead.Flag_First;
            buf[1] = 13;//剩下的数据包部分的长度
            buf[2] = (byte)PackageHead.Flag_SetPID;
            Array.Copy(pB, 0, buf, 3, 4);
            Array.Copy(iB, 0, buf, 7, 4);
            Array.Copy(dB, 0, buf, 11, 4);

            Console.WriteLine(BitConverter.ToString(buf).Replace("-", " "));
            serialPort.Write(buf, 0, buf.Length);
        }
        private void SetSpeed(short speed)
        {
            byte[] speedB = BitConverter.GetBytes(speed);
            byte[] buf = new byte[3 + 2];
            buf[0] = (byte)PackageHead.Flag_First;
            buf[1] = 3;//剩下的数据包部分的长度
            buf[2] = (byte)PackageHead.Flag_SetTar;
            Array.Copy(speedB, 0, buf, 3, speedB.Length);

            Console.WriteLine(BitConverter.ToString(buf).Replace("-", " "));
            serialPort.Write(buf, 0, buf.Length);
        }
        private void SetPWM(byte pwm)
        {
            byte[] buf = new byte[3 + 1];
            buf[0] = (byte)PackageHead.Flag_First;
            buf[1] = 2;//剩下的数据包部分的长度
            buf[2] = (byte)PackageHead.Flag_SetPWM;
            buf[3] = pwm;
            //Array.Copy(speedB, 0, buf, 3, speedB.Length);

            Console.WriteLine(BitConverter.ToString(buf).Replace("-", " "));
            serialPort.Write(buf, 0, buf.Length);
        }
        private void button_readPID_Click(object sender, EventArgs e)
        {
            byte[] buf = new byte[3];
            buf[0] = (byte)PackageHead.Flag_First;
            buf[1] = 1;//剩下的数据包部分的长度
            buf[2] = (byte)PackageHead.Flag_GetPID;
            serialPort.Write(buf, 0, buf.Length);
        }

        private void button_writePID_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox_P.Text, @"^[0-9]+\.[0-9]{2}$"))
            {
                if (Regex.IsMatch(textBox_I.Text, @"^[0-9]+\.[0-9]{2}$"))
                {
                    if (Regex.IsMatch(textBox_D.Text, @"^[0-9]+\.[0-9]{2}$"))
                    {
                        SetPID(Convert.ToSingle(textBox_P.Text), Convert.ToSingle(textBox_I.Text), Convert.ToSingle(textBox_D.Text));
                        return;
                    }
                }
            }
            MessageBox.Show("PID参数输入有误，请保持两位小数的格式");
        }

        private void button_lock_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox_des.Text, @"^[0-9]\d*$"))
            {
                Console.WriteLine("OK");
                desSpeed = Convert.ToInt16(textBox_des.Text);
                SetSpeed(desSpeed);
                label_state.Text = "速度已锁定";

            }
            else
            {
                MessageBox.Show("目标速度参数输入有误。应只含正整数");
            }
        }

        private void button_pwm_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox_DESPWM.Text, @"^[0-9]\d*$"))
            {
                short p = Convert.ToInt16(textBox_DESPWM.Text);
                if (p <= 100 && p >= 0)
                {
                    Console.WriteLine("OK");
                    //(Convert.ToInt16(textBox_des));
                    
                    SetPWM(Convert.ToByte(p));
                    label_state.Text = "PWM已锁定";
                    return;
                }
            }

            MessageBox.Show("目标PWM参数输入有误。应只含整数且范围0~100");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            updateUIdelegate = new UpdateUIdelegate(updateUI);

            SerialPort_Init();
            Chart_Init();
            //label6.Text = label7.Text = unitY;


            //seriesCur.Points.AddY(100);
            //seriesCur.Points.AddY(456);
            //seriesDes.Points.AddY(123);
            //seriesDes.Points.AddY(456);
            //seriesCur.Points.AddY(456);
            //seriesDes.Points.AddY(456);
        }

        private void button_reRecord_Click(object sender, EventArgs e)
        {
            seriesCur.Points.Clear();
            seriesDes.Points.Clear();
            seriesPwm.Points.Clear();
        }

        private void updateUI(UpdateUIwhich which, string text)
        {
            switch (which)
            {
                case UpdateUIwhich.SpeedCurrent:
                    textBox_curSpd.Text = text;
                    seriesCur.Points.AddY(Convert.ToInt32(text));
                    seriesDes.Points.AddY(desSpeed);
                    break;
                case UpdateUIwhich.SpeedDestination:

                    break;
                case UpdateUIwhich.PWMCurrent:
                    textBox_curPWM.Text = text;
                    seriesPwm.Points.AddY(Convert.ToInt32(textBox_curPWM.Text));
                    break;
                case UpdateUIwhich.PWMDestination:
                    break;
                case UpdateUIwhich.PID:
                    string[] t = text.Split(',');
                    textBox_P.Text = t[0];
                    textBox_I.Text = t[1];
                    textBox_D.Text = t[2];
                    break;
            }
        }
    }
}
