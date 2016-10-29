
// Type: Library.Controls.DoubleBufferedPanel

// MVID: 7AA6A484-F524-42F2-9571-0947D386B578
// Assembly location: C:\Documents and Settings\THE RAIN\Desktop\ge.exe

using System.Windows.Forms;

namespace Library.Controls
{
  public class DoubleBufferedPanel : Panel
  {
    public DoubleBufferedPanel()
    {
      this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
      this.UpdateStyles();
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
    }
  }
}
