using System;
using System.Text;

namespace Advanced_Encryption_Standard
{
    /// <summary>
    /// 128位密钥高级加密标准
    /// </summary>
    public class AES
    {
        private static string keytext = "psgmtrntepdcwqiy";           //密钥
        #region stable
        private static byte[] sbox ={                                  //s盒
        0x63, 0x7C, 0x77, 0x7B, 0xF2, 0x6B, 0x6F, 0xC5,
		0x30, 0x01, 0x67, 0x2B, 0xFE, 0xD7, 0xAB, 0x76,
		0xCA, 0x82, 0xC9, 0x7D, 0xFA, 0x59, 0x47, 0xF0,
		0xAD, 0xD4, 0xA2, 0xAF, 0x9C, 0xA4, 0x72, 0xC0,
		0xB7, 0xFD, 0x93, 0x26, 0x36, 0x3F, 0xF7, 0xCC,
		0x34, 0xA5, 0xE5, 0xF1, 0x71, 0xD8, 0x31, 0x15,
		0x04, 0xC7, 0x23, 0xC3, 0x18, 0x96, 0x05, 0x9A,
		0x07, 0x12, 0x80, 0xE2, 0xEB, 0x27, 0xB2, 0x75,
		0x09, 0x83, 0x2C, 0x1A, 0x1B, 0x6E, 0x5A, 0xA0,
		0x52, 0x3B, 0xD6, 0xB3, 0x29, 0xE3, 0x2F, 0x84,
		0x53, 0xD1, 0x00, 0xED, 0x20, 0xFC, 0xB1, 0x5B,
		0x6A, 0xCB, 0xBE, 0x39, 0x4A, 0x4C, 0x58, 0xCF,
		0xD0, 0xEF, 0xAA, 0xFB, 0x43, 0x4D, 0x33, 0x85,
		0x45, 0xF9, 0x02, 0x7F, 0x50, 0x3C, 0x9F, 0xA8,
		0x51, 0xA3, 0x40, 0x8F, 0x92, 0x9D, 0x38, 0xF5,
		0xBC, 0xB6, 0xDA, 0x21, 0x10, 0xFF, 0xF3, 0xD2,
		0xCD, 0x0C, 0x13, 0xEC, 0x5F, 0x97, 0x44, 0x17,
		0xC4, 0xA7, 0x7E, 0x3D, 0x64, 0x5D, 0x19, 0x73,
		0x60, 0x81, 0x4F, 0xDC, 0x22, 0x2A, 0x90, 0x88,
		0x46, 0xEE, 0xB8, 0x14, 0xDE, 0x5E, 0x0B, 0xDB,
		0xE0, 0x32, 0x3A, 0x0A, 0x49, 0x06, 0x24, 0x5C,
		0xC2, 0xD3, 0xAC, 0x62, 0x91, 0x95, 0xE4, 0x79,
		0xE7, 0xC8, 0x37, 0x6D, 0x8D, 0xD5, 0x4E, 0xA9,
		0x6C, 0x56, 0xF4, 0xEA, 0x65, 0x7A, 0xAE, 0x08,
		0xBA, 0x78, 0x25, 0x2E, 0x1C, 0xA6, 0xB4, 0xC6,
		0xE8, 0xDD, 0x74, 0x1F, 0x4B, 0xBD, 0x8B, 0x8A,
		0x70, 0x3E, 0xB5, 0x66, 0x48, 0x03, 0xF6, 0x0E,
		0x61, 0x35, 0x57, 0xB9, 0x86, 0xC1, 0x1D, 0x9E,
		0xE1, 0xF8, 0x98, 0x11, 0x69, 0xD9, 0x8E, 0x94,
		0x9B, 0x1E, 0x87, 0xE9, 0xCE, 0x55, 0x28, 0xDF,
		0x8C, 0xA1, 0x89, 0x0D, 0xBF, 0xE6, 0x42, 0x68,
		0x41, 0x99, 0x2D, 0x0F, 0xB0, 0x54, 0xBB, 0x16};
        #endregion
        #region _stable
        private static byte[] _sbox ={         //逆s盒
		0x52, 0x09, 0x6A, 0xD5, 0x30, 0x36, 0xA5, 0x38,
		0xBF, 0x40, 0xA3, 0x9E, 0x81, 0xF3, 0xD7, 0xFB,
		0x7C, 0xE3, 0x39, 0x82, 0x9B, 0x2F, 0xFF, 0x87,
		0x34, 0x8E, 0x43, 0x44, 0xC4, 0xDE, 0xE9, 0xCB,
		0x54, 0x7B, 0x94, 0x32, 0xA6, 0xC2, 0x23, 0x3D,
		0xEE, 0x4C, 0x95, 0x0B, 0x42, 0xFA, 0xC3, 0x4E,
		0x08, 0x2E, 0xA1, 0x66, 0x28, 0xD9, 0x24, 0xB2,
		0x76, 0x5B, 0xA2, 0x49, 0x6D, 0x8B, 0xD1, 0x25,
		0x72, 0xF8, 0xF6, 0x64, 0x86, 0x68, 0x98, 0x16,
		0xD4, 0xA4, 0x5C, 0xCC, 0x5D, 0x65, 0xB6, 0x92,
		0x6C, 0x70, 0x48, 0x50, 0xFD, 0xED, 0xB9, 0xDA,
		0x5E, 0x15, 0x46, 0x57, 0xA7, 0x8D, 0x9D, 0x84,
		0x90, 0xD8, 0xAB, 0x00, 0x8C, 0xBC, 0xD3, 0x0A,
		0xF7, 0xE4, 0x58, 0x05, 0xB8, 0xB3, 0x45, 0x06,
		0xD0, 0x2C, 0x1E, 0x8F, 0xCA, 0x3F, 0x0F, 0x02,
		0xC1, 0xAF, 0xBD, 0x03, 0x01, 0x13, 0x8A, 0x6B,
		0x3A, 0x91, 0x11, 0x41, 0x4F, 0x67, 0xDC, 0xEA,
		0x97, 0xF2, 0xCF, 0xCE, 0xF0, 0xB4, 0xE6, 0x73,
		0x96, 0xAC, 0x74, 0x22, 0xE7, 0xAD, 0x35, 0x85,
		0xE2, 0xF9, 0x37, 0xE8, 0x1C, 0x75, 0xDF, 0x6E,
		0x47, 0xF1, 0x1A, 0x71, 0x1D, 0x29, 0xC5, 0x89,
		0x6F, 0xB7, 0x62, 0x0E, 0xAA, 0x18, 0xBE, 0x1B,
		0xFC, 0x56, 0x3E, 0x4B, 0xC6, 0xD2, 0x79, 0x20,
		0x9A, 0xDB, 0xC0, 0xFE, 0x78, 0xCD, 0x5A, 0xF4,
		0x1F, 0xDD, 0xA8, 0x33, 0x88, 0x07, 0xC7, 0x31,
		0xB1, 0x12, 0x10, 0x59, 0x27, 0x80, 0xEC, 0x5F,
		0x60, 0x51, 0x7F, 0xA9, 0x19, 0xB5, 0x4A, 0x0D,
		0x2D, 0xE5, 0x7A, 0x9F, 0x93, 0xC9, 0x9C, 0xEF,
		0xA0, 0xE0, 0x3B, 0x4D, 0xAE, 0x2A, 0xF5, 0xB0,
		0xC8, 0xEB, 0xBB, 0x3C, 0x83, 0x53, 0x99, 0x61,
		0x17, 0x2B, 0x04, 0x7E, 0xBA, 0x77, 0xD6, 0x26,
		0xE1, 0x69, 0x14, 0x63, 0x55, 0x21, 0x0C, 0x7D};
        #endregion
        private static byte[,] mixup ={     //列混淆矩阵
        {0x2,0x3,0x1,0x1},
		{0x1,0x2,0x3,0x1},
		{0x1,0x1,0x2,0x3},
		{0x3,0x1,0x1,0x2}};

