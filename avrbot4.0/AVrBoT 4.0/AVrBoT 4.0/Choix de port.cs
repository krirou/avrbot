#region using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
#endregion
namespace AVrBoT_v4
{
    public partial class choix_de_port : Form
    {
        private string PortCOM = "COM1";
        public string PCOM
        {
            get
            {
                return PortCOM;
            }
            set
            {
                PortCOM = value;
            }
        }
        public choix_de_port()
        {
            InitializeComponent();

            try
            {

                string[] Ports = SerialPort.GetPortNames();
                foreach (string port in Ports)
                {
                    comboBox1.Items.Add(port);
                    comboBox1.Text = port;
                    this.PCOM = comboBox1.Text;
                    comboBox1.SelectedIndex = 0;
                }
            }
            catch (Exception) { }


        }

        

        private void button2_Click(object sender, EventArgs e)
        {

            this.PCOM = comboBox1.Text;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.PCOM = "";
            this.Close();
        }

      

    }
}
