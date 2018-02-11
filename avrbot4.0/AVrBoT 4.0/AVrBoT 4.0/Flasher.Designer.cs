namespace AVrBoT_v4
{
    partial class Flasher
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Flasher));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelhex = new System.Windows.Forms.Label();
            this.buttonhex = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboClock = new System.Windows.Forms.ComboBox();
            this.comboBaud = new System.Windows.Forms.ComboBox();
            this.comboPorts = new System.Windows.Forms.ComboBox();
            this.comboChip = new System.Windows.Forms.ComboBox();
            this.comboProgrammer = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxCommande = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textHighByte = new System.Windows.Forms.TextBox();
            this.textLowByte = new System.Windows.Forms.TextBox();
            this.textExtendedByte = new System.Windows.Forms.TextBox();
            this.checkSetFuses = new System.Windows.Forms.CheckBox();
            this.textCommand = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openAVRDude = new System.Windows.Forms.OpenFileDialog();
            this.openConf = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.process = new System.Diagnostics.Process();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelhex);
            this.groupBox1.Controls.Add(this.buttonhex);
            this.groupBox1.Location = new System.Drawing.Point(9, 17);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(450, 39);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "fichier hex";
            // 
            // labelhex
            // 
            this.labelhex.AutoSize = true;
            this.labelhex.Location = new System.Drawing.Point(4, 22);
            this.labelhex.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelhex.Name = "labelhex";
            this.labelhex.Size = new System.Drawing.Size(0, 13);
            this.labelhex.TabIndex = 1;
            // 
            // buttonhex
            // 
            this.buttonhex.Location = new System.Drawing.Point(382, 11);
            this.buttonhex.Margin = new System.Windows.Forms.Padding(2);
            this.buttonhex.Name = "buttonhex";
            this.buttonhex.Size = new System.Drawing.Size(64, 25);
            this.buttonhex.TabIndex = 0;
            this.buttonhex.Text = "Ouvrir";
            this.buttonhex.UseVisualStyleBackColor = true;
            this.buttonhex.Click += new System.EventHandler(this.buttonhex_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox2);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.comboClock);
            this.groupBox2.Controls.Add(this.comboBaud);
            this.groupBox2.Controls.Add(this.comboPorts);
            this.groupBox2.Controls.Add(this.comboChip);
            this.groupBox2.Controls.Add(this.comboProgrammer);
            this.groupBox2.Location = new System.Drawing.Point(9, 61);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(150, 162);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Option";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(52, 142);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(15, 14);
            this.checkBox2.TabIndex = 2;
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(52, 111);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 144);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "ISP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 111);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "vitesse ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 76);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 47);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Uc";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Prog.";
            // 
            // comboClock
            // 
            this.comboClock.FormattingEnabled = true;
            this.comboClock.Items.AddRange(new object[] {
            "1000000"});
            this.comboClock.Location = new System.Drawing.Point(72, 138);
            this.comboClock.Margin = new System.Windows.Forms.Padding(2);
            this.comboClock.Name = "comboClock";
            this.comboClock.Size = new System.Drawing.Size(75, 21);
            this.comboClock.TabIndex = 9;
            // 
            // comboBaud
            // 
            this.comboBaud.FormattingEnabled = true;
            this.comboBaud.Items.AddRange(new object[] {
            "19200",
            "115200"});
            this.comboBaud.Location = new System.Drawing.Point(72, 106);
            this.comboBaud.Margin = new System.Windows.Forms.Padding(2);
            this.comboBaud.Name = "comboBaud";
            this.comboBaud.Size = new System.Drawing.Size(75, 21);
            this.comboBaud.TabIndex = 8;
            // 
            // comboPorts
            // 
            this.comboPorts.FormattingEnabled = true;
            this.comboPorts.Location = new System.Drawing.Point(55, 71);
            this.comboPorts.Margin = new System.Windows.Forms.Padding(2);
            this.comboPorts.Name = "comboPorts";
            this.comboPorts.Size = new System.Drawing.Size(92, 21);
            this.comboPorts.TabIndex = 7;
            // 
            // comboChip
            // 
            this.comboChip.FormattingEnabled = true;
            this.comboChip.Location = new System.Drawing.Point(55, 41);
            this.comboChip.Margin = new System.Windows.Forms.Padding(2);
            this.comboChip.Name = "comboChip";
            this.comboChip.Size = new System.Drawing.Size(92, 21);
            this.comboChip.TabIndex = 6;
            // 
            // comboProgrammer
            // 
            this.comboProgrammer.FormattingEnabled = true;
            this.comboProgrammer.Location = new System.Drawing.Point(55, 17);
            this.comboProgrammer.Margin = new System.Windows.Forms.Padding(2);
            this.comboProgrammer.Name = "comboProgrammer";
            this.comboProgrammer.Size = new System.Drawing.Size(92, 21);
            this.comboProgrammer.TabIndex = 5;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxCommande);
            this.groupBox3.Location = new System.Drawing.Point(164, 61);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(219, 90);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ajouter des commandes";
            // 
            // textBoxCommande
            // 
            this.textBoxCommande.Location = new System.Drawing.Point(4, 17);
            this.textBoxCommande.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCommande.Multiline = true;
            this.textBoxCommande.Name = "textBoxCommande";
            this.textBoxCommande.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxCommande.Size = new System.Drawing.Size(211, 69);
            this.textBoxCommande.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.textHighByte);
            this.groupBox4.Controls.Add(this.textLowByte);
            this.groupBox4.Controls.Add(this.textExtendedByte);
            this.groupBox4.Controls.Add(this.checkSetFuses);
            this.groupBox4.Location = new System.Drawing.Point(164, 156);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(219, 67);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(152, 56);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(18, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "0x";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(90, 56);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(18, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "0x";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(26, 56);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(18, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "0x";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(176, 28);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Ex.Bit";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(114, 28);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "H.Bit";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(50, 28);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "L.Bit";
            // 
            // textHighByte
            // 
            this.textHighByte.Location = new System.Drawing.Point(111, 50);
            this.textHighByte.Margin = new System.Windows.Forms.Padding(2);
            this.textHighByte.Name = "textHighByte";
            this.textHighByte.Size = new System.Drawing.Size(31, 20);
            this.textHighByte.TabIndex = 3;
            // 
            // textLowByte
            // 
            this.textLowByte.Location = new System.Drawing.Point(47, 49);
            this.textLowByte.Margin = new System.Windows.Forms.Padding(2);
            this.textLowByte.Name = "textLowByte";
            this.textLowByte.Size = new System.Drawing.Size(31, 20);
            this.textLowByte.TabIndex = 2;
            // 
            // textExtendedByte
            // 
            this.textExtendedByte.Location = new System.Drawing.Point(173, 49);
            this.textExtendedByte.Margin = new System.Windows.Forms.Padding(2);
            this.textExtendedByte.Name = "textExtendedByte";
            this.textExtendedByte.Size = new System.Drawing.Size(31, 20);
            this.textExtendedByte.TabIndex = 1;
            // 
            // checkSetFuses
            // 
            this.checkSetFuses.AutoSize = true;
            this.checkSetFuses.Location = new System.Drawing.Point(11, 9);
            this.checkSetFuses.Margin = new System.Windows.Forms.Padding(2);
            this.checkSetFuses.Name = "checkSetFuses";
            this.checkSetFuses.Size = new System.Drawing.Size(51, 17);
            this.checkSetFuses.TabIndex = 0;
            this.checkSetFuses.Text = "fuses";
            this.checkSetFuses.UseVisualStyleBackColor = true;
            this.checkSetFuses.CheckedChanged += new System.EventHandler(this.checkSetFuses_CheckedChanged);
            // 
            // textCommand
            // 
            this.textCommand.Location = new System.Drawing.Point(9, 228);
            this.textCommand.Margin = new System.Windows.Forms.Padding(2);
            this.textCommand.Name = "textCommand";
            this.textCommand.ReadOnly = true;
            this.textCommand.Size = new System.Drawing.Size(451, 20);
            this.textCommand.TabIndex = 4;
            this.textCommand.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textCommand_MouseDoubleClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(391, 61);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 37);
            this.button1.TabIndex = 5;
            this.button1.Text = "Aide config";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(391, 100);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(64, 30);
            this.button2.TabIndex = 6;
            this.button2.Text = "Aide cmd";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(391, 132);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(64, 28);
            this.button3.TabIndex = 7;
            this.button3.Text = "Arreter!";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(391, 165);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(64, 28);
            this.button4.TabIndex = 8;
            this.button4.Text = "Confirmer";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(391, 197);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(64, 26);
            this.button5.TabIndex = 9;
            this.button5.Text = "Charger";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "Fichier Hex";
            // 
            // openAVRDude
            // 
            this.openAVRDude.FileName = "avrdude";
            // 
            // openConf
            // 
            this.openConf.FileName = "Fichier config";
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            // 
            // process
            // 
            this.process.StartInfo.Domain = "";
            this.process.StartInfo.LoadUserProfile = false;
            this.process.StartInfo.Password = null;
            this.process.StartInfo.StandardErrorEncoding = null;
            this.process.StartInfo.StandardOutputEncoding = null;
            this.process.StartInfo.UserName = "";
            this.process.SynchronizingObject = this;
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBoxOutput.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.textBoxOutput.ForeColor = System.Drawing.Color.Lime;
            this.textBoxOutput.Location = new System.Drawing.Point(9, 251);
            this.textBoxOutput.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.ReadOnly = true;
            this.textBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxOutput.Size = new System.Drawing.Size(451, 61);
            this.textBoxOutput.TabIndex = 10;
            this.textBoxOutput.UseWaitCursor = true;
            this.textBoxOutput.TextChanged += new System.EventHandler(this.textBoxOutput_TextChanged);
            // 
            // Flasher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 319);
            this.Controls.Add(this.textBoxOutput);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textCommand);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(480, 357);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(480, 357);
            this.Name = "Flasher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Flasher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Flasher_FormClosing);
            this.Load += new System.EventHandler(this.Flasher_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelhex;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkSetFuses;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openAVRDude;
        private System.Windows.Forms.OpenFileDialog openConf;
        private System.Diagnostics.Process process;
        public System.Windows.Forms.Button buttonhex;
        public System.Windows.Forms.ComboBox comboClock;
        public System.Windows.Forms.ComboBox comboBaud;
        public System.Windows.Forms.ComboBox comboPorts;
        public System.Windows.Forms.ComboBox comboChip;
        public System.Windows.Forms.ComboBox comboProgrammer;
        public System.Windows.Forms.TextBox textBoxCommande;
        public System.Windows.Forms.TextBox textCommand;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.Button button3;
        public System.Windows.Forms.Button button4;
        public System.Windows.Forms.Button button5;
        public System.Windows.Forms.TextBox textHighByte;
        public System.Windows.Forms.TextBox textLowByte;
        public System.Windows.Forms.TextBox textExtendedByte;
        private System.Windows.Forms.TextBox textBoxOutput;
        public System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}