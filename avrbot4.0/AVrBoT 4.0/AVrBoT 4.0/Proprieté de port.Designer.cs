namespace AVrBoT_v4
{
    partial class Propriétés_de_port
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Propriétés_de_port));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.BaudRatecombobox = new System.Windows.Forms.ComboBox();
            this.DataBitscombobox = new System.Windows.Forms.ComboBox();
            this.Paritycombobox = new System.Windows.Forms.ComboBox();
            this.StopBitscombobox = new System.Windows.Forms.ComboBox();
            this.ReadTimeOutcombobox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vitesse en baude";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 65);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bits de données";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 99);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Parité";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 132);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Bits d\'arret";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 164);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Temps";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(165, 199);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 25);
            this.button1.TabIndex = 5;
            this.button1.Text = "ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(20, 199);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(56, 25);
            this.button2.TabIndex = 6;
            this.button2.Text = "Annuler";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // BaudRatecombobox
            // 
            this.BaudRatecombobox.FormattingEnabled = true;
            this.BaudRatecombobox.Items.AddRange(new object[] {
            "9600"});
            this.BaudRatecombobox.Location = new System.Drawing.Point(144, 32);
            this.BaudRatecombobox.Margin = new System.Windows.Forms.Padding(2);
            this.BaudRatecombobox.Name = "BaudRatecombobox";
            this.BaudRatecombobox.Size = new System.Drawing.Size(92, 21);
            this.BaudRatecombobox.TabIndex = 7;
            // 
            // DataBitscombobox
            // 
            this.DataBitscombobox.FormattingEnabled = true;
            this.DataBitscombobox.Items.AddRange(new object[] {
            "8"});
            this.DataBitscombobox.Location = new System.Drawing.Point(144, 65);
            this.DataBitscombobox.Margin = new System.Windows.Forms.Padding(2);
            this.DataBitscombobox.Name = "DataBitscombobox";
            this.DataBitscombobox.Size = new System.Drawing.Size(92, 21);
            this.DataBitscombobox.TabIndex = 8;
            // 
            // Paritycombobox
            // 
            this.Paritycombobox.FormattingEnabled = true;
            this.Paritycombobox.Items.AddRange(new object[] {
            "None"});
            this.Paritycombobox.Location = new System.Drawing.Point(144, 99);
            this.Paritycombobox.Margin = new System.Windows.Forms.Padding(2);
            this.Paritycombobox.Name = "Paritycombobox";
            this.Paritycombobox.Size = new System.Drawing.Size(92, 21);
            this.Paritycombobox.TabIndex = 9;
            // 
            // StopBitscombobox
            // 
            this.StopBitscombobox.FormattingEnabled = true;
            this.StopBitscombobox.Items.AddRange(new object[] {
            "One"});
            this.StopBitscombobox.Location = new System.Drawing.Point(144, 132);
            this.StopBitscombobox.Margin = new System.Windows.Forms.Padding(2);
            this.StopBitscombobox.Name = "StopBitscombobox";
            this.StopBitscombobox.Size = new System.Drawing.Size(92, 21);
            this.StopBitscombobox.TabIndex = 10;
            // 
            // ReadTimeOutcombobox
            // 
            this.ReadTimeOutcombobox.FormattingEnabled = true;
            this.ReadTimeOutcombobox.Items.AddRange(new object[] {
            "-1"});
            this.ReadTimeOutcombobox.Location = new System.Drawing.Point(144, 164);
            this.ReadTimeOutcombobox.Margin = new System.Windows.Forms.Padding(2);
            this.ReadTimeOutcombobox.Name = "ReadTimeOutcombobox";
            this.ReadTimeOutcombobox.Size = new System.Drawing.Size(92, 21);
            this.ReadTimeOutcombobox.TabIndex = 11;
            // 
            // Propriétés_de_port
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 234);
            this.Controls.Add(this.ReadTimeOutcombobox);
            this.Controls.Add(this.StopBitscombobox);
            this.Controls.Add(this.Paritycombobox);
            this.Controls.Add(this.DataBitscombobox);
            this.Controls.Add(this.BaudRatecombobox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Propriétés_de_port";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Proprietés de port";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.ComboBox BaudRatecombobox;
        public System.Windows.Forms.ComboBox DataBitscombobox;
        public System.Windows.Forms.ComboBox Paritycombobox;
        public System.Windows.Forms.ComboBox StopBitscombobox;
        public System.Windows.Forms.ComboBox ReadTimeOutcombobox;
    }
}