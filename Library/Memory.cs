
// Type: Library.Memory

// MVID: 7AA6A484-F524-42F2-9571-0947D386B578
// Assembly location: C:\Documents and Settings\THE RAIN\Desktop\ge.exe

namespace Library
{
  internal class Memory
  {
    public static unsafe void Clear(byte[] array, int count)
    {
      fixed (byte* numPtr1 = array)
      {
        byte* numPtr2 = numPtr1;
        while (count-- != 0)
          *numPtr2++ = (byte) 0;
      }
    }

    public static unsafe void Clear(ushort[] array, int count)
    {
      fixed (ushort* numPtr1 = array)
      {
        ushort* numPtr2 = numPtr1;
        while (count-- != 0)
          *numPtr2++ = (ushort) 0;
      }
    }

    public static unsafe void Clear(uint[] array, int count)
    {
      fixed (uint* numPtr1 = array)
      {
        uint* numPtr2 = numPtr1;
        while (count-- != 0)
          *numPtr2++ = 0U;
      }
    }

    public static unsafe void Clear(void* pointer, int count)
    {
      uint* numPtr1 = (uint*) pointer;
      while (count >= 4)
      {
        *numPtr1++ = 0U;
        count -= 4;
      }
      if (count == 0)
        return;
      byte* numPtr2 = (byte*) numPtr1;
      while (count-- != 0)
        *numPtr2++ = (byte) 0;
    }

    public static unsafe void Copy(void* dest, void* src, int count)
    {
      uint* numPtr1 = (uint*) dest;
      uint* numPtr2 = (uint*) src;
      while (count >= 4)
      {
        *numPtr1++ = *numPtr2++;
        count -= 4;
      }
      if (count == 0)
        return;
      byte* numPtr3 = (byte*) numPtr1;
      byte* numPtr4 = (byte*) numPtr2;
      while (count-- != 0)
        *numPtr3++ = *numPtr4++;
    }

    public static unsafe void Set(byte[] array, int count, byte data)
    {
      if (count == 0)
        return;
      fixed (byte* numPtr1 = array)
      {
        byte* numPtr2 = numPtr1;
        while (count-- != 0)
          *numPtr2++ = data;
      }
    }

    public static unsafe void Set(byte[] array, int index, int count, byte data)
    {
      if (count == 0)
        return;
      fixed (byte* numPtr1 = &array[index])
      {
        byte* numPtr2 = numPtr1;
        while (count-- != 0)
          *numPtr2++ = data;
      }
    }

    public static unsafe void Set(ushort[] array, int count, ushort data)
    {
      if (count == 0)
        return;
      fixed (ushort* numPtr1 = array)
      {
        ushort* numPtr2 = numPtr1;
        while (count-- != 0)
          *numPtr2++ = data;
      }
    }

    public static unsafe void Set(ushort[] array, int index, int count, ushort data)
    {
      if (count == 0)
        return;
      fixed (ushort* numPtr1 = &array[index])
      {
        ushort* numPtr2 = numPtr1;
        while (count-- != 0)
          *numPtr2++ = data;
      }
    }

    public static unsafe void Set(uint[] array, int count, uint data)
    {
      if (count == 0)
        return;
      fixed (uint* numPtr1 = array)
      {
        uint* numPtr2 = numPtr1;
        while (count-- != 0)
          *numPtr2++ = data;
      }
    }

    public static unsafe void Set(uint[] array, int index, int count, uint data)
    {
      if (count == 0)
        return;
      fixed (uint* numPtr1 = &array[index])
      {
        uint* numPtr2 = numPtr1;
        while (count-- != 0)
          *numPtr2++ = data;
      }
    }

    public static unsafe void Set(void* pointer, int count, byte data)
    {
      if (count == 0)
        return;
      uint num = (uint) ((int) data | (int) data << 8 | (int) data << 16 | (int) data << 24);
      uint* numPtr1 = (uint*) pointer;
      while (count >= 4)
      {
        *numPtr1++ = num;
        count -= 4;
      }
      if (count == 0)
        return;
      byte* numPtr2 = (byte*) numPtr1;
      while (count-- != 0)
        *numPtr2++ = data;
    }
  }
}
