
// Type: GE.Forms.LevelEditor

// MVID: 7AA6A484-F524-42F2-9571-0947D386B578
// Assembly location: C:\Documents and Settings\THE RAIN\Desktop\ge.exe

using GE;
using GE.Forms.Dialogues.LevelEditor;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace GE.Forms
{
  public class LevelEditor : Form
  {
    private ObjectSelector objectSelector = new ObjectSelector();
    public ScreenExitEditor screenExitEditor = new ScreenExitEditor();
    private HeaderEditor headerEditor = new HeaderEditor();
    public PaletteEditor paletteEditor = new PaletteEditor();
    public MiniMapViewer miniMapViewer = new MiniMapViewer();
    private string[] levelNameList = new string[222];
    private MainForm mainForm;
    private IContainer components;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem fileToolStripMenuItem;
    private ToolStripMenuItem openLevelFromFileToolStripMenuItem;
    private ToolStrip toolStrip1;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripButton toolNewLevel;
    private ToolStripButton toolSelectLevel;
    private ToolStripButton toolOpenLevelFile;
    private ToolStripButton toolSaveLevel;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripButton toolObjectEditMode;
    private ToolStripButton toolSpriteEditMode;
    private ToolStripSeparator toolStripSeparator3;
    private ToolStripButton toolObjSprSelector;
    private ToolStripSeparator toolStripSeparator4;
    private ToolStripMenuItem openLevelInROMToolStripMenuItem;
    private StatusStrip statusStrip1;
    private ToolStripStatusLabel sbCoordinates;
    private ToolStripStatusLabel sbTile;
    private ToolStripStatusLabel sbLabel;
    private ToolStripMenuItem editToolStripMenuItem;
    private ToolStripMenuItem objectEditModeToolStripMenuItem;
    private ToolStripMenuItem spriteEditModeToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator5;
    private ToolStripMenuItem deleteToolStripMenuItem;
    private ToolStripMenuItem unselectToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator6;
    private ToolStripMenuItem increaseWidthToolStripMenuItem;
    private ToolStripMenuItem decreaseWidthToolStripMenuItem;
    private ToolStripMenuItem increaseHeightToolStripMenuItem;
    private ToolStripMenuItem decreaseHeightToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator7;
    private ToolStripMenuItem increaseZOrderToolStripMenuItem;
    private ToolStripMenuItem decreaseZOrderToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator8;
    private ToolStripMenuItem closeLevelToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator9;
    private ToolStripMenuItem saveLevelInROMToolStripMenuItem;
    private ToolStripMenuItem saveLevelToFileToolStripMenuItem;
    private ToolStripMenuItem saveLevelToFileAsToolStripMenuItem;
    internal DockPanel dockPanel;
    private ToolStripButton toolScreenExitEditor;
    private ToolStripButton toolHeaderEditor;
    private ToolStripButton toolPaletteEditor;
    private ToolStripSeparator toolStripSeparator10;
    private ToolStripMenuItem viewToolStripMenuItem;
    private ToolStripMenuItem objectsToolStripMenuItem;
    private ToolStripMenuItem spritesToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator11;
    private ToolStripMenuItem checkeredBackgroundToolStripMenuItem;
    private ToolStripMenuItem screenBoundariesToolStripMenuItem;
    private ToolStripMenuItem undoToolStripMenuItem;
    private ToolStripMenuItem redoToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator12;
    private ToolStripButton toolUndo;
    private ToolStripButton toolRedo;
    private ToolStripSeparator toolStripSeparator13;
    private ToolStripButton toolMiniMapViewer;
    private ToolStripSeparator toolStripSeparator14;
    private ToolStripMenuItem levelToolStripMenuItem;
    private ToolStripMenuItem clearLevelDataToolStripMenuItem;
    private ToolStripMenuItem scanIlleganItemPlacementToolStripMenuItem;
    private ToolStripMenuItem tileGridToolStripMenuItem;
    private ToolStripMenuItem levelInformationToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator15;

    private LevelTab levelTab
    {
      get
      {
        return this.dockPanel.ActiveDocument as LevelTab;
      }
    }

    public string StatusBarLabel
    {
      set
      {
        this.sbLabel.Text = value;
      }
    }

    public LevelEditor(MainForm MainForm)
    {
      this.InitializeComponent();
      this.MdiParent = (Form) (this.mainForm = MainForm);
      this.WindowState = FormWindowState.Maximized;
      this.objectSelector.Show(this.dockPanel, DockState.DockLeft);
      this.screenExitEditor.DockPanel = this.headerEditor.DockPanel = this.paletteEditor.DockPanel = this.miniMapViewer.DockPanel = this.dockPanel;
      this.InitializeROM();
      this.LoadLevelNameList(GE.Properties.Resources.level_name_list);
      this.LoadLevelNameList(MainForm.ReadUserTextDefinition("level_name_list.txt"));
      this.LoadObjectInformation(GE.Properties.Resources.objects_info);
      this.objectSelector.UpdateListBox();
    }

    public void StatusBarMouseCoordinates(int x, int y)
    {
      if ((uint) x >= 4096U || (uint) y >= 2048U)
        return;
      x /= 16;
      y /= 16;
      this.sbCoordinates.Text = string.Format("X:{0:X2} Y:{1:X2}",  x,  y);
      Level.LevelTileList levelTileList = this.levelTab.Level.Tiles[y & 240 | x >> 4][(int) (byte) (y << 4 | x & 15)];
      this.sbTile.Text = levelTileList.Count != 0 ? levelTileList[0].tile.ToString("X4") : "0000";
    }

    private void InitializeROM()
    {
      for (int index = 0; index < 2; ++index)
      {
        if ((int) this.mainForm.YI.ROM[785631 + index * 6].u24 == 1441002 && (int) this.mainForm.YI.ROM[785631 + index * 6 + 3].u24 == 1441749)
        {
          this.mainForm.YI.ROM[785631 + index * 6].u24 = 0U;
          this.mainForm.YI.ROM[785631 + index * 6 + 3].u24 = 0U;
        }
      }
    }

    private void LoadLevelNameList(string contents)
    {
      if (contents == null)
        return;
      foreach (Match match in new Regex("^([0-9A-F]+)\\s+(.+)?$", RegexOptions.IgnoreCase | RegexOptions.Multiline).Matches(contents))
      {
        try
        {
          uint num = uint.Parse(match.Groups[1].Value, NumberStyles.AllowHexSpecifier);
          if (num <= 221U)
            this.levelNameList[num] = match.Groups[2].Value.TrimEnd();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
        }
      }
    }

    private void LoadObjectInformation(string contents)
    {
      if (contents == null)
        return;
      Regex regex1 = new Regex("(Ex|)([0-9A-F]+)\\{(.+?)}", RegexOptions.IgnoreCase | RegexOptions.Singleline);
      Regex regex2 = new Regex("^\\s*label:\\s*(.+)$", RegexOptions.Multiline);
      Regex regex3 = new Regex("^\\s*desc:\\s*(.+)$", RegexOptions.Multiline);
      Regex regex4 = new Regex("^\\s*filter:\\s*(.+)$", RegexOptions.Multiline);
      foreach (Match match1 in regex1.Matches(contents))
      {
        try
        {
          uint num1 = uint.Parse(match1.Groups[2].Value, NumberStyles.AllowHexSpecifier);
          if (match1.Groups[1].Value == "")
          {
            uint num2;
            if ((num2 = num1 - 1U) < 246U)
            {
              Match match2 = regex2.Match(match1.Groups[3].Value);
              if (match2.Success)
                Level.ObjectInformation.Label[num2] = string.Format("{0:X2}\t\t{1}",  (uint) ((int) num2 + 1),  match2.Groups[1].Value.TrimEnd());
              Match match3 = regex3.Match(match1.Groups[3].Value);
              if (match3.Success)
                Level.ObjectInformation.Description[num2] = match3.Groups[1].Value.TrimEnd();
              Match match4 = regex4.Match(match1.Groups[3].Value);
              if (match4.Success)
                Level.ObjectInformation.Filter[num2] |= this.GetFilterValue(match4.Groups[1].Value.Insert(0, ",").ToLower());
            }
          }
          else if (num1 < 256U)
          {
            Match match2 = regex2.Match(match1.Groups[3].Value);
            if (match2.Success)
              Level.ExObjectInformation.Label[num1] = string.Format("{0:X2}\tEx\t{1}",  num1,  match2.Groups[1].Value.TrimEnd());
            Match match3 = regex3.Match(match1.Groups[3].Value);
            if (match3.Success)
              Level.ExObjectInformation.Description[num1] = match3.Groups[1].Value.TrimEnd();
            Match match4 = regex4.Match(match1.Groups[3].Value);
            if (match4.Success)
              Level.ExObjectInformation.Filter[num1] |= this.GetFilterValue(match4.Groups[1].Value.Insert(0, ",").ToLower());
          }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
        }
      }
    }

    private Level.ObjectFilter GetFilterValue(string filter)
    {
      Regex regex = new Regex("\\s*,\\s*([^\\s,]+)\\s*");
      Level.ObjectFilter objectFilter = (Level.ObjectFilter) 0;
      foreach (Match match in regex.Matches(filter))
      {
        switch (match.Groups[1].Value.ToLower())
        {
          case "cave1":
            objectFilter |= Level.ObjectFilter.CAVE1;
            continue;
          case "forest1":
            objectFilter |= Level.ObjectFilter.FOREST1;
            continue;
          case "pond":
            objectFilter |= Level.ObjectFilter.POND;
            continue;
          case "3d":
            objectFilter |= Level.ObjectFilter.THREE_D;
            continue;
          case "snow":
            objectFilter |= Level.ObjectFilter.SNOW;
            continue;
          case "jungle":
            objectFilter |= Level.ObjectFilter.JUNGLE;
            continue;
          case "castle1":
            objectFilter |= Level.ObjectFilter.CASTLE1;
            continue;
          case "grass1":
            objectFilter |= Level.ObjectFilter.GRASS1;
            continue;
          case "cave2":
            objectFilter |= Level.ObjectFilter.CAVE2;
            continue;
          case "forest2":
            objectFilter |= Level.ObjectFilter.FOREST2;
            continue;
          case "castle2":
            objectFilter |= Level.ObjectFilter.CASTLE2;
            continue;
          case "sewer":
            objectFilter |= Level.ObjectFilter.SEWER;
            continue;
          case "flower":
            objectFilter |= Level.ObjectFilter.FLOWER;
            continue;
          case "sky":
            objectFilter |= Level.ObjectFilter.SKY;
            continue;
          case "castle3":
            objectFilter |= Level.ObjectFilter.CASTLE3;
            continue;
          case "grass2":
            objectFilter |= Level.ObjectFilter.GRASS2;
            continue;
          case "kamek":
            objectFilter |= Level.ObjectFilter.KAMEK;
            continue;
          case "animated":
            objectFilter |= Level.ObjectFilter.ANIMATED;
            continue;
          case "misc":
            objectFilter |= Level.ObjectFilter.MISC;
            continue;
          default:
            continue;
        }
      }
      return objectFilter;
    }

    public void OnROMClosed()
    {
      while (this.levelTab != null)
        this.closeLevelToolStripMenuItem.PerformClick();
      this.Close();
    }

    private void toolSelectLevel_Click(object sender, EventArgs e)
    {
      this.SelectLevel();
    }

    private void SelectLevel()
    {
      using (LevelSelector levelSelector = new LevelSelector(this.levelNameList))
      {
        if (levelSelector.ShowDialog((IWin32Window) this) != DialogResult.OK)
          return;
        new LevelTab(this.mainForm, (byte) levelSelector.LevelNumber).Show(this.dockPanel, DockState.Document);
        this.OnLevelTabOpen();
      }
    }

    private void OnLevelTabOpen()
    {
      if (!this.objectEditModeToolStripMenuItem.Checked)
        this.SetEditMode(false);
      if (this.dockPanel.DocumentsCount != 1)
        return;
      this.EnableFileMenu(true);
      this.objectSelector.Enabled = this.screenExitEditor.Enabled = this.headerEditor.Enabled = this.paletteEditor.Enabled = this.miniMapViewer.Enabled = true;
    }

    public void OnLevelTabClose()
    {
      if (this.dockPanel.DocumentsCount != 1)
        return;
      this.EnableFileMenu(false);
      this.objectSelector.Enabled = this.screenExitEditor.Enabled = this.headerEditor.Enabled = this.paletteEditor.Enabled = this.miniMapViewer.Enabled = false;
      this.undoToolStripMenuItem.Enabled = this.redoToolStripMenuItem.Enabled = this.toolUndo.Enabled = this.toolRedo.Enabled = false;
      this.saveLevelInROMToolStripMenuItem.Enabled = this.toolSaveLevel.Enabled = false;
    }

    private void dockPanel_ActiveDocumentChanged(object sender, EventArgs e)
    {
      if (this.dockPanel.ActiveDocument == null)
        return;
      this.SetEditMode(this.levelTab.editMode == LevelTab.EditMode.Sprite);
      this.objectsToolStripMenuItem.Checked = (this.levelTab.view & LevelTab.View.Objects) != (LevelTab.View) 0;
      this.spritesToolStripMenuItem.Checked = (this.levelTab.view & LevelTab.View.Sprites) != (LevelTab.View) 0;
      this.screenBoundariesToolStripMenuItem.Checked = (this.levelTab.view & LevelTab.View.ScreenBoundaries) != (LevelTab.View) 0;
      this.tileGridToolStripMenuItem.Checked = (this.levelTab.view & LevelTab.View.Grid) != (LevelTab.View) 0;
      this.checkeredBackgroundToolStripMenuItem.Checked = (this.levelTab.view & LevelTab.View.CheckeredBackground) != (LevelTab.View) 0;
      this.StatusBarLabel = this.levelTab.StatusBarLabel;
      this.EnableUndoRedo();
      this.screenExitEditor.OnLevelTabChanged();
      this.headerEditor.OnLevelTabChanged();
      this.paletteEditor.OnLevelTabChanged();
      this.miniMapViewer.OnLevelTabChanged();
    }

    private void EnableFileMenu(bool enable)
    {
      this.closeLevelToolStripMenuItem.Enabled = this.saveLevelToFileToolStripMenuItem.Enabled = this.saveLevelToFileAsToolStripMenuItem.Enabled = this.objectEditModeToolStripMenuItem.Enabled = this.spriteEditModeToolStripMenuItem.Enabled = this.toolObjectEditMode.Enabled = this.toolSpriteEditMode.Enabled = this.levelInformationToolStripMenuItem.Enabled = this.clearLevelDataToolStripMenuItem.Enabled = this.scanIlleganItemPlacementToolStripMenuItem.Enabled = this.objectsToolStripMenuItem.Enabled = this.spritesToolStripMenuItem.Enabled = this.checkeredBackgroundToolStripMenuItem.Enabled = this.tileGridToolStripMenuItem.Enabled = this.screenBoundariesToolStripMenuItem.Enabled = enable;
    }

    public void EnableEditMenu(bool enable, LevelTab.EditMode editMode)
    {
      this.deleteToolStripMenuItem.Enabled = this.unselectToolStripMenuItem.Enabled = enable;
      if (editMode != LevelTab.EditMode.Object)
        return;
      this.increaseWidthToolStripMenuItem.Enabled = this.decreaseWidthToolStripMenuItem.Enabled = this.increaseHeightToolStripMenuItem.Enabled = this.decreaseHeightToolStripMenuItem.Enabled = this.increaseZOrderToolStripMenuItem.Enabled = this.decreaseZOrderToolStripMenuItem.Enabled = enable;
    }

    public new void Hide()
    {
      base.Hide();
      foreach (Control control in (ReadOnlyCollection<FloatWindow>) this.dockPanel.FloatWindows)
        control.Hide();
    }

    public new void Show()
    {
      ((Control) this).Show();
      foreach (FloatWindow floatWindow in (ReadOnlyCollection<FloatWindow>)this.dockPanel.FloatWindows)
      {
          floatWindow.Show();
          floatWindow.Update();
      }
    }

    private void toolObjSprSelector_Click(object sender, EventArgs e)
    {
      if (this.toolObjSprSelector.Checked = !this.toolObjSprSelector.Checked)
        this.objectSelector.Show();
      else
        this.objectSelector.Hide();
    }

    public void CheckObjSprSelector(bool check)
    {
      this.toolObjSprSelector.Checked = check;
    }

    private void toolScreenExitEditor_Click(object sender, EventArgs e)
    {
      if (this.toolScreenExitEditor.Checked = !this.toolScreenExitEditor.Checked)
        this.screenExitEditor.Show();
      else
        this.screenExitEditor.Hide();
    }

    public void CheckScreenExitEditor(bool check)
    {
      this.toolScreenExitEditor.Checked = check;
    }

    private void toolHeaderEditor_Click(object sender, EventArgs e)
    {
      if (this.toolHeaderEditor.Checked = !this.toolHeaderEditor.Checked)
        this.headerEditor.Show();
      else
        this.headerEditor.Hide();
    }

    public void CheckHeaderEditor(bool check)
    {
      this.toolHeaderEditor.Checked = check;
    }

    private void toolPaletteEditor_Click(object sender, EventArgs e)
    {
      if (this.toolPaletteEditor.Checked = !this.toolPaletteEditor.Checked)
        this.paletteEditor.Show();
      else
        this.paletteEditor.Hide();
    }

    public void CheckPaletteEditor(bool check)
    {
      this.toolPaletteEditor.Checked = check;
    }

    private void toolMiniMapViewer_Click(object sender, EventArgs e)
    {
      if (this.toolMiniMapViewer.Checked = !this.toolMiniMapViewer.Checked)
        this.miniMapViewer.Show();
      else
        this.miniMapViewer.Hide();
    }

    public void CheckMiniMapViewer(bool check)
    {
      this.toolMiniMapViewer.Checked = check;
    }

    private void openLevelInROMToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.SelectLevel();
    }

    public void OnRestored()
    {
      foreach (FloatWindow floatWindow in (ReadOnlyCollection<FloatWindow>) this.dockPanel.FloatWindows)
      {
        floatWindow.Show();
        floatWindow.Update();
      }
    }

    public void OnMinimized()
    {
      foreach (Control control in (ReadOnlyCollection<FloatWindow>) this.dockPanel.FloatWindows)
        control.Hide();
    }

    private void unselectToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = this.levelTab.doUnselect() ? 1 : 0;
      this.levelTab.StatusBarLabel = this.levelTab.editMode == LevelTab.EditMode.Object ? "Unselected object(s)." : "Unselected sprite(s).";
      this.EnableEditMenu(false, this.levelTab.editMode);
    }

    private void increaseWidthToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.levelTab.SizeObject(this.levelTab.SelectedID, (Level.Object[]) null, 1, 0))
        this.levelTab.StatusBarLabel = "Increased width by one.";
      else
        this.levelTab.StatusBarLabel = "Cannot increase width any farther.";
    }

    private void decreaseWidthToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.levelTab.SizeObject(this.levelTab.SelectedID, (Level.Object[]) null, -1, 0))
        this.levelTab.StatusBarLabel = "Decreased width by one.";
      else
        this.levelTab.StatusBarLabel = "Cannot decrease width any farther.";
    }

    private void increaseHeightToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.levelTab.SizeObject(this.levelTab.SelectedID, (Level.Object[]) null, 0, 1))
        this.levelTab.StatusBarLabel = "Increased height by one.";
      else
        this.levelTab.StatusBarLabel = "Cannot increase height any farther.";
    }

    private void decreaseHeightToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.levelTab.SizeObject(this.levelTab.SelectedID, (Level.Object[]) null, 0, -1))
        this.levelTab.StatusBarLabel = "Decreased height by one.";
      else
        this.levelTab.StatusBarLabel = "Cannot decrease height any farther.";
    }

    private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.levelTab.doDelete(this.levelTab.SelectedID);
      this.levelTab.StatusBarLabel = this.levelTab.editMode == LevelTab.EditMode.Object ? "Deleted object(s)." : "Deleted sprite(s).";
      this.EnableEditMenu(false, this.levelTab.editMode);
    }

    private void increaseZOrderToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.levelTab.ChangeZOrder(this.levelTab.SelectedID, false))
        this.levelTab.StatusBarLabel = "Increased Z order.";
      else
        this.levelTab.StatusBarLabel = "Cannot increase Z order any farther.";
    }

    private void decreaseZOrderToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.levelTab.ChangeZOrder(this.levelTab.SelectedID, true))
        this.levelTab.StatusBarLabel = "Decreased Z order.";
      else
        this.levelTab.StatusBarLabel = "Cannot decrease Z order any farther.";
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (base.ProcessCmdKey(ref msg, keyData))
        return true;
      if (!this.Focused && (this.levelTab == null || !this.levelTab.Focused || this.levelTab.Capture))
        return false;
      switch (keyData)
      {
        case Keys.Left | Keys.Shift:
          this.decreaseWidthToolStripMenuItem.PerformClick();
          return true;
        case Keys.Up | Keys.Shift:
          this.decreaseHeightToolStripMenuItem.PerformClick();
          return true;
        case Keys.Right | Keys.Shift:
          this.increaseWidthToolStripMenuItem.PerformClick();
          return true;
        case Keys.Down | Keys.Shift:
          this.increaseHeightToolStripMenuItem.PerformClick();
          return true;
        case Keys.Oemcomma | Keys.Shift:
          this.decreaseZOrderToolStripMenuItem.PerformClick();
          return true;
        case Keys.OemPeriod | Keys.Shift:
          this.increaseZOrderToolStripMenuItem.PerformClick();
          return true;
        case Keys.G | Keys.Control:
          this.tileGridToolStripMenuItem.PerformClick();
          return true;
        case Keys.Escape:
          this.unselectToolStripMenuItem.PerformClick();
          return true;
        case Keys.D0:
          this.checkeredBackgroundToolStripMenuItem.PerformClick();
          return true;
        case Keys.D1:
          this.objectsToolStripMenuItem.PerformClick();
          return true;
        case Keys.D2:
          this.spritesToolStripMenuItem.PerformClick();
          return true;
        case Keys.D3:
          this.screenBoundariesToolStripMenuItem.PerformClick();
          return true;
        case Keys.F1:
          if (this.objectEditModeToolStripMenuItem.Enabled)
            this.SetEditMode(this.levelTab.editMode != LevelTab.EditMode.Sprite);
          return true;
        default:
          return false;
      }
    }

    private void objectEditModeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.SetEditMode(false);
    }

    private void spriteEditModeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.SetEditMode(true);
    }

    private void SetEditMode(bool spriteEdit)
    {
      if (this.spriteEditModeToolStripMenuItem.Checked == spriteEdit)
        return;
      this.spriteEditModeToolStripMenuItem.Checked = this.toolSpriteEditMode.Checked = this.objectEditModeToolStripMenuItem.Checked;
      this.objectEditModeToolStripMenuItem.Checked = this.toolObjectEditMode.Checked = !this.objectEditModeToolStripMenuItem.Checked;
      this.levelTab.SwitchEditMode(spriteEdit ? LevelTab.EditMode.Sprite : LevelTab.EditMode.Object);
    }

    private void objectsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.levelTab.view = (LevelTab.View) ((this.objectsToolStripMenuItem.Checked ? 1 : 0) | (this.spritesToolStripMenuItem.Checked ? 2 : 0) | (this.screenBoundariesToolStripMenuItem.Checked ? 4 : 0) | (this.tileGridToolStripMenuItem.Checked ? 8 : 0) | (this.checkeredBackgroundToolStripMenuItem.Checked ? 16 : 0));
      if (sender != this.screenBoundariesToolStripMenuItem && sender != this.tileGridToolStripMenuItem)
        this.levelTab.RenderLevel();
      Win32.InvalidateRect(this.levelTab.Handle, (IntPtr) null, false);
    }

    private void undoToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.levelTab.undoBuffer.Count == 0)
        return;
      LevelTab.ICommand command = this.levelTab.undoBuffer.Pop();
      command.Undo();
      this.levelTab.redoBuffer.Push(command);
      this.EnableUndoRedo();
    }

    private void redoToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.levelTab.redoBuffer.Count == 0)
        return;
      LevelTab.ICommand command = this.levelTab.redoBuffer.Pop();
      command.Redo();
      this.levelTab.undoBuffer.Push(command);
      this.EnableUndoRedo();
    }

    public void EnableUndoRedo()
    {
      this.undoToolStripMenuItem.Enabled = this.toolUndo.Enabled = this.levelTab.undoBuffer.Count != 0;
      this.redoToolStripMenuItem.Enabled = this.toolRedo.Enabled = this.levelTab.redoBuffer.Count != 0;
      this.saveLevelInROMToolStripMenuItem.Enabled = this.toolSaveLevel.Enabled = this.levelTab.actionCount != this.levelTab.undoBuffer.Count;
    }

    private void toolSaveLevel_Click(object sender, EventArgs e)
    {
      this.levelTab.Save();
      this.saveLevelInROMToolStripMenuItem.Enabled = this.toolSaveLevel.Enabled = this.levelTab.actionCount != this.levelTab.undoBuffer.Count;
    }

    private void closeLevelToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.levelTab.Close();
    }

    private void clearLevelDataToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (ClearLevelData clearLevelData = new ClearLevelData())
      {
        if (clearLevelData.ShowDialog() != DialogResult.OK)
          return;
        this.levelTab.ClearLevelData(clearLevelData.ClearObject, clearLevelData.ClearSprite, clearLevelData.ClearExit);
      }
    }

    private void scanIlleganItemPlacementToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void levelInformationToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int[] levelDataRegion = this.levelTab.GetLevelDataRegion(this.mainForm.YI.ROM[0].ToByteArray(this.mainForm.YI.ROM.Length), (int) this.levelTab.Level.Number);
      int num1 = (int) this.levelTab.Level.Number == 56 ? 0 : 10;
      foreach (Level.Object @object in this.levelTab.Level.Objects)
      {
        if ((int) @object.num == 0)
        {
          num1 += 4;
        }
        else
        {
          byte num2 = (byte) ((uint) this.mainForm.YI.ROM[591084 + (int) @object.num].u8 & 3U);
          num1 += 3;
          if ((int) num2 != 1)
            ++num1;
          if ((int) num2 != 0)
            ++num1;
        }
      }
      int num3 = num1 + 1;
      foreach (Level.ScreenExit screenExit in this.levelTab.Level.Exits)
      {
        if (screenExit.enabled)
          num3 += 5;
      }
      int num4 = num3 + 1;
      int num5 = this.levelTab.Level.Sprites.Count * 3 + 2;
      int num6 = (int) MessageBox.Show(string.Format("Level Data in ROM: {0:X6} - {1:X6}\nSprite Data in ROM: {2:X6} - {3:X6}\n\nCurrent edited Level Data Size: 0x{4:X}\nCurrent edited Sprite Data Size: 0x{5:X}",  levelDataRegion[0],  levelDataRegion[1],  levelDataRegion[2],  levelDataRegion[3],  num4,  num5), "Level Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
      DockPanelSkin dockPanelSkin = new DockPanelSkin();
      AutoHideStripSkin autoHideStripSkin = new AutoHideStripSkin();
      DockPanelGradient dockPanelGradient1 = new DockPanelGradient();
      TabGradient tabGradient1 = new TabGradient();
      DockPaneStripSkin dockPaneStripSkin = new DockPaneStripSkin();
      DockPaneStripGradient paneStripGradient = new DockPaneStripGradient();
      TabGradient tabGradient2 = new TabGradient();
      DockPanelGradient dockPanelGradient2 = new DockPanelGradient();
      TabGradient tabGradient3 = new TabGradient();
      DockPaneStripToolWindowGradient toolWindowGradient = new DockPaneStripToolWindowGradient();
      TabGradient tabGradient4 = new TabGradient();
      TabGradient tabGradient5 = new TabGradient();
      DockPanelGradient dockPanelGradient3 = new DockPanelGradient();
      TabGradient tabGradient6 = new TabGradient();
      TabGradient tabGradient7 = new TabGradient();
      this.menuStrip1 = new MenuStrip();
      this.fileToolStripMenuItem = new ToolStripMenuItem();
      this.openLevelInROMToolStripMenuItem = new ToolStripMenuItem();
      this.openLevelFromFileToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator9 = new ToolStripSeparator();
      this.saveLevelInROMToolStripMenuItem = new ToolStripMenuItem();
      this.saveLevelToFileToolStripMenuItem = new ToolStripMenuItem();
      this.saveLevelToFileAsToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator8 = new ToolStripSeparator();
      this.closeLevelToolStripMenuItem = new ToolStripMenuItem();
      this.editToolStripMenuItem = new ToolStripMenuItem();
      this.undoToolStripMenuItem = new ToolStripMenuItem();
      this.redoToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator12 = new ToolStripSeparator();
      this.objectEditModeToolStripMenuItem = new ToolStripMenuItem();
      this.spriteEditModeToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator5 = new ToolStripSeparator();
      this.deleteToolStripMenuItem = new ToolStripMenuItem();
      this.unselectToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator6 = new ToolStripSeparator();
      this.increaseWidthToolStripMenuItem = new ToolStripMenuItem();
      this.decreaseWidthToolStripMenuItem = new ToolStripMenuItem();
      this.increaseHeightToolStripMenuItem = new ToolStripMenuItem();
      this.decreaseHeightToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator7 = new ToolStripSeparator();
      this.increaseZOrderToolStripMenuItem = new ToolStripMenuItem();
      this.decreaseZOrderToolStripMenuItem = new ToolStripMenuItem();
      this.levelToolStripMenuItem = new ToolStripMenuItem();
      this.clearLevelDataToolStripMenuItem = new ToolStripMenuItem();
      this.scanIlleganItemPlacementToolStripMenuItem = new ToolStripMenuItem();
      this.viewToolStripMenuItem = new ToolStripMenuItem();
      this.objectsToolStripMenuItem = new ToolStripMenuItem();
      this.spritesToolStripMenuItem = new ToolStripMenuItem();
      this.screenBoundariesToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator11 = new ToolStripSeparator();
      this.tileGridToolStripMenuItem = new ToolStripMenuItem();
      this.checkeredBackgroundToolStripMenuItem = new ToolStripMenuItem();
      this.toolStrip1 = new ToolStrip();
      this.toolStripSeparator1 = new ToolStripSeparator();
      this.toolNewLevel = new ToolStripButton();
      this.toolSelectLevel = new ToolStripButton();
      this.toolOpenLevelFile = new ToolStripButton();
      this.toolSaveLevel = new ToolStripButton();
      this.toolStripSeparator2 = new ToolStripSeparator();
      this.toolObjectEditMode = new ToolStripButton();
      this.toolSpriteEditMode = new ToolStripButton();
      this.toolStripSeparator3 = new ToolStripSeparator();
      this.toolObjSprSelector = new ToolStripButton();
      this.toolStripSeparator10 = new ToolStripSeparator();
      this.toolUndo = new ToolStripButton();
      this.toolRedo = new ToolStripButton();
      this.toolStripSeparator13 = new ToolStripSeparator();
      this.toolHeaderEditor = new ToolStripButton();
      this.toolPaletteEditor = new ToolStripButton();
      this.toolScreenExitEditor = new ToolStripButton();
      this.toolStripSeparator4 = new ToolStripSeparator();
      this.toolMiniMapViewer = new ToolStripButton();
      this.toolStripSeparator14 = new ToolStripSeparator();
      this.statusStrip1 = new StatusStrip();
      this.sbCoordinates = new ToolStripStatusLabel();
      this.sbTile = new ToolStripStatusLabel();
      this.sbLabel = new ToolStripStatusLabel();
      this.dockPanel = new DockPanel();
      this.levelInformationToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator15 = new ToolStripSeparator();
      this.menuStrip1.SuspendLayout();
      this.toolStrip1.SuspendLayout();
      this.statusStrip1.SuspendLayout();
      this.SuspendLayout();
      this.menuStrip1.AllowMerge = false;
      this.menuStrip1.Items.AddRange(new ToolStripItem[4]
      {
        (ToolStripItem) this.fileToolStripMenuItem,
        (ToolStripItem) this.editToolStripMenuItem,
        (ToolStripItem) this.levelToolStripMenuItem,
        (ToolStripItem) this.viewToolStripMenuItem
      });
      this.menuStrip1.Location = new Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new Size(387, 24);
      this.menuStrip1.TabIndex = 0;
      this.menuStrip1.Text = "menuStrip1";
      this.fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[8]
      {
        (ToolStripItem) this.openLevelInROMToolStripMenuItem,
        (ToolStripItem) this.openLevelFromFileToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator9,
        (ToolStripItem) this.saveLevelInROMToolStripMenuItem,
        (ToolStripItem) this.saveLevelToFileToolStripMenuItem,
        (ToolStripItem) this.saveLevelToFileAsToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator8,
        (ToolStripItem) this.closeLevelToolStripMenuItem
      });
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new Size(35, 20);
      this.fileToolStripMenuItem.Text = "&File";
      this.openLevelInROMToolStripMenuItem.Name = "openLevelInROMToolStripMenuItem";
      this.openLevelInROMToolStripMenuItem.ShortcutKeys = Keys.L | Keys.Control;
      this.openLevelInROMToolStripMenuItem.Size = new Size(214, 22);
      this.openLevelInROMToolStripMenuItem.Text = "Open &Level in ROM...";
      this.openLevelInROMToolStripMenuItem.Click += new EventHandler(this.openLevelInROMToolStripMenuItem_Click);
      this.openLevelFromFileToolStripMenuItem.Name = "openLevelFromFileToolStripMenuItem";
      this.openLevelFromFileToolStripMenuItem.Size = new Size(214, 22);
      this.openLevelFromFileToolStripMenuItem.Text = "&Open Level from File...";
      this.openLevelFromFileToolStripMenuItem.Visible = false;
      this.toolStripSeparator9.Name = "toolStripSeparator9";
      this.toolStripSeparator9.Size = new Size(211, 6);
      this.saveLevelInROMToolStripMenuItem.Enabled = false;
      this.saveLevelInROMToolStripMenuItem.Name = "saveLevelInROMToolStripMenuItem";
      this.saveLevelInROMToolStripMenuItem.ShortcutKeys = Keys.S | Keys.Control;
      this.saveLevelInROMToolStripMenuItem.Size = new Size(214, 22);
      this.saveLevelInROMToolStripMenuItem.Text = "&Save Level in ROM";
      this.saveLevelInROMToolStripMenuItem.Click += new EventHandler(this.toolSaveLevel_Click);
      this.saveLevelToFileToolStripMenuItem.Enabled = false;
      this.saveLevelToFileToolStripMenuItem.Name = "saveLevelToFileToolStripMenuItem";
      this.saveLevelToFileToolStripMenuItem.Size = new Size(214, 22);
      this.saveLevelToFileToolStripMenuItem.Text = "Save Level to File";
      this.saveLevelToFileToolStripMenuItem.Visible = false;
      this.saveLevelToFileAsToolStripMenuItem.Enabled = false;
      this.saveLevelToFileAsToolStripMenuItem.Name = "saveLevelToFileAsToolStripMenuItem";
      this.saveLevelToFileAsToolStripMenuItem.Size = new Size(214, 22);
      this.saveLevelToFileAsToolStripMenuItem.Text = "Save Level to File as...";
      this.saveLevelToFileAsToolStripMenuItem.Visible = false;
      this.toolStripSeparator8.Name = "toolStripSeparator8";
      this.toolStripSeparator8.Size = new Size(211, 6);
      this.closeLevelToolStripMenuItem.Enabled = false;
      this.closeLevelToolStripMenuItem.Name = "closeLevelToolStripMenuItem";
      this.closeLevelToolStripMenuItem.Size = new Size(214, 22);
      this.closeLevelToolStripMenuItem.Text = "Close Level";
      this.closeLevelToolStripMenuItem.Click += new EventHandler(this.closeLevelToolStripMenuItem_Click);
      this.editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[16]
      {
        (ToolStripItem) this.undoToolStripMenuItem,
        (ToolStripItem) this.redoToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator12,
        (ToolStripItem) this.objectEditModeToolStripMenuItem,
        (ToolStripItem) this.spriteEditModeToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator5,
        (ToolStripItem) this.deleteToolStripMenuItem,
        (ToolStripItem) this.unselectToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator6,
        (ToolStripItem) this.increaseWidthToolStripMenuItem,
        (ToolStripItem) this.decreaseWidthToolStripMenuItem,
        (ToolStripItem) this.increaseHeightToolStripMenuItem,
        (ToolStripItem) this.decreaseHeightToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator7,
        (ToolStripItem) this.increaseZOrderToolStripMenuItem,
        (ToolStripItem) this.decreaseZOrderToolStripMenuItem
      });
      this.editToolStripMenuItem.Name = "editToolStripMenuItem";
      this.editToolStripMenuItem.Size = new Size(37, 20);
      this.editToolStripMenuItem.Text = "&Edit";
      this.undoToolStripMenuItem.Enabled = false;
      this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
      this.undoToolStripMenuItem.ShortcutKeys = Keys.Z | Keys.Control;
      this.undoToolStripMenuItem.Size = new Size(214, 22);
      this.undoToolStripMenuItem.Text = "Undo";
      this.undoToolStripMenuItem.Click += new EventHandler(this.undoToolStripMenuItem_Click);
      this.redoToolStripMenuItem.Enabled = false;
      this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
      this.redoToolStripMenuItem.ShortcutKeys = Keys.Y | Keys.Control;
      this.redoToolStripMenuItem.Size = new Size(214, 22);
      this.redoToolStripMenuItem.Text = "Redo";
      this.redoToolStripMenuItem.Click += new EventHandler(this.redoToolStripMenuItem_Click);
      this.toolStripSeparator12.Name = "toolStripSeparator12";
      this.toolStripSeparator12.Size = new Size(211, 6);
      this.objectEditModeToolStripMenuItem.Checked = true;
      this.objectEditModeToolStripMenuItem.CheckState = CheckState.Checked;
      this.objectEditModeToolStripMenuItem.Enabled = false;
      this.objectEditModeToolStripMenuItem.Name = "objectEditModeToolStripMenuItem";
      this.objectEditModeToolStripMenuItem.ShortcutKeyDisplayString = "F1";
      this.objectEditModeToolStripMenuItem.Size = new Size(214, 22);
      this.objectEditModeToolStripMenuItem.Text = "Object Edit Mode";
      this.objectEditModeToolStripMenuItem.Click += new EventHandler(this.objectEditModeToolStripMenuItem_Click);
      this.spriteEditModeToolStripMenuItem.Enabled = false;
      this.spriteEditModeToolStripMenuItem.Name = "spriteEditModeToolStripMenuItem";
      this.spriteEditModeToolStripMenuItem.ShortcutKeyDisplayString = "F1";
      this.spriteEditModeToolStripMenuItem.Size = new Size(214, 22);
      this.spriteEditModeToolStripMenuItem.Text = "Sprite Edit Mode";
      this.spriteEditModeToolStripMenuItem.Click += new EventHandler(this.spriteEditModeToolStripMenuItem_Click);
      this.toolStripSeparator5.Name = "toolStripSeparator5";
      this.toolStripSeparator5.Size = new Size(211, 6);
      this.deleteToolStripMenuItem.Enabled = false;
      this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
      this.deleteToolStripMenuItem.ShortcutKeys = Keys.Delete;
      this.deleteToolStripMenuItem.Size = new Size(214, 22);
      this.deleteToolStripMenuItem.Text = "Delete";
      this.deleteToolStripMenuItem.Click += new EventHandler(this.deleteToolStripMenuItem_Click);
      this.unselectToolStripMenuItem.Enabled = false;
      this.unselectToolStripMenuItem.Name = "unselectToolStripMenuItem";
      this.unselectToolStripMenuItem.ShortcutKeyDisplayString = "Esc";
      this.unselectToolStripMenuItem.Size = new Size(214, 22);
      this.unselectToolStripMenuItem.Text = "Unselect";
      this.unselectToolStripMenuItem.Click += new EventHandler(this.unselectToolStripMenuItem_Click);
      this.toolStripSeparator6.Name = "toolStripSeparator6";
      this.toolStripSeparator6.Size = new Size(211, 6);
      this.increaseWidthToolStripMenuItem.Enabled = false;
      this.increaseWidthToolStripMenuItem.Name = "increaseWidthToolStripMenuItem";
      this.increaseWidthToolStripMenuItem.ShortcutKeyDisplayString = "Shift+Right";
      this.increaseWidthToolStripMenuItem.Size = new Size(214, 22);
      this.increaseWidthToolStripMenuItem.Text = "Increase Width";
      this.increaseWidthToolStripMenuItem.Click += new EventHandler(this.increaseWidthToolStripMenuItem_Click);
      this.decreaseWidthToolStripMenuItem.Enabled = false;
      this.decreaseWidthToolStripMenuItem.Name = "decreaseWidthToolStripMenuItem";
      this.decreaseWidthToolStripMenuItem.ShortcutKeyDisplayString = "Shift+Left";
      this.decreaseWidthToolStripMenuItem.Size = new Size(214, 22);
      this.decreaseWidthToolStripMenuItem.Text = "Decrease Width";
      this.decreaseWidthToolStripMenuItem.Click += new EventHandler(this.decreaseWidthToolStripMenuItem_Click);
      this.increaseHeightToolStripMenuItem.Enabled = false;
      this.increaseHeightToolStripMenuItem.Name = "increaseHeightToolStripMenuItem";
      this.increaseHeightToolStripMenuItem.ShortcutKeyDisplayString = "Shift+Down";
      this.increaseHeightToolStripMenuItem.Size = new Size(214, 22);
      this.increaseHeightToolStripMenuItem.Text = "Increase Height";
      this.increaseHeightToolStripMenuItem.Click += new EventHandler(this.increaseHeightToolStripMenuItem_Click);
      this.decreaseHeightToolStripMenuItem.Enabled = false;
      this.decreaseHeightToolStripMenuItem.Name = "decreaseHeightToolStripMenuItem";
      this.decreaseHeightToolStripMenuItem.ShortcutKeyDisplayString = "Shift+Up";
      this.decreaseHeightToolStripMenuItem.Size = new Size(214, 22);
      this.decreaseHeightToolStripMenuItem.Text = "Decrease Height";
      this.decreaseHeightToolStripMenuItem.Click += new EventHandler(this.decreaseHeightToolStripMenuItem_Click);
      this.toolStripSeparator7.Name = "toolStripSeparator7";
      this.toolStripSeparator7.Size = new Size(211, 6);
      this.increaseZOrderToolStripMenuItem.Enabled = false;
      this.increaseZOrderToolStripMenuItem.Name = "increaseZOrderToolStripMenuItem";
      this.increaseZOrderToolStripMenuItem.ShortcutKeyDisplayString = ">";
      this.increaseZOrderToolStripMenuItem.Size = new Size(214, 22);
      this.increaseZOrderToolStripMenuItem.Text = "Increase Z Order";
      this.increaseZOrderToolStripMenuItem.Click += new EventHandler(this.increaseZOrderToolStripMenuItem_Click);
      this.decreaseZOrderToolStripMenuItem.Enabled = false;
      this.decreaseZOrderToolStripMenuItem.Name = "decreaseZOrderToolStripMenuItem";
      this.decreaseZOrderToolStripMenuItem.ShortcutKeyDisplayString = "<";
      this.decreaseZOrderToolStripMenuItem.Size = new Size(214, 22);
      this.decreaseZOrderToolStripMenuItem.Text = "Decrease Z Order";
      this.decreaseZOrderToolStripMenuItem.Click += new EventHandler(this.decreaseZOrderToolStripMenuItem_Click);
      this.levelToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[4]
      {
        (ToolStripItem) this.levelInformationToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator15,
        (ToolStripItem) this.clearLevelDataToolStripMenuItem,
        (ToolStripItem) this.scanIlleganItemPlacementToolStripMenuItem
      });
      this.levelToolStripMenuItem.Name = "levelToolStripMenuItem";
      this.levelToolStripMenuItem.Size = new Size(44, 20);
      this.levelToolStripMenuItem.Text = "&Level";
      this.clearLevelDataToolStripMenuItem.Enabled = false;
      this.clearLevelDataToolStripMenuItem.Name = "clearLevelDataToolStripMenuItem";
      this.clearLevelDataToolStripMenuItem.ShortcutKeyDisplayString = "";
      this.clearLevelDataToolStripMenuItem.ShortcutKeys = Keys.Delete | Keys.Control;
      this.clearLevelDataToolStripMenuItem.Size = new Size(241, 22);
      this.clearLevelDataToolStripMenuItem.Text = "Clear Level Data";
      this.clearLevelDataToolStripMenuItem.Click += new EventHandler(this.clearLevelDataToolStripMenuItem_Click);
      this.scanIlleganItemPlacementToolStripMenuItem.Enabled = false;
      this.scanIlleganItemPlacementToolStripMenuItem.Name = "scanIlleganItemPlacementToolStripMenuItem";
      this.scanIlleganItemPlacementToolStripMenuItem.ShortcutKeys = Keys.I | Keys.Control;
      this.scanIlleganItemPlacementToolStripMenuItem.Size = new Size(241, 22);
      this.scanIlleganItemPlacementToolStripMenuItem.Text = "Scan Illegal Item Placement";
      this.scanIlleganItemPlacementToolStripMenuItem.Visible = false;
      this.scanIlleganItemPlacementToolStripMenuItem.Click += new EventHandler(this.scanIlleganItemPlacementToolStripMenuItem_Click);
      this.viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[6]
      {
        (ToolStripItem) this.objectsToolStripMenuItem,
        (ToolStripItem) this.spritesToolStripMenuItem,
        (ToolStripItem) this.screenBoundariesToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator11,
        (ToolStripItem) this.tileGridToolStripMenuItem,
        (ToolStripItem) this.checkeredBackgroundToolStripMenuItem
      });
      this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
      this.viewToolStripMenuItem.Size = new Size(41, 20);
      this.viewToolStripMenuItem.Text = "&View";
      this.objectsToolStripMenuItem.Checked = true;
      this.objectsToolStripMenuItem.CheckOnClick = true;
      this.objectsToolStripMenuItem.CheckState = CheckState.Checked;
      this.objectsToolStripMenuItem.Enabled = false;
      this.objectsToolStripMenuItem.Name = "objectsToolStripMenuItem";
      this.objectsToolStripMenuItem.ShortcutKeyDisplayString = "1";
      this.objectsToolStripMenuItem.Size = new Size(197, 22);
      this.objectsToolStripMenuItem.Text = "Objects";
      this.objectsToolStripMenuItem.Click += new EventHandler(this.objectsToolStripMenuItem_Click);
      this.spritesToolStripMenuItem.Checked = true;
      this.spritesToolStripMenuItem.CheckOnClick = true;
      this.spritesToolStripMenuItem.CheckState = CheckState.Checked;
      this.spritesToolStripMenuItem.Enabled = false;
      this.spritesToolStripMenuItem.Name = "spritesToolStripMenuItem";
      this.spritesToolStripMenuItem.ShortcutKeyDisplayString = "2";
      this.spritesToolStripMenuItem.Size = new Size(197, 22);
      this.spritesToolStripMenuItem.Text = "Sprites";
      this.spritesToolStripMenuItem.Click += new EventHandler(this.objectsToolStripMenuItem_Click);
      this.screenBoundariesToolStripMenuItem.CheckOnClick = true;
      this.screenBoundariesToolStripMenuItem.Enabled = false;
      this.screenBoundariesToolStripMenuItem.Name = "screenBoundariesToolStripMenuItem";
      this.screenBoundariesToolStripMenuItem.ShortcutKeyDisplayString = "3";
      this.screenBoundariesToolStripMenuItem.Size = new Size(197, 22);
      this.screenBoundariesToolStripMenuItem.Text = "Screen Boundaries";
      this.screenBoundariesToolStripMenuItem.Click += new EventHandler(this.objectsToolStripMenuItem_Click);
      this.toolStripSeparator11.Name = "toolStripSeparator11";
      this.toolStripSeparator11.Size = new Size(194, 6);
      this.tileGridToolStripMenuItem.CheckOnClick = true;
      this.tileGridToolStripMenuItem.Enabled = false;
      this.tileGridToolStripMenuItem.Name = "tileGridToolStripMenuItem";
      this.tileGridToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+G";
      this.tileGridToolStripMenuItem.Size = new Size(197, 22);
      this.tileGridToolStripMenuItem.Text = "Tile Grid";
      this.tileGridToolStripMenuItem.Click += new EventHandler(this.objectsToolStripMenuItem_Click);
      this.checkeredBackgroundToolStripMenuItem.CheckOnClick = true;
      this.checkeredBackgroundToolStripMenuItem.Enabled = false;
      this.checkeredBackgroundToolStripMenuItem.Name = "checkeredBackgroundToolStripMenuItem";
      this.checkeredBackgroundToolStripMenuItem.ShortcutKeyDisplayString = "0";
      this.checkeredBackgroundToolStripMenuItem.Size = new Size(197, 22);
      this.checkeredBackgroundToolStripMenuItem.Text = "Checkered Background";
      this.checkeredBackgroundToolStripMenuItem.Click += new EventHandler(this.objectsToolStripMenuItem_Click);
      this.toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
      this.toolStrip1.Items.AddRange(new ToolStripItem[20]
      {
        (ToolStripItem) this.toolStripSeparator1,
        (ToolStripItem) this.toolNewLevel,
        (ToolStripItem) this.toolSelectLevel,
        (ToolStripItem) this.toolOpenLevelFile,
        (ToolStripItem) this.toolSaveLevel,
        (ToolStripItem) this.toolStripSeparator2,
        (ToolStripItem) this.toolObjectEditMode,
        (ToolStripItem) this.toolSpriteEditMode,
        (ToolStripItem) this.toolStripSeparator3,
        (ToolStripItem) this.toolObjSprSelector,
        (ToolStripItem) this.toolStripSeparator10,
        (ToolStripItem) this.toolUndo,
        (ToolStripItem) this.toolRedo,
        (ToolStripItem) this.toolStripSeparator13,
        (ToolStripItem) this.toolHeaderEditor,
        (ToolStripItem) this.toolPaletteEditor,
        (ToolStripItem) this.toolScreenExitEditor,
        (ToolStripItem) this.toolStripSeparator4,
        (ToolStripItem) this.toolMiniMapViewer,
        (ToolStripItem) this.toolStripSeparator14
      });
      this.toolStrip1.Location = new Point(0, 24);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new Size(387, 25);
      this.toolStrip1.TabIndex = 1;
      this.toolStrip1.Text = "toolStrip1";
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new Size(6, 25);
      this.toolNewLevel.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolNewLevel.Image = (Image) GE.Properties.Resources.New;
      this.toolNewLevel.ImageTransparentColor = Color.Magenta;
      this.toolNewLevel.Name = "toolNewLevel";
      this.toolNewLevel.Size = new Size(23, 22);
      this.toolNewLevel.Text = "Create a New Level";
      this.toolNewLevel.Visible = false;
      this.toolSelectLevel.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolSelectLevel.Image = (Image) GE.Properties.Resources.LevelSelect;
      this.toolSelectLevel.ImageTransparentColor = Color.Magenta;
      this.toolSelectLevel.Name = "toolSelectLevel";
      this.toolSelectLevel.Size = new Size(23, 22);
      this.toolSelectLevel.Text = "Open a Level Number";
      this.toolSelectLevel.Click += new EventHandler(this.toolSelectLevel_Click);
      this.toolOpenLevelFile.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolOpenLevelFile.Image = (Image) GE.Properties.Resources.Open;
      this.toolOpenLevelFile.ImageTransparentColor = Color.Magenta;
      this.toolOpenLevelFile.Name = "toolOpenLevelFile";
      this.toolOpenLevelFile.Size = new Size(23, 22);
      this.toolOpenLevelFile.Text = "Open a Level File";
      this.toolOpenLevelFile.Visible = false;
      this.toolSaveLevel.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolSaveLevel.Enabled = false;
      this.toolSaveLevel.Image = (Image) GE.Properties.Resources.Save;
      this.toolSaveLevel.ImageTransparentColor = Color.Magenta;
      this.toolSaveLevel.Name = "toolSaveLevel";
      this.toolSaveLevel.Size = new Size(23, 22);
      this.toolSaveLevel.Text = "Save a Level to ROM";
      this.toolSaveLevel.Click += new EventHandler(this.toolSaveLevel_Click);
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new Size(6, 25);
      this.toolObjectEditMode.Checked = true;
      this.toolObjectEditMode.CheckState = CheckState.Checked;
      this.toolObjectEditMode.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolObjectEditMode.Enabled = false;
      this.toolObjectEditMode.Image = (Image) GE.Properties.Resources.ObjectEditMode;
      this.toolObjectEditMode.ImageTransparentColor = Color.Magenta;
      this.toolObjectEditMode.Name = "toolObjectEditMode";
      this.toolObjectEditMode.Size = new Size(23, 22);
      this.toolObjectEditMode.Text = "Enable Object Edit Mode";
      this.toolObjectEditMode.Click += new EventHandler(this.objectEditModeToolStripMenuItem_Click);
      this.toolSpriteEditMode.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolSpriteEditMode.Enabled = false;
      this.toolSpriteEditMode.Image = (Image) GE.Properties.Resources.SpriteEditMode;
      this.toolSpriteEditMode.ImageTransparentColor = Color.Magenta;
      this.toolSpriteEditMode.Name = "toolSpriteEditMode";
      this.toolSpriteEditMode.Size = new Size(23, 22);
      this.toolSpriteEditMode.Text = "Enable Sprite Edit Mode";
      this.toolSpriteEditMode.Click += new EventHandler(this.spriteEditModeToolStripMenuItem_Click);
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new Size(6, 25);
      this.toolObjSprSelector.Checked = true;
      this.toolObjSprSelector.CheckState = CheckState.Checked;
      this.toolObjSprSelector.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolObjSprSelector.Image = (Image) GE.Properties.Resources.Selector;
      this.toolObjSprSelector.ImageTransparentColor = Color.Magenta;
      this.toolObjSprSelector.Name = "toolObjSprSelector";
      this.toolObjSprSelector.Size = new Size(23, 22);
      this.toolObjSprSelector.Text = "Open Object and Sprite Selector ";
      this.toolObjSprSelector.Click += new EventHandler(this.toolObjSprSelector_Click);
      this.toolStripSeparator10.Name = "toolStripSeparator10";
      this.toolStripSeparator10.Size = new Size(6, 25);
      this.toolUndo.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolUndo.Enabled = false;
      this.toolUndo.Image = (Image) GE.Properties.Resources.Undo;
      this.toolUndo.ImageTransparentColor = Color.Magenta;
      this.toolUndo.Name = "toolUndo";
      this.toolUndo.Size = new Size(23, 22);
      this.toolUndo.Text = "Undo";
      this.toolUndo.Click += new EventHandler(this.undoToolStripMenuItem_Click);
      this.toolRedo.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolRedo.Enabled = false;
      this.toolRedo.Image = (Image) GE.Properties.Resources.Redo;
      this.toolRedo.ImageTransparentColor = Color.Magenta;
      this.toolRedo.Name = "toolRedo";
      this.toolRedo.Size = new Size(23, 22);
      this.toolRedo.Text = "Redo";
      this.toolRedo.Click += new EventHandler(this.redoToolStripMenuItem_Click);
      this.toolStripSeparator13.Name = "toolStripSeparator13";
      this.toolStripSeparator13.Size = new Size(6, 25);
      this.toolHeaderEditor.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolHeaderEditor.Image = (Image) GE.Properties.Resources.HeaderEditor;
      this.toolHeaderEditor.ImageTransparentColor = Color.Magenta;
      this.toolHeaderEditor.Name = "toolHeaderEditor";
      this.toolHeaderEditor.Size = new Size(23, 22);
      this.toolHeaderEditor.Text = "Open Header Editor";
      this.toolHeaderEditor.Click += new EventHandler(this.toolHeaderEditor_Click);
      this.toolPaletteEditor.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolPaletteEditor.Image = (Image) GE.Properties.Resources.PaletteEditor;
      this.toolPaletteEditor.ImageTransparentColor = Color.Magenta;
      this.toolPaletteEditor.Name = "toolPaletteEditor";
      this.toolPaletteEditor.Size = new Size(23, 22);
      this.toolPaletteEditor.Text = "Open Palette Editor";
      this.toolPaletteEditor.Click += new EventHandler(this.toolPaletteEditor_Click);
      this.toolScreenExitEditor.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolScreenExitEditor.Image = (Image) GE.Properties.Resources.ExitEditor;
      this.toolScreenExitEditor.ImageTransparentColor = Color.Magenta;
      this.toolScreenExitEditor.Name = "toolScreenExitEditor";
      this.toolScreenExitEditor.Size = new Size(23, 22);
      this.toolScreenExitEditor.Text = "Open Screen Exit Editor";
      this.toolScreenExitEditor.Click += new EventHandler(this.toolScreenExitEditor_Click);
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      this.toolStripSeparator4.Size = new Size(6, 25);
      this.toolMiniMapViewer.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolMiniMapViewer.Image = (Image) GE.Properties.Resources.map;
      this.toolMiniMapViewer.ImageTransparentColor = Color.Magenta;
      this.toolMiniMapViewer.Name = "toolMiniMapViewer";
      this.toolMiniMapViewer.Size = new Size(23, 22);
      this.toolMiniMapViewer.Text = "Open Mini Map Viewer";
      this.toolMiniMapViewer.Click += new EventHandler(this.toolMiniMapViewer_Click);
      this.toolStripSeparator14.Name = "toolStripSeparator14";
      this.toolStripSeparator14.Size = new Size(6, 25);
      this.statusStrip1.Items.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.sbCoordinates,
        (ToolStripItem) this.sbTile,
        (ToolStripItem) this.sbLabel
      });
      this.statusStrip1.Location = new Point(0, 264);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new Size(387, 22);
      this.statusStrip1.SizingGrip = false;
      this.statusStrip1.TabIndex = 3;
      this.statusStrip1.Text = "statusStrip1";
      this.sbCoordinates.AutoSize = false;
      this.sbCoordinates.BorderSides = ToolStripStatusLabelBorderSides.Right;
      this.sbCoordinates.Name = "sbCoordinates";
      this.sbCoordinates.Size = new Size(63, 17);
      this.sbTile.AutoSize = false;
      this.sbTile.BorderSides = ToolStripStatusLabelBorderSides.Right;
      this.sbTile.Name = "sbTile";
      this.sbTile.Size = new Size(35, 17);
      this.sbLabel.Name = "sbLabel";
      this.sbLabel.Size = new Size(0, 17);
      this.dockPanel.ActiveAutoHideContent = (IDockContent) null;
      this.dockPanel.BackColor = SystemColors.Control;
      this.dockPanel.DefaultFloatWindowSize = new Size(30, 30);
      this.dockPanel.Dock = DockStyle.Fill;
      this.dockPanel.DockBackColor = SystemColors.AppWorkspace;
      this.dockPanel.DockLeftPortion = 250.0;
      this.dockPanel.DockRightPortion = 250.0;
      this.dockPanel.DocumentStyle = DocumentStyle.DockingWindow;
      this.dockPanel.Location = new Point(0, 49);
      this.dockPanel.Name = "dockPanel";
      this.dockPanel.Size = new Size(387, 215);
      dockPanelGradient1.EndColor = SystemColors.ControlLight;
      dockPanelGradient1.StartColor = SystemColors.ControlLight;
      autoHideStripSkin.DockStripGradient = dockPanelGradient1;
      tabGradient1.EndColor = SystemColors.Control;
      tabGradient1.StartColor = SystemColors.Control;
      tabGradient1.TextColor = SystemColors.ControlDarkDark;
      autoHideStripSkin.TabGradient = tabGradient1;
      dockPanelSkin.AutoHideStripSkin = autoHideStripSkin;
      tabGradient2.EndColor = SystemColors.ControlLightLight;
      tabGradient2.StartColor = SystemColors.ControlLightLight;
      tabGradient2.TextColor = SystemColors.ControlText;
      paneStripGradient.ActiveTabGradient = tabGradient2;
      dockPanelGradient2.EndColor = SystemColors.Control;
      dockPanelGradient2.StartColor = SystemColors.Control;
      paneStripGradient.DockStripGradient = dockPanelGradient2;
      tabGradient3.EndColor = SystemColors.ControlLight;
      tabGradient3.StartColor = SystemColors.ControlLight;
      tabGradient3.TextColor = SystemColors.ControlText;
      paneStripGradient.InactiveTabGradient = tabGradient3;
      dockPaneStripSkin.DocumentGradient = paneStripGradient;
      tabGradient4.EndColor = SystemColors.ActiveCaption;
      tabGradient4.LinearGradientMode = LinearGradientMode.Vertical;
      tabGradient4.StartColor = SystemColors.GradientActiveCaption;
      tabGradient4.TextColor = SystemColors.ActiveCaptionText;
      toolWindowGradient.ActiveCaptionGradient = tabGradient4;
      tabGradient5.EndColor = SystemColors.Control;
      tabGradient5.StartColor = SystemColors.Control;
      tabGradient5.TextColor = SystemColors.ControlText;
      toolWindowGradient.ActiveTabGradient = tabGradient5;
      dockPanelGradient3.EndColor = SystemColors.ControlLight;
      dockPanelGradient3.StartColor = SystemColors.ControlLight;
      toolWindowGradient.DockStripGradient = dockPanelGradient3;
      tabGradient6.EndColor = SystemColors.GradientInactiveCaption;
      tabGradient6.LinearGradientMode = LinearGradientMode.Vertical;
      tabGradient6.StartColor = SystemColors.GradientInactiveCaption;
      tabGradient6.TextColor = SystemColors.ControlText;
      toolWindowGradient.InactiveCaptionGradient = tabGradient6;
      tabGradient7.EndColor = Color.Transparent;
      tabGradient7.StartColor = Color.Transparent;
      tabGradient7.TextColor = SystemColors.ControlDarkDark;
      toolWindowGradient.InactiveTabGradient = tabGradient7;
      dockPaneStripSkin.ToolWindowGradient = toolWindowGradient;
      dockPanelSkin.DockPaneStripSkin = dockPaneStripSkin;
      this.dockPanel.Skin = dockPanelSkin;
      this.dockPanel.TabIndex = 4;
      this.dockPanel.ActiveDocumentChanged += new EventHandler(this.dockPanel_ActiveDocumentChanged);
      this.levelInformationToolStripMenuItem.Enabled = false;
      this.levelInformationToolStripMenuItem.Name = "levelInformationToolStripMenuItem";
      this.levelInformationToolStripMenuItem.Size = new Size(241, 22);
      this.levelInformationToolStripMenuItem.Text = "Level Information";
      this.levelInformationToolStripMenuItem.Click += new EventHandler(this.levelInformationToolStripMenuItem_Click);
      this.toolStripSeparator15.Name = "toolStripSeparator15";
      this.toolStripSeparator15.Size = new Size(238, 6);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.ClientSize = new Size(387, 286);
      this.ControlBox = false;
      this.Controls.Add((Control) this.dockPanel);
      this.Controls.Add((Control) this.statusStrip1);
      this.Controls.Add((Control) this.toolStrip1);
      this.Controls.Add((Control) this.menuStrip1);
      this.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.KeyPreview = true;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "LevelEditor";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.Text = "LevelEditor";
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
