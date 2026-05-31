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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proyecto_Veterinaria.Formularios
{
    public partial class frmEditMedico : Form
    {
        public frmEditMedico()
        {
            InitializeComponent();
        }

        private void frmEditMedico_Load(object sender, EventArgs e)
        {

        }
        public bool ValidarDatos()
        {
            bool value = true;
            if (textBox1.Text.Trim().Length == 0 || textBox2.Text.Trim().Length == 0 || textBox3.Text.Trim().Length == 0
                || textBox4.Text.Trim().Length == 0 || textBox5.Text.Trim().Length == 0 || textBox6.Text.Trim().Length == 0 || textBox7.Text.Trim().Length == 0
                || textBox8.Text.Trim().Length == 0)
            {
                value = false;
            }
            return value;
        }
        public void Guardar()
        {
            try
            {
                if (ValidarDatos())
                    this.DialogResult = DialogResult.OK;
                else
                    MessageBox.Show("Los campos con (*) son obligatorios");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que los campos básicos del medico no estén vacíos
                if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    MessageBox.Show("Por favor, ingrese el código y cédula del medico.");
                    return;
                }

                string codMedico = textBox1.Text;
                string cedMedico = textBox2.Text;
                string nomMedico = textBox3.Text;
                string apeMedico = textBox4.Text;
                string especialidadMedico = textBox5.Text;
                string telefonoMedico = textBox6.Text;
                string correoMedico = textBox7.Text;
                string numeroLicenciaMedico = textBox8.Text;

                // Crear objeto Medico
                Medico nuevoMedico = new Medico(codMedico, cedMedico, nomMedico, apeMedico, especialidadMedico, telefonoMedico, correoMedico, numeroLicenciaMedico);

                // Insertar en la lista estática si no existe
                if (!TListas.Lista_Medicos.Any(d => d.Id_Medico == nuevoMedico.Id_Medico))
                {
                    TListas.InsertMedico(nuevoMedico);
                }

                MessageBox.Show("Medico registrado con éxito.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar medico: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
