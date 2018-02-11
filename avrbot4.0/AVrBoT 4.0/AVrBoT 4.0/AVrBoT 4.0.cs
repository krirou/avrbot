# region using directives
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
using System.Text.RegularExpressions;
using Utility.DriverManagement;
using InTheHand;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Ports;
using InTheHand.Net.Sockets;
#endregion
namespace AVrBoT_v4
{

    public partial class AVrBoT_4 : Form
    {
        choix_de_port cp = new choix_de_port();
        Propriétés_de_port pp = new Propriétés_de_port();
        SplashScreen ac = new SplashScreen();
        Flasher avrdud = new Flasher();
        SerialPort SP = new SerialPort();
        Process myProcess = new Process();
        DriverManagement driver = new DriverManagement();
        BlueTouth bl = new BlueTouth();
        MyWifi wifi = new MyWifi();
        MyTCP MyTCP = new MyTCP();
        projet proj = new projet();
        delegate void finishedProcessDelegate(string output);

        public AVrBoT_4()
        {
           
            InitializeComponent();
            
            labelconnexion.Text = "";
            startext.Hide();
            panelNum.Visible = false;
            texthex.Hide();
            labelmicrocontroleur.Text = "                     ";
            labelprogrammeur.Text = "                          ";
            labelcpu.Text = "                                    ";
            labelcom.Text = "           ";
            
            
        }

       public string nom_projet = "application1";
       public string auteur = "?";

