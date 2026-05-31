using Proyecto_Veterinaria.Controladores;
using Proyecto_Veterinaria.Entidades;
using Proyecto_Veterinaria.Formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Veterinaria
{
    public partial class frmAdminClient : Form
    {
        public frmAdminClient()
        {
            InitializeComponent();
        }

        private void frmAdminClient_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        public void MostrarDatos()
        {
            // Forzar actualización del DataGridView
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = TListas.Lista_Duenos.ToList();
        }

        public void Nuevo()
        {
            try
            {
                frmEditDueno_Mascota frm = new frmEditDueno_Mascota();
                // Opcional: puedes activar o desactivar paneles según lo que necesites
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    // Como el formulario mixto ya guardó usando los botones internos e introdujo
                    // los datos en TListas, solo necesitamos refrescar nuestra grilla local.
                    MessageBox.Show("Dueño registrado correctamente");
                }
                else
                {
                    MessageBox.Show("Registro Cancelado o Incompleto");
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
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    var res = MessageBox.Show("¿Desea eliminar al dueño seleccionado? Esto también borrará sus mascotas.", "Eliminar Dueño", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        Dueno obj = dataGridView1.CurrentRow.DataBoundItem as Dueno;
                        int pos = TListas.Buscar(obj.Codigo);
                        TListas.Delete(pos);

                        MessageBox.Show("Dueño y sus mascotas eliminados correctamente");
                        MostrarDatos();
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione la fila a Eliminar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
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
                MessageBox.Show("Seleccione un dueño de la lista.");
                return;
            }

            string cedulaSeleccionada = dataGridView1.CurrentRow.Cells["Cedula"].Value.ToString();
            Dueno duenoAEditar = TListas.Lista_Duenos.FirstOrDefault(m => m.Cedula == cedulaSeleccionada);

            if (duenoAEditar != null)
            {
                frmEditDueno_Mascota frmEditar = new frmEditDueno_Mascota(duenoAEditar);
                if (frmEditar.ShowDialog() == DialogResult.OK)
                {
                    MostrarDatos();
                }
            }
        }
    }
}
