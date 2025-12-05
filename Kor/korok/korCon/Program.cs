using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KorClassLibrary;

namespace korCon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Kor ujKor = new Kor(1.4);
            var ujKor2 = new Kor(3.14);
            Console.WriteLine(ujKor.Sugar);
            Console.WriteLine($"A kör K: {ujKor.Kerulet()}, T: {ujKor.Terulet()}");
            Console.WriteLine(Kor.KorokSzama);
            Console.WriteLine(Kor.StaticKerulet(1));
            Console.ReadKey();
        }
    }
}
