using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Configuration;

namespace ERPE2.CrossLogic.Auth;

using System;
using System.Security.Cryptography;

public class PasswordHasher
{
    private const int SaltSize = 16; // tamaño de la sal en bytes
    private const int KeySize = 32; // tamaño del hash en bytes
    private const int Iterations = 10000; // número de iteraciones de PBKDF2
    
    // Genera una sal aleatoria
    private static byte[] GenerateSalt()
    {
        byte[] salt = new byte[SaltSize];
        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(salt);
        }
        return salt;
    }

    // Hashea la contraseña usando sal y pimienta
    public static string HashPassword(string password, string Pepper)
    {
        byte[] salt = GenerateSalt();
        byte[] hash = KeyDerivation.Pbkdf2(
            password: password + Pepper,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: Iterations,
            numBytesRequested: KeySize
        );

        byte[] hashBytes = new byte[SaltSize + KeySize];
        Buffer.BlockCopy(salt, 0, hashBytes, 0, SaltSize);
        Buffer.BlockCopy(hash, 0, hashBytes, SaltSize, KeySize);

        return Convert.ToBase64String(hashBytes);
    }

    // Verifica la contraseña
    public static bool VerifyPassword(string password, string hashedPassword, string Pepper)
    {
        byte[] hashBytes = Convert.FromBase64String(hashedPassword);
        byte[] salt = new byte[SaltSize];
        Buffer.BlockCopy(hashBytes, 0, salt, 0, SaltSize);

        byte[] hash = KeyDerivation.Pbkdf2(
            password: password + Pepper,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: Iterations,
            numBytesRequested: KeySize
        );

        for (int i = 0; i < KeySize; i++)
        {
            if (hashBytes[SaltSize + i] != hash[i])
            {
                return false;
            }
        }
        return true;
    }
}
