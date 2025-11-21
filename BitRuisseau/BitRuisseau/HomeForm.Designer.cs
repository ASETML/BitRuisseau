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
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(flp_localList);
            Controls.Add(lbl_selectedFolder);
            Controls.Add(btn_selectFolder);
            Name = "HomeForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_selectFolder;
        private Label lbl_selectedFolder;
        private FlowLayoutPanel flp_localList;
    }
}
