using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Empresa :Entidad
    {
        /// <summary>
        /// Enumerado de tramites correspondientes a empresas
        /// </summary>
        public enum TramitesEmpresa { Credito, Inversiones, CuentaCorriente, PagoSalarios}

        protected int codigo;
      
        /// <summary>
        /// Lista de tipo diccionario indicando los tramites que tiene la empresa (el tramite es Key y Value es la cantidad de veces que se repite el tramite
        /// </summary>
        protected Dictionary<TramitesEmpresa, int> listaTramites;

        /// <summary>
        /// Propiedad que retorna el nombre de la empresa
        /// </summary>
        public override string NombreCompleto
        {
            get
            {
                return base.nombre;
            }
        }

        public int Codigo { get => codigo; set => codigo = value; }

        /// <summary>
        /// Constructor privado que inicializa la lista diccionario con el primer tramite
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="edad"></param>
        /// <param name="tramite"></param>
        private Empresa(int id, string nombre, int edad, TramitesEmpresa tramite) : base(id, nombre, edad)
        {
            this.listaTramites = new Dictionary<TramitesEmpresa, int>();
            listaTramites.Add(tramite, 1);
        }

        /// <summary>
        /// Constructor publico
        /// </summary>
        /// <param name="id"></param> 
        /// <param name="codigo"></param>
        /// <param name="nombre"></param>
        /// <param name="edad"></param>
        /// <param name="tramite"></param>
        public Empresa(int id, int codigo, string nombre, int edad, TramitesEmpresa tramite) :this(id, nombre, edad, tramite)
        {
            this.codigo = codigo;
            
        }

        /// <summary>
        /// Metodo to string para imprimir por pantalla la empresa
        /// </summary>
        /// <returns></returns> string conteniendo los datos de la empresa
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Empresa");
            sb.Append(base.ToString());
            sb.AppendLine($"Codigo: {this.codigo}");
            sb.AppendLine($"Anios en servicio: {base.edad}");

            sb.AppendLine("TRAMITES:");
            foreach(KeyValuePair <TramitesEmpresa, int> item in listaTramites)
            {
                sb.AppendLine($"{item.Key} x {item.Value}");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Agrega un tramite a una empresa preexistente
        /// </summary>
        /// <param name="tramite"></param> El tramite a agregar
        /// <returns></returns> bool indicando si el tramite pudo ser agregado
        public bool AgregarTramite(TramitesEmpresa tramite)
        {
            bool retorno = false;
            bool tramiteRepetido = false;
            int aux = 0;

            foreach(KeyValuePair<TramitesEmpresa, int> item in this.listaTramites)
            {
                if(item.Key == tramite)
                {
                    aux = item.Value;
                    listaTramites.Remove(item.Key);
                    tramiteRepetido = true;
                    break;
                }
            }
            if(!tramiteRepetido)
            {
                listaTramites.Add(tramite, 0);
            }
            else
            {
                listaTramites.Add(tramite, aux);
            }

            return retorno;

        }

        /// <summary>
        /// Sobrecarga de la igualdad entre dos empresas teniendo el mismo id
        /// </summary>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        /// <returns></returns>
        public static bool operator ==(Empresa e1, Empresa e2)
        {
            return e1.codigo == e2.codigo || (Entidad)e1 == (Entidad)e2;
        }

        public static bool operator !=(Empresa e1, Empresa e2)
        {
            return !(e1 == e2);
        }

        public override bool Equals(object obj)
        {
            Empresa empresa = obj as Empresa;

            return empresa is not null && this == empresa;
        }

    }
}
