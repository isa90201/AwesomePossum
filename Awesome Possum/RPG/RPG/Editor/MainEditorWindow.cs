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
    public partial class MainEditorWindow : Form
    {
        private World CurrentWorld;

        private Level NextLevel;
        private Level PrevLevel;
        private Level CurrentLevel;

        public MainEditorWindow()
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

                BackgroundGroup.Enabled = true;
                MusicGroup.Enabled = true;

                BackgroundList.Items.Clear();
                foreach (var bg in CurrentLevel.StageBackgrounds)
                {
                    BackgroundList.Items.Add(bg.FilePath.Split('\\').Last());
                }

                MusicList.Items.Clear();
                foreach (var song in CurrentLevel.Music)
                {
                    MusicList.Items.Add(song.FileName);
                }

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

                BadGuyCounter.Enabled = true;
                BadGuyCounter.Value = CurrentLevel.NumberOfBadGuys;
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
            if (SaveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CurrentWorld.Save(SaveDialog.FileName);
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
                    var name = Path.GetFileName(mp3);
                    if (!CurrentLevel.Music.Any(m => m.FileName == name))
                        CurrentLevel.Music.Add(new MusicItem() { FilePath = mp3 });
                }

                foreach (var png in pngs)
                {
                    var name = Path.GetFileName(png);
                    if (!CurrentLevel.StageBackgrounds.Any(bg => bg.FileName == name))
                        CurrentLevel.StageBackgrounds.Add(new Background() { FilePath = png });
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

        private void BackgroundList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (BackgroundList.Items.Count > 0)
            {
                CurrentLevel.StageBackgrounds.Remove(CurrentLevel.StageBackgrounds[BackgroundList.SelectedIndex]);
                UpdateUI(CurrentWorld, null);
            }
        }

        private void MusicList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (MusicList.Items.Count > 0)
            {
                CurrentLevel.Music.Remove(CurrentLevel.Music[MusicList.SelectedIndex]);
                UpdateUI(CurrentWorld, null);
            }
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

        private void BadGuyCounter_ValueChanged(object sender, EventArgs e)
        {
            CurrentLevel.NumberOfBadGuys = Convert.ToInt32(BadGuyCounter.Value);
            UpdateUI(CurrentWorld, CurrentLevel);
        }
    }
}
