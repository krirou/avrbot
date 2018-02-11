namespace AVrBoT_v4
{
    partial class MyWifi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyWifi));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.wifitext = new System.Windows.Forms.RichTextBox();
            this.msgwifi = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.WindowText;
            this.listBox1.ForeColor = System.Drawing.Color.Lime;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 49);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(394, 56);
            this.listBox1.TabIndex = 0;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(349, 26);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(62, 17);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Serveur";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(12, 26);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(51, 17);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Client";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(65, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(278, 24);
            this.button1.TabIndex = 3;
            this.button1.Text = "Connecter";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // wifitext
            // 
            this.wifitext.BackColor = System.Drawing.SystemColors.WindowText;
            this.wifitext.ForeColor = System.Drawing.Color.Lime;
            this.wifitext.Location = new System.Drawing.Point(12, 111);
            this.wifitext.Name = "wifitext";
            this.wifitext.Size = new System.Drawing.Size(212, 86);
            this.wifitext.TabIndex = 4;
            this.wifitext.Text = "";
            // 
            // msgwifi
            // 
            this.msgwifi.BackColor = System.Drawing.SystemColors.WindowText;
            this.msgwifi.ForeColor = System.Drawing.Color.Blue;
            this.msgwifi.Location = new System.Drawing.Point(230, 111);
            this.msgwifi.Name = "msgwifi";
            this.msgwifi.Size = new System.Drawing.Size(176, 86);
            this.msgwifi.TabIndex = 5;
            this.msgwifi.Text = "";
            // 
            // MyWifi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 195);
            this.Controls.Add(this.msgwifi);
            this.Controls.Add(this.wifitext);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.listBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(434, 233);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(434, 233);
            this.Name = "MyWifi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MyWifi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox wifitext;
        private System.Windows.Forms.RichTextBox msgwifi;
    }
}