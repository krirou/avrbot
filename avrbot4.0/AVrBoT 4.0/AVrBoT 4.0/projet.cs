using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AVrBoT_v4
{

    public partial class projet : Form
    {
        
        public projet()
        {
            InitializeComponent();
            nomauteur.Text = "nom";
            nomprojet.Text = "application1";

        }
        public string project_name = "application1";
        public string auteur = "?";

       

        private void button1_Click(object sender, EventArgs e)
        {
           
            project_name = nomprojet.Text;
            auteur = nomauteur.Text;
            this.Close();
            

        }
    }
}
