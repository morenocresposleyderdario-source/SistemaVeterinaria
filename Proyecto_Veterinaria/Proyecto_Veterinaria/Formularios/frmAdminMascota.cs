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
    public partial class frmAdminMascota : Form
    {
        public frmAdminMascota()
        {
            InitializeComponent();
        }

        private void frmAdminMascota_Load(object sender, EventArgs e)
        {
            MostrarDatos();

        }
        public void MostrarDatos()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = TListas.Lista_Mascotas.ToList();
        }

        public void Nuevo()
        {
            try
            {
                frmEditDueno_Mascota frm = new frmEditDueno_Mascota();
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    // Al igual que en dueños, el proceso masivo del ListBox ya guardó en TListas
                    MessageBox.Show("Mascotas vinculadas e ingresadas con éxito");
                }
                MostrarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir registro: " + ex.Message);
            }
        }

        public void Eliminar()
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una mascota para eliminar.");
                return;
            }

            string codMascota = dataGridView1.CurrentRow.Cells["Codigo_Mascota"].Value.ToString();
            Mascota mascotaAEliminar = TListas.Lista_Mascotas.FirstOrDefault(m => m.Codigo_Mascota == codMascota);

            if (mascotaAEliminar != null)
            {
                var confirmacion = MessageBox.Show($"¿Desea eliminar a la mascota {mascotaAEliminar.Nombre}?", "Confirmar", MessageBoxButtons.YesNo);
                if (confirmacion == DialogResult.Yes)
                {
                    // 1. Si la mascota tiene un dueño asignado, la removemos de SU lista familiar interna
                    if (mascotaAEliminar.Dueno != null && mascotaAEliminar.Dueno.Mascotas != null)
                    {
                        mascotaAEliminar.Dueno.Mascotas.Remove(mascotaAEliminar);
                    }

                    // 2. La eliminamos de la lista GLOBAL de la veterinaria
                    TListas.Lista_Mascotas.Remove(mascotaAEliminar);

                    MostrarDatos();
                    MessageBox.Show("Mascota eliminada con éxito.");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una mascota de la lista.");
                return;
            }

            string codigoMascotaSeleccionada = dataGridView1.CurrentRow.Cells["Codigo_Mascota"].Value.ToString();
            Mascota mascotaAEditar = TListas.Lista_Mascotas.FirstOrDefault(m => m.Codigo_Mascota == codigoMascotaSeleccionada);

            if (mascotaAEditar != null)
            {
                frmEditDueno_Mascota frmEditar = new frmEditDueno_Mascota(mascotaAEditar);
                if (frmEditar.ShowDialog() == DialogResult.OK)
                {
                    MostrarDatos();
                }
            }
        }
    }
}
