using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Infrastructure.Persistence.Helpers
{
    internal class PasswordHasher
    {
        private const int SaltSize = 16; // 16 bytes salt size
        private const int KeySize = 32; // 32 bytes key size
        private const int Iterations = 10000; // Number of iterations

        public static string HashPassword(string password)
        {
            // Generate a random salt
            byte[] salt = new byte[SaltSize];
            using (var rng = System.Security.Cryptography.RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            // Hash the password
            byte[] hashed = KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: Iterations,
                numBytesRequested: KeySize);

            // Combine the salt and hashed password
            byte[] combinedBytes = new byte[SaltSize + KeySize];
            Array.Copy(salt, 0, combinedBytes, 0, SaltSize);
            Array.Copy(hashed, 0, combinedBytes, SaltSize, KeySize);

            // Convert to base64 string for storage
            string hashedPassword = Convert.ToBase64String(combinedBytes);
            return hashedPassword;
        }
    }
}
