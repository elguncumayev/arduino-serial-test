using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace XeriteTest
{
    public partial class Form1 : Form
    {
        static SerialPort _serialPort;
        public Form1()
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(Form1_FormClosed);
            if (_serialPort == null)
            {
                _serialPort = new SerialPort("COM4", 9600);//Set your board COM
                _serialPort.Open();
            }
        }
        void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_serialPort != null && _serialPort.IsOpen)
            {
                _serialPort.Close();
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if(sender is Button button)
            {
                int buttonId = int.Parse(button.Name.Split('-')[1]);
                label1.Text = buttonId.ToString();
                char message = (char)('a' + buttonId);
                PortWrite(message.ToString());
            }
        }

        private void PortWrite(string message)
        {
            _serialPort.Write(message);
        }
    }
}
