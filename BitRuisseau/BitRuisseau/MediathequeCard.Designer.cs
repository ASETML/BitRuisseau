namespace BitRuisseau
{
    partial class MediathequeCard
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

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            lbl_name = new Label();
            SuspendLayout();
            // 
            // lbl_name
            // 
            lbl_name.AutoSize = true;
            lbl_name.Location = new Point(0, 0);
            lbl_name.Name = "lbl_name";
            lbl_name.Size = new Size(55, 15);
            lbl_name.TabIndex = 0;
            lbl_name.Text = "lbl_name";
            // 
            // MediathequeCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(lbl_name);
            Name = "MediathequeCard";
            Size = new Size(251, 53);
            Click += MediathequeCard_Click;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_name;
    }
}