        ///
        ///configuration de serial port
        //configuration de port de communication 
        delegate void OutputUpdateDelegate(string data);
        private void OutputUpdateCallback(string data)
        {
            texthex.Text += data;
        }
        public void myserialPort()
        {
            try
            {
                myserial.PortName = cp.PCOM;
                myserial.BaudRate = int.Parse(pp.BaudeRat);
                myserial.DataBits = int.Parse(pp.DataBit);
                myserial.Parity = (Parity)Enum.Parse(typeof(Parity), pp.Pari);
                myserial.StopBits = (StopBits)Enum.Parse(typeof(StopBits), pp.StopBit);
                myserial.ReadTimeout = int.Parse(pp.ReadTim);

            }
            catch (ArgumentException ex)
            {

                if (MessageBox.Show(ex.Message + "\n Configurer le port de communication", "Information port COM", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {

                    cp.ShowDialog();
                    pp.ShowDialog();

                }
            }
            catch (FormatException ex)
            {
                if (MessageBox.Show(ex.Message + "\n Configurer le port de communication", "Information port COM", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {

                    cp.ShowDialog();
                    pp.ShowDialog();

                }
            }
            catch (IOException ex)
            {
                if (MessageBox.Show(ex.Message + "\n Configurer le port de communication", "Information port COM", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {

                    cp.ShowDialog();
                    pp.ShowDialog();

                }
            }
        }
        //ouverture de port de communication
        public void OpenMyserialPort()
        {
            try
            {
                if (!myserial.IsOpen)
                {
                    myserialPort();
                    myserial.Open();
                }
            }
            catch (IOException ex)
            {
                if (MessageBox.Show(ex.Message + "Choisir un autre port de communication", "Information port COM", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {

                    cp.ShowDialog();

                }
            }
            catch (ArgumentException ex)
            {
                if (MessageBox.Show(ex.Message + "\n Choisir un autre port de communication", "Information port COM", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {

                    cp.ShowDialog();

                }

            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }




        ///
        ///traitement des fichiers
        //ouvrir une nouvelle session par defaut de programmation

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            proj.ShowDialog();
            nom_projet = proj.project_name;
            auteur = proj.auteur;
            panelNum.Visible = true;
            this.startext.ScrollBars = RichTextBoxScrollBars.ForcedBoth;
            startext.Clear();
            String buildPath = "app-avrbot";
            CreateResultFolder(ref buildPath);
            try
            {
                labelconnexion.Text = "Session de programmation";
                actualiser_Click(sender, e);
               startext.Show();
                texthex.Show();
                startext.Text = "/****************projet:"+nom_projet+"***************************************/" +"\n"
                                +"/*********************realisé par:"+auteur+"*********************************/"+"\n"

                                +"#include <avrbot.h>" + "\n"
                                + "//definir les variables" + "\n"
                                + "int main ( void )" + "\n"
                                + "{" + "\n"
                                + "//config_port_sortie(1)" + "\n"
                                + "while (1)" + "\n"
                                + "{" + "\n"
                                + "//entrer le code ici" + "\n"
                                + "//port_sortie(1,1)" + "\n"
                                + "}" + "\n"
                                + "}" + "\n";
                
                texthex.Text = "";
                activemenu(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFD = new OpenFileDialog();
                string Chosen_File = "";


                string name = "app-avrbot";
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                openFD.InitialDirectory = desktopPath + @"\" + name;
                openFD.Title = "Ouvrir un projet";
                openFD.FileName = "";
                nom_projet = "exeterne";
                openFD.Filter = "All files (*.*)|*.*";

                if (openFD.ShowDialog() != DialogResult.Cancel)
                {
                    
                    this.startext.ScrollBars = RichTextBoxScrollBars.ForcedBoth;
                    startext.Clear();
                    Chosen_File = openFD.FileName;
                    startext.Text = File.ReadAllText(Chosen_File);
                    nom_projet = Path.GetFileNameWithoutExtension(Chosen_File);
                    labelconnexion.Text = "Session de programmation";
                    actualiser_Click(sender, e);
                    startext.Show();
                    texthex.Show();
                    texthex.Text = "";
                    activemenu(sender, e);
                    panelNum.Visible = true;
                    String buildPath = "app-avrbot";
                    CreateResultFolder(ref buildPath);
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "AVrBoT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            proj.project_name = nom_projet;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFD = new SaveFileDialog();

                string saved_file = "";
                string name = "app-avrbot";
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                saveFD.InitialDirectory = desktopPath + @"\" + name;
                saveFD.Title = "enregistrer le projet";
                saveFD.FileName = "";

                saveFD.Filter = "Text Files|*.avrbot|*.asm|*.txt";

                if (saveFD.ShowDialog() != DialogResult.Cancel)
                {

                    saved_file = saveFD.FileName;
                    StreamWriter sw = new StreamWriter(saved_file);
                    sw.Write(startext.Text);
                    sw.Close();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "AVrBoT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFD = new SaveFileDialog();

                string saved_file = "";
                string name = "app-avrbot";
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                saveFD.InitialDirectory = desktopPath + @"\" + name;
                saveFD.Title = "enregistrer le projet";
                saveFD.FileName = "";

                saveFD.Filter = "Text Files|*.avrbot|*.asm|*.txt";

                if (saveFD.ShowDialog() != DialogResult.Cancel)
                {

                    saved_file = saveFD.FileName;
                    StreamWriter sw = new StreamWriter(saved_file);
                    sw.Write(startext.Text);
                    sw.Close();



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "AVrBoT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelNum.Visible = false;
            labelconnexion.Text = "";
            desactivemenu(sender, e);
            myserial.Close();
            startext.Hide();
            texthex.Hide();
        }
        /// <summary>
        /// //editeur de texte
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(startext.SelectedText);

                startext.SelectedText = string.Empty;
            }
            catch {  }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(startext.SelectedText);
            }
            catch {  }
            
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string xx = Clipboard.GetText();

                startext.Text = startext.Text.Insert(startext.SelectionStart, xx);
            }
            catch 
            {  }
        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {

            startext.Text = "";
        }
        /// <summary>
        /// configuration de systeme
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// //configurer le port de communication
        private void portToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cp.ShowDialog();
        }
        //les proprietes de port de communication
        private void propriétéPortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pp.ShowDialog();
        }

        /// <summary>
        /// lancer une cession de communication
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// etablir un nouveau connexion
        private void nouveauConnexionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                startext.Show();
                startext.Text = "";
                texthex.Show();
                OpenMyserialPort();
                labelconnexion.Text = "Session de communication";
            }
            catch (IOException ex)
            {
                texthex.Text = ex.Message;
            }
        }
        //Envoyer une listes des données
        private void envoyerLesDonnéesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                myserial.WriteLine(startext.Text);
            }
            catch (IOException ex)
            {
                texthex.Text = ex.Message;
            }
            catch (TimeoutException ex)
            {
                texthex.Text = ex.Message;

            }
            catch (InvalidOperationException ex)
            {
                texthex.Text = ex.Message;

            }

        }

        //lire les données
        private void lireLesDonnéesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                string data = myserial.ReadExisting();
                texthex.Invoke(new OutputUpdateDelegate(OutputUpdateCallback), data);
                if (texthex.Text == "")
                {
                    texthex.Text = "Rien à lire!";
                }

            }
            catch (IOException ex)
            {
                texthex.Text = ex.Message;

            }
            catch (TimeoutException ex)
            {
                texthex.Text = ex.Message;

            }
            catch (InvalidOperationException ex)
            {
                texthex.Text = ex.Message;

            }

        }
        /// <summary>
        /// //des informations pratiques pour la technologie avrbot
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// lancer site avrbot
        void OpenWithArguments()
        {

            System.Diagnostics.Process.Start("http://www.avrbot4.com/");
        }
        // avrbot tutorial
        private void laTechnologieAVrBoTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.avrbot4.com/"); 

        }
        //visiter site avrbot
        private void visiterAVrBoTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.avrbot4.com/");
        }
        //exemple des projets par avrbot
        private void exempleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.avrbot4.com/");
        }
        /// <summary>
        /// configuration materiel et flash de programmeur 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void flasherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            labelconnexion.Text = "Session de Flash";
            avrdud.ShowDialog();
        }
        /// <summary>
        /// actualiser les informations sur le materiel utilisé
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void actualiser_Click(object sender, EventArgs e)
        {
            labelcpu.Text = "                                    " + avrdud.myFCPU;
            labelcom.Text = "           " + cp.PCOM;
            labelmicrocontroleur.Text = "                     " + avrdud.mymicrocontroleur;
            labelprogrammeur.Text = "                          " + avrdud.myprogrammeur;


        }
        public void activemenu(object sender, EventArgs e)
        {
            editMenu.Enabled = true;
            toolsMenu.Enabled = true;
            connexionToolStripMenuItem.Enabled = true;
            technologiesToolStripMenuItem.Enabled = true;
            compilerToolStripMenuItem.Enabled = true;
            supprimer.Enabled = true;
            communicationbluetouth.Enabled = true;
            communicationserie.Enabled = true;
            lire.Enabled = true;
            envoyer.Enabled = true;
            connecter.Enabled = true;
            saveToolStripButton.Enabled = true;
            openToolStripButton.Enabled = true;
        }
        public void desactivemenu(object sender, EventArgs e)
        {
            editMenu.Enabled = false;
            toolsMenu.Enabled = false;
            connexionToolStripMenuItem.Enabled = false;
            technologiesToolStripMenuItem.Enabled = false;
            compilerToolStripMenuItem.Enabled = false;
            supprimer.Enabled = false;
            communicationbluetouth.Enabled = true;
            communicationserie.Enabled = true;
            lire.Enabled = false;
            envoyer.Enabled = false;
            connecter.Enabled = false;
            saveToolStripButton.Enabled = false;
            openToolStripButton.Enabled = false;
        }

