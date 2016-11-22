
using System.Security.Cryptography;

namespace Hmac.TiposHmac
{
    public class HMACSHA1
    {
        //O HMAC é a combinação de um hash + senha
        public static string HMAC(string palavra, string senha)
        {
            //Transformanda a senha em byte
            byte[] senhaByte = System.Text.Encoding.UTF8.GetBytes(senha);
            //Transformanda a palavra em byte
            byte[] palavraByte = System.Text.Encoding.UTF8.GetBytes(palavra);

            //Usando a função hash HMAC e passando a senha no construtor
            using (var hmac = new  System.Security.Cryptography.HMACSHA1(senhaByte))
            {
                //Gerando o hash
                byte[] hashByte = hmac.ComputeHash(palavraByte);

                //Transformando em base64
                string hashBase64 = System.Convert.ToBase64String(hashByte);

                //Retornando
                return hashBase64;
            }
        }
    }
}