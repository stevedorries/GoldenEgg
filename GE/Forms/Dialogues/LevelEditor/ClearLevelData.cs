
// Type: GE.Forms.Dialogues.LevelEditor.ClearLevelData

// MVID: 7AA6A484-F524-42F2-9571-0947D386B578
// Assembly location: C:\Documents and Settings\THE RAIN\Desktop\ge.exe

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GE.Forms.Dialogues.LevelEditor
{
  public class ClearLevelData : Form
  {
    private IContainer components;
    private GroupBox groupBox1;
    private CheckBox checkBox3;
    private CheckBox checkBox2;
    private CheckBox checkBox1;
    private Button button1;
    private Button button2;

    public bool ClearObject
    {
      get
      {
        return this.checkBox1.Checked;
      }
    }

    public bool ClearSprite
    {
      get
      {
        return this.checkBox2.Checked;
      }
    }

    public bool ClearExit
    {
      get
      {
        return this.checkBox3.Checked;
      }
    }

    public ClearLevelData()
    {
      this.InitializeComponent();
    }

    protected override void OnClosing(CancelEventArgs e)
    {
      if (this.DialogResult == DialogResult.OK)
      {
        if (!this.ClearObject && !this.ClearSprite && !this.ClearExit)
          this.DialogResult = DialogResult.Cancel;
        else if (MessageBox.Show("This operation cannot be undone. Do you proceed?", "Golden Egg", MessageBoxButtons.YesNo) == DialogResult.No)
        {
          e.Cancel = true;
          return;
        }
      }
      base.OnClosing(e);
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
      this.groupBox1 = new GroupBox();
      this.checkBox3 = new CheckBox();
      this.checkBox2 = new CheckBox();
      this.checkBox1 = new CheckBox();
      this.button1 = new Button();
      this.button2 = new Button();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      this.groupBox1.Controls.Add((Control) this.checkBox3);
      this.groupBox1.Controls.Add((Control) this.checkBox2);
      this.groupBox1.Controls.Add((Control) this.checkBox1);
      this.groupBox1.Location = new Point(12, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(159, 91);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Choose What to Clear";
      this.checkBox3.AutoSize = true;
      this.checkBox3.Location = new Point(6, 65);
      this.checkBox3.Name = "checkBox3";
      this.checkBox3.Size = new Size(111, 16);
      this.checkBox3.TabIndex = 2;
      this.checkBox3.Text = "Screen Exit Data";
      this.checkBox3.UseVisualStyleBackColor = true;
      this.checkBox2.AutoSize = true;
      this.checkBox2.Location = new Point(6, 42);
      this.checkBox2.Name = "checkBox2";
      this.checkBox2.Size = new Size(82, 16);
      this.checkBox2.TabIndex = 1;
      this.checkBox2.Text = "Sprite Data";
      this.checkBox2.UseVisualStyleBackColor = true;
      this.checkBox1.AutoSize = true;
      this.checkBox1.Location = new Point(6, 19);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new Size(85, 16);
      this.checkBox1.TabIndex = 0;
      this.checkBox1.Text = "Object Data";
      this.checkBox1.UseVisualStyleBackColor = true;
      this.button1.DialogResult = DialogResult.OK;
      this.button1.Location = new Point(13, 110);
      this.button1.Name = "button1";
      this.button1.Size = new Size(75, 23);
      this.button1.TabIndex = 1;
      this.button1.Text = "OK";
      this.button1.UseVisualStyleBackColor = true;
      this.button2.DialogResult = DialogResult.Cancel;
      this.button2.Location = new Point(94, 110);
      this.button2.Name = "button2";
      this.button2.Size = new Size(75, 23);
      this.button2.TabIndex = 2;
      this.button2.Text = "Cancel";
      this.button2.UseVisualStyleBackColor = true;
      this.AcceptButton = (IButtonControl) this.button1;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.button2;
      this.ClientSize = new Size(183, 144);
      this.Controls.Add((Control) this.button2);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.groupBox1);
      this.Font = new Font("Microsoft Sans Serif", 8.25f);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ClearLevelData";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Clear Level Data";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