        private static byte[,] _mixup = {     //逆列混淆矩阵
        {0xE,0xB,0xD,0x9},
		{0x9,0xE,0xB,0xD},
		{0xD,0x9,0xE,0xB},
		{0xB,0xD,0x9,0xE}};

        private static byte[] RC = { 0x01, 0x02, 0x04, 0x08, 0x10, 0x20, 0x40, 0x80, 0x1b, 0x36 };    //rcon矩阵

        private static void byteReplace(byte[,] state, byte[] table)   //字节代换
        {
            for (int i = 0; i < state.GetLength(0); i++)
            {
                for (int j = 0; j < state.GetLength(1); j++)
                    state[i, j] = table[16 * (state[i, j] / 16) + state[i, j] % 16];
            }
        }

        private static void byteReplace(byte[] result, byte[] table)   //逆字节代换
        {
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = table[16 * (result[i] / 16) + result[i] % 16];
            }
        }

        private static byte[,] rowMove(byte[,] state, bool isLeft)     //行移位
        {
            for (int i = 1; i < state.GetLength(0); i++)
            {
                move(isLeft, state, i, i);
            }
            return state;
        }

        private static void move(Boolean isLeft, byte[,] ch, int rowindex, int size)
        {
            int length;
            if (rowindex < ch.GetLength(0))
                length = ch.GetLength(1);
            else
                return;
            size = size % length;
            byte[] sh = new byte[size];

            if (isLeft)
            {
                for (int i = 0; i < length; i++)
                {
                    if (i < size)
                    {
                        sh[i] = ch[rowindex, i];
                    }
                    if (i < length - size)
                        ch[rowindex, i] = ch[rowindex, i + size];
                    else
                        ch[rowindex, i] = sh[i - length + size];
                }
            }
            else
            {
                for (int i = length - 1; i >= 0; i--)
                {
                    if (i >= length - size)
                    {
                        sh[length - 1 - i] = ch[rowindex, i];
                    }
                    if (i >= size)
                        ch[rowindex, i] = ch[rowindex, i - size];
                    else
                        ch[rowindex, i] = sh[size - i - 1];
                }
            }
        }

