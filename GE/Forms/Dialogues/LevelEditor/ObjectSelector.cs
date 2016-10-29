
// Type: GE.Forms.Dialogues.LevelEditor.ObjectSelector

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

  public class ObjectSelector : DockContent
  {
    private bool internalDisableUpdate = true;
    private IContainer components;
    private TableLayoutPanel tableLayoutPanel1;
    private TabControl tabControl1;
    private TabPage tabPage1;
    private TabPage tabPage2;
    private ListBox listBox1;
    private Label label1;
    private Label label2;
    private Button button2;
    private Button button1;
    private CheckedListBox checkedListBox1;
    private TextBox textBox1;
    private Label label3;
    private TextBox textBox2;
    private Label label4;
    private Level.ObjectFilter objectFilter;

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

    public unsafe ObjectSelector()
    {
      this.InitializeComponent();
      for (int index = 0; index < this.checkedListBox1.Items.Count; ++index)
        this.checkedListBox1.SetItemChecked(index, true);
      int[] numArray = new int[2]
      {
        18,
        34
      };
      fixed (int* numPtr = numArray)
        Win32.SendMessage(this.listBox1.Handle, 402U, (IntPtr) numArray.Length, (IntPtr) ((void*) numPtr));
      this.UpdateListBox();
      this.internalDisableUpdate = false;
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
      this.listBox1 = new ListBox();
      this.label1 = new Label();
      this.tabControl1 = new TabControl();
      this.tabPage1 = new TabPage();
      this.textBox1 = new TextBox();
      this.label3 = new Label();
      this.checkedListBox1 = new CheckedListBox();
      this.button2 = new Button();
      this.button1 = new Button();
      this.label2 = new Label();
      this.tabPage2 = new TabPage();
      this.textBox2 = new TextBox();
      this.label4 = new Label();
      this.tableLayoutPanel1.SuspendLayout();
      this.tabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.tabPage2.SuspendLayout();
      this.SuspendLayout();
      this.tableLayoutPanel1.ColumnCount = 2;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 89.91936f));
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10.08065f));
      this.tableLayoutPanel1.Controls.Add((Control) this.listBox1, 0, 1);
      this.tableLayoutPanel1.Controls.Add((Control) this.label1, 0, 2);
      this.tableLayoutPanel1.Controls.Add((Control) this.tabControl1, 0, 0);
      this.tableLayoutPanel1.Dock = DockStyle.Fill;
      this.tableLayoutPanel1.Location = new Point(0, 0);
      this.tableLayoutPanel1.Margin = new Padding(0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 3;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 193f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 62f));
      this.tableLayoutPanel1.Size = new Size(248, 444);
      this.tableLayoutPanel1.TabIndex = 0;
      this.tableLayoutPanel1.SetColumnSpan((Control) this.listBox1, 2);
      this.listBox1.Dock = DockStyle.Fill;
      this.listBox1.FormattingEnabled = true;
      this.listBox1.HorizontalScrollbar = true;
      this.listBox1.Location = new Point(3, 196);
      this.listBox1.Name = "listBox1";
      this.listBox1.Size = new Size(242, 183);
      this.listBox1.TabIndex = 1;
      this.listBox1.SelectedIndexChanged += new EventHandler(this.listBox1_SelectedIndexChanged);
      this.listBox1.MouseDown += new MouseEventHandler(this.listBox1_MouseDown);
      this.tableLayoutPanel1.SetColumnSpan((Control) this.label1, 2);
      this.label1.Dock = DockStyle.Fill;
      this.label1.Location = new Point(3, 382);
      this.label1.Name = "label1";
      this.label1.Size = new Size(242, 62);
      this.label1.TabIndex = 2;
      this.tableLayoutPanel1.SetColumnSpan((Control) this.tabControl1, 2);
      this.tabControl1.Controls.Add((Control) this.tabPage1);
      this.tabControl1.Controls.Add((Control) this.tabPage2);
      this.tabControl1.Dock = DockStyle.Fill;
      this.tabControl1.Location = new Point(3, 3);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new Size(242, 187);
      this.tabControl1.TabIndex = 0;
      this.tabControl1.SelectedIndexChanged += new EventHandler(this.tabControl1_SelectedIndexChanged);
      this.tabPage1.Controls.Add((Control) this.textBox1);
      this.tabPage1.Controls.Add((Control) this.label3);
      this.tabPage1.Controls.Add((Control) this.checkedListBox1);
      this.tabPage1.Controls.Add((Control) this.button2);
      this.tabPage1.Controls.Add((Control) this.button1);
      this.tabPage1.Controls.Add((Control) this.label2);
      this.tabPage1.Location = new Point(4, 22);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new Padding(3);
      this.tabPage1.Size = new Size(234, 161);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "Object";
      this.tabPage1.UseVisualStyleBackColor = true;
      this.textBox1.Location = new Point(78, 135);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(150, 20);
      this.textBox1.TabIndex = 5;
      this.textBox1.TextChanged += new EventHandler(this.textBox1_TextChanged);
      this.label3.AutoSize = true;
      this.label3.Location = new Point(6, 138);
      this.label3.Name = "label3";
      this.label3.Size = new Size(65, 13);
      this.label3.TabIndex = 4;
      this.label3.Text = "String Filter :";
      this.checkedListBox1.CheckOnClick = true;
      this.checkedListBox1.FormattingEnabled = true;
      this.checkedListBox1.Items.AddRange(new object[21]
      {
         "Object",
         "Extended Object",
         "Cave 1",
         "Forest 1",
         "Pond",
         "3D Stone",
         "Snow",
         "Jungle",
         "Castle 1",
         "Grass 1",
         "Cave 2",
         "Forest 2",
         "Castle 2",
         "Sewer",
         "Flower Garden",
         "Sky",
         "Castle 3",
         "Grass 2",
         "Kamek's Room",
         "Animated",
         "Misc."
      });
      this.checkedListBox1.Location = new Point(6, 34);
      this.checkedListBox1.Name = "checkedListBox1";
      this.checkedListBox1.Size = new Size(222, 94);
      this.checkedListBox1.TabIndex = 3;
      this.checkedListBox1.ItemCheck += new ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
      this.button2.Location = new Point(154, 8);
      this.button2.Name = "button2";
      this.button2.Size = new Size(60, 20);
      this.button2.TabIndex = 2;
      this.button2.Text = "Current";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new EventHandler(this.button2_Click);
      this.button1.Location = new Point(88, 8);
      this.button1.Name = "button1";
      this.button1.Size = new Size(60, 20);
      this.button1.TabIndex = 1;
      this.button1.Text = "All";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.label2.AutoSize = true;
      this.label2.Location = new Point(20, 12);
      this.label2.Name = "label2";
      this.label2.Size = new Size(62, 13);
      this.label2.TabIndex = 0;
      this.label2.Text = "Type Filter :";
      this.tabPage2.Controls.Add((Control) this.textBox2);
      this.tabPage2.Controls.Add((Control) this.label4);
      this.tabPage2.Location = new Point(4, 22);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new Padding(3);
      this.tabPage2.Size = new Size(234, 161);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "Sprite";
      this.tabPage2.UseVisualStyleBackColor = true;
      this.textBox2.Location = new Point(78, 135);
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new Size(150, 20);
      this.textBox2.TabIndex = 7;
      this.textBox2.TextChanged += new EventHandler(this.textBox2_TextChanged);
      this.label4.AutoSize = true;
      this.label4.Location = new Point(6, 138);
      this.label4.Name = "label4";
      this.label4.Size = new Size(65, 13);
      this.label4.TabIndex = 6;
      this.label4.Text = "String Filter :";
      this.AutoHidePortion = 250.0;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(248, 444);
      this.Controls.Add((Control) this.tableLayoutPanel1);
      //this.DefaultFloatWindowSize = new Size(256, 470);
      this.DockAreas = DockAreas.Float | DockAreas.DockLeft | DockAreas.DockRight;
      this.Enabled = false;
      this.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
      this.MinimumSize = new Size(8, 400);
      this.Name = "ObjectSelector";
      this.ShowHint = DockState.Float;
      this.Text = "Object and Sprite Selector";
      this.FormClosing += new FormClosingEventHandler(this.ObjectSelector_FormClosing);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tabControl1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.tabPage1.PerformLayout();
      this.tabPage2.ResumeLayout(false);
      this.tabPage2.PerformLayout();
      this.ResumeLayout(false);
    }

    private int strifind(string str, int startIndex, string key)
    {
      for (int indexA = startIndex; indexA <= str.Length - key.Length; ++indexA)
      {
        if (string.Compare(str, indexA, key, 0, key.Length, true) == 0)
          return indexA;
      }
      return -1;
    }

    public void UpdateListBox()
    {
      if (this.internalDisableUpdate)
        return;
      this.listBox1.BeginUpdate();
      this.listBox1.Items.Clear();
      if (this.tabControl1.SelectedIndex == 0)
      {
        for (int index = 0; index < Level.ObjectInformation.Label.Length; ++index)
        {
          if ((this.objectFilter & Level.ObjectFilter.OBJ) != (Level.ObjectFilter) 0 && (Level.ObjectInformation.Filter[index] & this.objectFilter) != (Level.ObjectFilter) 0 && (!(this.textBox1.Text != "") || this.strifind(Level.ObjectInformation.Label[index], 4, this.textBox1.Text) >= 0))
            this.listBox1.Items.Add( Level.ObjectInformation.Label[index]);
        }
        for (int index = 0; index < Level.ExObjectInformation.Label.Length; ++index)
        {
          if ((this.objectFilter & Level.ObjectFilter.EXOBJ) != (Level.ObjectFilter) 0 && (Level.ExObjectInformation.Filter[index] & this.objectFilter) != (Level.ObjectFilter) 0 && (!(this.textBox1.Text != "") || this.strifind(Level.ExObjectInformation.Label[index], 6, this.textBox1.Text) >= 0))
            this.listBox1.Items.Add( Level.ExObjectInformation.Label[index]);
        }
      }
      else
      {
        for (int index = 0; index < Level.SpriteInformation.Label.Length; ++index)
        {
          if (!(this.textBox2.Text != "") || this.strifind(Level.SpriteInformation.Label[index], 4, this.textBox2.Text) >= 0)
            this.listBox1.Items.Add( Level.SpriteInformation.Label[index]);
        }
      }
      this.listBox1.EndUpdate();
    }

    private void UpdateDescription()
    {
      int selectedIndex = this.listBox1.SelectedIndex;
      if (selectedIndex < 0)
        return;
      string str = this.listBox1.Items[selectedIndex] as string;
      if (this.tabControl1.SelectedIndex == 0)
      {
        int index = int.Parse(str.Substring(0, 2), NumberStyles.AllowHexSpecifier);
        this.label1.Text = (int) str[3] == 9 ? Level.ObjectInformation.Description[index - 1] : Level.ExObjectInformation.Description[index];
      }
      else
      {
        int index = int.Parse(str.Substring(0, 3), NumberStyles.AllowHexSpecifier);
        this.label1.Text = Level.SpriteInformation.Description[index];
      }
    }

    private void ObjectSelector_FormClosing(object sender, FormClosingEventArgs e)
    {
      e.Cancel = true;
      this.levelEditor.CheckObjSprSelector(false);
      this.Hide();
    }

    private void listBox1_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      int selectedIndex = this.listBox1.SelectedIndex;
      if (selectedIndex < 0)
        return;
      this.UpdateDescription();
      if (this.DockPanel.DocumentsCount == 0)
      {
        int num1 = (int) this.DoDragDrop( 0, DragDropEffects.None);
      }
      else
      {
        string str = this.listBox1.Items[selectedIndex] as string;
        if (this.tabControl1.SelectedIndex == 0)
        {
          Level.Object @object = new Level.Object();
          if ((int) str[3] == 9)
          {
            @object.num = byte.Parse(str.Substring(0, 2), NumberStyles.AllowHexSpecifier);
            @object.width = (ushort) ((int) Level.ObjectInformation.DefaultSize[(int) @object.num - 1] >> 4 | ((int) (sbyte) Level.ObjectInformation.DefaultSize[(int) @object.num - 1] < 0 ? 65520 : 0));
            @object.height = (ushort) ((int) Level.ObjectInformation.DefaultSize[(int) @object.num - 1] & 15 | (((int) Level.ObjectInformation.DefaultSize[(int) @object.num - 1] & 8) != 0 ? 65520 : 0));
          }
          else
          {
            @object.exnum = byte.Parse(str.Substring(0, 2), NumberStyles.AllowHexSpecifier);
            @object.width = @object.height = (ushort) 1;
          }
          int num2 = (int) this.DoDragDrop( @object, DragDropEffects.All);
        }
        else
        {
          int num3 = (int) this.DoDragDrop( new Level.Sprite()
          {
            num = ushort.Parse(str.Substring(0, 3), NumberStyles.AllowHexSpecifier)
          }, DragDropEffects.All);
        }
      }
    }

    private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
    {
      if (e.NewValue == CheckState.Checked)
        this.objectFilter |= (Level.ObjectFilter) (1 << e.Index);
      else
        this.objectFilter &= (Level.ObjectFilter) ~(1 << e.Index);
      this.UpdateListBox();
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
      this.UpdateListBox();
    }

    private void textBox2_TextChanged(object sender, EventArgs e)
    {
      this.UpdateListBox();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.internalDisableUpdate = true;
      for (int index = 0; index < this.checkedListBox1.Items.Count; ++index)
        this.checkedListBox1.SetItemChecked(index, true);
      this.internalDisableUpdate = false;
      this.UpdateListBox();
    }

    private void button2_Click(object sender, EventArgs e)
    {
      if (this.DockPanel.DocumentsCount == 0)
        return;
      this.internalDisableUpdate = true;
      this.objectFilter = this.objectFilter & (Level.ObjectFilter.OBJ | Level.ObjectFilter.EXOBJ | Level.ObjectFilter.ANIMATED) | ((int) this.levelTab.LevelHeader[9] == 10 ? Level.ObjectFilter.KAMEK : (Level.ObjectFilter) (4 << (int) this.levelTab.LevelHeader[1]));
      for (int index = 0; index < this.checkedListBox1.Items.Count; ++index)
        this.checkedListBox1.SetItemChecked(index, (this.objectFilter & (Level.ObjectFilter) (1 << index)) != (Level.ObjectFilter) 0);
      this.internalDisableUpdate = false;
      this.UpdateListBox();
    }

    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.UpdateDescription();
    }

    private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.UpdateListBox();
    }
  }
