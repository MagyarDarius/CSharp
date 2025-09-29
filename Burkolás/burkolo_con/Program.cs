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
            helyiség szoba = new helyiség();
            szoba.Name = "Hálószoba";
            szoba.Description = "padlóburkolat";
            szoba.Length = 4.18;
            szoba.Width = 3.5;
            Console.WriteLine($"A {szoba.Name} területe: {szoba.Length * szoba.Width} m2");
            Console.ReadKey();
        }

    }
}
