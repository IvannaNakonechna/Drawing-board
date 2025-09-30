using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt3
{
    public partial class KokpitProjektuNr3 : Form
    {
        public KokpitProjektuNr3()
        {
            InitializeComponent();
        }

        private void btn_lab_Click(object sender, EventArgs e)
        {
            foreach (Form Formularz in Application.OpenForms)
            {
                if (Formularz.Name == "RysownicaLab")
                {
                    this.Hide();
                    Formularz.Show();
                    return;

                }
                RysownicaLab FormularzLaboratoryjny = new RysownicaLab();
                this.Hide();
                FormularzLaboratoryjny.Show();
                break;

            }
        }

        private void btnlnd_Click(object sender, EventArgs e)
        {
            foreach (Form Formularz in Application.OpenForms)
            {
                if (Formularz.Name == "ProjektNr3")
                {
                    this.Hide();
                    Formularz.Show();
                    return;

                }
                ProjektNr3_Nakonechna68940 FormularzProjektowy = new ProjektNr3_Nakonechna68940();
                this.Hide();
                FormularzProjektowy.Show();
                break;

            }

        }
        
        
    }     
}
