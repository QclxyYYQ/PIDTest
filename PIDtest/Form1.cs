using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PIDtest
{
    public partial class Form1 : Form
    {
        private SerialPort serialPort;
        private Series seriesCur = new Series(), seriesDes = new Series();
        private string unitY = "转每秒";
        private string unitX = "秒";

        enum PackageHead : byte
        {
            Flag_First = 0xFF,
            Flag_Start = 0xF0,
            Flag_Stop = 0x8F,
            Flag_SetPWM = 0x10,
            Flag_SetTar = 0x20,
            Flag_SetP = 0x21,
            Flag_SetI = 0x22,
            Flag_SetD = 0x23,
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

            chart1.ChartAreas[0].Axes[0].Title = unitX;
            chart1.ChartAreas[0].Axes[1].Title = unitY;
            chart1.Series.Add(seriesCur);
            chart1.Series.Add(seriesDes);
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
                        if (BytesHasRecvived == BytesToReceived)
                        {
                            BytesToReceived = 0;
                            isReceiving = false;

                            Thread t = new Thread(new ParameterizedThreadStart(SerialPort_DataProcess));
                            t.IsBackground = true;
                            t.Start(bytesBuffer);
                        }
                    }
                }
                else if (b == (byte)PackageHead.Flag_First)
                {
                    Console.WriteLine("开始接收数据");
                    BytesToReceived = 0;
                    BytesHasRecvived = 0;
                    isReceiving = true;

                }
            }
        }

        private void SerialPort_DataProcess(object bytesReceived)
        {
            byte[] bytes = bytesReceived as byte[];
            //Console.WriteLine("接收数据完成");
            foreach (var b in bytes)
            {
                Console.Write(Convert.ToInt32(b));
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            SerialPort_Init();
            Chart_Init();
            label6.Text = label7.Text = unitY;

            seriesCur.Points.AddY(100);
            seriesCur.Points.AddY(456);
            seriesDes.Points.AddY(123);
            seriesDes.Points.AddY(456);
            seriesCur.Points.AddY(456);
            seriesDes.Points.AddY(456);
        }
    }
}
