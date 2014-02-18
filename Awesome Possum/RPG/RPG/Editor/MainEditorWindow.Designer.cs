namespace RPG.Editor
{
    partial class MainEditorWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.WorldMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.NewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.LevelMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.BackgroundList = new System.Windows.Forms.ListBox();
            this.BackgroundGroup = new System.Windows.Forms.GroupBox();
            this.DeleteBackground = new System.Windows.Forms.Button();
            this.MusicGroup = new System.Windows.Forms.GroupBox();
            this.DeleteMusic = new System.Windows.Forms.Button();
            this.MusicList = new System.Windows.Forms.ListBox();
            this.AddLevelMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.BackgroundGroup.SuspendLayout();
            this.MusicGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WorldMenu,
            this.AddLevelMenu,
            this.LevelMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(669, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // WorldMenu
            // 
            this.WorldMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewMenu,
            this.OpenMenu,
            this.SaveMenu});
            this.WorldMenu.Name = "WorldMenu";
            this.WorldMenu.Size = new System.Drawing.Size(51, 20);
            this.WorldMenu.Text = "World";
            // 
            // NewMenu
            // 
            this.NewMenu.Name = "NewMenu";
            this.NewMenu.Size = new System.Drawing.Size(152, 22);
            this.NewMenu.Text = "New";
            this.NewMenu.Click += new System.EventHandler(this.NewMenu_Click);
            // 
            // OpenMenu
            // 
            this.OpenMenu.Name = "OpenMenu";
            this.OpenMenu.Size = new System.Drawing.Size(152, 22);
            this.OpenMenu.Text = "Open";
            this.OpenMenu.Click += new System.EventHandler(this.OpenMenu_Click);
            // 
            // SaveMenu
            // 
            this.SaveMenu.Enabled = false;
            this.SaveMenu.Name = "SaveMenu";
            this.SaveMenu.Size = new System.Drawing.Size(152, 22);
            this.SaveMenu.Text = "Save";
            this.SaveMenu.Click += new System.EventHandler(this.SaveMenu_Click);
            // 
            // LevelMenu
            // 
            this.LevelMenu.Enabled = false;
            this.LevelMenu.Name = "LevelMenu";
            this.LevelMenu.Size = new System.Drawing.Size(51, 20);
            this.LevelMenu.Text = "Levels";
            // 
            // BackgroundList
            // 
            this.BackgroundList.FormattingEnabled = true;
            this.BackgroundList.Location = new System.Drawing.Point(6, 19);
            this.BackgroundList.Name = "BackgroundList";
            this.BackgroundList.Size = new System.Drawing.Size(180, 95);
            this.BackgroundList.TabIndex = 1;
            // 
            // BackgroundGroup
            // 
            this.BackgroundGroup.Controls.Add(this.DeleteBackground);
            this.BackgroundGroup.Controls.Add(this.BackgroundList);
            this.BackgroundGroup.Enabled = false;
            this.BackgroundGroup.Location = new System.Drawing.Point(12, 33);
            this.BackgroundGroup.Name = "BackgroundGroup";
            this.BackgroundGroup.Size = new System.Drawing.Size(192, 150);
            this.BackgroundGroup.TabIndex = 4;
            this.BackgroundGroup.TabStop = false;
            this.BackgroundGroup.Text = "Backgrounds";
            // 
            // DeleteBackground
            // 
            this.DeleteBackground.Location = new System.Drawing.Point(6, 120);
            this.DeleteBackground.Name = "DeleteBackground";
            this.DeleteBackground.Size = new System.Drawing.Size(180, 23);
            this.DeleteBackground.TabIndex = 2;
            this.DeleteBackground.Text = "Delete";
            this.DeleteBackground.UseVisualStyleBackColor = true;
            // 
            // MusicGroup
            // 
            this.MusicGroup.Controls.Add(this.DeleteMusic);
            this.MusicGroup.Controls.Add(this.MusicList);
            this.MusicGroup.Enabled = false;
            this.MusicGroup.Location = new System.Drawing.Point(210, 33);
            this.MusicGroup.Name = "MusicGroup";
            this.MusicGroup.Size = new System.Drawing.Size(192, 150);
            this.MusicGroup.TabIndex = 5;
            this.MusicGroup.TabStop = false;
            this.MusicGroup.Text = "Music";
            // 
            // DeleteMusic
            // 
            this.DeleteMusic.Location = new System.Drawing.Point(6, 120);
            this.DeleteMusic.Name = "DeleteMusic";
            this.DeleteMusic.Size = new System.Drawing.Size(180, 23);
            this.DeleteMusic.TabIndex = 2;
            this.DeleteMusic.Text = "Delete";
            this.DeleteMusic.UseVisualStyleBackColor = true;
            // 
            // MusicList
            // 
            this.MusicList.FormattingEnabled = true;
            this.MusicList.Location = new System.Drawing.Point(6, 19);
            this.MusicList.Name = "MusicList";
            this.MusicList.Size = new System.Drawing.Size(180, 95);
            this.MusicList.TabIndex = 1;
            // 
            // AddLevelMenu
            // 
            this.AddLevelMenu.Enabled = false;
            this.AddLevelMenu.Name = "AddLevelMenu";
            this.AddLevelMenu.Size = new System.Drawing.Size(71, 20);
            this.AddLevelMenu.Text = "Add Level";
            // 
            // OpenDialog
            // 
            this.OpenDialog.DefaultExt = "xml";
            this.OpenDialog.FileName = "openFileDialog1";
            this.OpenDialog.Filter = "XML Files|*.xml";
            // 
            // SaveDialog
            // 
            this.SaveDialog.DefaultExt = "xml";
            this.SaveDialog.Filter = "XML Files|*.xml";
            // 
            // MainEditorWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 415);
            this.Controls.Add(this.MusicGroup);
            this.Controls.Add(this.BackgroundGroup);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainEditorWindow";
            this.Text = "MainEditorWindow";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainEditorWindow_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainEditorWindow_DragEnter);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.BackgroundGroup.ResumeLayout(false);
            this.MusicGroup.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem WorldMenu;
        private System.Windows.Forms.ToolStripMenuItem NewMenu;
        private System.Windows.Forms.ToolStripMenuItem OpenMenu;
        private System.Windows.Forms.ToolStripMenuItem SaveMenu;
        private System.Windows.Forms.ToolStripMenuItem LevelMenu;
        private System.Windows.Forms.ListBox BackgroundList;
        private System.Windows.Forms.GroupBox BackgroundGroup;
        private System.Windows.Forms.Button DeleteBackground;
        private System.Windows.Forms.GroupBox MusicGroup;
        private System.Windows.Forms.Button DeleteMusic;
        private System.Windows.Forms.ListBox MusicList;
        private System.Windows.Forms.ToolStripMenuItem AddLevelMenu;
        private System.Windows.Forms.OpenFileDialog OpenDialog;
        private System.Windows.Forms.SaveFileDialog SaveDialog;
    }
}