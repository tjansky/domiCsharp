using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ishod_2
{
    public class Profesor : Osoba
    {
        // svojstva
        public string Titula { get; set; }
        public bool JeVoditelj { get; set; }


        // konstruktor
        public Profesor(string ime, string prezime, string titula, bool jeVoditelj) : base(ime, prezime)
        {
            Titula = titula;
            JeVoditelj = jeVoditelj;
        }


        // override-ana metoda iz bazne klase
        public override string ReciTkoSi()
        {
            return "Ja sam Profesor";
        }


        // metode
        public void PostaviProfesoraUVoditelja()
        {
            JeVoditelj = true;
            Console.WriteLine("Profesor je postao voditelj");
        }

        public void IspisiTituluProfesora()
        {
            Console.WriteLine("Titula profesora je: " + Titula);
        }

        public void PromjeniTituluProfesoru(string titula)
        {
            Titula = titula;
            Console.WriteLine("Profesor je promjenio titulu u: " + titula);
        }
    }
}
