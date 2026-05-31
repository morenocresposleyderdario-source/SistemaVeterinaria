using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Veterinaria.Entidades
{
    public class Medico
    {
        private string id_Medico;
        private string cedula;
        private string nombre;
        private string apellido;
        private string especialidad;
        private string telefono;
        private string correo;
        private string numero_Licencia;

        public Medico()
        {
        }

        public Medico(string id_medico, string cedula, string nombre, string apellido, string especialidad, string telefono, string correo, string numero_Licencia)
        {
            this.Id_Medico = id_medico;
            this.Cedula = cedula;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Especialidad = especialidad;
            this.Telefono = telefono;
            this.Correo = correo;
            this.Numero_Licencia = numero_Licencia;
        }

        public string Id_Medico { get => id_Medico; set => id_Medico = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Especialidad { get => especialidad; set => especialidad = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Numero_Licencia { get => numero_Licencia; set => numero_Licencia = value; }
        public string Imprimir()
        {
            return $"ID Médico: {Id_Medico}\nCédula: {Cedula}\nNombre: {Nombre}\nApellido: {Apellido}\nEspecialidad: {Especialidad}\nTeléfono: {Telefono}\nCorreo: {Correo}\nNúmero de Licencia: {Numero_Licencia}";
        }
        public override string ToString()
        {
            return $"{this.Nombre} {this.Apellido}";
        }
    }
}
