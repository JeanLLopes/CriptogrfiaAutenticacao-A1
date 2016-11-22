
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace CriptografiaSimetrica.TiposCriptografia
{
    public class DESCripto
    {
        //Na criptografia "DES" o modelo de cifra é em bloco
        //Cada bloco tem 64bits de tamanho
        public byte[] GetCrypt(string mensagem, string chave, CipherMode mode, 
            [Optional]byte[] vi)
        {
            byte[] mensagembyte = System.Text.Encoding.UTF8.GetBytes(mensagem);
            byte[] chavebyte = System.Text.Encoding.UTF8.GetBytes(chave);

            //Criptografia DES
            using (var des = new DESCryptoServiceProvider())
            {
                //Precisamos saber como os blocos são criptografados
                //Modo que cifra os bloco em separado (ver slide)
                des.Mode = mode;
                des.Key = chavebyte;
                des.Padding = PaddingMode.PKCS7;

                if (vi != null)
                    des.IV = vi;

                using (var memoryStream = new MemoryStream())
                {
                    var stream = new CryptoStream(memoryStream, des.CreateEncryptor(),
                        CryptoStreamMode.Write);

                    stream.Write(mensagembyte, 0, mensagembyte.Length);

                    stream.FlushFinalBlock();

                    return memoryStream.ToArray();                    
                }
            }
        }

        public string DeCrypt(byte[] mensagemCriptografada, string chave, CipherMode mode,
            [Optional]byte[] vi)
        {
            byte[] chavebyte = System.Text.Encoding.UTF8.GetBytes(chave);

            //Criptografia DES
            using (var des = new DESCryptoServiceProvider())
            {
                //Precisamos saber como os blocos são criptografados
                //Modo que cifra os bloco em separado (ver slide)
                des.Mode = mode;
                des.Key = chavebyte;
                des.Padding = PaddingMode.PKCS7;

                if (vi != null)
                    des.IV = vi;

                using (var memoryStream = new MemoryStream())
                {
                    var stream = new CryptoStream(memoryStream, des.CreateDecryptor(),
                        CryptoStreamMode.Write);

                    stream.Write(mensagemCriptografada, 0, mensagemCriptografada.Length);

                    stream.FlushFinalBlock();

                    byte[] bytes = memoryStream.ToArray();

                    
                    return System.Text.Encoding.UTF8.GetString(bytes);
                }
            }
        }

        //Usado para mode do tipo <> do ECB
        public byte[] GetVetorInicializacao(int lenght)
        {
            //Existe uma classe que cria um array de bytes para uso

            //Vetor de inicialização do tamanho que desejo
            //inicialmente ele esta vázio
            var iv = new byte[lenght];

            var geradorBytes = new RNGCryptoServiceProvider();
            geradorBytes.GetBytes(iv);

            return iv;
        }
    }
}    