using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Biblioteca
{
    public class Persona :Entidad, IHabitual
    {
        public enum TramitesPersona { AperturaCajaAhorro, PlazoFijo, TarjetasDeCredito, Prestamo}

        protected string apellido;
        protected int dni;
        protected bool cuentaCorriente;
        protected Dictionary<TramitesPersona, int> listaTramites;

        /// <summary>
        /// Propiedad que devuelve el nombre completo de la persona
        /// </summary>
        public override string NombreCompleto
        {
            get
            {
                return string.Format("{0}, {1}", this.apellido, base.nombre);
            }
        }

        private Persona(int id, string nombre, int edad, TramitesPersona tramite) : base(id, nombre, edad)
        {
            this.listaTramites = new Dictionary<TramitesPersona, int>();
            listaTramites.Add(tramite, 1);
        }

        public Persona(int id, int dni, string nombre, string apellido, bool cuentaCorriente, int edad, TramitesPersona tramite) :this(id, nombre, edad, tramite)
        {
            this.apellido = apellido;
            this.dni = dni;
            this.cuentaCorriente = cuentaCorriente;
        }

        public bool EsHabitual()
        {
            return this.cuentaCorriente;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Persona");
            sb.Append(base.ToString());
            sb.AppendLine($"DNI: {this.dni}");
            sb.AppendLine($"Edad: {base.edad}");
            sb.AppendFormat("Es habitual: {0}\n", EsHabitual() ? "SI" : "NO");

            sb.AppendLine("TRAMITES:");
            foreach (KeyValuePair<TramitesPersona, int> item in listaTramites)
            {
                sb.AppendLine($"{item.Key} x {item.Value}");
            }

            return sb.ToString();
        }

        

        public bool AgregarTramite(TramitesPersona tramite)
        {
            bool retorno = false;
            bool tramiteRepetido = false;
            int aux = 0;

            foreach (KeyValuePair<TramitesPersona, int> item in this.listaTramites)
            {
                if (item.Key == tramite)
                {
                    aux = item.Value;
                    listaTramites.Remove(item.Key);
                    tramiteRepetido = true;
                    break;
                }
            }
            if (!tramiteRepetido)
            {
                listaTramites.Add(tramite, 0);
            }
            else
            {
                listaTramites.Add(tramite, aux);
            }

            return retorno;

        }

        public static bool operator ==(Persona p1, Persona p2)
        {
            return p1.dni == p2.dni || (Entidad)p1 == (Entidad)p2;
        }

        public static bool operator !=(Persona p1, Persona p2)
        {
            return !(p1 == p2);
        }

        public override bool Equals(object obj)
        {
            Persona persona = obj as Persona;

            return persona is not null && this == persona;
        }
    }
}