        private static void move(Boolean isLeft, byte[] ch, int size)
        {
            int length = ch.Length;
            size = size % length;
            byte[] sh = new byte[size];

            if (isLeft)
            {
                for (int i = 0; i < length; i++)
                {
                    if (i < size)
                    {
                        sh[i] = ch[i];
                    }
                    if (i < length - size)
                        ch[i] = ch[i + size];
                    else
                        ch[i] = sh[i - length + size];
                }
            }
            else
            {
                for (int i = length - 1; i >= 0; i--)
                {
                    if (i >= length - size)
                    {
                        sh[length - 1 - i] = ch[i];
                    }
                    if (i >= size)
                        ch[i] = ch[i - size];
                    else
                        ch[i] = sh[size - i - 1];
                }
            }
        }

        private static void cloumnMixup(byte[,] state, byte[,] table)  //列混淆
        {
            if (table.GetLength(0) != state.GetLength(1) || table.GetLength(1) != state.GetLength(0))  //不符合混淆要求
            {
                return;
            }
            byte[,] temp = new byte[state.GetLength(0), state.GetLength(1)];
            for (int i = 0; i < state.GetLength(0); i++)
            {
                for (int j = 0; j < state.GetLength(1); j++)
                {
                    temp[i, j] = rowSum(table, i, state, j);
                }
            }
            for (int m = 0; m < state.GetLength(0); m++)
            {
                for (int n = 0; n < state.GetLength(1); n++)
                    state[m, n] = temp[m, n];
            }
        }

        private static byte rowSum(byte[,] table, int rowindex, byte[,] state, int cloumnindex)   //计算第rowindex行*cloumnindex列的值
        {
            if (rowindex >= table.GetLength(0) || cloumnindex >= state.GetLength(1))
                throw (new Exception("ArrayIndexOutofBounds"));
            byte temp = 0;
            for (int p = 0, q = 0; p < state.GetLength(1) && q < table.GetLength(0); p++, q++)
            {
                if (p == 0)
                    temp = multiply(state[q, cloumnindex], table[rowindex, p]);
                else
                    temp = (byte)(temp ^ multiply(state[q, cloumnindex], table[rowindex, p]));
            }
            return temp;
        }

        private static byte multiply(byte x, byte y)  //矩阵乘法
        {
            byte result = 0;
            if (y == 1)
                return x;
            byte[] temp = new byte[8];
            for (int i = 0; i < 8; i++)
            {
                if (i == 0)
                {
                    temp[i] = x;
                }
                else
                {
                    temp[i] = bitLeft(temp[i - 1]);
                    y /= 2;
                }
                if (y % 2 == 1)
                {
                    result ^= temp[i];
                }
            }
            return result;
        }

        private static byte bitLeft(byte x)   //左移位,如果最高位为1,则异或上00011011
        {
            char[] ch = Convert.ToString(x, 2).ToCharArray();
            string s = "";
            for (int i = 0; i < 8; i++)
            {
                if (i < 8 - ch.Length)
                    s += "0";
                else
                    s += ch[i - 8 + ch.Length].ToString();
            }
            s = s.Substring(1);
            s += "0";
            x = Convert.ToByte(s, 2);
            if (ch.Length >= 8 && (ch[0].ToString() == "1"))
            {
                x = (byte)(x ^ 27);
            }
            return x;
        }

        private static byte[,] getKeys(string keytext)   //获取密钥
        {
            byte[] key = new byte[16];
            char[] ch = keytext.ToCharArray();
            for (int i = 0; i < 16; i++)
                key[i] = (byte)ch[i];
            byte[,] expandkey = new byte[44, 4];
            keyExpansion(key, expandkey);
            return expandkey;
        }

