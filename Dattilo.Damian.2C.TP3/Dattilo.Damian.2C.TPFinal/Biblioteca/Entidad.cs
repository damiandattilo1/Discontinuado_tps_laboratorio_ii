using System;
using System.Text;

namespace Biblioteca
{
    /// <summary>
    /// Clase abstracta
    /// </summary>
    public abstract class Entidad
    {
        internal int id;
        protected string nombre;
        protected int edad;

        public abstract string NombreCompleto { get; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="edad"></param>
        public Entidad(int id, string nombre, int edad)
        {
            this.id = id;
            this.nombre = nombre;
            this.edad = edad;

        }

        /// <summary>
        /// imprime los datos de la entidad
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.id}");
            sb.AppendLine(this.NombreCompleto);

            return sb.ToString();
        }

        /// <summary>
        /// igualdad de entidades segun el id
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        public static bool operator ==(Entidad c1, Entidad c2)
        {
            return (c1.id == c2.id);
        }

        public static bool operator !=(Entidad c1, Entidad c2)
        {
            return !(c1 == c2);
        }

    }
}
