using System;
using System.Collections.Generic;

namespace burkolo_con
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            //helyiség.Converter("places.csv", "festo.csv");
            var placeList = helyiség.DataLoader();
            helyiség.SaveToFile(placeList);
            List<helyiség> loadedPlaceList = helyiség.LoadFromFile("places.csv");
            helyiség.HelyisegLister(loadedPlaceList);

            Console.ReadKey();
        }
    }
}
