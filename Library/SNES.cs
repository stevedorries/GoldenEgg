
// Type: Library.SNES

// MVID: 7AA6A484-F524-42F2-9571-0947D386B578
// Assembly location: C:\Documents and Settings\THE RAIN\Desktop\ge.exe

using System;
using System.IO;
using System.Text;

namespace Library
{
  public class SNES
  {
    public class Color
    {
      public static uint ToRGB(ushort color)
      {
        return (uint) (((int) color & 31) << 19 | ((int) color & 992) << 6) | ((uint) color & 31744U) >> 7;
      }

      public static ushort FromBGR(uint color)
      {
        return (ushort) ((color & 248U) >> 3 | (color & 63488U) >> 6 | (color & 16252928U) >> 9);
      }

      public static ushort FromRGB(uint color)
      {
        return (ushort) ((uint) (((int) color & 248) << 7) | (color & 63488U) >> 6 | (color & 16252928U) >> 19);
      }
    }

    public enum CountryCode
    {
      Japan,
      NorthAmerica,
      AllOfEurope,
      Scandinavia,
      French,
      Dutch,
      Spanish,
      German,
      Italian,
      Chinese,
      Korean,
      Common,
      Canada,
      Brazil,
      Australia,
      OtherVariation1,
      OtherVariation2,
      OtherVariation3,
    }

    public class ROMFile
    {
      private byte[] _HeaderBuf = new byte[512];
      public const int HeaderSize = 512;
      public const int VRAMSize = 65536;
      public const int CGRAMSize = 256;
      private string _ROMPath;
      private SNES.ROMFile.LastErrors _LastError;
      private VariableByte[] _ROMBuf;
      private ushort _HasHeader;
      private SNES.ROMFile.ROMTypes _ROMType;

      public VariableByte[] ROM
      {
        get
        {
          return this._ROMBuf;
        }
      }

      public string Title
      {
        get
        {
          return Encoding.ASCII.GetString(this.ROM[ this.AddressSNEStoPC(65472U)].ToByteArray(21)).TrimEnd((char[]) null);
        }
      }

      public string GetLastError()
      {
        switch (this._LastError)
        {
          case SNES.ROMFile.LastErrors.CouldntOpenROMForReading:
            return "Couldn't open the ROM for reading";
          case SNES.ROMFile.LastErrors.CouldntOpenROMForWriting:
            return "Couldn't open the ROM for writing";
          case SNES.ROMFile.LastErrors.InvalidROM:
            return "Invalid SNES ROM";
          case SNES.ROMFile.LastErrors.Exception:
            return "Exception detected";
          default:
            return "";
        }
      }

      public unsafe bool Open(string path)
      {
        if (!File.Exists(path))
        {
          this._LastError = SNES.ROMFile.LastErrors.CouldntOpenROMForReading;
          return false;
        }
        else
        {
          try
          {
            byte[] source = File.ReadAllBytes(path);
            int num1 = 0;
            int num2 = 0;
            switch (source.Length & (int) short.MaxValue)
            {
              case 0:
                num2 += 3;
                break;
              case 512:
                num1 += 2;
                break;
            }
            uint num3 = 0U;
            for (int index = 0; index < 512; ++index)
              num3 += (uint) source[index];
            if (num3 < 2500U)
              num1 += 2;
            int[] numArray = new int[4];
            int num4 = 0;
            fixed (byte* numPtr = source)
            {
              int num5 = numArray[0] = this.ROMTypeScore(numPtr + 32704);
              if (num5 < (numArray[1] = this.ROMTypeScore(numPtr + 65472)))
              {
                num5 = numArray[1];
                num4 = 1;
              }
              if (num5 < (numArray[2] = this.ROMTypeScore(numPtr + 33216)))
              {
                num5 = numArray[2];
                num4 = 2;
              }
              if (num5 < (numArray[3] = this.ROMTypeScore(numPtr + 65984)))
                num4 = 3;
            }
            if (num4 >= 2)
              num1 += 2;
            this._HasHeader = num1 > num2 ? (ushort) 512 : (ushort) 0;
            if ((int) this._HasHeader != 0)
              Array.Copy((Array) source, (Array) this._HeaderBuf, 512);
            this._ROMType = numArray[(int) this._HasHeader == 0 ? 1 : 3] > numArray[(int) this._HasHeader == 0 ? 0 : 2] ? SNES.ROMFile.ROMTypes.HiROM : SNES.ROMFile.ROMTypes.LoROM;
            uint num6 = (uint) (1 << (int) source[(this.AddressSNEStoPC(65495U) + (uint) this._HasHeader)] + 10);
            if (num6 < 524288U || 4194304U < num6)
              throw new SNES.ROMFile.InvalidROMException();
            uint num7 = (uint) source.Length - (uint) this._HasHeader;
            if (num7 > num6)
              throw new SNES.ROMFile.InvalidROMException();
            this._ROMBuf = new VariableByte[num6];
            this.ROM[0].CopyFrom(source, (int) this._HasHeader, (int) num7);
            if (this._ROMType == SNES.ROMFile.ROMTypes.LoROM)
            {
              if (((int) this.ROM[32726].u8 & 240) == 16)
              {
                this._ROMType = SNES.ROMFile.ROMTypes.SuperFX;
                if (num6 > 2097152U)
                  throw new SNES.ROMFile.InvalidROMException();
              }
            }
          }
          catch (SNES.ROMFile.InvalidROMException ex)
          {
              System.Diagnostics.Debug.WriteLine(ex.Message);
            this._LastError = SNES.ROMFile.LastErrors.InvalidROM;
            return false;
          }
          catch (Exception ex)
          {
              System.Diagnostics.Debug.WriteLine(ex.Message);
            this._LastError = SNES.ROMFile.LastErrors.Exception;
            return false;
          }
          this._ROMPath = path;
          return true;
        }
      }

