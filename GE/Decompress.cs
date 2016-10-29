
// Type: GE.Decompress

// MVID: 7AA6A484-F524-42F2-9571-0947D386B578
// Assembly location: C:\Documents and Settings\THE RAIN\Desktop\ge.exe

using System;

namespace GE
{
    public class Decompress
    {
        private static byte[] BitTable = new byte[] { 0x80, 0x40, 0x20, 0x10, 8, 4, 2, 1 };

        public static unsafe void LZ0(byte* src, byte* dest, uint max_size)
        {
            byte* numPtr1 = dest;
        label_1:
            ushort num1;
            while (true)
            {
                byte num2;
                do
                {
                    byte* numPtr2 = src++;
                    byte num3;
                    if ((int)(num3 = *numPtr2) == (int)byte.MaxValue)
                        return;
                    byte num4;
                    if (((int)num3 & 224) == 224)
                    {
                        num1 = (ushort)((((int)num3 & 3) << 8 | (int)*src++) + 1);
                        num4 = (byte)((int)num3 << 3 & 224);
                    }
                    else
                    {
                        num1 = (ushort)(((int)num3 & 31) + 1);
                        num4 = (byte)((uint)num3 & 224U);
                    }
                    num2 = num4;
                    if ((uint)num2 <= 32U)
                    {
                        if ((int)num2 != 0)
                        {
                            if ((int)num2 == 32)
                                goto label_14;
                        }
                        else
                            goto label_12;
                    }
                    else if ((int)num2 != 64)
                    {
                        if ((int)num2 == 96)
                            goto label_20;
                    }
                    else
                        goto label_16;
                }
                while ((int)num2 != 128);
                goto label_24;
            label_14:
                while ((int)num1-- != 0)
                    *dest++ = *src;
                ++src;
                continue;
            label_16:
                byte num5 = (byte)0;
                while ((int)num1-- != 0)
                    *dest++ = src[(int)num5++ & 1];
                src += 2;
                continue;
            label_24:
                ushort num6 = (ushort)((uint)*src << 8 | (uint)src[1]);
                while ((int)num1-- != 0)
                    *dest++ = numPtr1[(int)num6++];
                src += 2;
            }
        label_12:
            while ((int)num1-- != 0)
                *dest++ = *src++;
            goto label_1;
        label_20:
            byte num7 = *src++;
            while ((int)num1-- != 0)
                *dest++ = num7++;
            goto label_1;
        }

