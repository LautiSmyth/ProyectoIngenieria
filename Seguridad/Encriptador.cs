using System;
using System.Security.Cryptography;
using System.Text;

namespace Seguridad
{
    public static class Encriptador
    {
        private const int SaltSize = 16;       // 128 bits
        private const int HashSize = 32;       // 256 bits (SHA-256)
        private const int Iterations = 100000;

        // Clave e IV fijos para cifrado AES-256 determinístico
        private static readonly byte[] _clave = Encoding.UTF8.GetBytes("SysthActClaveAES256BitsKey123456");
        private static readonly byte[] _iv = Encoding.UTF8.GetBytes("SysthActIV123456");

        public static string Hash(string contraseña)
        {
            // Se generan 16 bytes aleatorios con el generador
            // criptográfico del sistema operativo
            byte[] salt = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
                rng.GetBytes(salt);

            using (var pbkdf2 = new Rfc2898DeriveBytes(
                contraseña, salt, Iterations, HashAlgorithmName.SHA256))
            {
                byte[] hash = pbkdf2.GetBytes(HashSize);
                // Combinar: [salt 16 bytes] + [hash 32 bytes] = 48 bytes
                byte[] hashBytes = new byte[SaltSize + HashSize];
                Array.Copy(salt, 0, hashBytes, 0, SaltSize);
                Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

                // Convertir a texto y guardar en BD:
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
            // 1. Leer los 48 bytes desde la BD (Base64 → bytes)
            byte[] hashBytes = Convert.FromBase64String(hashAlmacenado);
            // 2. Extraer el salt: los primeros 16 bytes
            byte[] salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);

            using (var pbkdf2 = new Rfc2898DeriveBytes(
                contraseñaIngresada, salt, Iterations, HashAlgorithmName.SHA256))
            {
                // 3. Recalcular el hash con la contraseña ingresada
                // usando el MISMO salt y las MISMAS iteraciones
                byte[] hashCalculado = pbkdf2.GetBytes(HashSize);
                // 4. Comparar byte a byte (posiciones 16 a 47)
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