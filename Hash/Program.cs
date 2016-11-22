using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Namespace que se encontra as principais classes de criptografia
using System.Security.Cryptography;

namespace Hash
{
    class Program
    {
        static void Main(string[] args)
        {
            var palavra1 = "LGroup1";
            var palavra2 = "Escola LGroup";

            var hash = TiposHash.MD5.GetHash(palavra1);
            var hash2 = TiposHash.MD5.GetHash(palavra2);
            var hash3 = TiposHash.SHA1.GetHash(palavra2);
            var hash4 = TiposHash.SHA256.GetHash(palavra2);
            var hash5 = TiposHash.SHA512.GetHash(palavra2);

            Console.WriteLine(hash);
            Console.WriteLine(hash2);
            Console.WriteLine(hash3);
            Console.WriteLine(hash4);
            Console.WriteLine(hash5);

            System.Console.ReadLine();
        }
    }
}
