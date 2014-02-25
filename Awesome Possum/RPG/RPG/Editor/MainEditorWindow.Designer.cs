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
            this.AddLevelMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.BackgroundList = new System.Windows.Forms.ListBox();
            this.BackgroundGroup = new System.Windows.Forms.GroupBox();
            this.MusicGroup = new System.Windows.Forms.GroupBox();
            this.MusicList = new System.Windows.Forms.ListBox();
            this.OpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.NextLevelMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PrevLevelMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteLevelMenu = new System.Windows.Forms.ToolStripMenuItem();
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
            this.PrevLevelMenu,
            this.NextLevelMenu,
            this.DeleteLevelMenu});
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
            // AddLevelMenu
            // 
            this.AddLevelMenu.Enabled = false;
            this.AddLevelMenu.Name = "AddLevelMenu";
            this.AddLevelMenu.Size = new System.Drawing.Size(71, 20);
            this.AddLevelMenu.Text = "Add Level";
            this.AddLevelMenu.Click += new System.EventHandler(this.AddLevelMenu_Click);
            // 
            // BackgroundList
            // 
            this.BackgroundList.FormattingEnabled = true;
            this.BackgroundList.Location = new System.Drawing.Point(6, 19);
            this.BackgroundList.Name = "BackgroundList";
            this.BackgroundList.Size = new System.Drawing.Size(180, 95);
            this.BackgroundList.TabIndex = 1;
            this.BackgroundList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.BackgroundList_MouseDoubleClick);
            // 
            // BackgroundGroup
            // 
            this.BackgroundGroup.Controls.Add(this.BackgroundList);
            this.BackgroundGroup.Enabled = false;
            this.BackgroundGroup.Location = new System.Drawing.Point(12, 33);
            this.BackgroundGroup.Name = "BackgroundGroup";
            this.BackgroundGroup.Size = new System.Drawing.Size(192, 123);
            this.BackgroundGroup.TabIndex = 4;
            this.BackgroundGroup.TabStop = false;
            this.BackgroundGroup.Text = "Backgrounds";
            // 
            // MusicGroup
            // 
            this.MusicGroup.Controls.Add(this.MusicList);
            this.MusicGroup.Enabled = false;
            this.MusicGroup.Location = new System.Drawing.Point(210, 33);
            this.MusicGroup.Name = "MusicGroup";
            this.MusicGroup.Size = new System.Drawing.Size(192, 123);
            this.MusicGroup.TabIndex = 5;
            this.MusicGroup.TabStop = false;
            this.MusicGroup.Text = "Music";
            // 
            // MusicList
            // 
            this.MusicList.FormattingEnabled = true;
            this.MusicList.Location = new System.Drawing.Point(6, 19);
            this.MusicList.Name = "MusicList";
            this.MusicList.Size = new System.Drawing.Size(180, 95);
            this.MusicList.TabIndex = 1;
            this.MusicList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MusicList_MouseDoubleClick);
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
            // NextLevelMenu
            // 
            this.NextLevelMenu.Enabled = false;
            this.NextLevelMenu.Name = "NextLevelMenu";
            this.NextLevelMenu.Size = new System.Drawing.Size(73, 20);
            this.NextLevelMenu.Text = "Next Level";
            this.NextLevelMenu.Click += new System.EventHandler(this.NextLevelMenu_Click);
            // 
            // PrevLevelMenu
            // 
            this.PrevLevelMenu.Enabled = false;
            this.PrevLevelMenu.Name = "PrevLevelMenu";
            this.PrevLevelMenu.Size = new System.Drawing.Size(72, 20);
            this.PrevLevelMenu.Text = "Prev Level";
            this.PrevLevelMenu.Click += new System.EventHandler(this.PrevLevelMenu_Click);
            // 
            // DeleteLevelMenu
            // 
            this.DeleteLevelMenu.Enabled = false;
            this.DeleteLevelMenu.Name = "DeleteLevelMenu";
            this.DeleteLevelMenu.Size = new System.Drawing.Size(82, 20);
            this.DeleteLevelMenu.Text = "Delete Level";
            this.DeleteLevelMenu.Click += new System.EventHandler(this.DeleteLevelMenu_Click);
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
            this.Text = "No World Loaded";
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
        private System.Windows.Forms.ListBox BackgroundList;
        private System.Windows.Forms.GroupBox BackgroundGroup;
        private System.Windows.Forms.GroupBox MusicGroup;
        private System.Windows.Forms.ListBox MusicList;
        private System.Windows.Forms.ToolStripMenuItem AddLevelMenu;
        private System.Windows.Forms.OpenFileDialog OpenDialog;
        private System.Windows.Forms.SaveFileDialog SaveDialog;
        private System.Windows.Forms.ToolStripMenuItem PrevLevelMenu;
        private System.Windows.Forms.ToolStripMenuItem NextLevelMenu;
        private System.Windows.Forms.ToolStripMenuItem DeleteLevelMenu;
    }
}