        private static void keyExpansion(byte[] key, byte[,] expandKey)  //密钥扩展
        {
            byte[] temp = new byte[4];
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    if (i == 3)
                        temp[j] = key[4 * i + j];
                    expandKey[i, j] = key[4 * i + j];
                }
            for (int m = 4; m < 44; m++)
            {
                for (int n = 0; n < 4; n++)
                {
                    if (m % 4 == 0 && n == 0)
                    {
                        move(true, temp, 1);
                        byteReplace(temp, sbox);
                        temp[0] = (byte)(temp[0] ^ RC[m / 4 - 1]);
                    }
                    byte x = expandKey[m - 4, n];
                    byte y = temp[n];
                    byte z = (byte)(x ^ y);
                    expandKey[m, n] = (byte)(expandKey[m - 4, n] ^ temp[n]);
                    temp[n] = expandKey[m, n];
                }
            }
        }

        private static void XOR(byte[,] state, byte[,] keys, int roundindex)//异或
        {
            for (int m = 0; m < state.GetLength(0); m++)
                for (int n = 0; n < state.GetLength(1); n++)
                    state[m, n] = (byte)(state[m, n] ^ keys[4 * roundindex + n, m]);
        }

        private static void changeTobyte(byte[,] state, string text)  //将字符串转化为state数组
        {
            char[] ch = text.ToCharArray();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (4 * i + j < text.Length)
                        state[i, j] = (byte)ch[4 * i + j];
                    else
                        state[i, j] = 0x00;
                }
            }
        }

        private static void onceEncryt(byte[,] state)        //加密一组数据
        {
            byte[,] keys = getKeys(keytext);
            XOR(state, keys, 0);
            for (int i = 1; i <= 10; i++)
            {
                byteReplace(state, sbox);
                rowMove(state, true);
                if (i != 10)
                    cloumnMixup(state, mixup);
                XOR(state, keys, i);
            }
        }

        private static void onceDecryt(byte[,] state)        //解密一组数据
        {
            byte[,] keys = getKeys(keytext);
            XOR(state, keys, 10);
            for (int i = 9; i >= 0; i--)
            {
                rowMove(state, false);
                byteReplace(state, _sbox);
                XOR(state, keys, i);
                if (i != 0)
                    cloumnMixup(state, _mixup);
            }
        }

        /// <summary>
        /// AES加密明文plaintext
        /// </summary>
        /// <param name="plaintext">明文</param>
        /// <returns>返回密文字符串,空字符串和null则返回空字符串</returns>
        public static string Encrypt(string plaintext)
        {
            if (String.IsNullOrEmpty(plaintext))
                return "";
            string ciphertext = "";
            byte[] plainBytes = Encoding.Unicode.GetBytes(plaintext);
            byte[,] state = new byte[4, 4];
            int length = 0;
            length = plainBytes.Length / 16;
            if (plainBytes.Length % 16 != 0)
                length = length + 1;
            byte[] cipherBytes = new byte[length * 16];
            int temp;
            for (int k = 0; k < length; k++)
            {
                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 4; j++)
                    {
                        temp = 16 * k + 4 * i + j;
                        if (temp < plainBytes.Length)
                            state[i, j] = plainBytes[temp];
                        else
                            state[i, j] = 0x00;
                    }
                onceEncryt(state);
                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 4; j++)
                    {
                        cipherBytes[16 * k + 4 * i + j] = state[i, j];
                    }
            }
            ciphertext = Convert.ToBase64String(cipherBytes);
            return ciphertext;
        }

        /// <summary>
        /// AES解密密文ciphertext
        /// </summary>
        /// <param name="ciphertext">密文</param>
        /// <returns>返回明文字符串,空字符串和null则返回空字符串</returns>
        public static string Decrypt(string ciphertext)
        {
            if (String.IsNullOrEmpty(ciphertext))
                return "";
            string plaintext = "";
            byte[] cipherBytes = Convert.FromBase64String(ciphertext);
            int length = 0;
            length = cipherBytes.Length / 16;
            if (cipherBytes.Length % 16 != 0)
                length = length + 1;
            byte[] plainBytes = new byte[length * 16];
            byte[,] state = new byte[4, 4];
            int temp;
            for (int k = 0; k < length; k++)
            {
                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 4; j++)
                    {
                        temp = 16 * k + 4 * i + j;
                        if (temp < cipherBytes.Length)
                            state[i, j] = cipherBytes[temp];
                        else
                            state[i, j] = 0x00;
                    }
                onceDecryt(state);
                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 4; j++)
                    {
                        plainBytes[16 * k + 4 * i + j] = state[i, j];
                    }
            }
            plaintext = Encoding.Unicode.GetString(plainBytes).TrimEnd('\0');
            return plaintext;
        }
    }
}
