// See https://aka.ms/new-console-template for more information
using System.Collections;

Console.WriteLine("Hello, World!");

// anonimna klasa
var knjiga = new { Naziv = "The Sapiens", BrojStranica = 246, GodinaIzdanja = 2019 };


// generičke kolekcije
//      -Brže izvođenje koda.
//      -Sigurniji kod - kolekcija će zajamčeno pohraniti samo podatke koji
//       su odgovarajućeg tipa
List<int> generickaLista = new List<int>();
generickaLista.Add(1);
generickaLista.Add(2);
generickaLista.Add(3);


// negeneričke kolekcije
//    -Slabije performanse
//    -Negeneričke nisu tipski sigurne
ArrayList negenerickaLista = new ArrayList();

negenerickaLista.Add("nesto");
negenerickaLista.Add(1);
negenerickaLista.Add(true);


// izrada generika (genericka metoda)
void GenerickaMetoda<T>(T parametar)
{
    Console.WriteLine("Proslijedeni parametar moze biti bilo kojega tipa: " + parametar);
}

GenerickaMetoda("parametar");
GenerickaMetoda(100);
GenerickaMetoda(true);


// Prosli ishodi:
//  Primjena skupova, lista ili mapa
//  Kolekcije i polimorfizam