using Proyecto_Veterinaria.Controladores;
using Proyecto_Veterinaria.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Veterinaria.Formularios
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void consultaMedicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditGuiaConsulta frm = new frmEditGuiaConsulta();
            frm.ShowDialog();
        }
        private void adminDueñoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdminClient frm = new frmAdminClient();
            frm.ShowDialog();
        }

        private void adminMascotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdminMascota frm = new frmAdminMascota();
            frm.ShowDialog();
        }

        private void adminMedicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdminMedico frm = new frmAdminMedico();
            frm.ShowDialog();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            if (TListas.Lista_Duenos.Count == 0)
            {
                // 1. Creamos los dueños base
                Dueno d1 = new Dueno("D01", "0701234567", "Carlos", "Pérez", "Masculino", 34, new DateTime(1992, 05, 12), "Av. Central", "0999999999", "carlos@mail.com");
                Dueno d2 = new Dueno("D02", "0707654321", "Ana", "Gómez", "Femenino", 28, new DateTime(1998, 11, 23), "Calle Loja", "0988888888", "ana@mail.com");

                TListas.Insert(d1);
                TListas.Insert(d2);

                // 2. Creamos sus mascotas base correspondientes
                Mascota m1 = new Mascota("M01", "Lucas", "Perro", "Golden", new DateTime(2022, 01, 10), 4, d1);
                Mascota m2 = new Mascota("M02", "Michi", "Gato", "Siamés", new DateTime(2024, 06, 15), 2, d2);

                TListas.InsertMascota(m1);
                TListas.InsertMascota(m2);
            }
        }
    }
}
