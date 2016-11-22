using System.Text;

namespace Hash.TiposHash
{
    public class SHA256
    {
        public static string GetHash(string palavra)
        {
            //Todo Hash herda de HashAlgoritm (classe Base)
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                //1 - transformamos a palavra em byte
                var bytesPalavra = Encoding.UTF8.GetBytes(palavra);

                //2 - Vamos criar o hash
                //o hash criado tem 32 bytes
                var hashbytes = sha256.ComputeHash(bytesPalavra);

                //3 - Transformar em Base64
                var hashBase64 = System.Convert.ToBase64String(hashbytes);

                return hashBase64;
            }
        }
    }
}