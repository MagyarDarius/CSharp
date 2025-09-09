using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szallas
{
    internal class Program
    {
        public struct Szallas
        {
            public string nev, cim, uzletnev, uzletcim, szallastip, tel;
            public int szobaszam, agyszam;
            public bool status;
        }
        static void Main(string[] args)
        {
            var szallasok = ProcessCsvData();

            foreach (var sz in szallasok)
            {
                Console.WriteLine($"{sz.nev}, {sz.cim}, {sz.uzletnev}, {sz.status}");
            }
            Console.WriteLine($"4. feladat: Szálláshelyek száma: {szallasok.Count-1} db");

            Console.ReadLine();
        }
        static List<Szallas> ProcessCsvData()
        {
            List<Szallas> products = new List<Szallas>();

            try
            {
                string[] lines = File.ReadAllLines("szallas2022.csv");

                foreach (string line in lines)
                {
                    string[] values = line.Split(';');

                    if (values.Length == 9)
                    {
                        Szallas sz = new Szallas
                        {
                            nev = values[0],
                            cim = values[1],
                            uzletnev = values[2],
                            uzletcim = values[3],
                            szallastip = values[4],
                            tel = values[5],
                            szobaszam = int.TryParse(values[6], out int szobaszam) ? szobaszam : 0,
                            agyszam = int.TryParse(values[7], out int agyszam) ? agyszam : 0,
                            status = values[8].ToLower() == "true" || values[8] == "1"
                        };

                        products.Add(sz);
                    }
                    else
                    {
                        Console.WriteLine($"Hibás sor: {line}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba a fájl beolvasásakor: {ex.Message}");
            }

            return products;
        }

    }
}
