using kockaPokerFrm.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kockaPokerFrm
{
    public partial class frmFo : Form
    {
        private Dobas Gep;
        private Dobas Ember;
        private PictureBox[] gepKep;
        private PictureBox[] emberKep;

        public frmFo()
        {
            InitializeComponent();
            gepKep = new PictureBox[5] { pbGep1, pbGep2, pbGep3, pbGep4, pbGep5 };
            emberKep = new PictureBox[5] { pbEmber1, pbEmber2, pbEmber3, pbEmber4, pbEmber5 };
            Gep = new Dobas();
            Ember = new Dobas();
            lblGepReszEredmeny.Text = "";
            lblEmberReszeredmeny.Text = "";
            lblGepEredmeny.Text = "";
            lblEmberEredmeny.Text = "";

        }

        private void KepElhelyez(PictureBox pb, int szam)
        {
            switch (szam)
            {
                case 1:
                    pb.Image = Resources.egy;
                    break;
                case 2:
                    pb.Image = Resources.ketto;
                    break;
                case 3:
                    pb.Image = Resources.harom;
                    break;
                case 4:
                    pb.Image = Resources.negy;
                    break;
                case 5:
                    pb.Image = Resources.ot;
                    break;
            }
        }

        private void DobasMegjelenit(Dobas d, PictureBox[] kepek)
        {
            for (int i = 0; i < 5; i++)
            {
                KepElhelyez(kepek[i], d.Kockak[i]);
            }

            //lblGepReszEredmeny.Text = Gep.Eredmeny;
            //lblEmberReszeredmeny.Text = Ember.Eredmeny;

            //KepElhelyez(pbGep1, d.Kockak[0]);
            //KepElhelyez(pbGep2, d.Kockak[1]);
            //KepElhelyez(pbGep3, d.Kockak[2]);
            //KepElhelyez(pbGep4, d.Kockak[3]);
            //KepElhelyez(pbGep5, d.Kockak[4]);
        }

        private void btnDobas_Click(object sender, EventArgs e)
        {
            Gep.EgyDobas();
            Ember.EgyDobas();
            DobasMegjelenit(Gep, gepKep);
            DobasMegjelenit(Ember, emberKep);
            lblGepReszEredmeny.Text = Gep.Eredmeny;
            lblEmberReszeredmeny.Text = Ember.Eredmeny;

            if (Gep.Pont > Ember.Pont)
            {
                MessageBox.Show("Gép nyert!", "Játszott kör", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Gep.Nyert++;
                lblGepEredmeny.Text = Gep.Nyert.ToString();

            }
            else if(Gep.Pont < Ember.Pont)
            {
                MessageBox.Show("Ember nyert!", "Játszott kör", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Ember.Nyert++;
                lblEmberEredmeny.Text = Ember.Nyert.ToString();
            }
            else
            {
                MessageBox.Show("Döntetlen", "Játszott kör", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
