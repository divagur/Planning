using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Planning.Kernel
{
    public class StringCryptor
    {

        private string RC2Cript(string data, bool IsCrypt)
        {
            if (String.IsNullOrEmpty(data)) return "";
            byte[] s1 = (IsCrypt) ? System.Text.UTF8Encoding.UTF8.GetBytes(data) : Convert.FromBase64String(data);
            SymmetricAlgorithm cripto = new RC2CryptoServiceProvider();
            cripto.Key = new byte[] { 0x10, 0x24, 0x76, 0x45, 0x84, 0x64, 0x25, 0x34 };
            cripto.IV = new byte[] { 0x14, 0x24, 0x76, 0x48, 0x84, 0x64, 0x25, 0x34 };
            s1 = ((ICryptoTransform)((IsCrypt) ? cripto.CreateEncryptor() : cripto.CreateDecryptor())).TransformFinalBlock(s1, 0, s1.Length);
            return (IsCrypt) ? Convert.ToBase64String(s1) : System.Text.UTF8Encoding.UTF8.GetString(s1).Trim();
        }

        public string Decode(string Data)
        {          
            
            return RC2Cript(Data, false);
        }

        public string Encode(string Data) 
        {
            return RC2Cript(Data, true); ; 
        }
    }
}
