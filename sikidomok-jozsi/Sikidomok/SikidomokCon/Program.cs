using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SikidomLibrary;

namespace SikidomokCon
{
    internal class Program
    {
        public static List<Kor> korLista = new List<Kor>();
        public static List<Teglalap> teglalapLista = new List<Teglalap>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Kört vagy téglalapot szeretnél megadni? (k / t)");
                string valasz = Console.ReadLine();
                if(valasz.ToLower() == "k")
                {
                    Kor.korFeltoltes();
                }
                else if (valasz.ToLower() == "t")
                {
                    Teglalap.teglalapFeltoltes();
                }
                else if (valasz.ToLower() == "")
                {
                    Console.WriteLine("\nÖsszegzés:\n");
                    Console.Write("Kör kerületek: ");
                    foreach (double k in Kor.KorKeruletek)
                    {
                        Console.Write(k + " ");
                    }
                    Console.WriteLine();
                    Console.Write("Kör területek: ");
                    foreach (double t in Kor.KorTeruletek)
                    {
                        Console.Write(t + " ");
                    }
                    Console.WriteLine();
                    Console.Write("Téglalap kerületek: ");
                    foreach (double k in Teglalap.TeglalapKeruletek)
                    {
                        Console.Write(k + " ");
                    }
                    Console.WriteLine();
                    Console.Write("Téglalap területek: ");
                    foreach (double t in Teglalap.TeglalapTeruletek)
                    {
                        Console.Write(t + " ");
                    }
                    Console.WriteLine();
                    break;
                }
                else
                {
                    Console.WriteLine("Érvénytelen válasz, kérlek válassz 'k' vagy 't' között.");
                }
            }
        }
    }
}