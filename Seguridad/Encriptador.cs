using System;
using System.Security.Cryptography;
using System.Text;

namespace Seguridad
{
    public static class Encriptador
    {
        private const int SaltSize = 16;
        private const int HashSize = 32;
        private const int Iterations = 100000;

        private static readonly byte[] _clave = Encoding.UTF8.GetBytes("SysthActClaveAES256BitsKey123456");
        private static readonly byte[] _iv = Encoding.UTF8.GetBytes("SysthActIV123456");

        public static string Hash(string contraseña)
        {
            byte[] salt = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
                rng.GetBytes(salt);

            using (var pbkdf2 = new Rfc2898DeriveBytes(contraseña, salt, Iterations, HashAlgorithmName.SHA256))
            {
                byte[] hash = pbkdf2.GetBytes(HashSize);
                byte[] hashBytes = new byte[SaltSize + HashSize];
                Array.Copy(salt, 0, hashBytes, 0, SaltSize);
                Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);
                return Convert.ToBase64String(hashBytes);
            }
        }

        public static string Cifrar(string texto)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = _clave;
                aes.IV = _iv;
                ICryptoTransform encriptador = aes.CreateEncryptor();
                byte[] bytes = Encoding.UTF8.GetBytes(texto);
                byte[] cifrado = encriptador.TransformFinalBlock(bytes, 0, bytes.Length);
                return Convert.ToBase64String(cifrado);
            }
        }

        public static string Descifrar(string textoCifrado)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = _clave;
                aes.IV = _iv;
                ICryptoTransform desencriptador = aes.CreateDecryptor();
                byte[] bytes = Convert.FromBase64String(textoCifrado);
                byte[] descifrado = desencriptador.TransformFinalBlock(bytes, 0, bytes.Length);
                return Encoding.UTF8.GetString(descifrado);
            }
        }

        public static bool Verificar(string contraseñaIngresada, string hashAlmacenado)
        {
            byte[] hashBytes = Convert.FromBase64String(hashAlmacenado);
            byte[] salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);

            using (var pbkdf2 = new Rfc2898DeriveBytes(contraseñaIngresada, salt, Iterations, HashAlgorithmName.SHA256))
            {
                byte[] hashCalculado = pbkdf2.GetBytes(HashSize);
                for (int i = 0; i < HashSize; i++)
                {
                    if (hashBytes[i + SaltSize] != hashCalculado[i])
                        return false;
                }
                return true;
            }
        }
    }
}
