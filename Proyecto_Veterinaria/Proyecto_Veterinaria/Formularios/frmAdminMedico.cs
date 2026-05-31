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
    public partial class frmAdminMedico : Form
    {
        public frmAdminMedico()
        {
            InitializeComponent();
        }

        private void frmAdminMedico_Load(object sender, EventArgs e)
        {
            MostrarDatos();

        }
        public void MostrarDatos()
        {
            // Forzar actualización del DataGridView
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = TListas.Lista_Medicos.ToList();
        }

        public void Nuevo()
        {
            try
            {
                frmEditMedico frm = new frmEditMedico();
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    // Como el formulario EditMedico ya guardó usando los botones internos e introdujo
                    // los datos en TListas, solo necesitamos refrescar nuestra grilla local.
                    MessageBox.Show("Médico registrado correctamente");
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
                    var res = MessageBox.Show("¿Desea eliminar al médico seleccionado?", "Eliminar Médico", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        // 1. Recuperamos el objeto de la fila seleccionada
                        Medico obj = dataGridView1.CurrentRow.DataBoundItem as Medico;

                        if (obj != null)
                        {
                            // 2. Buscamos el índice real directamente dentro de la lista de médicos
                            int pos = TListas.Lista_Medicos.FindIndex(m => m.Id_Medico == obj.Id_Medico);

                            // 3. Validamos que el índice sea válido (mayor o igual a 0) antes de eliminar
                            if (pos >= 0)
                            {
                                // Asegúrate de que este método apunte a borrar en la lista de médicos
                                TListas.DeleteMedico(pos); // O usa TListas.Lista_Medicos.RemoveAt(pos); si es público

                                MessageBox.Show("Médico eliminado correctamente");
                                MostrarDatos();
                            }
                            else
                            {
                                MessageBox.Show("El médico no fue encontrado en la lista del sistema.");
                            }
                        }
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
                MessageBox.Show("Seleccione un médico de la lista.");
                return;
            }

            string cedulaSeleccionada = dataGridView1.CurrentRow.Cells["Cedula"].Value.ToString();
            Medico medicoAEditar = TListas.Lista_Medicos.FirstOrDefault(m => m.Cedula == cedulaSeleccionada);

            if (medicoAEditar != null)
            {
                frmEditMedico frmEditar = new frmEditMedico(medicoAEditar);
                if (frmEditar.ShowDialog() == DialogResult.OK)
                {
                    MostrarDatos();
                }
            }
        }
    }
}
