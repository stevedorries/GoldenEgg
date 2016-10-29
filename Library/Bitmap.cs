
// Type: Library.Bitmap

// MVID: 7AA6A484-F524-42F2-9571-0947D386B578
// Assembly location: C:\Documents and Settings\THE RAIN\Desktop\ge.exe

using System;

namespace Library
{
  internal class Bitmap : IDisposable
  {
    private IntPtr _hDC;
    private IntPtr _hBitmap;
    private unsafe void* bits;
    private int _width;
    private int _height;
    private bool disposed;

    public IntPtr Handle
    {
      get
      {
        return this._hDC;
      }
    }

    public int Width
    {
      get
      {
        return this._width;
      }
    }

    public int Height
    {
      get
      {
        return this._height;
      }
    }

    ~Bitmap()
    {
      this.Dispose(false);
    }

    public unsafe uint* PixelBits(int x, int y)
    {
      return (uint*) ((IntPtr) this.bits +  x * 4 + (y * this.Width) * 4);
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
      if (this._hDC != (IntPtr) null)
      {
        Win32.DeleteDC(this._hDC);
        this._hDC = (IntPtr) null;
      }
      if (this._hBitmap != (IntPtr) null)
      {
        Win32.DeleteObject(this._hBitmap);
        this._hBitmap = (IntPtr) null;
      }
      this.disposed = true;
    }

    public unsafe bool Create(IntPtr hWnd, int width, int height)
    {
      int num1 = width & -16;
      if (num1 < width)
        num1 += 16;
      int num2 = height & -16;
      if (num2 < height)
        num2 += 16;
      if (this.Handle != (IntPtr) null && num1 == this._width && num2 == this._height)
        return false;
      this._width = num1;
      this._height = num2;
      Win32.BITMAPINFO pbmi = new Win32.BITMAPINFO();
      pbmi.bmiHeader.biSize = (uint) sizeof (Win32.BITMAPINFOHEADER);
      pbmi.bmiHeader.biWidth = num1;
      pbmi.bmiHeader.biHeight = -num2;
      pbmi.bmiHeader.biPlanes = (ushort) 1;
      pbmi.bmiHeader.biBitCount = (ushort) 32;
      pbmi.bmiHeader.biCompression = 0U;
      pbmi.bmiHeader.biSizeImage = 0U;
      pbmi.bmiHeader.biXPelsPerMeter = 0;
      pbmi.bmiHeader.biYPelsPerMeter = 0;
      pbmi.bmiHeader.biClrUsed = 0U;
      pbmi.bmiHeader.biClrImportant = 0U;
      if (this._hDC != (IntPtr) null)
      {
        Win32.DeleteDC(this._hDC);
        this._hDC = (IntPtr) null;
      }
      if (this._hBitmap != (IntPtr) null)
      {
        Win32.DeleteObject(this._hBitmap);
        this._hBitmap = (IntPtr) null;
      }
      this._hBitmap = Win32.CreateDIBSection((IntPtr) null, ref pbmi, 0U, ref this.bits, (IntPtr) null, 0U);
      if (this._hBitmap == (IntPtr) null)
        return false;
      IntPtr dc = Win32.GetDC(hWnd);
      this._hDC = Win32.CreateCompatibleDC(dc);
      Win32.ReleaseDC(hWnd, dc);
      if (!(this._hDC == (IntPtr) null) && !(Win32.SelectObject(this._hDC, this._hBitmap) == (IntPtr) null))
        return true;
      if (this._hDC != (IntPtr) null)
      {
        Win32.DeleteDC(this._hDC);
        this._hDC = (IntPtr) null;
      }
      Win32.DeleteObject(this._hBitmap);
      this._hBitmap = (IntPtr) null;
      return false;
    }

    public static unsafe void Blend(Bitmap dest, int x, int y, int cx, int cy, Bitmap src, int srcx, int srcy, ushort alpha = (ushort) 128)
    {
      if (x < 0)
      {
        if ((cx += x) <= 0 || (long) (srcx -= x) >= (long) src.Width)
          return;
        x = 0;
      }
      if (y < 0)
      {
        if ((cy += y) <= 0 || (long) (srcy -= y) >= (long) src.Height)
          return;
        y = 0;
      }
      double num1 = (double) alpha / 256.0;
      double num2 = 1.0 - num1;
      for (; (uint) y < (uint) dest.Height && (uint) srcy < (uint) src.Height && cy != 0; ++srcy)
      {
        byte* numPtr1 = (byte*) src.PixelBits(srcx, srcy);
        byte* numPtr2 = (byte*) dest.PixelBits(x, y);
        int num3 = x;
        int num4 = srcx;
        for (int index = cx; (uint) num3 < (uint) dest.Width && (uint) num4 < (uint) src.Width && index != 0; ++num4)
        {
          *(int*) numPtr2 = (int) (byte) ((double) *numPtr1 * num1 + (double) *numPtr2 * num2) | (int) (byte) ((double) numPtr1[1] * num1 + (double) numPtr2[1] * num2) << 8 | (int) (byte) ((double) numPtr1[2] * num1 + (double) numPtr2[2] * num2) << 16;
          numPtr2 += 4;
          numPtr1 += 4;
          --index;
          ++num3;
        }
        --cy;
        ++y;
      }
    }
  }
}
