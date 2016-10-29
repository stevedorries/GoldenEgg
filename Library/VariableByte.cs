
// Type: Library.VariableByte

// MVID: 7AA6A484-F524-42F2-9571-0947D386B578
// Assembly location: C:\Documents and Settings\THE RAIN\Desktop\ge.exe

using System;
using System.Runtime.InteropServices;

namespace Library
{
  public struct VariableByte
  {
    private byte _value;

    public byte u8
    {
      get
      {
        return this._value;
      }
      set
      {
        this._value = value;
      }
    }

    public unsafe ushort u16
    {
      get
      {
        fixed (byte* numPtr = &this._value)
          return *(ushort*) numPtr;
      }
      set
      {
        fixed (byte* numPtr = &this._value)
          *(short*) numPtr = (short) value;
      }
    }

    public unsafe uint u24
    {
      get
      {
        fixed (byte* numPtr = &this._value)
          return *(uint*) numPtr & 16777215U;
      }
      set
      {
        fixed (byte* numPtr = &this._value)
          *(int*) numPtr = (int) *(uint*) numPtr & -16777216 | (int) value & 16777215;
      }
    }

    public unsafe uint u32
    {
      get
      {
        fixed (byte* numPtr = &this._value)
          return *(uint*) numPtr;
      }
      set
      {
        fixed (byte* numPtr = &this._value)
          *(int*) numPtr = (int) value;
      }
    }

    public static implicit operator byte(VariableByte vb)
    {
      return vb._value;
    }

    public unsafe byte[] ToByteArray(int length)
    {
      byte[] destination = new byte[length];
      fixed (byte* numPtr = &this._value)
        Marshal.Copy((IntPtr) ((void*) numPtr), destination, 0, length);
      return destination;
    }

    public unsafe void CopyFrom(byte[] source, int startIndex, int length)
    {
      fixed (byte* numPtr = &this._value)
        Marshal.Copy(source, startIndex, (IntPtr) ((void*) numPtr), length);
    }
  }
}
