
// Type: Library.Controls.HexTextBox

// MVID: 7AA6A484-F524-42F2-9571-0947D386B578
// Assembly location: C:\Documents and Settings\THE RAIN\Desktop\ge.exe

using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Library.Controls
{
  public class HexTextBox : TextBox
  {
    protected override void WndProc(ref Message m)
    {
      switch (m.Msg)
      {
        case 258:
          char c1 = Convert.ToChar((int) m.WParam);
          if (!char.IsControl(c1) && (48 > (int) c1 || (int) c1 > 57) && ((97 > (int) c1 || (int) c1 > 102) && (65 > (int) c1 || (int) c1 > 70)))
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
            else if (48 <= (int) c2 && (int) c2 <= 57 || 97 <= (int) c2 && (int) c2 <= 102 || 65 <= (int) c2 && (int) c2 <= 70)
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
}
