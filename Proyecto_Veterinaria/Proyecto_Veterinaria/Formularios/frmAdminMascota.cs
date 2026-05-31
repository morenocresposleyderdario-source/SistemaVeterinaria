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
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    var res = MessageBox.Show("¿Desea eliminar la mascota seleccionada?", "Eliminar Mascota", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        Mascota obj = dataGridView1.CurrentRow.DataBoundItem as Mascota;
                        int pos = TListas.BuscarMascota(obj.Codigo_Mascota);
                        TListas.DeleteMascota(pos);

                        MessageBox.Show("Mascota eliminada de los registros");
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
    }
}
