using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Globalization;
using System.Threading;
using System.Diagnostics;
using System.Net.Sockets;
using System.Net;
using System.Runtime.InteropServices;
using Utility.DriverManagement;
using InTheHand;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Ports;
using InTheHand.Net.Sockets;
namespace AVrBoT_v4
{
    public partial class BlueTouth : Form
    {
        List<string> items;
        BluetoothDeviceInfo[] devices;
        public BlueTouth()
        {
            items = new List<string>();
            InitializeComponent();
            
        }
        bool serverstarted = false;
        private void connecter_Click(object sender, EventArgs e)
        {
            msgtexte.Clear();
            LB.Text = "";
            if (CLient.Checked )
            {
                starscan();
                   
            }
            if(serveur.Checked)
            {
                msgtexte.Text = "";
                connectAsserver(); 
            }
        }




        private void starscan()
        {
            Thread blueToothThreadScan = new Thread(new ThreadStart(scan));
            blueToothThreadScan.Start(); 

        }


        private void scan()
        {
            try
            {
                LB.DataSource = null;
                updat("\n");
                updat("scan en cours...");
                BluetoothClient client = new BluetoothClient();
                devices = client.DiscoverDevicesInRange();
                updat("\n");
                updat("scan terminé");
                updat(devices.Length.ToString() + " péripherique trouvé");
                foreach (BluetoothDeviceInfo d in devices)
                {
                    items.Add(d.DeviceName);

                }
                updatdeviceliste();
            }
            catch (NotSupportedException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void updatdeviceliste()
        {
            Func<int> del = delegate()
            {
                LB.Visible = true;
                LB.DataSource = items;
                return 0;
            };

            Invoke(del);
        }
        private void connectAsserver()
        {
            Thread blueToothServerThread = new Thread(new ThreadStart(ServerConnectThread));
            blueToothServerThread.Start();

        }
        Guid MyID = new Guid("00001101-0000-1000-8000-00805F9B34FB");
        
        public void ServerConnectThread()
        {
            serverstarted = true;
            try
            {
                updat("serveur activé");
                BluetoothListener bluelistener = new BluetoothListener(MyID);
                bluelistener.Start();
                BluetoothClient conn = bluelistener.AcceptBluetoothClient();
                updat("client est connecter!");
                Stream mstream = conn.GetStream();
                while (true)
                {
                    byte[] recieved = new byte[1024];
                    mstream.Read(recieved, 0, recieved.Length);
                    updat("Message reçue:" + Encoding.ASCII.GetString(recieved));
                    byte[] sent = Encoding.ASCII.GetBytes(bltexte.Text);
                    mstream.Write(sent, 0, sent.Length);


                }
            }
            catch (PlatformNotSupportedException)
            {
                
                updat("client est deconnecté!");

            }
        }
        private void updat(string msg)
        {
            Func<int> del = delegate()
            {
                msgtexte.AppendText(msg + System.Environment.NewLine);
                return 0;
            };
            Invoke(del);

        }
        BluetoothDeviceInfo deviceinfo;
        private void LB_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                deviceinfo = devices.ElementAt(LB.SelectedIndex);
                updat(deviceinfo.DeviceName + " est selectionné");
                if (pairdevice())
                {
                    updat(" essaie de connecter le péripherique ");
                    Thread bluetouthClienThread = new Thread(new ThreadStart(clientConnectThread));
                    bluetouthClienThread.Start();
                }
                else
                {
                    updat("connexion echoué avec le peripherique");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void clientConnectThread()
        {
            BluetoothClient client = new BluetoothClient();
            updat("essaie de connection");
            client.BeginConnect(deviceinfo.DeviceAddress, MyID, this.bluetouthClientConnectCallBack, client);
        }
         bool ready = false;
         Byte[] message;
        private void bltexte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                message = Encoding.ASCII.GetBytes(bltexte.Text);
                ready = true;
                bltexte.Clear();
            }
        }
        private void bluetouthClientConnectCallBack(IAsyncResult result)
        {
            BluetoothClient client = (BluetoothClient)result.AsyncState;
            client.EndConnect(result);
            Stream stream = client.GetStream();
            stream.ReadTimeout = 1000;
            while (true)
            {
                while (!ready) ;
                stream.Write(message, 0, message.Length);

            }

        }
        string myPin = "1010";
        private bool pairdevice()
        {
            if (!deviceinfo.Authenticated)
            {
                if(!BluetoothSecurity.PairRequest(deviceinfo.DeviceAddress,myPin))
                {
                    return false;
                }
            }
            return true;
        }
       
        }

    } 