        public static unsafe void LZ1(byte* src, byte* dest, uint max_row)
        {
            byte[] numArray1 = new byte[4];
            ushort num1 = (ushort)sbyte.MaxValue;
            ushort num2 = (ushort)0;
            byte num3 = (byte)5;
            bool flag1 = false;
            byte[] numArray2 = new byte[128];
            numArray1[0] = *src++;
            numArray1[1] = *src++;
            numArray1[2] = *src++;
            ushort num4 = (ushort)(byte)((uint)*src & 15U);
            byte num5 = (byte)((uint)*src >> 3);
            ++src;
            bool flag2 = ((int)num5 & 1) == 1;
            byte num6 = (byte)((uint)num5 >> 1);
            byte num7;
            if ((int)(num7 = (byte)((uint)num3 - 1U)) == 0)
            {
                num7 = (byte)8;
                num6 = *src++;
            }
            do
            {
                ushort num8 = (ushort)((uint)num4 << 1);
                if (flag2)
                    num8 |= (ushort)1;
                bool flag3 = ((int)num6 & 1) == 1;
                num6 >>= 1;
                if ((int)--num7 == 0)
                {
                    num7 = (byte)8;
                    num6 = *src++;
                }
                num4 = (ushort)((uint)num8 >> 1);
                if (flag3)
                    num4 |= 0x8000;
                do
                {
                    byte num9 = (byte)0;
                    byte num10 = (byte)1;
                    flag2 = ((int)num6 & 1) == 1;
                    num6 >>= 1;
                    if ((int)--num7 == 0)
                    {
                        num7 = (byte)8;
                        num6 = *src++;
                    }
                    while (flag2)
                    {
                        bool flag4 = ((int)num6 & 1) == 1;
                        byte num11 = (byte)((uint)num6 >> 1);
                        byte num12;
                        if ((int)(num12 = (byte)((uint)num7 - 1U)) == 0)
                        {
                            num12 = (byte)8;
                            num11 = *src++;
                        }
                        if (flag4)
                            num9 |= num10;
                        num10 <<= 1;
                        flag2 = ((int)num11 & 1) == 1;
                        num6 = (byte)((uint)num11 >> 1);
                        if ((int)(num7 = (byte)((uint)num12 - 1U)) == 0)
                        {
                            num7 = (byte)8;
                            num6 = *src++;
                        }
                    }
                    byte num13 = (byte)((uint)num9 | (uint)num10);
                    if ((int)(short)num4 < 0)
                    {
                        bool flag4 = ((int)num6 & 1) == 1;
                        byte num11 = (byte)((uint)num6 >> 1);
                        byte num12;
                        if ((int)(num12 = (byte)((uint)num7 - 1U)) == 0)
                        {
                            num12 = (byte)8;
                            num11 = *src++;
                        }
                        if (flag4)
                        {
                            byte[] numArray3 = numArray2;
                            int index1 = (int)num1;
                            int num14 = 1;
                            ushort num15 = (ushort)(index1 - num14);
                            byte num16 = numArray3[index1];
                            flag2 = ((int)num11 & 1) == 1;
                            num6 = (byte)((uint)num11 >> 1);
                            if ((int)(num7 = (byte)((uint)num12 - 1U)) == 0)
                            {
                                num7 = (byte)8;
                                num6 = *src++;
                            }
                            byte num17 = (byte)0;
                            if (!flag2)
                            {
                                byte num18;
                                int num19;
                                int num20;
                                do
                                {
                                    num19 = (int)num16;
                                    byte[] numArray4 = numArray2;
                                    int index2 = num15--;
                                    num18 = (byte)(num20 = (int)numArray4[index2]);
                                }
                                while (num19 == num20);
                                num1 = (ushort)((uint)num15 + 1U);
                                while ((int)num13-- != 0)
                                    numArray2[(int)num1--] = num16;
                                if ((int)(short)num1 >= 0)
                                {
                                    numArray2[(int)num1] = num18;
                                    continue;
                                }
                            }
                            else
                            {
                                bool flag5 = false;
                                while ((int)(short)num15 >= 0)
                                {
                                    int num18 = (int)num16;
                                    byte[] numArray4 = numArray2;
                                    int index2 = num15--;
                                    int num19;
                                    num17 = (byte)(num19 = (int)numArray4[index2]);
                                    if (num18 != num19)
                                        goto label_34;
                                }
                                flag5 = true;
                            label_34:
                                if (flag5)
                                    num17 = (byte)0;
                                else
                                    ++num15;
                                num1 = (ushort)((uint)num15 + (uint)num13);
                                numArray2[(int)num1] = num17;
                                continue;
                            }
                        }
                        else
                        {
                            flag2 = ((int)num11 & 1) == 1;
                            num6 = (byte)((uint)num11 >> 1);
                            if ((int)(num7 = (byte)((uint)num12 - 1U)) == 0)
                            {
                                num7 = (byte)8;
                                num6 = *src++;
                            }
                            if (flag2)
                            {
                                flag1 = true;
                            }
                            else
                            {
                                bool flag5 = false;
                                while ((int)num13-- != 0)
                                {
                                    byte num14 = numArray2[(int)num1--];
                                    while ((int)(short)num1 >= 0)
                                    {
                                        if ((int)num14 != (int)numArray2[(int)num1--])
                                            goto label_47;
                                    }
                                    flag5 = true;
                                label_47:
                                    if (!flag5)
                                        ++num1;
                                    else
                                        break;
                                }
                                if (!flag5)
                                    continue;
                            }
                        }
                    }
                    else
                        flag1 = true;
                    if (flag1)
                    {
                        flag1 = false;
                        int index1 = 0;
                        bool flag4 = false;
                        numArray1[3] = (byte)((uint)num4 & 15U);
                        bool flag5 = ((int)num6 & 1) == 1;
                        byte num11 = (byte)((uint)num6 >> 1);
                        byte num12;
                        if ((int)(num12 = (byte)((uint)num7 - 1U)) == 0)
                        {
                            num12 = (byte)8;
                            num11 = *src++;
                        }
                        if (flag5)
                            index1 |= 2;
                        bool flag6 = ((int)num11 & 1) == 1;
                        byte num14 = (byte)((uint)num11 >> 1);
                        byte num15;
                        if ((int)(num15 = (byte)((uint)num12 - 1U)) == 0)
                        {
                            num15 = (byte)8;
                            num14 = *src++;
                        }
                        if (flag6)
                            index1 |= 1;
                        flag2 = ((int)num14 & 1) == 1;
                        num6 = (byte)((uint)num14 >> 1);
                        if ((int)(num7 = (byte)((uint)num15 - 1U)) == 0)
                        {
                            num7 = (byte)8;
                            num6 = *src++;
                        }
                        if (flag2)
                            flag4 = true;
                        byte num16;
                        if (index1 == 3 && flag4)
                        {
                            num16 = (byte)0;
                            for (int index2 = 0; index2 < 4; ++index2)
                            {
                                flag2 = ((int)num6 & 1) == 1;
                                num6 >>= 1;
                                if ((int)--num7 == 0)
                                {
                                    num7 = (byte)8;
                                    num6 = *src++;
                                }
                                num16 <<= 1;
                                if (flag2)
                                    num16 |= (byte)1;
                            }
                        }
                        else
                            num16 = flag4 ? (byte)((uint)numArray1[index1] >> 4) : (byte)((uint)numArray1[index1] & 15U);
                        while ((int)num13-- != 0)
                            numArray2[(int)num1--] = num16;
                    }
                }
                while ((int)(short)num1 >= 0);
                ushort num21 = (ushort)0;
                while ((int)num21 < 128)
                {
                    dest[(int)num21 * 4 + ((int)num2 & 7) * 2 + ((int)num2 & 248) * 64] = (byte)0;
                    dest[(int)num21 * 4 + ((int)num2 & 7) * 2 + ((int)num2 & 248) * 64 + 1] = (byte)0;
                    dest[(int)num21 * 4 + ((int)num2 & 7) * 2 + ((int)num2 & 248) * 64 + 16] = (byte)0;
                    dest[(int)num21 * 4 + ((int)num2 & 7) * 2 + ((int)num2 & 248) * 64 + 17] = (byte)0;
                    for (int index = 0; index < 8; ++index)
                    {
                        IntPtr num9 = (IntPtr)(dest + ((int)num21 * 4 + ((int)num2 & 7) * 2 + ((int)num2 & 248) * 64));
                        int num10 = (int)(byte)((int)*(byte*)num9 | (((int)numArray2[(int)num21 + index] & 1) == 1 ? (int)Decompress.BitTable[index] : 0));
                        *(sbyte*)num9 = (sbyte)num10;
                        IntPtr num11 = (IntPtr)(dest + ((int)num21 * 4 + ((int)num2 & 7) * 2 + ((int)num2 & 248) * 64 + 1));
                        int num12 = (int)(byte)((int)*(byte*)num11 | (((int)numArray2[(int)num21 + index] & 2) == 2 ? (int)Decompress.BitTable[index] : 0));
                        *(sbyte*)num11 = (sbyte)num12;
                        IntPtr num13 = (IntPtr)(dest + ((int)num21 * 4 + ((int)num2 & 7) * 2 + ((int)num2 & 248) * 64 + 16));
                        int num14 = (int)(byte)((int)*(byte*)num13 | (((int)numArray2[(int)num21 + index] & 4) == 4 ? (int)Decompress.BitTable[index] : 0));
                        *(sbyte*)num13 = (sbyte)num14;
                        IntPtr num15 = (IntPtr)(dest + ((int)num21 * 4 + ((int)num2 & 7) * 2 + ((int)num2 & 248) * 64 + 17));
                        int num16 = (int)(byte)((int)*(byte*)num15 | (((int)numArray2[(int)num21 + index] & 8) == 8 ? (int)Decompress.BitTable[index] : 0));
                        *(sbyte*)num15 = (sbyte)num16;
                    }
                    num21 += (ushort)8;
                }
                num1 = (ushort)((uint)num21 - 1U);
                ++num2;
            }
            while ((uint)num2 < max_row);
        }
    }
}
