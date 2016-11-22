
using System.Security.Cryptography;
using System.Text;

namespace Hash.TiposHash
{
    //O Hash formado tem 128 bit = 16 bytes
    public class MD5
    {
        public static string GetHash(string palavra)
        {
            //Todo Hash herda de HashAlgoritm (classe Base)
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                //1 - transformamos a palavra em byte
                var bytesPalavra = Encoding.UTF8.GetBytes(palavra);

                //2 - Vamos criar o hash
                //o hash criado tem 16 bytes
                var hashbytes = md5.ComputeHash(bytesPalavra);

                //3 - Transformar em Base64
                var hashBase64 = System.Convert.ToBase64String(hashbytes);

                return hashBase64;
            }
        }


    }
}