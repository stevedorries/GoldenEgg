
// Type: GE.Forms.Dialogues.LevelEditor.ScreenExitEditor

// MVID: 7AA6A484-F524-42F2-9571-0947D386B578
// Assembly location: C:\Documents and Settings\THE RAIN\Desktop\ge.exe

using GE;
using GE.Forms;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;


  public class ScreenExitEditor : DockContent
  {
    private bool internalChange = true;
    private IContainer components;
    private TabControl tabControl1;
    private TabPage tabPage1;
    private TabPage tabPage2;
    private Label label5;
    private Library.Controls.HexTextBox hexTextBox3;
    private Label label4;
    private Library.Controls.HexTextBox hexTextBox2;
    private Label label3;
    private Library.Controls.HexTextBox hexTextBox1;
    private Label label2;
    private ComboBox comboBox2;
    private ComboBox comboBox3;
    private Label label6;
    private Library.Controls.HexTextBox hexTextBox4;
    private Label label7;
    private Library.Controls.HexTextBox hexTextBox5;
    private Label label8;
    private Library.Controls.HexTextBox hexTextBox6;
    private Label label9;
    private TableLayoutPanel tableLayoutPanel1;
    private Panel panel1;
    private Label label1;
    private ComboBox comboBox1;
    private CheckBox checkBox1;
    private Panel panel2;
    private Button button1;
    private Button button2;

    private LevelEditor levelEditor
    {
      get
      {
        return (LevelEditor) this.DockPanel.Parent;
      }
    }

    private LevelTab levelTab
    {
      get
      {
        return (LevelTab) this.DockPanel.ActiveDocument;
      }
    }

    public ScreenExitEditor()
    {
      this.InitializeComponent();
      this.comboBox1.BeginUpdate();
      for (int index = 0; index < 128; ++index)
        this.comboBox1.Items.Add( index.ToString("X2"));
      this.comboBox1.EndUpdate();
      this.comboBox1.SelectedIndex = 0;
      this.comboBox2.SelectedIndex = this.comboBox3.SelectedIndex = 0;
      this.internalChange = false;
    }

    protected override void OnClosing(CancelEventArgs e)
    {
      e.Cancel = true;
      this.levelEditor.CheckScreenExitEditor(false);
      this.Hide();
    }

    public void OnLevelTabChanged()
    {
      this.UpdateInformation();
      this.button1.Enabled = this.button2.Enabled = false;
    }

    public void UpdateInformation()
    {
      this.internalChange = true;
      int selectedIndex = this.comboBox1.SelectedIndex;
      if (this.checkBox1.Checked = this.levelTab.ScreenExits[selectedIndex].enabled)
      {
        IntPtr focus = Win32.GetFocus();
        this.tabControl1.Enabled = true;
        if ((int) this.levelTab.ScreenExits[selectedIndex].dest <= 221)
        {
          this.hexTextBox1.Text = this.levelTab.ScreenExits[selectedIndex].dest.ToString("X2");
          this.hexTextBox2.Text = this.levelTab.ScreenExits[selectedIndex].x.ToString("X2");
          this.hexTextBox3.Text = this.levelTab.ScreenExits[selectedIndex].y.ToString("X2");
          this.hexTextBox4.Text = this.hexTextBox5.Text = this.hexTextBox6.Text = "";
          //this.comboBox2.SelectedIndex = (int) this.levelTab.ScreenExits[selectedIndex].type;
          this.comboBox3.SelectedIndex = 0;
          this.tabControl1.SelectedIndex = 0;
        }
        else
        {
          this.hexTextBox1.Text = this.hexTextBox2.Text = this.hexTextBox3.Text = "";
          this.hexTextBox4.Text = this.levelTab.ScreenExits[selectedIndex].type.ToString("X2");
          this.hexTextBox5.Text = this.levelTab.ScreenExits[selectedIndex].x.ToString("X2");
          this.hexTextBox6.Text = this.levelTab.ScreenExits[selectedIndex].y.ToString("X2");
          this.comboBox2.SelectedIndex = 0;
          this.comboBox3.SelectedIndex = (int) this.levelTab.ScreenExits[selectedIndex].dest - 222;
          this.tabControl1.SelectedIndex = 1;
        }
        Win32.SetFocus(focus);
      }
      else
      {
        this.tabControl1.Enabled = false;
        this.hexTextBox1.Text = this.hexTextBox2.Text = this.hexTextBox3.Text = this.hexTextBox4.Text = this.hexTextBox5.Text = this.hexTextBox6.Text = "";
        this.comboBox2.SelectedIndex = this.comboBox3.SelectedIndex = 0;
      }
      this.internalChange = false;
    }

    private void UndoRedo(int id, ref Level.ScreenExit exit)
    {
      this.internalChange = true;
      this.comboBox1.SelectedIndex = id;
      this.ApplyChange( exit);
      this.UpdateInformation();
    }

    public void ApplyChange(object Exit)
    {
      Level.ScreenExit newExit;
      if (Exit == null)
      {
        newExit = new Level.ScreenExit();
        if (this.checkBox1.Checked)
        {
          newExit.enabled = true;
          if (this.tabControl1.SelectedIndex == 0)
          {
            if (this.hexTextBox1.Text == "")
              this.hexTextBox1.Text = "00";
            newExit.dest = byte.Parse(this.hexTextBox1.Text, NumberStyles.AllowHexSpecifier);
            if (this.hexTextBox2.Text == "")
              this.hexTextBox2.Text = "00";
            newExit.x = byte.Parse(this.hexTextBox2.Text, NumberStyles.AllowHexSpecifier);
            if (this.hexTextBox3.Text == "")
              this.hexTextBox3.Text = "00";
            newExit.y = byte.Parse(this.hexTextBox3.Text, NumberStyles.AllowHexSpecifier);
            newExit.type = (byte) this.comboBox2.SelectedIndex;
          }
          else
          {
            newExit.dest = (byte) (this.comboBox3.SelectedIndex + 222);
            if (this.hexTextBox5.Text == "")
              this.hexTextBox5.Text = "00";
            newExit.x = byte.Parse(this.hexTextBox5.Text, NumberStyles.AllowHexSpecifier);
            if (this.hexTextBox6.Text == "")
              this.hexTextBox6.Text = "00";
            newExit.y = byte.Parse(this.hexTextBox6.Text, NumberStyles.AllowHexSpecifier);
            if (this.hexTextBox4.Text == "")
              this.hexTextBox4.Text = "00";
            newExit.type = byte.Parse(this.hexTextBox4.Text, NumberStyles.AllowHexSpecifier);
          }
        }
        this.levelTab.undoBuffer.Push((LevelTab.ICommand) new ScreenExitEditor.EditCommand(this, this.comboBox1.SelectedIndex, this.levelTab.ScreenExits[this.comboBox1.SelectedIndex], newExit));
        this.levelTab.redoBuffer.Clear();
        this.levelEditor.EnableUndoRedo();
      }
      else
        newExit = (Level.ScreenExit) Exit;
      Win32.InvalidateRect(this.levelTab.Handle, (IntPtr) null, false);
      this.levelTab.ScreenExits[this.comboBox1.SelectedIndex] = newExit;
      this.button1.Enabled = this.button2.Enabled = false;
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.internalChange)
        return;
      this.UpdateInformation();
      this.button1.Enabled = this.button2.Enabled = false;
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.internalChange)
        this.button1.Enabled = this.button2.Enabled = true;
      this.tabControl1.Enabled = this.checkBox1.Checked;
    }

    private void hexTextBox1_TextChanged(object sender, EventArgs e)
    {
      if (this.internalChange)
        return;
      this.button1.Enabled = this.button2.Enabled = true;
    }

    private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.internalChange)
        return;
      this.button1.Enabled = this.button2.Enabled = true;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.ApplyChange( null);
    }

    private void button2_Click(object sender, EventArgs e)
    {
      this.UpdateInformation();
      this.button1.Enabled = this.button2.Enabled = false;
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
      this.tabControl1 = new TabControl();
      this.tabPage1 = new TabPage();
      this.comboBox2 = new ComboBox();
      this.label5 = new Label();
      this.hexTextBox3 = new Library.Controls.HexTextBox();
      this.label4 = new Label();
      this.hexTextBox2 = new Library.Controls.HexTextBox();
      this.label3 = new Label();
      this.hexTextBox1 = new Library.Controls.HexTextBox();
      this.label2 = new Label();
      this.tabPage2 = new TabPage();
      this.comboBox3 = new ComboBox();
      this.label6 = new Label();
      this.label7 = new Label();
      this.label8 = new Label();
      this.label9 = new Label();
      this.hexTextBox4 = new Library.Controls.HexTextBox();
      this.hexTextBox5 = new Library.Controls.HexTextBox();
      this.hexTextBox6 = new Library.Controls.HexTextBox();
      this.tableLayoutPanel1 = new TableLayoutPanel();
      this.panel1 = new Panel();
      this.label1 = new Label();
      this.comboBox1 = new ComboBox();
      this.checkBox1 = new CheckBox();
      this.panel2 = new Panel();
      this.button1 = new Button();
      this.button2 = new Button();
      this.tabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.tabPage2.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      this.tabControl1.Controls.Add((Control) this.tabPage1);
      this.tabControl1.Controls.Add((Control) this.tabPage2);
      this.tabControl1.Dock = DockStyle.Fill;
      this.tabControl1.Enabled = false;
      this.tabControl1.Location = new Point(3, 62);
      this.tabControl1.MinimumSize = new Size(205, 169);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new Size(205, 169);
      this.tabControl1.TabIndex = 1;
      this.tabPage1.Controls.Add((Control) this.comboBox2);
      this.tabPage1.Controls.Add((Control) this.label5);
      this.tabPage1.Controls.Add((Control) this.hexTextBox3);
      this.tabPage1.Controls.Add((Control) this.label4);
      this.tabPage1.Controls.Add((Control) this.hexTextBox2);
      this.tabPage1.Controls.Add((Control) this.label3);
      this.tabPage1.Controls.Add((Control) this.hexTextBox1);
      this.tabPage1.Controls.Add((Control) this.label2);
      this.tabPage1.Location = new Point(4, 22);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new Padding(3);
      this.tabPage1.Size = new Size(197, 143);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "Level";
      this.tabPage1.UseVisualStyleBackColor = true;
      this.comboBox2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox2.FormattingEnabled = true;
      this.comboBox2.Items.AddRange(new object[11]
      {
         "0 : Does Nothing",
         "1 : Skis",
         "2 : Exits rightwards from Pipe",
         "3 : Exits leftwards from Pipe",
         "4 : Exits downwards from Pipe",
         "5 : Exits upwards from Pipe",
         "6 : Goes rightwards",
         "7 : Goes leftwards",
         "8 : Goes downwards",
         "9 : Jumps high",
         "A : Sent flying to Moon"
      });
      this.comboBox2.Location = new Point(14, 107);
      this.comboBox2.Name = "comboBox2";
      this.comboBox2.Size = new Size(169, 21);
      this.comboBox2.TabIndex = 7;
      this.comboBox2.SelectedIndexChanged += new EventHandler(this.comboBox2_SelectedIndexChanged);
      this.label5.AutoSize = true;
      this.label5.Location = new Point(11, 91);
      this.label5.Name = "label5";
      this.label5.Size = new Size(77, 13);
      this.label5.TabIndex = 6;
      this.label5.Text = "Entrance Type";
      this.hexTextBox3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.hexTextBox3.CharacterCasing = CharacterCasing.Upper;
      this.hexTextBox3.Location = new Point(144, 62);
      this.hexTextBox3.MaxLength = 2;
      this.hexTextBox3.Name = "hexTextBox3";
      this.hexTextBox3.Size = new Size(39, 20);
      this.hexTextBox3.TabIndex = 5;
      this.hexTextBox3.TextChanged += new EventHandler(this.hexTextBox1_TextChanged);
      this.label4.AutoSize = true;
      this.label4.Location = new Point(11, 65);
      this.label4.Name = "label4";
      this.label4.Size = new Size(124, 13);
      this.label4.TabIndex = 4;
      this.label4.Text = "Destination Y Coordinate";
      this.hexTextBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.hexTextBox2.CharacterCasing = CharacterCasing.Upper;
      this.hexTextBox2.Location = new Point(144, 36);
      this.hexTextBox2.MaxLength = 2;
      this.hexTextBox2.Name = "hexTextBox2";
      this.hexTextBox2.Size = new Size(39, 20);
      this.hexTextBox2.TabIndex = 3;
      this.hexTextBox2.TextChanged += new EventHandler(this.hexTextBox1_TextChanged);
      this.label3.AutoSize = true;
      this.label3.Location = new Point(11, 39);
      this.label3.Name = "label3";
      this.label3.Size = new Size(124, 13);
      this.label3.TabIndex = 2;
      this.label3.Text = "Destination X Coordinate";
      this.hexTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.hexTextBox1.CharacterCasing = CharacterCasing.Upper;
      this.hexTextBox1.Location = new Point(144, 10);
      this.hexTextBox1.MaxLength = 2;
      this.hexTextBox1.Name = "hexTextBox1";
      this.hexTextBox1.Size = new Size(39, 20);
      this.hexTextBox1.TabIndex = 1;
      this.hexTextBox1.TextChanged += new EventHandler(this.hexTextBox1_TextChanged);
      this.label2.AutoSize = true;
      this.label2.Location = new Point(11, 13);
      this.label2.Name = "label2";
      this.label2.Size = new Size(89, 13);
      this.label2.TabIndex = 0;
      this.label2.Text = "Destination Level";
      this.tabPage2.Controls.Add((Control) this.comboBox3);
      this.tabPage2.Controls.Add((Control) this.label6);
      this.tabPage2.Controls.Add((Control) this.label7);
      this.tabPage2.Controls.Add((Control) this.label8);
      this.tabPage2.Controls.Add((Control) this.label9);
      this.tabPage2.Controls.Add((Control) this.hexTextBox4);
      this.tabPage2.Controls.Add((Control) this.hexTextBox5);
      this.tabPage2.Controls.Add((Control) this.hexTextBox6);
      this.tabPage2.Location = new Point(4, 22);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new Padding(3);
      this.tabPage2.Size = new Size(197, 143);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "Mini Battle";
      this.tabPage2.UseVisualStyleBackColor = true;
      this.comboBox3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox3.FormattingEnabled = true;
      this.comboBox3.Items.AddRange(new object[10]
      {
         "0 : Throwing Balloons (4)",
         "1 : Throwing Balloons (5)",
         "2 : Throwing Balloons (6)",
         "3 : Glitched",
         "4 : Gather Coins",
         "5 : Popping Balloons",
         "6 : Popping Balloons (Platforms moving)",
         "7 : Glitched",
         "8 : Glitched",
         "9 : Watermelong Seed Spitting Contest"
      });
      this.comboBox3.Location = new Point(14, 107);
      this.comboBox3.Name = "comboBox3";
      this.comboBox3.Size = new Size(169, 21);
      this.comboBox3.TabIndex = 7;
      this.comboBox3.SelectedIndexChanged += new EventHandler(this.comboBox2_SelectedIndexChanged);
      this.label6.AutoSize = true;
      this.label6.Location = new Point(11, 91);
      this.label6.Name = "label6";
      this.label6.Size = new Size(56, 13);
      this.label6.TabIndex = 6;
      this.label6.Text = "Mini Battle";
      this.label7.AutoSize = true;
      this.label7.Location = new Point(11, 65);
      this.label7.Name = "label7";
      this.label7.Size = new Size(103, 13);
      this.label7.TabIndex = 4;
      this.label7.Text = "Return Y Coordinate";
      this.label8.AutoSize = true;
      this.label8.Location = new Point(11, 39);
      this.label8.Name = "label8";
      this.label8.Size = new Size(103, 13);
      this.label8.TabIndex = 2;
      this.label8.Text = "Return X Coordinate";
      this.label9.AutoSize = true;
      this.label9.Location = new Point(11, 13);
      this.label9.Name = "label9";
      this.label9.Size = new Size(68, 13);
      this.label9.TabIndex = 0;
      this.label9.Text = "Return Level";
      this.hexTextBox4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.hexTextBox4.CharacterCasing = CharacterCasing.Upper;
      this.hexTextBox4.Location = new Point(144, 10);
      this.hexTextBox4.MaxLength = 2;
      this.hexTextBox4.Name = "hexTextBox4";
      this.hexTextBox4.Size = new Size(39, 20);
      this.hexTextBox4.TabIndex = 1;
      this.hexTextBox4.TextChanged += new EventHandler(this.hexTextBox1_TextChanged);
      this.hexTextBox5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.hexTextBox5.CharacterCasing = CharacterCasing.Upper;
      this.hexTextBox5.Location = new Point(144, 36);
      this.hexTextBox5.MaxLength = 2;
      this.hexTextBox5.Name = "hexTextBox5";
      this.hexTextBox5.Size = new Size(39, 20);
      this.hexTextBox5.TabIndex = 3;
      this.hexTextBox5.TextChanged += new EventHandler(this.hexTextBox1_TextChanged);
      this.hexTextBox6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.hexTextBox6.CharacterCasing = CharacterCasing.Upper;
      this.hexTextBox6.Location = new Point(144, 62);
      this.hexTextBox6.MaxLength = 2;
      this.hexTextBox6.Name = "hexTextBox6";
      this.hexTextBox6.Size = new Size(39, 20);
      this.hexTextBox6.TabIndex = 5;
      this.hexTextBox6.TextChanged += new EventHandler(this.hexTextBox1_TextChanged);
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
      this.tableLayoutPanel1.Controls.Add((Control) this.panel1, 0, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.panel2, 0, 2);
      this.tableLayoutPanel1.Controls.Add((Control) this.tabControl1, 0, 1);
      this.tableLayoutPanel1.Dock = DockStyle.Fill;
      this.tableLayoutPanel1.Location = new Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 3;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 59f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 175f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 221f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel1.Size = new Size(211, 280);
      this.tableLayoutPanel1.TabIndex = 0;
      this.panel1.Controls.Add((Control) this.label1);
      this.panel1.Controls.Add((Control) this.comboBox1);
      this.panel1.Controls.Add((Control) this.checkBox1);
      this.panel1.Dock = DockStyle.Fill;
      this.panel1.Location = new Point(3, 3);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(205, 53);
      this.panel1.TabIndex = 0;
      this.label1.Anchor = AnchorStyles.Top;
      this.label1.AutoSize = true;
      this.label1.Location = new Point(36, 7);
      this.label1.Name = "label1";
      this.label1.Size = new Size(66, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Target Page";
      this.comboBox1.Anchor = AnchorStyles.Top;
      this.comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox1.Location = new Point(108, 4);
      this.comboBox1.MaxLength = 2;
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new Size(61, 21);
      this.comboBox1.TabIndex = 1;
      this.comboBox1.SelectedIndexChanged += new EventHandler(this.comboBox1_SelectedIndexChanged);
      this.checkBox1.Anchor = AnchorStyles.Top;
      this.checkBox1.AutoSize = true;
      this.checkBox1.Location = new Point(44, 31);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new Size(116, 17);
      this.checkBox1.TabIndex = 2;
      this.checkBox1.Text = "Enable Screen Exit";
      this.checkBox1.UseVisualStyleBackColor = true;
      this.checkBox1.CheckedChanged += new EventHandler(this.checkBox1_CheckedChanged);
      this.panel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.panel2.Controls.Add((Control) this.button1);
      this.panel2.Controls.Add((Control) this.button2);
      this.panel2.Location = new Point(43, 237);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(165, 29);
      this.panel2.TabIndex = 2;
      this.button1.Enabled = false;
      this.button1.Location = new Point(3, 3);
      this.button1.Name = "button1";
      this.button1.Size = new Size(75, 23);
      this.button1.TabIndex = 0;
      this.button1.Text = "Apply";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.button2.Enabled = false;
      this.button2.Location = new Point(84, 3);
      this.button2.Name = "button2";
      this.button2.Size = new Size(75, 23);
      this.button2.TabIndex = 1;
      this.button2.Text = "Discard";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new EventHandler(this.button2_Click);
      this.AutoHidePortion = 250.0;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(211, 280);
      this.Controls.Add((Control) this.tableLayoutPanel1);
      //this.DefaultFloatWindowSize = new Size(224, 297);
      this.DockAreas = DockAreas.Float | DockAreas.DockLeft | DockAreas.DockRight;
      this.Enabled = false;
      this.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
      this.Name = "ScreenExitEditor";
      this.ShowHint = DockState.DockRightAutoHide;
      this.Text = "ScreenExitEditor";
      this.tabControl1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.tabPage1.PerformLayout();
      this.tabPage2.ResumeLayout(false);
      this.tabPage2.PerformLayout();
      this.tableLayoutPanel1.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    private class EditCommand : LevelTab.ICommand
    {
      private ScreenExitEditor target;
      private int screenId;
      private Level.ScreenExit oldExit;
      private Level.ScreenExit newExit;

      public EditCommand(ScreenExitEditor target, int screenId, Level.ScreenExit oldExit, Level.ScreenExit newExit)
      {
        this.target = target;
        this.screenId = screenId;
        this.oldExit = oldExit;
        this.newExit = newExit;
      }

      public void Redo()
      {
        this.target.UndoRedo(this.screenId, ref this.newExit);
      }

      public void Undo()
      {
        this.target.UndoRedo(this.screenId, ref this.oldExit);
      }
    }
  }
