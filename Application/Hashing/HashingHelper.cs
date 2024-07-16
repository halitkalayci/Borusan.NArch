using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Hashing
{
    public static class HashingHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordSalt, out byte[] passwordHash)
        {
            using HMACSHA512 hmac = new();
            // Key => her üretildiğinde random üretilen bir yapı. (SALT)
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        // HASH => 0xABC123
        // SALT => 0xKLŞ589

        // BENİM ŞİFREM => ABC123
        // abc1234+0xKLŞ589 => 0xBRTQXC2
        // abc123+0xKLŞ589 => 0xABC123
        public static bool VerifyPasswordHash(string password, byte[] passwordSalt, byte[] passwordHash)
        {
            using HMACSHA512 hmac = new(passwordSalt); // Geçerli salt ile bir şifreleyici
            byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); // Geçerli salt ile yeni gelen şifreyi hashledim
            return hash.SequenceEqual(passwordHash); // eski hashlenmiş ile şu an hashlenmişi karşılaştırdım.
        }
    }
}
