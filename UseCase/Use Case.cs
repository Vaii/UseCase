using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace UseCase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            rbActor.CheckedChanged += new EventHandler(NaamGeven);
            rbUseCase.CheckedChanged += new EventHandler(NaamGeven);
            rbCreate.CheckedChanged += new EventHandler(NaamGeven);
            List<Case> Case;
        }

        bool draw = false;
        Point? clickOne = null;
        Point clickTwo;


        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void NaamGeven(object sender, EventArgs e)
        {
            if(rbActor.Checked && rbCreate.Checked)
            {
                tbNaam.Visible = true;
                lblNaam.Visible = true;
                lblNaam.Text = "Naam Actor";
            }
            else if (rbUseCase.Checked && rbCreate.Checked)
            {
                tbNaam.Visible = true;
                lblNaam.Visible = true;
                lblNaam.Text = "Naam Use Case";
            }
            else if (!rbUseCase.Checked && !rbActor.Checked && rbCreate.Checked)
            {
                tbNaam.Visible = false;
                lblNaam.Visible = false;
            }
            else if (!rbCreate.Checked)
            {
                tbNaam.Visible = false;
                lblNaam.Visible = false;
            }
        }

        private void pnlTeken_MouseClick(object sender, MouseEventArgs e)
        {
            if (rbActor.Checked && rbCreate.Checked && !string.IsNullOrWhiteSpace(tbNaam.Text))
            {
                PictureBox actor = new PictureBox();
                actor.Image = Image.FromFile(@"\\Mac\Home\Documents\Visual Studio 2015\Projects\UseCase\UseCase\bin\stick.png");
                actor.SizeMode = PictureBoxSizeMode.StretchImage;
                actor.Size = new Size(80, 75);
                actor.Location = e.Location;
                Label actorNaam = new Label();
                actorNaam.Text = tbNaam.Text;
                actorNaam.Left = actor.Location.X;
                actorNaam.Top = Convert.ToInt32(actor.Location.Y) + actor.Height + 5;
                actorNaam.Width = actor.Width;
                actorNaam.BackColor = Color.White;
                actor.Show();
                actorNaam.Show();
                pnlTeken.Controls.Add(actorNaam);
                pnlTeken.Controls.Add(actor);
            }

            if (rbUseCase.Checked && rbCreate.Checked && !string.IsNullOrWhiteSpace(tbNaam.Text))
            {
                Label naam = new Label();
                naam.MouseDown += new MouseEventHandler(pnlTeken_MouseDown);
                naam.Name = tbNaam.Text;
                naam.Text = tbNaam.Text;
                naam.Location = e.Location;
                naam.BackColor = Color.Transparent;
                naam.Show();
                pnlTeken.Controls.Add(naam);
                int x = naam.Location.X - naam.Width / 2;
                int y = naam.Location.Y - naam.Height / 2;
                int width = naam.Width + 40 ;
                int height = naam.Height + 20 ;
                Graphics gs = pnlTeken.CreateGraphics();
                Pen p = new Pen(Color.Black);
                gs.DrawEllipse(p,x,y,width,height);
                string caseNaam = tbNaam.Text;
                Case newCase = new Case(caseNaam);
            }


        }
          
        private void pnlTeken_MouseDown(object sender, MouseEventArgs e)
        { 

            if (rbLine.Checked && rbCreate.Checked)
            {


                if (!draw)
                {
                    clickOne = e.Location;
                    draw = true;
                }
                else
                {
                    clickTwo = e.Location;
                    Graphics gs = pnlTeken.CreateGraphics();
                    Pen p = new Pen(Color.Black);
                    gs.DrawLine(p,clickOne.GetValueOrDefault(),clickTwo);
                    draw = false;
                }


            }

            if (rbSelect.Checked)
            {
                if (sender is Label)
                {
                    MessageBox.Show("Test");
                }
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
        }
    }
}
