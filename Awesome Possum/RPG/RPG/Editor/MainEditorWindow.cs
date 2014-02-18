using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RPG.Editor
{
    public partial class MainEditorWindow : Form
    {
        private World CurrentWorld;
        private Level CurrentLevel;

        public MainEditorWindow()
        {
            InitializeComponent();
        }

        public void UpdateUI(World w, int? level)
        {
            if (w != null)
            {
                CurrentWorld = w;

                if (level.HasValue)
                    CurrentLevel = w.Levels[level.Value];

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
                    MusicList.Items.Add(song.Split('\\').Last());
                }

                AddLevelMenu.Enabled = true;
                LevelMenu.Enabled = true;
                SaveMenu.Enabled = true;

                LevelMenu.DropDownItems.Clear();

                int i = 0;
                foreach (var l in w.Levels)
                {
                    LevelMenu.DropDownItems.Add(string.Format("{0}{1}", i + 1, i == level ? "*" : ""));
                    ++i;
                }

            }
        }

        private void NewMenu_Click(object sender, EventArgs e)
        {
            var w = new World();
            w.Levels.Add(new Level());
            UpdateUI(w, 0);
        }

        private void SaveMenu_Click(object sender, EventArgs e)
        {
            if (SaveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Serializer.Serialize(SaveDialog.FileName, CurrentWorld);
            }
        }

        private void OpenMenu_Click(object sender, EventArgs e)
        {
            if (OpenDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var w = Serializer.Deserialize(OpenDialog.FileName, typeof(World)) as World;
                UpdateUI(w, 0);
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
                    CurrentLevel.Music.Add(mp3);
                }

                foreach (var png in pngs)
                {
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
    }
}
