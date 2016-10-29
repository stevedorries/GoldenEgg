
// Type: Library.Font

// MVID: 7AA6A484-F524-42F2-9571-0947D386B578
// Assembly location: C:\Documents and Settings\THE RAIN\Desktop\ge.exe

using System;

namespace Library
{
  internal class Font : IDisposable
  {
    private IntPtr _hFont;
    private bool disposed;

    public IntPtr Handle
    {
      get
      {
        return this._hFont;
      }
    }

    public Font(string fontName)
    {
      this._hFont = Win32.CreateFont(0, 0, 0, 0, 0, 0U, 0U, 0U, 0U, 2U, 0U, 0U, 0U, fontName);
    }

    public Font(int height, string fontName)
    {
      this._hFont = Win32.CreateFont(height, 0, 0, 0, 0, 0U, 0U, 0U, 0U, 2U, 0U, 0U, 0U, fontName);
    }

    ~Font()
    {
      this.Dispose(false);
    }

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize( this);
    }

    private void Dispose(bool disposing)
    {
      if (this.disposed)
        return;
      int num = disposing ? 1 : 0;
      if (this._hFont != (IntPtr) null)
      {
        Win32.DeleteObject(this._hFont);
        this._hFont = (IntPtr) null;
      }
      this.disposed = true;
    }
  }
}
