
// Type: ge.Program

// MVID: 7AA6A484-F524-42F2-9571-0947D386B578
// Assembly location: C:\Documents and Settings\THE RAIN\Desktop\ge.exe

using GE.Forms;
using System;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices; 

namespace ge
{
  internal static class Program
  {
    [STAThread]
    private static void Main(string[] args)
    {
      string rom_path = (string) null;
      if (args.Length >= 1)
        rom_path = Path.GetFullPath(args[0]);
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      CustomExceptionHandler eh = new CustomExceptionHandler();
      Application.ThreadException += new ThreadExceptionEventHandler(eh.OnThreadException);
      Application.SetUnhandledExceptionMode(System.Windows.Forms.UnhandledExceptionMode.CatchException);
      Thread.CurrentThread.Name = "UI";
      System.Diagnostics.Debug.WriteLine(Thread.CurrentThread.ManagedThreadId);
      Application.Run((Form) new MainForm(rom_path));
    }
  }
}