      public unsafe void Save(string path, byte[] src)
      {
        if (path == null)
          path = this._ROMPath;
        ushort num = (ushort) 510;
        if (this._ROMType != SNES.ROMFile.ROMTypes.LoROM)
        {
          if (this._ROMType != SNES.ROMFile.ROMTypes.SuperFX)
            goto label_11;
        }
        for (int index = 0; index < 32732; ++index)
          num += (ushort) src[index];
        for (int index = 32736; index < src.Length; ++index)
          num += (ushort) src[index];
        fixed (byte* numPtr = &src[32732])
          *(int*) numPtr = (int) num << 16 | (int) num ^ (int) ushort.MaxValue;
label_11:
        try
        {
          FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
          if ((int) this._HasHeader != 0)
            fileStream.Write(this._HeaderBuf, 0, 512);
          fileStream.Write(src, 0, src.Length);
          fileStream.Close();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
          this._LastError = SNES.ROMFile.LastErrors.CouldntOpenROMForWriting;
          throw new SNES.ROMFile.UnableToWriteException();
        }
        this._ROMBuf[0].CopyFrom(src, 0, src.Length);
      }

      private unsafe int ROMTypeScore(byte* info)
      {
        int num = 0;
        if ((int) info[21] <= 5)
          num += 2;
        if (1 << (int) info[23] - 7 > 48)
          --num;
        if ((int) info[25] <= 20)
          ++num;
        if ((int) info[26] == 51)
          num += 2;
        if ((int) *(ushort*) (info + 28) + (int) *(ushort*) (info + 30) == (int) ushort.MaxValue)
          num += 3;
        if (((int) info[61] & 128) == 0)
          num -= 4;
        for (int index = 0; index < 21; ++index)
        {
          if ((int) info[index] < 32 || 126 < (int) info[index])
          {
            --num;
            break;
          }
        }
        return num;
      }

      public uint AddressSNEStoPC(uint address)
      {
        if (7340032U <= address && address <= 8388607U)
          throw new SNES.ROMFile.InvalidSNESAddressException();
        switch (this._ROMType)
        {
          case SNES.ROMFile.ROMTypes.LoROM:
            return (address & 16711680U) >> 1 | address & (uint) short.MaxValue;
          case SNES.ROMFile.ROMTypes.HiROM:
            return address & 4194303U;
          case SNES.ROMFile.ROMTypes.SuperFX:
            if ((address & 8388607U) >= 6291456U)
              throw new SNES.ROMFile.InvalidSNESAddressException();
            if ((address & 8388607U) < 4194304U)
              return (address & 16711680U) >> 1 | address & (uint) short.MaxValue;
            else
              return address & 2097151U;
          default:
            return 0U;
        }
      }

      private class InvalidROMException : Exception
      {
      }

      private class InvalidSNESAddressException : Exception
      {
      }

      private class UnableToWriteException : Exception
      {
      }

      private enum LastErrors
      {
        Null,
        CouldntOpenROMForReading,
        CouldntOpenROMForWriting,
        InvalidROM,
        Exception,
      }

      private enum ROMTypes
      {
        LoROM,
        HiROM,
        SuperFX,
      }
    }
  }
}
