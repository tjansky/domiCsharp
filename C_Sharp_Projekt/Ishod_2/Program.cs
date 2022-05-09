// See https://aka.ms/new-console-template for more information
using Ishod_2;

// inicijalizacija varijabli
List<string> listaKolegija = new List<string> { "Baze podataka", "Web dizajn", "Operacijski sustavi" };

Osoba profesor = new Profesor("Tomislav", "Peric", "dr.sc.eng.", false);
Osoba student = new Student("Domagoj", "Jansky", 2, listaKolegija);
Osoba profesor2 = new Profesor("Marina", "Ivic", "in.teh.", true);
Osoba student2 = new Student("Marta", "Stimac", 2, listaKolegija);

// dodavanje objekata u zajednicki array
Osoba[] osobe =  new Osoba[4];
osobe[0] = profesor;
osobe[1] = student;
osobe[2] = profesor2;
osobe[3] = student2;


// POLIMORFIZAM
foreach (var o in osobe)
{
    Console.WriteLine(o.ReciTkoSi());
}

// Polimorfizam omogućava nasljeđenim klasama (Profesor, Student) definiranje svoje
// verzije metoda koje su naslijedile od bazne klase pomoću
// nadglasavanja metoda (engl. method overriding).
// U ovom slucaju metoda "ReciTkoSi()"