using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Veterinaria.Entidades
{
    public class GuiaConsulta
    {
        private int idConsulta;
        private DateTime fechaConsulta;
        private Mascota mascota;
        private Dueno dueno;
        private String motivo;
        private int temperatura;
        private double peso;
        private double frecuenciaCardiaca;
        private double frecuenciaRespiratoria;
        private double estatura;
        private string diagnostico;
        private string tratamiento;

        public GuiaConsulta()
        {
        }
        public GuiaConsulta(int idConsulta, DateTime fechaConsulta, Mascota mascota, Dueno dueno, string motivo, int temperatura, double peso, double frecuenciaCardiaca, double frecuenciaRespiratoria, double estatura, string diagnostico, string tratamiento)
        {
            this.IdConsulta = idConsulta;
            this.FechaConsulta = fechaConsulta;
            this.Mascota = mascota;
            this.Dueno = dueno;
            this.Motivo = motivo;
            this.Temperatura = temperatura;
            this.Peso = peso;
            this.FrecuenciaCardiaca = frecuenciaCardiaca;
            this.FrecuenciaRespiratoria = frecuenciaRespiratoria;
            this.Estatura = estatura;
            this.Diagnostico = diagnostico;
            this.Tratamiento = tratamiento;
        }

        public int IdConsulta { get => idConsulta; set => idConsulta = value; }
        public DateTime FechaConsulta { get => fechaConsulta; set => fechaConsulta = value; }
        public Mascota Mascota { get => mascota; set => mascota = value; }
        public Dueno Dueno { get => dueno; set => dueno = value; }
        public string Motivo { get => motivo; set => motivo = value; }
        public int Temperatura { get => temperatura; set => temperatura = value; }
        public double Peso { get => peso; set => peso = value; }
        public double FrecuenciaCardiaca { get => frecuenciaCardiaca; set => frecuenciaCardiaca = value; }
        public double FrecuenciaRespiratoria { get => frecuenciaRespiratoria; set => frecuenciaRespiratoria = value; }
        public double Estatura { get => estatura; set => estatura = value; }
        public string Diagnostico { get => diagnostico; set => diagnostico = value; }
        public string Tratamiento { get => tratamiento; set => tratamiento = value; }
        public string NombreMascota { get => mascota != null ? mascota.Nombre : "Sin registrar"; }
        public string NombreDueno { get => dueno != null ? $"{dueno.Nombre} {dueno.Apellido}" : "Sin registrar"; }

        public string ImprimirResumen()
        {
            return $"Consulta #{IdConsulta} - Fecha: {FechaConsulta}\n" +
                   $"Paciente: {NombreMascota} | Dueño: {NombreDueno}\n" +
                   $"Motivo: {Motivo}\n" +
                   $"Temperatura de la mascota: {Temperatura} °C\n" +
                   $"Peso de la mascota: {Peso} kg\n" +
                   $"Frecuencia cardíaca: {FrecuenciaCardiaca} bpm\n" +
                   $"Frecuencia respiratoria: {FrecuenciaRespiratoria} rpm\n" +
                   $"Estatura de la mascota: {Estatura} m\n" +
                   $"Diagnóstico: {Diagnostico}\n" +
                   $"Tratamiento: {Tratamiento}";
        }
    }
}
