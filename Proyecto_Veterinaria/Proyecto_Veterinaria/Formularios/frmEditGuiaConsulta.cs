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
        public void LlenarComboMedicos()
        {
            // 1. Limpiamos los ítems actuales por si acaso para evitar duplicados
            comboBox1.Items.Clear();

            // 2. Recorremos la lista estática global de médicos
            foreach (Medico med in TListas.Lista_Medicos)
            {
                // Al agregar el objeto 'med' completo, el combo usará el ToString() que configuramos en el Paso 1
                comboBox1.Items.Add(med);
            }

            // 3. Opcional: Si hay médicos registrados, seleccionamos el primero por defecto
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void frmEditGuiaConsulta_Load(object sender, EventArgs e)
        {
            LlenarComboMedicos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. VALIDACIONES BÁSICAS DE TEXTO vacío
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Por favor, ingrese el número de consulta.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox12.Text))
                {
                    MessageBox.Show("Debe buscar y cargar un Dueño y una Mascota antes de guardar.");
                    return;
                }

                if (comboBox1.SelectedIndex < 0)
                {
                    MessageBox.Show("Debe seleccionar un Médico encargado.");
                    return;
                }

                // 2. RECUPERAR LOS OBJETOS REALES EN MEMORIA
                Dueno duenoConsulta = TListas.Lista_Duenos.FirstOrDefault(d => d.Cedula == textBox3.Text);
                Mascota mascotaConsulta = TListas.Lista_Mascotas.FirstOrDefault(m => m.Nombre == textBox12.Text && m.Dueno.Codigo == duenoConsulta.Codigo);
                Medico medicoConsulta = comboBox1.SelectedItem as Medico;

                // =========================================================================
                // 3. CAPTURAR DATOS NUMÉRICOS DE FORMA SEGURA (Evita el error de formato)
                // =========================================================================

                // Conversión segura del Número de Consulta
                int idConsulta;
                if (!int.TryParse(textBox1.Text.Trim(), out idConsulta))
                {
                    MessageBox.Show("El Número de Consulta debe ser un número entero válido (ej: 1, 2, 3...).");
                    return;
                }

                DateTime fechaConsulta = dateTimePicker1.Value;
                string motivo = textBox17.Text;
                string diagnostico = textBox18.Text;
                string tratamiento = textBox19.Text;

                // Variables auxiliares para intentar la conversión sin romper el sistema
                int temperatura;
                double peso, frecCardiaca, frecRespiratoria, estatura;

                // Si el usuario no escribe nada o pone letras, se asigna 0 automáticamente
                int.TryParse(textBox16.Text.Trim(), out temperatura);
                double.TryParse(textBox20.Text.Trim().Replace(',', '.'), out peso); // Reemplaza coma por punto por si acaso
                double.TryParse(textBox15.Text.Trim(), out frecCardiaca);
                double.TryParse(textBox14.Text.Trim(), out frecRespiratoria);
                double.TryParse(textBox13.Text.Trim(), out estatura);

                // =========================================================================
                // 4. CREAR INSTANCIA DE GUIA CONSULTA
                // =========================================================================
                GuiaConsulta nuevaConsulta = new GuiaConsulta(
                    idConsulta, fechaConsulta, mascotaConsulta, duenoConsulta, motivo,
                    temperatura, peso, frecCardiaca, frecRespiratoria, estatura, diagnostico, tratamiento
                );

                // 5. GUARDAR EN LA LISTA GLOBAL Y GENERAR EL REPORTE
                if (!TListas.Lista_GuiaConsulta.Any(c => c.IdConsulta == nuevaConsulta.IdConsulta))
                {
                    TListas.Lista_GuiaConsulta.Add(nuevaConsulta);

                    // Generamos el PDF usando la entidad externa
                    ReportePDF.GenerarComprobanteConsulta(nuevaConsulta, medicoConsulta);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ya existe una consulta registrada con ese número de consulta.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado al guardar la consulta: " + ex.Message);
            }
        }
    }
}
