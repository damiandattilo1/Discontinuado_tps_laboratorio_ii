using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        public Operando()
        {
            this.numero = 0;
        }
        public Operando(double numero)
        {
            this.numero = numero;
        }
        public Operando(string strNumero) :this (double.Parse(strNumero)){ }

        private string Numero
        {
            set
            {
                this.Numero = value;
            }
            
        }
        

        /// <summary>
        /// Convierte el operando string en double
        /// </summary>
        /// <param name="strNumero"></param> Operando a convertir
        /// <returns></returns> El operando convertido
        private double ValidarOperando(string strNumero)
        {
            double resultado;

            double.TryParse(strNumero, out resultado);
            
            return resultado;
        }

        /// <summary>
        /// Valida que el string recibido contenga un numero binario
        /// </summary>
        /// <param name="binario"></param> String a validar
        /// <returns></returns> true si el string es binario, false si no lo es
        private static bool EsBinario(string binario)
        {
            int numeroInt;
            bool esBinario = int.TryParse(binario, out numeroInt);

            if (esBinario)
            {
                for (int i = binario.Length; i > 0; i--)
                {
                    if ((double)numeroInt % 10 != 1 && (double)numeroInt % 10 != 0)
                    {
                        esBinario = false;
                    }

                    numeroInt = (numeroInt / 10);
                }
            }

            return esBinario;
        }

        /// <summary>
        /// Convierte un numero decimal en variable double a binario
        /// </summary>
        /// <param name="numero"></param> El numero a convertir
        /// <returns></returns> Un string conteniendo el binario resultante
        public static string DecimalBinario(double numero)
        {
            int numeroEntero = (int)numero;
            int resultadoInt;
            string resultadoInvertido = "";
            string resultadoFinal = "";
            
            do
            {
                resultadoInvertido += (double)numeroEntero % 2;
                numeroEntero = numeroEntero / 2;
            }while(numeroEntero > 1);

            resultadoInvertido += numeroEntero;
            resultadoInt = int.Parse(resultadoInvertido);
            for(int i = resultadoInvertido.Length; i > 0; i--)
            {
                if(resultadoInt % 10 == 1)
                {
                    resultadoFinal += "1";
                }
                else
                {
                    resultadoFinal += "0";
                }
                resultadoInt = resultadoInt / 10;
            }
            return resultadoFinal;
        }
         
        /// <summary>
        /// Convierte un numero contenido en un string a binario
        /// </summary>
        /// <param name="numero"></param> Numero decimal a convertir, en formato string
        /// <returns></returns> Conversion a binario, en formato string
        public static string DecimalBinario(string numero)
        {
            double numeroDouble;
            if (!double.TryParse(numero, out numeroDouble))
            {
                return "Valor invalido";
            }
            else
            {
                return DecimalBinario(numeroDouble);
            }
        }

        /// <summary>
        /// Convierte un numero binario a decimal
        /// </summary>
        /// <param name="binario"></param>  Numero binario a convertir, en formato string
        /// <returns></returns> Resultado decimal de la conversion, en formato string
        public static string BinarioDecimal(string binario)
        {
            int resultado = 0;
            int numeroInt;
            if(EsBinario(binario))
            {
                numeroInt = int.Parse(binario);
                for (int i = 0; numeroInt > 0; i++)
                {
                    if ((double)numeroInt % 2 == 1)
                    {
                        resultado += (int)Math.Pow(2, i);
                    }
                
                    numeroInt = (numeroInt / 10);
                }
                return resultado.ToString();
            }
            else
            {
                return "Valor invalido";
            }

        }
         

        /// <summary>
        /// Sobrecarga del operador resta, que realiza la resta entre dos propiedades numero de dos objetos del tipo Operando
        /// </summary>
        /// <param name="n1"></param> Objeto 1
        /// <param name="n2"></param> Objeto 2
        /// <returns></returns> El resultado de la operacion
        public static double operator -(Operando n1, Operando n2)
        {
            return (n1.numero - n2.numero);
        }


        /// <summary>
        /// Sobrecarga del operador asterisco, que realiza la multiplicacion entre dos propiedades numero de dos objetos del tipo Operando
        /// </summary>
        /// <param name="n1"></param> Objeto 1
        /// <param name="n2"></param> Objeto 2
        /// <returns></returns> El resultado de la operacion
        public static double operator *(Operando n1, Operando n2)
        {
            return (n1.numero * n2.numero);
        }

        /// <summary>
        /// Sobrecarga del operador division, que realiza la division entre dos propiedades numero de dos objetos del tipo Operando
        /// </summary>
        /// <param name="n1"></param> Objeto 1
        /// <param name="n2"></param> Objeto 2 (se valida que sea != 0)
        /// <returns></returns> El resultado de la operacion. En caso de que n2.numero == 0, devuelve double.MinValue
        public static double operator /(Operando n1, Operando n2)
        {
            double retorno = double.MinValue;
            
            if (n2.numero != 0)
            {
                retorno = (n1.numero / n2.numero);
            }
            
            return retorno;
        }

        /// <summary>
        /// Sobrecarga del operador suma, que realiza la suma entre dos propiedades numero de dos objetos del tipo Operando
        /// </summary>
        /// <param name="n1"></param> Objeto 1
        /// <param name="n2"></param> Objeto 2
        /// <returns></returns> El resultado de la operacion
        public static double operator +(Operando n1, Operando n2)
        {
            return (n1.numero + n2.numero);
        }

        
    }
}
