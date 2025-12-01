using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SikidomClassLibrary;

namespace SikidomCon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. rész: Kör adatok gyűjtése \n" + "\t Add meg a kör sugarát (üres ENTER=vége) \n");
            while (true)
            {
                Console.Write("--> ");
                string input = Console.ReadLine();
                if (input == "") break;
                try
                {
                    double sugar = double.Parse(input);
                    if (sugar > 0)
                    {
                        //példányositás
                        var ujObj = new Kor(sugar);
                    }
                    else
                    {
                        continue;
                    }
                    ;

                }
                catch
                {
                    Console.WriteLine("Helyes adatokat kérek.");
                }
            }
            Console.WriteLine("\nkörök adatainak listázása\n");
            foreach(var kor in Kor.KorokListaja)
            {
                    Console.WriteLine($"A(z) {kor.sugar} sugarú kör kerülete: {kor.KorKerulet()} Területe: {kor.KorTerulet()}");
            }
            Console.WriteLine($"\nÖsszes Kerület: {Kor.OsszesKerulet} \n" + $"Összes Terület: {Kor.OsszesTerulet}");

            Console.ReadKey();
            
        }
    }
}
