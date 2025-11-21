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
            //6.feladat
            feladat(6);
            Console.WriteLine("Szeghalom környéki aktív szállások");
            Dictionary<string, int> telepulesDict = new Dictionary<string, int>();
            foreach(var szallas in lista)
            {
                string telepulesNeve=szallas.SzallasCime.Split(' ')[1];
                if(!szallas.Statusz) continue;
                if (telepulesDict.ContainsKey(telepulesNeve))
                {
                    telepulesDict[telepulesNeve]++;
                }
                else
                {
                    telepulesDict.Add(telepulesNeve, 1);
                }
            }
            foreach(var sor in telepulesDict)
            {
                Console.WriteLine($"\t{sor.Key} : {sor.Value} db");
            }
            Console.ReadKey();
        }
        public static void feladat(int sorszam)
        {
            Console.WriteLine($"{sorszam}. Feladat:");
        }
    }
}
