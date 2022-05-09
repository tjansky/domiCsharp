// See https://aka.ms/new-console-template for more information
using Ishod_6;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.Text;

Console.WriteLine("Hello, Ishod 6");
Console.WriteLine("------------------");


// ucitaj direktorij
DirectoryInfo direktorij = new DirectoryInfo(@"C:\Spremnik\programi\C_Sharp_Projekt\Ishod_6\test_direktorij");

// ispisi njegove detalje ako postoji
if (direktorij.Exists)
{
    Console.WriteLine("Naziv: {0}", direktorij.Name);
    Console.WriteLine("Roditelj: {0}", direktorij.Parent);
    Console.WriteLine("Izrađeno: {0}", direktorij.CreationTime);
    Console.WriteLine("Atributi: {0}", direktorij.Attributes);
    Console.WriteLine("Korijenski direktorij: {0}", direktorij.Root);
} else
{
    Console.WriteLine("Direktorij ne postoji");
}

Console.WriteLine("------------------");

// dohvati datoteke koje se nalaze i njemu
FileInfo[] datoteke = direktorij.GetFiles();

// ispisi detalje dohvacenih datoteka
foreach (var d in datoteke)
{
    Console.WriteLine("Datoteka naziv: {0}", d.Name);
    Console.WriteLine("Datoteka velicina: {0}", d.Length);
    Console.WriteLine("Datoteka izrađeno: {0}", d.CreationTime);
    Console.WriteLine("Datoteka atributi: {0}", d.Attributes);
    Console.WriteLine("------------------");
}

// -------------------------------------------------------------------------------------------------

// pisanje u tekstualnu datoteku
List<string> listaPodatakaUnos = new List<string>();
listaPodatakaUnos.Add("Podatak broj jedan");
listaPodatakaUnos.Add("Podatak broj dva");

using (StreamWriter w = File.CreateText(@"C:\Spremnik\programi\C_Sharp_Projekt\Ishod_6\test_direktorij\test_za_pisanje.txt"))
{
    w.WriteLine("Programski unešeni podaci:");
    foreach (var podatak in listaPodatakaUnos)
    {
        w.WriteLine(podatak);
    }
}


// čitanje tekstualne datoteke
List<string> listaProcitanihPodataka = new List<string>();

using (StreamReader sr = File.OpenText(@"C:\Spremnik\programi\C_Sharp_Projekt\Ishod_6\test_direktorij\test_za_pisanje.txt"))
{
    string linija = null;
    sr.ReadLine();
    while ((linija = sr.ReadLine()) != null)
    {
        listaProcitanihPodataka.Add(linija);
    }
}

foreach (var podatak in listaProcitanihPodataka)
{
    Console.WriteLine(podatak);
}


// serijalizacija objekta (objekt u JSON string)
Student student = new Student("Domagoj", "Jansky", true, 2000);

string serijaliziraniObjekt = JsonConvert.SerializeObject(student);
Console.WriteLine(serijaliziraniObjekt);


// čitanje i parsiranje (iz JSON-a u objekt) JSON datoteka
string studentJson = File.ReadAllText(@"C:\Spremnik\programi\C_Sharp_Projekt\Ishod_6\test_direktorij\student.json");
Student studentObject = JsonConvert.DeserializeObject<Student>(studentJson);

Console.WriteLine(studentObject.Ime);
Console.WriteLine(studentObject.Prezime);
Console.WriteLine(studentObject.Redovan);
Console.WriteLine(studentObject.Godiste);


// izrada JSON datoteke (iz prethodno serijaliziranog objekta)
string jsonDatotekaPath = @"C:\Spremnik\programi\C_Sharp_Projekt\Ishod_6\test_direktorij\student_upis.json";

using (FileStream fs = File.Create(jsonDatotekaPath))
{
    byte[] info = new UTF8Encoding(true).GetBytes(serijaliziraniObjekt);
    fs.Write(info, 0, info.Length);
}


// pohrana podataka i dohvaćanje podataka iz baze podataka
string connectionString = "Data Source = sql.vub.zone,14330; Initial Catalog = labos-khusak; User ID = sa; Password = VUBserver2020";
string sqlQueryDohvat = "SELECT * FROM Student";

// Dohvat podataka
using (SqlConnection sqlConnection = new SqlConnection(connectionString))
{
    SqlDataAdapter adapter = new SqlDataAdapter(sqlQueryDohvat, sqlConnection);
    DataSet ds = new DataSet();

    adapter.Fill(ds);

    Console.WriteLine("Dohvaceni podaci iz baze:");
    Console.WriteLine("-----------------");
    foreach (DataRow redak in ds.Tables[0].Rows)
    {
        Console.WriteLine(redak["Ime"]);
        Console.WriteLine(redak["Prezime"]);
        Console.WriteLine(redak["Godiste"]);
        Console.WriteLine(redak["Redovan"]);
        Console.WriteLine("-----------------");
    }
}

// Unos podataka
string sqlQueryUnos = "INSERT INTO Student (Ime, Prezime, Godiste, Redovan) VALUES (@Ime, @Prezime, @Godiste, @Redovan)";

using (SqlConnection sqlConnection = new SqlConnection(connectionString))
{
    using (SqlCommand sqlCommand = new SqlCommand(sqlQueryUnos, sqlConnection))
    {
        sqlCommand.Parameters.AddWithValue("@Ime", "mirko");
        sqlCommand.Parameters.AddWithValue("@Prezime", "mirkovic");
        sqlCommand.Parameters.AddWithValue("@Godiste", 2002);
        sqlCommand.Parameters.AddWithValue("@Redovan", true);

        sqlConnection.Open();
        sqlCommand.ExecuteNonQuery();
    }
}