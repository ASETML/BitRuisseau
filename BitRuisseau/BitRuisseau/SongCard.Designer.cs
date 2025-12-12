namespace BitRuisseau
{
    partial class SongCard
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
            lbl_title_artist = new Label();
            lbl_year_duration_size = new Label();
            lbl_featuring = new Label();
            btn_download = new Button();
            SuspendLayout();
            // 
            // lbl_title_artist
            // 
            lbl_title_artist.AutoSize = true;
            lbl_title_artist.Location = new Point(3, 0);
            lbl_title_artist.Name = "lbl_title_artist";
            lbl_title_artist.Size = new Size(75, 15);
            lbl_title_artist.TabIndex = 0;
            lbl_title_artist.Text = "Titre - Artiste";
            // 
            // lbl_year_duration_size
            // 
            lbl_year_duration_size.AutoSize = true;
            lbl_year_duration_size.Location = new Point(3, 15);
            lbl_year_duration_size.Name = "lbl_year_duration_size";
            lbl_year_duration_size.Size = new Size(120, 15);
            lbl_year_duration_size.TabIndex = 2;
            lbl_year_duration_size.Text = "Année - Durée - Taille";
            // 
            // lbl_featuring
            // 
            lbl_featuring.AutoSize = true;
            lbl_featuring.Location = new Point(3, 30);
            lbl_featuring.Name = "lbl_featuring";
            lbl_featuring.Size = new Size(57, 15);
            lbl_featuring.TabIndex = 5;
            lbl_featuring.Text = "Featuring";
            // 
            // btn_download
            // 
            btn_download.Location = new Point(229, 3);
            btn_download.Name = "btn_download";
            btn_download.Size = new Size(19, 23);
            btn_download.TabIndex = 6;
            btn_download.Text = "↓";
            btn_download.UseVisualStyleBackColor = true;
            btn_download.Click += btn_download_Click;
            // 
            // SongCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(btn_download);
            Controls.Add(lbl_featuring);
            Controls.Add(lbl_year_duration_size);
            Controls.Add(lbl_title_artist);
            Name = "SongCard";
            Size = new Size(251, 53);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_title_artist;
        private Label lbl_year_duration_size;
        private Label lbl_featuring;
        private Button btn_download;
    }
}
