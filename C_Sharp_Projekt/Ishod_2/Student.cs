using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ishod_2
{
    public class Student : Osoba
    {
        // svojstva
        public List<string> Kolegiji { get; set; }

        // ENKAPSULACIJA svojstva GodinaStudiranja
        private int godinaStudiranja;
        public int GodinaStudiranja { 
            get {
                return godinaStudiranja;
            }
            set { 
                if (value > 3 && value < 0)
                {
                    throw new Exception("Godina studiranja ne može biti manja od 0 i veca od 3!");
                }
            } 
        }


        // konstruktor
        public Student(string ime, string prezime, int godinaStudiranja, List<string> kolegiji) : base(ime, prezime)
        {
            this.godinaStudiranja = godinaStudiranja;
            Kolegiji = kolegiji;
        }


        // override-ana metoda iz bazne klase
        public override string ReciTkoSi()
        {
            return "Ja sam Student";
        }


        // metode
        public void IsprintajStudentInfo()
        {
            Console.WriteLine("----------------");
            Console.WriteLine("Ime: " + Ime);
            Console.WriteLine("Prezime: " + Prezime);
            Console.WriteLine("Godina studiranja: " + GodinaStudiranja);
            Console.WriteLine("Kolegiji: ");
            foreach (string kol in Kolegiji)
            {
                Console.WriteLine("-" + kol);
            }
            Console.WriteLine("----------------");
        }

        public void DodajKolegijStudentu(string nazivKolegija)
        {
            Kolegiji.Add(nazivKolegija);
            Console.WriteLine("Studentu je dodan kolegij: " + nazivKolegija);
        }

        public void ObrisiKolegijeStudentu()
        {
            Kolegiji = new List<string>();
            Console.WriteLine("Studentu su obrisani svi kolegiji");
        }
    }
}
