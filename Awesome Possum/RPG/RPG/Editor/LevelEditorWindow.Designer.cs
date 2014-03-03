namespace RPG.Editor
{
    partial class LevelEditorWindow
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
            this.PrevLevelMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.NextLevelMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteLevelMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.TotalBadGuyCounter = new System.Windows.Forms.NumericUpDown();
            this.TotalBadGuys_Label = new System.Windows.Forms.Label();
            this.BG_Label = new System.Windows.Forms.Label();
            this.MP3_Label = new System.Windows.Forms.Label();
            this.BadGuysOnScreen_Label = new System.Windows.Forms.Label();
            this.BadGuysOnScreenCounter = new System.Windows.Forms.NumericUpDown();
            this.DragItems_Label = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TotalBadGuyCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BadGuysOnScreenCounter)).BeginInit();
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
            this.menuStrip1.Size = new System.Drawing.Size(373, 24);
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
            this.NewMenu.Size = new System.Drawing.Size(103, 22);
            this.NewMenu.Text = "New";
            this.NewMenu.Click += new System.EventHandler(this.NewMenu_Click);
            // 
            // OpenMenu
            // 
            this.OpenMenu.Name = "OpenMenu";
            this.OpenMenu.Size = new System.Drawing.Size(103, 22);
            this.OpenMenu.Text = "Open";
            this.OpenMenu.Click += new System.EventHandler(this.OpenMenu_Click);
            // 
            // SaveMenu
            // 
            this.SaveMenu.Enabled = false;
            this.SaveMenu.Name = "SaveMenu";
            this.SaveMenu.Size = new System.Drawing.Size(103, 22);
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
            // PrevLevelMenu
            // 
            this.PrevLevelMenu.Enabled = false;
            this.PrevLevelMenu.Name = "PrevLevelMenu";
            this.PrevLevelMenu.Size = new System.Drawing.Size(72, 20);
            this.PrevLevelMenu.Text = "Prev Level";
            this.PrevLevelMenu.Click += new System.EventHandler(this.PrevLevelMenu_Click);
            // 
            // NextLevelMenu
            // 
            this.NextLevelMenu.Enabled = false;
            this.NextLevelMenu.Name = "NextLevelMenu";
            this.NextLevelMenu.Size = new System.Drawing.Size(73, 20);
            this.NextLevelMenu.Text = "Next Level";
            this.NextLevelMenu.Click += new System.EventHandler(this.NextLevelMenu_Click);
            // 
            // DeleteLevelMenu
            // 
            this.DeleteLevelMenu.Enabled = false;
            this.DeleteLevelMenu.Name = "DeleteLevelMenu";
            this.DeleteLevelMenu.Size = new System.Drawing.Size(82, 20);
            this.DeleteLevelMenu.Text = "Delete Level";
            this.DeleteLevelMenu.Click += new System.EventHandler(this.DeleteLevelMenu_Click);
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
            // TotalBadGuyCounter
            // 
            this.TotalBadGuyCounter.Enabled = false;
            this.TotalBadGuyCounter.Location = new System.Drawing.Point(163, 196);
            this.TotalBadGuyCounter.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.TotalBadGuyCounter.Name = "TotalBadGuyCounter";
            this.TotalBadGuyCounter.Size = new System.Drawing.Size(120, 20);
            this.TotalBadGuyCounter.TabIndex = 6;
            this.TotalBadGuyCounter.ValueChanged += new System.EventHandler(this.TotalNumberOfBadGuys_ValueChanged);
            // 
            // TotalBadGuys_Label
            // 
            this.TotalBadGuys_Label.AutoSize = true;
            this.TotalBadGuys_Label.Location = new System.Drawing.Point(32, 198);
            this.TotalBadGuys_Label.Name = "TotalBadGuys_Label";
            this.TotalBadGuys_Label.Size = new System.Drawing.Size(98, 13);
            this.TotalBadGuys_Label.TabIndex = 7;
            this.TotalBadGuys_Label.Text = "# of total bad guys:";
            // 
            // BG_Label
            // 
            this.BG_Label.AutoSize = true;
            this.BG_Label.Location = new System.Drawing.Point(32, 106);
            this.BG_Label.Name = "BG_Label";
            this.BG_Label.Size = new System.Drawing.Size(82, 13);
            this.BG_Label.TabIndex = 8;
            this.BG_Label.Text = "No BG selected";
            // 
            // MP3_Label
            // 
            this.MP3_Label.AutoSize = true;
            this.MP3_Label.Location = new System.Drawing.Point(32, 150);
            this.MP3_Label.Name = "MP3_Label";
            this.MP3_Label.Size = new System.Drawing.Size(89, 13);
            this.MP3_Label.TabIndex = 9;
            this.MP3_Label.Text = "No MP3 selected";
            // 
            // BadGuysOnScreen_Label
            // 
            this.BadGuysOnScreen_Label.AutoSize = true;
            this.BadGuysOnScreen_Label.Location = new System.Drawing.Point(32, 245);
            this.BadGuysOnScreen_Label.Name = "BadGuysOnScreen_Label";
            this.BadGuysOnScreen_Label.Size = new System.Drawing.Size(125, 13);
            this.BadGuysOnScreen_Label.TabIndex = 10;
            this.BadGuysOnScreen_Label.Text = "# of bad guys on screen:";
            // 
            // BadGuysOnScreenCounter
            // 
            this.BadGuysOnScreenCounter.Enabled = false;
            this.BadGuysOnScreenCounter.Location = new System.Drawing.Point(163, 243);
            this.BadGuysOnScreenCounter.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.BadGuysOnScreenCounter.Name = "BadGuysOnScreenCounter";
            this.BadGuysOnScreenCounter.Size = new System.Drawing.Size(120, 20);
            this.BadGuysOnScreenCounter.TabIndex = 11;
            this.BadGuysOnScreenCounter.ValueChanged += new System.EventHandler(this.BadGuysOnScreenCounter_ValueChanged);
            // 
            // DragItems_Label
            // 
            this.DragItems_Label.AutoSize = true;
            this.DragItems_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DragItems_Label.Location = new System.Drawing.Point(30, 38);
            this.DragItems_Label.Name = "DragItems_Label";
            this.DragItems_Label.Size = new System.Drawing.Size(332, 26);
            this.DragItems_Label.TabIndex = 12;
            this.DragItems_Label.Text = "Drag PNG and MP3 into window.";
            // 
            // MainEditorWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 286);
            this.Controls.Add(this.DragItems_Label);
            this.Controls.Add(this.BadGuysOnScreenCounter);
            this.Controls.Add(this.BadGuysOnScreen_Label);
            this.Controls.Add(this.MP3_Label);
            this.Controls.Add(this.BG_Label);
            this.Controls.Add(this.TotalBadGuys_Label);
            this.Controls.Add(this.TotalBadGuyCounter);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainEditorWindow";
            this.Text = "No World Loaded";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainEditorWindow_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainEditorWindow_DragEnter);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TotalBadGuyCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BadGuysOnScreenCounter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem WorldMenu;
        private System.Windows.Forms.ToolStripMenuItem NewMenu;
        private System.Windows.Forms.ToolStripMenuItem OpenMenu;
        private System.Windows.Forms.ToolStripMenuItem SaveMenu;
        private System.Windows.Forms.ToolStripMenuItem AddLevelMenu;
        private System.Windows.Forms.OpenFileDialog OpenDialog;
        private System.Windows.Forms.SaveFileDialog SaveDialog;
        private System.Windows.Forms.ToolStripMenuItem PrevLevelMenu;
        private System.Windows.Forms.ToolStripMenuItem NextLevelMenu;
        private System.Windows.Forms.ToolStripMenuItem DeleteLevelMenu;
        private System.Windows.Forms.NumericUpDown TotalBadGuyCounter;
        private System.Windows.Forms.Label TotalBadGuys_Label;
        private System.Windows.Forms.Label BG_Label;
        private System.Windows.Forms.Label MP3_Label;
        private System.Windows.Forms.Label BadGuysOnScreen_Label;
        private System.Windows.Forms.NumericUpDown BadGuysOnScreenCounter;
        private System.Windows.Forms.Label DragItems_Label;
    }
}