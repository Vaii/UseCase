using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UseCase
{
    public partial class PropertiesForm : Form
    {
        public List<Case> CaseList { get; set; }
        public string Naam { get; set; }

        public PropertiesForm(List<Case> caseList, string naam)
        {
            InitializeComponent();
            CaseList = caseList;
            Naam = naam;
        }


        private void btnOpslaan_Click(object sender, EventArgs e)
        {
            foreach (Case o in CaseList)
            {
                if (o.Naam == tbCaseName.Text)
                {
                    o.Naam = tbCaseName.Text;
                    o.Aannamen = tbCaseAannamen.Text;
                    o.Actoren = tbCaseActors.Text;
                    o.Samenvatting = tbCaseSummary.Text;
                    o.Beschrijving = rtbDescription.Text;
                    o.Resultaat = tbResult.Text;
                    o.Uitzondering = rtbExceptions.Text;
                }
            }
        }

        private void PropertiesForm_Load(object sender, EventArgs e)
        {
            tbCaseName.Text = Naam;
            foreach (Case o in CaseList)
            {
                if (o.Naam == tbCaseName.Text)
                {
                    tbCaseAannamen.Text = o.Aannamen;
                    tbCaseActors.Text = o.Actoren;
                    tbCaseSummary.Text = o.Samenvatting;
                    rtbDescription.Text = o.Beschrijving;
                    tbResult.Text = o.Resultaat;
                    rtbExceptions.Text = o.Uitzondering;
                }
            }
        }
    }
}
