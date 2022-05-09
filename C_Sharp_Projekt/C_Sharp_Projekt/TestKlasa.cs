using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Projekt
{
    public class TestKlasa
    {
        private readonly string _testVarijabla;
        public TestKlasa(string testVarijabla)
        {
            _testVarijabla = testVarijabla;
        }

        public void TestVarijabla()
        {
            Console.WriteLine("Varijabla unutar klase je: " + _testVarijabla);
        }

    }
}
