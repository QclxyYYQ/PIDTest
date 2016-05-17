namespace PIDtest
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.Label label;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.GroupBox groupBox3;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label14;
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox_baud = new System.Windows.Forms.ComboBox();
            this.label_state_serial = new System.Windows.Forms.Label();
            this.comboBox_serialNumber = new System.Windows.Forms.ComboBox();
            this.btn_connect = new System.Windows.Forms.Button();
            this.textBox_P = new System.Windows.Forms.TextBox();
            this.textBox_I = new System.Windows.Forms.TextBox();
            this.textBox_D = new System.Windows.Forms.TextBox();
            this.button_readPID = new System.Windows.Forms.Button();
            this.button_writePID = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_des = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button_lock = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.button_pwm = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button_export = new System.Windows.Forms.Button();
            this.button_reRecord = new System.Windows.Forms.Button();
            this.button_record = new System.Windows.Forms.Button();
            label = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            groupBox3 = new System.Windows.Forms.GroupBox();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chart1);
            this.groupBox1.Location = new System.Drawing.Point(253, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(501, 415);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "电机转速";
            // 
            // chart1
            // 
            chartArea1.CursorX.IsUserEnabled = true;
            chartArea1.CursorX.IsUserSelectionEnabled = true;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            legend1.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(6, 13);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(489, 396);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox_baud);
            this.groupBox2.Controls.Add(label);
            this.groupBox2.Controls.Add(label1);
            this.groupBox2.Controls.Add(this.label_state_serial);
            this.groupBox2.Controls.Add(this.comboBox_serialNumber);
            this.groupBox2.Controls.Add(this.btn_connect);
            this.groupBox2.Location = new System.Drawing.Point(12, 39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(235, 59);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "串口通讯";
            // 
            // comboBox_baud
            // 
            this.comboBox_baud.FormattingEnabled = true;
            this.comboBox_baud.Location = new System.Drawing.Point(70, 35);
            this.comboBox_baud.Name = "comboBox_baud";
            this.comboBox_baud.Size = new System.Drawing.Size(58, 20);
            this.comboBox_baud.TabIndex = 21;
            // 
            // label
            // 
            label.AutoSize = true;
            label.ForeColor = System.Drawing.SystemColors.ControlText;
            label.Location = new System.Drawing.Point(11, 38);
            label.Name = "label";
            label.Size = new System.Drawing.Size(53, 12);
            label.TabIndex = 20;
            label.Text = "波特率：";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(11, 16);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(53, 12);
            label1.TabIndex = 11;
            label1.Text = "串口号：";
            // 
            // label_state_serial
            // 
            this.label_state_serial.AutoSize = true;
            this.label_state_serial.Location = new System.Drawing.Point(131, 39);
            this.label_state_serial.Name = "label_state_serial";
            this.label_state_serial.Size = new System.Drawing.Size(101, 12);
            this.label_state_serial.TabIndex = 12;
            this.label_state_serial.Text = "串口状态：已断开";
            // 
            // comboBox_serialNumber
            // 
            this.comboBox_serialNumber.FormattingEnabled = true;
            this.comboBox_serialNumber.Location = new System.Drawing.Point(70, 13);
            this.comboBox_serialNumber.Name = "comboBox_serialNumber";
            this.comboBox_serialNumber.Size = new System.Drawing.Size(58, 20);
            this.comboBox_serialNumber.TabIndex = 10;
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(148, 11);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(68, 23);
            this.btn_connect.TabIndex = 0;
            this.btn_connect.Text = "连接串口";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(this.button_writePID);
            groupBox3.Controls.Add(this.button_readPID);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(this.textBox_D);
            groupBox3.Controls.Add(this.textBox_I);
            groupBox3.Controls.Add(this.textBox_P);
            groupBox3.Location = new System.Drawing.Point(12, 104);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new System.Drawing.Size(235, 100);
            groupBox3.TabIndex = 20;
            groupBox3.TabStop = false;
            groupBox3.Text = "PID设置";
            // 
            // textBox_P
            // 
            this.textBox_P.Location = new System.Drawing.Point(70, 20);
            this.textBox_P.Name = "textBox_P";
            this.textBox_P.Size = new System.Drawing.Size(58, 21);
            this.textBox_P.TabIndex = 0;
            // 
            // textBox_I
            // 
            this.textBox_I.Location = new System.Drawing.Point(70, 47);
            this.textBox_I.Name = "textBox_I";
            this.textBox_I.Size = new System.Drawing.Size(58, 21);
            this.textBox_I.TabIndex = 1;
            // 
            // textBox_D
            // 
            this.textBox_D.Location = new System.Drawing.Point(70, 73);
            this.textBox_D.Name = "textBox_D";
            this.textBox_D.Size = new System.Drawing.Size(58, 21);
            this.textBox_D.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(47, 23);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(17, 12);
            label2.TabIndex = 3;
            label2.Text = "P:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(47, 50);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(17, 12);
            label3.TabIndex = 4;
            label3.Text = "I:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(47, 76);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(17, 12);
            label4.TabIndex = 5;
            label4.Text = "D:";
            // 
            // button_readPID
            // 
            this.button_readPID.Location = new System.Drawing.Point(134, 18);
            this.button_readPID.Name = "button_readPID";
            this.button_readPID.Size = new System.Drawing.Size(92, 23);
            this.button_readPID.TabIndex = 6;
            this.button_readPID.Text = "读出PID参数";
            this.button_readPID.UseVisualStyleBackColor = true;
            // 
            // button_writePID
            // 
            this.button_writePID.Location = new System.Drawing.Point(133, 71);
            this.button_writePID.Name = "button_writePID";
            this.button_writePID.Size = new System.Drawing.Size(92, 23);
            this.button_writePID.TabIndex = 7;
            this.button_writePID.Text = "写入PID参数";
            this.button_writePID.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.button_pwm);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.textBox3);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.textBox2);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.button_lock);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.textBox1);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.textBox_des);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(12, 210);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(235, 155);
            this.groupBox4.TabIndex = 21;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "速度控制";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "目标速度：";
            // 
            // textBox_des
            // 
            this.textBox_des.Location = new System.Drawing.Point(70, 77);
            this.textBox_des.Name = "textBox_des";
            this.textBox_des.Size = new System.Drawing.Size(58, 21);
            this.textBox_des.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(131, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "r/s";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(131, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 12);
            this.label7.TabIndex = 5;
            this.label7.Text = "r/s";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(70, 50);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(58, 21);
            this.textBox1.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 3;
            this.label8.Text = "当前速度：";
            // 
            // button_lock
            // 
            this.button_lock.Location = new System.Drawing.Point(160, 50);
            this.button_lock.Name = "button_lock";
            this.button_lock.Size = new System.Drawing.Size(66, 48);
            this.button_lock.TabIndex = 6;
            this.button_lock.Text = "锁定目标速度";
            this.button_lock.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(70, 104);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(58, 21);
            this.textBox2.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 107);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 7;
            this.label9.Text = "当前PWM：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(131, 107);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(11, 12);
            this.label10.TabIndex = 9;
            this.label10.Text = "%";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(131, 129);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(11, 12);
            this.label11.TabIndex = 12;
            this.label11.Text = "%";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(70, 126);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(58, 21);
            this.textBox3.TabIndex = 11;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 129);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 12);
            this.label12.TabIndex = 10;
            this.label12.Text = "目标PWM：";
            // 
            // button_pwm
            // 
            this.button_pwm.Location = new System.Drawing.Point(160, 104);
            this.button_pwm.Name = "button_pwm";
            this.button_pwm.Size = new System.Drawing.Size(65, 43);
            this.button_pwm.TabIndex = 13;
            this.button_pwm.Text = "设定PWM";
            this.button_pwm.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(64, 17);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(106, 21);
            this.label13.TabIndex = 14;
            this.label13.Text = "当前控制状态";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new System.Drawing.Font("幼圆", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            label14.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            label14.Location = new System.Drawing.Point(54, 12);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(149, 20);
            label14.TabIndex = 22;
            label14.Text = "电机转速控制器";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button_record);
            this.groupBox5.Controls.Add(this.button_reRecord);
            this.groupBox5.Controls.Add(this.button_export);
            this.groupBox5.Location = new System.Drawing.Point(12, 371);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(235, 56);
            this.groupBox5.TabIndex = 23;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "数据记录";
            // 
            // button_export
            // 
            this.button_export.Location = new System.Drawing.Point(139, 20);
            this.button_export.Name = "button_export";
            this.button_export.Size = new System.Drawing.Size(90, 23);
            this.button_export.TabIndex = 0;
            this.button_export.Text = "导出至Excel";
            this.button_export.UseVisualStyleBackColor = true;
            // 
            // button_reRecord
            // 
            this.button_reRecord.Location = new System.Drawing.Point(68, 20);
            this.button_reRecord.Name = "button_reRecord";
            this.button_reRecord.Size = new System.Drawing.Size(65, 23);
            this.button_reRecord.TabIndex = 1;
            this.button_reRecord.Text = "重新记录";
            this.button_reRecord.UseVisualStyleBackColor = true;
            // 
            // button_record
            // 
            this.button_record.Location = new System.Drawing.Point(8, 20);
            this.button_record.Name = "button_record";
            this.button_record.Size = new System.Drawing.Size(54, 23);
            this.button_record.TabIndex = 2;
            this.button_record.Text = "开始";
            this.button_record.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 439);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(label14);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "电机转速控制器    杨宇庆 版权所有";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox_baud;
        private System.Windows.Forms.Label label_state_serial;
        private System.Windows.Forms.ComboBox comboBox_serialNumber;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.Button button_writePID;
        private System.Windows.Forms.Button button_readPID;
        private System.Windows.Forms.TextBox textBox_D;
        private System.Windows.Forms.TextBox textBox_I;
        private System.Windows.Forms.TextBox textBox_P;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button_pwm;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button_lock;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_des;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button_record;
        private System.Windows.Forms.Button button_reRecord;
        private System.Windows.Forms.Button button_export;
    }
}

