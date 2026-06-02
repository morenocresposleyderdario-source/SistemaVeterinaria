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
    public partial class frmAdminGuiaConsulta : Form
    {
        public frmAdminGuiaConsulta()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = TListas.Lista_GuiaConsulta.ToList();
        }

        private void frmAdminGuiaConsulta_Load(object sender, EventArgs e)
        {

        }
    }
}
