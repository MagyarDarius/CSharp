using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KonyvDLL;

namespace Konyvnyilvantartas
{
    internal class Konyvnyilvantartas
    {
        static void Main(string[] args)
        {
            try
            {
                List<Konyv> konyvek = new List<Konyv>();

                while (true)
                {
                    Console.Write("Könyv címe (stop = kilépés): ");
                    string cim = Console.ReadLine();

                    if (cim == "stop")
                        break;

                    Console.Write("Kérek egy Szerzőt: ");
                    string szerzo = Console.ReadLine();

                    Console.Write("Kérem Az Oldalszámot: ");
                    int lapok = int.Parse(Console.ReadLine());

                    Konyv K = new Konyv(cim, szerzo, lapok);

                    konyvek.Add(K);


                    Console.WriteLine("Könyv rögzítve.\n");
                }
                foreach (Konyv k in konyvek)
                {
                    Console.WriteLine($"Cím: {k.Cim},\n Szerző: {k.Szerzo},\n Oldalszám: {k.LapokSzama},\n Olvasási idő: {k.OlvasasiIdo()} perc\n");
                }
                Console.WriteLine($"Az összes könyvek száma{konyvek.Count}");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Hiba a kódban" + ex.Message);
            }
            
            Console.ReadKey();
        }
    }
}
