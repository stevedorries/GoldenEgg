
// Type: GE.Forms.Dialogues.LevelEditor.LevelSelector

// MVID: 7AA6A484-F524-42F2-9571-0947D386B578
// Assembly location: C:\Documents and Settings\THE RAIN\Desktop\ge.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GE.Forms.Dialogues.LevelEditor
{
  public class LevelSelector : Form
  {
    private bool internal_update;
    private IContainer components;
    private Label label1;
    private Button button1;
    private Button button2;
    private ListView listView1;
    private Library.Controls.HexTextBox textBox1;
    private ColumnHeader columnHeader1;
    private ColumnHeader columnHeader2;

    public int LevelNumber
    {
      get
      {
        try
        {
          return (int) Convert.ToInt16(this.textBox1.Text, 16);
        }
        catch
        {
          return -1;
        }
      }
    }

    public LevelSelector(string[] levelNameList)
    {
      this.InitializeComponent();
      this.listView1.BeginUpdate();
      for (int index = 0; index < levelNameList.Length; ++index)
        this.listView1.Items.Add(new ListViewItem(new string[2]
        {
          index.ToString("X2"),
          levelNameList[index]
        }));
      this.listView1.EndUpdate();
    }

    protected override void OnClosing(CancelEventArgs e)
    {
      if (this.DialogResult == DialogResult.OK)
      {
        if (this.LevelNumber < 0)
        {
          int num = (int) MessageBox.Show("The level number you specified is invalid.", "Invalid Level Number");
          e.Cancel = true;
        }
        else if (this.LevelNumber > 221)
        {
          int num = (int) MessageBox.Show("The level number you specified is out of range.", "Invalid Level Number");
          e.Cancel = true;
        }
      }
      base.OnClosing(e);
    }

    private void listView1_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.internal_update)
        return;
      foreach (int num in this.listView1.SelectedIndices)
        this.textBox1.Text = num.ToString("X2");
    }

    private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      this.button1.PerformClick();
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
      this.label1 = new Label();
      this.button1 = new Button();
      this.button2 = new Button();
      this.listView1 = new ListView();
      this.columnHeader1 = new ColumnHeader();
      this.columnHeader2 = new ColumnHeader();
      this.textBox1 = new Library.Controls.HexTextBox();
      this.SuspendLayout();
      this.label1.AutoSize = true;
      this.label1.Location = new Point(75, 15);
      this.label1.Name = "label1";
      this.label1.Size = new Size(79, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Level Number :";
      this.button1.Anchor = AnchorStyles.Bottom;
      this.button1.DialogResult = DialogResult.OK;
      this.button1.Location = new Point(122, 326);
      this.button1.Name = "button1";
      this.button1.Size = new Size(75, 23);
      this.button1.TabIndex = 3;
      this.button1.Text = "OK";
      this.button1.UseVisualStyleBackColor = true;
      this.button2.Anchor = AnchorStyles.Bottom;
      this.button2.DialogResult = DialogResult.Cancel;
      this.button2.Location = new Point(205, 326);
      this.button2.Name = "button2";
      this.button2.Size = new Size(75, 23);
      this.button2.TabIndex = 4;
      this.button2.Text = "Cancel";
      this.button2.UseVisualStyleBackColor = true;
      this.listView1.Columns.AddRange(new ColumnHeader[2]
      {
        this.columnHeader1,
        this.columnHeader2
      });
      this.listView1.FullRowSelect = true;
      this.listView1.HideSelection = false;
      this.listView1.Location = new Point(12, 38);
      this.listView1.MultiSelect = false;
      this.listView1.Name = "listView1";
      this.listView1.Size = new Size(268, 278);
      this.listView1.TabIndex = 5;
      this.listView1.UseCompatibleStateImageBehavior = false;
      this.listView1.View = View.Details;
      this.listView1.SelectedIndexChanged += new EventHandler(this.listView1_SelectedIndexChanged);
      this.listView1.MouseDoubleClick += new MouseEventHandler(this.listView1_MouseDoubleClick);
      this.columnHeader1.Text = "Index";
      this.columnHeader1.Width = 46;
      this.columnHeader2.Text = "Level Name";
      this.columnHeader2.Width = 201;
      this.textBox1.CharacterCasing = CharacterCasing.Upper;
      this.textBox1.Location = new Point(160, 12);
      this.textBox1.MaxLength = 2;
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(58, 20);
      this.textBox1.TabIndex = 1;
      this.AcceptButton = (IButtonControl) this.button1;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.button2;
      this.ClientSize = new Size(292, 361);
      this.Controls.Add((Control) this.listView1);
      this.Controls.Add((Control) this.button2);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.textBox1);
      this.Controls.Add((Control) this.label1);
      this.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "LevelSelector";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.SizeGripStyle = SizeGripStyle.Hide;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Open a Level by Number";
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
