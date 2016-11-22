using System.Text;

namespace Hash.TiposHash
{
    public class SHA1
    {
        public static string GetHash(string palavra)
        {
            //Todo Hash herda de HashAlgoritm (classe Base)
            using (var sha1 = System.Security.Cryptography.SHA1.Create())
            {
                //1 - transformamos a palavra em byte
                var bytesPalavra = Encoding.UTF8.GetBytes(palavra);

                //2 - Vamos criar o hash
                //o hash criado tem 20 bytes
                var hashbytes = sha1.ComputeHash(bytesPalavra);

                //3 - Transformar em Base64
                var hashBase64 = System.Convert.ToBase64String(hashbytes);

                return hashBase64;
            }
        }
    }
}