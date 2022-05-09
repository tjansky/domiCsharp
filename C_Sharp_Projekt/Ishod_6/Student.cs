using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ishod_6
{
    public class Student
    {
        public Student(string ime, string prezime, bool redovan, int godiste)
        {
            Ime = ime;
            Prezime = prezime;
            Redovan = redovan;
            Godiste = godiste;
        }

        public string Ime { get; set; }
        public string Prezime { get; set; }
        public bool Redovan { get; set; }
        public int Godiste { get; set; }
    }
}
