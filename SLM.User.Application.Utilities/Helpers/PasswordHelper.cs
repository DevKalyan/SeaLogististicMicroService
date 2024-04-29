using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Application.Utilities.Helpers
{
    public  class PasswordHelper
    {
        private const int SaltSize = 16; // 16 bytes salt size
        private const int KeySize = 32; // 32 bytes key size
        private const int Iterations = 10000; // Number of iterations
              

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            // Extract the salt and hash from the stored password
            byte[] combinedBytes = Convert.FromBase64String(hashedPassword);
            byte[] salt = new byte[SaltSize];
            byte[] storedHash = new byte[KeySize];
            Array.Copy(combinedBytes, 0, salt, 0, SaltSize);
            Array.Copy(combinedBytes, SaltSize, storedHash, 0, KeySize);

            // Hash the password with the extracted salt
            byte[] hashToVerify = KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA512,
            iterationCount: Iterations,
                numBytesRequested: KeySize);

            // Compare the hashes
            for (int i = 0; i < KeySize; i++)
            {
                if (storedHash[i] != hashToVerify[i])
                {
                    return false;
                }
            }

            return true;
        }
    }

  
}
