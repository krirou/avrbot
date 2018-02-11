namespace AVrBoT_v4
{
    partial class BlueTouth
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlueTouth));
            this.CLient = new System.Windows.Forms.RadioButton();
            this.serveur = new System.Windows.Forms.RadioButton();
            this.bltexte = new System.Windows.Forms.RichTextBox();
            this.LB = new System.Windows.Forms.ListBox();
            this.msgtexte = new System.Windows.Forms.RichTextBox();
            this.connecter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CLient
            // 
            this.CLient.AutoSize = true;
            this.CLient.Location = new System.Drawing.Point(12, 12);
            this.CLient.Name = "CLient";
            this.CLient.Size = new System.Drawing.Size(53, 17);
            this.CLient.TabIndex = 0;
            this.CLient.TabStop = true;
            this.CLient.Text = "Cllient";
            this.CLient.UseVisualStyleBackColor = true;
            // 
            // serveur
            // 
            this.serveur.AutoSize = true;
            this.serveur.Location = new System.Drawing.Point(346, 15);
            this.serveur.Name = "serveur";
            this.serveur.Size = new System.Drawing.Size(62, 17);
            this.serveur.TabIndex = 1;
            this.serveur.TabStop = true;
            this.serveur.Text = "Serveur";
            this.serveur.UseVisualStyleBackColor = true;
            // 
            // bltexte
            // 
            this.bltexte.BackColor = System.Drawing.SystemColors.WindowText;
            this.bltexte.ForeColor = System.Drawing.Color.Chartreuse;
            this.bltexte.Location = new System.Drawing.Point(12, 102);
            this.bltexte.Name = "bltexte";
            this.bltexte.Size = new System.Drawing.Size(212, 93);
            this.bltexte.TabIndex = 3;
            this.bltexte.Text = "";
            this.bltexte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.bltexte_KeyPress);
            // 
            // LB
            // 
            this.LB.BackColor = System.Drawing.SystemColors.WindowText;
            this.LB.ForeColor = System.Drawing.Color.LimeGreen;
            this.LB.FormattingEnabled = true;
            this.LB.Location = new System.Drawing.Point(12, 38);
            this.LB.Name = "LB";
            this.LB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LB.ScrollAlwaysVisible = true;
            this.LB.Size = new System.Drawing.Size(394, 56);
            this.LB.TabIndex = 4;
            this.LB.DoubleClick += new System.EventHandler(this.LB_DoubleClick);
            // 
            // msgtexte
            // 
            this.msgtexte.BackColor = System.Drawing.SystemColors.WindowText;
            this.msgtexte.ForeColor = System.Drawing.Color.Red;
            this.msgtexte.Location = new System.Drawing.Point(230, 102);
            this.msgtexte.Name = "msgtexte";
            this.msgtexte.ReadOnly = true;
            this.msgtexte.Size = new System.Drawing.Size(176, 93);
            this.msgtexte.TabIndex = 5;
            this.msgtexte.Text = "";
            this.msgtexte.UseWaitCursor = true;
            // 
            // connecter
            // 
            this.connecter.Location = new System.Drawing.Point(62, 8);
            this.connecter.Name = "connecter";
            this.connecter.Size = new System.Drawing.Size(278, 24);
            this.connecter.TabIndex = 6;
            this.connecter.Text = "connecter";
            this.connecter.UseVisualStyleBackColor = true;
            this.connecter.Click += new System.EventHandler(this.connecter_Click);
            // 
            // BlueTouth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 195);
            this.Controls.Add(this.connecter);
            this.Controls.Add(this.msgtexte);
            this.Controls.Add(this.LB);
            this.Controls.Add(this.bltexte);
            this.Controls.Add(this.serveur);
            this.Controls.Add(this.CLient);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(434, 233);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(434, 233);
            this.Name = "BlueTouth";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BlueTouth";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton CLient;
        private System.Windows.Forms.RadioButton serveur;
        private System.Windows.Forms.RichTextBox bltexte;
        private System.Windows.Forms.ListBox LB;
        private System.Windows.Forms.RichTextBox msgtexte;
        private System.Windows.Forms.Button connecter;
    }
}