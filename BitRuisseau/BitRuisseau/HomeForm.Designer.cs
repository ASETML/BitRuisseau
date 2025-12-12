namespace BitRuisseau
{
    partial class HomeForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_selectFolder = new Button();
            lbl_selectedFolder = new Label();
            flp_localList = new FlowLayoutPanel();
            flp_mediathequesList = new FlowLayoutPanel();
            btn_loadMediatheques = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // btn_selectFolder
            // 
            btn_selectFolder.Location = new Point(12, 12);
            btn_selectFolder.Name = "btn_selectFolder";
            btn_selectFolder.Size = new Size(113, 23);
            btn_selectFolder.TabIndex = 0;
            btn_selectFolder.Text = "Choisir un dossier";
            btn_selectFolder.UseVisualStyleBackColor = true;
            btn_selectFolder.Click += btn_selectFolder_Click;
            // 
            // lbl_selectedFolder
            // 
            lbl_selectedFolder.AutoSize = true;
            lbl_selectedFolder.Location = new Point(143, 16);
            lbl_selectedFolder.Name = "lbl_selectedFolder";
            lbl_selectedFolder.Size = new Size(10, 15);
            lbl_selectedFolder.TabIndex = 1;
            lbl_selectedFolder.Text = " ";
            // 
            // flp_localList
            // 
            flp_localList.AutoScroll = true;
            flp_localList.FlowDirection = FlowDirection.TopDown;
            flp_localList.Location = new Point(12, 41);
            flp_localList.Name = "flp_localList";
            flp_localList.Size = new Size(280, 397);
            flp_localList.TabIndex = 2;
            flp_localList.WrapContents = false;
            // 
            // flp_mediathequesList
            // 
            flp_mediathequesList.AutoScroll = true;
            flp_mediathequesList.FlowDirection = FlowDirection.TopDown;
            flp_mediathequesList.Location = new Point(298, 41);
            flp_mediathequesList.Name = "flp_mediathequesList";
            flp_mediathequesList.Size = new Size(280, 397);
            flp_mediathequesList.TabIndex = 3;
            flp_mediathequesList.WrapContents = false;
            // 
            // btn_loadMediatheques
            // 
            btn_loadMediatheques.Location = new Point(298, 12);
            btn_loadMediatheques.Name = "btn_loadMediatheques";
            btn_loadMediatheques.Size = new Size(197, 23);
            btn_loadMediatheques.TabIndex = 4;
            btn_loadMediatheques.Text = "Charger les médiathèques en ligne";
            btn_loadMediatheques.UseVisualStyleBackColor = true;
            btn_loadMediatheques.Click += btn_loadMediatheques_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(584, 41);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(280, 397);
            flowLayoutPanel1.TabIndex = 3;
            flowLayoutPanel1.WrapContents = false;
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(868, 450);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(btn_loadMediatheques);
            Controls.Add(flp_mediathequesList);
            Controls.Add(flp_localList);
            Controls.Add(lbl_selectedFolder);
            Controls.Add(btn_selectFolder);
            Name = "HomeForm";
            Text = "BitRuisseau";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_selectFolder;
        private Label lbl_selectedFolder;
        private FlowLayoutPanel flp_localList;
        private FlowLayoutPanel flp_mediathequesList;
        private Button btn_loadMediatheques;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}
