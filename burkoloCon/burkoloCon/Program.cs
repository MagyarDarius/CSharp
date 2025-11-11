using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace burkoloCon
{
    internal class Program
    {
        static List<Helyiseg> placeList;
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            //Helyiseg.Converter("places.csv", "festo.csv");
            placeList = Helyiseg.ReadFromFile2("places.csv");
            placeList = Helyiseg.DataLoader();
            Helyiseg.SaveToFile("places.csv", placeList);
            Helyiseg.HelyisegLister(placeList);
            var newObj1 = new Helyiseg("a", "b", 2.4, 5.4);
            var newObj2 = new Helyiseg("a", "b", 2.4, 5.4, 2.7);
            //Console.WriteLine($"A 3.5 * 4.5 m-es szoba területe: {Helyiseg.AreaStatic(3.5, 4.5)} m\u00B2");
            Console.ReadKey();
        }
    }
}
