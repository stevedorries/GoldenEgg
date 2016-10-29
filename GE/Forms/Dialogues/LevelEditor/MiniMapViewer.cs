
// Type: GE.Forms.Dialogues.LevelEditor.MiniMapViewer

// MVID: 7AA6A484-F524-42F2-9571-0947D386B578
// Assembly location: C:\Documents and Settings\THE RAIN\Desktop\ge.exe

using GE;
using GE.Forms;
using Library;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

  public class MiniMapViewer : DockContent
  {
    private System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(256, 128, PixelFormat.Format32bppRgb);
    private IContainer components;
    private bool dragging;

    private LevelEditor levelEditor
    {
      get
      {
        return (LevelEditor) this.DockPanel.Parent;
      }
    }

    private SNES.ROMFile YI
    {
      get
      {
        return ((MainForm) this.levelEditor.MdiParent).YI;
      }
    }

    private LevelTab levelTab
    {
      get
      {
        return (LevelTab) this.DockPanel.ActiveDocument;
      }
    }

    private Level Level
    {
      get
      {
        return this.levelTab.Level;
      }
    }

    public MiniMapViewer()
    {
      this.InitializeComponent();
      this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
      this.UpdateStyles();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.components = (IContainer)new Container();
      this.SuspendLayout();
      this.AutoHidePortion = 260.0;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(256, 128);
      ////this.DefaultFloatWindowSize = new Size(264, 154);
      this.DockAreas = DockAreas.Float | DockAreas.DockLeft | DockAreas.DockRight;
      this.Enabled = false;
      this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
      this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
      this.Name = "MiniMapViewer";
      this.ShowHint = DockState.Float;
      this.Text = "Mini Map";
      this.MouseDown += new MouseEventHandler(this.MiniMapViewer_MouseDown);
      this.MouseMove += new MouseEventHandler(this.MiniMapViewer_MouseMove);
      this.MouseUp += new MouseEventHandler(this.MiniMapViewer_MouseUp);
      this.ResumeLayout(false);
    }

    protected override void OnClosing(CancelEventArgs e)
    {
      e.Cancel = true;
      this.levelEditor.CheckMiniMapViewer(false);
      this.Hide();
    }

    public void OnLevelTabChanged()
    {
      this.UpdateInformation();
    }

    public void UpdateInformation()
    {
      this.Render();
      this.Invalidate();
      this.Update();
    }

    private unsafe void Render()
    {
      BitmapData bitmapdata = this.bmp.LockBits(new Rectangle(0, 0, this.bmp.Width, this.bmp.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppRgb);
      uint* numPtr1 = (uint*) (void*) bitmapdata.Scan0;
      for (int index = 0; index < 128; ++index)
      {
        int num1 = 0;
        while (num1 < 256)
        {
          uint num2 = 0U;
          if (this.Level.Tiles[index & 240 | num1 >> 4][(int) (byte) (index << 4 | num1 & 15)].Count != 0)
            num2 = 33023U;
          if (this.Level.CommandTiles[index << 8 | num1].Count != 0)
            num2 |= 33023U;
          *numPtr1 = num2;
          ++num1;
          ++numPtr1;
        }
      }
      uint* numPtr2 = (uint*) (void*) bitmapdata.Scan0;
      foreach (Level.Sprite sprite in this.Level.Sprites)
        (numPtr2 + sprite.x)[(int) sprite.y * 256] = 16776960U;
      this.bmp.UnlockBits(bitmapdata);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      if (!this.Enabled)
        return;
      e.Graphics.DrawImage((Image) this.bmp, 0, 0);
    }

    private void MiniMapViewer_MouseMove(object sender, MouseEventArgs e)
    {
      this.ScrollLevelTab(e);
    }

    private void MiniMapViewer_MouseDown(object sender, MouseEventArgs e)
    {
      this.dragging = e.X < 256 && e.Y < 128;
      this.ScrollLevelTab(e);
    }

    private void MiniMapViewer_MouseUp(object sender, MouseEventArgs e)
    {
      this.dragging = false;
    }

    private void ScrollLevelTab(MouseEventArgs e)
    {
      if (!this.Enabled || !this.dragging || e.Button != MouseButtons.Left)
        return;
      int num1 = e.X;
      if (num1 < 0)
        num1 = 0;
      else if (num1 >= 256)
        num1 = (int) byte.MaxValue;
      int num2 = num1 * 16 - this.levelTab.Width / 2;
      int num3 = e.Y;
      if (num3 < 0)
        num3 = 0;
      else if (num3 >= 128)
        num3 = (int) sbyte.MaxValue;
      int num4 = num3 * 16 - this.levelTab.Height / 2;
      this.levelTab.internalDisableUpdate = true;
      Win32.SendMessage(this.levelTab.Handle, 276U, (IntPtr) (4 | num2 << 16), (IntPtr) null);
      Win32.SendMessage(this.levelTab.Handle, 277U, (IntPtr) (4 | num4 << 16), (IntPtr) null);
      this.levelTab.internalDisableUpdate = false;
      this.levelTab.Update();
    }
  }