        private void texthex_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //texthex.Clear();
        }
        /// <summary>
        /// compiler le programme en C ,c++ et assembleur 
        /// Utilisation de compilateur avr-gcc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
           //enregestrement de projet automatique
            nom_projet = proj.project_name;
            progressBar1.Visible = true;
            texthex.Text = " AVrBoT Lab Education version 4.2 \n\r";
            string name = "app-avrbot";
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            System.IO.Directory.CreateDirectory(desktopPath + @"\" + name+@"\"+nom_projet);

            string auto_save = desktopPath + @"\" + name + @"\" + nom_projet+@"\" + nom_projet+".c";

            StreamWriter sw = new StreamWriter(auto_save);
             sw.Write(startext.Text);
             sw.Close();
            //util de compilation 
            System.Threading.Thread.Sleep(1000);
            progressBar1.Value = 20;
            string avrPath = Path.GetFullPath("toolavrbot");
            string avrbasepath = (string)avrPath + "\\bin" + "\\";
            string objectfile = nom_projet + ".o";
            string elffile = nom_projet + ".elf";
            string hexfile = nom_projet + ".hex";
            string eepfile = nom_projet + ".eep";
            string lssfile = nom_projet + ".lss";
            string outfile = nom_projet + ".out";
            string applicationfile = desktopPath + @"\" + name + @"\" + nom_projet;
            string objectpath = System.IO.Path.Combine(applicationfile, objectfile);
            string sourcename = applicationfile + "\\" + nom_projet + ".c";
            string sourcenameelf = System.IO.Path.Combine(applicationfile, elffile);
            string sourcenameeep = System.IO.Path.Combine(applicationfile, eepfile);
            string sourcenamehex = System.IO.Path.Combine(applicationfile, hexfile);
            string sourcenameout = System.IO.Path.Combine(applicationfile, outfile);


            //compile 
            string command1 = "\"" + avrPath + "\\bin" + "\\avr-gcc.exe " +
                              "\" -c" + // compile, don't link 
                              " -g " + // include debugging info (so errors include line numbers)
                //  optimize for size
                              " -fno-branch-count-reg -fno-defer-pop" +
                              " -fno-function-cse  -fno-guess-branch-probability -fno-inline  " +
                              " -Os" +
                             
                              " -ffunction-sections " + // place each function in its own section
                              " -fdata-sections " +
                              " -mmcu=" + avrdud.mymicrocontroleur +
                              " " + "-Wall -gdwarf-2 -std=gnu99 " + 
                              (string)sourcename +
                              " -o " + objectpath + "  ";



            string commandlinker = "\"" + avrPath + "\\bin" + "\\avr-gcc.exe " +
                            "\" -Os " +
                            " -Wl,--gc-sections " +
                            " -mmcu=" + avrdud.mymicrocontroleur +
                            " " + objectpath +
                            " -o " + "   " + sourcenameelf + "  ";



            string commandeep = "\"" + avrPath + "\\bin" + "\\avr-objcopy.exe " + "\"" +
                               " -j .eeprom --change-section-lma .eeprom=0  " +
                               " -O ihex " +
                               " " + sourcenameelf + "  " +
                               "  " + sourcenameeep + "  ";


            string commandhex = "\"" + avrPath + "\\bin" + "\\avr-objcopy.exe " + "\"" +
                                " -j .text -j .data  " +
                                " -O ihex " +
                                "  " + sourcenameelf + "  " +
                                "   " + sourcenamehex;
            string commandsize = "\"" + avrPath + "\\bin" + "\\avr-size.exe " + "\"" +
                                 " -C " +
                                 " --mcu=" + avrdud.mymicrocontroleur +
                                "  -t " + sourcenameelf + "  ";

            while (backgroundWorker1.IsBusy != true)
            {

                backgroundWorker1.RunWorkerAsync(command1);
                progressBar1.Value = 40;
                backgroundWorker1.Dispose();
                System.Threading.Thread.Sleep(1000);
                while (backgroundWorker2.IsBusy != true)
                {
                    backgroundWorker2.RunWorkerAsync(commandlinker);
                    progressBar1.Value = 60;
                    backgroundWorker2.Dispose();
                    System.Threading.Thread.Sleep(1000);
                    while (backgroundWorker3.IsBusy != true)
                    {
                        backgroundWorker3.RunWorkerAsync(commandeep);
                        backgroundWorker3.Dispose();
                        progressBar1.Value = 80;
                        System.Threading.Thread.Sleep(1000);
                        while (backgroundWorker4.IsBusy != true)
                        {
                            backgroundWorker4.RunWorkerAsync(commandhex);
                            backgroundWorker4.Dispose();
                            progressBar1.Value = 90;
                            System.Threading.Thread.Sleep(1000);
                            while (backgroundWorker5.IsBusy != true)
                            {
                                backgroundWorker5.RunWorkerAsync(commandsize);
                                backgroundWorker5.Dispose();
                                progressBar1.Value = 100;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// create folder pour le projet actuel 
        /// </summary>
        /// <param name="name"></param>
        public void CreateResultFolder(ref string name)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (!(System.IO.Directory.Exists(desktopPath + @"\" + name)))
            {
                System.IO.Directory.CreateDirectory(desktopPath + @"\" + name);
            }
        }

        /// <summary>
        /// compilation de programme assembleur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void assembleurToolStripMenuItem_Click(object sender, EventArgs e)
        {//enregestrement de projet automatique
            nom_projet = proj.project_name;
            progressBar1.Visible = true;
            texthex.Text = " AVrBoT Lab Education version 4.2 \n\r";
            string name = "app-avrbot";
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            System.IO.Directory.CreateDirectory(desktopPath + @"\" + name + @"\" + nom_projet);

            string auto_save = desktopPath + @"\" + name + @"\" + nom_projet + @"\" + nom_projet + ".s";

            StreamWriter sw = new StreamWriter(auto_save);
            sw.Write(startext.Text);
            sw.Close();
            //util de compilation 
            System.Threading.Thread.Sleep(1000);
            progressBar1.Value = 20;
            string avrPath = Path.GetFullPath("toolavrbot");
            string avrbasepath = (string)avrPath + "\\bin" + "\\";
            string objectfile = nom_projet + ".o";
            string elffile = nom_projet + ".elf";
            string hexfile = nom_projet + ".hex";
            string eepfile = nom_projet + ".eep";
            string lssfile = nom_projet + ".lss";
            string outfile = nom_projet + ".out";
            string applicationfile = desktopPath + @"\" + name + @"\" + nom_projet;
            string objectpath = System.IO.Path.Combine(applicationfile, objectfile);
            string sourcename = applicationfile + "\\" + nom_projet + ".s";
            string sourcenameelf = System.IO.Path.Combine(applicationfile, elffile);
            string sourcenameeep = System.IO.Path.Combine(applicationfile, eepfile);
            string sourcenamehex = System.IO.Path.Combine(applicationfile, hexfile);
            string sourcenameout = System.IO.Path.Combine(applicationfile, outfile);

            //compile 
            string command1 = "\"" + avrPath + "\\bin" + "\\avr-gcc.exe " +
                              "\" -c" + // compile, don't link 
                              " -g " + // include debugging info (so errors include line numbers)
                              " -assembler-with-cpp " +
                              " -mmcu=" + avrdud.mymicrocontroleur +
                              " " + (string)sourcename +
                              " -o " + objectpath + "  ";



            string commandlinker = "\"" + avrPath + "\\bin" + "\\avr-gcc.exe " +
                            "\" -Os " +
                            " -Wl,--gc-sections " +
                            " -mmcu=" + avrdud.mymicrocontroleur +
                            " " + objectpath +
                            " -o " + "   " + sourcenameelf + "  ";



            string commandeep = "\"" + avrPath + "\\bin" + "\\avr-objcopy.exe " + "\"" +
                               " -j .eeprom --change-section-lma .eeprom=0  " +
                               " -O ihex " +
                               " " + sourcenameelf + "  " +
                               "  " + sourcenameeep + "  ";


            string commandhex = "\"" + avrPath + "\\bin" + "\\avr-objcopy.exe " + "\"" +
                                " -j .text -j .data  " +
                                " -O ihex " +
                                "  " + sourcenameelf + "  " +
                                "   " + sourcenamehex;

            string commandsize = "\"" + avrPath + "\\bin" + "\\avr-size.exe " + "\"" +
                                 " -C " +
                                 " --mcu=" + avrdud.mymicrocontroleur +
                                 "  -t " + sourcenameelf + "  ";


            while (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync(command1);
                progressBar1.Value = 40;
                backgroundWorker1.Dispose();
                System.Threading.Thread.Sleep(5000);
                while (backgroundWorker2.IsBusy != true)
                {
                    backgroundWorker2.RunWorkerAsync(commandlinker);
                    progressBar1.Value = 60;
                    backgroundWorker2.Dispose();
                    System.Threading.Thread.Sleep(5000);
                    while (backgroundWorker3.IsBusy != true)
                    {
                        backgroundWorker3.RunWorkerAsync(commandeep);
                        backgroundWorker3.Dispose();
                        progressBar1.Value = 80;
                        System.Threading.Thread.Sleep(5000);
                        while (backgroundWorker4.IsBusy != true)
                        {
                            backgroundWorker4.RunWorkerAsync(commandhex);
                            backgroundWorker4.Dispose();
                            progressBar1.Value = 100;
                            while (backgroundWorker5.IsBusy != true)
                            {
                                backgroundWorker5.RunWorkerAsync(commandsize);
                                backgroundWorker5.Dispose();
                                progressBar1.Value = 100;
                            }
                        }
                    }
                }
            }


        }
        /// <summary>
        /// compilation de programme c++
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cppToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //enregestrement de projet automatique
            nom_projet = proj.project_name;
            progressBar1.Visible = true;
            texthex.Text = " AVrBoT Lab Education version 4.2 \n\r";
            string name = "app-avrbot";
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            System.IO.Directory.CreateDirectory(desktopPath + @"\" + name + @"\" + nom_projet);

            string auto_save = desktopPath + @"\" + name + @"\" + nom_projet + @"\" + nom_projet + ".cpp";

            StreamWriter sw = new StreamWriter(auto_save);
            sw.Write(startext.Text);
            sw.Close();
            //util de compilation 
            System.Threading.Thread.Sleep(1000);
            progressBar1.Value = 20;
            string avrPath = Path.GetFullPath("toolavrbot");
            string avrbasepath = (string)avrPath + "\\bin" + "\\";
            string objectfile = nom_projet + ".o";
            string elffile = nom_projet + ".elf";
            string hexfile = nom_projet + ".hex";
            string eepfile = nom_projet + ".eep";
            string lssfile = nom_projet + ".lss";
            string outfile = nom_projet + ".out";
            string applicationfile = desktopPath + @"\" + name + @"\" + nom_projet;
            string objectpath = System.IO.Path.Combine(applicationfile, objectfile);
            string sourcename = applicationfile + "\\" + nom_projet + ".cpp";
            string sourcenameelf = System.IO.Path.Combine(applicationfile, elffile);
            string sourcenameeep = System.IO.Path.Combine(applicationfile, eepfile);
            string sourcenamehex = System.IO.Path.Combine(applicationfile, hexfile);
            string sourcenameout = System.IO.Path.Combine(applicationfile, outfile);


            //compile 
            string command1 = "\"" + avrPath + "\\bin" + "\\avr-g++.exe " +
                              "\" -c" + // compile, don't link 
                              " -g " + // include debugging info (so errors include line numbers)
                //  optimize for size
                              " -fno-branch-count-reg -fno-default-inline  -fno-defer-pop" +
                              " -fno-function-cse  -fno-guess-branch-probability -fno-inline  " +
                              " -Os" +
                              " -Wall" + // surpress all warnings
                              " -ffunction-sections " + // place each function in its own section
                              " -fdata-sections " +
                              " -mmcu=" + avrdud.mymicrocontroleur +
                              " " + (string)sourcename +
                              " -o " + objectpath + "  ";



            string commandlinker = "\"" + avrPath + "\\bin" + "\\avr-gcc.exe " +
                            "\" -Os " +
                            " -Wl,--gc-sections " +
                            " -mmcu=" + avrdud.mymicrocontroleur +
                            " " + objectpath +
                            " -o " + "   " + sourcenameelf + "  ";



            string commandeep = "\"" + avrPath + "\\bin" + "\\avr-objcopy.exe " + "\"" +
                               " -j .eeprom --change-section-lma .eeprom=0  " +
                               " -O ihex " +
                               " " + sourcenameelf + "  " +
                               "  " + sourcenameeep + "  ";


            string commandhex = "\"" + avrPath + "\\bin" + "\\avr-objcopy.exe " + "\"" +
                                " -j .text -j .data  " +
                                " -O ihex " +
                                "  " + sourcenameelf + "  " +
                                "   " + sourcenamehex;

            string commandsize = "\"" + avrPath + "\\bin" + "\\avr-size.exe " + "\"" +
                                " -C " +
                                 " --mcu=" + avrdud.mymicrocontroleur +
                                "  -t " + sourcenameelf + "  ";


            while (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync(command1);
                progressBar1.Value = 40;
                backgroundWorker1.Dispose();
                System.Threading.Thread.Sleep(5000);
                while (backgroundWorker2.IsBusy != true)
                {
                    backgroundWorker2.RunWorkerAsync(commandlinker);
                    progressBar1.Value = 60;
                    backgroundWorker2.Dispose();
                    System.Threading.Thread.Sleep(5000);
                    while (backgroundWorker3.IsBusy != true)
                    {
                        backgroundWorker3.RunWorkerAsync(commandeep);
                        backgroundWorker3.Dispose();
                        progressBar1.Value = 80;
                        System.Threading.Thread.Sleep(5000);
                        while (backgroundWorker4.IsBusy != true)
                        {
                            backgroundWorker4.RunWorkerAsync(commandhex);
                            backgroundWorker4.Dispose();
                            progressBar1.Value = 100;
                            while (backgroundWorker5.IsBusy != true)
                            {
                                backgroundWorker5.RunWorkerAsync(commandsize);
                                backgroundWorker5.Dispose();
                                progressBar1.Value = 100;
                            }
                        }
                    }
                }
            }

        }
        //finir le processus
        private void finishedProcess(string output)
        {
            // retour de fonction 
            progressBar1.Visible = false;
            texthex.Text += output;
            texthex.Cursor = Cursors.IBeam;
            texthex.SelectionStart = texthex.Text.Length;
            texthex.ScrollToCaret();


        }

        private void aVrBoTPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nom_projet = proj.project_name;
            auteur = proj.auteur;
            String buildPath = "app-avrbot";
            CreateResultFolder(ref buildPath);
            try
            {
                startext.Text = "";
                labelconnexion.Text = "Session de programmation";
                actualiser_Click(sender, e);
                startext.Show();
                texthex.Show();
                startext.Text = "/**********************projet:" + nom_projet + "*******************/"+"\n"
                                + "/*******************realisé par:" + auteur + "*******************/" + "\n"
                                +"#include <avr/io.h>" + "\n"
                                + "#include <util/delay.h>" + "\n"
                                +"#define F_CPU 1000000UL"+"\n"
                                + "//definir les variables" + "\n"
                                + "int main (void)" + "\n"
                                + "{" + "\n"
                                + "///definir les entrees et les sorties" + "\n"
                                + "while (1)" + "\n"
                                + "{" + "\n"
                                + "//entrer le code ici" + "\n"
                                
                                + "}" + "\n"
                                + "}" + "\n";
                texthex.Text = "";
                activemenu(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void aVRCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nom_projet = proj.project_name;
            auteur = proj.auteur;
            startext.Text = "";
            String buildPath = "app-avrbot";
            CreateResultFolder(ref buildPath);
            try
            {
                labelconnexion.Text = "Session de programmation";
                actualiser_Click(sender, e);
                startext.Show();
                texthex.Show();
                startext.Text = "/**************************projet:" + nom_projet +"*********************/"+ "\n"
                                + "/***********************realisé par:" + auteur + "**********************/" + "\n" 
                                +"#include <avrbot.h>" + "\n"
                                + "//definir les variables" + "\n"
                                + "int main ( void )" + "\n"
                                + "{" + "\n"
                                + "//config_port_sortie(1)" + "\n"
                                + "while (1)" + "\n"
                                + "{" + "\n"
                                + "//entrer le code ici" + "\n"
                                + "//port_sortie(1,1)" + "\n"
                                + "}" + "\n"
                                + "}" + "\n";
                texthex.Text = "";
                activemenu(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// communication serie RS232...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nouveauConnexionToolStripMenuItem_Click(sender, e);
        }
        /// <summary>
        /// communication blueTouth
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bLUTTOUTHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            labelconnexion.Text = "Session de communication BlueTouth";
            bl.ShowDialog();
        }

        private void wIFIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            labelconnexion.Text = "Session de communication wifi";
            wifi.ShowDialog();
        }

        private void tCPIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            labelconnexion.Text = "Session de communication tcp/ip";
            MyTCP.ShowDialog();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
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

        private void intercativeCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //enregestrement de projet automatique
            nom_projet = proj.project_name;
            progressBar1.Visible = true;
            texthex.Text = " AVrBoT Lab Education version 4.2 \n\r";
            string name = "app-avrbot";
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            System.IO.Directory.CreateDirectory(desktopPath + @"\" + name+@"\"+nom_projet);

            string auto_save = desktopPath + @"\" + name + @"\" + nom_projet+@"\" + nom_projet+".c";

            StreamWriter sw = new StreamWriter(auto_save);
             sw.Write(startext.Text);
             sw.Close();
            //util de compilation 
            System.Threading.Thread.Sleep(1000);
            progressBar1.Value = 20;
            string avrPath = Path.GetFullPath("toolavrbot");
            string avrbasepath = (string)avrPath + "\\bin" + "\\";
            string objectfile = nom_projet + ".o";
            string elffile = nom_projet + ".elf";
            string hexfile = nom_projet + ".hex";
            string eepfile = nom_projet + ".eep";
            string lssfile = nom_projet + ".lss";
            string outfile = nom_projet + ".out";
            string applicationfile = desktopPath + @"\" + name + @"\" + nom_projet;
            string objectpath = System.IO.Path.Combine(applicationfile, objectfile);
            string sourcename = applicationfile + "\\" + nom_projet + ".c";
            string sourcenameelf = System.IO.Path.Combine(applicationfile, elffile);
            string sourcenameeep = System.IO.Path.Combine(applicationfile, eepfile);
            string sourcenamehex = System.IO.Path.Combine(applicationfile, hexfile);
            string sourcenameout = System.IO.Path.Combine(applicationfile, outfile);



            //compile 
            string command1 = "\"" + avrPath + "\\bin" + "\\avr-gcc.exe " +
                              "\" -c" + // compile, don't link 
                              " -g " + // include debugging info (so errors include line numbers)
                //  optimize for size
                              " -fno-branch-count-reg -fno-default-inline  -fno-defer-pop" +
                              " -fno-function-cse  -fno-guess-branch-probability -fno-inline  " +
                              " -Os" +
                              " -w" + // surpress all warnings
                              " -ffunction-sections " + // place each function in its own section
                              " -fdata-sections " +
                              " -mmcu=" + avrdud.mymicrocontroleur +
                              " " + (string)sourcename +
                              " -o " + objectpath + "  ";



            string commandlinker = "\"" + avrPath + "\\bin" + "\\avr-gcc.exe " +
                            "\" -Os " +
                            " -Wl,--gc-sections " +
                            " -mmcu=" + avrdud.mymicrocontroleur +
                            " " + objectpath +
                            " -o " + "   " + sourcenameelf + "  ";



            string commandeep = "\"" + avrPath + "\\bin" + "\\avr-objcopy.exe " + "\"" +
                               " -j .eeprom --change-section-lma .eeprom=0  " +
                               " -O ihex " +
                               " " + sourcenameelf + "  " +
                               "  " + sourcenameeep + "  ";


            string commandhex = "\"" + avrPath + "\\bin" + "\\avr-objcopy.exe " + "\"" +
                                " -j .text -j .data  " +
                                " -O ihex " +
                                "  " + sourcenameelf + "  " +
                                "   " + sourcenamehex;

            string commandsize = "\"" + avrPath + "\\bin" + "\\avr-size.exe " + "\"" +
                                 " -C " +
                                 " --mcu=" + avrdud.mymicrocontroleur +
                                 "  -t " + sourcenameelf + "  ";


            while (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync(command1);
                progressBar1.Value = 40;
                backgroundWorker1.Dispose();
                System.Threading.Thread.Sleep(5000);
                while (backgroundWorker2.IsBusy != true)
                {
                    backgroundWorker2.RunWorkerAsync(commandlinker);
                    progressBar1.Value = 60;
                    backgroundWorker2.Dispose();
                    System.Threading.Thread.Sleep(5000);
                    while (backgroundWorker3.IsBusy != true)
                    {
                        backgroundWorker3.RunWorkerAsync(commandeep);
                        backgroundWorker3.Dispose();
                        progressBar1.Value = 80;
                        System.Threading.Thread.Sleep(5000);
                        while (backgroundWorker4.IsBusy != true)
                        {
                            backgroundWorker4.RunWorkerAsync(commandhex);
                            backgroundWorker4.Dispose();
                            progressBar1.Value = 100;
                            while (backgroundWorker5.IsBusy != true)
                            {
                                backgroundWorker5.RunWorkerAsync(commandsize);
                                backgroundWorker5.Dispose();
                                progressBar1.Value = 100;
                            }
                        }
                    }
                }
            }



        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
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


            Invoke(new finishedProcessDelegate(finishedProcess), "");

        }

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
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


            Invoke(new finishedProcessDelegate(finishedProcess), "");
        }

        private void backgroundWorker4_DoWork(object sender, DoWorkEventArgs e)
        {
            //Réponse par defaut

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


            Invoke(new finishedProcessDelegate(finishedProcess), "");
        }

        private void AVrBoT_4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void backgroundWorker5_DoWork(object sender, DoWorkEventArgs e)
        {
            //Réponse par defaut

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




        private void DrawLines(Graphics g, int firstLine)
        {
            // Number of text lines
            int linesCount = startext.Lines.Length;

            // Last visible line (used to determine numbers panel width)
            int lastChar = this.startext.GetCharIndexFromPosition(new Point(this.startext.ClientRectangle.Width, this.startext.ClientRectangle.Height));
            int lastLine = this.startext.GetLineFromCharIndex(lastChar);

            // Line numbers layout (position, width)
            int rightMargin = 2, leftMargin = 5, topMargin = 2, bottomMargin = 15, verticalMargin = 2;
            SizeF maxTextSize = g.MeasureString(new string((char)48, lastLine.ToString().Length), this.startext.Font);
            this.panelNum.Width = (int)maxTextSize.Width + leftMargin + rightMargin;

            // Clear existing numbers
            g.Clear(this.panelNum.BackColor);

            // First line name
            int lineNumber = firstLine + 1;

            // Y position for first line number
            int firstLineY = this.startext.GetPositionFromCharIndex(this.startext.GetFirstCharIndexFromLine(firstLine)).Y;
            int lineY = topMargin + firstLineY;

            // Write all visible line numbers
            while (true)
            {
                // Draw line number string
                string lineNumberLabel = lineNumber.ToString().PadLeft(lastLine.ToString().Length);
                g.DrawString(lineNumberLabel, this.startext.Font, Brushes.Black, leftMargin, lineY);

                // Next line
                lineNumber += 1;
                lineY += Font.Height + verticalMargin;

                // End of numeration if and of text content or end of RichTextBox height
                if (lineY > ClientRectangle.Height - bottomMargin || lineNumber > linesCount)
                    break;
            }
        }

        private void panelNum_Paint(object sender, PaintEventArgs e)
        {

            // Update the line numbers
            int firstChar = this.startext.GetCharIndexFromPosition(new Point(0, 0));
            int firstLine = this.startext.GetLineFromCharIndex(firstChar);

            DrawLines(e.Graphics, firstLine);
        }

        private void AVrBoT_4_Load(object sender, EventArgs e)
        {
            
            // Required properties
            this.startext.ScrollBars = RichTextBoxScrollBars.Both;
            this.startext.WordWrap = false;

            // Required events
            this.startext.SelectionChanged += new System.EventHandler(this.startext_SelectionChanged_1);
            this.startext.VScroll += new System.EventHandler(this.startext_VScroll);
            this.panelNum.Paint += new PaintEventHandler(this.panelNum_Paint);
           


            
        }

        private void startext_SelectionChanged_1(object sender, EventArgs e)
        {

            this.panelNum.Invalidate(); // Request repaint => line numbers update
            
        }

        private void startext_VScroll(object sender, EventArgs e)
        {
            this.panelNum.Invalidate(); // Request repaint => line numbers update
        }

        private void startext_TextChanged_1(object sender, EventArgs e)
        {
            
               
               
          
        }

        private void clignotementLedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startext.Text = "";
            StreamReader sr = new StreamReader("exemple_clignotement_led.txt");
                while (!sr.EndOfStream)
                {
                    startext.Text += sr.ReadLine() + "\r\n";
                }
            sr.Close();

            proj.project_name ="demo_led";
        }

        private void brasRobotiqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startext.Text = "";
            StreamReader sr = new StreamReader("exemple_commande_bras_robotique.txt");
            while (!sr.EndOfStream)
            {
                startext.Text += sr.ReadLine() + "\r\n";
            }
            sr.Close();
            proj.project_name = "demo_bras";
        }

        private void ascenseurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startext.Text = "";
            StreamReader sr = new StreamReader("exemple_prog_ascenseur.txt");
            while (!sr.EndOfStream)
            {
                startext.Text += sr.ReadLine() + "\r\n";
            }
            sr.Close();
            proj.project_name = "demo_ascenseur";
        }

        private void moteurPasAPasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startext.Text = "";
            StreamReader sr = new StreamReader("exemple_commande_moteur_pap_vitesse.txt");
            while (!sr.EndOfStream)
            {
                startext.Text += sr.ReadLine() + "\r\n";
            }
            sr.Close();
            proj.project_name = "demo_moteur_pap";
        }

        
        private void texthex_MouseClick(object sender, MouseEventArgs e)
        {
           /*
                int firstcharindex = texthex.GetFirstCharIndexOfCurrentLine();
                int currentline = texthex.GetLineFromCharIndex(firstcharindex);
                string currentlinetext = texthex.Lines[currentline];
                texthex.Select(firstcharindex, currentlinetext.Length);
            */
        }

        private void texthex_TextChanged(object sender, EventArgs e)
        {
            texthex.Text = texthex.Text.Replace("Microsoft Windows", "AVrBoT  Editeur pour Windows");
            texthex.Text = texthex.Text.Replace("Microsoft Corporation.", "AVrBoT Lab Eduction ");
            texthex.Text = texthex.Text.Replace("2009", "2014 ");
            texthex.Text = texthex.Text.Replace("2010", "2014 ");
            texthex.Text = texthex.Text.Replace("2011", "2014 ");
            texthex.Text = texthex.Text.Replace("2012", "2014 ");
            texthex.Text = texthex.Text.Replace("20013", "2014 ");

        }
        private void exist_systeme(object sender, EventArgs e)
        {

            if (MessageBox.Show("AVrBoT Lab Education ", "vous voulez vraiment quiter \n\r", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                Application.Exit();

            }
        }
        /// <summary>
        /// variable global pour controler le header file
        /// </summary>
        public string nomheaderfile = "avrbot.h";
        
        private void ecrireLeFichierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // nommer le fichier 
            startext.Text = "avrbot.h";
            nomheaderfile = startext.Text;
            
        }

        private void inclureDansLeSystèmeToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //ecrire le fichier 
            startext.Text = "";
            string avrPath = Path.GetFullPath("toolavrbot");
            string includepach = avrPath + @"\avr" + @"\include"+@"\"+nomheaderfile;
            startext.Text = "/*************fichier developpé par " + auteur +"***********************/" + "\n" +
                           "/************pour le projet " + nom_projet + "**************************/" + "\n" +
                            "/**********nom de fichier " + nomheaderfile + "***********************/" + "\n" +
                            "#ifndef " + nomheaderfile + "_H" + "\n" +
                            "#define " + nomheaderfile + " _H" + "\n" +
                            "//**********************************definir les includes utilisés ici " + "\n" +
                            "//**********************************developper les fonction ici" +"\n"+
                            "#endif" + "\n";

        }

        private void inclureDansLeSystèmeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
         // inclure le fichier 
            try
            {
                string avrPath = Path.GetFullPath("toolavrbot");
                string includepach = avrPath + @"\avr" + @"\include" + @"\" + nomheaderfile;
                StreamWriter sw = new StreamWriter(includepach);
                sw.Write(startext.Text);
                sw.Close();
                texthex.Text = "le fichier est bien inclue dans le systeme";
            }
            catch { texthex.Text = "impossible d'inclure dans le systeme, refaire et verifier le nom de fichier"; }
        }
         
        

        private void startext_DoubleClick(object sender, EventArgs e)
        {
            nomheaderfile = startext.Text;
        }
        //ouvrir une fichier header pour le modification
        private void ouvrirLeFichierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string avrPath = Path.GetFullPath("toolavrbot");
                string includepach = avrPath + @"\avr" + @"\include" + @"\" + nomheaderfile;
                StreamReader sr = new StreamReader(includepach);
                startext.Text = "";
                while (!sr.EndOfStream)
                {
                    startext.Text += sr.ReadLine() + "\r\n";
                }
                sr.Close();

            }
            catch { texthex.Text = "fichier introuvable"; }
        }

        private void nommerLeFichierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // nommer le fichier 
            startext.Text = "avrbot.h";
            nomheaderfile = startext.Text;
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startext.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startext.Redo();
        }

       

       
    }
    }

