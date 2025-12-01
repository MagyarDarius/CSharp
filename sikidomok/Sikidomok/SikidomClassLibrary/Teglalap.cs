using System;
using System.Collections.Generic;

namespace SikidomClassLibrary
{
    public class Teglalap
    {
        public double aOldal { get; private set; }
        public double bOldal { get; private set; }

        public static List<Teglalap> TeglalapokListaja = new List<Teglalap>();
        public static double OsszesKerulet { get; private set; } = 0;
        public static double OsszesTerulet { get; private set; } = 0;
        /// <summary>
        /// téglalap objektumot hoz létre
        /// </summary>
        /// <param name="aOldal">A téglalap a oldala, double tipus, pozítiv szám</param>
        /// <param name="bOldal">A téglalap b oldala, double tipus, pozítiv szám</param>
        public Teglalap(double aOldal, double bOldal)
        {
            this.aOldal = aOldal;
            this.bOldal = bOldal;

            TeglalapokListaja.Add(this);
            OsszesKerulet += TeglalapKerulet();
            OsszesTerulet += TeglalapTerulet();
        }

        public double TeglalapKerulet() => Math.Round(2 * (aOldal + bOldal), 2);
        public double TeglalapTerulet() => Math.Round(aOldal * bOldal, 2);
    }
}
