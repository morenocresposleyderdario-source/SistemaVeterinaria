using Org.BouncyCastle.Math;
using Proyecto_Veterinaria.Controladores;
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
    public partial class frmConsultasLinq : Form
    {
        public frmConsultasLinq()
        {
            InitializeComponent();
        }

        private void canntidadMascotasRegistradasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // var se convierte automáticamente en un tipo 'int'
            var totalMascotas = TListas.Lista_Mascotas.Count();

            // Para mostrarlo en la interfaz:
            label4.Text = $"Total de Pacientes: {totalMascotas}";
            dataGridView1.DataSource = TListas.Lista_Mascotas.ToList();
        }

        private void mascotasOrdenadasAlfabeticamenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mascotasOrdenadas = (from m in TListas.Lista_Mascotas
                                     orderby m.Nombre ascending
                                     select m).ToList();

            // Lo cargas directo a la tabla de tu pantalla:
            dataGridView1.DataSource = mascotasOrdenadas.ToList();
            label4.Visible = true;
            label4.Text = $"Total de Pacientes: {mascotasOrdenadas.Count()}";
        }

        private void listarMascotasPerroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var perros=(from x in TListas.Lista_Mascotas
                        where x.Especie.Equals("Perro")
                        select x).Count();
            var perrosRegistrados = (from m in TListas.Lista_Mascotas
                                     where m.Especie.ToLower() == "perro"
                                     select m).ToList();

            dataGridView1.DataSource = perrosRegistrados.ToList();
            label4.Text = $"Total de Perros: {perros}";
        }

        private void cantidadMascotasPorEspecieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var conteoPorEspecie = (from m in TListas.Lista_Mascotas
                                    group m by m.Especie into grupo
                                    select new
                                    {
                                        Especie = grupo.Key,
                                        Cantidad = grupo.Count()
                                    }).ToList();

            // El DataGridView creará dos columnas automáticas llamadas Especie y Cantidad
            dataGridView1.DataSource = conteoPorEspecie.ToList();
            label4.Visible = false;
        }

        private void mascotaYDueñoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cedulaBuscar = textBox1.Text.Trim();

            var duenoYPaciente = (from m in TListas.Lista_Mascotas
                                  where m.Dueno != null && m.Dueno.Cedula == cedulaBuscar
                                  select new
                                  {
                                      CedulaDueño = m.Dueno.Cedula,
                                      Propietario = m.Dueno.Nombre + " " + m.Dueno.Apellido,
                                      NombreMascota = m.Nombre,
                                      Raza = m.Raza
                                  }).ToList();

            dataGridView1.DataSource = duenoYPaciente.ToList();
            label4.Visible = false;
        }

        private void promedioDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var promedioPeso = TListas.Lista_GuiaConsulta.Any() ? TListas.Lista_GuiaConsulta.Average(c => c.Peso) : 0.0;

            label4.Visible = true;
            label4.Text = $"Peso promedio global: {promedioPeso:F2} kg";
            dataGridView1.DataSource = TListas.Lista_Mascotas.ToList();
        }

        private void pacientesConFiebreAltaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var consultasFiebreAlta = (from c in TListas.Lista_GuiaConsulta
                                       where c.Temperatura > 39
                                       select new
                                       {
                                           Ficha = c.IdConsulta,
                                           Paciente = c.Mascota.Nombre,
                                           Temperatura = c.Temperatura + " °C",
                                           Diagnostico = c.Diagnostico
                                       }).ToList();

            dataGridView1.DataSource = consultasFiebreAlta.ToList();
            label4.Visible = true;
            label4.Text = $"Total de Pacientes con Fiebre Alta: {consultasFiebreAlta.Count()}";
        }

        private void medicosOrdenadosAlfabeticamentePoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var medicosOrdenados = (from med in TListas.Lista_Medicos
                                    orderby med.Apellido ascending
                                    select med).ToList();

            dataGridView1.DataSource = medicosOrdenados.ToList();
            label4.Visible = true;
            label4.Text = $"Total de Médicos: {medicosOrdenados.Count()}";
        }

        private void atencionesClinicasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var atencionesClinicas = (from g in TListas.Lista_GuiaConsulta
                                      select g).Count();
            var resumenGlobal = (from c in TListas.Lista_GuiaConsulta
                                 select new
                                 {
                                     Nro_Consulta = c.IdConsulta,
                                     Fecha = c.FechaConsulta.ToShortDateString(),
                                     Propietario = c.Dueno.Nombre + " " + c.Dueno.Apellido,
                                     Mascota = c.Mascota.Nombre,
                                     Diagnostico = c.Diagnostico,
                                     Tratamiento = c.Tratamiento
                                 }).ToList();

            dataGridView1.DataSource = resumenGlobal;
            label4.Visible = true;
            label4.Text = $"Total de Atenciones Clínicas: {atencionesClinicas}";
        }

        private void frmConsultasLinq_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime fechaFiltro = dateTimePicker1.Value.Date;

            var consultasDelDia = (from c in TListas.Lista_GuiaConsulta
                                   where c.FechaConsulta.Date == fechaFiltro
                                   select c).ToList();

            dataGridView1.DataSource = consultasDelDia.ToList();
            label4.Visible = true;
            label4.Text = $"Total de Consultas el {fechaFiltro.ToShortDateString()}: {consultasDelDia.Count()}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cedulaBuscar = textBox1.Text.Trim();

            var duenoYPaciente = (from m in TListas.Lista_Mascotas
                                  where m.Dueno != null && m.Dueno.Cedula == cedulaBuscar
                                  select new
                                  {
                                      CedulaDueño = m.Dueno.Cedula,
                                      Propietario = m.Dueno.Nombre + " " + m.Dueno.Apellido,
                                      NombreMascota = m.Nombre,
                                      Raza = m.Raza
                                  }).ToList();

            dataGridView1.DataSource = duenoYPaciente.ToList();
            label4.Visible = false;
        }
    }
}
