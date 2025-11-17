using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using szallasLibrary;

namespace szallascon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lista = szallas.FileBetoltes("szallas2022.csv");
            // 4.feladat
            feladat(4);
            Console.WriteLine($"Az összes szálláshelyek száma: {lista.Count} darab");
            Console.WriteLine($"Az összes szálláshelyek száma: {szallas.szallasdarab} darab");
            //5.feladat
            feladat(5);
            Console.WriteLine($"Átlagos ágyszám az aktív szálláshelyeken {(double)szallas.aktívAgyszam/(double)szallas.aktívSzallasokSzama:f2}");

            Console.ReadKey();
        }
        public static void feladat(int sorszam)
        {
            Console.WriteLine($"{sorszam}. Feladat:");
        }
    }
}
