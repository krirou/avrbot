using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Diagnostics;
using System.Configuration;
using Utility.ModifyRegistry;


namespace AVrBoT_v4
{
    public partial class Flasher : Form
    {
        /// <summary>
        /// configurer pour charger le programme dans le microcontroleur
        /// </summary>
        //declaration des variables 
        String appName = "AVrBoT";
        String avrdudexe = "avrdude.exe";
        String avrdudconfig = "avrdude.conf";
        String myexefile = "";
        String[] chipDude = new String[100];
        String[] programmerDude = new String[100];
        SerialPort sport = new SerialPort();
        //processus de sortie
        delegate void finishedProcessDelegate(string output);
        /// <summary>
        /// methode d'acces et iteration
        /// </summary>
        //return programmeur
        private string Programmeur= "AVrBoT";
        public string myprogrammeur
        {
            get
            {
                return Programmeur;
            }
            set
            {
                Programmeur = value;
            }
        }
        //return microcontroleur
        private string microcontroleur = "atmega16";
        public string mymicrocontroleur
        {
            get
            {
                return microcontroleur;
            }
            set
            {
                microcontroleur = value;
            }
        }
        //return fcpu
        private string FCPU = "1000000";
        public string myFCPU
        {
            get
            {
                return FCPU;
            }
            set
            {
                FCPU = value;
            }
        }
        
