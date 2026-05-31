using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Veterinaria.Entidades
{
    public class Dueno
    {
        private string codigo;
        private string cedula;
        private string nombre;
        private string apellido;
        private string sexo;
        private int edad;
        private DateTime fechaNacimiento;
        private string direccion;
        private string telefono;
        private string correo;
        private List<Mascota> mascotas;

        public Dueno()
        {
        }
        public Dueno(string codigo, string cedula, string nombre, string apellido, string sexo, int edad, DateTime fechaNacimiento, string direccion, string telefono, string correo)
        {
            this.Codigo = codigo;
            this.Cedula = cedula;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Sexo = sexo;
            this.Edad = edad;
            this.FechaNacimiento = fechaNacimiento;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Correo = correo;
            this.Mascotas = new List<Mascota>();
        }

        public string Codigo { get => codigo; set => codigo = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Sexo { get => sexo; set => sexo = value; }
        public int Edad { get => edad; set => edad = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Correo { get => correo; set => correo = value; }
        public List<Mascota> Mascotas { get => mascotas; set => mascotas = value; }

        public void agregarMascota(Mascota mascota)
        {
            this.Mascotas.Add(mascota);
        }

        public string Imprimir()
        {
            return $"Código: {Codigo}\nCédula: {Cedula}\nNombre: {Nombre}\nApellido: {Apellido}\nSexo: {Sexo}\nEdad: {Edad}\nFecha de Nacimiento: {FechaNacimiento}\nDirección: {Direccion}\nTeléfono: {Telefono}\nCorreo: {Correo}";
        }
        public override string ToString()
        {
            return $"{this.Nombre} {this.Apellido}";
        }
    }
}
