using CriptografiaSimetrica.TiposCriptografia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CriptografiaSimetrica
{
    class Program
    {
        static void Main(string[] args)
        {
            var mensagem = "Lgroup Treinamentos";
            var chave = "123Troca";
            var desCripto = new DESCripto();

            //No DES o tamanho do bloco é de 8 bytes
            var iv = desCripto.GetVetorInicializacao(8);

            //Tipo cifra de bloco
            var mode1 = CipherMode.ECB;

            //Criptografando a mensagem
            //Para o tipo ECB
            var msgCript = desCripto.GetCrypt(mensagem, chave, mode1);

            //Palavra criptgrafada
            var base641 = Convert.ToBase64String(msgCript);

            //Decriptografando a mensagem
            var msgDeCript = desCripto.DeCrypt(msgCript, chave, mode1);


            //COM VETOR DE INICIALIZACAO

            var mode2 = CipherMode.CBC;

            //Criptografando a mensagem
            //Para o tipo ECB
            var msgCript2 = desCripto.GetCrypt(mensagem, chave, mode2, iv);

            //Palavra criptgrafada
            var base642 = Convert.ToBase64String(msgCript2);

            //Decriptografando a mensagem
            var msgDeCript2 = desCripto.DeCrypt(msgCript2, chave, mode2, iv);

        }
    }
}
