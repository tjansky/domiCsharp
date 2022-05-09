using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ishod_2
{
    abstract public class Osoba
    {
        // svojstva
        public string Ime { get; set; }
        public string Prezime { get; set; }


        // konstruktor
        protected Osoba(string ime, string prezime)
        {
            Ime = ime;
            Prezime = prezime;
        }


        // virtual metoda
        public virtual string ReciTkoSi()
        {
            return "Ja sam Osoba";
        }

        // metode
        public void PromjeniIme(string ime)
        {
            Ime = ime;
        }

        public void PromjeniPrezime(string prezime)
        {
            Prezime = prezime;
        }

        public void IspisiImePrezime()
        {
            Console.WriteLine("Ime: " + Ime);
            Console.WriteLine("Prezime: " + Prezime);
        }
    }
}
