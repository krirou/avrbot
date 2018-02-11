#region using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
#endregion
namespace AVrBoT_v4
{
    public partial class Propriétés_de_port : Form
    {
        private string BaudR = "9600";
        private string DataB = "8";
        private string Parit = "None";
        private string StopB = "One";
        private string ReadTimeO = "-1";

        public string BaudeRat
        {
            get
            {
                return BaudR;
            }
            set
            {
                BaudR = value;
            }
        }
        public string DataBit
        {
            get
            {
                return DataB;
            }
            set
            {
                DataB = value;
            }
        }
        public string Pari
        {
            get
            {
                return Parit;
            }
            set
            {
                Parit = value;
            }
        }
        public string StopBit
        {
            get
            {
                return StopB;
            }
            set
            {
                StopB = value;
            }
        }
        public string ReadTim
        {
            get
            {
                return ReadTimeO;
            }
            set
            {
                ReadTimeO = value;
            }
        }
        public Propriétés_de_port()
        {
            InitializeComponent();


            try
            {


                this.BaudeRat = BaudRatecombobox.Text;
                this.DataBit = DataBitscombobox.Text;
                this.Pari = Paritycombobox.Text;
                this.StopBit = StopBitscombobox.Text;
                this.ReadTim = ReadTimeOutcombobox.Text;
            }
            catch (Exception)
            {
            }

        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.BaudeRat = BaudRatecombobox.Text;
                this.DataBit = DataBitscombobox.Text;
                this.Pari = Paritycombobox.Text;
                this.StopBit = StopBitscombobox.Text;
                this.ReadTim = ReadTimeOutcombobox.Text;
                this.Close();

            }
            catch
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.BaudeRat = "";
                this.DataBit = "";
                this.Pari = "";
                this.StopBit = "";
                this.ReadTim = "";
                this.Close();
            }
            catch
            {


            }
        }

    }
}
