using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Services.CommonServices
{
    public class EncryptPassword
    {
        public static string PasswordToEncrypt(string paasWord)
        {
            return Convert.ToBase64String(System.Security.Cryptography.SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(paasWord)));
        }

        public static string OPTPassword()
        {
            Random rnd = new Random();
            string OTP = rnd.Next(100000, 999999).ToString();
            return OTP;
        }

    }
}
