using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace RPG.Editor
{
    public partial class LevelEditorWindow : Form
    {
        private World CurrentWorld;

        private Level NextLevel;
        private Level PrevLevel;
        private Level CurrentLevel;

        public LevelEditorWindow()
        {
            InitializeComponent();
        }

        public void UpdateUI(World w, Level level)
        {
            if (w != null)
            {
                CurrentWorld = w;

                if (level != null)
                    CurrentLevel = level;

                TotalBadGuyCounter.Enabled = CurrentLevel != null;
                BadGuysOnScreenCounter.Enabled = CurrentLevel != null;

                if (string.IsNullOrEmpty(CurrentLevel.BackgroundImage.FileName))
                    BG_Label.Text = "NO BACKGROUND SELECTED.";
                else
                    BG_Label.Text = CurrentLevel.BackgroundImage.FileName;

                if (string.IsNullOrEmpty(CurrentLevel.Music.FileName))
                    MP3_Label.Text = "NO MP3 SELECTED.";
                else
                    MP3_Label.Text = CurrentLevel.Music.FileName;


                AddLevelMenu.Enabled = true;
                SaveMenu.Enabled = true;
                NextLevelMenu.Enabled = false;
                PrevLevelMenu.Enabled = false;

                int i = 0;
                foreach (var l in w.Levels)
                {
                    if (l == CurrentLevel)
                    {
                        Text = string.Format("Level {0} / {1}", i + 1, w.Levels.Count);
                        if (i > 0)
                        {
                            PrevLevelMenu.Enabled = true;
                            PrevLevel = w.Levels[i - 1];
                        }

                        if (i < w.Levels.Count - 1)
                        {
                            NextLevelMenu.Enabled = true;
                            NextLevel = w.Levels[i + 1];
                        }

                        break;
                    }
                    ++i;
                }

                DeleteLevelMenu.Enabled = w.Levels.Count > 1;

                TotalBadGuyCounter.Enabled = true;
                TotalBadGuyCounter.Value = CurrentLevel.TotalNumberOfBadGuys;
            }
        }

        private void NewMenu_Click(object sender, EventArgs e)
        {
            var w = new World();
            w.Levels.Add(new Level());
            UpdateUI(w, w.Levels[0]);
        }

        private void SaveMenu_Click(object sender, EventArgs e)
        {
            if (CurrentWorld.IsValid())
            {
                if (SaveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    CurrentWorld.Save(SaveDialog.FileName);
                }
            }
            else
            {
                MessageBox.Show("A background and MP3 are required for ALL levels.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void OpenMenu_Click(object sender, EventArgs e)
        {
            if (OpenDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var w = World.Load(OpenDialog.FileName);
                UpdateUI(w, w.Levels[0]);
            }
        }

        private void MainEditorWindow_DragDrop(object sender, DragEventArgs e)
        {
            if (CurrentWorld != null && e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var files = (string[])e.Data.GetData(DataFormats.FileDrop);

                var mp3s = files.Where(f => f.EndsWith(".mp3", StringComparison.OrdinalIgnoreCase));
                var pngs = files.Where(f => f.EndsWith(".png", StringComparison.OrdinalIgnoreCase));

                foreach (var mp3 in mp3s)
                {
                    CurrentLevel.Music.FilePath = mp3;
                }

                foreach (var png in pngs)
                {
                    CurrentLevel.BackgroundImage.FilePath = png;
                    var img = Image.FromFile(png);
                    CurrentLevel.BackgroundImage.Width = img.Width;
                    CurrentLevel.BackgroundImage.Height = img.Height;
                    img.Dispose();
                }

                UpdateUI(CurrentWorld, null);
            }
        }

        private void MainEditorWindow_DragEnter(object sender, DragEventArgs e)
        {
            if (CurrentWorld != null && e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var files = (string[])e.Data.GetData(DataFormats.FileDrop);

                if (files.Any(f =>
                    f.EndsWith(".mp3", StringComparison.OrdinalIgnoreCase) ||
                    f.EndsWith(".png", StringComparison.OrdinalIgnoreCase)
                    ))
                {
                    e.Effect = DragDropEffects.Copy;
                    return;
                }
            }

            e.Effect = DragDropEffects.None;
        }

        private void AddLevelMenu_Click(object sender, EventArgs e)
        {
            CurrentWorld.Levels.Add(new Level());
            CurrentLevel = CurrentWorld.Levels.Last();
            UpdateUI(CurrentWorld, null);
        }

        private void PrevLevelMenu_Click(object sender, EventArgs e)
        {
            UpdateUI(CurrentWorld, PrevLevel);
        }

        private void NextLevelMenu_Click(object sender, EventArgs e)
        {
            UpdateUI(CurrentWorld, NextLevel);
        }

        private void DeleteLevelMenu_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Delete?", "Delete Level?", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                CurrentWorld.Levels.Remove(CurrentLevel);
                UpdateUI(CurrentWorld, CurrentWorld.Levels[0]);
            }
        }

        private void TotalNumberOfBadGuys_ValueChanged(object sender, EventArgs e)
        {
            CurrentLevel.TotalNumberOfBadGuys = Convert.ToInt32(TotalBadGuyCounter.Value);
            UpdateUI(CurrentWorld, CurrentLevel);
        }

        private void BadGuysOnScreenCounter_ValueChanged(object sender, EventArgs e)
        {
            CurrentLevel.BadGuysOnScreen = Convert.ToInt32(BadGuysOnScreenCounter.Value);
            UpdateUI(CurrentWorld, CurrentLevel);
        }
    }
}
