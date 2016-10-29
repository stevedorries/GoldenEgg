
// Type: GE.Forms.Dialogues.LevelEditor.PaletteEditor

// MVID: 7AA6A484-F524-42F2-9571-0947D386B578
// Assembly location: C:\Documents and Settings\THE RAIN\Desktop\ge.exe

using GE;
using GE.Forms;
using Library;
using Library.Controls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

  public class PaletteEditor : DockContent
  {
    private static string[] AnimationDescription = new string[21]
    {
      "None\nNone\nNone",
      "Unknown\nNone\nNone",
      "None\nNone\nShine",
      "None\nCastle, Watercourse and Candles\nNone",
      "None\nWaterfall\nNone",
      "Cave, Ground (if tileset matched)\nCave, Crystals\nCave",
      "Cave, Ground + Waterfall\nCave, Crystals\nNone",
      "Cave, Ground + Waterfall\nCave, Crystals (faster)\nNone",
      "Sewer\nNone\nNone",
      "None\nNone\nCastle, Torches",
      "Cave, Lava\nNone\nNone",
      "None\nNone\nSnowstorm (gets harder)",
      "None\nNone\nSnowstorm (will lift)",
      "None\nNone\nSun",
      "Cave, Waterfall/Lava\nCave, Waterfall/Lava\nNone",
      "None\nNone\nBoss's Room",
      "Cave, Ground (blue)\nNone\nNone",
      "Cave, Waterfall/Lava\nCave, Waterfall/Lava\nMist",
      "Cave, Lava + Ground (blue)\nNone\nMist",
      "Cave, Ground\nCave, Waterfall/Lava\nShine",
      "Cave, Ground\nCave, Waterfall/Lava\nShine"
    };
    private static int[] AnimationMaximumFrame = new int[21]
    {
      0,
      8,
      4,
      4,
      8,
      8,
      8,
      8,
      4,
      8,
      4,
      8,
      8,
      8,
      8,
      4,
      8,
      16,
      16,
      8,
      8
    };
    private System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(272, 256, PixelFormat.Format32bppRgb);
    private ushort[] CGRAM = new ushort[256];
    private uint[] regularPalette = new uint[256];
    private uint[] animationPalette = new uint[256];
    private bool internalChange = true;
    private IContainer components;
    private TableLayoutPanel tableLayoutPanel1;
    private Panel panel8;
    private Label labelInformation2;
    private Label labelInformation1;
    private Label label11;
    private TabControl tabControl1;
    private TabPage tabPage1;
    private DoubleBufferedPanel panelPreviewGradient;
    private DoubleBufferedPanel panelPreviewPalette;
    private TabPage tabPage2;
    private DoubleBufferedPanel panelRegularPalette;
    private GroupBox groupBox2;
    private Label label2;
    private Label label1;
    private Button button2;
    private Button button1;
    private ComboBox cbRegularCustom;
    private GroupBox groupBox1;
    private ComboBox cbRegularYoshi;
    private ComboBox cbRegularSprite;
    private ComboBox cbRegularBG2;
    private ComboBox cbRegularBG3;
    private ComboBox cbRegularBG1;
    private ComboBox cbRegularBackArea;
    private TabPage tabPage3;
    private GroupBox groupBox4;
    private Label label8;
    private Label label7;
    private ComboBox cbAnimationCustomCycle;
    private Label label10;
    private ComboBox cbAnimationCustomMaxFrame;
    private Label label9;
    private Label label6;
    private ComboBox cbAnimationCustomFrame;
    private Button button4;
    private Button button3;
    private ComboBox cbAnimationCustom;
    private GroupBox groupBox3;
    private Label label3;
    private Label labelAnimationDescription;
    private Label label4;
    private ComboBox cbAnimationFrame;
    private ComboBox cbAnimation;
    private DoubleBufferedPanel panelAnimationPalette;
    private TabPage tabPage4;
    private GroupBox groupBox5;
    private CheckBox checkBoxCustomGradient;
    private DoubleBufferedPanel panelGradientGradient;
    private DoubleBufferedPanel panelGradientPalette;
    private Button buttonDiscard;
    private Button buttonApply;

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

    private byte[] Header
    {
      get
      {
        return this.levelTab.LevelHeader;
      }
    }

    private byte[] HeaderBackup
    {
      get
      {
        return this.levelTab.LevelHeaderBackup;
      }
    }

    private Level.CustomGradient CustomGradient
    {
      get
      {
        return this.levelTab.CustomGradient;
      }
    }

    private Level.CustomGradient CustomGradientBackup
    {
      get
      {
        return this.levelTab.CustomGradientBackup;
      }
      set
      {
        this.levelTab.CustomGradientBackup = value;
      }
    }

    private Level Level
    {
      get
      {
        return this.levelTab.Level;
      }
    }

    public PaletteEditor()
    {
      this.InitializeComponent();
      this.cbRegularBackArea.BeginUpdate();
      this.cbRegularBG1.BeginUpdate();
      this.cbRegularBG2.BeginUpdate();
      this.cbRegularBG3.BeginUpdate();
      this.cbRegularSprite.BeginUpdate();
      this.cbRegularYoshi.BeginUpdate();
      this.cbAnimation.BeginUpdate();
      for (int index = 0; index < 32; ++index)
        this.cbRegularBackArea.Items.Add( string.Format("Back Area : {0:X2}",  index));
      for (int index = 0; index < 32; ++index)
        this.cbRegularBG1.Items.Add( string.Format("BG1 : {0:X2}",  index));
      for (int index = 0; index < 64; ++index)
        this.cbRegularBG2.Items.Add( string.Format("BG2 : {0:X2}",  index));
      for (int index = 0; index < 64; ++index)
        this.cbRegularBG3.Items.Add( string.Format("BG3 : {0:X2}",  index));
      for (int index = 0; index < 16; ++index)
        this.cbRegularSprite.Items.Add( string.Format("Sprite : {0:X}",  index));
      for (int index = 0; index < 8; ++index)
        this.cbRegularYoshi.Items.Add( string.Format("Yoshi : {0:X}",  index));
      for (int index = 0; index < 21; ++index)
        this.cbAnimation.Items.Add( string.Format("Animation : {0:X2}",  index));
      this.cbRegularBackArea.EndUpdate();
      this.cbRegularBG1.EndUpdate();
      this.cbRegularBG2.EndUpdate();
      this.cbRegularBG3.EndUpdate();
      this.cbRegularSprite.EndUpdate();
      this.cbRegularYoshi.EndUpdate();
      this.cbAnimation.EndUpdate();
      this.cbRegularYoshi.SelectedIndex = 0;
      this.internalChange = false;
    }

    private uint SwapRGB(uint color)
    {
      return (uint) ((int) ((color & 16252928U) >> 16) | (int) color & 63488 | ((int) color & 248) << 16);
    }

    protected override void OnClosing(CancelEventArgs e)
    {
      e.Cancel = true;
      this.levelEditor.CheckPaletteEditor(false);
      this.Hide();
    }

    public void OnLevelTabChanged()
    {
      this.UpdateInformation();
      this.buttonApply.Enabled = this.buttonDiscard.Enabled = this.levelTab.paletteEditorButtonEnabled;
    }

    private void FlushPalette(uint[] dest)
    {
      for (int index = 0; index < 256; ++index)
        dest[index] = (int) this.CGRAM[index] == (int) ushort.MaxValue ? uint.MaxValue : SNES.Color.ToRGB(this.CGRAM[index]);
    }

    private unsafe void RenderPalette(int lp)
    {
      BitmapData bitmapdata = this.bmp.LockBits(new Rectangle(0, 0, this.bmp.Width, this.bmp.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppRgb);
      uint* numPtr = (uint*) (void*) bitmapdata.Scan0;
      switch (this.tabControl1.SelectedIndex)
      {
        case 0:
          for (int index1 = 0; index1 < 256; ++index1)
          {
            for (int index2 = 0; index2 < 16; ++index2)
            {
              for (int index3 = 0; index3 < 16; ++index3)
                (numPtr + ((index1 & 15) * 16 | index3))[(index1 & 240 | index2) * bitmapdata.Width] = this.levelTab.Palette[index1];
            }
          }
          break;
        case 1:
          for (int index1 = 0; index1 < 256; ++index1)
          {
            for (int index2 = 0; index2 < 16; ++index2)
            {
              for (int index3 = 0; index3 < 16; ++index3)
                (numPtr + ((index1 & 15) * 16 | index3))[(index1 & 240 | index2) * bitmapdata.Width] = this.regularPalette[index1];
            }
          }
          if (lp < 0)
            break;
          else
            break;
        case 2:
          for (int index1 = 0; index1 < 256; ++index1)
          {
            for (int index2 = 0; index2 < 16; ++index2)
            {
              for (int index3 = 0; index3 < 16; ++index3)
                (numPtr + ((index1 & 15) * 16 | index3))[(index1 & 240 | index2) * bitmapdata.Width] = (int) this.animationPalette[index1] != -1 ? this.animationPalette[index1] : (((index3 ^ index2) & 4) == 0 ? 8421504U : 4210752U);
            }
          }
          if (lp < 0)
            break;
          else
            break;
        case 3:
          for (int index1 = 0; index1 < 256; ++index1)
          {
            for (int index2 = 0; index2 < 256; ++index2)
              (numPtr + index2)[index1 * bitmapdata.Width] = this.levelTab.Gradient[index1 * 2];
          }
          break;
      }
      this.bmp.UnlockBits(bitmapdata);
    }

    private unsafe void RenderGradient()
    {
      BitmapData bitmapdata = this.bmp.LockBits(new Rectangle(0, 0, this.bmp.Width, this.bmp.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppRgb);
      uint* numPtr = (uint*) bitmapdata.Scan0;
      switch (this.tabControl1.SelectedIndex)
      {
        case 0:
          for (int index1 = 0; index1 < 256; ++index1)
          {
            for (int index2 = 256; index2 < 272; ++index2)
              (numPtr + index2)[index1 * bitmapdata.Width] = this.levelTab.Gradient[index1 * 2];
          }
          break;
        case 3:
          int num;
          for (num = 0; num < 40; ++num)
          {
            for (int index = 256; index < 272; ++index)
              (numPtr + index)[num * bitmapdata.Width] = SNES.Color.ToRGB(this.CustomGradient.color[23]);
          }
          for (; num < 224; ++num)
          {
            for (int index = 256; index < 272; ++index)
              (numPtr + index)[num * bitmapdata.Width] = !this.CustomGradient.enabled || (num & 7) != 0 ? SNES.Color.ToRGB(this.CustomGradient.color[-((num - 40) / 8 - 12) + 10]) : ((index & 1) == 0 ? 16777215U : 0U);
          }
          for (; num < 256; ++num)
          {
            for (int index = 256; index < 272; ++index)
              (numPtr + index)[num * bitmapdata.Width] = SNES.Color.ToRGB(this.CustomGradient.color[0]);
          }
          break;
      }
      this.bmp.UnlockBits(bitmapdata);
    }

    public void UpdateInformation()
    {
      this.internalChange = true;
      this.cbRegularBackArea.SelectedIndex = (int) this.Header[0];
      this.cbRegularBG1.SelectedIndex = (int) this.Header[2];
      this.cbRegularBG2.SelectedIndex = (int) this.Header[4];
      this.cbRegularBG3.SelectedIndex = (int) this.Header[6];
      this.cbRegularSprite.SelectedIndex = (int) this.Header[8];
      this.cbAnimation.SelectedIndex = (int) this.Header[11];
      this.cbRegularBG1.Enabled = this.cbRegularBG2.Enabled = this.cbRegularBG3.Enabled = (int) this.Header[9] != 10;
      Memory.Clear(this.CGRAM, this.CGRAM.Length);
      this.Level.LoadRegularPalette(this.Header, this.Level.YoshiColor, this.CGRAM);
      this.FlushPalette(this.regularPalette);
      Memory.Set(this.CGRAM, this.CGRAM.Length, ushort.MaxValue);
      this.Level.LoadAnimatedPalette(this.Header[11], this.CGRAM, 0U, 0U);
      this.FlushPalette(this.animationPalette);
      this.RenderPalette(-1);
      this.RenderGradient();
      switch (this.tabControl1.SelectedIndex)
      {
        case 0:
          Win32.InvalidateRect(this.panelPreviewPalette.Handle, (IntPtr) null, false);
          Win32.InvalidateRect(this.panelPreviewGradient.Handle, (IntPtr) null, false);
          break;
        case 1:
          Win32.InvalidateRect(this.panelRegularPalette.Handle, (IntPtr) null, false);
          break;
        case 2:
          Win32.InvalidateRect(this.panelAnimationPalette.Handle, (IntPtr) null, false);
          break;
        case 3:
          Win32.InvalidateRect(this.panelGradientPalette.Handle, (IntPtr) null, false);
          Win32.InvalidateRect(this.panelGradientGradient.Handle, (IntPtr) null, false);
          break;
      }
      this.internalChange = false;
    }

    private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
    {
      int lp = -1;
      switch (this.tabControl1.SelectedIndex)
      {
        case 1:
          lp = this.cbRegularCustom.SelectedIndex;
          break;
        case 2:
          lp = this.cbAnimationCustom.SelectedIndex;
          break;
      }
      this.RenderPalette(lp);
      this.RenderGradient();
    }

    private void panelPrewviewPalette_Paint(object sender, PaintEventArgs e)
    {
      if (this.Enabled)
        e.Graphics.DrawImage((Image) this.bmp, e.ClipRectangle.Left, e.ClipRectangle.Top, new Rectangle(e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width, e.ClipRectangle.Height), GraphicsUnit.Pixel);
      else
        e.Graphics.FillRectangle(Brushes.White, e.ClipRectangle);
    }

    private void panelPreviewGradient_Paint(object sender, PaintEventArgs e)
    {
      if (this.Enabled)
        e.Graphics.DrawImage((Image) this.bmp, e.ClipRectangle.Left, e.ClipRectangle.Top, new Rectangle(e.ClipRectangle.Left + 256, e.ClipRectangle.Top, e.ClipRectangle.Width, e.ClipRectangle.Height), GraphicsUnit.Pixel);
      else
        e.Graphics.FillRectangle(Brushes.White, e.ClipRectangle);
    }

    private void cbRegularBackArea_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.internalChange)
        return;
      this.Header[0] = (byte) this.cbRegularBackArea.SelectedIndex;
      this.Header[2] = (byte) this.cbRegularBG1.SelectedIndex;
      this.Header[4] = (byte) this.cbRegularBG2.SelectedIndex;
      this.Header[6] = (byte) this.cbRegularBG3.SelectedIndex;
      this.Header[8] = (byte) this.cbRegularSprite.SelectedIndex;
      this.Level.YoshiColor = (byte) this.cbRegularYoshi.SelectedIndex;
      this.levelTab.ReloadPalette();
      Memory.Clear(this.CGRAM, this.CGRAM.Length);
      this.Level.LoadRegularPalette(this.Header, this.Level.YoshiColor, this.CGRAM);
      this.FlushPalette(this.regularPalette);
      this.RenderPalette(-1);
      Win32.InvalidateRect(this.panelRegularPalette.Handle, (IntPtr) null, false);
      if (sender == this.cbRegularYoshi)
        return;
      this.levelTab.paletteEditorButtonEnabled = this.buttonApply.Enabled = this.buttonDiscard.Enabled = true;
    }

    private void cbAnimation_SelectedIndexChanged(object sender, EventArgs e)
    {
      int selectedIndex = this.cbAnimation.SelectedIndex;
      this.labelAnimationDescription.Text = PaletteEditor.AnimationDescription[selectedIndex];
      this.Header[11] = (byte) selectedIndex;
      this.cbAnimationFrame.BeginUpdate();
      this.cbAnimationFrame.Items.Clear();
      if (selectedIndex != 0)
      {
        for (int index = 0; index < PaletteEditor.AnimationMaximumFrame[selectedIndex]; ++index)
          this.cbAnimationFrame.Items.Add( index.ToString("X2"));
        this.cbAnimationFrame.SelectedIndex = 0;
        this.cbAnimationFrame.Enabled = true;
      }
      else
      {
        if (!this.internalChange)
        {
          this.levelTab.ReloadPalette();
          Memory.Set(this.animationPalette, this.animationPalette.Length, uint.MaxValue);
          this.RenderPalette(-1);
          Win32.InvalidateRect(this.panelAnimationPalette.Handle, (IntPtr) null, false);
        }
        this.cbAnimationFrame.Enabled = false;
      }
      this.cbAnimationFrame.EndUpdate();
      if (this.internalChange)
        return;
      this.levelTab.paletteEditorButtonEnabled = this.buttonApply.Enabled = this.buttonDiscard.Enabled = true;
    }

    private void cbAnimationFrame_SelectedIndexChanged(object sender, EventArgs e)
    {
      int selectedIndex = this.cbAnimationFrame.SelectedIndex;
      if (this.internalChange)
        return;
      this.levelTab.ReloadPalette();
      Memory.Set(this.CGRAM, this.CGRAM.Length, ushort.MaxValue);
      this.Level.LoadAnimatedPalette(this.Header[11], this.CGRAM, (uint) selectedIndex, (uint) selectedIndex);
      this.FlushPalette(this.animationPalette);
      this.RenderPalette(-1);
      Win32.InvalidateRect(this.panelAnimationPalette.Handle, (IntPtr) null, false);
    }

    private void panelPreviewPalette_MouseMove(object sender, MouseEventArgs e)
    {
      int index = e.Y & -16 | e.X >> 4;
      if ((uint) index >= 256U)
        return;
      uint color = this.tabControl1.SelectedIndex == 0 ? this.levelTab.Palette[index] : (this.tabControl1.SelectedIndex == 1 ? this.regularPalette[index] : (this.tabControl1.SelectedIndex == 2 ? this.animationPalette[index] : this.levelTab.Gradient[e.Y * 2]));
      if ((int) color != -1)
      {
        this.labelInformation1.Text = string.Format("{0:X2}\n{1:X6}\n{2:X4}",  index,  this.SwapRGB(color),  SNES.Color.FromRGB(color));
        this.labelInformation2.Text = string.Format("\n{0},{1},{2}\n{3:X2},{4:X2},{5:X2}",  (byte) color,  ((color & 63488U) >> 8),  ((color & 16252928U) >> 16),  ((int) (byte) color >> 3),  ((color & 63488U) >> 11),  ((color & 16252928U) >> 19));
      }
      else
      {
        this.labelInformation1.Text = string.Format("{0:X2}\nN/A\nN/A",  index);
        this.labelInformation2.Text = "\nN/A\nN/A";
      }
    }

    private void panelPreviewGradient_MouseMove(object sender, MouseEventArgs e)
    {
      if ((uint) e.Y >= 256U)
        return;
      uint color = this.levelTab.Gradient[e.Y * 2];
      this.labelInformation1.Text = string.Format("N/A\n{0:X6}\n{1:X4}",  this.SwapRGB(color),  SNES.Color.FromRGB(color));
      this.labelInformation2.Text = string.Format("\n{0},{1},{2}\n{3:X2},{4:X2},{5:X2}",  (byte) color,  ((color & 63488U) >> 8),  ((color & 16252928U) >> 16),  ((int) (byte) color >> 3),  ((color & 63488U) >> 11),  ((color & 16252928U) >> 19));
    }

    private void panelRegularPalette_MouseMove(object sender, MouseEventArgs e)
    {
      this.panelPreviewPalette_MouseMove(sender, e);
    }

    private void panelAnimationPalette_MouseMove(object sender, MouseEventArgs e)
    {
      this.panelPreviewPalette_MouseMove(sender, e);
    }

    private void panelGradientGradient_MouseMove(object sender, MouseEventArgs e)
    {
      int index = e.Y < 40 ? 23 : (e.Y < 224 ? -((e.Y - 40) / 8 - 12) + 10 : 0);
      ushort color = this.levelTab.CustomGradient.color[index];
      this.labelInformation1.Text = string.Format("{0:X2}\n{1:X6}\n{2:X4}",  index,  SNES.Color.ToRGB(color),  color);
      this.labelInformation2.Text = string.Format("\n{0},{1},{2}\n{3:X2},{4:X2},{5:X2}",  (((int) color & 31744) >> 7),  (((int) color & 992) >> 2),  (byte) ((uint) color << 3),  ((int) color >> 10),  (((int) color & 992) >> 5),  ((int) color & 31));
    }

    public void UndoRedo(byte[] header, Level.CustomGradient gradient)
    {
      this.MovePaletteData(this.Header, header, this.CustomGradient, gradient);
      this.MovePaletteData(this.HeaderBackup, header, this.CustomGradientBackup, gradient);
      this.levelTab.paletteEditorButtonEnabled = this.buttonApply.Enabled = this.buttonDiscard.Enabled = false;
      this.levelTab.ReloadPalette();
    }

    private void buttonApply_Click(object sender, EventArgs e)
    {
      this.levelTab.undoBuffer.Push((LevelTab.ICommand) new PaletteEditor.EditCommand(this, new object[4]
      {
        this.HeaderBackup.Clone(),
        this.Header.Clone(),
         this.CustomGradientBackup.Clone(),
         this.CustomGradient.Clone()
      }));
      this.levelTab.redoBuffer.Clear();
      this.levelEditor.EnableUndoRedo();
      this.MovePaletteData(this.HeaderBackup, this.Header, this.CustomGradientBackup, this.CustomGradient);
      this.levelTab.paletteEditorButtonEnabled = this.buttonApply.Enabled = this.buttonDiscard.Enabled = false;
    }

    private void buttonDiscard_Click(object sender, EventArgs e)
    {
      this.MovePaletteData(this.Header, this.HeaderBackup, this.CustomGradient, this.CustomGradientBackup);
      this.levelTab.ReloadPalette();
      this.levelTab.paletteEditorButtonEnabled = this.buttonApply.Enabled = this.buttonDiscard.Enabled = false;
    }

    private void MovePaletteData(byte[] hdrDest, byte[] hdrSrc, Level.CustomGradient graDest, Level.CustomGradient graSrc)
    {
      hdrDest[0] = hdrSrc[0];
      hdrDest[2] = hdrSrc[2];
      hdrDest[4] = hdrSrc[4];
      hdrDest[6] = hdrSrc[6];
      hdrDest[8] = hdrSrc[8];
      hdrDest[11] = hdrSrc[11];
      graDest = graSrc.Clone();
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
      this.tableLayoutPanel1 = new TableLayoutPanel();
      this.panel8 = new Panel();
      this.buttonDiscard = new Button();
      this.buttonApply = new Button();
      this.labelInformation2 = new Label();
      this.labelInformation1 = new Label();
      this.label11 = new Label();
      this.tabControl1 = new TabControl();
      this.tabPage1 = new TabPage();
      this.tabPage2 = new TabPage();
      this.groupBox2 = new GroupBox();
      this.label2 = new Label();
      this.label1 = new Label();
      this.button2 = new Button();
      this.button1 = new Button();
      this.cbRegularCustom = new ComboBox();
      this.groupBox1 = new GroupBox();
      this.cbRegularYoshi = new ComboBox();
      this.cbRegularSprite = new ComboBox();
      this.cbRegularBG2 = new ComboBox();
      this.cbRegularBG3 = new ComboBox();
      this.cbRegularBG1 = new ComboBox();
      this.cbRegularBackArea = new ComboBox();
      this.tabPage3 = new TabPage();
      this.groupBox4 = new GroupBox();
      this.label8 = new Label();
      this.label7 = new Label();
      this.cbAnimationCustomCycle = new ComboBox();
      this.label10 = new Label();
      this.cbAnimationCustomMaxFrame = new ComboBox();
      this.label9 = new Label();
      this.label6 = new Label();
      this.cbAnimationCustomFrame = new ComboBox();
      this.button4 = new Button();
      this.button3 = new Button();
      this.cbAnimationCustom = new ComboBox();
      this.groupBox3 = new GroupBox();
      this.label3 = new Label();
      this.labelAnimationDescription = new Label();
      this.label4 = new Label();
      this.cbAnimationFrame = new ComboBox();
      this.cbAnimation = new ComboBox();
      this.tabPage4 = new TabPage();
      this.groupBox5 = new GroupBox();
      this.checkBoxCustomGradient = new CheckBox();
      this.panelPreviewGradient = new DoubleBufferedPanel();
      this.panelPreviewPalette = new DoubleBufferedPanel();
      this.panelRegularPalette = new DoubleBufferedPanel();
      this.panelAnimationPalette = new DoubleBufferedPanel();
      this.panelGradientGradient = new DoubleBufferedPanel();
      this.panelGradientPalette = new DoubleBufferedPanel();
      this.tableLayoutPanel1.SuspendLayout();
      this.panel8.SuspendLayout();
      this.tabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.tabPage2.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.tabPage3.SuspendLayout();
      this.groupBox4.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.tabPage4.SuspendLayout();
      this.groupBox5.SuspendLayout();
      this.SuspendLayout();
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
      this.tableLayoutPanel1.Controls.Add((Control) this.panel8, 0, 1);
      this.tableLayoutPanel1.Controls.Add((Control) this.tabControl1, 0, 0);
      this.tableLayoutPanel1.Dock = DockStyle.Top;
      this.tableLayoutPanel1.Location = new Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 309f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle());
      this.tableLayoutPanel1.Size = new Size(558, 366);
      this.tableLayoutPanel1.TabIndex = 1;
      this.panel8.Controls.Add((Control) this.buttonDiscard);
      this.panel8.Controls.Add((Control) this.buttonApply);
      this.panel8.Controls.Add((Control) this.labelInformation2);
      this.panel8.Controls.Add((Control) this.labelInformation1);
      this.panel8.Controls.Add((Control) this.label11);
      this.panel8.Dock = DockStyle.Fill;
      this.panel8.Location = new Point(3, 312);
      this.panel8.Name = "panel8";
      this.panel8.Size = new Size(552, 51);
      this.panel8.TabIndex = 1;
      this.buttonDiscard.Enabled = false;
      this.buttonDiscard.Location = new Point(468, 14);
      this.buttonDiscard.Name = "buttonDiscard";
      this.buttonDiscard.Size = new Size(75, 23);
      this.buttonDiscard.TabIndex = 4;
      this.buttonDiscard.Text = "Discard";
      this.buttonDiscard.UseVisualStyleBackColor = true;
      this.buttonDiscard.Click += new EventHandler(this.buttonDiscard_Click);
      this.buttonApply.Enabled = false;
      this.buttonApply.Location = new Point(387, 14);
      this.buttonApply.Name = "buttonApply";
      this.buttonApply.Size = new Size(75, 23);
      this.buttonApply.TabIndex = 3;
      this.buttonApply.Text = "Apply";
      this.buttonApply.UseVisualStyleBackColor = true;
      this.buttonApply.Click += new EventHandler(this.buttonApply_Click);
      this.labelInformation2.Location = new Point(169, 4);
      this.labelInformation2.Name = "labelInformation2";
      this.labelInformation2.Size = new Size(85, 39);
      this.labelInformation2.TabIndex = 2;
      this.labelInformation2.Text = "DDD\r\nDDD,DDD,DDD\r\nDD,DD,DD";
      this.labelInformation2.TextAlign = ContentAlignment.TopRight;
      this.labelInformation1.Location = new Point(108, 4);
      this.labelInformation1.Name = "labelInformation1";
      this.labelInformation1.Size = new Size(55, 39);
      this.labelInformation1.TabIndex = 1;
      this.labelInformation1.Text = "DD\r\nDDDDDD\r\nDDDD";
      this.labelInformation1.TextAlign = ContentAlignment.TopRight;
      this.label11.AutoSize = true;
      this.label11.Location = new Point(10, 4);
      this.label11.Name = "label11";
      this.label11.Size = new Size(92, 39);
      this.label11.TabIndex = 0;
      this.label11.Text = "Palette Number\r\nPC RGB Value\r\nSNES RGB Value";
      this.label11.TextAlign = ContentAlignment.TopRight;
      this.tabControl1.Controls.Add((Control) this.tabPage1);
      this.tabControl1.Controls.Add((Control) this.tabPage2);
      this.tabControl1.Controls.Add((Control) this.tabPage3);
      this.tabControl1.Controls.Add((Control) this.tabPage4);
      this.tabControl1.Dock = DockStyle.Left;
      this.tabControl1.Location = new Point(3, 3);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new Size(552, 303);
      this.tabControl1.TabIndex = 0;
      this.tabControl1.SelectedIndexChanged += new EventHandler(this.tabControl1_SelectedIndexChanged);
      this.tabPage1.Controls.Add((Control) this.panelPreviewGradient);
      this.tabPage1.Controls.Add((Control) this.panelPreviewPalette);
      this.tabPage1.Location = new Point(4, 22);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new Padding(3);
      this.tabPage1.Size = new Size(544, 277);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "Preview";
      this.tabPage1.UseVisualStyleBackColor = true;
      this.tabPage2.Controls.Add((Control) this.panelRegularPalette);
      this.tabPage2.Controls.Add((Control) this.groupBox2);
      this.tabPage2.Controls.Add((Control) this.groupBox1);
      this.tabPage2.Location = new Point(4, 22);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new Padding(3);
      this.tabPage2.Size = new Size(544, 277);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "Regular";
      this.tabPage2.UseVisualStyleBackColor = true;
      this.groupBox2.Controls.Add((Control) this.label2);
      this.groupBox2.Controls.Add((Control) this.label1);
      this.groupBox2.Controls.Add((Control) this.button2);
      this.groupBox2.Controls.Add((Control) this.button1);
      this.groupBox2.Controls.Add((Control) this.cbRegularCustom);
      this.groupBox2.Enabled = false;
      this.groupBox2.Location = new Point(294, 120);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new Size(239, 148);
      this.groupBox2.TabIndex = 2;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Custom Palette";
      this.groupBox2.Visible = false;
      this.label2.Location = new Point(76, 72);
      this.label2.Name = "label2";
      this.label2.Size = new Size(47, 39);
      this.label2.TabIndex = 4;
      this.label1.AutoSize = true;
      this.label1.Location = new Point(7, 72);
      this.label1.Name = "label1";
      this.label1.Size = new Size(66, 39);
      this.label1.TabIndex = 3;
      this.label1.Text = "Base Index :\r\nWidth :\r\nHeight :";
      this.label1.TextAlign = ContentAlignment.TopRight;
      this.button2.Enabled = false;
      this.button2.Location = new Point(91, 46);
      this.button2.Name = "button2";
      this.button2.Size = new Size(75, 23);
      this.button2.TabIndex = 2;
      this.button2.Text = "Remove";
      this.button2.UseVisualStyleBackColor = true;
      this.button1.Location = new Point(10, 46);
      this.button1.Name = "button1";
      this.button1.Size = new Size(75, 23);
      this.button1.TabIndex = 1;
      this.button1.Text = "Add";
      this.button1.UseVisualStyleBackColor = true;
      this.cbRegularCustom.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbRegularCustom.Enabled = false;
      this.cbRegularCustom.FormattingEnabled = true;
      this.cbRegularCustom.Location = new Point(10, 19);
      this.cbRegularCustom.Name = "cbRegularCustom";
      this.cbRegularCustom.Size = new Size(105, 21);
      this.cbRegularCustom.TabIndex = 0;
      this.groupBox1.Controls.Add((Control) this.cbRegularYoshi);
      this.groupBox1.Controls.Add((Control) this.cbRegularSprite);
      this.groupBox1.Controls.Add((Control) this.cbRegularBG2);
      this.groupBox1.Controls.Add((Control) this.cbRegularBG3);
      this.groupBox1.Controls.Add((Control) this.cbRegularBG1);
      this.groupBox1.Controls.Add((Control) this.cbRegularBackArea);
      this.groupBox1.Location = new Point(294, 8);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(239, 106);
      this.groupBox1.TabIndex = 1;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Header Setting";
      this.cbRegularYoshi.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbRegularYoshi.FormattingEnabled = true;
      this.cbRegularYoshi.Location = new Point(124, 73);
      this.cbRegularYoshi.Name = "cbRegularYoshi";
      this.cbRegularYoshi.Size = new Size(105, 21);
      this.cbRegularYoshi.TabIndex = 5;
      this.cbRegularYoshi.SelectedIndexChanged += new EventHandler(this.cbRegularBackArea_SelectedIndexChanged);
      this.cbRegularSprite.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbRegularSprite.FormattingEnabled = true;
      this.cbRegularSprite.Location = new Point(10, 73);
      this.cbRegularSprite.Name = "cbRegularSprite";
      this.cbRegularSprite.Size = new Size(105, 21);
      this.cbRegularSprite.TabIndex = 4;
      this.cbRegularSprite.SelectedIndexChanged += new EventHandler(this.cbRegularBackArea_SelectedIndexChanged);
      this.cbRegularBG2.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbRegularBG2.FormattingEnabled = true;
      this.cbRegularBG2.Location = new Point(10, 46);
      this.cbRegularBG2.Name = "cbRegularBG2";
      this.cbRegularBG2.Size = new Size(105, 21);
      this.cbRegularBG2.TabIndex = 2;
      this.cbRegularBG2.SelectedIndexChanged += new EventHandler(this.cbRegularBackArea_SelectedIndexChanged);
      this.cbRegularBG3.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbRegularBG3.FormattingEnabled = true;
      this.cbRegularBG3.Location = new Point(124, 46);
      this.cbRegularBG3.Name = "cbRegularBG3";
      this.cbRegularBG3.Size = new Size(105, 21);
      this.cbRegularBG3.TabIndex = 3;
      this.cbRegularBG3.SelectedIndexChanged += new EventHandler(this.cbRegularBackArea_SelectedIndexChanged);
      this.cbRegularBG1.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbRegularBG1.FormattingEnabled = true;
      this.cbRegularBG1.Location = new Point(124, 19);
      this.cbRegularBG1.Name = "cbRegularBG1";
      this.cbRegularBG1.Size = new Size(105, 21);
      this.cbRegularBG1.TabIndex = 1;
      this.cbRegularBG1.SelectedIndexChanged += new EventHandler(this.cbRegularBackArea_SelectedIndexChanged);
      this.cbRegularBackArea.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbRegularBackArea.FormattingEnabled = true;
      this.cbRegularBackArea.Location = new Point(10, 19);
      this.cbRegularBackArea.Name = "cbRegularBackArea";
      this.cbRegularBackArea.Size = new Size(105, 21);
      this.cbRegularBackArea.TabIndex = 0;
      this.cbRegularBackArea.SelectedIndexChanged += new EventHandler(this.cbRegularBackArea_SelectedIndexChanged);
      this.tabPage3.Controls.Add((Control) this.groupBox4);
      this.tabPage3.Controls.Add((Control) this.groupBox3);
      this.tabPage3.Controls.Add((Control) this.panelAnimationPalette);
      this.tabPage3.Location = new Point(4, 22);
      this.tabPage3.Name = "tabPage3";
      this.tabPage3.Padding = new Padding(3);
      this.tabPage3.Size = new Size(544, 277);
      this.tabPage3.TabIndex = 2;
      this.tabPage3.Text = "Animation";
      this.tabPage3.UseVisualStyleBackColor = true;
      this.groupBox4.Controls.Add((Control) this.label8);
      this.groupBox4.Controls.Add((Control) this.label7);
      this.groupBox4.Controls.Add((Control) this.cbAnimationCustomCycle);
      this.groupBox4.Controls.Add((Control) this.label10);
      this.groupBox4.Controls.Add((Control) this.cbAnimationCustomMaxFrame);
      this.groupBox4.Controls.Add((Control) this.label9);
      this.groupBox4.Controls.Add((Control) this.label6);
      this.groupBox4.Controls.Add((Control) this.cbAnimationCustomFrame);
      this.groupBox4.Controls.Add((Control) this.button4);
      this.groupBox4.Controls.Add((Control) this.button3);
      this.groupBox4.Controls.Add((Control) this.cbAnimationCustom);
      this.groupBox4.Enabled = false;
      this.groupBox4.Location = new Point(294, 104);
      this.groupBox4.Name = "groupBox4";
      this.groupBox4.Size = new Size(239, 164);
      this.groupBox4.TabIndex = 3;
      this.groupBox4.TabStop = false;
      this.groupBox4.Text = "Custom Palette";
      this.groupBox4.Visible = false;
      this.label8.AutoSize = true;
      this.label8.Location = new Point(73, 72);
      this.label8.Name = "label8";
      this.label8.Size = new Size(23, 26);
      this.label8.TabIndex = 6;
      this.label8.Text = "DD\r\nDD";
      this.label8.TextAlign = ContentAlignment.TopRight;
      this.label7.AutoSize = true;
      this.label7.Location = new Point(6, 72);
      this.label7.Name = "label7";
      this.label7.Size = new Size(66, 26);
      this.label7.TabIndex = 5;
      this.label7.Text = "Base Index :\r\nLength :";
      this.label7.TextAlign = ContentAlignment.TopRight;
      this.cbAnimationCustomCycle.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbAnimationCustomCycle.Enabled = false;
      this.cbAnimationCustomCycle.FormattingEnabled = true;
      this.cbAnimationCustomCycle.Items.AddRange(new object[5]
      {
         "1",
         "2",
         "4",
         "8",
         "16"
      });
      this.cbAnimationCustomCycle.Location = new Point(175, 96);
      this.cbAnimationCustomCycle.Name = "cbAnimationCustomCycle";
      this.cbAnimationCustomCycle.Size = new Size(54, 21);
      this.cbAnimationCustomCycle.TabIndex = 10;
      this.label10.AutoSize = true;
      this.label10.Location = new Point(131, 99);
      this.label10.Name = "label10";
      this.label10.Size = new Size(33, 13);
      this.label10.TabIndex = 9;
      this.label10.Text = "Cycle";
      this.cbAnimationCustomMaxFrame.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbAnimationCustomMaxFrame.Enabled = false;
      this.cbAnimationCustomMaxFrame.FormattingEnabled = true;
      this.cbAnimationCustomMaxFrame.Items.AddRange(new object[4]
      {
         "2",
         "4",
         "8",
         "16"
      });
      this.cbAnimationCustomMaxFrame.Location = new Point(175, 69);
      this.cbAnimationCustomMaxFrame.Name = "cbAnimationCustomMaxFrame";
      this.cbAnimationCustomMaxFrame.Size = new Size(54, 21);
      this.cbAnimationCustomMaxFrame.TabIndex = 8;
      this.label9.AutoSize = true;
      this.label9.Location = new Point(105, 72);
      this.label9.Name = "label9";
      this.label9.Size = new Size(62, 13);
      this.label9.TabIndex = 7;
      this.label9.Text = "Max. Frame";
      this.label6.AutoSize = true;
      this.label6.Location = new Point(133, 22);
      this.label6.Name = "label6";
      this.label6.Size = new Size(36, 13);
      this.label6.TabIndex = 1;
      this.label6.Text = "Frame";
      this.cbAnimationCustomFrame.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbAnimationCustomFrame.Enabled = false;
      this.cbAnimationCustomFrame.FormattingEnabled = true;
      this.cbAnimationCustomFrame.Location = new Point(175, 19);
      this.cbAnimationCustomFrame.Name = "cbAnimationCustomFrame";
      this.cbAnimationCustomFrame.Size = new Size(54, 21);
      this.cbAnimationCustomFrame.TabIndex = 2;
      this.button4.Enabled = false;
      this.button4.Location = new Point(91, 46);
      this.button4.Name = "button4";
      this.button4.Size = new Size(75, 23);
      this.button4.TabIndex = 4;
      this.button4.Text = "Remove";
      this.button4.UseVisualStyleBackColor = true;
      this.button3.Location = new Point(10, 46);
      this.button3.Name = "button3";
      this.button3.Size = new Size(75, 23);
      this.button3.TabIndex = 3;
      this.button3.Text = "Add";
      this.button3.UseVisualStyleBackColor = true;
      this.cbAnimationCustom.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbAnimationCustom.Enabled = false;
      this.cbAnimationCustom.FormattingEnabled = true;
      this.cbAnimationCustom.Location = new Point(10, 19);
      this.cbAnimationCustom.Name = "cbAnimationCustom";
      this.cbAnimationCustom.Size = new Size(105, 21);
      this.cbAnimationCustom.TabIndex = 0;
      this.groupBox3.Controls.Add((Control) this.label3);
      this.groupBox3.Controls.Add((Control) this.labelAnimationDescription);
      this.groupBox3.Controls.Add((Control) this.label4);
      this.groupBox3.Controls.Add((Control) this.cbAnimationFrame);
      this.groupBox3.Controls.Add((Control) this.cbAnimation);
      this.groupBox3.Location = new Point(294, 8);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new Size(239, 90);
      this.groupBox3.TabIndex = 2;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Header Setting";
      this.label3.AutoSize = true;
      this.label3.Location = new Point(130, 22);
      this.label3.Name = "label3";
      this.label3.Size = new Size(36, 13);
      this.label3.TabIndex = 1;
      this.label3.Text = "Frame";
      this.labelAnimationDescription.Location = new Point(46, 44);
      this.labelAnimationDescription.Name = "labelAnimationDescription";
      this.labelAnimationDescription.Size = new Size(190, 39);
      this.labelAnimationDescription.TabIndex = 4;
      this.label4.AutoSize = true;
      this.label4.Location = new Point(6, 44);
      this.label4.Name = "label4";
      this.label4.Size = new Size(34, 39);
      this.label4.TabIndex = 3;
      this.label4.Text = "BG1 :\r\nBG2 :\r\nBG3 :";
      this.label4.TextAlign = ContentAlignment.TopRight;
      this.cbAnimationFrame.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbAnimationFrame.FormattingEnabled = true;
      this.cbAnimationFrame.Location = new Point(175, 19);
      this.cbAnimationFrame.Name = "cbAnimationFrame";
      this.cbAnimationFrame.Size = new Size(54, 21);
      this.cbAnimationFrame.TabIndex = 2;
      this.cbAnimationFrame.SelectedIndexChanged += new EventHandler(this.cbAnimationFrame_SelectedIndexChanged);
      this.cbAnimation.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cbAnimation.FormattingEnabled = true;
      this.cbAnimation.Location = new Point(10, 19);
      this.cbAnimation.Name = "cbAnimation";
      this.cbAnimation.Size = new Size(105, 21);
      this.cbAnimation.TabIndex = 0;
      this.cbAnimation.SelectedIndexChanged += new EventHandler(this.cbAnimation_SelectedIndexChanged);
      this.tabPage4.Controls.Add((Control) this.groupBox5);
      this.tabPage4.Controls.Add((Control) this.panelGradientGradient);
      this.tabPage4.Controls.Add((Control) this.panelGradientPalette);
      this.tabPage4.Location = new Point(4, 22);
      this.tabPage4.Name = "tabPage4";
      this.tabPage4.Padding = new Padding(3);
      this.tabPage4.Size = new Size(544, 277);
      this.tabPage4.TabIndex = 3;
      this.tabPage4.Text = "Gradient";
      this.tabPage4.UseVisualStyleBackColor = true;
      this.groupBox5.Controls.Add((Control) this.checkBoxCustomGradient);
      this.groupBox5.Enabled = false;
      this.groupBox5.Location = new Point(294, 8);
      this.groupBox5.Name = "groupBox5";
      this.groupBox5.Size = new Size(239, 48);
      this.groupBox5.TabIndex = 2;
      this.groupBox5.TabStop = false;
      this.groupBox5.Text = "Custom Palette";
      this.groupBox5.Visible = false;
      this.checkBoxCustomGradient.AutoSize = true;
      this.checkBoxCustomGradient.Location = new Point(7, 20);
      this.checkBoxCustomGradient.Name = "checkBoxCustomGradient";
      this.checkBoxCustomGradient.Size = new Size(59, 17);
      this.checkBoxCustomGradient.TabIndex = 0;
      this.checkBoxCustomGradient.Text = "Enable";
      this.checkBoxCustomGradient.UseVisualStyleBackColor = true;
      this.panelPreviewGradient.BorderStyle = BorderStyle.Fixed3D;
      this.panelPreviewGradient.Location = new Point(268, 8);
      this.panelPreviewGradient.Name = "panelPreviewGradient";
      this.panelPreviewGradient.Size = new Size(20, 260);
      this.panelPreviewGradient.TabIndex = 1;
      this.panelPreviewGradient.Paint += new PaintEventHandler(this.panelPreviewGradient_Paint);
      this.panelPreviewGradient.MouseMove += new MouseEventHandler(this.panelPreviewGradient_MouseMove);
      this.panelPreviewPalette.BorderStyle = BorderStyle.Fixed3D;
      this.panelPreviewPalette.Location = new Point(6, 8);
      this.panelPreviewPalette.Name = "panelPreviewPalette";
      this.panelPreviewPalette.Size = new Size(260, 260);
      this.panelPreviewPalette.TabIndex = 0;
      this.panelPreviewPalette.Paint += new PaintEventHandler(this.panelPrewviewPalette_Paint);
      this.panelPreviewPalette.MouseMove += new MouseEventHandler(this.panelPreviewPalette_MouseMove);
      this.panelRegularPalette.BorderStyle = BorderStyle.Fixed3D;
      this.panelRegularPalette.Location = new Point(6, 8);
      this.panelRegularPalette.Name = "panelRegularPalette";
      this.panelRegularPalette.Size = new Size(260, 260);
      this.panelRegularPalette.TabIndex = 0;
      this.panelRegularPalette.Paint += new PaintEventHandler(this.panelPrewviewPalette_Paint);
      this.panelRegularPalette.MouseMove += new MouseEventHandler(this.panelRegularPalette_MouseMove);
      this.panelAnimationPalette.BorderStyle = BorderStyle.Fixed3D;
      this.panelAnimationPalette.Location = new Point(6, 8);
      this.panelAnimationPalette.Name = "panelAnimationPalette";
      this.panelAnimationPalette.Size = new Size(260, 260);
      this.panelAnimationPalette.TabIndex = 0;
      this.panelAnimationPalette.Paint += new PaintEventHandler(this.panelPrewviewPalette_Paint);
      this.panelAnimationPalette.MouseMove += new MouseEventHandler(this.panelAnimationPalette_MouseMove);
      this.panelGradientGradient.BorderStyle = BorderStyle.Fixed3D;
      this.panelGradientGradient.Location = new Point(268, 8);
      this.panelGradientGradient.Name = "panelGradientGradient";
      this.panelGradientGradient.Size = new Size(20, 260);
      this.panelGradientGradient.TabIndex = 1;
      this.panelGradientGradient.Paint += new PaintEventHandler(this.panelPreviewGradient_Paint);
      this.panelGradientGradient.MouseMove += new MouseEventHandler(this.panelGradientGradient_MouseMove);
      this.panelGradientPalette.BorderStyle = BorderStyle.Fixed3D;
      this.panelGradientPalette.Location = new Point(6, 8);
      this.panelGradientPalette.Name = "panelGradientPalette";
      this.panelGradientPalette.Size = new Size(260, 260);
      this.panelGradientPalette.TabIndex = 0;
      this.panelGradientPalette.Paint += new PaintEventHandler(this.panelPrewviewPalette_Paint);
      this.panelGradientPalette.MouseMove += new MouseEventHandler(this.panelPreviewGradient_MouseMove);
      this.AutoHidePortion = 393.0;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(558, 367);
      this.Controls.Add((Control) this.tableLayoutPanel1);
      //this.DefaultFloatWindowSize = new Size(566, 393);
      this.DockAreas = DockAreas.Float | DockAreas.DockTop | DockAreas.DockBottom;
      this.Enabled = false;
      this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
      this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
      this.Name = "PaletteEditor";
      this.ShowHint = DockState.Float;
      this.Text = "PaletteEditor";
      this.tableLayoutPanel1.ResumeLayout(false);
      this.panel8.ResumeLayout(false);
      this.panel8.PerformLayout();
      this.tabControl1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.tabPage2.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.tabPage3.ResumeLayout(false);
      this.groupBox4.ResumeLayout(false);
      this.groupBox4.PerformLayout();
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.tabPage4.ResumeLayout(false);
      this.groupBox5.ResumeLayout(false);
      this.groupBox5.PerformLayout();
      this.ResumeLayout(false);
    }

    private class EditCommand : LevelTab.ICommand
    {
      private PaletteEditor target;
      private object[] objs;

      public EditCommand(PaletteEditor target, params object[] objs)
      {
        this.target = target;
        this.objs = objs;
      }

      public void Redo()
      {
        this.target.UndoRedo((byte[]) this.objs[1], (Level.CustomGradient) this.objs[3]);
      }

      public void Undo()
      {
        this.target.UndoRedo((byte[]) this.objs[0], (Level.CustomGradient) this.objs[2]);
      }
    }
  }
