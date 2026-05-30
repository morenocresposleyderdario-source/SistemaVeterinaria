using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Veterinaria.Entidades
{
    public class Mascota
    {
        private string codigo_Mascota;
        private string nombre;
        private string especie;
        private string raza;
        private DateTime fechaNacimiento;
        private int edad;
        private Dueno dueno;

        public Mascota()
        {
        }

        public Mascota(string codigo_Mascota, string nombre, string especie, string raza, DateTime fechaNacimiento, int edad, Dueno dueno)
        {
            this.Codigo_Mascota = codigo_Mascota;
            this.Nombre = nombre;
            this.Especie = especie;
            this.Raza = raza;
            this.FechaNacimiento = fechaNacimiento;
            this.Edad = edad;
            this.Dueno = dueno;
            if (dueno != null)
            {
                dueno.agregarMascota(this);
            }
        }

        public string Codigo_Mascota { get => codigo_Mascota; set => codigo_Mascota = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Especie { get => especie; set => especie = value; }
        public string Raza { get => raza; set => raza = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public int Edad { get => edad; set => edad = value; }
        public Dueno Dueno { get => dueno; set => dueno = value; }

        public string Imprimir()
        {
            return $"Código Mascota: {Codigo_Mascota}\nNombre: {Nombre}\nEspecie: {Especie}\nRaza: {Raza}\nFecha de Nacimiento: {FechaNacimiento}\nEdad: {Edad}\nDueño: {Dueno.Nombre} {Dueno.Apellido}";
        }
    }
}
