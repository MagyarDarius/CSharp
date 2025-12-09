using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonyvDLL
{
    public class Konyv
    {
        public string Cim { get; private set; }
        public string Szerzo { get; private set; }
        public int LapokSzama { get; private set; }

        public int KonyvekSzama = 0;

        public Konyv(string cim, string szerzo, int lapokSzama)
        {
            this.Cim = cim;
            this.Szerzo = szerzo;
            this.LapokSzama = lapokSzama;

            KonyvekSzama++;
        }

        public int OlvasasiIdo()
        {
            return LapokSzama * 2;
        }
    }
}
