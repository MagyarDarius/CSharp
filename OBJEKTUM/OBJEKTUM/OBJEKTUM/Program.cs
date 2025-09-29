using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OBJEKTUM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            dog bodri = new dog();
            bodri.name = "Bodri";
            bodri.age = 3;
            dog ubul = new dog();
            ubul.name = "ubul";
            ubul.age = 5;
            Console.WriteLine($"{bodri.name} Kutya {bodri.age} Éves");
            Console.WriteLine($"{ubul.name} Kutya {ubul.age} Éves");
            bodri.bark();
            ubul.eat();
            Car mercedes = new Car();
            mercedes.Brand = "Mercedes-Benz";
            mercedes.Plate = "JPG-387";
            mercedes.Year = 2000;
            mercedes.Speed = 260;
            mercedes.FuelConsumption = 6.4;
            Console.WriteLine($"A kocsi márkája: {mercedes.Brand}, Rendszáma: {mercedes.Plate}, Gyártási éve: {mercedes.Year}, Végsebessége: {mercedes.Speed} km/h, Fogyasztása: {mercedes.FuelConsumption} l/100km");
            Console.WriteLine("Add meg a megtett távolságot km-ben:");
            int Dis = int.Parse(Console.ReadLine());
            mercedes.Distance(Dis);
            mercedes.TimeDistance(Dis);
            Console.ReadKey();
        }
    }
    internal class dog
    {
        public string name;
        public int age;

        public void bark()
        {
            Console.WriteLine($"{name}: Vau Vau");
        }
        public void eat()
        {
            Console.WriteLine($"{name}: Nom Nom");
        }
        public void sleep()
        {
            Console.WriteLine("Zzz Zzz");
        }
        public void drink()
        {
            Console.WriteLine("Glug Glug");

        }
    }
    internal class Car
    {
        public string Brand, Plate;
        public int Year, Speed;
        public double FuelConsumption;

        public void Distance(int distance)
        {
            double fuelNeeded = (FuelConsumption / 100) * distance;
            Console.WriteLine($"A megtett távolság: {distance} km, Szükséges üzemanyag: {fuelNeeded} l");
        }
        public void TimeDistance(int distance)
        {
            double hours = (double)distance / Speed;

            TimeSpan travelTime = TimeSpan.FromHours(hours);

            Console.WriteLine($"Max sebességen az út megtétele: {travelTime.Hours} óra {travelTime.Minutes} perc {travelTime.Seconds} másodperc");
        }
    }
}