using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Win32;
using System.Runtime.InteropServices;


namespace AVrBoT_v4
{
    public partial class SplashScreen : Form
    {

        
        public SplashScreen()
        {
            InitializeComponent();
           
        }

        private void SplashScreen_Shown(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = true;
            panel3.Visible = true;
           // label1.Visible = true;
            for (int i = 0; i < 100; i++)
            {
                progressBar1.Value =i;
                System.Threading.Thread.Sleep(250);
            }
           
           
            //display mainform
           AVrBoT_4 mf = new AVrBoT_4();
           mf.Show();
            //hide this form
           this.Hide();
          
           
        }
       

       
		}
	}
	


      
      
       
    

