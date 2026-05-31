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
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un dueño para eliminar.");
                return;
            }

            // 1. Obtener el código o cédula del dueño seleccionado en la tabla
            string codigoDueno = dataGridView1.CurrentRow.Cells["Codigo"].Value.ToString();

            // 2. Buscar el objeto Dueño real en tu lista estática
            Dueno duenoAEliminar = TListas.Lista_Duenos.FirstOrDefault(d => d.Codigo == codigoDueno);

            if (duenoAEliminar != null)
            {
                var confirmacion = MessageBox.Show($"¿Está seguro de eliminar a {duenoAEliminar.Nombre}? También se eliminarán todas sus mascotas asociadas.", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmacion == DialogResult.Yes)
                {
                    // =========================================================================
                    // ¡AQUÍ ESTÁ EL TRUCO! - ELIMINACIÓN EN CASCADA
                    // =========================================================================

                    // Usamos LINQ para remover de la lista GLOBAL de mascotas todas aquellas 
                    // cuyo dueño coincida con el código del dueño que vamos a borrar.
                    TListas.Lista_Mascotas.RemoveAll(m => m.Dueno != null && m.Dueno.Codigo == codigoDueno);

                    // Ahora sí, eliminamos al dueño de la lista GLOBAL de dueños
                    TListas.Lista_Duenos.Remove(duenoAEliminar);

                    // 3. Refrescar la tabla actual
                    MostrarDatos();
                    MessageBox.Show("Dueño y sus mascotas eliminados correctamente.");
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
