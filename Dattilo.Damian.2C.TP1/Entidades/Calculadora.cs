using System;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Realiza las operaciones de la calculadora
        /// </summary>
        /// <param name="num1"></param> Primer parametro
        /// <param name="num2"></param> Segundo parametro
        /// <param name="operador"></param> Operador
        /// <returns></returns> El resultado de la operacion en formato double
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            double resultado = 0;
            
            switch (ValidarOperador(operador))
            {
                case '+':
                    resultado = num1 + num2;
                    break;
                case '-':
                    resultado = num1 - num2;
                    break;
                case '*':
                    resultado = num1 * num2;
                    break;
                case '/':
                    resultado = num1 / num2;
                    break;

            }
            return resultado;
        }

        /// <summary>
        /// Valida si el operador pasado como parametro es valido
        /// </summary>
        /// <param name="operador"></param> Operador a validar
        /// <returns></returns> El mismo operador si resulta valido, caso contrario '+'
        private static char ValidarOperador(char operador)
        {
            char retorno;

            if(operador == '+' || operador == '-' || operador == '*' || operador == '/')
            {
                retorno = operador;
            }
            else
            {
                retorno = '+';
            }

            return retorno;
        }
    }
}
