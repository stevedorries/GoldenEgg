
// Type: GE.Forms.Dialogues.LevelEditor.HeaderEditor

// MVID: 7AA6A484-F524-42F2-9571-0947D386B578
// Assembly location: C:\Documents and Settings\THE RAIN\Desktop\ge.exe

using GE;
using GE.Forms;
using Library;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;


  public class HeaderEditor : DockContent
  {
    private static string[] LevelModeDescription = new string[16]
    {
      "",
      "",
      "Unsigned Width of Objects",
      "Fuzzy, 3D Rock Area",
      "",
      "",
      "",
      "",
      "",
      "Fight with Raphael the Raven",
      "Kamek's Room",
      "",
      "",
      "",
      "",
      ""
    };
    private static string[] AnimationDescription = new string[18]
    {
      "Common\nTransparent\nNone",
      "Common\nNone\nWater of Pond",
      "Common\nClouds\nNone",
      "Common\nNone\nSmiley Clouds",
      "None\nNone\nNone",
      "Common\nNone\nWater",
      "Common\nNone\nCastle Torches and Clouds",
      "Common, Castle Lava\nNone\nNone",
      "Common, Water in Icy area\nNone\nNone",
      "Common\nNone\nSnowstorm",
      "Common\nNone\nGoonies",
      "Common\nClouds\nButterfly",
      "Common, Water\nNone\nNone",
      "Common, Castle Lava\nNone\nCastle Torches and Clouds",
      "Common, Water\nNone\nCastle Torches and Clouds",
      "Common\nNone\nClouds",
      "Common\nNone\nReserved Animation",
      "Common, Water\nNone\nSmiley Clouds"
    };
    private bool internalChange = true;
    private const int HeaderSpriteTilesetMax = 128;
    private const int HeaderLevelModeMax = 16;
    private const int HeaderAnimationMax = 18;
    private const int HeaderBGScrollingRateMax = 32;
    private const int HeaderItemMemoryMax = 4;
    private IContainer components;
    private TableLayoutPanel tableLayoutPanel1;
    private TabControl tabControl1;
    private TabPage tabPage1;
    private GroupBox groupBox2;
    private Button buttonSpriteTilesetSearch;
    private HeaderEditor.HexTextBox textBox1;
    private Label label6;
    private Label LabelSpriteGraphicsFile;
    private Label label4;
    private ComboBox CB_TilesetSprite;
    private GroupBox groupBox1;
    private Label label3;
    private Label label2;
    private Label label1;
    private ComboBox CB_TilesetBG3;
    private ComboBox CB_TilesetBG2;
    private ComboBox CB_TilesetBG1;
    private TabPage tabPage2;
    private GroupBox groupBox5;
    private Label LabelLevelModeParam4;
    private Label LabelLevelModeParam3;
    private Label label13;
    private Label label12;
    private GroupBox groupBox4;
    private Label LabelLevelModeParam2;
    private Label label10;
    private Label LabelLevelModeParam1;
    private Label label8;
    private GroupBox groupBox3;
    private Label LabelLevelModeDescription;
    private ComboBox CB_LevelMode;
    private TabPage tabPage3;
    private GroupBox groupBox6;
    private Label LabelAnimation;
    private Label label16;
    private ComboBox CB_Animation;
    private TabPage tabPage4;
    private GroupBox groupBox7;
    private Label LabelBGVerticalRate;
    private Label LabelBGHorizontalRate;
    private Label label20;
    private Label label19;
    private Label label18;
    private ComboBox CB_BGScrollRate;
    private TabPage tabPage5;
    private GroupBox groupBox8;
    private ComboBox CB_Music;
    private TabPage tabPage6;
    private GroupBox groupBox9;
    private ComboBox CB_ItemMemory;
    private TabPage tabPage7;
    private GroupBox groupBox10;
    private CheckBox CheckBox_World6;
    private Panel panel1;
    private Button Discard_Button;
    private Button Apply_Button;

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

    public HeaderEditor()
    {
      this.InitializeComponent();
      for (int index = 0; index < 128; ++index)
        this.CB_TilesetSprite.Items.Add( index.ToString("X2"));
      for (int index = 0; index < 16; ++index)
        this.CB_LevelMode.Items.Add( index.ToString("X2"));
      for (int index = 0; index < 18; ++index)
        this.CB_Animation.Items.Add( index.ToString("X2"));
      for (int index = 0; index < 32; ++index)
        this.CB_BGScrollRate.Items.Add( index.ToString("X2"));
      for (int index = 0; index < 4; ++index)
        this.CB_ItemMemory.Items.Add( index.ToString("X"));
      this.internalChange = false;
    }

    protected override void OnClosing(CancelEventArgs e)
    {
      e.Cancel = true;
      this.levelEditor.CheckHeaderEditor(false);
      this.Hide();
    }

    public void OnLevelTabChanged()
    {
      this.UpdateInformation();
    }

    public void UndoRedo(byte[] header)
    {
      this.Header[1] = header[1];
      this.Header[3] = header[3];
      this.Header[5] = header[5];
      this.Header[7] = header[7];
      this.Header[9] = header[9];
      this.Header[10] = header[10];
      this.Header[12] = header[12];
      this.Header[13] = header[13];
      this.Header[14] = header[14];
      this.UpdateInformation();
      this.levelTab.ReloadLevel();
    }

    private void UpdateInformation()
    {
      this.internalChange = true;
      this.CB_TilesetBG1.SelectedIndex = (int) this.Header[1];
      this.CB_TilesetBG2.SelectedIndex = (int) this.Header[3];
      this.CB_TilesetBG3.SelectedIndex = (int) this.Header[5];
      this.CB_TilesetSprite.SelectedIndex = (int) this.Header[7];
      this.CB_LevelMode.SelectedIndex = (int) this.Header[9];
      this.CB_Animation.SelectedIndex = (int) this.Header[10];
      this.CB_BGScrollRate.SelectedIndex = (int) this.Header[12];
      this.CB_Music.SelectedIndex = (int) this.Header[13];
      this.CB_ItemMemory.SelectedIndex = (int) this.Header[14];
      this.CheckBox_World6.Checked = this.levelTab.IsWorld6;
      this.Apply_Button.Enabled = this.Discard_Button.Enabled = false;
      this.internalChange = false;
    }

    private void CB_TilesetSprite_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.LabelSpriteGraphicsFile.Text = string.Format("{0:X2}, {1:X2}, {2:X2}, {3:X2}, {4:X2}, {5:X2}",  this.YI.ROM[12345 + this.CB_TilesetSprite.SelectedIndex * 6].u8,  this.YI.ROM[12345 + this.CB_TilesetSprite.SelectedIndex * 6 + 1].u8,  this.YI.ROM[12345 + this.CB_TilesetSprite.SelectedIndex * 6 + 2].u8,  this.YI.ROM[12345 + this.CB_TilesetSprite.SelectedIndex * 6 + 3].u8,  this.YI.ROM[12345 + this.CB_TilesetSprite.SelectedIndex * 6 + 4].u8,  this.YI.ROM[12345 + this.CB_TilesetSprite.SelectedIndex * 6 + 5].u8);
      if (this.internalChange)
        return;
      this.Apply_Button.Enabled = this.Discard_Button.Enabled = true;
    }

    private unsafe void CB_LevelMode_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.LabelLevelModeDescription.Text = HeaderEditor.LevelModeDescription[this.CB_LevelMode.SelectedIndex];
      fixed (VariableByte* variableBytePtr = &this.YI.ROM[(15338U + (uint) this.YI.ROM[(15279U + (uint) this.YI.ROM[44928L + (long) this.CB_LevelMode.SelectedIndex].u8)].u16)])
      {
        this.LabelLevelModeParam1.Text = string.Format(": {0:X2}\n: {1:X2}\n: {2}",  *(byte*) variableBytePtr,  ((byte*) variableBytePtr)[2],  ((int) ((byte*) variableBytePtr)[4] != 0 ? 1 : 0));
        this.LabelLevelModeParam2.Text = string.Format(": {0:X2}\n: {1:X2}",  ((byte*) variableBytePtr)[1],  ((byte*) variableBytePtr)[3]);
        this.LabelLevelModeParam3.Text = string.Format(": {0:X2}\n: {1:X2}\n: {2:X2}\n: {3:X2}\n: {4:X2}\n: {5:X2}\n: {6:X2}\n: {7:X2}",  ((byte*) variableBytePtr)[5],  ((byte*) variableBytePtr)[7],  ((byte*) variableBytePtr)[9],  ((byte*) variableBytePtr)[11],  ((byte*) variableBytePtr)[13],  ((byte*) variableBytePtr)[14],  ((byte*) variableBytePtr)[16],  ((byte*) variableBytePtr)[18]);
        this.LabelLevelModeParam4.Text = string.Format(": {0:X2}\n: {1:X2}\n: {2:X2}\n: {3:X2}\n\n: {4:X2}\n: {5:X2}\n: {6:X2}",  ((byte*) variableBytePtr)[6],  ((byte*) variableBytePtr)[8],  ((byte*) variableBytePtr)[10],  ((byte*) variableBytePtr)[12],  ((byte*) variableBytePtr)[15],  ((byte*) variableBytePtr)[17],  ((byte*) variableBytePtr)[19]);
      }
      if (this.internalChange)
        return;
      this.Apply_Button.Enabled = this.Discard_Button.Enabled = true;
    }

    private void CB_Animation_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.LabelAnimation.Text = HeaderEditor.AnimationDescription[this.CB_Animation.SelectedIndex];
      if (this.internalChange)
        return;
      this.Apply_Button.Enabled = this.Discard_Button.Enabled = true;
    }

    private void CB_BGScrollRate_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.LabelBGHorizontalRate.Text = ((int) (short) this.YI.ROM[162670 + this.CB_BGScrollRate.SelectedIndex * 2].u16 < 0 ? "Undefinied\n" : ((double) this.YI.ROM[162670 + this.CB_BGScrollRate.SelectedIndex * 2].u16 / 256.0 * 100.0).ToString("F2") + "%\n") + ((int) (short) this.YI.ROM[162798 + this.CB_BGScrollRate.SelectedIndex * 2].u16 < 0 ? "Undefinied\n" : ((double) this.YI.ROM[162798 + this.CB_BGScrollRate.SelectedIndex * 2].u16 / 256.0 * 100.0).ToString("F2") + "%\n") + ((int) (short) this.YI.ROM[162926 + this.CB_BGScrollRate.SelectedIndex * 2].u16 < 0 ? "Undefinied" : ((double) this.YI.ROM[162926 + this.CB_BGScrollRate.SelectedIndex * 2].u16 / 256.0 * 100.0).ToString("F2") + "%");
      this.LabelBGVerticalRate.Text = ((int) (short) this.YI.ROM[162734 + this.CB_BGScrollRate.SelectedIndex * 2].u16 < 0 ? "Constant\n" : ((double) this.YI.ROM[162734 + this.CB_BGScrollRate.SelectedIndex * 2].u16 / 256.0 * 100.0).ToString("F2") + "%\n") + ((int) (short) this.YI.ROM[162862 + this.CB_BGScrollRate.SelectedIndex * 2].u16 < 0 ? "Constant\n" : ((double) this.YI.ROM[162862 + this.CB_BGScrollRate.SelectedIndex * 2].u16 / 256.0 * 100.0).ToString("F2") + "%\n") + ((int) (short) this.YI.ROM[162990 + this.CB_BGScrollRate.SelectedIndex * 2].u16 < 0 ? "Constant" : ((double) this.YI.ROM[162990 + this.CB_BGScrollRate.SelectedIndex * 2].u16 / 256.0 * 100.0).ToString("F2") + "%");
      if (this.internalChange)
        return;
      this.Apply_Button.Enabled = this.Discard_Button.Enabled = true;
    }

    private void CB_TilesetBG1_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.internalChange)
        return;
      this.Apply_Button.Enabled = this.Discard_Button.Enabled = true;
    }

    private void CheckBox_World6_CheckedChanged(object sender, EventArgs e)
    {
      if (this.internalChange)
        return;
      this.levelTab.IsWorld6 = this.CheckBox_World6.Checked;
      this.levelTab.ReloadLevel();
    }

    private void Apply_Button_Click(object sender, EventArgs e)
    {
      bool flag = true;
      if ((int) this.Header[1] == 2 ^ this.CB_TilesetBG1.SelectedIndex == 2)
      {
        if (MessageBox.Show("You're trying to switch the BG1 tileset between Pond, whose objects are with unsigned width, and other, so Golden Egg will try to adjust the width if necessary so that the level won't get corrupted.\r\nThis operation cannot be undone.\r\nDo you proceed?", "Golden Egg", MessageBoxButtons.YesNo) == DialogResult.No)
          return;
        flag = false;
        for (int index = 0; index < this.levelTab.Level.Objects.Count; ++index)
        {
          Level.Object @object = this.levelTab.Level.Objects[index];
          if ((int) @object.width > 128)
          {
            @object.width = (ushort) 1;
            this.levelTab.Level.Objects[index] = @object;
          }
        }
      }
      byte[] oldHeader = (byte[]) this.Header.Clone();
      this.Header[1] = (byte) this.CB_TilesetBG1.SelectedIndex;
      this.Header[3] = (byte) this.CB_TilesetBG2.SelectedIndex;
      this.Header[5] = (byte) this.CB_TilesetBG3.SelectedIndex;
      this.Header[7] = (byte) this.CB_TilesetSprite.SelectedIndex;
      this.Header[9] = (byte) this.CB_LevelMode.SelectedIndex;
      this.Header[10] = (byte) this.CB_Animation.SelectedIndex;
      this.Header[12] = (byte) this.CB_BGScrollRate.SelectedIndex;
      this.Header[13] = (byte) this.CB_Music.SelectedIndex;
      this.Header[14] = (byte) this.CB_ItemMemory.SelectedIndex;
      if (flag)
      {
        this.levelTab.undoBuffer.Push((LevelTab.ICommand) new HeaderEditor.EditCommand(this, oldHeader, (byte[]) this.Header.Clone()));
        this.levelTab.redoBuffer.Clear();
        this.levelEditor.EnableUndoRedo();
      }
      else
      {
        this.levelTab.actionCount = -1;
        this.levelTab.redoBuffer.Clear();
        this.levelTab.undoBuffer.Clear();
        this.levelEditor.EnableUndoRedo();
      }
      this.Apply_Button.Enabled = this.Discard_Button.Enabled = false;
      this.levelTab.ReloadLevel();
    }

    private void Discard_Button_Click(object sender, EventArgs e)
    {
      this.UpdateInformation();
    }

    private void buttonSpriteTilesetSearch_Click(object sender, EventArgs e)
    {
      uint[] numArray = new uint[6];
      int index1 = 0;
      bool flag1 = false;
      foreach (char ch in this.textBox1.Text)
      {
        if (48 <= (int) ch && (int) ch <= 57)
        {
          flag1 = true;
          numArray[index1] = (uint) ((int) numArray[index1] << 4 | (int) ch - 48);
        }
        else if (65 <= (int) ch && (int) ch <= 70)
        {
          flag1 = true;
          numArray[index1] = (uint) ((int) numArray[index1] << 4 | (int) ch - 65 + 10);
        }
        else if (flag1 && ++index1 >= 6)
        {
          flag1 = false;
          break;
        }
        else
          flag1 = false;
      }
      if (flag1)
        ++index1;
      if (index1 == 0)
        return;
      int num1 = this.CB_TilesetSprite.SelectedIndex + 1;
      int num2 = 0;
      while (num2 < 128)
      {
        bool flag2 = false;
        for (int index2 = 0; index2 < index1; ++index2)
        {
          int num3 = 0;
          while (num3 < 6 && (int) this.YI.ROM[12345 + num1 * 6 + num3].u8 != (int) numArray[index2])
            ++num3;
          if (num3 == 6)
          {
            flag2 = true;
            break;
          }
        }
        if (!flag2)
        {
          this.CB_TilesetSprite.SelectedIndex = num1;
          break;
        }
        else
        {
          ++num2;
          num1 = num1 + 1 & (int) sbyte.MaxValue;
        }
      }
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
      this.tabControl1 = new TabControl();
      this.tabPage1 = new TabPage();
      this.groupBox2 = new GroupBox();
      this.buttonSpriteTilesetSearch = new Button();
      this.textBox1 = new HeaderEditor.HexTextBox();
      this.label6 = new Label();
      this.LabelSpriteGraphicsFile = new Label();
      this.label4 = new Label();
      this.CB_TilesetSprite = new ComboBox();
      this.groupBox1 = new GroupBox();
      this.label3 = new Label();
      this.label2 = new Label();
      this.label1 = new Label();
      this.CB_TilesetBG3 = new ComboBox();
      this.CB_TilesetBG2 = new ComboBox();
      this.CB_TilesetBG1 = new ComboBox();
      this.tabPage2 = new TabPage();
      this.groupBox5 = new GroupBox();
      this.LabelLevelModeParam4 = new Label();
      this.LabelLevelModeParam3 = new Label();
      this.label13 = new Label();
      this.label12 = new Label();
      this.groupBox4 = new GroupBox();
      this.LabelLevelModeParam2 = new Label();
      this.label10 = new Label();
      this.LabelLevelModeParam1 = new Label();
      this.label8 = new Label();
      this.groupBox3 = new GroupBox();
      this.LabelLevelModeDescription = new Label();
      this.CB_LevelMode = new ComboBox();
      this.tabPage3 = new TabPage();
      this.groupBox6 = new GroupBox();
      this.LabelAnimation = new Label();
      this.label16 = new Label();
      this.CB_Animation = new ComboBox();
      this.tabPage4 = new TabPage();
      this.groupBox7 = new GroupBox();
      this.LabelBGVerticalRate = new Label();
      this.LabelBGHorizontalRate = new Label();
      this.label20 = new Label();
      this.label19 = new Label();
      this.label18 = new Label();
      this.CB_BGScrollRate = new ComboBox();
      this.tabPage5 = new TabPage();
      this.groupBox8 = new GroupBox();
      this.CB_Music = new ComboBox();
      this.tabPage6 = new TabPage();
      this.groupBox9 = new GroupBox();
      this.CB_ItemMemory = new ComboBox();
      this.tabPage7 = new TabPage();
      this.groupBox10 = new GroupBox();
      this.CheckBox_World6 = new CheckBox();
      this.panel1 = new Panel();
      this.Discard_Button = new Button();
      this.Apply_Button = new Button();
      this.tableLayoutPanel1.SuspendLayout();
      this.tabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.tabPage2.SuspendLayout();
      this.groupBox5.SuspendLayout();
      this.groupBox4.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.tabPage3.SuspendLayout();
      this.groupBox6.SuspendLayout();
      this.tabPage4.SuspendLayout();
      this.groupBox7.SuspendLayout();
      this.tabPage5.SuspendLayout();
      this.groupBox8.SuspendLayout();
      this.tabPage6.SuspendLayout();
      this.groupBox9.SuspendLayout();
      this.tabPage7.SuspendLayout();
      this.groupBox10.SuspendLayout();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
      this.tableLayoutPanel1.Controls.Add((Control) this.tabControl1, 0, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.panel1, 0, 1);
      this.tableLayoutPanel1.Dock = DockStyle.Fill;
      this.tableLayoutPanel1.Location = new Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 314f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
      this.tableLayoutPanel1.Size = new Size(307, 355);
      this.tableLayoutPanel1.TabIndex = 0;
      this.tabControl1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.tabControl1.Controls.Add((Control) this.tabPage1);
      this.tabControl1.Controls.Add((Control) this.tabPage2);
      this.tabControl1.Controls.Add((Control) this.tabPage3);
      this.tabControl1.Controls.Add((Control) this.tabPage4);
      this.tabControl1.Controls.Add((Control) this.tabPage5);
      this.tabControl1.Controls.Add((Control) this.tabPage6);
      this.tabControl1.Controls.Add((Control) this.tabPage7);
      this.tabControl1.Location = new Point(3, 3);
      this.tabControl1.Multiline = true;
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new Size(301, 308);
      this.tabControl1.SizeMode = TabSizeMode.FillToRight;
      this.tabControl1.TabIndex = 3;
      this.tabPage1.Controls.Add((Control) this.groupBox2);
      this.tabPage1.Controls.Add((Control) this.groupBox1);
      this.tabPage1.Location = new Point(4, 40);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new Padding(3);
      this.tabPage1.Size = new Size(293, 264);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "Tileset";
      this.tabPage1.UseVisualStyleBackColor = true;
      this.groupBox2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.groupBox2.Controls.Add((Control) this.buttonSpriteTilesetSearch);
      this.groupBox2.Controls.Add((Control) this.textBox1);
      this.groupBox2.Controls.Add((Control) this.label6);
      this.groupBox2.Controls.Add((Control) this.LabelSpriteGraphicsFile);
      this.groupBox2.Controls.Add((Control) this.label4);
      this.groupBox2.Controls.Add((Control) this.CB_TilesetSprite);
      this.groupBox2.Location = new Point(8, 126);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new Size(277, 131);
      this.groupBox2.TabIndex = 1;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Sprite Tileset";
      this.buttonSpriteTilesetSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.buttonSpriteTilesetSearch.Location = new Point(207, 97);
      this.buttonSpriteTilesetSearch.Name = "buttonSpriteTilesetSearch";
      this.buttonSpriteTilesetSearch.Size = new Size(59, 23);
      this.buttonSpriteTilesetSearch.TabIndex = 5;
      this.buttonSpriteTilesetSearch.Text = "Search";
      this.buttonSpriteTilesetSearch.UseVisualStyleBackColor = true;
      this.buttonSpriteTilesetSearch.Click += new EventHandler(this.buttonSpriteTilesetSearch_Click);
      this.textBox1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.textBox1.CharacterCasing = CharacterCasing.Upper;
      this.textBox1.Location = new Point(85, 71);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(181, 20);
      this.textBox1.TabIndex = 4;
      this.textBox1.WordWrap = false;
      this.label6.AutoSize = true;
      this.label6.Location = new Point(11, 71);
      this.label6.Name = "label6";
      this.label6.Size = new Size(65, 13);
      this.label6.TabIndex = 3;
      this.label6.Text = "Search For :";
      this.label6.TextAlign = ContentAlignment.TopRight;
      this.LabelSpriteGraphicsFile.AutoSize = true;
      this.LabelSpriteGraphicsFile.Location = new Point(82, 49);
      this.LabelSpriteGraphicsFile.Name = "LabelSpriteGraphicsFile";
      this.LabelSpriteGraphicsFile.Size = new Size(133, 13);
      this.LabelSpriteGraphicsFile.TabIndex = 2;
      this.LabelSpriteGraphicsFile.Text = "DD, DD, DD, DD, DD, DD";
      this.label4.AutoSize = true;
      this.label4.Location = new Point(2, 49);
      this.label4.Name = "label4";
      this.label4.Size = new Size(74, 13);
      this.label4.TabIndex = 1;
      this.label4.Text = "Graphics File :";
      this.label4.TextAlign = ContentAlignment.TopRight;
      this.CB_TilesetSprite.DropDownStyle = ComboBoxStyle.DropDownList;
      this.CB_TilesetSprite.FormattingEnabled = true;
      this.CB_TilesetSprite.Location = new Point(9, 19);
      this.CB_TilesetSprite.Name = "CB_TilesetSprite";
      this.CB_TilesetSprite.Size = new Size(53, 21);
      this.CB_TilesetSprite.TabIndex = 0;
      this.CB_TilesetSprite.SelectedIndexChanged += new EventHandler(this.CB_TilesetSprite_SelectedIndexChanged);
      this.groupBox1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.groupBox1.Controls.Add((Control) this.label3);
      this.groupBox1.Controls.Add((Control) this.label2);
      this.groupBox1.Controls.Add((Control) this.label1);
      this.groupBox1.Controls.Add((Control) this.CB_TilesetBG3);
      this.groupBox1.Controls.Add((Control) this.CB_TilesetBG2);
      this.groupBox1.Controls.Add((Control) this.CB_TilesetBG1);
      this.groupBox1.Location = new Point(8, 6);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(277, 114);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "BG Tileset";
      this.label3.AutoSize = true;
      this.label3.Location = new Point(6, 82);
      this.label3.Name = "label3";
      this.label3.Size = new Size(28, 13);
      this.label3.TabIndex = 4;
      this.label3.Text = "BG3";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(6, 52);
      this.label2.Name = "label2";
      this.label2.Size = new Size(28, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "BG2";
      this.label1.AutoSize = true;
      this.label1.Location = new Point(6, 22);
      this.label1.Name = "label1";
      this.label1.Size = new Size(28, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "BG1";
      this.CB_TilesetBG3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.CB_TilesetBG3.DropDownStyle = ComboBoxStyle.DropDownList;
      this.CB_TilesetBG3.FormattingEnabled = true;
      this.CB_TilesetBG3.Items.AddRange(new object[48]
      {
         "00 : None",
         "01 : Water of Pond",
         "02 : BG3 Objects 1",
         "03 : Clouds, glitched",
         "04 : Clouds",
         "05 : BG3 Objects 2",
         "06 : BG3 Objects 3",
         "07 : BG3 Objects 4",
         "08 : Unknown",
         "09 : Unknown",
         "0A : Cross Section Cover",
         "0B : Unknown",
         "0C : Shine",
         "0D : Clouds and Mountains",
         "0E : Boggy Woods",
         "0F : Sky, Mountains",
         "10 : Sky, Clouds",
         "11 : Fog (Hookbill the Koopa)",
         "12 : Night sky, Raven's Moon",
         "13 : Water (low)",
         "14 : Jungle",
         "15 : Cave",
         "16 : Shark Chomp",
         "17 : Rocks",
         "18 : Castle, Torches",
         "19 : Snowstorm",
         "1A : Goonies",
         "1B : Flower Garden",
         "1C : Spotlight",
         "1D : Water (high)",
         "1E : Moon, Clouds, and Mountains",
         "1F : Magic Shower",
         "20 : Grass",
         "21 : Prince Froggy's throat",
         "22 : Clouds and Mist",
         "23 : Sun",
         "24 : Night sky, Moons",
         "25 : Boss's Room",
         "26 : Pop",
         "27 : Forest",
         "28 : Night sky",
         "29 : Clouds",
         "2A : Moon, Clodus, and Mountains",
         "2B : Clouds",
         "2C : Mist, waves",
         "2D : Mist, scrolls left",
         "2E : Clouds",
         "2F : Sky, Clouds"
      });
      this.CB_TilesetBG3.Location = new Point(59, 79);
      this.CB_TilesetBG3.Name = "CB_TilesetBG3";
      this.CB_TilesetBG3.Size = new Size(207, 21);
      this.CB_TilesetBG3.TabIndex = 5;
      this.CB_TilesetBG3.SelectedIndexChanged += new EventHandler(this.CB_TilesetBG1_SelectedIndexChanged);
      this.CB_TilesetBG2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.CB_TilesetBG2.DropDownStyle = ComboBoxStyle.DropDownList;
      this.CB_TilesetBG2.FormattingEnabled = true;
      this.CB_TilesetBG2.Items.AddRange(new object[32]
      {
         "00 : Cave, Waterfall",
         "01 : Woods",
         "02 : Pond",
         "03 : 3D stone, Lava",
         "04 : Forest and Mountains",
         "05 : Forest",
         "06 : Castle, Watercourse and Candles",
         "07 : Tropical Mountains",
         "08 : Forest",
         "09 : Jungle, Mountains",
         "0A : Waterfall",
         "0B : Distant grounds",
         "0C : Boggy Woods",
         "0D : Night sky, Raven's Moons",
         "0E : Grass",
         "0F : Forest and Mountains",
         "10 : Jungle, Mountains",
         "11 : Glitched",
         "12 : Ocean",
         "13 : Cave, Crystals",
         "14 : Castle, webs",
         "15 : Sky, Mountains (low)",
         "16 : Boss",
         "17 : Glitched",
         "18 : Forest, Eerie Cave",
         "19 : Castle, Stones",
         "1A : Sky, Mountains (high)",
         "1B : None",
         "1C : Smiley Mountains",
         "1D : Round Mountains",
         "1E : Forest",
         "1F : Baby Bowser's Room"
      });
      this.CB_TilesetBG2.Location = new Point(59, 49);
      this.CB_TilesetBG2.Name = "CB_TilesetBG2";
      this.CB_TilesetBG2.Size = new Size(207, 21);
      this.CB_TilesetBG2.TabIndex = 3;
      this.CB_TilesetBG2.SelectedIndexChanged += new EventHandler(this.CB_TilesetBG1_SelectedIndexChanged);
      this.CB_TilesetBG1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.CB_TilesetBG1.DropDownStyle = ComboBoxStyle.DropDownList;
      this.CB_TilesetBG1.FormattingEnabled = true;
      this.CB_TilesetBG1.Items.AddRange(new object[16]
      {
         "0 : Cave 0",
         "1 : Forest 1",
         "2 : Pond",
         "3 : 3D stone",
         "4 : Snow",
         "5 : Jungle",
         "6 : Brick Castle",
         "7 : Grass 1",
         "8 : Cave 2",
         "9 : Forest 2",
         "A : Wooden Castle",
         "B : Sewer",
         "C : Flower Garden",
         "D : Sky",
         "E : Stone Castle",
         "F : Grass 2"
      });
      this.CB_TilesetBG1.Location = new Point(59, 19);
      this.CB_TilesetBG1.Name = "CB_TilesetBG1";
      this.CB_TilesetBG1.Size = new Size(207, 21);
      this.CB_TilesetBG1.TabIndex = 1;
      this.CB_TilesetBG1.SelectedIndexChanged += new EventHandler(this.CB_TilesetBG1_SelectedIndexChanged);
      this.tabPage2.Controls.Add((Control) this.groupBox5);
      this.tabPage2.Controls.Add((Control) this.groupBox4);
      this.tabPage2.Controls.Add((Control) this.groupBox3);
      this.tabPage2.Location = new Point(4, 40);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new Padding(3);
      this.tabPage2.Size = new Size(293, 264);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "Level Mode";
      this.tabPage2.UseVisualStyleBackColor = true;
      this.groupBox5.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.groupBox5.Controls.Add((Control) this.LabelLevelModeParam4);
      this.groupBox5.Controls.Add((Control) this.LabelLevelModeParam3);
      this.groupBox5.Controls.Add((Control) this.label13);
      this.groupBox5.Controls.Add((Control) this.label12);
      this.groupBox5.Location = new Point(8, 129);
      this.groupBox5.Name = "groupBox5";
      this.groupBox5.Size = new Size(277, 128);
      this.groupBox5.TabIndex = 2;
      this.groupBox5.TabStop = false;
      this.groupBox5.Text = "Hardware Parameters";
      this.LabelLevelModeParam4.AutoSize = true;
      this.LabelLevelModeParam4.Location = new Point(242, 16);
      this.LabelLevelModeParam4.Name = "LabelLevelModeParam4";
      this.LabelLevelModeParam4.Size = new Size(29, 104);
      this.LabelLevelModeParam4.TabIndex = 3;
      this.LabelLevelModeParam4.Text = ": DD\r\n: DD\r\n: DD\r\n: DD\r\n\r\n: DD\r\n: DD\r\n: DD";
      this.LabelLevelModeParam3.AutoSize = true;
      this.LabelLevelModeParam3.Location = new Point(98, 16);
      this.LabelLevelModeParam3.Name = "LabelLevelModeParam3";
      this.LabelLevelModeParam3.Size = new Size(29, 104);
      this.LabelLevelModeParam3.TabIndex = 1;
      this.LabelLevelModeParam3.Text = ": DD\r\n: DD\r\n: DD\r\n: DD\r\n: DD\r\n: DD\r\n: DD\r\n: DD";
      this.label13.AutoSize = true;
      this.label13.Location = new Point(140, 16);
      this.label13.Name = "label13";
      this.label13.Size = new Size(59, 104);
      this.label13.TabIndex = 2;
      this.label13.Text = "BG1SC\r\nBG3SC\r\nBG34NBA\r\nW34SEL\r\n\r\nTS\r\nTSW\r\nCGADSUB";
      this.label12.AutoSize = true;
      this.label12.Location = new Point(6, 16);
      this.label12.Name = "label12";
      this.label12.Size = new Size(60, 104);
      this.label12.TabIndex = 0;
      this.label12.Text = "BG MODE\r\nBG2SC\r\nBG1NBA\r\nW12SEL\r\nWOBJSEL\r\nTM\r\nTMW\r\nCGSWSEL";
      this.groupBox4.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.groupBox4.Controls.Add((Control) this.LabelLevelModeParam2);
      this.groupBox4.Controls.Add((Control) this.label10);
      this.groupBox4.Controls.Add((Control) this.LabelLevelModeParam1);
      this.groupBox4.Controls.Add((Control) this.label8);
      this.groupBox4.Location = new Point(8, 59);
      this.groupBox4.Name = "groupBox4";
      this.groupBox4.Size = new Size(277, 64);
      this.groupBox4.TabIndex = 1;
      this.groupBox4.TabStop = false;
      this.groupBox4.Text = "Game Parameters";
      this.LabelLevelModeParam2.AutoSize = true;
      this.LabelLevelModeParam2.Location = new Point(242, 16);
      this.LabelLevelModeParam2.Name = "LabelLevelModeParam2";
      this.LabelLevelModeParam2.Size = new Size(29, 26);
      this.LabelLevelModeParam2.TabIndex = 3;
      this.LabelLevelModeParam2.Text = ": DD\r\n: DD";
      this.label10.AutoSize = true;
      this.label10.Location = new Point(140, 16);
      this.label10.Name = "label10";
      this.label10.Size = new Size(56, 26);
      this.label10.TabIndex = 2;
      this.label10.Text = "IRQ Mode\r\nSBMR";
      this.label10.UseMnemonic = false;
      this.LabelLevelModeParam1.AutoSize = true;
      this.LabelLevelModeParam1.Location = new Point(98, 16);
      this.LabelLevelModeParam1.Name = "LabelLevelModeParam1";
      this.LabelLevelModeParam1.Size = new Size(35, 39);
      this.LabelLevelModeParam1.TabIndex = 1;
      this.LabelLevelModeParam1.Text = ": DD\r\n: DD\r\n: false";
      this.label8.AutoSize = true;
      this.label8.Location = new Point(6, 16);
      this.label8.Name = "label8";
      this.label8.Size = new Size(89, 39);
      this.label8.TabIndex = 0;
      this.label8.Text = "NMI & IRQ Mode\r\nSCBR\r\nInvalidate Pal. 00";
      this.label8.UseMnemonic = false;
      this.groupBox3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.groupBox3.Controls.Add((Control) this.LabelLevelModeDescription);
      this.groupBox3.Controls.Add((Control) this.CB_LevelMode);
      this.groupBox3.Location = new Point(8, 6);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new Size(277, 47);
      this.groupBox3.TabIndex = 0;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Level Mode";
      this.LabelLevelModeDescription.Location = new Point(61, 22);
      this.LabelLevelModeDescription.Name = "LabelLevelModeDescription";
      this.LabelLevelModeDescription.Size = new Size(210, 17);
      this.LabelLevelModeDescription.TabIndex = 1;
      this.CB_LevelMode.DropDownStyle = ComboBoxStyle.DropDownList;
      this.CB_LevelMode.FormattingEnabled = true;
      this.CB_LevelMode.Location = new Point(6, 19);
      this.CB_LevelMode.Name = "CB_LevelMode";
      this.CB_LevelMode.Size = new Size(49, 21);
      this.CB_LevelMode.TabIndex = 0;
      this.CB_LevelMode.SelectedIndexChanged += new EventHandler(this.CB_LevelMode_SelectedIndexChanged);
      this.tabPage3.Controls.Add((Control) this.groupBox6);
      this.tabPage3.Location = new Point(4, 40);
      this.tabPage3.Name = "tabPage3";
      this.tabPage3.Padding = new Padding(3);
      this.tabPage3.Size = new Size(293, 264);
      this.tabPage3.TabIndex = 2;
      this.tabPage3.Text = "Animation";
      this.tabPage3.UseVisualStyleBackColor = true;
      this.groupBox6.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.groupBox6.Controls.Add((Control) this.LabelAnimation);
      this.groupBox6.Controls.Add((Control) this.label16);
      this.groupBox6.Controls.Add((Control) this.CB_Animation);
      this.groupBox6.Location = new Point(8, 6);
      this.groupBox6.Name = "groupBox6";
      this.groupBox6.Size = new Size(277, 251);
      this.groupBox6.TabIndex = 0;
      this.groupBox6.TabStop = false;
      this.groupBox6.Text = "Animation";
      this.LabelAnimation.Location = new Point(46, 130);
      this.LabelAnimation.Name = "LabelAnimation";
      this.LabelAnimation.Size = new Size(225, 39);
      this.LabelAnimation.TabIndex = 2;
      this.label16.AutoSize = true;
      this.label16.Location = new Point(6, 130);
      this.label16.Name = "label16";
      this.label16.Size = new Size(34, 39);
      this.label16.TabIndex = 1;
      this.label16.Text = "BG1 :\r\nBG2 :\r\nBG3 :";
      this.label16.TextAlign = ContentAlignment.TopRight;
      this.CB_Animation.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.CB_Animation.DropDownStyle = ComboBoxStyle.DropDownList;
      this.CB_Animation.FormattingEnabled = true;
      this.CB_Animation.Location = new Point(111, 106);
      this.CB_Animation.Name = "CB_Animation";
      this.CB_Animation.Size = new Size(55, 21);
      this.CB_Animation.TabIndex = 0;
      this.CB_Animation.SelectedIndexChanged += new EventHandler(this.CB_Animation_SelectedIndexChanged);
      this.tabPage4.Controls.Add((Control) this.groupBox7);
      this.tabPage4.Location = new Point(4, 40);
      this.tabPage4.Name = "tabPage4";
      this.tabPage4.Padding = new Padding(3);
      this.tabPage4.Size = new Size(293, 264);
      this.tabPage4.TabIndex = 3;
      this.tabPage4.Text = "BG Scrolling Rate";
      this.tabPage4.UseVisualStyleBackColor = true;
      this.groupBox7.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.groupBox7.Controls.Add((Control) this.LabelBGVerticalRate);
      this.groupBox7.Controls.Add((Control) this.LabelBGHorizontalRate);
      this.groupBox7.Controls.Add((Control) this.label20);
      this.groupBox7.Controls.Add((Control) this.label19);
      this.groupBox7.Controls.Add((Control) this.label18);
      this.groupBox7.Controls.Add((Control) this.CB_BGScrollRate);
      this.groupBox7.Location = new Point(8, 6);
      this.groupBox7.Name = "groupBox7";
      this.groupBox7.Size = new Size(277, 251);
      this.groupBox7.TabIndex = 0;
      this.groupBox7.TabStop = false;
      this.groupBox7.Text = "BG Scrolling Rate";
      this.LabelBGVerticalRate.Location = new Point(179, 143);
      this.LabelBGVerticalRate.Name = "LabelBGVerticalRate";
      this.LabelBGVerticalRate.Size = new Size(68, 39);
      this.LabelBGVerticalRate.TabIndex = 5;
      this.LabelBGVerticalRate.Text = "100.00%\r\n100.00%\r\n100.00%";
      this.LabelBGVerticalRate.TextAlign = ContentAlignment.TopRight;
      this.LabelBGHorizontalRate.Location = new Point(61, 143);
      this.LabelBGHorizontalRate.Name = "LabelBGHorizontalRate";
      this.LabelBGHorizontalRate.Size = new Size(77, 39);
      this.LabelBGHorizontalRate.TabIndex = 4;
      this.LabelBGHorizontalRate.Text = "100.00%\r\n100.00%\r\n100.00%";
      this.LabelBGHorizontalRate.TextAlign = ContentAlignment.TopRight;
      this.label20.AutoSize = true;
      this.label20.Location = new Point(179, 130);
      this.label20.Name = "label20";
      this.label20.Size = new Size(68, 13);
      this.label20.TabIndex = 2;
      this.label20.Text = "Vertical Rate";
      this.label19.AutoSize = true;
      this.label19.Location = new Point(58, 130);
      this.label19.Name = "label19";
      this.label19.Size = new Size(80, 13);
      this.label19.TabIndex = 1;
      this.label19.Text = "Horizontal Rate";
      this.label18.AutoSize = true;
      this.label18.Location = new Point(6, 130);
      this.label18.Name = "label18";
      this.label18.Size = new Size(34, 52);
      this.label18.TabIndex = 3;
      this.label18.Text = "\r\nBG2 :\r\nBG3 :\r\nBG4 :";
      this.CB_BGScrollRate.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.CB_BGScrollRate.DropDownStyle = ComboBoxStyle.DropDownList;
      this.CB_BGScrollRate.FormattingEnabled = true;
      this.CB_BGScrollRate.Location = new Point(111, 106);
      this.CB_BGScrollRate.Name = "CB_BGScrollRate";
      this.CB_BGScrollRate.Size = new Size(55, 21);
      this.CB_BGScrollRate.TabIndex = 0;
      this.CB_BGScrollRate.SelectedIndexChanged += new EventHandler(this.CB_BGScrollRate_SelectedIndexChanged);
      this.tabPage5.Controls.Add((Control) this.groupBox8);
      this.tabPage5.Location = new Point(4, 40);
      this.tabPage5.Name = "tabPage5";
      this.tabPage5.Padding = new Padding(3);
      this.tabPage5.Size = new Size(293, 264);
      this.tabPage5.TabIndex = 4;
      this.tabPage5.Text = "Music";
      this.tabPage5.UseVisualStyleBackColor = true;
      this.groupBox8.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.groupBox8.Controls.Add((Control) this.CB_Music);
      this.groupBox8.Location = new Point(8, 6);
      this.groupBox8.Name = "groupBox8";
      this.groupBox8.Size = new Size(277, 251);
      this.groupBox8.TabIndex = 0;
      this.groupBox8.TabStop = false;
      this.groupBox8.Text = "Music";
      this.CB_Music.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.CB_Music.DropDownStyle = ComboBoxStyle.DropDownList;
      this.CB_Music.FormattingEnabled = true;
      this.CB_Music.Items.AddRange(new object[16]
      {
         "0 : Flower Garden",
         "1 : Jungle",
         "2 : Castle & Fortress",
         "3 : In Front of Boss's Room",
         "4 : Underground",
         "5 : Kamek's Theme",
         "6 : Bonus Game",
         "7 : In Front of Boss's Room",
         "8 : Kamek's Theme",
         "9 : Big Boss BGM",
         "A : Athletic",
         "B : Powerful Baby",
         "C : No Music",
         "D : In Front of Boss's Room",
         "E :",
         "F :"
      });
      this.CB_Music.Location = new Point(47, 115);
      this.CB_Music.Name = "CB_Music";
      this.CB_Music.Size = new Size(182, 21);
      this.CB_Music.TabIndex = 1;
      this.CB_Music.SelectedIndexChanged += new EventHandler(this.CB_TilesetBG1_SelectedIndexChanged);
      this.tabPage6.Controls.Add((Control) this.groupBox9);
      this.tabPage6.Location = new Point(4, 40);
      this.tabPage6.Name = "tabPage6";
      this.tabPage6.Padding = new Padding(3);
      this.tabPage6.Size = new Size(293, 264);
      this.tabPage6.TabIndex = 5;
      this.tabPage6.Text = "Item Memory";
      this.tabPage6.UseVisualStyleBackColor = true;
      this.groupBox9.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.groupBox9.Controls.Add((Control) this.CB_ItemMemory);
      this.groupBox9.Location = new Point(8, 6);
      this.groupBox9.Name = "groupBox9";
      this.groupBox9.Size = new Size(277, 251);
      this.groupBox9.TabIndex = 0;
      this.groupBox9.TabStop = false;
      this.groupBox9.Text = "Item Memory";
      this.CB_ItemMemory.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.CB_ItemMemory.DropDownStyle = ComboBoxStyle.DropDownList;
      this.CB_ItemMemory.FormattingEnabled = true;
      this.CB_ItemMemory.Location = new Point(111, 115);
      this.CB_ItemMemory.Name = "CB_ItemMemory";
      this.CB_ItemMemory.Size = new Size(55, 21);
      this.CB_ItemMemory.TabIndex = 1;
      this.CB_ItemMemory.SelectedIndexChanged += new EventHandler(this.CB_TilesetBG1_SelectedIndexChanged);
      this.tabPage7.Controls.Add((Control) this.groupBox10);
      this.tabPage7.Location = new Point(4, 40);
      this.tabPage7.Name = "tabPage7";
      this.tabPage7.Padding = new Padding(3);
      this.tabPage7.Size = new Size(293, 264);
      this.tabPage7.TabIndex = 6;
      this.tabPage7.Text = "Option";
      this.tabPage7.UseVisualStyleBackColor = true;
      this.groupBox10.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.groupBox10.Controls.Add((Control) this.CheckBox_World6);
      this.groupBox10.Location = new Point(8, 6);
      this.groupBox10.Name = "groupBox10";
      this.groupBox10.Size = new Size(277, 43);
      this.groupBox10.TabIndex = 0;
      this.groupBox10.TabStop = false;
      this.groupBox10.Text = "Visual";
      this.CheckBox_World6.AutoSize = true;
      this.CheckBox_World6.Location = new Point(6, 19);
      this.CheckBox_World6.Name = "CheckBox_World6";
      this.CheckBox_World6.Size = new Size(123, 16);
      this.CheckBox_World6.TabIndex = 0;
      this.CheckBox_World6.Text = "Assume as World 6";
      this.CheckBox_World6.UseVisualStyleBackColor = true;
      this.CheckBox_World6.CheckedChanged += new EventHandler(this.CheckBox_World6_CheckedChanged);
      this.panel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.panel1.Controls.Add((Control) this.Discard_Button);
      this.panel1.Controls.Add((Control) this.Apply_Button);
      this.panel1.Location = new Point(135, 317);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(169, 33);
      this.panel1.TabIndex = 4;
      this.Discard_Button.DialogResult = DialogResult.Cancel;
      this.Discard_Button.Enabled = false;
      this.Discard_Button.Location = new Point(87, 3);
      this.Discard_Button.Name = "Discard_Button";
      this.Discard_Button.Size = new Size(75, 23);
      this.Discard_Button.TabIndex = 3;
      this.Discard_Button.Text = "Discard";
      this.Discard_Button.UseVisualStyleBackColor = true;
      this.Discard_Button.Click += new EventHandler(this.Discard_Button_Click);
      this.Apply_Button.Enabled = false;
      this.Apply_Button.Location = new Point(6, 3);
      this.Apply_Button.Name = "Apply_Button";
      this.Apply_Button.Size = new Size(75, 23);
      this.Apply_Button.TabIndex = 2;
      this.Apply_Button.Text = "Apply";
      this.Apply_Button.UseVisualStyleBackColor = true;
      this.Apply_Button.Click += new EventHandler(this.Apply_Button_Click);
      this.AutoHidePortion = 315.0;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(307, 355);
      this.Controls.Add((Control) this.tableLayoutPanel1);
      //this.DefaultFloatWindowSize = new Size(315, 381);
      this.DockAreas = DockAreas.Float | DockAreas.DockLeft | DockAreas.DockRight;
      this.Enabled = false;
      this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
      this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
      this.MinimumSize = new Size(310, 26);
      this.Name = "HeaderEditor";
      this.ShowHint = DockState.DockRightAutoHide;
      this.Text = "HeaderEditor";
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tabControl1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.tabPage2.ResumeLayout(false);
      this.groupBox5.ResumeLayout(false);
      this.groupBox5.PerformLayout();
      this.groupBox4.ResumeLayout(false);
      this.groupBox4.PerformLayout();
      this.groupBox3.ResumeLayout(false);
      this.tabPage3.ResumeLayout(false);
      this.groupBox6.ResumeLayout(false);
      this.groupBox6.PerformLayout();
      this.tabPage4.ResumeLayout(false);
      this.groupBox7.ResumeLayout(false);
      this.groupBox7.PerformLayout();
      this.tabPage5.ResumeLayout(false);
      this.groupBox8.ResumeLayout(false);
      this.tabPage6.ResumeLayout(false);
      this.groupBox9.ResumeLayout(false);
      this.tabPage7.ResumeLayout(false);
      this.groupBox10.ResumeLayout(false);
      this.groupBox10.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    public class HexTextBox : TextBox
    {
      protected override void WndProc(ref Message m)
      {
        switch (m.Msg)
        {
          case 258:
            char c1 = Convert.ToChar((int) m.WParam);
            if (!char.IsControl(c1) && (48 > (int) c1 || (int) c1 > 57) && ((97 > (int) c1 || (int) c1 > 102) && (65 > (int) c1 || (int) c1 > 70)) && (int) c1 != 32)
            {
              m.Result = (IntPtr) null;
              return;
            }
            else
              break;
          case 770:
            string str = Clipboard.GetDataObject().GetData(DataFormats.Text) as string;
            if (str == null)
              return;
            string s = "";
            foreach (char c2 in str)
            {
              if (char.IsControl(c2))
              {
                if (this.Multiline && ((int) c2 == 10 || (int) c2 == 13))
                  s = s +  c2;
              }
              else if (48 <= (int) c2 && (int) c2 <= 57 || 97 <= (int) c2 && (int) c2 <= 102 || (65 <= (int) c2 && (int) c2 <= 70 || (int) c2 == 32))
                s = s +  c2;
            }
            IntPtr num = Marshal.StringToHGlobalUni(s);
            Win32.SendMessageW(this.Handle, 194U, (IntPtr) 1, num);
            Marshal.FreeHGlobal(num);
            return;
        }
        base.WndProc(ref m);
      }
    }

    private class EditCommand : LevelTab.ICommand
    {
      private HeaderEditor target;
      private byte[] oldHeader;
      private byte[] newHeader;

      public EditCommand(HeaderEditor target, byte[] oldHeader, byte[] newHeader)
      {
        this.target = target;
        this.oldHeader = oldHeader;
        this.newHeader = newHeader;
      }

      public void Redo()
      {
        this.target.UndoRedo(this.newHeader);
      }

      public void Undo()
      {
        this.target.UndoRedo(this.oldHeader);
      }
    }
  }
