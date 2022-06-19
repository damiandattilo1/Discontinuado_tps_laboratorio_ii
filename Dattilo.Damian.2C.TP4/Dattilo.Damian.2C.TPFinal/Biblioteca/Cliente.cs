using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Cliente <T> where T : Entidad
    {
        public int capacidadMaxima;
        public List<T> lista; // Lista GENERICA donde se agregan los productos


        /// <summary>
        /// Constructor privado donde se instancia la lista generica
        /// </summary>
        /// <param name="capacidad"></param>
        private Cliente()
        {
            this.lista = new List<T>();
        }

        /// <summary>
        /// Constructor donde se establece la capacidad
        /// </summary>
        /// <param name="capacidad"></param>
        public Cliente(int capacidad) :this()
        {
            this.capacidadMaxima = capacidad;
        }

        /// <summary>
        /// Metodo que agrega un cliente a la lista
        /// </summary>
        /// <param name="aprobado"></param> objeto a agregar
        /// <returns></returns> TRue si se pudo agregar el objeto, de lo contrario False
        public bool Agregar(T cliente)
        {
            return (this + cliente);
        }

        /// <summary>
        /// Metodo estatico que verifica si un cliente ya esta en la lista generica.
        /// </summary>
        /// <param name="control"></param> objeto conteniendo la lista
        /// <param name="aprobado"></param> cliente a comparar
        /// <returns></returns>  True si el cliente esta en la lista, de lo contrario false
        public static bool operator ==(Cliente<T> c, T cliente)
        {
            bool flag = false;

            foreach (T item in c.lista)
            {
                if (item == cliente)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }

        public static bool operator !=(Cliente<T> c, T cliente)
        {
            return !(c == cliente);
        }

        /// <summary>
        /// Sobrecarga del operador + para agregar un objeto a la lista generica si queda lugar en la misma
        /// </summary>
        /// <param name="c"></param> instancia conteniendo la lista generica 
        /// <param name="aprobado"></param>  cliente a agregar
        /// <returns></returns> True si se pudo agregar, de lo contrario False
        public static bool operator +(Cliente<T> c, T cliente)
        {
            bool flag = false;
            bool esRepetido = (c == cliente);


            if (c.lista.Count < c.capacidadMaxima && esRepetido == false)
            {
                c.lista.Add(cliente);
                flag = true;
            }

            return flag;
        }

        /// <summary>
        /// Metodo para remover un cliente de la lista generica
        /// </summary>
        /// <param name="aprobado"></param> Cliente a remover
        /// <returns></returns> True si se pudo agregar, de lo contrario False
        public bool Remover(T aprobado)
        {
            return (this - aprobado);
        }

        /// <summary>
        /// Sobrecarga del operador - para remover un cliente de la lista generica
        /// </summary>
        /// <param name="c"></param> instancia con la lista generica
        /// <param name="aprobado"></param> Cliente a remover
        /// <returns></returns> True si el cliente pudo ser removido, de lo contrario false

        public static bool operator -(Cliente<T> c, T aprobado)
        {
            bool retorno = false;
            foreach (T item in c.lista)
            {
                if (item == aprobado)
                {
                    c.lista.Remove(item);
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }


        /// <summary>
        /// Polimorfismo en to string para mostrar por pantalla la lista generica
        /// </summary>
        /// <returns></returns> Un string conteniendo todos los datos de la lista
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Capacidad Maxima = {this.capacidadMaxima}\n\nListado de {typeof(T).Name}:\n");

            foreach (T item in lista)
            {
                sb.AppendLine($"{item.ToString()}");
            }

            return sb.ToString();
        }



        public static implicit operator string(Cliente<T> c)
        {
            return c.ToString();
        }

        public Empresa BuscarEmpresa(int id)
        {
            foreach (T item in this.lista)
            {
                if (item.id == id)
                {
                    return item as Empresa;
                }
            }

            return null;
        }

        public Persona BuscarPersona(int id)
        {
            foreach (T item in this.lista)
            {
                if(item.id == id && item is Persona)
                {
                    return item as Persona;
                }
            }

            return null;
        }
    }
}

