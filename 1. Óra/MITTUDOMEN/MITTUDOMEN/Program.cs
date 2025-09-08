using System;
using System.Collections.Generic;
using System.IO;

namespace MITTUDOMEN
{
    internal class Program
    {
        struct termek
        {
            public string Termek;
            public int Ar;

            public termek(string termek, int ar)
            {
                Termek = termek;
                Ar = ar;
            }

            public override string ToString()
            {
                return $"{Termek} , {Ar} Ft";
            }
        }

        static void Main(string[] args)
        {
            List<termek> products = ProcessCsvData();

            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
            PrintMaxMinPrices(products);
            SumPrices(products);
        }

        static List<termek> ProcessCsvData()
        {
            List<termek> products = new List<termek>();

            try
            {
                string[] lines = File.ReadAllLines("termekek.csv");

                for (int i = 0; i < lines.Length; i++)
                {
                    string[] values = lines[i].Split(';');

                    if (values.Length >= 2)
                    {
                        string termek = values[0];
                        if (int.TryParse(values[1], out int ar))
                        {
                            products.Add(new termek(termek, ar));
                        }
                        else
                        {
                            Console.WriteLine($"Hiba az ár értelmezésében: {values[1]}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba a fájl beolvasásakor: {ex.Message}");
            }

            return products;
        }
        static void PrintMaxMinPrices(List<termek> products)
        {
            if (products.Count == 0)
            {
                Console.WriteLine("Nincs termék az adatok között.");
                return;
            }

            termek maxPriceProduct = products[0];
            termek minPriceProduct = products[0];

            foreach (var product in products)
            {
                if (product.Ar > maxPriceProduct.Ar)
                {
                    maxPriceProduct = product;
                }
                if (product.Ar < minPriceProduct.Ar)
                {
                    minPriceProduct = product;
                }
            }

            Console.WriteLine();
            Console.WriteLine($"Legdrágább termék: {maxPriceProduct}");
            Console.WriteLine($"Legolcsóbb termék: {minPriceProduct}");
        }
        static void SumPrices(List<termek> products)
        {
            int total = 0;

            foreach (var product in products)
            {
                total += product.Ar;
            }

            Console.WriteLine();
            Console.WriteLine($"Összes termék ára: {total} Ft");
        }
    }
}
