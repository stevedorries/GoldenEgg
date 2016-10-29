
// Type: GE.Forms.LevelTab

// MVID: 7AA6A484-F524-42F2-9571-0947D386B578
// Assembly location: C:\Documents and Settings\THE RAIN\Desktop\ge.exe

using GE;
using Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace GE.Forms
{
  public class LevelTab : DockContent
  {
    private string statusBarLabel = "";
    private Library.Bitmap bmp = new Library.Bitmap();
    private Library.Bitmap backbmp = new Library.Bitmap();
    private byte[,] bg1bmp = new byte[1024, 64];
    private byte[,] bg3bmp = new byte[256, 64];
    private byte[,] sprbmp = new byte[512, 64];
    private uint[] palette = new uint[256];
    public LevelTab.View view = LevelTab.View.Objects | LevelTab.View.Sprites;
    private SortedSet<int> selectedID = new SortedSet<int>();
    private SortedSet<int> selectedIDbackup = new SortedSet<int>();
    private Win32.SCROLLINFO vScroll = new Win32.SCROLLINFO(31U, 2047);
    private Win32.SCROLLINFO hScroll = new Win32.SCROLLINFO(31U, 4095);
    public Stack<LevelTab.ICommand> undoBuffer = new Stack<LevelTab.ICommand>();
    public Stack<LevelTab.ICommand> redoBuffer = new Stack<LevelTab.ICommand>();
    private static Library.Font sFont = new Library.Font(15, "Courier New");
    private static Library.Bitmap hexBitmap = new Library.Bitmap();
    private static byte[] hexBitmapPixel = new byte[72]
    {
      (byte) 98,
      (byte) 102,
      (byte) 47,
      (byte) 111,
      (byte) 102,
      (byte) 46,
      (byte) 108,
      byte.MaxValue,
      (byte) 158,
      (byte) 153,
      (byte) 40,
      (byte) 145,
      (byte) 153,
      (byte) 89,
      (byte) 154,
      (byte) 136,
      (byte) 146,
      (byte) 153,
      (byte) 168,
      (byte) 129,
      (byte) 153,
      (byte) 89,
      (byte) 153,
      (byte) 136,
      (byte) 146,
      (byte) 17,
      (byte) 174,
      (byte) 226,
      (byte) 153,
      (byte) 153,
      (byte) 137,
      (byte) 136,
      (byte) 146,
      (byte) 38,
      (byte) 169,
      (byte) 146,
      (byte) 105,
      (byte) 158,
      (byte) 137,
      (byte) 238,
      (byte) 146,
      (byte) 65,
      (byte) 161,
      (byte) 146,
      (byte) 151,
      (byte) 249,
      (byte) 153,
      (byte) 136,
      (byte) 146,
      (byte) 137,
      (byte) 249,
      (byte) 148,
      (byte) 145,
      (byte) 153,
      (byte) 153,
      (byte) 136,
      (byte) 146,
      (byte) 137,
      (byte) 41,
      (byte) 148,
      (byte) 153,
      (byte) 153,
      (byte) 154,
      (byte) 136,
      (byte) 98,
      (byte) 246,
      (byte) 38,
      (byte) 100,
      (byte) 102,
      (byte) 158,
      (byte) 108,
      (byte) 248
    };
    private static uint[,] searchIndex = new uint[15, 2]
    {
      {
        27604U,
        32672U
      },
      {
        60928U,
        65536U
      },
      {
        390144U,
        393216U
      },
      {
        553570U,
        557056U
      },
      {
        576021U,
        589824U
      },
      {
        608009U,
        622592U
      },
      {
        654944U,
        655360U
      },
      {
        655360U,
        720896U
      },
      {
        720896U,
        753664U
      },
      {
        785655U,
        786432U
      },
      {
        844002U,
        851968U
      },
      {
        916528U,
        917504U
      },
      {
        1094650U,
        1114112U
      },
      {
        1114112U,
        1118427U
      },
      {
        1135440U,
        1179648U
      }
    };
    private static ulong[] pixel_bit = new ulong[256]
    {
      0UL,
      72057594037927936UL,
      281474976710656UL,
      72339069014638592UL,
      1099511627776UL,
      72058693549555712UL,
      282574488338432UL,
      72340168526266368UL,
      4294967296UL,
      72057598332895232UL,
      281479271677952UL,
      72339073309605888UL,
      1103806595072UL,
      72058697844523008UL,
      282578783305728UL,
      72340172821233664UL,
      16777216UL,
      72057594054705152UL,
      281474993487872UL,
      72339069031415808UL,
      1099528404992UL,
      72058693566332928UL,
      282574505115648UL,
      72340168543043584UL,
      4311744512UL,
      72057598349672448UL,
      281479288455168UL,
      72339073326383104UL,
      1103823372288UL,
      72058697861300224UL,
      282578800082944UL,
      72340172838010880UL,
      65536UL,
      72057594037993472UL,
      281474976776192UL,
      72339069014704128UL,
      1099511693312UL,
      72058693549621248UL,
      282574488403968UL,
      72340168526331904UL,
      4295032832UL,
      72057598332960768UL,
      281479271743488UL,
      72339073309671424UL,
      1103806660608UL,
      72058697844588544UL,
      282578783371264UL,
      72340172821299200UL,
      16842752UL,
      72057594054770688UL,
      281474993553408UL,
      72339069031481344UL,
      1099528470528UL,
      72058693566398464UL,
      282574505181184UL,
      72340168543109120UL,
      4311810048UL,
      72057598349737984UL,
      281479288520704UL,
      72339073326448640UL,
      1103823437824UL,
      72058697861365760UL,
      282578800148480UL,
      72340172838076416UL,
      256UL,
      72057594037928192UL,
      281474976710912UL,
      72339069014638848UL,
      1099511628032UL,
      72058693549555968UL,
      282574488338688UL,
      72340168526266624UL,
      4294967552UL,
      72057598332895488UL,
      281479271678208UL,
      72339073309606144UL,
      1103806595328UL,
      72058697844523264UL,
      282578783305984UL,
      72340172821233920UL,
      16777472UL,
      72057594054705408UL,
      281474993488128UL,
      72339069031416064UL,
      1099528405248UL,
      72058693566333184UL,
      282574505115904UL,
      72340168543043840UL,
      4311744768UL,
      72057598349672704UL,
      281479288455424UL,
      72339073326383360UL,
      1103823372544UL,
      72058697861300480UL,
      282578800083200UL,
      72340172838011136UL,
      65792UL,
      72057594037993728UL,
      281474976776448UL,
      72339069014704384UL,
      1099511693568UL,
      72058693549621504UL,
      282574488404224UL,
      72340168526332160UL,
      4295033088UL,
      72057598332961024UL,
      281479271743744UL,
      72339073309671680UL,
      1103806660864UL,
      72058697844588800UL,
      282578783371520UL,
      72340172821299456UL,
      16843008UL,
      72057594054770944UL,
      281474993553664UL,
      72339069031481600UL,
      1099528470784UL,
      72058693566398720UL,
      282574505181440UL,
      72340168543109376UL,
      4311810304UL,
      72057598349738240UL,
      281479288520960UL,
      72339073326448896UL,
      1103823438080UL,
      72058697861366016UL,
      282578800148736UL,
      72340172838076672UL,
      1UL,
      72057594037927937UL,
      281474976710657UL,
      72339069014638593UL,
      1099511627777UL,
      72058693549555713UL,
      282574488338433UL,
      72340168526266369UL,
      4294967297UL,
      72057598332895233UL,
      281479271677953UL,
      72339073309605889UL,
      1103806595073UL,
      72058697844523009UL,
      282578783305729UL,
      72340172821233665UL,
      16777217UL,
      72057594054705153UL,
      281474993487873UL,
      72339069031415809UL,
      1099528404993UL,
      72058693566332929UL,
      282574505115649UL,
      72340168543043585UL,
      4311744513UL,
      72057598349672449UL,
      281479288455169UL,
      72339073326383105UL,
      1103823372289UL,
      72058697861300225UL,
      282578800082945UL,
      72340172838010881UL,
      65537UL,
      72057594037993473UL,
      281474976776193UL,
      72339069014704129UL,
      1099511693313UL,
      72058693549621249UL,
      282574488403969UL,
      72340168526331905UL,
      4295032833UL,
      72057598332960769UL,
      281479271743489UL,
      72339073309671425UL,
      1103806660609UL,
      72058697844588545UL,
      282578783371265UL,
      72340172821299201UL,
      16842753UL,
      72057594054770689UL,
      281474993553409UL,
      72339069031481345UL,
      1099528470529UL,
      72058693566398465UL,
      282574505181185UL,
      72340168543109121UL,
      4311810049UL,
      72057598349737985UL,
      281479288520705UL,
      72339073326448641UL,
      1103823437825UL,
      72058697861365761UL,
      282578800148481UL,
      72340172838076417UL,
      257UL,
      72057594037928193UL,
      281474976710913UL,
      72339069014638849UL,
      1099511628033UL,
      72058693549555969UL,
      282574488338689UL,
      72340168526266625UL,
      4294967553UL,
      72057598332895489UL,
      281479271678209UL,
      72339073309606145UL,
      1103806595329UL,
      72058697844523265UL,
      282578783305985UL,
      72340172821233921UL,
      16777473UL,
      72057594054705409UL,
      281474993488129UL,
      72339069031416065UL,
      1099528405249UL,
      72058693566333185UL,
      282574505115905UL,
      72340168543043841UL,
      4311744769UL,
      72057598349672705UL,
      281479288455425UL,
      72339073326383361UL,
      1103823372545UL,
      72058697861300481UL,
      282578800083201UL,
      72340172838011137UL,
      65793UL,
      72057594037993729UL,
      281474976776449UL,
      72339069014704385UL,
      1099511693569UL,
      72058693549621505UL,
      282574488404225UL,
      72340168526332161UL,
      4295033089UL,
      72057598332961025UL,
      281479271743745UL,
      72339073309671681UL,
      1103806660865UL,
      72058697844588801UL,
      282578783371521UL,
      72340172821299457UL,
      16843009UL,
      72057594054770945UL,
      281474993553665UL,
      72339069031481601UL,
      1099528470785UL,
      72058693566398721UL,
      282574505181441UL,
      72340168543109377UL,
      4311810305UL,
      72057598349738241UL,
      281479288520961UL,
      72339073326448897UL,
      1103823438081UL,
      72058697861366017UL,
      282578800148737UL,
      72340172838076673UL
    };
    private const int SizingPosition = 12;
    private const int NegativeSizingPosition = 4;
    private IContainer components;
    private ToolTip toolTip;
    private MainForm mainForm;
    private Level level;
    private LevelTab.DoSelect doSelect;
    public LevelTab.DoUnselect doUnselect;
    private LevelTab.DoFocusOn doFocusOn;
    private LevelTab.DoCopy doCopy;
    private LevelTab.DoMove doMove;
    public LevelTab.DoDelete doDelete;
    private LevelTab.Render8x8Tile RenderTile;
    public byte[] LevelHeaderBackup;
    public Level.CustomGradient CustomGradientBackup;
    public bool paletteEditorButtonEnabled;
    private bool[] rerenderFlag;
    private Point selectionOrigin;
    private Rectangle selectionRect;
    private bool dragging;
    private Keys keyState;
    private Point lastMouse;
    private bool atLeastOnceMoved;
    private LevelTab.EditMode _editMode;
    private LevelTab.EditType editType;
    private object selectedObjects;
    public int actionCount;
    public bool internalDisableUpdate;

    private LevelEditor levelEditor
    {
      get
      {
        return this.mainForm.LevelEditor;
      }
    }

    private SNES.ROMFile YI
    {
      get
      {
        return this.mainForm.YI;
      }
    }

    public string StatusBarLabel
    {
      get
      {
        return this.statusBarLabel;
      }
      set
      {
        this.statusBarLabel = this.levelEditor.StatusBarLabel = value;
      }
    }

    public Level Level
    {
      get
      {
        return this.level;
      }
    }

    public byte[] LevelHeader
    {
      get
      {
        return this.level.Header;
      }
    }

    public Level.ScreenExit[] ScreenExits
    {
      get
      {
        return this.level.Exits;
      }
    }

    public Level.CustomGradient CustomGradient
    {
      get
      {
        return this.level.customGradient;
      }
    }

    public bool IsWorld6
    {
      get
      {
        return this.level.IsWorld6;
      }
      set
      {
        this.level.IsWorld6 = value;
      }
    }

    public uint[] Palette
    {
      get
      {
        return this.palette;
      }
    }

    public uint[] Gradient
    {
      get
      {
        return this.level.Gradient;
      }
    }

    public SortedSet<int> SelectedID
    {
      get
      {
        return this.selectedID;
      }
    }

    public LevelTab.EditMode editMode
    {
      get
      {
        return this._editMode;
      }
    }

    public int ScrollY16
    {
      get
      {
        return this.vScroll.nPos / 16;
      }
    }

    public int ScrollX16
    {
      get
      {
        return this.hScroll.nPos / 16;
      }
    }

    public int VerticalScrollPosition
    {
      get
      {
        return this.vScroll.nPos;
      }
    }

    public int HorizontalScrollPosition
    {
      get
      {
        return this.hScroll.nPos;
      }
    }

    protected override CreateParams CreateParams
    {
      get
      {
        CreateParams createParams = base.CreateParams;
        createParams.Style |= 3145728;
        return createParams;
      }
    }

    static unsafe LevelTab()
    {
      LevelTab.hexBitmap.Create((IntPtr) null, 64, 18);
      for (int y = 0; y < 9; ++y)
      {
        for (int x = 0; x < 64; ++x)
        {
          *LevelTab.hexBitmap.PixelBits(x, y) = ((int) LevelTab.hexBitmapPixel[y * 8 + x / 8] & 1 << (x & 7 ^ 7)) != 0 ? 16316664U : 16252928U;
          *LevelTab.hexBitmap.PixelBits(x, y + 9) = ((int) LevelTab.hexBitmapPixel[y * 8 + x / 8] & 1 << (x & 7 ^ 7)) != 0 ? 16316664U : 12583160U;
        }
      }
    }

    public LevelTab(MainForm MainForm, byte number)
    {
      this.mainForm = MainForm;
      this.InitializeComponent();
      this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
      this.UpdateStyles();
      this.Text = string.Format("Level {0:X2}",  number);
      this.OpenLevel(number);
      this.LevelHeaderBackup = (byte[]) this.LevelHeader.Clone();
      this.CustomGradientBackup = this.level.customGradient.Clone();
      this.doSelect = new LevelTab.DoSelect(this.SelectObject);
      this.doUnselect = new LevelTab.DoUnselect(this.UnselectObject);
      this.doFocusOn = new LevelTab.DoFocusOn(this.FocusOnObject);
      this.doCopy = new LevelTab.DoCopy(this.CopyObject);
      this.doMove = new LevelTab.DoMove(this.MoveObject);
      this.doDelete = new LevelTab.DoDelete(this.DeleteObject);
      this.toolTip.Tag =  -1;
      Win32.SendMessage((IntPtr) typeof (ToolTip).InvokeMember("Handle", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetProperty, (Binder) null,  this.toolTip, (object[]) null), 1048U, (IntPtr) null, (IntPtr) 200);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      this.toolTip = new ToolTip(this.components);
      this.SuspendLayout();
      this.toolTip.Tag =  "";
      this.AllowDrop = true;
      this.AllowEndUserDocking = false;
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.ClientSize = new Size(292, 266);
      this.DockAreas = DockAreas.Document;
      this.DoubleBuffered = true;
      this.Font = new System.Drawing.Font("MS UI Gothic", 9f, FontStyle.Regular, GraphicsUnit.Point, 0x80);
      this.Name = "LevelTab";
      this.Text = "LevelTab";
      this.DragDrop += new DragEventHandler(this.LevelTab_DragDrop);
      this.DragEnter += new DragEventHandler(this.LevelTab_DragEnter);
      this.DragOver += new DragEventHandler(this.LevelTab_DragOver);
      this.MouseCaptureChanged += new EventHandler(this.LevelTab_MouseCaptureChanged);
      this.MouseDown += new MouseEventHandler(this.LevelTab_MouseDown);
      this.MouseMove += new MouseEventHandler(this.LevelTab_MouseMove);
      this.MouseUp += new MouseEventHandler(this.LevelTab_MouseUp);
      this.ResumeLayout(false);
    }

    protected override void OnClosing(CancelEventArgs e)
    {
      if (this.undoBuffer.Count == this.actionCount)
        return;
      switch (MessageBox.Show("Do you want to save the level?", "Golden Egg", MessageBoxButtons.YesNoCancel))
      {
        case DialogResult.Cancel:
          e.Cancel = true;
          break;
        case DialogResult.Yes:
          this.Save();
          break;
      }
    }

    protected override void OnClosed(EventArgs e)
    {
      base.OnClosed(e);
      this.levelEditor.OnLevelTabClose();
    }

    public unsafe bool Save()
    {
      if ((int) this.level.Number == 56)
      {
        int num = (int) MessageBox.Show("This level cannot be saved.", "Hardcoded Level");
        return false;
      }
      else
      {
        this.StatusBarLabel = "Saving the level...";
        byte[] numArray1 = this.YI.ROM[0].ToByteArray(this.YI.ROM.Length);
        fixed (byte* numPtr1 = numArray1)
        {
          List<byte> list1 = new List<byte>();
          List<byte> list2 = new List<byte>();
          byte num1 = (byte) 0;
          byte* numPtr2 = numPtr1 + 527109;
          byte num2 = *numPtr2;
          int index1 = 0;
          int num3 = 8;
          while (true)
          {
            if ((int) num2 == 0)
            {
              if ((int) (num2 = *++numPtr2) != 0)
                ++index1;
              else
                break;
            }
            num1 = (byte) ((int) num1 << 1 | (((int) this.level.Header[index1] & 1 << (int) num2 - 1) != 0 ? 1 : 0));
            if (--num3 == 0)
            {
              list1.Add(num1);
              num1 = (byte) 0;
              num3 = 8;
            }
            --num2;
          }
          if (num3 != 8)
            list1.Add((byte) ((uint) num1 << num3));
          foreach (Level.Object @object in this.level.Objects)
          {
            if ((int) @object.num == 0)
            {
              list1.Add((byte) 0);
              list1.Add(@object.locH);
              list1.Add(@object.locL);
              list1.Add(@object.exnum);
            }
            else
            {
              byte num4 = (byte) ((uint) (numPtr1 + 591084)[(int) @object.num] & 3U);
              list1.Add(@object.num);
              list1.Add(@object.locH);
              list1.Add(@object.locL);
              if ((int) num4 != 1)
                list1.Add((int) (short) @object.width < 0 ? (byte) ((int) @object.width + 1) : (byte) ((int) @object.width - 1));
              if ((int) num4 != 0)
                list1.Add((int) (short) @object.height < 0 ? (byte) ((int) @object.height + 1) : (byte) ((int) @object.height - 1));
            }
          }
          list1.Add(byte.MaxValue);
          for (int index2 = 0; index2 < 128; ++index2)
          {
            if (this.level.Exits[index2].enabled)
            {
              list1.Add((byte) index2);
              list1.Add(this.level.Exits[index2].dest);
              list1.Add(this.level.Exits[index2].x);
              list1.Add(this.level.Exits[index2].y);
              list1.Add(this.level.Exits[index2].type);
            }
          }
          list1.Add(byte.MaxValue);
          foreach (Level.Sprite sprite in this.level.Sprites)
          {
            list2.Add((byte) sprite.num);
            list2.Add((byte) ((int) sprite.y << 1 | (int) sprite.num >> 8));
            list2.Add(sprite.x);
          }
          list2.Add(byte.MaxValue);
          list2.Add(byte.MaxValue);
          int[][] all_region = new int[222][];
          uint[] numArray2 = this.SearchForFreeSpace(numArray1, (int) this.level.Number, new uint[2]
          {
            (uint) list1.Count,
            (uint) list2.Count
          }, ref all_region);
          if ((int) numArray2[0] == 0 || (int) numArray2[1] == 0)
          {
            int num4 = (int) MessageBox.Show("Couldn't find any free space in the ROM.", "No More Free Space", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            this.StatusBarLabel = "Saving the level... Failed.";
            return false;
          }
          else
          {
            bool flag1 = false;
            bool flag2 = false;
            List<string> list3 = new List<string>();
            if (all_region[(int) this.level.Number] != null)
            {
              for (int index2 = 0; index2 <= 221; ++index2)
              {
                if (all_region[index2] != null && index2 != (int) this.level.Number)
                {
                  if (this.level.removeOldObject)
                  {
                    if (all_region[index2][0] != 0 && all_region[(int) this.level.Number][1] >= all_region[index2][0] && all_region[index2][1] >= all_region[(int) this.level.Number][0])
                    {
                      list3.Add(string.Format("Level {0:X2} Object data ({1:X6}-{2:X6}) is overlapped with Level {3:X2} Object data ({4:X6}-{5:X6})",  this.level.Number,  all_region[(int) this.level.Number][0],  all_region[(int) this.level.Number][1],  index2,  all_region[index2][0],  all_region[index2][1]));
                      flag1 = true;
                    }
                    if (all_region[index2][2] != 0 && all_region[(int) this.level.Number][1] >= all_region[index2][2] && all_region[index2][3] >= all_region[(int) this.level.Number][0])
                    {
                      list3.Add(string.Format("Level {0:X2} Object data ({1:X6}-{2:X6}) is overlapped with Level {3:X2} Sprite data ({4:X6}-{5:X6})",  this.level.Number,  all_region[(int) this.level.Number][0],  all_region[(int) this.level.Number][1],  index2,  all_region[index2][2],  all_region[index2][3]));
                      flag1 = true;
                    }
                    if (this.level.removeOldSprite && all_region[(int) this.level.Number][1] >= all_region[(int) this.level.Number][2] && all_region[(int) this.level.Number][3] >= all_region[(int) this.level.Number][0])
                    {
                      list3.Add(string.Format("Level {0:X2} Object data ({1:X6}-{2:X6}) is overlapped with Level {0:X2} Sprite data ({3:X6}-{4:X6})",  this.level.Number,  all_region[(int) this.level.Number][0],  all_region[(int) this.level.Number][1],  all_region[(int) this.level.Number][2],  all_region[(int) this.level.Number][3]));
                      flag1 = true;
                      flag2 = true;
                    }
                  }
                  if (this.level.removeOldSprite)
                  {
                    if (all_region[index2][0] != 0 && all_region[index2][1] >= all_region[(int) this.level.Number][2] && all_region[(int) this.level.Number][3] >= all_region[index2][0])
                    {
                      list3.Add(string.Format("Level {0:X2} Sprite data ({1:X6}-{2:X6}) is overlapped with Level {3:X2} Object data ({4:X6}-{5:X6})",  this.level.Number,  all_region[(int) this.level.Number][2],  all_region[(int) this.level.Number][3],  index2,  all_region[index2][0],  all_region[index2][1]));
                      flag2 = true;
                    }
                    if (all_region[index2][2] != 0 && all_region[(int) this.level.Number][3] >= all_region[index2][2] && all_region[index2][3] >= all_region[(int) this.level.Number][2])
                    {
                      list3.Add(string.Format("Level {0:X2} Sprite data ({1:X6}-{2:X6}) is overlapped with Level {3:X2} Sprite data ({4:X6}-{5:X6})",  this.level.Number,  all_region[(int) this.level.Number][2],  all_region[(int) this.level.Number][3],  index2,  all_region[index2][2],  all_region[index2][3]));
                      flag2 = true;
                    }
                  }
                }
              }
            }
            foreach (string text in list3)
            {
              int num4 = (int) MessageBox.Show(text, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            bool flag3 = this.level.removeOldObject;
            bool flag4 = this.level.removeOldSprite;
            if (flag1 || flag2)
            {
              if (MessageBox.Show("The old level data is overlapped with other level. Do you want to save the level?", "Golden Egg", MessageBoxButtons.YesNo) == DialogResult.No)
              {
                this.StatusBarLabel = "Saving the level... Canceled.";
                return false;
              }
              else if (MessageBox.Show("Do you want to remove the old level data? (Not recommended)", "Golden Egg", MessageBoxButtons.YesNo) == DialogResult.No)
              {
                if (flag1)
                  flag3 = false;
                if (flag2)
                  flag4 = false;
              }
            }
            if (flag3)
              Memory.Set(numArray1, all_region[(int) this.level.Number][0], all_region[(int) this.level.Number][1] - all_region[(int) this.level.Number][0] + 1, (byte) 0);
            if (flag4)
              Memory.Set(numArray1, all_region[(int) this.level.Number][2], all_region[(int) this.level.Number][3] - all_region[(int) this.level.Number][2] + 1, (byte) 0);
            list1.CopyTo(numArray1, (int) numArray2[0] & 2097151);
            list2.CopyTo(numArray1, (int) numArray2[1] & 2097151);
            *(int*) (numPtr1 + 784323 + (this.level.Number * 6)) = (int) *(uint*) (numPtr1 + 784323 + (this.level.Number * 6)) & -16777216 | (int) numArray2[0];
            *(int*) (numPtr1 + 784323 + (this.level.Number * 6) + 3) = (int) *(uint*) (numPtr1 + 784323 + (this.level.Number * 6) + 3) & -16777216 | (int) numArray2[1];
            this.level.removeOldObject = true;
            this.level.removeOldSprite = true;
            try
            {
              this.YI.Save((string) null, numArray1);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
              int num4 = (int) MessageBox.Show("Couldn't write to file", "ERROR");
              return false;
            }
            // ISSUE: __unpin statement
            //__unpin(numPtr1);
            this.actionCount = this.undoBuffer.Count;
            this.StatusBarLabel = "Saving the level... Done!";
            return true;
          }
        }
      }
    }

    private uint[] SearchForFreeSpace(byte[] rom, int level_number, uint[] required_size, ref int[][] all_region)
    {
      byte[] array = (byte[]) rom.Clone();
      for (int level_number1 = 0; level_number1 <= 221; ++level_number1)
      {
        int[] levelDataRegion = this.GetLevelDataRegion(rom, level_number1);
        if (levelDataRegion != null)
        {
          Memory.Set(array, levelDataRegion[0], levelDataRegion[1] - levelDataRegion[0] + 1, level_number == level_number1 ? (byte) 0 : (byte) 85);
          Memory.Set(array, levelDataRegion[2], levelDataRegion[3] - levelDataRegion[2] + 1, level_number == level_number1 ? (byte) 0 : (byte) 85);
          if (all_region != null)
            all_region[level_number1] = levelDataRegion;
        }
      }
      uint[] numArray = new uint[required_size.Length];
      for (int index1 = 0; index1 < required_size.Length; ++index1)
      {
        for (int index2 = 0; index2 < LevelTab.searchIndex.GetLength(0); ++index2)
        {
          numArray[index1] = 0U;
          uint num1 = LevelTab.searchIndex[index2, 0];
          uint num2 = required_size[index1];
          for (; num1 < LevelTab.searchIndex[index2, 1]; ++num1)
          {
            if (array[num1] != 0 && array[num1] != byte.MaxValue)
              num2 = required_size[index1];
            else if ((int) --num2 == 0)
            {
              numArray[index1] = (uint) ((int) num1 - ((int) required_size[index1] - 1) | 4194304);
              Memory.Set(array, (int) numArray[index1] & 2097151, (int) required_size[index1], (byte) 85);
              index2 = LevelTab.searchIndex.GetLength(0);
              break;
            }
          }
        }
      }
      return numArray;
    }

    public unsafe int[] GetLevelDataRegion(byte[] rom, int level_number)
    {
      fixed (byte* numPtr1 = rom)
      {
        uint num1 = this.YI.AddressSNEStoPC(*(uint*) (numPtr1 + (784323 + level_number * 6)) & 16777215U);
        uint num2 = this.YI.AddressSNEStoPC(*(uint*) (numPtr1 + (784323 + level_number * 6 + 3)) & 16777215U);
        byte* numPtr2 = numPtr1 + (int) num1;
        if ((int) num1 != 0)
        {
          if (level_number != 56)
            numPtr2 += 10;
          byte* numPtr3;
          while (true)
          {
            int num3;
            do
            {
              byte num4 = *numPtr2;
              numPtr3 = numPtr2 + 1;
              if (num4 != byte.MaxValue)
              {
                numPtr2 = numPtr3 + 2;
                if ((int) num4 != 0)
                {
                  num3 = (int) numPtr1[591084 + (int) num4] & 3;
                  if (num3 != 1)
                    ++numPtr2;
                }
                else
                  goto label_9;
              }
              else
                goto label_11;
            }
            while (num3 == 0);
            ++numPtr2;
            continue;
label_9:
            ++numPtr2;
          }
label_11:
          while ((int) (sbyte) *numPtr3 >= 0)
            numPtr3 += 5;
          numPtr2 = numPtr3 + 1;
        }
        byte* numPtr4 = numPtr1 + (int) num2;
        if ((int) num2 != 0)
        {
          while (*(ushort*) numPtr4 != ushort.MaxValue)
            numPtr4 += 3;
          numPtr4 += 2;
        }
        return new int[4]
        {
          (int) num1,
          (int) (numPtr2 - numPtr1 - 1L),
          (int) num2,
          (int) (numPtr4 - numPtr1 - 1L)
        };
      }
    }

    private void OpenLevel(byte level_number)
    {
      Level level = new Level(this.YI);
      level.LoadLevel(level_number, false);
      this.level = level;
      this.LoadVRAMIntoBitmapArray(this.bg1bmp, (ushort) 28672, (int) this.level.Header[9] == 10 ? (byte) 2 : (byte) 4, 1024);
      this.RenderTile = (int) this.level.Header[9] != 10 ? new LevelTab.Render8x8Tile(this.Render4bpp) : new LevelTab.Render8x8Tile(this.Render2bpp);
      this.FlushPalette();
    }

    public void ReloadLevel()
    {
      this.level.ReloadLevel();
      this.LoadVRAMIntoBitmapArray(this.bg1bmp, (ushort) 28672, (int) this.level.Header[9] == 10 ? (byte) 2 : (byte) 4, 1024);
      this.RenderTile = (int) this.level.Header[9] != 10 ? new LevelTab.Render8x8Tile(this.Render4bpp) : new LevelTab.Render8x8Tile(this.Render2bpp);
      this.FlushPalette();
      this.levelEditor.paletteEditor.UpdateInformation();
      this.levelEditor.miniMapViewer.UpdateInformation();
      this.RenderLevel();
      Win32.InvalidateRect(this.Handle, (IntPtr) null, false);
    }

    public void ReloadPalette()
    {
      this.level.LoadPalette(this.LevelHeader);
      this.FlushPalette();
      this.levelEditor.paletteEditor.UpdateInformation();
      this.RenderLevel();
      Win32.InvalidateRect(this.Handle, (IntPtr) null, false);
      Win32.UpdateWindow(this.Handle);
    }

    private unsafe void LoadVRAMIntoBitmapArray(byte[,] dest, ushort src_addr, byte bpp, int count)
    {
      src_addr *= (ushort) 2;
      fixed (byte* numPtr1 = this.level.VRAM)
      {
        byte[,] numArray;
        // ISSUE: cast to a reference type
        // ISSUE: cast to a reference type
        // ISSUE: explicit reference operation
        bool notnull = false;
        if(((numArray = dest) == null || numArray.Length == 0)){
            notnull = true;
        }
        fixed (byte* numPtr2 = &numArray[0, 0])
        {
          ulong* numPtr3 = (ulong*) numPtr2;
          if (notnull)
          {
              //numPtr3 = null;
          }
          do
          {
            byte* numPtr4 = (byte*) ((IntPtr) numPtr1 + (int) src_addr);
            int num1 = 0;
            while (num1 < 8)
            {
              ulong num2 = LevelTab.pixel_bit[(int) *numPtr4] | LevelTab.pixel_bit[(int) numPtr4[1]] << 1;
              if ((int) bpp >= 4)
                num2 = num2 | LevelTab.pixel_bit[(int) numPtr4[16]] << 2 | LevelTab.pixel_bit[(int) numPtr4[17]] << 3;
              *numPtr3++ = num2;
              ++num1;
              numPtr4 += 2;
            }
            src_addr += (ushort) ((uint) bpp * 8U);
          }
          while (--count != 0);
        }
      }
    }

    private void FlushPalette()
    {
      for (int index = 0; index < 256; ++index)
        this.palette[index] = SNES.Color.ToRGB(this.level.CGRAM[index]);
    }

    public void RenderLevel()
    {
      this.RenderLevel(this.bmp, (bool[]) null, 0, 0, this.bmp.Width, this.bmp.Height, this.hScroll.nPos / 16, this.vScroll.nPos / 16);
    }

    private void RenderLevel(Library.Bitmap b, bool[] renderFlag, int FromX, int FromY, int ToX, int ToY)
    {
      this.RenderLevel(b, renderFlag, FromX, FromY, ToX, ToY, (this.hScroll.nPos + FromX) / 16, (this.vScroll.nPos + FromY) / 16);
    }

    private unsafe void RenderLevel(Library.Bitmap b, bool[] renderFlag, int FromX, int FromY, int ToX, int ToY, int tile_xpos, int tile_ypos)
    {
      uint* numPtr1 = b.PixelBits(0, 0);
      int num1 = tile_ypos;
      for (int dsty = FromY; dsty < ToY && num1 < 128; ++num1)
      {
        int num2 = tile_xpos;
        for (int dstx = FromX; dstx < ToX && num2 < 256; ++num2)
        {
          if (renderFlag == null || renderFlag[(dstx + dsty * (b.Width / 16)) / 16])
          {
            if ((this.view & LevelTab.View.CheckeredBackground) == (LevelTab.View) 0)
            {
              for (int index1 = 0; index1 < 16; ++index1)
              {
                for (int index2 = 0; index2 < 16; ++index2)
                  (numPtr1 + (dstx | index2))[(dsty | index1) * b.Width] = this.level.Gradient[(num1 << 4 | index1) >> 2];
              }
            }
            else
            {
              for (int index1 = 0; index1 < 16; ++index1)
              {
                for (int index2 = 0; index2 < 16; ++index2)
                  (numPtr1 + (dstx | index2))[(dsty | index1) * b.Width] = ((index2 ^ index1) & 4) != 0 ? 9474192U : 5263440U;
              }
            }
            if ((this.view & LevelTab.View.Objects) != (LevelTab.View) 0)
            {
              Level.LevelTileList levelTileList = this.level.Tiles[num1 & 240 | num2 >> 4][(int) (byte) (num1 << 4) | num2 & 15];
              Level.LevelCommandList levelCommandList = this.level.CommandTiles[num1 * 256 | num2];
              if (levelTileList.Count != 0 || levelCommandList.Count != 0)
              {
                LevelTab.RenderFlag f = LevelTab.RenderFlag.Null;
                if (this.editMode == LevelTab.EditMode.Object)
                {
                  if (levelTileList[0].id > levelCommandList[0])
                  {
                    if (this.selectedID.Contains(levelTileList[0].id))
                    {
                      f = ((int) levelTileList[0].state & 16) != 0 ? LevelTab.RenderFlag.Blue : LevelTab.RenderFlag.Invert;
                    }
                    else
                    {
                      for (int index = 1; index < levelTileList.Count; ++index)
                      {
                        if (this.selectedID.Contains(levelTileList[index].id))
                        {
                          f = (LevelTab.RenderFlag) (12 | (((int) levelTileList[index].state & 16) != 0 ? 192 : 0));
                          goto label_44;
                        }
                      }
                      for (int index = 0; index < levelCommandList.Count; ++index)
                      {
                        if (this.selectedID.Contains(levelCommandList[index]))
                        {
                          f = LevelTab.RenderFlag.Red;
                          break;
                        }
                      }
                    }
                  }
                  else if (this.selectedID.Contains(levelCommandList[0]))
                  {
                    f = LevelTab.RenderFlag.Invert;
                  }
                  else
                  {
                    for (int index = 0; index < levelTileList.Count; ++index)
                    {
                      if (this.selectedID.Contains(levelTileList[index].id))
                      {
                        f = (LevelTab.RenderFlag) (12 | (((int) levelTileList[index].state & 16) != 0 ? 192 : 0));
                        goto label_44;
                      }
                    }
                    for (int index = 1; index < levelCommandList.Count; ++index)
                    {
                      if (this.selectedID.Contains(levelCommandList[index]))
                      {
                        f = LevelTab.RenderFlag.Red;
                        break;
                      }
                    }
                  }
                }
label_44:
                if (levelTileList[0].id > levelCommandList[0])
                {
                  ushort num3 = levelTileList[0].tile;
                  fixed (VariableByte* variableBytePtr = &this.YI.ROM[799730 + (int) this.YI.ROM[799396 + ((int) num3 >> 8 << 1)].u16])
                  {
                    ushort* numPtr2 = (ushort*) ((IntPtr) variableBytePtr + ((int) (byte) num3 * 4) * 2);
                    this.RenderTile(b, dstx, dsty, this.bg1bmp, this.palette, *numPtr2, f);
                    this.RenderTile(b, dstx + 8, dsty, this.bg1bmp, this.palette, numPtr2[1], f);
                    this.RenderTile(b, dstx, dsty + 8, this.bg1bmp, this.palette, numPtr2[2], f);
                    this.RenderTile(b, dstx + 8, dsty + 8, this.bg1bmp, this.palette, numPtr2[3], f);
                  }
                }
                else
                {
                  for (int index1 = 0; index1 < 16; ++index1)
                  {
                    for (int index2 = 0; index2 < 16; ++index2)
                      (numPtr1 + (dstx | index2))[(dsty | index1) * b.Width] = (uint) (index1 - 1) > 13U || (uint) (index2 - 1) > 13U ? 0U : 12583160U;
                  }
                  if ((int) this.level.Objects[levelCommandList[0]].num != 0)
                  {
                    int num3 = (int) this.level.Objects[levelCommandList[0]].num;
                    Win32.BitBlt(b.Handle, dstx + 3, dsty + 3, 4, 9, LevelTab.hexBitmap.Handle, (num3 >> 4) * 4, 9, 13369376U);
                    Win32.BitBlt(b.Handle, dstx + 8, dsty + 3, 4, 9, LevelTab.hexBitmap.Handle, (num3 & 15) * 4, 9, 13369376U);
                  }
                  else
                  {
                    int num3 = (int) this.level.Objects[levelCommandList[0]].exnum;
                    (numPtr1 + (dstx | 1))[(dsty | 6) * b.Width] = (uint) (*(int*) (numPtr1 + (dstx | 1) + (dsty | 7) * b.Width) = *(int*) (numPtr1 + (dstx | 1) + (dsty | 10) * b.Width) = *(int*) (numPtr1 + (dstx | 1) + (dsty | 11) * b.Width) = *(int*) (numPtr1 + (dstx | 2) + (dsty | 8) * b.Width) = *(int*) (numPtr1 + (dstx | 2) + (dsty | 9) * b.Width) = *(int*) (numPtr1 + (dstx | 3) + (dsty | 8) * b.Width) = *(int*) (numPtr1 + (dstx | 3) + (dsty | 9) * b.Width) = *(int*) (numPtr1 + (dstx | 4) + (dsty | 6) * b.Width) = *(int*) (numPtr1 + (dstx | 4) + (dsty | 7) * b.Width) = *(int*) (numPtr1 + (dstx | 4) + (dsty | 10) * b.Width) = *(int*) (numPtr1 + (dstx | 4) + (dsty | 11) * b.Width) = 16316664);
                    Win32.BitBlt(b.Handle, dstx + 6, dsty + 3, 4, 9, LevelTab.hexBitmap.Handle, (num3 >> 4) * 4, 9, 13369376U);
                    Win32.BitBlt(b.Handle, dstx + 11, dsty + 3, 4, 9, LevelTab.hexBitmap.Handle, (num3 & 15) * 4, 9, 13369376U);
                  }
                  if ((f & LevelTab.RenderFlag.Invert) != LevelTab.RenderFlag.Null)
                  {
                    for (int index1 = 0; index1 < 16; ++index1)
                    {
                      for (int index2 = 0; index2 < 16; ++index2)
                      {
                        IntPtr num3 = (IntPtr) (numPtr1 + (dstx | index2) + (dsty | index1) * b.Width);
                        int num4 = (int) *(uint*) num3 ^ 16316664;
                        *(int*) num3 = num4;
                      }
                    }
                  }
                  else if ((f & LevelTab.RenderFlag.Red) != LevelTab.RenderFlag.Null)
                  {
                    for (int index1 = 0; index1 < 16; ++index1)
                    {
                      for (int index2 = 0; index2 < 16; ++index2)
                      {
                        IntPtr num3 = (IntPtr) (numPtr1 + (dstx | index2) + (dsty | index1) * b.Width);
                        int num4 = (int) *(uint*) num3 | 16252928;
                        *(int*) num3 = num4;
                      }
                    }
                  }
                }
              }
            }
          }
          dstx += 16;
        }
        dsty += 16;
      }
      if ((this.view & LevelTab.View.Sprites) == (LevelTab.View) 0)
        return;
      int num5 = -1;
      foreach (Level.Sprite sprite in this.level.Sprites)
      {
        ++num5;
        int num2 = ((int) sprite.x - this.ScrollX16) * 16;
        int num3 = ((int) sprite.y - this.ScrollY16) * 16;
        if ((long) (uint) num2 < (long) this.bmp.Width && (long) (uint) num3 < (long) this.bmp.Height)
        {
          if ((this.editMode != LevelTab.EditMode.Sprite || !this.selectedID.Contains(num5) ? 0 : 2) == 0)
          {
            for (int index1 = 0; index1 < 16; ++index1)
            {
              for (int index2 = 0; index2 < 16; ++index2)
                (numPtr1 + num2 + index2)[(num3 + index1) * this.bmp.Width] = index1 == 0 || index2 == 0 || (index1 == 15 || index2 == 15) ? 0U : 16252928U;
            }
            Win32.BitBlt(this.bmp.Handle, num2 + 1, num3 + 3, 4, 9, LevelTab.hexBitmap.Handle, ((int) sprite.num >> 8) * 4, 0, 13369376U);
            Win32.BitBlt(this.bmp.Handle, num2 + 6, num3 + 3, 4, 9, LevelTab.hexBitmap.Handle, ((int) sprite.num >> 4 & 15) * 4, 0, 13369376U);
            Win32.BitBlt(this.bmp.Handle, num2 + 11, num3 + 3, 4, 9, LevelTab.hexBitmap.Handle, ((int) sprite.num & 15) * 4, 0, 13369376U);
          }
          else
          {
            for (int index1 = 0; index1 < 16; ++index1)
            {
              for (int index2 = 0; index2 < 16; ++index2)
                (numPtr1 + num2 + index2)[(num3 + index1) * this.bmp.Width] = index1 == 0 || index2 == 0 || (index1 == 15 || index2 == 15) ? 16316664U : 63736U;
            }
            Win32.BitBlt(this.bmp.Handle, num2 + 1, num3 + 3, 4, 9, LevelTab.hexBitmap.Handle, ((int) sprite.num >> 8) * 4, 0, 3342344U);
            Win32.BitBlt(this.bmp.Handle, num2 + 6, num3 + 3, 4, 9, LevelTab.hexBitmap.Handle, ((int) sprite.num >> 4 & 15) * 4, 0, 3342344U);
            Win32.BitBlt(this.bmp.Handle, num2 + 11, num3 + 3, 4, 9, LevelTab.hexBitmap.Handle, ((int) sprite.num & 15) * 4, 0, 3342344U);
          }
        }
      }
    }

    private unsafe void Render4bpp(Library.Bitmap b, int dstx, int dsty, byte[,] chr, uint[] pal, ushort tile_info, LevelTab.RenderFlag f)
    {
      if (b.Width <= dstx || b.Height <= dsty)
        return;
      uint* numPtr1 = b.PixelBits(0, 0);
      int num1;
      if (((int) tile_info & 16384) != 0)
      {
        num1 = -1;
        dstx += 7;
      }
      else
        num1 = 1;
      int num2;
      if (((int) tile_info & 32768) != 0)
      {
        num2 = -1;
        dsty += 7;
      }
      else
        num2 = 1;
      uint num3 = (uint) (((f & LevelTab.RenderFlag.RedOpaque) != LevelTab.RenderFlag.Null ? 16711680 : 0) | ((f & LevelTab.RenderFlag.GreenOpaque) != LevelTab.RenderFlag.Null ? 65280 : 0) | ((f & LevelTab.RenderFlag.BlueOpaque) != LevelTab.RenderFlag.Null ? (int) byte.MaxValue : 0));
      uint num4 = (uint) (((f & LevelTab.RenderFlag.RedTransparent) != LevelTab.RenderFlag.Null ? 16711680 : 0) | ((f & LevelTab.RenderFlag.GreenTransparent) != LevelTab.RenderFlag.Null ? 65280 : 0) | ((f & LevelTab.RenderFlag.BlueTransparent) != LevelTab.RenderFlag.Null ? (int) byte.MaxValue : 0));
      fixed (byte* numPtr2 = &chr[(int) tile_info & 1023, 0])
        fixed (uint* numPtr3 = &pal[((int) tile_info & 7168) >> 6])
        {
          int num5 = 0;
          while (num5 < 8)
          {
            int num6 = 0;
            int num7 = dstx;
            while (num6 < 8)
            {
              (numPtr1 + num7)[dsty * b.Width] = (int) numPtr2[num6 + num5 * 8] == 0 ? (numPtr1 + num7)[dsty * b.Width] ^ ((f & LevelTab.RenderFlag.InvertTransparent) != LevelTab.RenderFlag.Null ? 16316664U : 0U) | num4 : numPtr3[numPtr2[num6 + num5 * 8]] ^ ((f & LevelTab.RenderFlag.InvertOpaque) != LevelTab.RenderFlag.Null ? 16316664U : 0U) | num3;
              ++num6;
              num7 += num1;
            }
            ++num5;
            dsty += num2;
          }
        }
    }

    private unsafe void Render2bpp(Library.Bitmap b, int dstx, int dsty, byte[,] chr, uint[] pal, ushort tile_info, LevelTab.RenderFlag f)
    {
      if (b.Width <= dstx || b.Height <= dsty)
        return;
      uint* numPtr1 = b.PixelBits(0, 0);
      int num1;
      if (((int) tile_info & 16384) != 0)
      {
        num1 = -1;
        dstx += 7;
      }
      else
        num1 = 1;
      int num2;
      if (((int) tile_info & 32768) != 0)
      {
        num2 = -1;
        dsty += 7;
      }
      else
        num2 = 1;
      uint num3 = (uint) (((f & LevelTab.RenderFlag.RedOpaque) != LevelTab.RenderFlag.Null ? 16711680 : 0) | ((f & LevelTab.RenderFlag.GreenOpaque) != LevelTab.RenderFlag.Null ? 65280 : 0) | ((f & LevelTab.RenderFlag.BlueOpaque) != LevelTab.RenderFlag.Null ? (int) byte.MaxValue : 0));
      uint num4 = (uint) (((f & LevelTab.RenderFlag.RedTransparent) != LevelTab.RenderFlag.Null ? 16711680 : 0) | ((f & LevelTab.RenderFlag.GreenTransparent) != LevelTab.RenderFlag.Null ? 65280 : 0) | ((f & LevelTab.RenderFlag.BlueTransparent) != LevelTab.RenderFlag.Null ? (int) byte.MaxValue : 0));
      fixed (byte* numPtr2 = &chr[(int) tile_info & 1023, 0])
        fixed (uint* numPtr3 = &pal[((int) tile_info & 7168) >> 8])
        {
          int num5 = 0;
          while (num5 < 8)
          {
            int num6 = 0;
            int num7 = dstx;
            while (num6 < 8)
            {
              (numPtr1 + num7)[dsty * b.Width] = (int) numPtr2[num6 + num5 * 8] == 0 ? (numPtr1 + num7)[dsty * b.Width] ^ ((f & LevelTab.RenderFlag.InvertTransparent) != LevelTab.RenderFlag.Null ? 16316664U : 0U) | num4 : numPtr3[numPtr2[num6 + num5 * 8]] ^ ((f & LevelTab.RenderFlag.InvertOpaque) != LevelTab.RenderFlag.Null ? 16316664U : 0U) | num3;
              ++num6;
              num7 += num1;
            }
            ++num5;
            dsty += num2;
          }
        }
    }

    protected override unsafe void WndProc(ref Message m)
    {
      switch (m.Msg)
      {
        case 20:
          m.Result = (IntPtr) null;
          break;
        case 276:
          int num1 = this.hScroll.nPos;
          int num2 = this.hScroll.Scroll(m.WParam);
          if (num2 != 0)
          {
            Win32.SetScrollInfo(this.Handle, 0, ref this.hScroll, true);
            Win32.ScrollWindowEx(this.Handle, -num2, 0, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, 2U);
            int scrolled = (this.hScroll.nPos & -16) - (num1 & -16);
            if (scrolled != 0)
            {
              this.ScrollClientArea(scrolled, ScrollOrientation.HorizontalScroll, true);
              if (!this.internalDisableUpdate)
                Win32.UpdateWindow(this.Handle);
            }
          }
          m.Result = (IntPtr) null;
          break;
        case 277:
          int num3 = this.vScroll.nPos;
          int num4 = this.vScroll.Scroll(m.WParam);
          if (num4 != 0)
          {
            Win32.SetScrollInfo(this.Handle, 1, ref this.vScroll, true);
            Win32.ScrollWindowEx(this.Handle, 0, -num4, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, 2U);
            int scrolled = (this.vScroll.nPos & -16) - (num3 & -16);
            if (scrolled != 0)
            {
              this.ScrollClientArea(scrolled, ScrollOrientation.VerticalScroll, true);
              if (!this.internalDisableUpdate)
                Win32.UpdateWindow(this.Handle);
            }
          }
          m.Result = (IntPtr) null;
          break;
        case 5:
          if (m.WParam == (IntPtr) null || m.WParam == (IntPtr) 2)
          {
            this.hScroll.nPage = (uint) (short) (int) m.LParam;
            this.hScroll.Scroll((IntPtr) (4 | this.hScroll.nPos << 16));
            Win32.SetScrollInfo(this.Handle, 0, ref this.hScroll, true);
            this.vScroll.nPage = (uint) (int) m.LParam >> 16;
            this.vScroll.Scroll((IntPtr) (4 | this.vScroll.nPos << 16));
            Win32.SetScrollInfo(this.Handle, 1, ref this.vScroll, true);
            Win32.InvalidateRect(this.Handle, (IntPtr) null, false);
          }
          m.Result = (IntPtr) null;
          break;
        case 15:
          Win32.PAINTSTRUCT lpPaint = new Win32.PAINTSTRUCT();
          IntPtr hdcDest = Win32.BeginPaint(this.Handle, ref lpPaint);
          if (this.bmp.Create(this.Handle, this.ClientRectangle.Width + 16, this.ClientRectangle.Height + 16))
          {
            if (this.backbmp.Create(this.Handle, this.ClientRectangle.Width, this.ClientRectangle.Height + 16))
            {
              Win32.SelectObject(this.backbmp.Handle, Win32.GetStockObject(5));
              Win32.SelectObject(this.backbmp.Handle, LevelTab.sFont.Handle);
              int num5 = (int) Win32.SetTextColor(this.backbmp.Handle, 16777215U);
            }
            this.rerenderFlag = new bool[this.bmp.Width / 16 * (this.bmp.Height / 16)];
            this.RenderLevel();
          }
          if (this.bmp.Handle != (IntPtr) null)
          {
            Win32.BitBlt(this.backbmp.Handle, lpPaint.rcPaint.left, lpPaint.rcPaint.top, lpPaint.rcPaint.Width, lpPaint.rcPaint.Height, this.bmp.Handle, lpPaint.rcPaint.left + ((this.hScroll.nPos & 15) != 0 ? this.hScroll.nPos & 15 : 0), lpPaint.rcPaint.top + ((this.vScroll.nPos & 15) != 0 ? this.vScroll.nPos & 15 : 0), 13369376U);
            if ((this.view & LevelTab.View.Grid) != (LevelTab.View) 0)
            {
              int y = (lpPaint.rcPaint.top & -16) + ((this.vScroll.nPos & 15) != 0 ? 16 - (this.vScroll.nPos & 15) : 0);
              while (y < lpPaint.rcPaint.bottom)
              {
                uint* numPtr = this.backbmp.PixelBits(lpPaint.rcPaint.left, y);
                for (int width = lpPaint.rcPaint.Width; width >= 0; --width)
                  *numPtr++ = (uint) ((int) (*numPtr >> 2) & 3684408 | 4210752);
                y += 16;
              }
              int x = (lpPaint.rcPaint.left & -16) + ((this.hScroll.nPos & 15) != 0 ? 16 - (this.hScroll.nPos & 15) : 0);
              while (x < lpPaint.rcPaint.right)
              {
                uint* numPtr = this.backbmp.PixelBits(x, lpPaint.rcPaint.top);
                for (int height = lpPaint.rcPaint.Height; height >= 0; --height)
                {
                  *numPtr = (uint) ((int) (*numPtr >> 2) & 3684408 | 4210752);
                  numPtr += this.backbmp.Width;
                }
                x += 16;
              }
            }
            if ((this.view & LevelTab.View.ScreenBoundaries) != (LevelTab.View) 0)
            {
              int num5 = lpPaint.rcPaint.top + this.vScroll.nPos >> 8;
              int srcy = lpPaint.rcPaint.top - (lpPaint.rcPaint.top + this.vScroll.nPos & (int) byte.MaxValue);
              while (srcy < lpPaint.rcPaint.bottom)
              {
                int num6 = lpPaint.rcPaint.left + this.hScroll.nPos >> 8;
                int srcx = lpPaint.rcPaint.left - (lpPaint.rcPaint.left + this.hScroll.nPos & (int) byte.MaxValue);
                while (srcx < lpPaint.rcPaint.right)
                {
                  if (this.level.Exits[num5 << 4 | num6].enabled)
                  {
                    this.DrawRectangle(this.backbmp, 16252928U, srcx, srcy, 256, 256);
                    this.DrawRectangle(this.backbmp, 16252928U, srcx + 2, srcy + 2, 252, 252);
                    int num7 = (int) Win32.SetBkColor(this.backbmp.Handle, 248U);
                    string lpString;
                    if ((int) this.level.Exits[num5 << 4 | num6].dest < 222)
                      lpString = string.Format("{0:X2} : Level {1:X2}  X:{2:X2} Y:{3:X2}            ",  (num5 << 4 | num6),  this.level.Exits[num5 << 4 | num6].dest,  this.level.Exits[num5 << 4 | num6].x,  this.level.Exits[num5 << 4 | num6].y);
                    else
                      lpString = string.Format("{0:X2} Mini Battle {1:X}  L:{2:X2} X:{2:X2} Y:{3:X2}   ",  (num5 << 4 | num6),  ((int) this.level.Exits[num5 << 4 | num6].dest - 222),  this.level.Exits[num5 << 4 | num6].type,  this.level.Exits[num5 << 4 | num6].x,  this.level.Exits[num5 << 4 | num6].y);
                    Win32.TextOut(this.backbmp.Handle, 0, this.backbmp.Height - 16, lpString, lpString.Length);
                    Library.Bitmap.Blend(this.backbmp, srcx + 3, srcy + 3, 250, 12, this.backbmp, 1, this.backbmp.Height - 14, (ushort) 160);
                  }
                  else
                  {
                    this.DrawRectangle(this.backbmp, 248U, srcx, srcy, 256, 256);
                    this.DrawRectangle(this.backbmp, 248U, srcx + 2, srcy + 2, 252, 252);
                    int num7 = (int) Win32.SetBkColor(this.backbmp.Handle, 16252928U);
                    string lpString = string.Format("{0:X2}",  (num5 << 4 | num6),  this.level.Exits[num5 << 4 | num6].dest,  this.level.Exits[num5 << 4 | num6].x,  this.level.Exits[num5 << 4 | num6].y);
                    Win32.TextOut(this.backbmp.Handle, 0, this.backbmp.Height - 16, lpString, lpString.Length);
                    Library.Bitmap.Blend(this.backbmp, srcx + 3, srcy + 3, 13, 13, this.backbmp, 1, this.backbmp.Height - 14, (ushort) 160);
                  }
                  srcx += 256;
                  ++num6;
                }
                srcy += 256;
                ++num5;
              }
            }
            if (this.dragging && this.editType == LevelTab.EditType.Null)
              this.DrawDashedRectangle(this.backbmp, this.selectionRect.Left - this.hScroll.nPos, this.selectionRect.Top - this.vScroll.nPos, this.selectionRect.Width, this.selectionRect.Height);
            Win32.BitBlt(hdcDest, lpPaint.rcPaint.left, lpPaint.rcPaint.top, lpPaint.rcPaint.Width, lpPaint.rcPaint.Height, this.backbmp.Handle, lpPaint.rcPaint.left, lpPaint.rcPaint.top, 13369376U);
          }
          Win32.EndPaint(this.Handle, ref lpPaint);
          m.Result = (IntPtr) null;
          break;
      }
      base.WndProc(ref m);
    }

    private unsafe void DrawDashedRectangle(Library.Bitmap b, int srcx, int srcy, int width, int height)
    {
      if (--width <= 0 || --height <= 0)
        return;
      for (int y = Math.Max(0, srcy); (long) (uint) y <= (long) (srcy + height) && (long) (uint) y < (long) this.backbmp.Height; ++y)
      {
        if ((long) (uint) srcx < (long) b.Width)
          *b.PixelBits(srcx, y) = (y & 1) != 0 ? 0U : 16777215U;
        if ((long) (uint) (srcx + width) < (long) b.Width)
          *b.PixelBits(srcx + width, y) = (y & 1) != 0 ? 0U : 16777215U;
      }
      for (int x = Math.Max(0, srcx); (long) (uint) x <= (long) (srcx + width) && (long) (uint) x < (long) b.Width; ++x)
      {
        if ((long) (uint) srcy < (long) b.Height)
          *b.PixelBits(x, srcy) = (x & 1) != 0 ? 0U : 16777215U;
        if ((long) (uint) (srcy + height) < (long) b.Height)
          *b.PixelBits(x, srcy + height) = (x & 1) != 0 ? 0U : 16777215U;
      }
    }

    private unsafe void DrawRectangle(Library.Bitmap b, uint color, int srcx, int srcy, int width, int height)
    {
      if (--width <= 0 || --height <= 0)
        return;
      for (int y = Math.Max(0, srcy); (long) (uint) y <= (long) (srcy + height) && (long) (uint) y < (long) this.backbmp.Height; ++y)
      {
        if ((long) (uint) srcx < (long) b.Width)
          *b.PixelBits(srcx, y) = color;
        if ((long) (uint) (srcx + width) < (long) b.Width)
          *b.PixelBits(srcx + width, y) = color;
      }
      for (int x = Math.Max(0, srcx); (long) (uint) x <= (long) (srcx + width) && (long) (uint) x < (long) b.Width; ++x)
      {
        if ((long) (uint) srcy < (long) b.Height)
          *b.PixelBits(x, srcy) = color;
        if ((long) (uint) (srcy + height) < (long) b.Height)
          *b.PixelBits(x, srcy + height) = color;
      }
    }

    public void ScrollClientArea(int scrolled, ScrollOrientation orientation, bool redraw)
    {
      if (orientation == ScrollOrientation.HorizontalScroll)
      {
        Win32.ScrollDC(this.bmp.Handle, -scrolled, 0, (IntPtr) null, (IntPtr) null, (IntPtr) null, (IntPtr) null);
        if (!redraw)
          return;
        if (scrolled > 0)
          this.RenderLevel(this.bmp, (bool[]) null, Math.Max(0, this.bmp.Width - scrolled), 0, this.bmp.Width, this.bmp.Height);
        else
          this.RenderLevel(this.bmp, (bool[]) null, 0, 0, Math.Min(this.bmp.Width, -scrolled), this.bmp.Height);
      }
      else
      {
        if (orientation != ScrollOrientation.VerticalScroll)
          return;
        Win32.ScrollDC(this.bmp.Handle, 0, -scrolled, (IntPtr) null, (IntPtr) null, (IntPtr) null, (IntPtr) null);
        if (!redraw)
          return;
        if (scrolled > 0)
          this.RenderLevel(this.bmp, (bool[]) null, 0, Math.Max(0, this.bmp.Height - scrolled), this.bmp.Width, this.bmp.Height);
        else
          this.RenderLevel(this.bmp, (bool[]) null, 0, 0, this.bmp.Width, Math.Min(this.bmp.Height, -scrolled));
      }
    }

    public void SwitchEditMode(LevelTab.EditMode newMode)
    {
      if (this.editMode == newMode)
        return;
      if (newMode == LevelTab.EditMode.Object)
      {
        this.doSelect = new LevelTab.DoSelect(this.SelectObject);
        this.doUnselect = new LevelTab.DoUnselect(this.UnselectObject);
        this.doFocusOn = new LevelTab.DoFocusOn(this.FocusOnObject);
        this.doCopy = new LevelTab.DoCopy(this.CopyObject);
        this.doMove = new LevelTab.DoMove(this.MoveObject);
        this.doDelete = new LevelTab.DoDelete(this.DeleteObject);
      }
      else
      {
        this.doSelect = new LevelTab.DoSelect(this.SelectSprite);
        this.doUnselect = new LevelTab.DoUnselect(this.UnselectSprite);
        this.doFocusOn = new LevelTab.DoFocusOn(this.FocusOnSprite);
        this.doCopy = new LevelTab.DoCopy(this.CopySprite);
        this.doMove = new LevelTab.DoMove(this.MoveSprite);
        this.doDelete = new LevelTab.DoDelete(this.DeleteSprite);
      }
      this.toolTip.Tag =  -1;
      this.toolTip.SetToolTip((Control) this, (string) null);
      this.selectedID.Clear();
      this.levelEditor.EnableEditMenu(false, this.editMode);
      this._editMode = newMode;
      this.Cursor = Cursors.Default;
      this.RenderLevel();
      Win32.InvalidateRect(this.Handle, (IntPtr) null, false);
    }

    private void LevelTab_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        this.dragging = true;
        this.atLeastOnceMoved = false;
        this.lastMouse = this.selectionOrigin = new Point(e.X + this.hScroll.nPos, e.Y + this.vScroll.nPos);
        this.keyState = Control.ModifierKeys;
        if (this.editType == LevelTab.EditType.Null)
        {
          this.selectionRect = new Rectangle(this.selectionOrigin.X, this.selectionOrigin.Y, 0, 0);
          this.selectedIDbackup = this.keyState.HasFlag((Enum) Keys.Control) || this.keyState.HasFlag((Enum) Keys.Alt) ? this.selectedID : new SortedSet<int>();
          this.levelEditor.EnableEditMenu(this.doSelect(true), this.editMode);
        }
        if (this.editType == LevelTab.EditType.Null)
          return;
        this.selectedIDbackup = new SortedSet<int>((IEnumerable<int>) this.selectedID);
        if (this.editMode == LevelTab.EditMode.Object)
        {
          Level.Object[] objectArray = new Level.Object[this.selectedID.Count];
          for (int index = 0; index < objectArray.Length; ++index)
            objectArray[index] = this.level.Objects[Enumerable.ElementAt<int>((IEnumerable<int>) this.selectedID, index)];
          this.selectedObjects =  objectArray;
        }
        else
        {
          Level.Sprite[] spriteArray = new Level.Sprite[this.selectedID.Count];
          for (int index = 0; index < spriteArray.Length; ++index)
            spriteArray[index] = this.level.Sprites[Enumerable.ElementAt<int>((IEnumerable<int>) this.selectedID, index)];
          this.selectedObjects =  spriteArray;
        }
      }
      else
      {
        if (e.Button != MouseButtons.Right || this.selectedID.Count == 0)
          return;
        this.doCopy((e.X + this.hScroll.nPos) / 16, (e.Y + this.vScroll.nPos) / 16);
        this.editType = LevelTab.EditType.Move | LevelTab.EditType.Copy;
        this.Cursor = Cursors.SizeAll;
        this.dragging = true;
        this.lastMouse = this.selectionOrigin = new Point(e.X + this.hScroll.nPos, e.Y + this.vScroll.nPos);
        this.keyState = Control.ModifierKeys;
      }
    }

    private void LevelTab_MouseMove(object sender, MouseEventArgs e)
    {
      if (!this.dragging)
      {
        Point mouse = new Point(e.X + this.hScroll.nPos, e.Y + this.vScroll.nPos);
        this.levelEditor.StatusBarMouseCoordinates(mouse.X, mouse.Y);
        this.Cursor = this.doFocusOn(mouse);
      }
      else
      {
        this.internalDisableUpdate = true;
        if (e.X < 0)
          Win32.SendMessage(this.Handle, 276U, (IntPtr) (4 | this.hScroll.nPos - 64 << 16), (IntPtr) null);
        else if (e.X >= this.ClientRectangle.Width)
          Win32.SendMessage(this.Handle, 276U, (IntPtr) (4 | this.hScroll.nPos + 64 << 16), (IntPtr) null);
        if (e.Y < 0)
          Win32.SendMessage(this.Handle, 277U, (IntPtr) (4 | this.vScroll.nPos - 64 << 16), (IntPtr) null);
        else if (e.Y >= this.ClientRectangle.Height)
          Win32.SendMessage(this.Handle, 277U, (IntPtr) (4 | this.vScroll.nPos + 64 << 16), (IntPtr) null);
        this.internalDisableUpdate = false;
        Point point = new Point(e.X + this.hScroll.nPos, e.Y + this.vScroll.nPos);
        if ((this.editType & LevelTab.EditType.Move) != LevelTab.EditType.Null)
        {
          uint num1 = this.doMove(this.selectedID, this.keyState, -(((this.lastMouse.X & -16) - (point.X & -16)) / 16), -(((this.lastMouse.Y & -16) - (point.Y & -16)) / 16));
          if ((int) num1 != 0)
          {
            int num2 = (int) (short) num1;
            int num3 = (int) (short) (num1 >> 16);
            this.lastMouse.X += num2 * 16;
            this.lastMouse.Y += num3 * 16;
            this.atLeastOnceMoved = true;
          }
        }
        else if ((this.editType & LevelTab.EditType.SizeBoth) != LevelTab.EditType.Null)
        {
          if ((this.lastMouse.X & -16) != (point.X & -16) || (this.lastMouse.Y & -16) != (point.Y & -16))
          {
            if (this.SizeObject(this.selectedID, (Level.Object[]) this.selectedObjects, (this.editType & LevelTab.EditType.SizeHorz) == LevelTab.EditType.Null ? 0 : -(((this.selectionOrigin.X & -16) - (point.X & -16)) / 16), (this.editType & LevelTab.EditType.SizeVert) == LevelTab.EditType.Null ? 0 : -(((this.selectionOrigin.Y & -16) - (point.Y & -16)) / 16)))
              this.atLeastOnceMoved = true;
            this.lastMouse = point;
          }
        }
        else
        {
          Rectangle rectangle = new Rectangle();
          if (point.X >= this.selectionOrigin.X)
          {
            rectangle.X = this.selectionOrigin.X;
            rectangle.Width = point.X - this.selectionOrigin.X + 1;
          }
          else
          {
            rectangle.X = point.X;
            rectangle.Width = this.selectionOrigin.X - point.X + 1;
          }
          if (point.Y >= this.selectionOrigin.Y)
          {
            rectangle.Y = this.selectionOrigin.Y;
            rectangle.Height = point.Y - this.selectionOrigin.Y + 1;
          }
          else
          {
            rectangle.Y = point.Y;
            rectangle.Height = this.selectionOrigin.Y - point.Y + 1;
          }
          this.selectionRect = rectangle;
          this.levelEditor.EnableEditMenu(this.doSelect(false), this.editMode);
        }
        Win32.UpdateWindow(this.Handle);
      }
    }

    private void LevelTab_MouseUp(object sender, MouseEventArgs e)
    {
      this.FinalizeDrag();
    }

    private void LevelTab_MouseCaptureChanged(object sender, EventArgs e)
    {
      this.FinalizeDrag();
    }

    private void FinalizeDrag()
    {
      if (!this.dragging)
        return;
      this.dragging = false;
      if ((this.editType & LevelTab.EditType.Move) != LevelTab.EditType.Null)
      {
        int dx = -(((this.selectionOrigin.X & -16) - (this.lastMouse.X & -16)) / 16);
        int dy = -(((this.selectionOrigin.Y & -16) - (this.lastMouse.Y & -16)) / 16);
        if (this.editMode == LevelTab.EditMode.Object)
        {
          if ((this.editType & LevelTab.EditType.Copy) == LevelTab.EditType.Null)
          {
            if (this.atLeastOnceMoved)
            {
              this.undoBuffer.Push((LevelTab.ICommand) new LevelTab.EditCommand(this, this.selectedIDbackup, ((Array) this.selectedObjects).Clone(), (this.keyState & Keys.Control) != Keys.None ? LevelTab.EditCommand.Type.MoveObject : LevelTab.EditCommand.Type.MoveObjectToFront, dx, dy));
              this.redoBuffer.Clear();
              this.levelEditor.EnableUndoRedo();
            }
          }
          else
          {
            this.undoBuffer.Push((LevelTab.ICommand) new LevelTab.EditCommand(this, this.selectedID,  this.level.Objects.GetRange(this.level.Objects.Count - this.selectedID.Count, this.selectedID.Count).ToArray(), LevelTab.EditCommand.Type.CopyObject, 0, 0));
            this.editType &= ~LevelTab.EditType.Copy;
            this.redoBuffer.Clear();
            this.levelEditor.EnableUndoRedo();
          }
        }
        else if ((this.editType & LevelTab.EditType.Copy) == LevelTab.EditType.Null)
        {
          if (this.atLeastOnceMoved)
          {
            this.undoBuffer.Push((LevelTab.ICommand) new LevelTab.EditCommand(this, this.selectedIDbackup, ((Array) this.selectedObjects).Clone(), LevelTab.EditCommand.Type.MoveSprite, dx, dy));
            this.redoBuffer.Clear();
            this.levelEditor.EnableUndoRedo();
          }
        }
        else
        {
          this.undoBuffer.Push((LevelTab.ICommand) new LevelTab.EditCommand(this, this.selectedID,  this.level.Sprites.GetRange(this.level.Sprites.Count - this.selectedID.Count, this.selectedID.Count).ToArray(), LevelTab.EditCommand.Type.CopySprite, 0, 0));
          this.editType &= ~LevelTab.EditType.Copy;
          this.redoBuffer.Clear();
          this.levelEditor.EnableUndoRedo();
        }
      }
      else if ((this.editType & LevelTab.EditType.SizeBoth) != LevelTab.EditType.Null && this.atLeastOnceMoved)
      {
        this.undoBuffer.Push((LevelTab.ICommand) new LevelTab.EditCommand(this, this.selectedID, ((Array) this.selectedObjects).Clone(), LevelTab.EditCommand.Type.SizeObjectMouse, (this.editType & LevelTab.EditType.SizeHorz) == LevelTab.EditType.Null ? 0 : -(((this.selectionOrigin.X & -16) - (this.lastMouse.X & -16)) / 16), (this.editType & LevelTab.EditType.SizeVert) == LevelTab.EditType.Null ? 0 : -(((this.selectionOrigin.Y & -16) - (this.lastMouse.Y & -16)) / 16)));
        this.redoBuffer.Clear();
        this.levelEditor.EnableUndoRedo();
      }
      this.selectedObjects =  null;
      this.InvalidateSelection();
    }

    private void LevelTab_DragEnter(object sender, DragEventArgs e)
    {
      this.LevelTab_DragOver(sender, e);
    }

    private void LevelTab_DragOver(object sender, DragEventArgs e)
    {
      Point point = this.PointToClient(new Point(e.X, e.Y));
      if ((long) (uint) point.X >= (long) this.ClientSize.Width || (long) (uint) point.Y >= (long) this.ClientSize.Height || ((uint) (point.X += this.hScroll.nPos) >= 4096U || (uint) (point.Y += this.vScroll.nPos) >= 2048U))
        e.Effect = DragDropEffects.None;
      else if (e.Data.GetDataPresent(this.editMode == LevelTab.EditMode.Object ? typeof (Level.Object) : typeof (Level.Sprite)))
        e.Effect = DragDropEffects.Move;
      else
        e.Effect = DragDropEffects.None;
    }

    private void LevelTab_DragDrop(object sender, DragEventArgs e)
    {
      Point point = this.PointToClient(new Point(e.X + this.hScroll.nPos, e.Y + this.vScroll.nPos));
      if ((uint) point.X >= 4096U || (uint) point.Y >= 2048U)
        return;
      if (this.editMode == LevelTab.EditMode.Object && e.Data.GetDataPresent(typeof (Level.Object)))
      {
        Level.Object @object = (Level.Object) e.Data.GetData(typeof (Level.Object));
        @object.X = (byte) (point.X / 16);
        @object.Y = (byte) (point.Y / 16);
        @object.id = this.level.ObjectID++;
        if ((int) this.level.Header[1] == 2 && (int) (short) @object.width < 0)
          @object.width = (ushort) 1;
        this.AddObject(this.selectedID, @object);
        this.levelEditor.EnableEditMenu(true, LevelTab.EditMode.Object);
      }
      else
      {
        if (!e.Data.GetDataPresent(typeof (Level.Sprite)))
          return;
        Level.Sprite spr = (Level.Sprite) e.Data.GetData(typeof (Level.Sprite));
        spr.x = (byte) (point.X / 16);
        spr.y = (byte) (point.Y / 16);
        spr.id = this.level.SpriteID++;
        this.AddSprite(this.selectedID, spr);
        this.levelEditor.EnableEditMenu(true, LevelTab.EditMode.Sprite);
      }
    }

    private void InvalidateSelection()
    {
      this.Invalidate(new Rectangle(this.selectionRect.X - this.hScroll.nPos, this.selectionRect.Y - this.vScroll.nPos, this.selectionRect.Width + 1, this.selectionRect.Height + 1), false);
    }

    public void ClearLevelData(bool clearObject, bool clearSprite, bool clearExit)
    {
      if (clearObject)
        this.level.Objects.Clear();
      if (clearSprite)
        this.level.Sprites.Clear();
      if (clearExit)
        this.level.Exits = new Level.ScreenExit[128];
      this.level.RedecodeLevel(0);
      this.RenderLevel();
      Win32.InvalidateRect(this.Handle, (IntPtr) null, false);
      this.actionCount = -1;
      this.undoBuffer.Clear();
      this.redoBuffer.Clear();
      this.levelEditor.EnableUndoRedo();
      this.levelEditor.miniMapViewer.UpdateInformation();
      this.levelEditor.screenExitEditor.UpdateInformation();
    }

    private void SetRerenderFlagBefore(bool initialize, int updateID)
    {
      int num1 = this.hScroll.nPos / 16;
      int num2 = this.vScroll.nPos / 16;
      for (int index1 = 0; index1 < this.bmp.Height / 16 && num2 < 128; ++num2)
      {
        int num3 = num1;
        for (int index2 = 0; index2 < this.bmp.Width / 16 && num3 < 256; ++num3)
        {
          if (initialize)
            this.rerenderFlag[index2 + index1 * (this.bmp.Width / 16)] = false;
          else if (this.rerenderFlag[index2 + index1 * (this.bmp.Width / 16)])
            goto label_16;
          Level.LevelTileList levelTileList = this.level.Tiles[num2 & 240 | num3 >> 4][(int) (byte) (num2 << 4) | num3 & 15];
          Level.LevelCommandList levelCommandList = this.level.CommandTiles[num3 | num2 * 256];
          for (int index3 = levelTileList.Count - 1; index3 >= 0; --index3)
          {
            if (levelTileList[index3].id >= updateID || this.editMode == LevelTab.EditMode.Object && this.selectedID.Contains(levelTileList[index3].id))
            {
              this.rerenderFlag[index2 + index1 * (this.bmp.Width / 16)] = true;
              goto label_16;
            }
          }
          for (int index3 = levelCommandList.Count - 1; index3 >= 0; --index3)
          {
            if (levelCommandList[index3] >= updateID || this.editMode == LevelTab.EditMode.Object && this.selectedID.Contains(levelCommandList[index3]))
            {
              this.rerenderFlag[index2 + index1 * (this.bmp.Width / 16)] = true;
              break;
            }
          }
label_16:
          ++index2;
        }
        ++index1;
      }
    }

    private void SetRerenderFlagAfter(int updateID)
    {
      int num1 = this.hScroll.nPos / 16;
      int num2 = this.vScroll.nPos / 16;
      for (int index1 = 0; index1 < this.bmp.Height / 16 && num2 < 128; ++num2)
      {
        int num3 = num1;
        for (int index2 = 0; index2 < this.bmp.Width / 16 && num3 < 256; ++num3)
        {
          if (!this.rerenderFlag[index2 + index1 * (this.bmp.Width / 16)])
          {
            Level.LevelTileList levelTileList = this.level.Tiles[num2 & 240 | num3 >> 4][(int) (byte) (num2 << 4) | num3 & 15];
            Level.LevelCommandList levelCommandList = this.level.CommandTiles[num3 | num2 * 256];
            for (int index3 = levelTileList.Count - 1; index3 >= 0; --index3)
            {
              if (levelTileList[index3].id >= updateID)
              {
                this.rerenderFlag[index2 + index1 * (this.bmp.Width / 16)] = true;
                goto label_14;
              }
            }
            for (int index3 = levelCommandList.Count - 1; index3 >= 0; --index3)
            {
              if (levelCommandList[index3] >= updateID)
              {
                this.rerenderFlag[index2 + index1 * (this.bmp.Width / 16)] = true;
                break;
              }
            }
          }
label_14:
          ++index2;
        }
        ++index1;
      }
    }

    private void SetRerenderFlagSelecting(SortedSet<int> newSet)
    {
      int num1 = this.hScroll.nPos / 16;
      int num2 = this.vScroll.nPos / 16;
      for (int index1 = 0; index1 < this.bmp.Height / 16 && num2 < 128; ++num2)
      {
        int num3 = num1;
        for (int index2 = 0; index2 < this.bmp.Width / 16 && num3 < 256; ++num3)
        {
          this.rerenderFlag[index2 + index1 * (this.bmp.Width / 16)] = false;
          Level.LevelTileList levelTileList = this.level.Tiles[num2 & 240 | num3 >> 4][(int) (byte) (num2 << 4) | num3 & 15];
          Level.LevelCommandList levelCommandList = this.level.CommandTiles[num3 | num2 * 256];
          for (int index3 = levelTileList.Count - 1; index3 >= 0; --index3)
          {
            if (newSet.Contains(levelTileList[index3].id) ^ this.selectedID.Contains(levelTileList[index3].id))
            {
              this.rerenderFlag[index2 + index1 * (this.bmp.Width / 16)] = true;
              goto label_13;
            }
          }
          for (int index3 = levelCommandList.Count - 1; index3 >= 0; --index3)
          {
            if (newSet.Contains(levelCommandList[index3]) ^ this.selectedID.Contains(levelCommandList[index3]))
            {
              this.rerenderFlag[index2 + index1 * (this.bmp.Width / 16)] = true;
              break;
            }
          }
label_13:
          ++index2;
        }
        ++index1;
      }
    }

    private void SetRerenderFlagExFBBefore(ref int Id, ref Level.Object obj)
    {
      if ((int) obj.exnum != 251)
        return;
      if (Id > this.level.PageFirstID[(int) obj.locH])
        Id = this.level.PageFirstID[(int) obj.locH];
      if ((int) obj.locL < 128 && this.level.OriginalPageFirstID[(int) obj.locL] != -1 && Id > this.level.OriginalPageFirstID[(int) obj.locL])
        Id = this.level.OriginalPageFirstID[(int) obj.locL];
      if ((int) obj.locL >= 128)
        return;
      int num1 = ((int) obj.locL & 15) * 16 - this.hScroll.nPos / 16;
      int num2 = ((int) obj.locL & 240) - this.vScroll.nPos / 16;
      for (int index1 = 0; index1 < 16; ++index1)
      {
        if (num2 >= 0)
        {
          if (num2 >= this.bmp.Height / 16)
            break;
          int num3 = num1;
          for (int index2 = 0; index2 < 16; ++index2)
          {
            if (num3 >= 0)
            {
              if (num3 < this.bmp.Width / 16)
                this.rerenderFlag[num2 * (this.bmp.Width / 16) + num3] = true;
              else
                break;
            }
            ++num3;
          }
        }
        ++num2;
      }
    }

    private void SetRerenderFlagExFBAfter(ref Level.Object obj)
    {
      if ((int) obj.exnum != 251 || (int) obj.locL >= 128)
        return;
      int num1 = ((int) obj.locL & 15) * 16 - this.hScroll.nPos / 16;
      int num2 = ((int) obj.locL & 240) - this.vScroll.nPos / 16;
      for (int index1 = 0; index1 < 16; ++index1)
      {
        if (num2 >= 0)
        {
          if (num2 >= this.bmp.Height / 16)
            break;
          int num3 = num1;
          for (int index2 = 0; index2 < 16; ++index2)
          {
            if (num3 >= 0)
            {
              if (num3 < this.bmp.Width / 16)
                this.rerenderFlag[num2 * (this.bmp.Width / 16) + num3] = true;
              else
                break;
            }
            ++num3;
          }
        }
        ++num2;
      }
    }

    private bool SelectObject(bool onClick)
    {
      SortedSet<int> newSet = new SortedSet<int>((IEnumerable<int>) this.selectedIDbackup);
      int num1 = Math.Max(this.selectionRect.Top, 0) & -16;
      while (num1 < this.selectionRect.Bottom)
      {
        int num2 = num1 / 16;
        if (num2 < 128)
        {
          int num3 = Math.Max(this.selectionRect.Left, 0) & -16;
          while (num3 < this.selectionRect.Right)
          {
            int num4 = num3 / 16;
            if (num4 < 256)
            {
              int num5;
              if (this.level.Tiles[num2 & 240 | num4 >> 4][(int) (byte) (num2 << 4) | num4 & 15].Count != 0)
                num5 = this.level.CommandTiles[num2 * 256 | num4].Count == 0 ? this.level.Tiles[num2 & 240 | num4 >> 4][(int) (byte) (num2 << 4) | num4 & 15][0].id : Math.Max(this.level.Tiles[num2 & 240 | num4 >> 4][(int) (byte) (num2 << 4) | num4 & 15][0].id, this.level.CommandTiles[num2 * 256 | num4][0]);
              else if (this.level.CommandTiles[num2 * 256 | num4].Count != 0)
                num5 = this.level.CommandTiles[num2 * 256 | num4][0];
              else
                goto label_17;
              if (this.keyState.HasFlag((Enum) Keys.Control))
              {
                if (this.keyState.HasFlag((Enum) Keys.Alt) && this.selectedIDbackup.Contains(num5))
                  newSet.Remove(num5);
                else if (!newSet.Contains(num5))
                  newSet.Add(num5);
              }
              else if (this.keyState.HasFlag((Enum) Keys.Alt))
                newSet.Remove(num5);
              else if (!newSet.Contains(num5))
                newSet.Add(num5);
label_17:
              num3 += 16;
            }
            else
              break;
          }
          num1 += 16;
        }
        else
          break;
      }
      bool flag = this.selectedID.Count != newSet.Count;
      if (!flag)
      {
        for (int index = 0; index < newSet.Count; ++index)
        {
          if (Enumerable.ElementAt<int>((IEnumerable<int>) this.selectedID, index) != Enumerable.ElementAt<int>((IEnumerable<int>) newSet, index))
          {
            flag = true;
            break;
          }
        }
      }
      if (flag)
      {
        this.SetRerenderFlagSelecting(newSet);
        this.selectedID = newSet;
        this.RenderLevel(this.bmp, this.rerenderFlag, 0, 0, this.bmp.Width, this.bmp.Height);
      }
      Win32.InvalidateRect(this.Handle, (IntPtr) null, false);
      return this.selectedID.Count != 0;
    }

    private bool UnselectObject()
    {
      if (this.selectedID.Count == 0)
        return false;
      this.selectedID.Clear();
      this.RenderLevel();
      Win32.InvalidateRect(this.Handle, (IntPtr) null, false);
      return true;
    }

    private Cursor FocusOnObject(Point mouse)
    {
      if ((uint) mouse.X >= 4096U || (uint) mouse.Y >= 2048U)
      {
        this.toolTip.SetToolTip((Control) this, (string) null);
        this.editType = LevelTab.EditType.Null;
        return Cursors.Default;
      }
      else
      {
        Level.LevelTileList levelTileList = this.level.Tiles[(mouse.Y & 3840) >> 4 | mouse.X >> 8][mouse.Y & 240 | (int) (byte) mouse.X >> 4];
        Level.LevelCommandList levelCommandList = this.level.CommandTiles[(mouse.Y & 4080) << 4 | (mouse.X & 4080) >> 4];
        int index1 = Math.Max(levelTileList[0].id, levelCommandList[0]);
        if (levelTileList[0].id == levelCommandList[0] && levelCommandList[0] == -1)
          index1 = -1;
        if (index1 != (int) this.toolTip.Tag)
        {
          this.toolTip.Tag =  index1;
          if (index1 == -1)
            this.toolTip.SetToolTip((Control) this, (string) null);
          else if ((int) this.level.Objects[index1].num != 0)
            this.toolTip.SetToolTip((Control) this, string.Format("Object {0:X2}\n{1}",  this.level.Objects[index1].num,  Level.ObjectInformation.Description[(int) this.level.Objects[index1].num - 1]));
          else
            this.toolTip.SetToolTip((Control) this, string.Format("Extended object {0:X2}\n{1}",  this.level.Objects[index1].exnum,  Level.ExObjectInformation.Description[(int) this.level.Objects[index1].exnum]));
        }
        if (this.selectedID.Count == 0)
        {
          this.editType = LevelTab.EditType.Null;
          return Cursors.Default;
        }
        else
        {
          Level.LevelTile levelTile = new Level.LevelTile();
          int index2 = -1;
          bool flag = false;
          for (int index3 = 0; index3 < levelTileList.Count; ++index3)
          {
            if (this.selectedID.Contains(levelTileList[index3].id))
            {
              levelTile = levelTileList[index3];
              index2 = levelTileList[index3].id;
              break;
            }
          }
          for (int index3 = 0; index3 < levelCommandList.Count; ++index3)
          {
            if (this.selectedID.Contains(levelCommandList[0]))
            {
              if (index2 < levelCommandList[0])
              {
                index2 = levelCommandList[0];
                flag = true;
                break;
              }
              else
                break;
            }
          }
          if (flag)
          {
            if ((int) this.level.Objects[index2].num != 0)
            {
              switch ((int) this.YI.ROM[(int) this.level.Objects[index2].num + 591084].u8 & 3)
              {
                case 0:
                  if (12 <= (mouse.X & 15))
                  {
                    this.editType = LevelTab.EditType.SizeHorz;
                    return Cursors.SizeWE;
                  }
                  else
                    break;
                case 1:
                  if (12 <= (mouse.Y & 15))
                  {
                    this.editType = LevelTab.EditType.SizeVert;
                    return Cursors.SizeNS;
                  }
                  else
                    break;
                case 2:
                  if (12 <= (mouse.X & 15))
                  {
                    if (12 <= (mouse.Y & 15))
                    {
                      this.editType = LevelTab.EditType.SizeBoth;
                      return Cursors.SizeNWSE;
                    }
                    else
                    {
                      this.editType = LevelTab.EditType.SizeHorz;
                      return Cursors.SizeWE;
                    }
                  }
                  else if (12 <= (mouse.Y & 15))
                  {
                    this.editType = LevelTab.EditType.SizeVert;
                    return Cursors.SizeNS;
                  }
                  else
                    break;
              }
            }
            this.editType = LevelTab.EditType.Move;
            return Cursors.SizeAll;
          }
          else if (index2 != -1)
          {
            if (((int) levelTile.state & 16) != 0)
            {
              this.editType = LevelTab.EditType.Null;
              return Cursors.Default;
            }
            else
            {
              switch (levelTile.state)
              {
                case (byte) 1:
                  if (12 <= (mouse.X & 15))
                  {
                    this.editType = LevelTab.EditType.SizeHorz;
                    return Cursors.SizeWE;
                  }
                  else
                    break;
                case (byte) 2:
                  if (12 <= (mouse.Y & 15))
                  {
                    this.editType = LevelTab.EditType.SizeVert;
                    return Cursors.SizeNS;
                  }
                  else
                    break;
                case (byte) 3:
                  if (12 <= (mouse.X & 15))
                  {
                    if (12 <= (mouse.Y & 15))
                    {
                      this.editType = LevelTab.EditType.SizeBoth;
                      return Cursors.SizeNWSE;
                    }
                    else
                    {
                      this.editType = LevelTab.EditType.SizeHorz;
                      return Cursors.SizeWE;
                    }
                  }
                  else if (12 <= (mouse.Y & 15))
                  {
                    this.editType = LevelTab.EditType.SizeVert;
                    return Cursors.SizeNS;
                  }
                  else
                    break;
                case (byte) 5:
                  if ((mouse.X & 15) < 4)
                  {
                    this.editType = LevelTab.EditType.SizeHorz;
                    return Cursors.SizeWE;
                  }
                  else
                    break;
                case (byte) 7:
                  if ((mouse.X & 15) < 4)
                  {
                    if (12 <= (mouse.Y & 15))
                    {
                      this.editType = LevelTab.EditType.SizeBoth;
                      return Cursors.SizeNESW;
                    }
                    else
                    {
                      this.editType = LevelTab.EditType.SizeHorz;
                      return Cursors.SizeWE;
                    }
                  }
                  else if (12 <= (mouse.Y & 15))
                  {
                    this.editType = LevelTab.EditType.SizeVert;
                    return Cursors.SizeNS;
                  }
                  else
                    break;
                case (byte) 10:
                  if ((mouse.Y & 15) < 4)
                  {
                    this.editType = LevelTab.EditType.SizeVert;
                    return Cursors.SizeNS;
                  }
                  else
                    break;
                case (byte) 11:
                  if (12 <= (mouse.X & 15))
                  {
                    if ((mouse.Y & 15) < 4)
                    {
                      this.editType = LevelTab.EditType.SizeBoth;
                      return Cursors.SizeNESW;
                    }
                    else
                    {
                      this.editType = LevelTab.EditType.SizeHorz;
                      return Cursors.SizeWE;
                    }
                  }
                  else if ((mouse.Y & 15) < 4)
                  {
                    this.editType = LevelTab.EditType.SizeVert;
                    return Cursors.SizeNS;
                  }
                  else
                    break;
                case (byte) 15:
                  if ((mouse.X & 15) < 4)
                  {
                    if ((mouse.Y & 15) < 4)
                    {
                      this.editType = LevelTab.EditType.SizeBoth;
                      return Cursors.SizeNWSE;
                    }
                    else
                    {
                      this.editType = LevelTab.EditType.SizeHorz;
                      return Cursors.SizeWE;
                    }
                  }
                  else if ((mouse.Y & 15) < 4)
                  {
                    this.editType = LevelTab.EditType.SizeVert;
                    return Cursors.SizeNS;
                  }
                  else
                    break;
              }
              this.editType = LevelTab.EditType.Move;
              return Cursors.SizeAll;
            }
          }
          else
          {
            this.editType = LevelTab.EditType.Null;
            return Cursors.Default;
          }
        }
      }
    }

    public void AddObject(SortedSet<int> IDs, Level.Object obj)
    {
      if (this.editMode == LevelTab.EditMode.Object && this.selectedID.Count != 0)
      {
        this.SetRerenderFlagBefore(true, this.level.Objects.Count);
      }
      else
      {
        for (int index = this.rerenderFlag.Length - 1; index >= 0; --index)
          this.rerenderFlag[index] = false;
      }
      if (this.editMode == LevelTab.EditMode.Object)
        this.selectedID.Clear();
      if (IDs == this.selectedID)
      {
        this.selectedID.Add(this.level.Objects.Count);
        this.undoBuffer.Push((LevelTab.ICommand) new LevelTab.EditCommand(this, IDs,  obj, LevelTab.EditCommand.Type.AddObject, 0, 0));
        this.redoBuffer.Clear();
        this.levelEditor.EnableUndoRedo();
      }
      else if (this.editMode == LevelTab.EditMode.Object)
        this.selectedID.Add(this.level.Objects.Count);
      this.level.Objects.Add(obj);
      this.level.RedecodeLevel(this.level.Objects.Count - 1);
      this.SetRerenderFlagAfter(this.level.Objects.Count - 1);
      this.RenderLevel(this.bmp, this.rerenderFlag, 0, 0, this.bmp.Width, this.bmp.Height);
      this.levelEditor.miniMapViewer.UpdateInformation();
      Win32.InvalidateRect(this.Handle, (IntPtr) null, false);
      Win32.UpdateWindow(this.Handle);
    }

    public void AddObject(SortedSet<int> IDs, Level.Object[] objs)
    {
      if (this.editMode == LevelTab.EditMode.Object && this.selectedID.Count != 0)
      {
        this.SetRerenderFlagBefore(true, this.level.Objects.Count);
      }
      else
      {
        for (int index = this.rerenderFlag.Length - 1; index >= 0; --index)
          this.rerenderFlag[index] = false;
      }
      if (this.editMode == LevelTab.EditMode.Object)
        this.selectedID.Clear();
      if (this.editMode == LevelTab.EditMode.Object)
        this.selectedID = new SortedSet<int>((IEnumerable<int>) IDs);
      foreach (Level.Object @object in objs)
        this.level.Objects.Add(@object);
      this.level.RedecodeLevel(Enumerable.First<int>((IEnumerable<int>) IDs));
      this.SetRerenderFlagAfter(Enumerable.First<int>((IEnumerable<int>) IDs));
      this.RenderLevel(this.bmp, this.rerenderFlag, 0, 0, this.bmp.Width, this.bmp.Height);
      this.levelEditor.miniMapViewer.UpdateInformation();
      Win32.InvalidateRect(this.Handle, (IntPtr) null, false);
      Win32.UpdateWindow(this.Handle);
    }

    private void CopyObject(int x, int y)
    {
      if (this.selectedID.Count == 0 || (uint) x >= 256U || (uint) y >= 128U)
        return;
      int num1 = 256;
      int num2 = -1;
      int num3 = 128;
      int num4 = -1;
      int num5;
      int index1 = num5 = -1;
      int index2 = num5;
      int index3 = num5;
      int index4 = num5;
      foreach (int index5 in this.selectedID)
      {
        if ((int) this.level.Objects[index5].X < num1)
        {
          num1 = (int) this.level.Objects[index5].X;
          index4 = index5;
        }
        if ((int) this.level.Objects[index5].X > num2)
        {
          num2 = (int) this.level.Objects[index5].X;
          index3 = index5;
        }
        if ((int) this.level.Objects[index5].Y < num3)
        {
          num3 = (int) this.level.Objects[index5].Y;
          index2 = index5;
        }
        if ((int) this.level.Objects[index5].Y > num4)
        {
          num4 = (int) this.level.Objects[index5].Y;
          index1 = index5;
        }
      }
      int num6 = x - (int) this.level.Objects[index4].X;
      int num7 = y - (int) this.level.Objects[index2].Y;
      if (num6 > 0 && (int) this.level.Objects[index3].X + num6 >= 256)
        num6 = (int) byte.MaxValue - (int) this.level.Objects[index3].X;
      if (num7 > 0 && (int) this.level.Objects[index1].Y + num7 >= 128)
        num7 = (int) sbyte.MaxValue - (int) this.level.Objects[index1].Y;
      int count = this.level.Objects.Count;
      foreach (int index5 in this.selectedID)
      {
        Level.Object @object = this.level.Objects[index5];
        @object.X += (byte) num6;
        @object.Y += (byte) num7;
        this.level.Objects.Add(@object);
      }
      this.selectedID.Clear();
      int num8 = count;
      while (num8 < this.level.Objects.Count)
        this.selectedID.Add(num8++);
      this.level.RedecodeLevel(count);
      this.RenderLevel();
      this.levelEditor.miniMapViewer.UpdateInformation();
      Win32.InvalidateRect(this.Handle, (IntPtr) null, false);
      Win32.UpdateWindow(this.Handle);
    }

    public uint MoveObject(SortedSet<int> IDs, Keys key, int dx, int dy)
    {
      if (IDs == this.selectedID && (IDs.Count == 0 || dx == 0 && dy == 0))
        return 0U;
      foreach (int index in IDs)
      {
        if (dx > 0 && (int) this.level.Objects[index].X + dx >= 256)
          dx = (int) byte.MaxValue - (int) this.level.Objects[index].X;
        else if (dx < 0 && (int) this.level.Objects[index].X + dx < 0)
          dx = (int) -this.level.Objects[index].X;
        if (dy > 0 && (int) this.level.Objects[index].Y + dy >= 128)
          dy = (int) sbyte.MaxValue - (int) this.level.Objects[index].Y;
        else if (dy < 0 && (int) this.level.Objects[index].Y + dy < 0)
          dy = (int) -this.level.Objects[index].Y;
      }
      if (IDs == this.selectedID && dx == 0 && dy == 0)
        return 0U;
      int num1 = 0;
      int num2 = Enumerable.First<int>((IEnumerable<int>) IDs);
      SortedSet<int> sortedSet = new SortedSet<int>();
      for (int index = 0; index < this.rerenderFlag.Length; ++index)
        this.rerenderFlag[index] = false;
      if ((key & Keys.Control) == Keys.None)
      {
        foreach (int num3 in IDs)
        {
          Level.Object @object = this.level.Objects[num3 - num1];
          this.level.Objects.RemoveAt(num3 - num1++);
          @object.X += (byte) dx;
          @object.Y += (byte) dy;
          this.level.Objects.Add(@object);
        }
        for (; num1 != 0; --num1)
          sortedSet.Add(this.level.Objects.Count - num1);
      }
      else
      {
        foreach (int index in IDs)
        {
          Level.Object @object = this.level.Objects[index];
          @object.X += (byte) dx;
          @object.Y += (byte) dy;
          this.level.Objects[index] = @object;
        }
        sortedSet = new SortedSet<int>((IEnumerable<int>) IDs);
      }
      this.SetRerenderFlagBefore(true, num2);
      this.level.RedecodeLevel(num2);
      if (this.editMode == LevelTab.EditMode.Object)
        this.selectedID = sortedSet;
      this.SetRerenderFlagAfter(Enumerable.First<int>((IEnumerable<int>) sortedSet));
      this.RenderLevel(this.bmp, this.rerenderFlag, 0, 0, this.bmp.Width, this.bmp.Height);
      Win32.InvalidateRect(this.Handle, (IntPtr) null, false);
      this.levelEditor.miniMapViewer.UpdateInformation();
      
      return (uint) (ushort) dy << 16 | (uint) (ushort) dx;
    }

    public void UndoMoveObject(SortedSet<int> IDs, Level.Object[] objs)
    {
      int num = Enumerable.First<int>((IEnumerable<int>) IDs);
      this.level.Objects.RemoveRange(this.level.Objects.Count - IDs.Count, IDs.Count);
      for (int index = 0; index < objs.Length; ++index)
      {
        Level.Object @object = objs[index];
        this.level.Objects.Insert(Enumerable.ElementAt<int>((IEnumerable<int>) IDs, index), @object);
      }
      this.SetRerenderFlagBefore(true, num);
      this.level.RedecodeLevel(num);
      if (this.editMode == LevelTab.EditMode.Object)
        this.selectedID = new SortedSet<int>((IEnumerable<int>) IDs);
      this.SetRerenderFlagAfter(num);
      this.RenderLevel(this.bmp, this.rerenderFlag, 0, 0, this.bmp.Width, this.bmp.Height);
      this.levelEditor.miniMapViewer.UpdateInformation();
      Win32.InvalidateRect(this.Handle, (IntPtr) null, false);
      
    }

    public bool SizeObject(SortedSet<int> IDs, Level.Object[] originalObjects, int dx, int dy)
    {
      bool flag1 = false;
      int index1 = -1;
      Level.Object[] objectArray = (Level.Object[]) null;
      if (IDs == this.selectedID && originalObjects == null)
      {
        objectArray = new Level.Object[IDs.Count];
        for (int index2 = 0; index2 < objectArray.Length; ++index2)
          objectArray[index2] = this.level.Objects[Enumerable.ElementAt<int>((IEnumerable<int>) IDs, index2)];
      }
      foreach (int index2 in IDs)
      {
        ++index1;
        if ((int) this.level.Objects[index2].num != 0)
        {
          int num1;
          int num2;
          int num3;
          int num4;
          if (originalObjects != null)
          {
            num2 = num1 = (int) (short) originalObjects[index1].width < 0 ? (int) (short) originalObjects[index1].width + 1 : (int) originalObjects[index1].width;
            num4 = num3 = (int) (short) originalObjects[index1].height < 0 ? (int) (short) originalObjects[index1].height + 1 : (int) originalObjects[index1].height;
          }
          else
          {
            num2 = num1 = (int) (short) this.level.Objects[index2].width < 0 ? (int) (short) this.level.Objects[index2].width + 1 : (int) this.level.Objects[index2].width;
            num4 = num3 = (int) (short) this.level.Objects[index2].height < 0 ? (int) (short) this.level.Objects[index2].height + 1 : (int) this.level.Objects[index2].height;
          }
          bool flag2 = dx != 0 && ((int) this.YI.ROM[591084 + (int) this.level.Objects[index2].num].u8 & 3) != 1;
          bool flag3 = dy != 0 && ((int) this.YI.ROM[591084 + (int) this.level.Objects[index2].num].u8 & 3) != 0;
          if (flag2)
          {
            num2 += dx;
            if ((int) this.level.Header[1] == 2)
            {
              if (num2 > 256)
                num2 = 256;
              else if (num2 < 1)
                num2 = 1;
            }
            else if (((int) this.YI.ROM[591084 + (int) this.level.Objects[index2].num].u8 & 128) == 0)
            {
              if (num2 > 128)
                num2 = 128;
              else if (num2 < 1)
                num2 = 1;
            }
            else if (num2 > 128)
              num2 = 128;
            else if (num2 < -127)
              num2 = -127;
          }
          if (flag3)
          {
            num4 += dy;
            if (((int) this.YI.ROM[591084 + (int) this.level.Objects[index2].num].u8 & 64) == 0)
            {
              if (num4 > 128)
                num4 = 128;
              else if (num4 < 1)
                num4 = 1;
            }
            else if (num4 > 128)
              num4 = 128;
            else if (num4 < -127)
              num4 = -127;
          }
          if (!this.keyState.HasFlag((Enum) Keys.Control))
          {
            if (flag2)
            {
              byte num5 = this.level.Objects[index2].num;
              if ((uint) num5 <= 98U)
              {
                if ((uint) num5 <= 42U)
                {
                  switch (num5)
                  {
                    case (byte) 4:
                      break;
                    case (byte) 6:
                      goto label_46;
                    case (byte) 8:
                      goto label_48;
                    case (byte) 39:
                      if (num2 >= 2)
                        num2 = 1;
                      if (num4 < (num2 < 0 ? -num2 : num2))
                      {
                        num2 = num4 == 1 ? num4 : -num4;
                        goto label_132;
                      }
                      else
                        goto label_132;
                    case (byte) 40:
                      if (num4 < num2)
                      {
                        num2 = num4;
                        goto label_132;
                      }
                      else
                        goto label_132;
                    case (byte) 41:
                      if (num2 >= 2)
                        num2 = 1;
                      if (((num4 < 0 ? -num4 : num4) + 1) / 2 < ((num2 < 0 ? -num2 : num2) + 1) / 2)
                      {
                        num2 = (num4 < 0 ? num4 : -num4) & -2;
                        goto label_132;
                      }
                      else
                        goto label_132;
                    case (byte) 42:
                      if (num2 <= 0)
                        num2 = 1;
                      if (((num4 < 0 ? -num4 : num4) + 1) / 2 < (num2 + 1) / 2)
                      {
                        num2 = (num4 < 0 ? -num4 : num4) + 1 & -2;
                        goto label_132;
                      }
                      else
                        goto label_132;
                    default:
                      goto label_132;
                  }
                }
                else
                {
                  switch (num5)
                  {
                    case (byte) 58:
                      if (num4 / 2 < num2)
                      {
                        num2 = (num4 + 1) / 2;
                        goto label_132;
                      }
                      else
                        goto label_132;
                    case (byte) 69:
                    case (byte) 90:
                      goto label_46;
                    case (byte) 82:
                      if (num4 < (num2 < 0 ? -num2 : num2))
                      {
                        num4 = num2 < 0 ? -num2 : num2;
                        goto label_132;
                      }
                      else if (num4 - 1 > (num2 < 0 ? -num2 : num2))
                      {
                        num4 = (num2 < 0 ? -num2 : num2) + 1;
                        goto label_132;
                      }
                      else
                        goto label_132;
                    case (byte) 84:
                      if (num4 != ((num2 < 0 ? -num2 : num2) + 1) / 2)
                      {
                        num4 = ((num2 < 0 ? -num2 : num2) + 1) / 2;
                        goto label_132;
                      }
                      else
                        goto label_132;
                    case (byte) 85:
                      if (num4 + 1 != (num2 < 0 ? -num2 : num2))
                      {
                        num4 = Math.Max((num2 < 0 ? -num2 : num2) - 1, 1);
                        goto label_132;
                      }
                      else
                        goto label_132;
                    case (byte) 86:
                      if (-2 <= num2 && num2 <= 2)
                      {
                        num4 = 1;
                        goto label_132;
                      }
                      else if (num4 != (num2 < 0 ? -num2 : num2) * 2 - 3)
                      {
                        num4 = (num2 < 0 ? -num2 : num2) * 2 - 3;
                        goto label_132;
                      }
                      else
                        goto label_132;
                    case (byte) 89:
                      break;
                    case (byte) 91:
                      goto label_48;
                    case (byte) 95:
                      if ((num2 & 1) != 0)
                      {
                        if (dx > 0)
                          ++num2;
                        else
                          --num2;
                      }
                      if (num4 < (num2 + 1) / 2)
                      {
                        num4 = (num2 + 1) / 2;
                        goto label_132;
                      }
                      else
                        goto label_132;
                    case (byte) 96:
                      if (num4 < num2)
                      {
                        num4 = num2;
                        goto label_132;
                      }
                      else
                        goto label_132;
                    case (byte) 97:
                      if ((num2 & 1) != 0)
                      {
                        if (dx > 0)
                          ++num2;
                        else
                          --num2;
                      }
                      if (num4 < num2 / 2)
                      {
                        num4 = num2 / 2;
                        goto label_132;
                      }
                      else
                        goto label_132;
                    case (byte) 98:
                      if (num4 < num2 + 1)
                      {
                        num4 = num2 + 1;
                        goto label_132;
                      }
                      else
                        goto label_132;
                    default:
                      goto label_132;
                  }
                }
                if (num4 + 1 < (num2 + 1) / 2)
                {
                  num2 = (num4 + 1) * 2;
                  goto label_132;
                }
                else
                  goto label_132;
label_46:
                if (num4 + 1 < num2)
                {
                  num2 = num4 + 1;
                  goto label_132;
                }
                else
                  goto label_132;
label_48:
                if ((num4 + 2) / 2 < num2)
                  num2 = (num4 + 2) / 2;
              }
              else
              {
                if ((uint) num5 <= 181U)
                {
                  switch (num5)
                  {
                    case (byte) 123:
                      if (num4 < (num2 < 0 ? -num2 : num2))
                      {
                        num2 = num2 < 0 ? -num4 : num4;
                        goto label_132;
                      }
                      else
                        goto label_132;
                    case (byte) 143:
                      if (num4 < (num2 < 0 ? -num2 : num2) / 2)
                      {
                        num4 = (num2 < 0 ? -num2 : num2) / 2;
                        goto label_132;
                      }
                      else if ((num2 < 0 ? -num2 : num2) < num4 * 2 - 3)
                      {
                        num4 = (num2 < 0 ? -num2 : num2) / 2 + 1;
                        goto label_132;
                      }
                      else
                        goto label_132;
                    case (byte) 144:
                      if (num4 + 1 < (num2 < 0 ? -num2 : num2))
                      {
                        num4 = (num2 < 0 ? -num2 : num2) - 1;
                        goto label_132;
                      }
                      else if ((num2 < 0 ? -num2 : num2) + 1 < num4)
                      {
                        num4 = (num2 < 0 ? -num2 : num2) + 1;
                        goto label_132;
                      }
                      else
                        goto label_132;
                    case (byte) 178:
                    case (byte) 179:
                    case (byte) 180:
                    case (byte) 181:
                      break;
                    default:
                      goto label_132;
                  }
                }
                else
                {
                  switch (num5)
                  {
                    case (byte) 194:
                      break;
                    case (byte) 195:
                      if (num2 < 0)
                      {
                        num2 = 1;
                        goto label_132;
                      }
                      else
                        goto label_132;
                    case (byte) 204:
                      if (num2 >= 2)
                        num2 = 1;
                      if ((num4 < 0 ? -num4 : num4) < (num2 < 0 ? -num2 : num2))
                      {
                        num2 = num4;
                        goto label_132;
                      }
                      else
                        goto label_132;
                    case (byte) 205:
                      if ((num4 < 0 ? -num4 : num4) < (num2 < 0 ? -num2 : num2))
                      {
                        num2 = num4 < 0 ? -num4 : num4;
                        goto label_132;
                      }
                      else
                        goto label_132;
                    case (byte) 229:
                      if (num2 >= 2)
                        num2 = 1;
                      if (num4 < ((num2 < 0 ? -num2 : num2) - 1) / 2)
                      {
                        num2 = -(num4 + 1) * 2;
                        goto label_132;
                      }
                      else
                        goto label_132;
                    case (byte) 230:
                      if (num2 >= 2)
                        num2 = 1;
                      if (num4 + 1 < ((num2 < 0 ? -num2 : num2) + 1 & -2))
                      {
                        num2 = -(num4 + 1 & -2);
                        goto label_132;
                      }
                      else
                        goto label_132;
                    case (byte) 231:
                      if (num2 >= 2)
                        num2 = 1;
                      if (num4 < ((num2 < 0 ? -num2 : num2) - 1) * 2)
                      {
                        num2 = -(num4 / 2 + 1);
                        goto label_132;
                      }
                      else
                        goto label_132;
                    case (byte) 232:
                      if (num4 < (num2 - 1) / 2)
                      {
                        num2 = (num4 + 1) * 2;
                        goto label_132;
                      }
                      else
                        goto label_132;
                    case (byte) 233:
                      if (num4 + 1 < (num2 + 1 & -2))
                      {
                        num2 = num4 + 1 & -2;
                        goto label_132;
                      }
                      else
                        goto label_132;
                    case (byte) 234:
                      if (num4 < (num2 - 1) * 2)
                      {
                        num2 = num4 / 2 + 1;
                        goto label_132;
                      }
                      else
                        goto label_132;
                    default:
                      goto label_132;
                  }
                }
                if (num2 >= 2)
                  num2 = 1;
              }
            }
label_132:
            if (flag3)
            {
              byte num5 = this.level.Objects[index2].num;
              if ((uint) num5 <= 98U)
              {
                if ((uint) num5 <= 42U)
                {
                  switch (num5)
                  {
                    case (byte) 4:
                      break;
                    case (byte) 6:
                      goto label_142;
                    case (byte) 8:
                      goto label_144;
                    case (byte) 39:
                      if (num4 < (num2 < 0 ? -num2 : num2))
                      {
                        num4 = num2 < 0 ? -num2 : num2;
                        goto label_228;
                      }
                      else
                        goto label_228;
                    case (byte) 40:
                      if (num4 < num2)
                      {
                        num4 = num2;
                        goto label_228;
                      }
                      else
                        goto label_228;
                    case (byte) 41:
                      if (num4 >= 2)
                        num4 = 1;
                      if (((num4 < 0 ? -num4 : num4) + 1) / 2 < ((num2 < 0 ? -num2 : num2) + 1) / 2)
                      {
                        num4 = (num2 & -2) + 1;
                        goto label_228;
                      }
                      else
                        goto label_228;
                    case (byte) 42:
                      if (num4 >= 2)
                        num4 = 1;
                      if (((num4 < 0 ? -num4 : num4) + 1) / 2 < (num2 + 1) / 2)
                      {
                        num4 = num2 == 1 ? num2 : -((num2 + 1 & -2) - 1);
                        goto label_228;
                      }
                      else
                        goto label_228;
                    default:
                      goto label_228;
                  }
                }
                else
                {
                  switch (num5)
                  {
                    case (byte) 58:
                      if (num4 / 2 < num2)
                      {
                        num4 = num2 * 2 - 1;
                        goto label_228;
                      }
                      else
                        goto label_228;
                    case (byte) 69:
                    case (byte) 90:
                      goto label_142;
                    case (byte) 82:
                      if (num4 < 1)
                        num4 = 1;
                      if (num4 < (num2 < 0 ? -num2 : num2))
                      {
                        num2 = num2 < 0 ? -num4 : num4;
                        goto label_228;
                      }
                      else if (num4 - 1 > (num2 < 0 ? -num2 : num2))
                      {
                        num2 = num2 < 0 ? -num4 + 1 : num4 - 1;
                        goto label_228;
                      }
                      else
                        goto label_228;
                    case (byte) 84:
                      if (num4 < 1)
                        num4 = 1;
                      if (num4 != ((num2 < 0 ? -num2 : num2) + 1) / 2)
                      {
                        num2 = (num2 < 0 ? -num4 : num4) * 2 - 1;
                        goto label_228;
                      }
                      else
                        goto label_228;
                    case (byte) 85:
                      if (num4 < 1)
                        num4 = 1;
                      if (num4 + 1 != (num2 < 0 ? -num2 : num2))
                      {
                        num2 = num2 < 0 ? -num4 - 1 : num4 + 1;
                        goto label_228;
                      }
                      else
                        goto label_228;
                    case (byte) 86:
                      if (num4 < 1)
                        num4 = 1;
                      if (num4 != (num2 < 0 ? -num2 : num2) * 2 - 3)
                      {
                        num2 = num2 < 0 ? -((num4 - 3) / 2 + 3) : (num4 - 3) / 2 + 3;
                        num4 = (num2 < 0 ? -num2 : num2) * 2 - 3;
                        goto label_228;
                      }
                      else
                        goto label_228;
                    case (byte) 89:
                      break;
                    case (byte) 91:
                      goto label_144;
                    case (byte) 95:
                      if (num4 < (num2 + 1) / 2)
                      {
                        num4 = (num2 + 1) / 2;
                        goto label_228;
                      }
                      else
                        goto label_228;
                    case (byte) 96:
                      if (num4 < num2)
                      {
                        num4 = num2;
                        goto label_228;
                      }
                      else
                        goto label_228;
                    case (byte) 97:
                      if (num4 < num2 / 2)
                      {
                        num4 = num2 / 2;
                        goto label_228;
                      }
                      else
                        goto label_228;
                    case (byte) 98:
                      if (num4 < num2 + 1)
                      {
                        num4 = num2 + 1;
                        goto label_228;
                      }
                      else
                        goto label_228;
                    default:
                      goto label_228;
                  }
                }
                if (num4 + 1 < (num2 + 1) / 2)
                {
                  num4 = Math.Max((num2 + 1) / 2 - 1, 1);
                  goto label_228;
                }
                else
                  goto label_228;
label_142:
                if (num4 + 1 < num2)
                {
                  num4 = Math.Max(num2 - 1, 1);
                  goto label_228;
                }
                else
                  goto label_228;
label_144:
                if ((num4 + 2) / 2 < num2)
                  num4 = (num2 - 1) * 2;
              }
              else if ((uint) num5 <= 136U)
              {
                switch (num5)
                {
                  case (byte) 123:
                    if (num4 < 1)
                      num4 = 1;
                    if (num4 < (num2 < 0 ? -num2 : num2))
                    {
                      num4 = num2 < 0 ? -num2 : num2;
                      break;
                    }
                    else
                      break;
                  case (byte) 135:
                  case (byte) 136:
                    if (num4 < 2)
                    {
                      num4 = 2;
                      break;
                    }
                    else
                      break;
                }
              }
              else
              {
                switch (num5)
                {
                  case (byte) 143:
                    if (num4 < (num2 < 0 ? -num2 : num2) / 2)
                    {
                      num2 = num2 < 0 ? -(num4 * 2 + 1) : num4 * 2 + 1;
                      break;
                    }
                    else if ((num2 < 0 ? -num2 : num2) + 3 < num4 * 2)
                    {
                      num2 = num2 < 0 ? -num4 * 2 + 3 : num4 * 2 - 3;
                      break;
                    }
                    else
                      break;
                  case (byte) 144:
                    if (num4 + 1 < (num2 < 0 ? -num2 : num2))
                    {
                      num2 = num2 < 0 ? -num4 - 1 : num4 + 1;
                      break;
                    }
                    else if ((num2 < 0 ? -num2 : num2) + 1 < num4)
                    {
                      num2 = num2 < 0 ? -num4 + 1 : num4 - 1;
                      break;
                    }
                    else
                      break;
                  case (byte) 202:
                    if (num4 < 2)
                    {
                      num4 = 2;
                      break;
                    }
                    else
                      break;
                  case (byte) 204:
                    if (num4 >= 2)
                      num4 = 1;
                    if ((num4 < 0 ? -num4 : num4) < (num2 < 0 ? -num2 : num2))
                    {
                      num4 = num2;
                      break;
                    }
                    else
                      break;
                  case (byte) 205:
                    if (num4 >= 2)
                      num4 = 1;
                    if ((num4 < 0 ? -num4 : num4) < (num2 < 0 ? -num2 : num2))
                    {
                      num4 = num2 == 1 ? 1 : -num2;
                      break;
                    }
                    else
                      break;
                  case (byte) 229:
                    if (num4 < 1)
                      num4 = 1;
                    if (num4 < ((num2 < 0 ? -num2 : num2) - 1) / 2)
                    {
                      num4 = ((num2 < 0 ? -num2 : num2) - 1) / 2;
                      break;
                    }
                    else
                      break;
                  case (byte) 230:
                    if (num4 < 1)
                      num4 = 1;
                    if (num4 + 1 < ((num2 < 0 ? -num2 : num2) + 1 & -2))
                    {
                      num4 = ((num2 < 0 ? -num2 : num2) + 1 & -2) - 1;
                      break;
                    }
                    else
                      break;
                  case (byte) 231:
                    if (num4 < 1)
                      num4 = 1;
                    if (num4 < ((num2 < 0 ? -num2 : num2) - 1) * 2)
                    {
                      num4 = ((num2 < 0 ? -num2 : num2) - 1) * 2;
                      break;
                    }
                    else
                      break;
                  case (byte) 232:
                    if (num4 < (num2 - 1) / 2)
                    {
                      num4 = (num2 - 1) / 2;
                      break;
                    }
                    else
                      break;
                  case (byte) 233:
                    if (num4 + 1 < (num2 + 1 & -2))
                    {
                      num4 = (num2 + 1 & -2) - 1;
                      break;
                    }
                    else
                      break;
                  case (byte) 234:
                    if (num4 < (num2 - 1) * 2)
                    {
                      num4 = (num2 - 1) * 2;
                      break;
                    }
                    else
                      break;
                }
              }
            }
label_228:
            if ((int) this.level.Header[1] == 2)
            {
              if (num2 > 256)
                num2 = 256;
              else if (num2 < 1)
                num2 = 1;
            }
            else if (((int) this.YI.ROM[591084 + (int) this.level.Objects[index2].num].u8 & 128) == 0)
            {
              if (num2 > 128)
                num2 = 128;
              else if (num2 < 1)
                num2 = 1;
            }
            else if (num2 > 128)
              num2 = 128;
            else if (num2 < -127)
              num2 = -127;
            if (((int) this.YI.ROM[591084 + (int) this.level.Objects[index2].num].u8 & 64) == 0)
            {
              if (num4 > 128)
                num4 = 128;
              else if (num4 < 1)
                num4 = 1;
            }
            else if (num4 > 128)
              num4 = 128;
            else if (num4 < -127)
              num4 = -127;
          }
          Level.Object @object = this.level.Objects[index2];
          @object.width = num2 <= 0 ? (ushort) (num2 - 1) : (ushort) num2;
          @object.height = num4 <= 0 ? (ushort) (num4 - 1) : (ushort) num4;
          this.level.Objects[index2] = @object;
          if (!flag1)
            flag1 = this.selectedObjects != null || num1 != num2 || num3 != num4;
        }
      }
      if (!flag1)
        return false;
      this.SetRerenderFlagBefore(true, Enumerable.First<int>((IEnumerable<int>) IDs));
      this.level.RedecodeLevel(Enumerable.First<int>((IEnumerable<int>) IDs));
      if (IDs == this.selectedID && objectArray != null)
      {
        this.undoBuffer.Push((LevelTab.ICommand) new LevelTab.EditCommand(this, IDs,  objectArray, LevelTab.EditCommand.Type.SizeObject, dx, dy));
        this.redoBuffer.Clear();
        this.levelEditor.EnableUndoRedo();
      }
      if (this.editMode == LevelTab.EditMode.Object)
        this.selectedID = new SortedSet<int>((IEnumerable<int>) IDs);
      this.SetRerenderFlagAfter(Enumerable.First<int>((IEnumerable<int>) IDs));
      this.RenderLevel(this.bmp, this.rerenderFlag, 0, 0, this.bmp.Width, this.bmp.Height);
      this.levelEditor.miniMapViewer.UpdateInformation();
      Win32.InvalidateRect(this.Handle, (IntPtr) null, false);
      
      return true;
    }

    public void RestoreObject(SortedSet<int> IDs, Level.Object[] originalObjects)
    {
      int index1 = -1;
      foreach (int index2 in IDs)
      {
        ++index1;
        this.level.Objects[index2] = originalObjects[index1];
      }
      this.SetRerenderFlagBefore(true, Enumerable.First<int>((IEnumerable<int>) IDs));
      this.level.RedecodeLevel(Enumerable.First<int>((IEnumerable<int>) IDs));
      if (this.editMode == LevelTab.EditMode.Object)
        this.selectedID = new SortedSet<int>((IEnumerable<int>) IDs);
      this.SetRerenderFlagAfter(Enumerable.First<int>((IEnumerable<int>) IDs));
      this.RenderLevel(this.bmp, this.rerenderFlag, 0, 0, this.bmp.Width, this.bmp.Height);
      this.levelEditor.miniMapViewer.UpdateInformation();
      Win32.InvalidateRect(this.Handle, (IntPtr) null, false);
      
    }

    public void RestoreMovedObject(SortedSet<int> IDs, Level.Object[] originalObjects)
    {
      for (int index = 0; index < this.rerenderFlag.Length; ++index)
        this.rerenderFlag[index] = false;
      int num = Enumerable.First<int>((IEnumerable<int>) IDs);
      int index1 = 0;
      foreach (Level.Object @object in originalObjects)
      {
        this.level.Objects[Enumerable.ElementAt<int>((IEnumerable<int>) IDs, index1)] = @object;
        ++index1;
      }
      this.SetRerenderFlagBefore(false, num);
      this.level.RedecodeLevel(num);
      if (this.editMode == LevelTab.EditMode.Object)
        this.selectedID = new SortedSet<int>((IEnumerable<int>) IDs);
      this.SetRerenderFlagAfter(num);
      this.RenderLevel(this.bmp, this.rerenderFlag, 0, 0, this.bmp.Width, this.bmp.Height);
      this.levelEditor.miniMapViewer.UpdateInformation();
      Win32.InvalidateRect(this.Handle, (IntPtr) null, false);
      
    }

    public bool ChangeZOrder(SortedSet<int> IDs, bool decrease)
    {
      int[] numArray1 = new int[IDs.Count];
      int[] numArray2 = new int[IDs.Count];
      int[] array = Enumerable.ToArray<int>((IEnumerable<int>) IDs);
      int num1;
      if (!decrease)
      {
        num1 = this.level.Objects.Count;
        if (Enumerable.First<int>((IEnumerable<int>) array) + array.Length == this.level.Objects.Count)
          return false;
        for (int index = 0; index < array.Length; ++index)
        {
          if (array[index] + array.Length - index == this.level.Objects.Count)
          {
            num1 = array[index];
            break;
          }
        }
        for (int index = 0; index < numArray1.Length; ++index)
          numArray1[index] = num1 - 1;
      }
      else
      {
        num1 = -1;
        if (Enumerable.Last<int>((IEnumerable<int>) array) - (array.Length - 1) == 0)
          return false;
        for (int index = array.Length - 1; index >= 0; --index)
        {
          if (array[index] - index == 0)
          {
            num1 = array[index];
            break;
          }
        }
        for (int index = array.Length - 1; index >= 0; --index)
          numArray1[index] = num1 + 1;
      }
      this.SetRerenderFlagBefore(true, Enumerable.First<int>((IEnumerable<int>) IDs));
      int num2;
      if (!decrease)
      {
        num2 = Enumerable.First<int>((IEnumerable<int>) array);
        for (int index1 = 0; index1 <= this.level.PageCount; ++index1)
        {
          for (int index2 = 0; index2 < 256; ++index2)
          {
            Level.LevelTileList levelTileList = this.level.InternalTiles[index1][index2];
            for (int index3 = levelTileList.Count - 1; index3 > 0; --index3)
            {
              int num3 = levelTileList[index3].id;
              if (IDs.Contains(num3) && num1 > num3)
              {
                while (index3 >= 0 && levelTileList[index3].id == num3)
                  --index3;
                if (index3 >= 0 && levelTileList[index3].id < numArray1[Array.IndexOf<int>(array, num3)])
                  numArray1[Array.IndexOf<int>(array, num3)] = levelTileList[index3].id;
                ++index3;
              }
            }
          }
        }
        for (int index1 = array.Length - 1; index1 >= 0; --index1)
        {
          if (array[index1] >= num1)
          {
            numArray2[index1] = array[index1];
          }
          else
          {
            for (int index2 = index1 + 1; index2 < array.Length; ++index2)
            {
              if (numArray1[index1] == array[index2])
              {
                numArray1[index1] = numArray1[index2];
                break;
              }
            }
            int num3 = 0;
            for (int index2 = index1 + 1; index2 < array.Length && array[index2] < num1; ++index2)
            {
              if (numArray1[index1] >= array[index2] && numArray1[index2] >= numArray1[index1])
                ++num3;
            }
            Level.Object @object = this.level.Objects[array[index1]];
            this.level.Objects.RemoveAt(array[index1]);
            numArray2[index1] = numArray1[index1] - num3;
            this.level.Objects.Insert(numArray1[index1] - num3, @object);
            for (int index2 = index1 + 1; index2 < array.Length && array[index2] < num1; ++index2)
            {
              if (numArray2[index2] < numArray2[index1])
                --numArray2[index2];
            }
          }
        }
        if (this.selectedID == IDs)
        {
          this.undoBuffer.Push((LevelTab.ICommand) new LevelTab.EditCommand(this, IDs, numArray2.Clone(), LevelTab.EditCommand.Type.IncreaseZOrderObject, 0, 0));
          this.redoBuffer.Clear();
          this.levelEditor.EnableUndoRedo();
        }
        if (this.editMode == LevelTab.EditMode.Object)
          this.selectedID = new SortedSet<int>((IEnumerable<int>) numArray2);
      }
      else
      {
        for (int index1 = 0; index1 <= this.level.PageCount; ++index1)
        {
          for (int index2 = 0; index2 < 256; ++index2)
          {
            Level.LevelTileList levelTileList = this.level.InternalTiles[index1][index2];
            for (int index3 = 0; index3 < levelTileList.Count - 1; ++index3)
            {
              int num3 = levelTileList[index3].id;
              if (IDs.Contains(num3) && num1 < num3)
              {
                while (index3 < levelTileList.Count && levelTileList[index3].id == num3)
                  ++index3;
                if (index3 < levelTileList.Count && levelTileList[index3].id > numArray1[Array.IndexOf<int>(array, num3)])
                  numArray1[Array.IndexOf<int>(array, num3)] = levelTileList[index3].id;
                --index3;
              }
            }
          }
        }
        for (int index1 = 0; index1 < array.Length; ++index1)
        {
          if (array[index1] <= num1)
          {
            numArray2[index1] = array[index1];
          }
          else
          {
            for (int index2 = index1 - 1; index2 >= 0; --index2)
            {
              if (numArray1[index1] == array[index2])
              {
                numArray1[index1] = numArray1[index2];
                break;
              }
            }
            int num3 = 0;
            for (int index2 = index1 - 1; index2 >= 0 && array[index2] > num1; --index2)
            {
              if (numArray1[index1] <= array[index2] && numArray1[index2] <= numArray1[index1])
                ++num3;
            }
            Level.Object @object = this.level.Objects[array[index1]];
            this.level.Objects.RemoveAt(array[index1]);
            numArray2[index1] = numArray1[index1] + num3;
            this.level.Objects.Insert(numArray1[index1] + num3, @object);
            for (int index2 = index1 - 1; index2 >= 0 && array[index2] > num1; --index2)
            {
              if (numArray2[index2] > numArray2[index1])
                ++numArray2[index2];
            }
          }
        }
        if (this.selectedID == IDs)
        {
          this.undoBuffer.Push((LevelTab.ICommand) new LevelTab.EditCommand(this, IDs, numArray2.Clone(), LevelTab.EditCommand.Type.DecreaseZOrderObject, 0, 0));
          this.redoBuffer.Clear();
          this.levelEditor.EnableUndoRedo();
        }
        if (this.editMode == LevelTab.EditMode.Object)
          this.selectedID = new SortedSet<int>((IEnumerable<int>) numArray2);
        num2 = Enumerable.Min((IEnumerable<int>) numArray2);
      }
      this.level.RedecodeLevel(num2);
      this.SetRerenderFlagAfter(num2);
      
      this.RenderLevel(this.bmp, this.rerenderFlag, 0, 0, this.bmp.Width, this.bmp.Height);
      this.levelEditor.miniMapViewer.UpdateInformation();
      Win32.InvalidateRect(this.Handle, (IntPtr) null, false);
      Win32.UpdateWindow(this.Handle);
      return true;
    }

    public void UndoIncreaseZOrder(SortedSet<int> IDs, int[] resultID)
    {
      List<Level.Object> list = new List<Level.Object>(this.level.Objects.Count);
      int[] array = Enumerable.ToArray<int>((IEnumerable<int>) IDs);
      int num = 0;
      for (int index = 0; index < this.level.Objects.Count; ++index)
      {
        if (Array.IndexOf<int>(array, index) < 0)
        {
          while (Array.IndexOf<int>(resultID, num) >= 0)
            ++num;
          list.Add(this.level.Objects[num++]);
        }
        else
          list.Add(this.level.Objects[resultID[Array.IndexOf<int>(array, index)]]);
      }
      this.level.Objects = list;
      this.SetRerenderFlagBefore(true, Enumerable.Min((IEnumerable<int>) resultID));
      if (this.editMode == LevelTab.EditMode.Object)
        this.selectedID = new SortedSet<int>((IEnumerable<int>) IDs);
      this.level.RedecodeLevel(Enumerable.First<int>((IEnumerable<int>) IDs));
      this.SetRerenderFlagAfter(Enumerable.First<int>((IEnumerable<int>) IDs));
      this.RenderLevel(this.bmp, this.rerenderFlag, 0, 0, this.bmp.Width, this.bmp.Height);
      this.levelEditor.miniMapViewer.UpdateInformation();
      Win32.InvalidateRect(this.Handle, (IntPtr) null, false);
      Win32.UpdateWindow(this.Handle);
      
    }

    public void UndoDecreaseZOrder(SortedSet<int> IDs, int[] resultID)
    {
      List<Level.Object> list = new List<Level.Object>(this.level.Objects.Count);
      int[] array = Enumerable.ToArray<int>((IEnumerable<int>) IDs);
      int num = this.level.Objects.Count - 1;
      for (int index = num; index >= 0; --index)
      {
        if (Array.IndexOf<int>(array, index) < 0)
        {
          while (Array.IndexOf<int>(resultID, num) >= 0)
            --num;
          list.Insert(0, this.level.Objects[num--]);
        }
        else
          list.Insert(0, this.level.Objects[resultID[Array.IndexOf<int>(array, index)]]);
      }
      this.level.Objects = list;
      this.SetRerenderFlagBefore(true, Enumerable.First<int>((IEnumerable<int>) IDs));
      if (this.editMode == LevelTab.EditMode.Object)
        this.selectedID = new SortedSet<int>((IEnumerable<int>) IDs);
      this.level.RedecodeLevel(Enumerable.Min((IEnumerable<int>) resultID));
      this.SetRerenderFlagAfter(Enumerable.Min((IEnumerable<int>) resultID));
      this.RenderLevel(this.bmp, this.rerenderFlag, 0, 0, this.bmp.Width, this.bmp.Height);
      this.levelEditor.miniMapViewer.UpdateInformation();
      Win32.InvalidateRect(this.Handle, (IntPtr) null, false);
      Win32.UpdateWindow(this.Handle);
      
    }

    public void DeleteObject(SortedSet<int> IDs)
    {
      if (IDs.Count == 0)
        return;
      int num1 = Enumerable.First<int>((IEnumerable<int>) IDs);
      int index = 0;
      Level.Object[] objectArray = (Level.Object[]) null;
      if (IDs == this.selectedID)
        objectArray = new Level.Object[IDs.Count];
      foreach (int num2 in IDs)
      {
        if (objectArray != null)
          objectArray[index] = this.level.Objects[num2 - index];
        this.level.Objects.RemoveAt(num2 - index++);
      }
      this.SetRerenderFlagBefore(true, num1);
      this.level.RedecodeLevel(num1);
      if (IDs == this.selectedID)
      {
        this.undoBuffer.Push((LevelTab.ICommand) new LevelTab.EditCommand(this, IDs,  objectArray, LevelTab.EditCommand.Type.DeleteObject, 0, 0));
        this.redoBuffer.Clear();
        this.levelEditor.EnableUndoRedo();
      }
      if (this.editMode == LevelTab.EditMode.Object)
        this.selectedID.Clear();
      this.SetRerenderFlagAfter(num1);
      this.editType = LevelTab.EditType.Null;
      this.Cursor = Cursors.Default;
      this.RenderLevel(this.bmp, this.rerenderFlag, 0, 0, this.bmp.Width, this.bmp.Height);
      this.levelEditor.miniMapViewer.UpdateInformation();
      Win32.InvalidateRect(this.Handle, (IntPtr) null, false);
      Win32.UpdateWindow(this.Handle);
    }

    public void InsertObject(SortedSet<int> IDs, Level.Object[] objs)
    {
      int index1 = 0;
      foreach (int index2 in IDs)
      {
        this.level.Objects.Insert(index2, objs[index1]);
        ++index1;
      }
      this.SetRerenderFlagBefore(true, Enumerable.First<int>((IEnumerable<int>) IDs));
      this.level.RedecodeLevel(Enumerable.First<int>((IEnumerable<int>) IDs));
      if (this.editMode == LevelTab.EditMode.Object)
        this.selectedID = new SortedSet<int>((IEnumerable<int>) IDs);
      this.SetRerenderFlagAfter(Enumerable.First<int>((IEnumerable<int>) IDs));
      this.RenderLevel(this.bmp, this.rerenderFlag, 0, 0, this.bmp.Width, this.bmp.Height);
      this.levelEditor.miniMapViewer.UpdateInformation();
      Win32.InvalidateRect(this.Handle, (IntPtr) null, false);
      Win32.UpdateWindow(this.Handle);
      
    }

    private void SetRerenderFlagSprite(int updateID)
    {
      this.rerenderFlag.Initialize();
      for (int index = updateID; index < this.level.Sprites.Count; ++index)
      {
        int num1 = (int) this.level.Sprites[index].x - this.hScroll.nPos / 16;
        int num2 = (int) this.level.Sprites[index].y - this.vScroll.nPos / 16;
        if ((long) (uint) num1 < (long) (this.bmp.Width / 16) && (long) (uint) num2 < (long) (this.bmp.Height / 16))
          this.rerenderFlag[num1 + num2 * (this.bmp.Width / 16)] = true;
      }
    }

    private void SetRerenderFlagSpriteBefore(bool initialize, int updateID)
    {
      int num1 = this.hScroll.nPos / 16;
      int num2 = this.vScroll.nPos / 16;
      for (int index1 = 0; index1 < this.bmp.Height / 16 && num2 < 128; ++num2)
      {
        int num3 = num1;
        for (int index2 = 0; index2 < this.bmp.Width / 16 && num3 < 256; ++num3)
        {
          if (initialize)
          {
            this.rerenderFlag[index2 + index1 * (this.bmp.Width / 16)] = false;
          }
          else
          {
            int num4 = this.rerenderFlag[index2 + index1 * (this.bmp.Width / 16)] ? 1 : 0;
          }
          ++index2;
        }
        ++index1;
      }
      for (int index = updateID; index < this.level.Sprites.Count; ++index)
      {
        int num3 = (int) this.level.Sprites[index].x - this.hScroll.nPos / 16;
        int num4 = (int) this.level.Sprites[index].y - this.vScroll.nPos / 16;
        if ((long) (uint) num3 < (long) (this.bmp.Width / 16) && (long) (uint) num4 < (long) (this.bmp.Height / 16))
          this.rerenderFlag[num3 + num4 * (this.bmp.Width / 16)] = true;
      }
    }

    private void SetRerenderFlagSpriteAfter(int updateID)
    {
      for (int index = updateID; index < this.level.Sprites.Count; ++index)
      {
        int num1 = (int) this.level.Sprites[index].x - this.hScroll.nPos / 16;
        int num2 = (int) this.level.Sprites[index].y - this.vScroll.nPos / 16;
        if ((long) (uint) num1 < (long) (this.bmp.Width / 16) && (long) (uint) num2 < (long) (this.bmp.Height / 16))
          this.rerenderFlag[num1 + num2 * (this.bmp.Width / 16)] = true;
      }
    }

    private void SetRerenderFlagSpriteSelecting(SortedSet<int> newSet)
    {
      int num1 = this.hScroll.nPos / 16;
      int num2 = this.vScroll.nPos / 16;
      for (int index1 = 0; index1 < this.bmp.Height / 16 && num2 < 128; ++num2)
      {
        int num3 = num1;
        for (int index2 = 0; index2 < this.bmp.Width / 16 && num3 < 256; ++num3)
        {
          this.rerenderFlag[index2 + index1 * (this.bmp.Width / 16)] = false;
          Level.LevelTileList levelTileList = this.level.Tiles[num2 & 240 | num3 >> 4][(int) (byte) (num2 << 4) | num3 & 15];
          Level.LevelCommandList levelCommandList = this.level.CommandTiles[num3 | num2 * 256];
          for (int index3 = levelTileList.Count - 1; index3 >= 0; --index3)
          {
            if (newSet.Contains(levelTileList[index3].id) ^ this.selectedID.Contains(levelTileList[index3].id))
            {
              this.rerenderFlag[index2 + index1 * (this.bmp.Width / 16)] = true;
              goto label_13;
            }
          }
          for (int index3 = levelCommandList.Count - 1; index3 >= 0; --index3)
          {
            if (newSet.Contains(levelCommandList[index3]) ^ this.selectedID.Contains(levelCommandList[index3]))
            {
              this.rerenderFlag[index2 + index1 * (this.bmp.Width / 16)] = true;
              break;
            }
          }
label_13:
          ++index2;
        }
        ++index1;
      }
    }

    private bool SelectSprite(bool onClick)
    {
      SortedSet<int> sortedSet = new SortedSet<int>((IEnumerable<int>) this.selectedIDbackup);
      for (int id = this.level.Sprites.Count - 1; id >= 0; --id)
      {
        if (this.CheckSpriteCollision(ref this.selectionRect, id))
        {
          if (this.keyState.HasFlag((Enum) Keys.Control))
          {
            if (this.keyState.HasFlag((Enum) Keys.Alt) && this.selectedIDbackup.Contains(id))
              sortedSet.Remove(id);
            else if (!sortedSet.Contains(id))
              sortedSet.Add(id);
          }
          else if (this.keyState.HasFlag((Enum) Keys.Alt))
            sortedSet.Remove(id);
          else if (!sortedSet.Contains(id))
            sortedSet.Add(id);
          if (onClick)
          {
            this.editType = LevelTab.EditType.Move;
            this.Cursor = Cursors.SizeAll;
            break;
          }
        }
      }
      this.selectedID = sortedSet;
      
      this.SetRerenderFlagSprite(0);
      this.RenderLevel(this.bmp, this.rerenderFlag, 0, 0, this.bmp.Width, this.bmp.Height);
      Win32.InvalidateRect(this.Handle, (IntPtr) null, false);
      return this.selectedID.Count != 0;
    }

    private bool UnselectSprite()
    {
      if (this.selectedID.Count == 0)
        return false;
      this.selectedID.Clear();
      this.SetRerenderFlagSprite(0);
      this.RenderLevel(this.bmp, this.rerenderFlag, 0, 0, this.bmp.Width, this.bmp.Height);
      Win32.InvalidateRect(this.Handle, (IntPtr) null, false);
      return true;
    }

    private Cursor FocusOnSprite(Point mouse)
    {
      if ((uint) mouse.X >= 4096U || (uint) mouse.Y >= 2048U)
      {
        this.toolTip.SetToolTip((Control) this, (string) null);
        this.editType = LevelTab.EditType.Null;
        return Cursors.Default;
      }
      else
      {
        int index = -1;
        for (int id = this.level.Sprites.Count - 1; id >= 0; --id)
        {
          if (this.CheckSpriteCollision(ref mouse, id))
          {
            index = id;
            break;
          }
        }
        if (index != (int) this.toolTip.Tag)
        {
          this.toolTip.Tag =  index;
          if (index == -1)
            this.toolTip.SetToolTip((Control) this, (string) null);
          else
            this.toolTip.SetToolTip((Control) this, string.Format("Sprite {0:X3}\n{1}",  this.level.Sprites[index].num,  Level.SpriteInformation.Description[(int) this.level.Sprites[index].num]));
        }
        if (this.selectedID.Count == 0)
        {
          this.editType = LevelTab.EditType.Null;
          return Cursors.Default;
        }
        else if (this.selectedID.Contains(index))
        {
          this.editType = LevelTab.EditType.Move;
          return Cursors.SizeAll;
        }
        else
        {
          this.editType = LevelTab.EditType.Null;
          return Cursors.Default;
        }
      }
    }

    private void AddSprite(SortedSet<int> IDs, Level.Sprite spr)
    {
      this.SetRerenderFlagSprite(0);
      if (this.editMode == LevelTab.EditMode.Sprite)
        this.selectedID.Clear();
      if (IDs == this.selectedID)
      {
        this.selectedID.Add(this.level.Sprites.Count);
        this.undoBuffer.Push((LevelTab.ICommand) new LevelTab.EditCommand(this, IDs,  spr, LevelTab.EditCommand.Type.AddSprite, 0, 0));
        this.redoBuffer.Clear();
        this.levelEditor.EnableUndoRedo();
      }
      else if (this.editMode == LevelTab.EditMode.Sprite)
        this.selectedID.Add(this.level.Sprites.Count);
      this.level.Sprites.Add(spr);
      this.SetRerenderFlagSprite(0);
      this.RenderLevel(this.bmp, this.rerenderFlag, 0, 0, this.bmp.Width, this.bmp.Height);
      this.levelEditor.miniMapViewer.UpdateInformation();
      Win32.InvalidateRect(this.Handle, (IntPtr) null, false);
      Win32.UpdateWindow(this.Handle);
    }

    private void AddSprite(SortedSet<int> IDs, Level.Sprite[] sprs)
    {
      this.SetRerenderFlagSprite(0);
      if (this.editMode == LevelTab.EditMode.Sprite)
        this.selectedID.Clear();
      if (this.editMode == LevelTab.EditMode.Sprite)
        this.selectedID = new SortedSet<int>((IEnumerable<int>) IDs);
      foreach (Level.Sprite sprite in sprs)
        this.level.Sprites.Add(sprite);
      this.SetRerenderFlagSprite(0);
      this.RenderLevel(this.bmp, this.rerenderFlag, 0, 0, this.bmp.Width, this.bmp.Height);
      this.levelEditor.miniMapViewer.UpdateInformation();
      Win32.InvalidateRect(this.Handle, (IntPtr) null, false);
      Win32.UpdateWindow(this.Handle);
    }

    private void CopySprite(int x, int y)
    {
      if (this.selectedID.Count == 0 || (uint) x >= 256U || (uint) y >= 128U)
        return;
      int num1 = 256;
      int num2 = -1;
      int num3 = 128;
      int num4 = -1;
      int num5;
      int index1 = num5 = -1;
      int index2 = num5;
      int index3 = num5;
      int index4 = num5;
      foreach (int index5 in this.selectedID)
      {
        if ((int) this.level.Sprites[index5].x < num1)
        {
          num1 = (int) this.level.Sprites[index5].x;
          index4 = index5;
        }
        if ((int) this.level.Sprites[index5].x > num2)
        {
          num2 = (int) this.level.Sprites[index5].x;
          index3 = index5;
        }
        if ((int) this.level.Sprites[index5].y < num3)
        {
          num3 = (int) this.level.Sprites[index5].y;
          index2 = index5;
        }
        if ((int) this.level.Sprites[index5].y > num4)
        {
          num4 = (int) this.level.Sprites[index5].y;
          index1 = index5;
        }
      }
      int num6 = x - (int) this.level.Sprites[index4].x;
      int num7 = y - (int) this.level.Sprites[index2].y;
      if (num6 > 0 && (int) this.level.Sprites[index3].x + num6 >= 256)
        num6 = (int) byte.MaxValue - (int) this.level.Sprites[index3].x;
      if (num7 > 0 && (int) this.level.Sprites[index1].y + num7 >= 128)
        num7 = (int) sbyte.MaxValue - (int) this.level.Sprites[index1].y;
      int count = this.level.Sprites.Count;
      foreach (int index5 in this.selectedID)
      {
        Level.Sprite sprite = this.level.Sprites[index5];
        sprite.x += (byte) num6;
        sprite.y += (byte) num7;
        this.level.Sprites.Add(sprite);
      }
      this.selectedID.Clear();
      int num8 = count;
      while (num8 < this.level.Sprites.Count)
        this.selectedID.Add(num8++);
      this.SetRerenderFlagSprite(0);
      this.RenderLevel(this.bmp, this.rerenderFlag, 0, 0, this.bmp.Width, this.bmp.Height);
      this.levelEditor.miniMapViewer.UpdateInformation();
      Win32.InvalidateRect(this.Handle, (IntPtr) null, false);
      Win32.UpdateWindow(this.Handle);
    }

    private uint MoveSprite(SortedSet<int> IDs, Keys key, int dx, int dy)
    {
      if (IDs == this.selectedID && (IDs.Count == 0 || dx == 0 && dy == 0))
        return 0U;
      foreach (int index in IDs)
      {
        if (dx > 0 && (int) this.level.Sprites[index].x + dx >= 256)
          dx = (int) byte.MaxValue - (int) this.level.Sprites[index].x;
        else if (dx < 0 && (int) this.level.Sprites[index].x + dx < 0)
          dx = (int) -this.level.Sprites[index].x;
        if (dy > 0 && (int) this.level.Sprites[index].y + dy >= 128)
          dy = (int) sbyte.MaxValue - (int) this.level.Sprites[index].y;
        else if (dy < 0 && (int) this.level.Sprites[index].y + dy < 0)
          dy = (int) -this.level.Sprites[index].y;
      }
      if (IDs == this.selectedID && dx == 0 && dy == 0)
        return 0U;
      this.SetRerenderFlagSprite(0);
      int num1 = 0;
      SortedSet<int> sortedSet = new SortedSet<int>();
      foreach (int num2 in IDs)
      {
        Level.Sprite sprite = this.level.Sprites[num2 - num1];
        this.level.Sprites.RemoveAt(num2 - num1++);
        sprite.x += (byte) dx;
        sprite.y += (byte) dy;
        this.level.Sprites.Add(sprite);
      }
      Enumerable.First<int>((IEnumerable<int>) IDs);
      for (; num1 != 0; --num1)
        sortedSet.Add(this.level.Sprites.Count - num1);
      if (this.editMode == LevelTab.EditMode.Sprite)
        this.selectedID = sortedSet;
      this.SetRerenderFlagSprite(0);
      this.RenderLevel(this.bmp, this.rerenderFlag, 0, 0, this.bmp.Width, this.bmp.Height);
      this.levelEditor.miniMapViewer.UpdateInformation();
      Win32.InvalidateRect(this.Handle, (IntPtr) null, false);
      Win32.UpdateWindow(this.Handle);
      return (uint) (ushort) dy << 16 | (uint) (ushort) dx;
    }

    public void UndoMoveSprite(SortedSet<int> IDs, Level.Sprite[] objs)
    {
      Enumerable.First<int>((IEnumerable<int>) IDs);
      this.SetRerenderFlagSprite(0);
      this.level.Sprites.RemoveRange(this.level.Sprites.Count - IDs.Count, IDs.Count);
      for (int index = 0; index < objs.Length; ++index)
        this.level.Sprites.Insert(Enumerable.ElementAt<int>((IEnumerable<int>) IDs, index), objs[index]);
      if (this.editMode == LevelTab.EditMode.Sprite)
        this.selectedID = new SortedSet<int>((IEnumerable<int>) IDs);
      this.SetRerenderFlagSprite(0);
      this.RenderLevel(this.bmp, this.rerenderFlag, 0, 0, this.bmp.Width, this.bmp.Height);
      this.levelEditor.miniMapViewer.UpdateInformation();
      Win32.InvalidateRect(this.Handle, (IntPtr) null, false);
      
    }

    private void DeleteSprite(SortedSet<int> IDs)
    {
      if (IDs.Count == 0)
        return;
      this.SetRerenderFlagSprite(0);
      Enumerable.First<int>((IEnumerable<int>) IDs);
      int index = 0;
      Level.Sprite[] spriteArray = (Level.Sprite[]) null;
      if (IDs == this.selectedID)
        spriteArray = new Level.Sprite[IDs.Count];
      foreach (int num in IDs)
      {
        if (spriteArray != null)
          spriteArray[index] = this.level.Sprites[num - index];
        this.level.Sprites.RemoveAt(num - index++);
      }
      this.SetRerenderFlagSprite(Enumerable.First<int>((IEnumerable<int>) IDs));
      if (IDs == this.selectedID)
      {
        this.undoBuffer.Push((LevelTab.ICommand) new LevelTab.EditCommand(this, IDs,  spriteArray, LevelTab.EditCommand.Type.DeleteSprite, 0, 0));
        this.redoBuffer.Clear();
        this.levelEditor.EnableUndoRedo();
      }
      if (this.editMode == LevelTab.EditMode.Sprite)
        this.selectedID.Clear();
      this.editType = LevelTab.EditType.Null;
      this.Cursor = Cursors.Default;
      this.RenderLevel(this.bmp, this.rerenderFlag, 0, 0, this.bmp.Width, this.bmp.Height);
      this.levelEditor.miniMapViewer.UpdateInformation();
      Win32.InvalidateRect(this.Handle, (IntPtr) null, false);
      Win32.UpdateWindow(this.Handle);
    }

    public void InsertSprite(SortedSet<int> IDs, Level.Sprite[] objs)
    {
      this.SetRerenderFlagSprite(0);
      int index1 = 0;
      foreach (int index2 in IDs)
      {
        this.level.Sprites.Insert(index2, objs[index1]);
        ++index1;
      }
      if (this.editMode == LevelTab.EditMode.Sprite)
        this.selectedID = new SortedSet<int>((IEnumerable<int>) IDs);
      this.SetRerenderFlagSprite(0);
      this.RenderLevel(this.bmp, this.rerenderFlag, 0, 0, this.bmp.Width, this.bmp.Height);
      this.levelEditor.miniMapViewer.UpdateInformation();
      Win32.InvalidateRect(this.Handle, (IntPtr) null, false);
      Win32.UpdateWindow(this.Handle);
      
    }

    private bool CheckSpriteCollision(ref Rectangle rectangle, int id)
    {
      Rectangle rectangle1 = new Rectangle((int) this.level.Sprites[id].x * 16, (int) this.level.Sprites[id].y * 16, 15, 15);
      return rectangle.Right >= rectangle1.Left && rectangle1.Right >= rectangle.Left && (rectangle1.Bottom >= rectangle.Top && rectangle.Bottom >= rectangle1.Top);
    }

    private bool CheckSpriteCollision(ref Point point, int id)
    {
      Rectangle rectangle = new Rectangle((int) this.level.Sprites[id].x * 16, (int) this.level.Sprites[id].y * 16, 16, 16);
      if ((long) (uint) (point.X - rectangle.Left) < (long) rectangle.Width)
        return (long) (uint) (point.Y - rectangle.Top) < (long) rectangle.Height;
      else
        return false;
    }

    private delegate bool DoSelect(bool onClick);

    public delegate bool DoUnselect();

    private delegate Cursor DoFocusOn(Point mouse);

    private delegate void DoCopy(int x, int y);

    private delegate uint DoMove(SortedSet<int> IDs, Keys key, int dx, int dy);

    public delegate void DoDelete(SortedSet<int> IDs);

    private delegate void Render8x8Tile(Library.Bitmap b, int dstx, int dsty, byte[,] chr, uint[] pal, ushort tile_info, LevelTab.RenderFlag f);

    [Flags]
    public enum View : uint
    {
      Objects = 1U,
      Sprites = 2U,
      ScreenBoundaries = 4U,
      Grid = 8U,
      CheckeredBackground = 16U,
      All = CheckeredBackground | Grid | ScreenBoundaries | Sprites | Objects,
    }

    public enum EditMode : uint
    {
      Object,
      Sprite,
    }

    [Flags]
    private enum EditType : uint
    {
      Null = 0U,
      SizeHorz = 1U,
      SizeVert = 2U,
      SizeBoth = SizeVert | SizeHorz,
      Move = 4U,
      Copy = 8U,
    }

    public interface ICommand
    {
      void Redo();

      void Undo();
    }

    private class EditCommand : LevelTab.ICommand
    {
      private LevelTab target;
      private LevelTab.EditCommand.Type type;
      private SortedSet<int> IDs;
      private object obj;
      private int dx;
      private int dy;

      public EditCommand(LevelTab target, SortedSet<int> IDs, object obj, LevelTab.EditCommand.Type type, int dx, int dy)
      {
        this.target = target;
        this.IDs = new SortedSet<int>((IEnumerable<int>) IDs);
        this.obj = obj;
        this.type = type;
        this.dx = dx;
        this.dy = dy;
      }

      public void Undo()
      {
        switch (this.type)
        {
          case LevelTab.EditCommand.Type.AddObject:
            this.target.DeleteObject(this.IDs);
            break;
          case LevelTab.EditCommand.Type.CopyObject:
            this.target.DeleteObject(this.IDs);
            break;
          case LevelTab.EditCommand.Type.MoveObject:
            this.target.RestoreMovedObject(this.IDs, (Level.Object[]) this.obj);
            break;
          case LevelTab.EditCommand.Type.MoveObjectToFront:
            this.target.UndoMoveObject(this.IDs, (Level.Object[]) this.obj);
            break;
          case LevelTab.EditCommand.Type.SizeObject:
          case LevelTab.EditCommand.Type.SizeObjectMouse:
            this.target.RestoreObject(this.IDs, (Level.Object[]) this.obj);
            break;
          case LevelTab.EditCommand.Type.IncreaseZOrderObject:
            this.target.UndoIncreaseZOrder(this.IDs, (int[]) this.obj);
            break;
          case LevelTab.EditCommand.Type.DecreaseZOrderObject:
            this.target.UndoDecreaseZOrder(this.IDs, (int[]) this.obj);
            break;
          case LevelTab.EditCommand.Type.DeleteObject:
            this.target.InsertObject(this.IDs, (Level.Object[]) this.obj);
            break;
          case LevelTab.EditCommand.Type.AddSprite:
            this.target.DeleteSprite(this.IDs);
            break;
          case LevelTab.EditCommand.Type.CopySprite:
            this.target.DeleteSprite(this.IDs);
            break;
          case LevelTab.EditCommand.Type.MoveSprite:
            this.target.UndoMoveSprite(this.IDs, (Level.Sprite[]) this.obj);
            break;
          case LevelTab.EditCommand.Type.DeleteSprite:
            this.target.InsertSprite(this.IDs, (Level.Sprite[]) this.obj);
            break;
        }
        this.FinalizeCommand(false);
      }

      public void Redo()
      {
        switch (this.type)
        {
          case LevelTab.EditCommand.Type.AddObject:
            this.target.AddObject(this.IDs, (Level.Object) this.obj);
            break;
          case LevelTab.EditCommand.Type.CopyObject:
            this.target.AddObject(this.IDs, (Level.Object[]) this.obj);
            break;
          case LevelTab.EditCommand.Type.MoveObject:
            int num1 = (int) this.target.MoveObject(this.IDs, Keys.Control, this.dx, this.dy);
            break;
          case LevelTab.EditCommand.Type.MoveObjectToFront:
            int num2 = (int) this.target.MoveObject(this.IDs, Keys.None, this.dx, this.dy);
            break;
          case LevelTab.EditCommand.Type.SizeObject:
            this.target.SizeObject(this.IDs, (Level.Object[]) null, this.dx, this.dy);
            break;
          case LevelTab.EditCommand.Type.SizeObjectMouse:
            this.target.SizeObject(this.IDs, (Level.Object[]) this.obj, this.dx, this.dy);
            break;
          case LevelTab.EditCommand.Type.IncreaseZOrderObject:
            this.target.ChangeZOrder(this.IDs, false);
            break;
          case LevelTab.EditCommand.Type.DecreaseZOrderObject:
            this.target.ChangeZOrder(this.IDs, true);
            break;
          case LevelTab.EditCommand.Type.DeleteObject:
            this.target.DeleteObject(this.IDs);
            break;
          case LevelTab.EditCommand.Type.AddSprite:
            this.target.AddSprite(this.IDs, (Level.Sprite) this.obj);
            break;
          case LevelTab.EditCommand.Type.CopySprite:
            this.target.AddSprite(this.IDs, (Level.Sprite[]) this.obj);
            break;
          case LevelTab.EditCommand.Type.MoveSprite:
            int num3 = (int) this.target.MoveSprite(this.IDs, Keys.None, this.dx, this.dy);
            break;
          case LevelTab.EditCommand.Type.DeleteSprite:
            this.target.DeleteSprite(this.IDs);
            break;
        }
        this.FinalizeCommand(true);
      }

      private void FinalizeCommand(bool redo)
      {
        if (this.type < LevelTab.EditCommand.Type.AddSprite)
          this.target.levelEditor.EnableEditMenu(this.target.editMode == LevelTab.EditMode.Object && this.target.SelectedID.Count != 0, LevelTab.EditMode.Object);
        else
          this.target.levelEditor.EnableEditMenu(this.target.editMode == LevelTab.EditMode.Sprite && this.target.SelectedID.Count != 0, LevelTab.EditMode.Sprite);
      }

      public enum Type
      {
        AddObject,
        CopyObject,
        MoveObject,
        MoveObjectToFront,
        SizeObject,
        SizeObjectMouse,
        IncreaseZOrderObject,
        DecreaseZOrderObject,
        DeleteObject,
        AddSprite,
        CopySprite,
        MoveSprite,
        DeleteSprite,
      }
    }

    [Flags]
    private enum RenderFlag
    {
      Null = 0,
      InvertTransparent = 1,
      InvertOpaque = 2,
      Invert = InvertOpaque | InvertTransparent,
      RedTransparent = 4,
      RedOpaque = 8,
      Red = RedOpaque | RedTransparent,
      GreenTransparent = 16,
      GreenOpaque = 32,
      Green = GreenOpaque | GreenTransparent,
      BlueTransparent = 64,
      BlueOpaque = 128,
      Blue = BlueOpaque | BlueTransparent,
    }
  }
}
