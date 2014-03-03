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
    public partial class CharacterEditorWindow : Form
    {
        SpriteCollection CharacterActions;
        SpriteAction CurrentAction;

        string ImagePath;
        Image CurImage;
        int ImagePos;
        int Direction;

        public CharacterEditorWindow()
        {
            InitializeComponent();
        }

        private void CharacterEditorWindow_DragEnter(object sender, DragEventArgs e)
        {
            if (CurrentAction != null && e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var files = (string[])e.Data.GetData(DataFormats.FileDrop);

                if (files.Any(f =>
                    f.EndsWith(".png", StringComparison.OrdinalIgnoreCase)
                    ))
                {
                    e.Effect = DragDropEffects.Copy;
                    return;
                }
            }

            e.Effect = DragDropEffects.None;
        }

        private void CharacterEditorWindow_DragDrop(object sender, DragEventArgs e)
        {
            if (CurrentAction != null && e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var files = (string[])e.Data.GetData(DataFormats.FileDrop);

                var pngs = files.Where(f => f.EndsWith(".png", StringComparison.OrdinalIgnoreCase));


                foreach (var png in pngs)
                {
                    CurrentAction.FilePath = png;
                }
            }

            UpdateUI();
        }

        private void UpdateUI()
        {
            if (CurrentAction == null)
            {
                ActionLabel.Enabled = false;
                actionsToolStripMenuItem.Enabled = false;
                SaveMenu.Enabled = false;
                SpriteTimer.Enabled = false;

                ActionLabel.Text = "No Action";
            }
            else
            {
                ActionLabel.Enabled = true;
                actionsToolStripMenuItem.Enabled = true;
                SaveMenu.Enabled = true;

                SpriteTimer.Enabled = false;
                if (CurrentAction.FrameDelay > 0)
                {
                    SpriteTimer.Interval = CurrentAction.FrameDelay;
                    SpriteTimer.Enabled = true;
                }

                if (ImagePath != CurrentAction.FilePath)
                {
                    ImagePath = CurrentAction.FilePath;

                    if (CurImage != null)
                        CurImage.Dispose();

                    if (string.IsNullOrEmpty(ImagePath))
                        CurImage = null;
                    else
                        CurImage = Image.FromFile(ImagePath);
                }

                ActionLabel.Text = CurrentAction.Name;

                ImageNameBox.Text = Path.GetFileNameWithoutExtension(CurrentAction.FilePath);
                if (string.IsNullOrEmpty(ImageNameBox.Text))
                    ImageNameBox.Text = "No Sprite";

                CurrentAction.NumFrames = Set(FramesNumber, CurrentAction.NumFrames, 1);
                CurrentAction.FrameDelay = Set(FrameTimeNumber, CurrentAction.FrameDelay, 50);
                CurrentAction.HitHeight = Set(HitHeightNumber, CurrentAction.HitHeight);
                CurrentAction.HitWidth = Set(HitWidthNumber, CurrentAction.HitWidth);

                CurrentAction.ImgRDx = Set(RImgDXNumber, CurrentAction.ImgRDx);
                CurrentAction.ImgRDy = Set(RImgDYNumber, CurrentAction.ImgRDy);
                CurrentAction.ImgLDx = Set(LImgDXNumber, CurrentAction.ImgLDx);
                CurrentAction.ImgLDy = Set(LImgDYNumber, CurrentAction.ImgLDy);

                CurrentAction.HitRDx = Set(RHitDXNumber, CurrentAction.HitRDx);
                CurrentAction.HitRDy = Set(RHitDYNumber, CurrentAction.HitRDy);
                CurrentAction.HitLDx = Set(LHitDXNumber, CurrentAction.HitLDx);
                CurrentAction.HitLDy = Set(LHitDYNumber, CurrentAction.HitLDy);

                actionsToolStripMenuItem.DropDownItems.Clear();
                foreach (var action in CharacterActions.Actions)
                {
                    var item = actionsToolStripMenuItem.DropDownItems.Add(string.Format("{0}{1}", action.Name, action == CurrentAction ? " *" : ""));

                    item.Name = action.Name;
                    item.Click += new EventHandler(item_Click);
                }
            }
        }

        void item_Click(object sender, EventArgs e)
        {
            var item = sender as ToolStripItem;

            CurrentAction = CharacterActions.Actions.FirstOrDefault(i => i.Name == item.Name);

            ImagePos = 0;
            UpdateUI();
        }

        private int Set(NumericUpDown numEdit, int value, int min = -255, int max = 255)
        {
            if (value > max)
                value = max;

            if (value < min)
                value = min;

            numEdit.Minimum = min;
            numEdit.Maximum = max;
            numEdit.Value = value;

            return value;
        }

        #region UI Input
        private void FramesNumber_ValueChanged(object sender, EventArgs e)
        {
            CurrentAction.NumFrames = Convert.ToInt32(FramesNumber.Value);
            UpdateUI();
        }

        private void FrameTimeNumber_ValueChanged(object sender, EventArgs e)
        {
            CurrentAction.FrameDelay = Convert.ToInt32(FrameTimeNumber.Value);
            UpdateUI();
        }

        private void HitWidthNumber_ValueChanged(object sender, EventArgs e)
        {
            CurrentAction.HitWidth = Convert.ToInt32(HitWidthNumber.Value);
            UpdateUI();
        }

        private void HitHeightNumber_ValueChanged(object sender, EventArgs e)
        {
            CurrentAction.HitHeight = Convert.ToInt32(HitHeightNumber.Value);
            UpdateUI();
        }

        private void RImgDXNumber_ValueChanged(object sender, EventArgs e)
        {
            CurrentAction.ImgRDx = Convert.ToInt32(RImgDXNumber.Value);
            UpdateUI();
        }

        private void RImgDYNumber_ValueChanged(object sender, EventArgs e)
        {
            CurrentAction.ImgRDy = Convert.ToInt32(RImgDYNumber.Value);
            UpdateUI();
        }

        private void RHitDXNumber_ValueChanged(object sender, EventArgs e)
        {
            CurrentAction.HitRDx = Convert.ToInt32(RHitDXNumber.Value);
            UpdateUI();
        }

        private void RHitDYNumber_ValueChanged(object sender, EventArgs e)
        {
            CurrentAction.HitRDy = Convert.ToInt32(RHitDYNumber.Value);
            UpdateUI();
        }

        private void LImgDXNumber_ValueChanged(object sender, EventArgs e)
        {
            CurrentAction.ImgLDx = Convert.ToInt32(LImgDXNumber.Value);
            UpdateUI();
        }

        private void LImgDYNumber_ValueChanged(object sender, EventArgs e)
        {
            CurrentAction.ImgLDy = Convert.ToInt32(LImgDYNumber.Value);
            UpdateUI();
        }

        private void LHitDXNumber_ValueChanged(object sender, EventArgs e)
        {
            CurrentAction.HitLDx = Convert.ToInt32(LHitDXNumber.Value);
            UpdateUI();
        }

        private void LHitDYNumber_ValueChanged(object sender, EventArgs e)
        {
            CurrentAction.HitLDy = Convert.ToInt32(LHitDYNumber.Value);
            UpdateUI();
        }
        #endregion

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CharacterActions = SpriteCollection.CreateNew();
            CurrentAction = CharacterActions.Actions[0];

            UpdateUI();
        }

        private void SaveMenu_Click(object sender, EventArgs e)
        {
            if (CharacterActions.IsValid())
            {
                if (SaveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    CharacterActions.Save(SaveDialog.FileName);
                }
            }
            else
            {
                MessageBox.Show("A sprite is required for all character actions", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OpenDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CharacterActions = SpriteCollection.Load(OpenDialog.FileName);
                CurrentAction = CharacterActions.Actions[0];
                UpdateUI();
            }
        }

        private void SpriteTimer_Tick(object sender, EventArgs e)
        {
            if (CurImage != null)
            {
                int w = CurImage.Width / CurrentAction.NumFrames,
                    h = CurImage.Height / 2,
                    x = w * ImagePos,
                    y = h * Direction;

                SpritePictureBox.Image = CropImage(CurImage, x, y, w, h);

                ImagePos = (ImagePos + 1) % CurrentAction.NumFrames;
            }
        }

        Image CropImage(Image src, int x, int y, int width, int height)
        {
            Rectangle cropRect = new Rectangle(x, y, width, height);
            Bitmap target = new Bitmap(cropRect.Width, cropRect.Height);

            using (Graphics g = Graphics.FromImage(target))
            {
                g.DrawImage(src, new Rectangle(0, 0, target.Width, target.Height),
                                 cropRect,
                                 GraphicsUnit.Pixel);

                return target;
            }
        }

        private void leftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Direction = 1;
        }

        private void rightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Direction = 0;
        }
    }
}
