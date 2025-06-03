﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.Kernel
{
    public class StringCryptor
    {
        public string Decode(string Data)
        {
            string result = Data;
            string decode = string.Empty;

            UTF8Encoding encoder = new UTF8Encoding();
            Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(Data);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            result = new String(decoded_char);

            return result;
        }

        public string Encode(string Data) 
        {
            string result = Data;

            byte[] encData_byte = Encoding.UTF8.GetBytes(Data);
            result = Convert.ToBase64String(encData_byte);
            return result; 
        }
    }
}
