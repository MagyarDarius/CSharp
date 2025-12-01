using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SikidomClassLibrary
{
    public class Kor
    {
        public double sugar { get; private set; }
        public static List<Kor> KorokListaja = new List<Kor>();
        public static double OsszesKerulet { get; private set; } = 0;
        public static double OsszesTerulet { get; private set; } = 0;

        public Kor(double sugar)
        {
            this.sugar = sugar;
            OsszesKerulet += this.KorKerulet();
            OsszesTerulet += this.KorTerulet();
            KorokListaja.Add(this);
        }
        public double KorKerulet()
        {
            return Math.Round(this.sugar * 2 * Math.PI, 2);
        }
        public double KorTerulet()
        {
            return Math.Round( Math.Pow(this.sugar, 2) * Math.PI, 2);
        }
    }
}
