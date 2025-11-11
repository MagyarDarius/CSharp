using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace burkoloCon
{
    internal class Helyiseg
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public double Lenght { get; private set; }
        public double Width { get; private set; }
        public double Height { get; private set; }

        private static List<Helyiseg> placeList = new List<Helyiseg>();
        public static int Count { get; private set; } = 0;
        public static double FullArea { get; private set; } = 0;
        public static double FullPerimeter { get; private set; } = 0;
        public helyiseg(string line)
        {
            string[] items = line.Split(';');
            this.Name = items[0];
            this.Description = items[1];
            this.Lenght = double.Parse(items[2]);
            this.Width = double.Parse(items[3]);
            if (items.Length > 4)
            {
                this.Height = double.Parse(items[4]);
            }
            else this.Height = 2.7;
            Count++;
            FullArea += this.Lenght * this.Width;
            FullPerimeter += Perimeter();
        }

        public Helyiseg(string name, string desc, double length, double width) 
        {
            this.Name = name;
            this.Description = desc;
            this.Lenght = length;
            this.Width = width;
            Count++;
            FullArea += length * width;
            FullPerimeter += Perimeter();
        }

        public Helyiseg(string name, string description, double lenght, double width, double height) : this(name, description, lenght, width)
        {
            this.Height = height;
        }

        public double FloorArea()
        {
            return this.Lenght*this.Width;
        }

        public double Perimeter()
        {
            return 2*this.Width + 2*this.Lenght;
        }

        public double NeedsToBePaintWall()
        {
            return 2*(this.Width*this.Height) + 2*(this.Lenght*this.Height);
        }

        public double CeilingArea()
        {
            return this.Lenght * this.Width;
        }


        public static double AreaStatic(double a, double b)
        {
            return a + b;
        }

        public static List<Helyiseg> DataLoader()
        {
            while (true)
            {
                Console.WriteLine("Add meg egy helyiség adatait! ");
                Console.Write("Neve (<ENTER>= vége): ");
                string name = Console.ReadLine();
                if (name == "") break;
                Console.Write("Megjegyzés: ");
                string description = Console.ReadLine();
                Console.Write("Hossza: ");
                double length = double.Parse(Console.ReadLine());
                Console.Write("Széle: ");
                double width = double.Parse(Console.ReadLine());
                Console.Write("Magasság: ");
                double height = double.Parse(Console.ReadLine());

                Helyiseg szoba = new Helyiseg(name,description,length,width,height);
                /*szoba.Name = name;
                szoba.Description = description;
                szoba.Lenght = length;
                szoba.Width = width;*/
                placeList.Add(szoba);
            }
            return placeList;
        }

        public static void SaveToFile(string filename, List<Helyiseg> placeList)
        {
            try
            {
                StreamWriter sw = new StreamWriter(filename);
                foreach (var item in placeList)
                {
                    sw.WriteLine($"{item.Name};{item.Description};{item.Lenght};{item.Width};{item.Height}");
                }
                sw.Close();
            }
            catch
            {
                Console.WriteLine("Hiba a file írása során");
            }
        }

        public static List<Helyiseg> ReadFromFile(string filename)
        {
            
            try
            {
                var reader = new StreamReader(filename);
                while(!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    string[] lineDb = line.Split(';');
                    if (lineDb.Length == 4)
                    {
                        var newObj = new Helyiseg(lineDb[0], lineDb[1], double.Parse(lineDb[2]), double.Parse(lineDb[3]));
                        placeList.Add(newObj);
                    }
                    if (lineDb.Length == 5)
                    {
                        var newObj = new Helyiseg(lineDb[0], lineDb[1], double.Parse(lineDb[2]), double.Parse(lineDb[3]), double.Parse(lineDb[4]));
                        placeList.Add(newObj);
                    }
                    /*newObj.Name = ;
                    newObj.Description = ;
                    newObj.Lenght=;
                    newObj.Width = ;*/
                }
                reader.Close();
            }
            catch
            {
                Console.WriteLine("Hiba a file olvasása során");
            }

            return placeList;
        }
        public static List<Helyiseg> ReadFromFile2(string filename)
        {
            try
            {
                var reader = new StreamReader(filename);
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var newObj = new Helyiseg(line);
                    placeList.Add(newObj);
                }
                reader.Close();
            }
            catch
            {
                Console.WriteLine("Hiba a file olvasása során");
            }
            return placeList;
            
        }

        public static void HelyisegLister(List<Helyiseg> placeList)
        {
            foreach (Helyiseg h in placeList)
            {
                Console.WriteLine($"{h.Name}, terület: {h.FloorArea()} m\u00B2, szegély hossz: {h.Perimeter()} m ");
                //h.Name = "előszoba";

            }
            Console.WriteLine($"Helyiségek száma: {Count} db");
            Console.WriteLine($"Összterület: {FullArea} m\u00B2");
            Console.WriteLine($"Össz szegélyhossz: {FullPerimeter} m");
        }

        /*public static void Converter(string filenameIn, string filenameOut)
        {
            try
            {
                placeList = ReadFromFile(filenameIn);
                StreamWriter sw=new StreamWriter(filenameOut);
                foreach (Helyiseg h in placeList)
                {
                    sw.WriteLine($"{h.Name};{h.Description};{h.Lenght};{h.Width};2,7");
                }
                sw.Close();
            }
            catch
            {
                Console.WriteLine("Hiba a konvertálás során!");
            }
        }*/
    }
}
