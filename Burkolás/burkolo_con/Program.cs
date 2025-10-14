using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace burkolo_con
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            var PlaceList = helyiség.DataLoader();
            helyiség.SaveToFile(PlaceList);
            var LoadedPlaceList = helyiség.LoadFromFile();
            helyiség.HelyisegLister(LoadedPlaceList);
            Console.ReadKey();
        }

    }
}
