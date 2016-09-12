using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UseCase
{
    public class Case
    {
        public Case(string naam)
        {
            this.Naam = naam;
        }

        public string Naam;
        public string Samenvatting;
        public string Actoren;
        public string Aannamen;
        public string Beschrijving;
        public string Uitzondering;
        public string Resultaat;
    }
}
