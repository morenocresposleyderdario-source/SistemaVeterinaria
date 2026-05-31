using Proyecto_Veterinaria.Controladores;
using Proyecto_Veterinaria.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Proyecto_Veterinaria.Formularios
{
    public partial class frmEditDueno_Mascota : Form
    {
        public frmEditDueno_Mascota()
        {
            InitializeComponent();
        }
        private Dueno duenoSeleccionado;
        private List<Mascota> listaMascotasTemporales = new List<Mascota>();

        private Dueno duenoexistente = null;
        private Mascota mascotaexistente = null;
        public frmEditDueno_Mascota(Dueno dueno)
        {
            InitializeComponent();
            this.duenoexistente = dueno;
        }

        // Constructor 3: Cuando se modifica desde el Administrador de Mascotas
        public frmEditDueno_Mascota(Mascota mascota)
        {
            InitializeComponent();
            this.mascotaexistente = mascota;
            // Si viene una mascota, automáticamente apuntamos también a su dueño original
            this.duenoexistente = mascota.Dueno;
        }

        private void frmEditDueno_Mascota_Load(object sender, EventArgs e)
        {
            LlenarComboDuenos();
            if (duenoexistente != null)
            {
                // 1. Cargar los datos del Dueño en los campos superiores
                textBox1.Text = duenoexistente.Codigo;
                textBox1.Enabled = false; // Bloqueamos la llave primaria del dueño

                textBox2.Text = duenoexistente.Cedula;
                textBox3.Text = duenoexistente.Nombre;
                textBox4.Text = duenoexistente.Apellido;
                comboBox1.SelectedItem = duenoexistente.Sexo.ToString();
                textBox5.Text = duenoexistente.Edad.ToString();
                dateTimePicker1.Value = duenoexistente.FechaNacimiento;
                textBox6.Text = duenoexistente.Direccion;
                textBox7.Text = duenoexistente.Telefono;
                textBox8.Text = duenoexistente.Correo;

                // Cambiar texto de los botones para guiar al usuario
                button1.Text = "Actualizar Dueño";
                button3.Text = "Guardar Cambios Modificados";

                string nomCompleto = $"{duenoexistente.Nombre} {duenoexistente.Apellido}";

                if (!comboBox3.Items.Contains(nomCompleto))
                {
                    comboBox3.Items.Add(nomCompleto);
                }
                comboBox3.SelectedItem = nomCompleto;
                comboBox3.Enabled = false;

                // 2. ¿Cómo cargar la sección de la Mascota? 
                if (mascotaexistente != null)
                {
                    // Caso A: Si venimos desde frmAdminMascota, cargamos los datos de ESA mascota específica en los campos de edición directa
                    textBox16.Text = mascotaexistente.Codigo_Mascota;
                    textBox16.Enabled = false; // Bloqueamos la llave primaria de la mascota

                    textBox15.Text = mascotaexistente.Nombre;
                    comboBox2.SelectedItem = mascotaexistente.Especie.ToString();
                    textBox13.Text = mascotaexistente.Raza;
                    textBox12.Text = mascotaexistente.Edad.ToString();
                    dateTimePicker2.Value = mascotaexistente.FechaNacimiento;

                    listaMascotasTemporales.Clear();
                    listBox1.Items.Clear();
                    listaMascotasTemporales.Add(mascotaexistente);
                    listBox1.Items.Add($"{mascotaexistente.Codigo_Mascota} - {mascotaexistente.Nombre} ({mascotaexistente.Especie})");
                }
                else
                {
                    listaMascotasTemporales.Clear();
                    listBox1.Items.Clear();
                    // Caso B: Si venimos desde frmAdminDueno, cargamos TODAS las mascotas que tiene ese dueño en el ListBox
                    if (duenoexistente.Mascotas != null) 
                    {
                        foreach (Mascota m in duenoexistente.Mascotas)
                        {
                            listaMascotasTemporales.Add(m);
                            listBox1.Items.Add($"{m.Codigo_Mascota} - {m.Nombre} ({m.Especie})");
                        }
                    }
                }
            }
        }
        public bool ValidarDatos()
        {
            bool value = true;
            if (textBox1.Text.Trim().Length == 0 || textBox2.Text.Trim().Length == 0 || textBox3.Text.Trim().Length == 0
                || textBox4.Text.Trim().Length == 0 || textBox5.Text.Trim().Length == 0 || textBox6.Text.Trim().Length == 0 || textBox7.Text.Trim().Length == 0 
                || textBox8.Text.Trim().Length == 0 || comboBox1.SelectedIndex < 0 || comboBox2.SelectedIndex < 0 || dateTimePicker1.Value == null)
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
        public void LlenarComboDuenos()
        {
            // 1. Limpiamos los elementos actuales para evitar duplicados
            comboBox3.Items.Clear();

            // 2. Recorremos tu lista estática de TListas
            foreach (Dueno d in TListas.Lista_Duenos)
            {
                // Agregamos únicamente el Nombre y el Apellido
                comboBox3.Items.Add($"{d.Nombre} {d.Apellido}");
            }

            // 3. Si hay dueños registrados, seleccionamos el último por defecto
            if (duenoexistente == null && comboBox3.Items.Count > 0)
            {
                comboBox3.SelectedIndex = comboBox3.Items.Count - 1;
            }
        }
        public Dueno CrearObjeto()
        {
            try
            {
                // ==========================================
                // 1. CAPTURAR DATOS DE LA SECCIÓN: DUEÑO
                // ==========================================
                string codDueno = textBox1.Text; // Cambia por el Name real de tus TextBox
                string cedDueno = textBox2.Text;
                string nomDueno = textBox3.Text;
                string apeDueno = textBox4.Text;
                string sexoDueno = comboBox1.SelectedItem?.ToString();
                int edadDueno = int.Parse(textBox5.Text);
                DateTime fechanacDueno = dateTimePicker1.Value;
                string dirDueno = textBox6.Text;
                string telDueno = textBox7.Text;
                string correoDueno = textBox8.Text;

                // Instanciamos el objeto Dueño (La lista de mascotas se inicializa vacía en su constructor)
                Dueno nuevoDueno = new Dueno(codDueno, cedDueno, nomDueno, apeDueno, sexoDueno, edadDueno, fechanacDueno, dirDueno, telDueno, correoDueno);
                if (!TListas.Lista_Duenos.Any(d => d.Codigo == nuevoDueno.Codigo))
                {
                    TListas.Insert(nuevoDueno);
                }


                // ==========================================
                // 2. CAPTURAR DATOS DE LA SECCIÓN: MASCOTA
                // ==========================================
                string codMascota = textBox16.Text;
                string nomMascota = textBox15.Text;
                string especieMascota = comboBox2.SelectedItem.ToString();
                string razaMascota = textBox13.Text;
                int edadMascota = int.Parse(textBox12.Text);
                DateTime fechanacMascota = dateTimePicker2.Value;
                Dueno duenoMascota = comboBox3.SelectedItem.ToString() == $"{nuevoDueno.Nombre} {nuevoDueno.Apellido}" ? nuevoDueno : null;

                // Instanciamos la Mascota pasándole el dueño que acabamos de crear arriba
                Mascota nuevaMascota = new Mascota(codMascota, nomMascota, especieMascota, razaMascota, fechanacMascota, edadMascota, duenoMascota);

                // ==========================================
                // 3. VINCULACIÓN DE AMBOS OBJETOS
                // ==========================================
                // Añadimos la mascota a la lista interna del dueño
                nuevoDueno.agregarMascota(nuevaMascota);

                // [Opcional] Guardar la mascota en la lista global de mascotas si aplica
                if (!TListas.Lista_Mascotas.Any(m => m.Codigo_Mascota == nuevaMascota.Codigo_Mascota))
                {
                    TListas.InsertMascota(nuevaMascota);
                }


                // Retornamos el dueño completo (ya lleva la mascota en su lista interna)
                return nuevoDueno;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear el objeto: " + ex.Message);
                return null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que los campos básicos del dueño no estén vacíos
                if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    MessageBox.Show("Por favor, ingrese el código y nombre del dueño.");
                    return;
                }

                string codDueno = textBox1.Text;
                string cedDueno = textBox2.Text;
                string nomDueno = textBox3.Text;
                string apeDueno = textBox4.Text;
                string sexoDueno = comboBox1.SelectedItem?.ToString() ?? "No especificado";
                int edadDueno = string.IsNullOrWhiteSpace(textBox5.Text) ? 0 : int.Parse(textBox5.Text);
                DateTime fechanacDueno = dateTimePicker1.Value;
                string dirDueno = textBox6.Text;
                string telDueno = textBox7.Text;
                string correoDueno = textBox8.Text;

                // Crear objeto Dueño
                Dueno nuevoDueno = new Dueno(codDueno, cedDueno, nomDueno, apeDueno, sexoDueno, edadDueno, fechanacDueno, dirDueno, telDueno, correoDueno);

                // Insertar en la lista estática si no existe
                if (!TListas.Lista_Duenos.Any(d => d.Codigo == nuevoDueno.Codigo))
                {
                    TListas.Insert(nuevoDueno);
                }

                // Refrescar inmediatamente el ComboBox de abajo
                LlenarComboDuenos();

                MessageBox.Show("Dueño registrado con éxito. Ahora puede seleccionarlo abajo para su mascota.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar dueño: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if(duenoexistente != null)
                {
                    int idxDueno = TListas.Lista_Duenos.FindIndex(d => d.Codigo == duenoexistente.Codigo);
                    if(idxDueno != -1)
                    {
                        TListas.Lista_Duenos[idxDueno].Cedula = textBox2.Text.Trim();
                        TListas.Lista_Duenos[idxDueno].Nombre = textBox3.Text.Trim();
                        TListas.Lista_Duenos[idxDueno].Apellido = textBox4.Text.Trim();
                        TListas.Lista_Duenos[idxDueno].Sexo = comboBox1.SelectedItem?.ToString();
                        TListas.Lista_Duenos[idxDueno].Edad = string.IsNullOrWhiteSpace(textBox5.Text) ? 0 : int.Parse(textBox5.Text);
                        TListas.Lista_Duenos[idxDueno].FechaNacimiento = dateTimePicker1.Value;
                        TListas.Lista_Duenos[idxDueno].Direccion = textBox6.Text.Trim();
                        TListas.Lista_Duenos[idxDueno].Telefono = textBox7.Text.Trim();
                        TListas.Lista_Duenos[idxDueno].Correo = textBox8.Text.Trim();

                        // Asignamos esta referencia limpia como el dueño seleccionado
                        duenoSeleccionado = TListas.Lista_Duenos[idxDueno];

                        // Reiniciamos la lista interna de mascotas de este dueño para actualizarla
                        if (duenoSeleccionado.Mascotas != null)
                        {
                            duenoSeleccionado.Mascotas.Clear();
                        }

                    }
                }
                else
                {
                    if (comboBox3.SelectedIndex < 0)
                    {
                        MessageBox.Show("Debe seleccionar un dueño para continuar.");
                        return;
                    }
                    duenoSeleccionado = TListas.GetDueno(comboBox3.SelectedIndex);
                }
                // 2. ACTUALIZAR LA MASCOTA ACTIVA DE LAS CAJAS EN LA LISTA TEMPORAL (SI SE MODIFICÓ)
                if (mascotaexistente != null && !string.IsNullOrWhiteSpace(textBox16.Text))
                {
                    int idxM = listaMascotasTemporales.FindIndex(m => m.Codigo_Mascota == mascotaexistente.Codigo_Mascota);
                    if (idxM != -1)
                    {
                        listaMascotasTemporales[idxM].Nombre = textBox15.Text.Trim();
                        listaMascotasTemporales[idxM].Especie = comboBox2.SelectedItem?.ToString();
                        listaMascotasTemporales[idxM].Raza = textBox13.Text.Trim();
                        listaMascotasTemporales[idxM].Edad = string.IsNullOrWhiteSpace(textBox12.Text) ? 0 : int.Parse(textBox12.Text);
                        listaMascotasTemporales[idxM].FechaNacimiento = dateTimePicker2.Value;
                    }
                }

                // 3. GUARDAR TODO EN LAS LISTAS GLOBALES DE LA APLICACIÓN (TListas)
                foreach (Mascota mascotaTemp in listaMascotasTemporales)
                {
                    // Enlazamos al dueño correcto actualizado
                    mascotaTemp.Dueno = duenoSeleccionado;
                    duenoSeleccionado.agregarMascota(mascotaTemp);

                    // Buscamos si la mascota ya existe en la lista de la veterinaria
                    int idxMascotaGlobal = TListas.Lista_Mascotas.FindIndex(m => m.Codigo_Mascota == mascotaTemp.Codigo_Mascota);

                    if (idxMascotaGlobal != -1)
                    {
                        // Si ya existía, reemplazamos con sus datos nuevos modificados
                        TListas.Lista_Mascotas[idxMascotaGlobal] = mascotaTemp;
                    }
                    else
                    {
                        // Si es una mascota nueva añadida en esta edición, la insertamos
                        TListas.InsertMascota(mascotaTemp);
                    }
                }

                MessageBox.Show("¡Todos los cambios han sido modificados y guardados con éxito!", "Éxito");

                // Limpieza de memoria temporal
                listaMascotasTemporales.Clear();
                listBox1.Items.Clear();

                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar el guardado definitivo: " + ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Validaciones básicas de campos vacíos para la mascota
                if (string.IsNullOrWhiteSpace(textBox16.Text) || string.IsNullOrWhiteSpace(textBox15.Text))
                {
                    MessageBox.Show("Por favor, llene el código y nombre de la mascota.");
                    return;
                }

                // 2. Capturar datos de los campos de la mascota
                string codMascota = textBox16.Text;
                string nomMascota = textBox15.Text;
                string especieMascota = comboBox2.SelectedItem?.ToString() ?? "No especificada";
                string razaMascota = textBox13.Text;
                int edadMascota = string.IsNullOrWhiteSpace(textBox12.Text) ? 0 : int.Parse(textBox12.Text);
                DateTime fechanacMascota = dateTimePicker2.Value;

                // 3. Crear el objeto temporal (el dueño se enlazará al presionar el botón Ingresar definitivo)
                Mascota temporal = new Mascota(codMascota, nomMascota, especieMascota, razaMascota, fechanacMascota, edadMascota, duenoexistente);

                int indxTemp = listaMascotasTemporales.FindIndex(m => m.Codigo_Mascota == temporal.Codigo_Mascota);

                if (indxTemp != -1)
                {
                    listaMascotasTemporales[indxTemp] = temporal; // Reemplazamos el objeto temporal existente con el nuevo objeto modificado
                }
                else
                {
                    listaMascotasTemporales.Add(temporal); // Agregamos el nuevo objeto temporal a la lista
                }

                listBox1.Items.Clear();
                foreach (Mascota m in listaMascotasTemporales)
                {
                    listBox1.Items.Add($"{m.Codigo_Mascota} - {m.Nombre} ({m.Especie})");
                }
                LimpiarCamposMascota();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar la mascota en la lista: " + ex.Message);
            }
        }
        private void LimpiarCamposMascota()
        {
            textBox16.Clear();
            textBox15.Clear();
            textBox13.Clear();
            textBox12.Clear();
            comboBox2.SelectedIndex = -1;
            dateTimePicker2.Value = DateTime.Now;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                int indice = listBox1.SelectedIndex;

                // Remover de la lista en memoria y del componente visual
                listaMascotasTemporales.RemoveAt(indice);
                listBox1.Items.RemoveAt(indice);
            }
            else
            {
                MessageBox.Show("Seleccione una mascota de la lista para eliminarla.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.SelectedIndex = -1;
            dateTimePicker1.Value = DateTime.Now;
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox16.Clear();
            textBox15.Clear();
            textBox13.Clear();
            textBox12.Clear();
            comboBox2.SelectedIndex = -1;
            dateTimePicker2.Value = DateTime.Now;
            comboBox3.SelectedIndex = -1;
            listBox1.Items.Clear();
        }
    }
 }
