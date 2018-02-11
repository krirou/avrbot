using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace AVrBoT_v4 
{
    public partial class MyTCP : Form
    {
        TcpClient client = new TcpClient();
       

        public MyTCP()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string SERVER_IP = textip.Text;
                int SERVER_PORT = int.Parse(textport.Text);
                textinfo.Text = "Connecting... ";

                client.Connect(SERVER_IP, SERVER_PORT);
                textinfo.Text = "envoyer la commande... ";
                using(NetworkStream stream = client.GetStream())
                {
                    while (true)
                    {
                        string message = textsend.Text;
                        if (string.IsNullOrEmpty(message))
                            break;
                        byte[] data = Encoding.ASCII.GetBytes(message);
                        textinfo.Text = "envoi encours... ";
                        stream.Write(data, 0, data.Length);
                        textinfo.Text = "message envoyé ";
                        byte[] response = new byte[4096];
                        int bytesRead = stream.Read(response, 0, response.Length);
                        textread.Text="Reponse: " + Encoding.ASCII.GetString(response, 0, bytesRead);
                    }

                }
            }
            catch
            {
                textinfo.Text = "echec de connexion";
            }
            client.Close();

        }
    }
}

