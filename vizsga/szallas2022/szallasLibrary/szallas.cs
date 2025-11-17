using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace szallasLibrary
{
    public class szallas
    {
        public string _szallasNeve;
        public string Szallasneve { get; private set; }
        public string SzallasCime { get; private set; }
        public int Szobaszam { get; private set; }
        public int Agyszam { get; private set; }
        public string UzemeltetoNeve { get; private set; }
        public string UzemeltetoCime { get; private set; }
        public string UzemeltetoTelefonszama { get; private set; }
        public bool Statusz { get; private set; }
        public string TevekenysegTipusa { get; private set; }
        public static List<szallas> SzallasokListaja = new List<szallas>();
        public static int szallasdarab { get; private set; } = 0;
        public static int aktívSzallasokSzama { get; private set; } = 0;
        public static int aktívAgyszam { get; private set; } = 0;

        public szallas(string sor)
        {
            string[] db=sor.Split(';');
            this.Szallasneve = db[0];
            this.SzallasCime = db[1];
            this.Szobaszam = int.Parse(db[2]);
            this.Agyszam = int.Parse(db[3]);
            this.UzemeltetoNeve = db[4];
            this.UzemeltetoCime = db[5];
            this.UzemeltetoTelefonszama = db[6];
            if (db[7]=="Aktív") this.Statusz = true;
            else this.Statusz = false;
            this.TevekenysegTipusa = db[8];
            szallasdarab++;
            if (this.Statusz == true)
            {
                aktívSzallasokSzama++;
                aktívAgyszam += this.Agyszam;
            }
        }

        public static List<szallas> FileBetoltes(string filename)
        {
            try
            {
                var sr = new StreamReader(filename);
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    var ujObjektum = new szallas(sr.ReadLine());
                    SzallasokListaja.Add(ujObjektum);
                }
                sr.Close();
            }
            catch(Exception ex) 
            {
                Console.WriteLine("hiba a file betöltése során" + ex.Message);
            }
            return SzallasokListaja;
        }
        

    }
}
