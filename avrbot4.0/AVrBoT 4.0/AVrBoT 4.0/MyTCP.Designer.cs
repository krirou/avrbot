namespace AVrBoT_v4
{
    partial class MyTCP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyTCP));
            this.button1 = new System.Windows.Forms.Button();
            this.textsend = new System.Windows.Forms.RichTextBox();
            this.textinfo = new System.Windows.Forms.RichTextBox();
            this.textread = new System.Windows.Forms.RichTextBox();
            this.textip = new System.Windows.Forms.RichTextBox();
            this.textport = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(394, 24);
            this.button1.TabIndex = 1;
            this.button1.Text = "Connecter";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textsend
            // 
            this.textsend.BackColor = System.Drawing.SystemColors.WindowText;
            this.textsend.ForeColor = System.Drawing.Color.Lime;
            this.textsend.Location = new System.Drawing.Point(12, 74);
            this.textsend.Name = "textsend";
            this.textsend.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.textsend.Size = new System.Drawing.Size(276, 60);
            this.textsend.TabIndex = 4;
            this.textsend.Text = "";
            // 
            // textinfo
            // 
            this.textinfo.BackColor = System.Drawing.SystemColors.WindowText;
            this.textinfo.ForeColor = System.Drawing.Color.Red;
            this.textinfo.Location = new System.Drawing.Point(293, 74);
            this.textinfo.Name = "textinfo";
            this.textinfo.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.textinfo.Size = new System.Drawing.Size(113, 122);
            this.textinfo.TabIndex = 5;
            this.textinfo.Text = "";
            this.textinfo.UseWaitCursor = true;
            // 
            // textread
            // 
            this.textread.BackColor = System.Drawing.SystemColors.WindowText;
            this.textread.ForeColor = System.Drawing.Color.Lime;
            this.textread.Location = new System.Drawing.Point(11, 133);
            this.textread.Name = "textread";
            this.textread.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.textread.Size = new System.Drawing.Size(277, 63);
            this.textread.TabIndex = 6;
            this.textread.Text = "";
            // 
            // textip
            // 
            this.textip.BackColor = System.Drawing.SystemColors.WindowText;
            this.textip.ForeColor = System.Drawing.Color.Lime;
            this.textip.Location = new System.Drawing.Point(12, 42);
            this.textip.Name = "textip";
            this.textip.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.textip.Size = new System.Drawing.Size(276, 26);
            this.textip.TabIndex = 7;
            this.textip.Text = "192.168.1.102";
            // 
            // textport
            // 
            this.textport.BackColor = System.Drawing.SystemColors.WindowText;
            this.textport.ForeColor = System.Drawing.Color.Lime;
            this.textport.Location = new System.Drawing.Point(294, 42);
            this.textport.Name = "textport";
            this.textport.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.textport.Size = new System.Drawing.Size(112, 26);
            this.textport.TabIndex = 8;
            this.textport.Text = "8080";
            // 
            // MyTCP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 195);
            this.Controls.Add(this.textport);
            this.Controls.Add(this.textip);
            this.Controls.Add(this.textread);
            this.Controls.Add(this.textinfo);
            this.Controls.Add(this.textsend);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(434, 233);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(434, 233);
            this.Name = "MyTCP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MyTCP";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox textsend;
        private System.Windows.Forms.RichTextBox textinfo;
        private System.Windows.Forms.RichTextBox textread;
        private System.Windows.Forms.RichTextBox textip;
        private System.Windows.Forms.RichTextBox textport;
    }
}