        public Flasher()
        {
            InitializeComponent();
            textCommand.Visible = false;
            //verification de l'existance des fichiers avrdude
            try
            {

                myexefile = Path.GetFullPath("toolavrbot") + "\\bin";
               
                
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }

            catch (ArgumentException ex)
            {
                if (MessageBox.Show(ex.Message + "vous voulez continuer!", "Avertissement", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {

                    Application.Run(new AVrBoT_4());

                }
            }
        }
        
        //charger la fichier .hex
        private void buttonhex_Click(object sender, EventArgs e)
        {
            projet project = new projet();
            string nom_projet = project.project_name;
            string name = "app-avrbot";
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            labelhex.Text = desktopPath + @"\" + name + @"\" + nom_projet;
            
            openFileDialog1.InitialDirectory = labelhex.Text;
            openFileDialog1.ShowDialog();
            openFileDialog1.Filter = "Text Files|*.hex|*.asm|*.txt";
            labelhex.Text = openFileDialog1.FileName;
        }
        
        //aide de configuration valeur
        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.engbedded.com/fusecalc/");
        }
        //AIDE DE COMMANDE AVRDUDE VIA MS
        private void button2_Click(object sender, EventArgs e)
        {
            string avrPath = Path.GetFullPath("toolavrbot");
            textCommand.Text = "";
            string command = "\"" + avrPath + "\\bin" + "\\avrdude.exe " +
                              "\" -help" ;

            textCommand.Text =command;
            textCommand.Visible = false;
            backgroundWorker.RunWorkerAsync(textCommand.Text);
        }
        //confirmer les choix 
        private void button4_Click(object sender, EventArgs e)
        {
            updateCommand(sender, e);
           // textCommand.Visible = true;
           
        }
        
        // inviter des commandes pour avrdude 
        private void updateCommand(object sender, EventArgs e)
        {
            if (comboProgrammer.Text != "" &&
                comboPorts.Text != "" &&
                comboChip.Text != "" &&
                labelhex.Text != "fichier hex" &&
                labelhex.Text != "*.hex")
            {


                String command = "\"" + myexefile +"\\" + avrdudexe +
                                 "\" -C \"" + myexefile + "\\"+ avrdudconfig +
                                 "\" -c " + programmerDude[comboProgrammer.SelectedIndex] +
                                 " -p " + chipDude[comboChip.SelectedIndex] +
                                 " -P " + comboPorts.Text +
                                 " -U flash:w:\"" + labelhex.Text + "\":i ";

                if (checkBox1.Checked == true)
                {
                    command = command + " -b " + comboBaud.Text;
                }
                if (checkBox2.Checked == true)
                {
                    command = command + " -i " + comboClock.Text;
                }
                if (textBoxCommande.Text == "")
                {
                    command = command + "";
                }
                else
                {
                    command = command + textBoxCommande.Text;
                }

                if (checkSetFuses.Checked == true)
                {

                    if (textLowByte.Text != "")
                    {
                        command = command + " -U lfuse:w:0x" + textLowByte.Text + ":m";
                    }
                    if (textHighByte.Text != "")
                    {
                        command = command + " -U hfuse:w:0x" + textHighByte.Text + ":m";
                    }
                    if (textExtendedByte.Text != "")
                    {
                        command = command + " -U efuse:w:0x" + textExtendedByte.Text + ":m";
                    }
                }

                textCommand.Text = command;
            }
        }
        //chemin de fichier avrdude.exe et avrdude.conf
        private void button3_Click(object sender, EventArgs e)
        {
            
            backgroundWorker.WorkerSupportsCancellation=true;
            if (backgroundWorker.WorkerSupportsCancellation == true)
            {
                backgroundWorker.CancelAsync();
                backgroundWorker.Dispose();
            }
            Flasher.ActiveForm.Cursor = Cursors.Default;
            textBoxOutput.Cursor = Cursors.Default;
            
            textBoxOutput.Text = " AVrBoT Lab Education version 4.2 \n\r";
            textBoxOutput.Text +=" \n Operation de flash est arreter !";
        }
        //ecrire dans le microcontroleur/charger le programme
        private void button5_Click(object sender, EventArgs e)
        {
            textBoxOutput.Text = " AVrBoT Lab Education version 4.2 \n";
            sport.PortName = comboPorts.Text;
            Flasher.ActiveForm.Cursor = Cursors.Default;
            textBoxOutput.Cursor = Cursors.WaitCursor;
           

            backgroundWorker.RunWorkerAsync(textCommand.Text);
            
        }
        //charher le contenu de l'interface 
        private void Flasher_Load(object sender, EventArgs e)
        {
            string name = "app-avrbot";
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            labelhex.Text = desktopPath + @"\" + name;
            String line;
            int i = 0;

            try
            {
                // lecture de la liste des microcontroleurs
                using (StreamReader sr = new StreamReader("chip.txt"))
                {
                    String[] chipData;
                    
                    while ((line = sr.ReadLine()) != null)
                    {
                        chipData = line.Split(',');
                        chipDude[i] = chipData[0];
                        comboChip.Items.Add(chipData[1].Trim());
                        i++;
                    }
                }
                // lecture de la liste programmeur.
                
                using (StreamReader sr = new StreamReader("programmer.txt"))
                {
                    String[] programmerData;
                    i = 0;
                    
                    while ((line = sr.ReadLine()) != null)
                    {
                        programmerData = line.Split(',');
                        programmerDude[i] = programmerData[0];
                        comboProgrammer.Items.Add(programmerData[1].Trim());
                        i++;

                    }
                }
                comboChip.SelectedIndex = 0;
                comboProgrammer.SelectedIndex = 0;

            }
            catch (Exception exc)
            {
                
                MessageBox.Show("Probleme dans la lecture de fichier.\r\n\r\n" + exc.Message + "\r\n\r\n" + appName +
                " fermer.",
                        "Erreur",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                
            }
            // port serie COM
            foreach (string str in SerialPort.GetPortNames())
            {
                comboPorts.Items.Add(str);
                comboPorts.SelectedIndex = 0;

            }
            
            try
            {
           
                textLowByte.Text = AVrBoT_v4.Properties.Settings.Default.lowbyte;
                textHighByte.Text = AVrBoT_v4.Properties.Settings.Default.highbyte;
                textExtendedByte.Text = AVrBoT_v4.Properties.Settings.Default.extendedbyte;
                checkSetFuses.Checked = AVrBoT_v4.Properties.Settings.Default.fuse;
            }
            catch (Exception ex)
            {
                if (MessageBox.Show(ex.Message, "AVRdude", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    
                    textLowByte.Text = AVrBoT_v4.Properties.Settings.Default.lowbyte;
                    textHighByte.Text = AVrBoT_v4.Properties.Settings.Default.highbyte;
                    textExtendedByte.Text = AVrBoT_v4.Properties.Settings.Default.extendedbyte;
                    checkSetFuses.Checked = AVrBoT_v4.Properties.Settings.Default.fuse;

                }
            }

            // valeur par defaut
            try
            {
                comboProgrammer.SelectedIndex = AVrBoT_v4.Properties.Settings.Default.programmer;
            }
            catch
            {
                comboProgrammer.SelectedIndex = 0;
            }
            try
            {
                comboPorts.SelectedIndex = AVrBoT_v4.Properties.Settings.Default.port;
            }
            catch
            {
               // comboPorts.SelectedIndex = 0;
            }
            try
            {
                comboChip.SelectedIndex = AVrBoT_v4.Properties.Settings.Default.chip;
            }
            catch
            {
                comboChip.SelectedIndex = 0;
            }

            this.myprogrammeur = comboProgrammer.Text;
            this.mymicrocontroleur = comboChip.Text;
            this.myFCPU = comboClock.Text;

            // chargement de commande prompt 
            updateCommand(sender, e);

        }
        //finir l'execution de processus
        private void finishedProcess(string output)
        {
            // retour de fonction 
            textBoxOutput.Text = " AVrBoT Lab Education version 4.2 \r\n";
           textBoxOutput.Text += output;

            Flasher.ActiveForm.Cursor = Cursors.Arrow;
            textBoxOutput.Cursor = Cursors.IBeam;
            Flasher.ActiveForm.Text = appName;


           textBoxOutput.SelectionStart = textBoxOutput.Text.Length;
            textBoxOutput.ScrollToCaret();
        }
        //concerner les donnnees pour la prochaine utilisation 
        private void Flasher_FormClosing(object sender, FormClosingEventArgs e)
        {

            // concerver les choix pour la prochaine utilisation.
            AVrBoT_v4.Properties.Settings.Default.hex = label1.Text;
            AVrBoT_v4.Properties.Settings.Default.chip = comboChip.SelectedIndex;
            AVrBoT_v4.Properties.Settings.Default.programmer = comboProgrammer.SelectedIndex;
            AVrBoT_v4.Properties.Settings.Default.port = comboPorts.SelectedIndex;
            AVrBoT_v4.Properties.Settings.Default.lowbyte = textLowByte.Text;
            AVrBoT_v4.Properties.Settings.Default.highbyte = textHighByte.Text;
            AVrBoT_v4.Properties.Settings.Default.extendedbyte = textExtendedByte.Text;
            AVrBoT_v4.Properties.Settings.Default.fuse = checkSetFuses.Checked;
            AVrBoT_v4.Properties.Settings.Default.chipscount = comboChip.Items.Count;
            AVrBoT_v4.Properties.Settings.Default.programmercount = comboProgrammer.Items.Count;
            AVrBoT_v4.Properties.Settings.Default.Save();
        }
        //executer les commandes
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
             // Réponse par defaut
            
            string returnText = "Rien n'a été retourné!";
            try
            {
                Process avrprog = new Process();
                StreamReader avrstdout, avrstderr;
                StreamWriter avrstdin;
                string command = (string)e.Argument;
                
                ProcessStartInfo psI = new ProcessStartInfo("cmd");
                psI.UseShellExecute = false;
                psI.RedirectStandardInput = true;
                psI.RedirectStandardOutput = true;
                psI.RedirectStandardError = true;
                psI.CreateNoWindow = true;
                avrprog.StartInfo = psI;
                avrprog.Start();
                avrstdin = avrprog.StandardInput;
                avrstdout = avrprog.StandardOutput;
                avrstderr = avrprog.StandardError;
                avrstdin.AutoFlush = true;
                avrstdin.WriteLine(command);
                avrstdin.Close();
                returnText = avrstdout.ReadToEnd();
                returnText += avrstderr.ReadToEnd();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Il y avait un problème d'exécuter cette commande. \r\n\r\n" +
                                "(" + exc.Message + ")",
                                "Erreur",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }

            
            Invoke(new finishedProcessDelegate(finishedProcess), returnText);
        }
        //remplir les donnees des bytes 
        private void checkSetFuses_CheckedChanged(object sender, EventArgs e)
        {
            if (checkSetFuses.Checked == true)
            {
                textLowByte.Enabled = true;
                textHighByte.Enabled = true;
                textExtendedByte.Enabled = true;
            }
            else
            {
                textLowByte.Enabled = false;
                textHighByte.Enabled = false;
                textExtendedByte.Enabled = false;
            }
            updateCommand(sender, e);
        }
        //activer l'ecriture des commandes personelles
        private void textCommand_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (textCommand.ReadOnly != true)
            {
                textCommand.ReadOnly = true;
            }
            else
            {
                textCommand.ReadOnly = false;
            }
        }

        private void textBoxOutput_TextChanged(object sender, EventArgs e)
        {
            textBoxOutput.Text = textBoxOutput.Text.Replace("Microsoft Windows", "AVrBoT  Editeur pour Windows");
            textBoxOutput.Text = textBoxOutput.Text.Replace("Microsoft Corporation.", "AVrBoT Lab Eduction ");
            textBoxOutput.Text = textBoxOutput.Text.Replace("2009", "2014 ");
            textBoxOutput.Text = textBoxOutput.Text.Replace("2010", "2014 ");
            textBoxOutput.Text = textBoxOutput.Text.Replace("2011", "2014 ");
            textBoxOutput.Text = textBoxOutput.Text.Replace("2012", "2014 ");
            textBoxOutput.Text = textBoxOutput.Text.Replace("20013", "2014 ");
        }

        

        

       
    }
}
