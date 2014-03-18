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
                    f.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                    f.EndsWith(".wav", StringComparison.OrdinalIgnoreCase)
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

                var wavs = files.Where(f => f.EndsWith(".wav", StringComparison.OrdinalIgnoreCase));

                foreach (var png in pngs)
                {
                    CurrentAction.FilePath = png;
                    var img = Image.FromFile(png);

                    CurrentAction.ImgLDx = img.Width / CurrentAction.NumFrames / 2;
                    CurrentAction.ImgLDy = img.Height / 4;
                    CurrentAction.ImgRDx = CurrentAction.ImgLDx;
                    CurrentAction.ImgRDy = CurrentAction.ImgLDy;

                    CurrentAction.HitLDx = CurrentAction.ImgLDx;
                    CurrentAction.HitLDy = CurrentAction.ImgLDy;
                    CurrentAction.HitRDx = CurrentAction.ImgRDx;
                    CurrentAction.HitRDy = CurrentAction.ImgRDy;

                    CurrentAction.AtkLDx = CurrentAction.ImgLDx;
                    CurrentAction.AtkLDy = CurrentAction.ImgLDy;
                    CurrentAction.AtkRDx = CurrentAction.ImgRDx;
                    CurrentAction.AtkRDy = CurrentAction.ImgRDy;

                    CurrentAction.HitWidth = img.Width / CurrentAction.NumFrames;
                    CurrentAction.HitHeight = img.Height / 2;
                }

                foreach (var wav in wavs)
                {
                    CurrentAction.EffectPath = wav;
                }
            }

            UpdateUI();
        }

        private void UpdateUI()
        {
            SpritePictureBox.Image = null;

            if (CurrentAction == null)
            {
                ActionLabel.Enabled = false;
                actionsToolStripMenuItem.Enabled = false;
                SaveMenu.Enabled = false;
                SpriteTimer.Enabled = false;
                AddMenu.Enabled = false;
                RemoveMenu.Enabled = false;
                SoundLabel.Visible = false;

                ActionLabel.Text = "No Action";
            }
            else
            {
                ActionLabel.Enabled = true;
                actionsToolStripMenuItem.Enabled = true;
                SaveMenu.Enabled = true;
                AddMenu.Enabled = true;
                RemoveMenu.Enabled = true;

                SoundLabel.Visible = !string.IsNullOrEmpty(CurrentAction.EffectPath);
                SoundLabel.Text = Path.GetFileName(CurrentAction.EffectPath);

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

                ActionLabel.Text = CurrentAction.Name.ToString();

                ImageNameBox.Text = Path.GetFileNameWithoutExtension(CurrentAction.FilePath);
                if (string.IsNullOrEmpty(ImageNameBox.Text))
                    ImageNameBox.Text = "No Sprite";

                CurrentAction.NumFrames = Set(FramesNumber, CurrentAction.NumFrames, 1);
                CurrentAction.FrameDelay = Set(FrameTimeNumber, CurrentAction.FrameDelay, 50);

                CurrentAction.HitHeight = Set(HitHeightNumber, CurrentAction.HitHeight, 0);
                CurrentAction.HitWidth = Set(HitWidthNumber, CurrentAction.HitWidth, 0);

                CurrentAction.AtkHeight = Set(AtkHeightNumber, CurrentAction.AtkHeight, 0);
                CurrentAction.AtkWidth = Set(AtkWidthNumber, CurrentAction.AtkWidth, 0);

                CurrentAction.ImgRDx = Set(RImgDXNumber, CurrentAction.ImgRDx);
                CurrentAction.ImgRDy = Set(RImgDYNumber, CurrentAction.ImgRDy);
                CurrentAction.ImgLDx = Set(LImgDXNumber, CurrentAction.ImgLDx);
                CurrentAction.ImgLDy = Set(LImgDYNumber, CurrentAction.ImgLDy);

                CurrentAction.HitRDx = Set(RHitDXNumber, CurrentAction.HitRDx);
                CurrentAction.HitRDy = Set(RHitDYNumber, CurrentAction.HitRDy);
                CurrentAction.HitLDx = Set(LHitDXNumber, CurrentAction.HitLDx);
                CurrentAction.HitLDy = Set(LHitDYNumber, CurrentAction.HitLDy);

                CurrentAction.AtkRDx = Set(RAtkDXNumber, CurrentAction.AtkRDx);
                CurrentAction.AtkRDy = Set(RAtkDYNumber, CurrentAction.AtkRDy);
                CurrentAction.AtkLDx = Set(LAtkDXNumber, CurrentAction.AtkLDx);
                CurrentAction.AtkLDy = Set(LAtkDYNumber, CurrentAction.AtkLDy);

                actionsToolStripMenuItem.DropDownItems.Clear();
                foreach (var action in CharacterActions.Actions)
                {
                    var item = actionsToolStripMenuItem.DropDownItems.Add(string.Format("{0}{1}", action.Name, action == CurrentAction ? " *" : ""));

                    item.Name = action.Name.ToString();
                    item.Click += new EventHandler(item_Click);
                }
            }
        }

        void item_Click(object sender, EventArgs e)
        {
            var item = sender as ToolStripItem;

            CurrentAction = CharacterActions.Actions.FirstOrDefault(i => i.Name.ToString() == item.Name);

            ImagePos = 0;
            UpdateUI();
        }

        private int Set(NumericUpDown numEdit, int value, int min = -512, int max = 512)
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

        private void AtkWidthNumber_ValueChanged(object sender, EventArgs e)
        {
            CurrentAction.AtkWidth = Convert.ToInt32(AtkWidthNumber.Value);
            UpdateUI();
        }

        private void AtkHeightNumber_ValueChanged(object sender, EventArgs e)
        {
            CurrentAction.AtkHeight = Convert.ToInt32(AtkHeightNumber.Value);
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
            CurrentAction.ImgLDy = CurrentAction.ImgRDy;
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
            CurrentAction.HitLDy = CurrentAction.HitRDy;
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
            CurrentAction.ImgRDy = CurrentAction.ImgLDy;
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
            CurrentAction.HitRDy = CurrentAction.HitLDy;
            UpdateUI();
        }

        private void RAtkDXNumber_ValueChanged(object sender, EventArgs e)
        {
            CurrentAction.AtkRDx = Convert.ToInt32(RAtkDXNumber.Value);
            UpdateUI();
        }

        private void RAtkDYNumber_ValueChanged(object sender, EventArgs e)
        {
            CurrentAction.AtkRDy = Convert.ToInt32(RAtkDYNumber.Value);
            CurrentAction.AtkLDy = CurrentAction.AtkRDy;
            UpdateUI();
        }

        private void LAtkDXNumber_ValueChanged(object sender, EventArgs e)
        {
            CurrentAction.AtkLDx = Convert.ToInt32(LAtkDXNumber.Value);
            UpdateUI();
        }

        private void LAtkDYNumber_ValueChanged(object sender, EventArgs e)
        {
            CurrentAction.AtkLDy = Convert.ToInt32(LAtkDYNumber.Value);
            CurrentAction.AtkRDy = CurrentAction.AtkLDy;
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
                int imgW = CurImage.Width / CurrentAction.NumFrames,
                    imgH = CurImage.Height / 2,
                    imgX = imgW * ImagePos,
                    imgY = imgH * Direction,
                    imgDx,
                    imgDy,
                    hitDX,
                    hitDY,
                    hitW = CurrentAction.HitWidth,
                    hitH = CurrentAction.HitHeight,
                    atkDX,
                    atkDY,
                    atkW = CurrentAction.AtkWidth,
                    atkH = CurrentAction.AtkHeight,
                    canW = SpritePictureBox.Width,
                    canH = SpritePictureBox.Height,
                    canCX = canW / 2,
                    canCY = canH / 2;

                if (Direction == 0)
                {
                    imgDx = CurrentAction.ImgRDx;
                    imgDy = CurrentAction.ImgRDy;
                    hitDX = CurrentAction.HitRDx;
                    hitDY = CurrentAction.HitRDy;
                    atkDX = CurrentAction.AtkRDx;
                    atkDY = CurrentAction.AtkRDy;
                }
                else
                {
                    imgDx = CurrentAction.ImgLDx;
                    imgDy = CurrentAction.ImgLDy;
                    hitDX = CurrentAction.HitLDx;
                    hitDY = CurrentAction.HitLDy;
                    atkDX = CurrentAction.AtkLDx;
                    atkDY = CurrentAction.AtkLDy;
                }

                Rectangle cropRect = new Rectangle(imgX, imgY, imgW, imgH);
                Bitmap target = new Bitmap(canW, canH);

                using (Graphics g = Graphics.FromImage(target))
                {
                    // sprite
                    g.DrawImage(CurImage, new Rectangle(canCX - imgDx, canCY - imgDy, imgW, imgH), cropRect, GraphicsUnit.Pixel);

                    // hitbox
                    if (hitW > 0 && hitH > 0)
                        g.DrawRectangle(Pens.Blue, new Rectangle(canCX - hitDX, canCY - hitDY, hitW, hitH));

                    // atkbox
                    if (atkW > 0 && atkH > 0)
                        g.DrawRectangle(Pens.Red, new Rectangle(canCX - atkDX, canCY - atkDY, atkW, atkH));

                    // crosshairs
                    g.DrawLine(Pens.Gray, new Point(canCX, 0), new Point(canCX, target.Height));
                    g.DrawLine(Pens.Gray, new Point(0, canCY), new Point(target.Width, canCY));

                    SpritePictureBox.Image = target;
                }

                ImagePos = (ImagePos + 1) % CurrentAction.NumFrames;
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

        private void CharacterEditorWindow_Load(object sender, EventArgs e)
        {
            foreach (SpriteAction.States state in (SpriteAction.States[])Enum.GetValues(typeof(SpriteAction.States)))
            {
                var add = AddMenu.DropDownItems.Add(state.ToString());
                var del = RemoveMenu.DropDownItems.Add(state.ToString());

                add.Click += new EventHandler(add_Click);
                del.Click += new EventHandler(del_Click);
            }
        }

        void del_Click(object sender, EventArgs e)
        {
            var menu = sender as ToolStripMenuItem;
            var action = CharacterActions.Actions.FirstOrDefault(a => a.Name.ToString() == menu.Text);
            if (action != null && action != CurrentAction)
            {
                CharacterActions.Actions.Remove(action);
                UpdateUI();
            }
        }

        void add_Click(object sender, EventArgs e)
        {
            var menu = sender as ToolStripMenuItem;
            var action = CharacterActions.Actions.FirstOrDefault(a => a.Name.ToString() == menu.Text);
            if (action == null)
            {
                CurrentAction = new SpriteAction() { Name = (SpriteAction.States)Enum.Parse(typeof(SpriteAction.States), menu.Text) };
                CharacterActions.Actions.Add(CurrentAction);
                UpdateUI();
            }
        }
    }
}
