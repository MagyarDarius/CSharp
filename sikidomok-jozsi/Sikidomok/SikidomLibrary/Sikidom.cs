using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace SikidomLibrary
{
    public class Kor
    {
        public static List<double> KorKeruletek = new List<double>();
        public static List<double> KorTeruletek = new List<double>();
        public double Sugar { get; private set; }
        public Kor(double sugar)
        {
            this.Sugar = sugar;
        }


        public double korKerulet()
        {
            double kerulet = 2 * Math.PI * Sugar;
            KorKeruletek.Add(kerulet);
            return kerulet;
        }

        public double korTerulet()
        {
            double terulet = Math.PI * Sugar * Sugar;
            KorTeruletek.Add(terulet);
            return terulet;
        }
        public static List<Kor> korLista = new List<Kor>();
        public static void korFeltoltes()
        {
            while (true)
            {
                Console.WriteLine("Add meg a kör sugarát:");
                double sugar = Convert.ToDouble(Console.ReadLine());
                Kor ujKor = new Kor(sugar);

                korLista.Add(ujKor);

                // automatikusan számolunk és eltárolunk
                ujKor.korKerulet();
                ujKor.korTerulet();

                Console.WriteLine("Szeretnél még egy kört hozzáadni? (i/n)");
                string valasz = Console.ReadLine();
                if (valasz.ToLower() != "i")
                {
                    break;
                }
            }
        }
    }
    public class Teglalap
    {
        public static List<double> TeglalapKeruletek = new List<double>();
        public static List<double> TeglalapTeruletek = new List<double>();
        public double aOldal { get; private set; }
        public double bOldal { get; private set; }
        public Teglalap(double aOldal, double bOldal)
        {
            this.aOldal = aOldal;
            this.bOldal = bOldal;
        }
        public double teglalapKerulet()
        {
            double kerulet = 2 * (aOldal + bOldal);
            TeglalapKeruletek.Add(kerulet);
            return kerulet;
        }
        public double teglalapTerulet()
        {
            double terulet = aOldal * bOldal;
            TeglalapTeruletek.Add(terulet);
            return terulet;
        }
        public static List<Teglalap> teglalapLista = new List<Teglalap>();
        public static void teglalapFeltoltes()
        {
            while (true)
            {
                Console.WriteLine("a oldal:");
                double a = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("b oldal:");
                double b = Convert.ToDouble(Console.ReadLine());

                Teglalap ujTeglalap = new Teglalap(a, b);
                teglalapLista.Add(ujTeglalap);

                // automatikus számítás + tárolás
                ujTeglalap.teglalapKerulet();
                ujTeglalap.teglalapTerulet();

                Console.WriteLine("Szeretnél még egy téglalapot hozzáadni? (i/n)");
                string valasz = Console.ReadLine();
                if (valasz.ToLower() != "i")
                    break;
            }
        }
    }
}