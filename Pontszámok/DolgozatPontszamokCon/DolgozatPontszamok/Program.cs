using System;
using System.Collections.Generic;
using TanulokDolgozat;

namespace DolgozatPontszamok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Add meg a dolgozat maximális pontszámát: ");
            int MaxPont = int.Parse(Console.ReadLine());
            Tanulok.BeallitMaxPont(MaxPont);

            List<Tanulok> diakok = new List<Tanulok>();

            while (true)
            {
                Console.Write("\nDiák neve (vége = kilépés): ");
                string nev = Console.ReadLine();

                if (nev.ToLower() == "vége" || nev.ToLower() == "vege")
                    break;

                Console.Write("Elért pontszám: ");
                int pont = int.Parse(Console.ReadLine());

                diakok.Add(new Tanulok(nev, pont));
            }

            Console.WriteLine("\n--- EREDMÉNYEK ---\n");

            foreach (var d in diakok)
            {
                Console.WriteLine($"Név: {d.Nev}");
                Console.WriteLine($"Pontszám: {d.Pontszam}/{Tanulok.MaxPontszam}");
                Console.WriteLine($"Százalék: {d.Szazalek():0.00}%");
                Console.WriteLine($"Jegy: {d.Jegy()}");
            }

        }
    }
}
