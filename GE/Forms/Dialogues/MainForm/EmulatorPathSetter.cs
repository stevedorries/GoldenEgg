
// Type: GE.Forms.Dialogues.MainForm.EmulatorPathSetter

// MVID: 7AA6A484-F524-42F2-9571-0947D386B578
// Assembly location: C:\Documents and Settings\THE RAIN\Desktop\ge.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GE.Forms.Dialogues.MainForm
{
  public class EmulatorPathSetter : Form
  {
    private IContainer components;
    private TextBox textBox1;
    private Button button1;
    private Button button2;
    private Button button3;

    public string Path
    {
      get
      {
        return this.textBox1.Text;
      }
    }

    public EmulatorPathSetter(string path)
    {
      this.InitializeComponent();
      this.textBox1.Text = path;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Filter = "Executable Files (*.exe)|*.exe|All Files (*.*)|*.*";
      if (openFileDialog.ShowDialog() != DialogResult.OK)
        return;
      this.textBox1.Text = openFileDialog.FileName;
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
      this.textBox1 = new TextBox();
      this.button1 = new Button();
      this.button2 = new Button();
      this.button3 = new Button();
      this.SuspendLayout();
      this.textBox1.Location = new Point(13, 14);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(183, 20);
      this.textBox1.TabIndex = 0;
      this.button1.Location = new Point(205, 12);
      this.button1.Name = "button1";
      this.button1.Size = new Size(75, 25);
      this.button1.TabIndex = 1;
      this.button1.Text = "Browse";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.button2.DialogResult = DialogResult.OK;
      this.button2.Location = new Point(64, 44);
      this.button2.Name = "button2";
      this.button2.Size = new Size(75, 25);
      this.button2.TabIndex = 2;
      this.button2.Text = "OK";
      this.button2.UseVisualStyleBackColor = true;
      this.button3.DialogResult = DialogResult.Cancel;
      this.button3.Location = new Point(153, 44);
      this.button3.Name = "button3";
      this.button3.Size = new Size(75, 25);
      this.button3.TabIndex = 3;
      this.button3.Text = "Cancel";
      this.button3.UseVisualStyleBackColor = true;
      this.AcceptButton = (IButtonControl) this.button2;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.button3;
      this.ClientSize = new Size(292, 82);
      this.Controls.Add((Control) this.button3);
      this.Controls.Add((Control) this.button2);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.textBox1);
      this.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "EmulatorPathSetter";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Set up Emulator Path";
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
