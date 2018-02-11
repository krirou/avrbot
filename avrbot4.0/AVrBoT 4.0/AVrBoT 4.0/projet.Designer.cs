namespace AVrBoT_v4
{
    partial class projet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(projet));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nomauteur = new System.Windows.Forms.TextBox();
            this.nomprojet = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(60, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Auteur:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(60, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nom de projet :";
            // 
            // nomauteur
            // 
            this.nomauteur.ForeColor = System.Drawing.SystemColors.WindowText;
            this.nomauteur.Location = new System.Drawing.Point(180, 39);
            this.nomauteur.Name = "nomauteur";
            this.nomauteur.Size = new System.Drawing.Size(439, 20);
            this.nomauteur.TabIndex = 3;
            // 
            // nomprojet
            // 
            this.nomprojet.Location = new System.Drawing.Point(180, 84);
            this.nomprojet.Name = "nomprojet";
            this.nomprojet.Size = new System.Drawing.Size(439, 20);
            this.nomprojet.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(180, 136);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(439, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Entrer ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // projet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(684, 189);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.nomprojet);
            this.Controls.Add(this.nomauteur);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(700, 227);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(700, 227);
            this.Name = "projet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nouveau projet";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox nomauteur;
        public System.Windows.Forms.TextBox nomprojet;
        private System.Windows.Forms.Button button1;
    }
}