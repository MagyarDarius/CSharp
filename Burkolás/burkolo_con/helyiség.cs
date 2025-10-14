using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace burkolo_con
{
    internal class helyiség
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public double Length { get; private set; }
        public double Width { get; private set; }

        private static List<helyiség> placelist = new List<helyiség>();
        public static int counter { get; private set; } = 0;
        public static double TotalArea { get; private set; } = 0;

        public helyiség(string name, string description, double length, double width)
        {
            this.Name = name;
            this.Description = description;
            this.Length = length;
            this.Width = width;
            counter++;
            TotalArea+= length * width;
        }
        public double Area()
        {
            return this.Length * this.Width;
        }
        public double Perimeter()
        {
            return 2 * this.Length + this.Width;
        }
        public static double AreaStatic(double a, double b)
        {
            return a * b;
        }
        public static void SaveToFile(List<helyiség> PlaceList)
        {
            try
            {
                StreamWriter sw = new StreamWriter("places.csv");
                foreach (helyiség h in PlaceList)
                {
                    sw.WriteLine($"{h.Name};{h.Description};{h.Length};{h.Width}");
                }
                sw.Close();
            }
            catch (IOException ex)
            {
                Console.WriteLine("Hiba a fájl írása közben: " + ex.Message);
            }
        }
        public static List<helyiség> LoadFromFile()
        {
            List<helyiség> PlaceList = new List<helyiség>();
            try
            {
                StreamReader sr = new StreamReader("places.csv");
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] parts = line.Split(';');
                    helyiség h = new helyiség(parts[0], parts[1], double.Parse(parts[2]), double.Parse(parts[3]));
                    PlaceList.Add(h);
                }
                sr.Close();

            }
            catch (IOException ex)
            {
                Console.WriteLine("Hiba a fájl olvasása közben: " + ex.Message);
            }
            return PlaceList;
        }
        public static List<helyiség> DataLoader()
        {
            List<helyiség> PlaceList = new List<helyiség>();
            while (true)
            {
                Console.WriteLine("Add meg egy helyiség adatait!");
                Console.Write("Neve: ");
                string name = Console.ReadLine();
                if (name == "") break;
                Console.Write("Megjegyzés ");
                string description = Console.ReadLine();
                Console.Write("Hossza: ");
                double length = double.Parse(Console.ReadLine());
                Console.Write("Szélessége: ");
                double width = double.Parse(Console.ReadLine());

                helyiség szoba = new helyiség(name, description, length, width);
                /*szoba.Name = name;
                szoba.Description = Description;
                szoba.Length = Length;
                szoba.Width = Width;*/
                PlaceList.Add(szoba);
            }
            return PlaceList;
        }
        public static void HelyisegLister(List<helyiség> placelist)
        {
            Console.WriteLine("Helyiségek listája:");
            foreach (helyiség h in placelist)
            {
                Console.WriteLine($"Név: {h.Name}, Terület: {h.Area()} m2, Kerület: {h.Perimeter()}");
            }
            Console.WriteLine($"Helyiségek száma: {helyiség.counter}");
            Console.WriteLine($"A szobák összterülete: {helyiség.TotalArea}m2");
        }
    }
}