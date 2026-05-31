using Proyecto_Veterinaria.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Veterinaria.Controladores
{
    public class TListas
    {
        // ── Listas estáticas principales ──────────────────────
        public static List<Dueno> Lista_Duenos = new List<Dueno>();
        public static List<Mascota> Lista_Mascotas = new List<Mascota>();
        public static List<Medico> Lista_Medicos = new List<Medico>();
        public static List<GuiaConsulta> Lista_GuiaConsulta = new List<GuiaConsulta>();
        // ════════════════════════════════════════════════════════
        //  CRUD — Duenos
        // ════════════════════════════════════════════════════════
        public static void Insert(Dueno od)
        {
            Lista_Duenos.Add(od);
        }

        public static void Edit(int pos, Dueno od)
        {
            Lista_Duenos[pos] = od;
        }

        public static void Delete(int pos)
        {
            Lista_Duenos.RemoveAt(pos);
        }

        public static int Buscar(string cod)
        {
            int pos = -1;
            for (int i = 0; i < Lista_Duenos.Count; i++)
            {
                if (Lista_Duenos[i].Codigo.Equals(cod))
                {
                    pos = i;
                    break;
                }
            }
            return pos;
        }

        public static Dueno GetDueno(int pos)
        {
            return Lista_Duenos[pos];
        }
        // ════════════════════════════════════════════════════════
        //  CRUD — Mascotas
        // ════════════════════════════════════════════════════════
        public static void InsertMascota(Mascota om)
        {
            Lista_Mascotas.Add(om);
        }

        public static void EditMascota(int pos, Mascota om)
        {
            Lista_Mascotas[pos] = om;
        }

        public static void DeleteMascota(int pos)
        {
            // Antes de borrarla de la lista global, la quitamos de la lista interna de su dueño
            Mascota mascota = Lista_Mascotas[pos];
            mascota.Dueno.Mascotas.Remove(mascota);

            Lista_Mascotas.RemoveAt(pos);
        }

        public static int BuscarMascota(string cod)
        {
            int pos = -1;
            for (int i = 0; i < Lista_Mascotas.Count; i++)
            {
                if (Lista_Mascotas[i].Codigo_Mascota.Equals(cod))
                {
                    pos = i;
                    break;
                }
            }
            return pos;
        }

        public static Mascota GetMascota(int pos)
        {
            return Lista_Mascotas[pos];
        }

        // ════════════════════════════════════════════════════════
        //  CRUD — Médicos
        // ════════════════════════════════════════════════════════
        public static void InsertMedico(Medico om)
        {
            Lista_Medicos.Add(om);
        }

        public static void EditMedico(int pos, Medico om)
        {
            Lista_Medicos[pos] = om;
        }

        public static void DeleteMedico(int pos)
        {
            Lista_Medicos.RemoveAt(pos);
        }

        public static int BuscarMedico(string cod) // Asumiendo que el código de médico también sea string
        {
            int pos = -1;
            for (int i = 0; i < Lista_Medicos.Count; i++)
            {
                if (Lista_Medicos[i].Id_Medico.Equals(cod))
                {
                    pos = i;
                    break;
                }
            }
            return pos;
        }

        public static Medico GetMedico(int pos)
        {
            return Lista_Medicos[pos];
        }
    }
}