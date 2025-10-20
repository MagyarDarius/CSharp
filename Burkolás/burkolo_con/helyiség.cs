using System;
using System.Collections.Generic;
using System.IO;

namespace burkolo_con
{
    internal class helyiség
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public double Length { get; private set; }
        public double Width { get; private set; }
        public double Height { get; private set; }

        public static int counter { get; private set; } = 0;
        public static double TotalArea { get; private set; } = 0;
        public static double TotalPerimeter { get; private set; } = 0;

        public helyiség(string name, string description, double length, double width)
        {
            this.Name = name;
            this.Description = description;
            this.Length = length;
            this.Width = width;
            this.Height = 0;

            counter++;
            TotalArea += length * width;
            TotalPerimeter += 2 * (length + width);
        }

        public helyiség(string name, string description, double length, double width, double height) : this(name, description, length, width)
        {
            this.Height = height;
        }

        public double Area() => Length * Width;

        public double Perimeter() => 2 * (Length + Width);

        public static double AreaStatic(double a, double b) => a * b;

        public static void SaveToFile(List<helyiség> placeList)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("places.csv"))
                {
                    foreach (helyiség h in placeList)
                    {
                        if (h.Height > 0)
                        {
                            sw.WriteLine($"{h.Name};{h.Description};{h.Length};{h.Width};{h.Height}");
                        }
                        else
                        {
                            sw.WriteLine($"{h.Name};{h.Description};{h.Length};{h.Width}");
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Hiba a fájl írása közben: " + ex.Message);
            }
        }

        public static List<helyiség> LoadFromFile(string filename)
        {
            List<helyiség> loadedList = new List<helyiség>();
            try
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] parts = line.Split(';');

                        if (parts.Length == 4)
                        {
                            helyiség obj = new helyiség(
                                parts[0],
                                parts[1],
                                double.Parse(parts[2]),
                                double.Parse(parts[3]));
                            loadedList.Add(obj);
                        }
                        else if (parts.Length == 5)
                        {
                            helyiség obj = new helyiség(
                                parts[0],
                                parts[1],
                                double.Parse(parts[2]),
                                double.Parse(parts[3]),
                                double.Parse(parts[4]));
                            loadedList.Add(obj);
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Hiba a fájl olvasása közben: " + ex.Message);
            }

            return loadedList;
        }

        public static List<helyiség> DataLoader()
        {
            List<helyiség> placeList = new List<helyiség>();

            while (true)
            {
                Console.WriteLine("Add meg egy helyiség adatait!");
                Console.Write("Neve: ");
                string name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name)) break;

                Console.Write("Megjegyzés: ");
                string description = Console.ReadLine();

                Console.Write("Hossza (m): ");
                double length = double.Parse(Console.ReadLine());

                Console.Write("Szélessége (m): ");
                double width = double.Parse(Console.ReadLine());

                Console.Write("Magassága (m) [opcionális, Enter ha nincs]: ");
                string heightInput = Console.ReadLine();
                double height = 0;

                helyiség szoba;

                if (!string.IsNullOrWhiteSpace(heightInput))
                {
                    height = double.Parse(heightInput);
                    szoba = new helyiség(name, description, length, width, height);
                }
                else
                {
                    szoba = new helyiség(name, description, length, width);
                }

                placeList.Add(szoba);
            }

            return placeList;
        }

        public static void HelyisegLister(List<helyiség> placeList)
        {
            Console.WriteLine("\nHelyiségek listája:");
            foreach (helyiség h in placeList)
            {
                string heightText = h.Height > 0 ? $", Magasság: {h.Height} m" : "";
                Console.WriteLine($"Név: {h.Name}, Terület: {h.Area()} m², Kerület: {h.Perimeter()} m{heightText}");
            }

            Console.WriteLine($"\nHelyiségek száma: {counter}");
            Console.WriteLine($"A szobák összterülete: {TotalArea} m²");
            Console.WriteLine($"A szobák összkerülete: {TotalPerimeter} m");
        }

        public static void Converter(string filenameIn, string filenameOut)
        {
            try
            {
                List<helyiség> places = LoadFromFile(filenameIn);
                using (StreamWriter sw = new StreamWriter(filenameOut))
                {
                    foreach (helyiség h in places)
                    {
                        sw.WriteLine($"{h.Name};{h.Description};{h.Length};{h.Width};2.7");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hiba a konvertálás közben: " + ex.Message);
            }
        }
    }
}
