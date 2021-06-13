using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.IO;
using System.IO.Ports;
using System.Threading;


namespace PDI_Tarea2.Forms
{
    public partial class USB : Form
    {
        public System.IO.Ports.SerialPort sport;
        public String filePath = string.Empty;
        Thread FileSender;
        private static EventWaitHandle waitHandle = new ManualResetEvent(initialState: true);
        public USB()
        {
            InitializeComponent();
            foreach (String s in SerialPort.GetPortNames())
            {
                txtPort.Items.Add(s);
            }
            this.cmbbaudrate.SelectedIndex = 0;
            this.cmbparity.SelectedIndex = 2;
            this.cmbdatabits.SelectedIndex = 3;
            this.cmbstopbits.SelectedIndex = 0;
            cmdClose.Enabled = false;
            cmbSend.Enabled = false;
            btSend.Enabled = false;
            btStop.Enabled = false;
            btPause.Enabled = false;
             filePath = Cache.GetFileName();
            txPath.Text = filePath;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtPort.Items.Clear();
            foreach (String s in SerialPort.GetPortNames())
            {
                txtPort.Items.Add(s);
            }
        }



        public void serialport_connect(String port, int baudrate, Parity parity, int databits, StopBits stopbits)
        {
            DateTime dt = DateTime.Now;
            String dtn = dt.ToShortTimeString();

            
            try
            {
                sport = new System.IO.Ports.SerialPort(port, baudrate, parity, databits, stopbits);
                sport.Open();
                cmdClose.Enabled = true;
                cmbSend.Enabled = true;
                cmdConnect.Enabled = false;
                txtReceive.Text = ("[" + dtn + "] " + "З'єднано\n") + txtReceive.Text;
                sport.DataReceived += new SerialDataReceivedEventHandler(sport_DataReceived);
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString(), "Помилка"); }
        }

        private void sport_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            DateTime dt = DateTime.Now;
            String dtn = dt.ToShortTimeString();

            txtReceive.Text = ("[" + dtn + "] " + "Прийнято: " + sport.ReadExisting() + "\n") + txtReceive.Text;
        }

        private void cmdConnect_Click(object sender, EventArgs e)
        {
            String port = txtPort.Text;
            int baudrate = Convert.ToInt32(cmbbaudrate.Text);
            Parity parity = (Parity)Enum.Parse(typeof(Parity), cmbparity.Text);
            int databits = Convert.ToInt32(cmbdatabits.Text);
            StopBits stopbits = (StopBits)Enum.Parse(typeof(StopBits), cmbstopbits.Text);
            serialport_connect(port, baudrate, parity, databits, stopbits);

            if (File.Exists(filePath) && (sport != null) && (sport.IsOpen))
            {
                btSend.Enabled = true;
            }
        }

        private void cmbSend_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            String dtn = dt.ToShortTimeString();
            String data = txtDatatoSend.Text;
            sport.Write(data);
            txtReceive.Text = ("[" + dtn + "] " + "Відправлено: " + data + "\n") + txtReceive.Text;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            String dtn = dt.ToShortTimeString();

            if (sport.IsOpen)
            {
                sport.Close();
                cmdClose.Enabled = false;
                cmdConnect.Enabled = true;
                cmbSend.Enabled = false;
                txtReceive.Text = ("[" + dtn + "] " + "Відключено\n") + txtReceive.Text;
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
                txPath.Text = filePath;
            }
            if (File.Exists(filePath) && (sport!=null) && (sport.IsOpen))
            {
                btSend.Enabled = true;
            }

        }
        public class SendFile
        {
            public SerialPort sport;
            public Stream file;
            public int Delay;

        }

        private void button3_Click(object sender, EventArgs e)
        {

            cmdClose.Enabled = false;
            cmbSend.Enabled = false;
            btSend.Enabled = false;
            btPause.Enabled = true;
            btStop.Enabled = true;
         
            SendFile NewProgramSend = new SendFile();
            NewProgramSend.sport = sport;
            openFileDialog1.FileName =  filePath;
            NewProgramSend.file = openFileDialog1.OpenFile();
            NewProgramSend.Delay = Convert.ToInt32(nUDDelay.Value);

            FileSender = new Thread(new ParameterizedThreadStart(SendFileTo));
            FileSender.Start(NewProgramSend);
        }

        public int GetDelay()
        {
            return Convert.ToInt32(nUDDelay.Value);
        }

        public void AppendTextBox(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendTextBox), new object[] { value });
                return;
            }
            txtReceive.Text = value + txtReceive.Text;
        }
        public void CloseButtonEnable(bool value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<bool>(CloseButtonEnable), new object[] { value });
                return;
            }
            cmdClose.Enabled = value;
        }

        public void SendButtonEnable(bool value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<bool>(SendButtonEnable), new object[] { value });
                return;
            }
            cmbSend.Enabled = value;
        }

        public void SendFileButtonEnable(bool value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<bool>(SendFileButtonEnable), new object[] { value });
                return;
            }
            btSend.Enabled = value;
        }

        public void SendFileTo (object obj)
        {
            SendFile C = (SendFile)obj;
            using (StreamReader reader = new StreamReader(C.file))
            {
                while (reader.Peek() >= 0)
                {
                    // textBox1.Text = textBox1.Text + reader.ReadLine() + Environment.NewLine;
                    DateTime dt = DateTime.Now;
                    String dtn = dt.ToShortTimeString();
                    String data = reader.ReadLine();
                    C.sport.Write(data);
                    AppendTextBox("[" + dtn + "] " + "Відправлено: " + data + Environment.NewLine);
                    Thread.Sleep(GetDelay());
                    waitHandle.WaitOne();
                }
                CloseButtonEnable(true);
                SendButtonEnable(true);
                SendFileButtonEnable(true);
            }
        }

       
        private void btPause_Click(object sender, EventArgs e)
        {
            if (btPause.Text == "Пауза")
            {
                waitHandle.Reset();
                btPause.Text = "Продовжити";
            }
           else 
            {
                waitHandle.Set();
                btPause.Text = "Пауза";
            }

        }

        private void btStop_Click(object sender, EventArgs e)
        {
            FileSender.Abort();
            btStop.Enabled = false;
            btPause.Enabled = false;

            cmdClose.Enabled = true;
            cmbSend.Enabled = true;
            btSend.Enabled = true ;

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
           // FileSender.Abort();
            this.Close();
        }
    }
}
