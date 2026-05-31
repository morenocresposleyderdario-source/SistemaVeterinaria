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
    public partial class frmEditGuiaConsulta : Form
    {
        public frmEditGuiaConsulta()
        {
            InitializeComponent();
        }
        private void LimpiarBloqueDueno()
        {
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }

        private void LimpiarBloquePaciente()
        {
            textBox12.Clear();
            textBox11.Clear();
            textBox10.Clear();
            textBox9.Clear();
            textBox8.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Capturar la cédula desde el campo de búsqueda de arriba
                string cedulaBuscar = textBox2.Text.Trim();

                if (string.IsNullOrWhiteSpace(cedulaBuscar))
                {
                    MessageBox.Show("Por favor, ingrese el número de cédula del dueño para realizar la consulta.");
                    return;
                }

                // 2. Buscar al dueño en la lista global de TListas por su cédula
                Dueno duenoEncontrado = TListas.Lista_Duenos.FirstOrDefault(d => d.Cedula == cedulaBuscar);

                if (duenoEncontrado != null)
                {
                    // =========================================================================
                    // 3. AUTO-LLENAR EL BLOQUE: DATOS DEL DUEÑO
                    // =========================================================================
                    textBox3.Text = duenoEncontrado.Cedula;
                    textBox4.Text = $"{duenoEncontrado.Nombre} {duenoEncontrado.Apellido}";
                    textBox5.Text = duenoEncontrado.Direccion;
                    textBox6.Text = duenoEncontrado.Telefono;
                    textBox7.Text = duenoEncontrado.Correo;

                    // =========================================================================
                    // 4. AUTO-LLENAR EL BLOQUE: DATOS DEL PACIENTE (MASCOTA)
                    // =========================================================================
                    // Buscamos la primera mascota en la lista global vinculada a este dueño
                    Mascota mascotaEncontrada = TListas.Lista_Mascotas.FirstOrDefault(m => m.Dueno != null && m.Dueno.Codigo == duenoEncontrado.Codigo);

                    if (mascotaEncontrada != null)
                    {
                        textBox12.Text = mascotaEncontrada.Nombre;
                        textBox11.Text = mascotaEncontrada.Especie;
                        textBox10.Text = mascotaEncontrada.Raza;
                        textBox9.Text = mascotaEncontrada.FechaNacimiento.ToShortDateString();
                        textBox8.Text = mascotaEncontrada.Edad.ToString();

                        MessageBox.Show($"Datos cargados. Dueño: {duenoEncontrado.Nombre} | Paciente: {mascotaEncontrada.Nombre}");
                    }
                    else
                    {
                        // Si el dueño existe pero no tiene mascotas en el sistema
                        LimpiarBloquePaciente();
                        MessageBox.Show($"Dueño [{duenoEncontrado.Nombre}] cargado, pero no registra ninguna mascota en el sistema.");
                    }
                }
                else
                {
                    MessageBox.Show("No se encontró ningún dueño registrado con el número de cédula ingresado.");
                    LimpiarBloqueDueno();
                    LimpiarBloquePaciente();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar la búsqueda: " + ex.Message);
            }
        }
    }
}
