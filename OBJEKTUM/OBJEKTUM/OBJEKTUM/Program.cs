using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            dog buksi = new dog();
            buksi.name = "Buksi";
            buksi.age = 5;
        }
    } 
    internal class dog
    {
        public string name;
        public int age;
    }
}
