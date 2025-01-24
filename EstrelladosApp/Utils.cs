using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EstrelladosApp
{
    internal class Utils
    {
        public static string SHA256(string input)
        {
            try
            {
                // Crear una instancia de SHA256
                using (System.Security.Cryptography.SHA256 sha256 = System.Security.Cryptography.SHA256.Create())

                {
                    // Convertir la entrada a bytes
                    byte[] inputBytes = Encoding.UTF8.GetBytes(input);

                    // Calcular el hash
                    byte[] hashBytes = sha256.ComputeHash(inputBytes);

                    // Convertir el hash en una cadena hexadecimal
                    StringBuilder hexString = new StringBuilder();
                    foreach (byte b in hashBytes)
                    {
                        hexString.Append(b.ToString("x2")); // "x2" genera siempre dos dígitos
                    }

                    return hexString.ToString();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al calcular el hash SHA-256", e);
            }
        }
    }

}
