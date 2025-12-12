using System;

namespace TanulokDolgozat
{
    public class Tanulok
    {
        public string Nev { get; private set; }
        public int Pontszam { get; private set; }
        public static int MaxPontszam { get; private set; }

        public Tanulok(string nev, int pontszam)
        {
            this.Nev = nev;
            this.Pontszam = pontszam;
        }

        public static void BeallitMaxPont(int maxPont)
        {
            MaxPontszam = maxPont;
        }

        public double Szazalek()
        {
            return (double)Pontszam / MaxPontszam * 100.0;
        }

        public int Jegy()
        {
            double sz = Szazalek();

            if (sz >= 90) return 5;
            if (sz >= 75) return 4;
            if (sz >= 60) return 3;
            if (sz >= 40) return 2;
            return 1;
        }
    }
}
