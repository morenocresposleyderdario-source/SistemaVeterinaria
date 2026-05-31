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
                Dueno d3 = new Dueno("D03", "0709876543", "Luis", "Ramírez", "Masculino", 40, new DateTime(1984, 02, 18), "Av. Quito", "0977777777", "luis@mail.com");
                Dueno d4 = new Dueno("D04", "0705432167", "María", "López", "Femenino", 30, new DateTime(1992, 08, 05), "Calle Guayaquil", "0966666666", "maria@mail.com");
                Dueno d5 = new Dueno("D05", "0706789012", "Jorge", "Sánchez", "Masculino", 45, new DateTime(1979, 12, 30), "Av. Amazonas", "0955555555", "jorge@mail.com");
                Dueno d6 = new Dueno("D06", "0704321098", "Sofía", "Fernández", "Femenino", 27, new DateTime(1997, 03, 14), "Calle Esmeraldas", "0944444444", "sofia@mail.com");

                TListas.Insert(d1);
                TListas.Insert(d2);
                TListas.Insert(d3);
                TListas.Insert(d4);
                TListas.Insert(d5);
                TListas.Insert(d6);

                // 2. Creamos sus mascotas base correspondientes
                Mascota m1 = new Mascota("M01", "Lucas", "Perro", "Golden", new DateTime(2022, 01, 10), 4, d1);
                Mascota m2 = new Mascota("M02", "Michi", "Gato", "Siamés", new DateTime(2024, 06, 15), 2, d2);
                Mascota m3 = new Mascota("M03", "Rocky", "Perro", "Bulldog", new DateTime(2021, 03, 05), 5, d3);
                Mascota m4 = new Mascota("M04", "Luna", "Gato", "Persa", new DateTime(2023, 08, 20), 1, d4);
                Mascota m5 = new Mascota("M05", "Lucky", "Ave", "Canario", new DateTime(2020, 12, 01), 6, d5);
                Mascota m6 = new Mascota("M06", "Bella", "Conejo", "Conejo Blanco", new DateTime(2022, 05, 30), 4, d6);

                Medico med1 = new Medico("MED01", "0706924271", "Sleyder", "Moreno Crespo", "Veterinario", "0968896092", "sleyder.moreno@hotmail.com", "Lic_01");
                Medico med2 = new Medico("MED02", "0701237890", "Laura", "Ramírez", "Veterinaria", "0977777777", "laura.ramirez@hotmail.com", "Lic_02");
                GuiaConsulta gc1 = new GuiaConsulta(01, new DateTime(2024, 07, 20), m1, d1, "Consulta general", 35, 1.35, 60, 25, 1.20, "Perro en estables condiciones", "Sacar a pasear al canino");
                GuiaConsulta gc2 = new GuiaConsulta(02, new DateTime(2026, 05, 31), m2, d2, "Consulta general", 40, 1.40, 70, 30, 1.00, "Minino presenta gripe e infección", "Tomar bastantes líquidos y mantener reposo");
                GuiaConsulta gc3 = new GuiaConsulta(03, new DateTime(2025, 09, 15), m3, d3, "Consulta general", 38, 1.25, 55, 20, 0.80, "Bulldog con sobrepeso", "Controlar la dieta y aumentar el ejercicio físico");
                GuiaConsulta gc4 = new GuiaConsulta(04, new DateTime(2024, 11, 10), m4, d4, "Consulta general", 37, 1.30, 65, 28, 1.10, "Gato con síntomas de resfriado", "Mantener al gato en un ambiente cálido y darle medicamentos para el resfriado");
                GuiaConsulta gc5 = new GuiaConsulta(05, new DateTime(2024, 12, 05), m5, d5, "Consulta general", 36, 1.20, 60, 25, 1.00, "Canario con problemas respiratorios", "Proporcionar un ambiente cálido y administrar medicamentos según indicaciones");
                GuiaConsulta gc6 = new GuiaConsulta(06, new DateTime(2024, 10, 22), m6, d6, "Consulta general", 39, 1.35, 70, 30, 1.20, "Conejo con síntomas de deshidratación", "Asegurar una adecuada hidratación y proporcionar alimentos ricos en agua");

                TListas.InsertMedico(med1);
                TListas.InsertMedico(med2);

                TListas.Lista_GuiaConsulta.Add(gc1);
                TListas.Lista_GuiaConsulta.Add(gc2);
                TListas.Lista_GuiaConsulta.Add(gc3);
                TListas.Lista_GuiaConsulta.Add(gc4);
                TListas.Lista_GuiaConsulta.Add(gc5);
                TListas.Lista_GuiaConsulta.Add(gc6);

                TListas.InsertMascota(m1);
                TListas.InsertMascota(m2);
                TListas.InsertMascota(m3);
                TListas.InsertMascota(m4);
                TListas.InsertMascota(m5);
                TListas.InsertMascota(m6);
            }
        }

        private void adminGuiaConsultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdminGuiaConsulta frm = new frmAdminGuiaConsulta();
            frm.ShowDialog();
        }

        private void consultasLinqToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultasLinq frm = new frmConsultasLinq();
            frm.ShowDialog();
        }
    }
}
