
// Type: GE.Forms.MainForm

// MVID: 7AA6A484-F524-42F2-9571-0947D386B578
// Assembly location: C:\Documents and Settings\THE RAIN\Desktop\ge.exe

using GE.Forms.Dialogues.MainForm;
using Library;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace GE.Forms
{
  public class MainForm : Form
  {
    private IContainer components;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem fileToolStripMenuItem;
    private ToolStripMenuItem openROMToolStripMenuItem;
    private ToolStripMenuItem closeROMToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripMenuItem emulatorToolStripMenuItem;
    private ToolStripMenuItem runROMInEmulatorToolStripMenuItem;
    private ToolStripMenuItem setUpEmulatorPathToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripMenuItem exitToolStripMenuItem;
    private ToolStripMenuItem windowToolStripMenuItem;
    private ToolStripMenuItem levelEditorToolStripMenuItem;
    private string ROMpath;
    private SNES.ROMFile _YI;
    private LevelEditor _LevelEditor;
    private MainForm.Settings settings;
    private Win32.RECT settingWndRect;
    private bool settingMaximized;

    public LevelEditor LevelEditor
    {
      get
      {
        return this._LevelEditor;
      }
    }

    public SNES.ROMFile YI
    {
      get
      {
        return this._YI;
      }
    }

    public string ROMPath
    {
      get
      {
        return this.ROMpath;
      }
    }

    public string ROMName
    {
      get
      {
        int startIndex = Math.Max(this.ROMpath.LastIndexOf('/'), this.ROMpath.LastIndexOf('\\')) + 1;
        int num = this.ROMpath.LastIndexOf('.');
        if (startIndex >= num)
          return (string) null;
        else
          return this.ROMpath.Substring(startIndex, num - startIndex);
      }
    }

    public string ROMNameDirectory
    {
      get
      {
        int num = Math.Max(this.ROMpath.LastIndexOf('/'), this.ROMpath.LastIndexOf('\\')) + 1;
        int length = this.ROMpath.LastIndexOf('.');
        if (num >= length)
          return this.ROMName;
        else
          return this.ROMpath.Substring(0, length);
      }
    }

    public MainForm(string rom_path)
    {
      this.settings = this.LoadSettings();
      this.InitializeComponent();
      Win32.MoveWindow(this.Handle, this.settings.WndRect.left, this.settings.WndRect.top, this.settings.WndRect.Width, this.settings.WndRect.Height, false);
      if (rom_path != null)
        this.OpenTheROMFile(rom_path);
      if (!this.settings.Maximized)
        return;
      this.WindowState = FormWindowState.Maximized;
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (MainForm));
      this.menuStrip1 = new MenuStrip();
      this.fileToolStripMenuItem = new ToolStripMenuItem();
      this.openROMToolStripMenuItem = new ToolStripMenuItem();
      this.closeROMToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator1 = new ToolStripSeparator();
      this.emulatorToolStripMenuItem = new ToolStripMenuItem();
      this.runROMInEmulatorToolStripMenuItem = new ToolStripMenuItem();
      this.setUpEmulatorPathToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator2 = new ToolStripSeparator();
      this.exitToolStripMenuItem = new ToolStripMenuItem();
      this.windowToolStripMenuItem = new ToolStripMenuItem();
      this.levelEditorToolStripMenuItem = new ToolStripMenuItem();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      this.menuStrip1.Items.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.fileToolStripMenuItem,
        (ToolStripItem) this.windowToolStripMenuItem
      });
      this.menuStrip1.Location = new Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new Size(578, 24);
      this.menuStrip1.TabIndex = 1;
      this.menuStrip1.Text = "menuStrip1";
      this.fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[6]
      {
        (ToolStripItem) this.openROMToolStripMenuItem,
        (ToolStripItem) this.closeROMToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator1,
        (ToolStripItem) this.emulatorToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator2,
        (ToolStripItem) this.exitToolStripMenuItem
      });
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new Size(35, 20);
      this.fileToolStripMenuItem.Text = "&File";
      this.openROMToolStripMenuItem.Name = "openROMToolStripMenuItem";
      this.openROMToolStripMenuItem.ShortcutKeys = Keys.O | Keys.Shift | Keys.Control;
      this.openROMToolStripMenuItem.Size = new Size(196, 22);
      this.openROMToolStripMenuItem.Text = "&Open ROM";
      this.openROMToolStripMenuItem.Click += new EventHandler(this.openROMToolStripMenuItem_Click);
      this.closeROMToolStripMenuItem.Enabled = false;
      this.closeROMToolStripMenuItem.Name = "closeROMToolStripMenuItem";
      this.closeROMToolStripMenuItem.Size = new Size(196, 22);
      this.closeROMToolStripMenuItem.Text = "&Close ROM";
      this.closeROMToolStripMenuItem.Click += new EventHandler(this.closeROMToolStripMenuItem_Click);
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new Size(193, 6);
      this.emulatorToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.runROMInEmulatorToolStripMenuItem,
        (ToolStripItem) this.setUpEmulatorPathToolStripMenuItem
      });
      this.emulatorToolStripMenuItem.Enabled = false;
      this.emulatorToolStripMenuItem.Name = "emulatorToolStripMenuItem";
      this.emulatorToolStripMenuItem.Size = new Size(196, 22);
      this.emulatorToolStripMenuItem.Text = "&Emulator";
      this.runROMInEmulatorToolStripMenuItem.Enabled = false;
      this.runROMInEmulatorToolStripMenuItem.Name = "runROMInEmulatorToolStripMenuItem";
      this.runROMInEmulatorToolStripMenuItem.ShortcutKeys = Keys.F5;
      this.runROMInEmulatorToolStripMenuItem.Size = new Size(194, 22);
      this.runROMInEmulatorToolStripMenuItem.Text = "&Run ROM in Emulator";
      this.runROMInEmulatorToolStripMenuItem.Click += new EventHandler(this.runROMInEmulatorToolStripMenuItem_Click);
      this.setUpEmulatorPathToolStripMenuItem.Enabled = false;
      this.setUpEmulatorPathToolStripMenuItem.Name = "setUpEmulatorPathToolStripMenuItem";
      this.setUpEmulatorPathToolStripMenuItem.Size = new Size(194, 22);
      this.setUpEmulatorPathToolStripMenuItem.Text = "&Set up Emulator Path";
      this.setUpEmulatorPathToolStripMenuItem.Click += new EventHandler(this.setUpEmulatorPathToolStripMenuItem_Click);
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new Size(193, 6);
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.ShortcutKeyDisplayString = "Alt+F4";
      this.exitToolStripMenuItem.Size = new Size(196, 22);
      this.exitToolStripMenuItem.Text = "E&xit";
      this.exitToolStripMenuItem.Click += new EventHandler(this.exitToolStripMenuItem_Click);
      this.windowToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.levelEditorToolStripMenuItem
      });
      this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
      this.windowToolStripMenuItem.Size = new Size(57, 20);
      this.windowToolStripMenuItem.Text = "&Window";
      this.levelEditorToolStripMenuItem.Enabled = false;
      this.levelEditorToolStripMenuItem.Name = "levelEditorToolStripMenuItem";
      this.levelEditorToolStripMenuItem.ShortcutKeys = Keys.F1 | Keys.Control;
      this.levelEditorToolStripMenuItem.Size = new Size(174, 22);
      this.levelEditorToolStripMenuItem.Text = "Level Editor";
      this.levelEditorToolStripMenuItem.Click += new EventHandler(this.levelEditorToolStripMenuItem_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(578, 358);
      this.Controls.Add((Control) this.menuStrip1);
      this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.IsMdiContainer = true;
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "MainForm";
      this.StartPosition = FormStartPosition.Manual;
      this.Text = "Golden Egg";
      this.FormClosing += new FormClosingEventHandler(this.MainForm_FormClosing);
      this.FormClosed += new FormClosedEventHandler(this.MainForm_FormClosed);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public string ReadUserTextDefinition(string file_name)
    {
      if (this.ROMNameDirectory == null)
        return (string) null;
      try
      {
        return File.ReadAllText(this.ROMNameDirectory +  '\\' + file_name);
      }
      catch (Exception ex)
      {
          System.Diagnostics.Debug.WriteLine(ex.Message);
        return (string) ex.Message;
      }
    }

    private MainForm.Settings LoadSettings()
    {
      try
      {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof (MainForm.Settings));
        FileStream fileStream = new FileStream(Application.StartupPath + "\\ge.xml", FileMode.Open);
        MainForm.Settings settings = (MainForm.Settings) xmlSerializer.Deserialize((Stream) fileStream);
        fileStream.Close();
        return settings;
      }
      catch (Exception ex)
      {
          System.Diagnostics.Debug.WriteLine(ex.Message);
      }
      return new MainForm.Settings();
    }

    private void SaveSettings()
    {
      try
      {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof (MainForm.Settings));
        FileStream fileStream = new FileStream(Application.StartupPath + "\\ge.xml", FileMode.Create);
        xmlSerializer.Serialize((Stream) fileStream,  this.settings);
        fileStream.Close();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
    }

    private void EnableMenus(bool enableFlag)
    {
      this.openROMToolStripMenuItem.Enabled = !enableFlag;
      this.closeROMToolStripMenuItem.Enabled = this.emulatorToolStripMenuItem.Enabled = this.setUpEmulatorPathToolStripMenuItem.Enabled = this.levelEditorToolStripMenuItem.Enabled = enableFlag;
      this.runROMInEmulatorToolStripMenuItem.Enabled = enableFlag && this.settings.EmulatorPath != "";
    }

    private void EnableEditor(int id)
    {
      if (this.LevelEditor == null)
      {
        this._LevelEditor = new LevelEditor(this);
        this.LevelEditor.Show();
      }
      else
        this.LevelEditor.Show();
    }

    private void OpenTheROMFile(string path)
    {
      try
      {
        SNES.ROMFile romFile = new SNES.ROMFile();
        if (!romFile.Open(path))
          throw new Exception(romFile.GetLastError());
        if (romFile.Title != "YOSHI'S ISLAND")
          throw new Exception("The loaded ROM is not Yoshi's Island.");
        if ((int) (byte) romFile.ROM[32729] != 1)
          throw new Exception("The loaded ROM's country code is other than the North America version.");
        if ((int) (byte) romFile.ROM[32731] != 0)
          throw new Exception("The loaded ROM version is not 1.00");
        this._YI = romFile;
        this.ROMpath = path;
        this.EnableMenus(true);
        this.EnableEditor(0);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    private void openROMToolStripMenuItem_Click(object sender, EventArgs e)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Filter = "SNES ROM Images (*.sfc;*.smc)|*.sfc;*.smc|All Files (*.*)|*.*";
      if (openFileDialog.ShowDialog() != DialogResult.OK)
        return;
      this.OpenTheROMFile(openFileDialog.FileName);
    }

    private void closeROMToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this._YI = (SNES.ROMFile) null;
      this.EnableMenus(false);
      this._LevelEditor.OnROMClosed();
      this._LevelEditor = (LevelEditor) null;
    }

    private void setUpEmulatorPathToolStripMenuItem_Click(object sender, EventArgs e)
    {
      EmulatorPathSetter emulatorPathSetter = new EmulatorPathSetter(this.settings.EmulatorPath);
      if (emulatorPathSetter.ShowDialog() == DialogResult.OK)
      {
        this.settings.EmulatorPath = emulatorPathSetter.Path;
        this.runROMInEmulatorToolStripMenuItem.Enabled = this.settings.EmulatorPath != "";
      }
      emulatorPathSetter.Dispose();
    }

    private void runROMInEmulatorToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        Process.Start(this.settings.EmulatorPath, "\"" + this.ROMpath + "\"");
      }
      catch
      {
      }
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void levelEditorToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.EnableEditor(0);
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      this.Hide();
    }

    private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      if (!(this.settings.Maximized = this.settingMaximized))
        Win32.GetWindowRect(this.Handle, ref this.settings.WndRect);
      else
        this.settings.WndRect = this.settingWndRect;
      this.SaveSettings();
    }

    protected override void WndProc(ref Message m)
    {
      switch (m.Msg)
      {
        case 5:
          if ((int) m.WParam == 0)
          {
            this.settingMaximized = false;
            Win32.GetWindowRect(this.Handle, ref this.settingWndRect);
          }
          else if ((int) m.WParam == 2)
            this.settingMaximized = true;
          m.Result = (IntPtr) null;
          return;
        case 274:
          if ((int) m.WParam == 61472)
          {
            if (this.LevelEditor != null)
            {
              this.LevelEditor.OnMinimized();
            }
          }
          else if ((int) m.WParam == 61728 && this.LevelEditor != null)
          {
            this.LevelEditor.OnRestored();
          }
          break;
      }
      base.WndProc(ref m);
    }

    public class Settings
    {
      public string EmulatorPath = "";
      public Win32.RECT WndRect = new Win32.RECT(40, 40, 400, 400);
      public bool Maximized;
    }
  }
}
