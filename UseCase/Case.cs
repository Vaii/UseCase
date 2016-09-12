using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UseCase
{
    class Case
    {
        public Case(string naam)
        {
            this.Naam = naam;
        }

        private string Naam;
        string Samenvatting;
        string Actoren;
        string Aannamen;
        string Beschrijving;
        string Uitzondering;
        string Resultaat;
    }
}
