using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
            this.cmbOperador.Items.AddRange(new String[] { "", "+", "-", "*", "/" });
        }

        /// <summary>
        /// Boton para cerrar el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult rta = MessageBox.Show("¿Seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (rta == DialogResult.Yes)
            {
                Dispose();
            }
            else
            {
                MessageBox.Show("Cierre cancelado", "Salir", MessageBoxButtons.OK ,MessageBoxIcon.Exclamation);
            }
        }
        /// <summary>
        /// Evento Click del boton que convierte un numero decimal a binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            string resultadoBinario;


            if (string.IsNullOrEmpty(this.lblResultado.Text))
            {
                MessageBox.Show("ERROR, Realize alguna operacion");
            }
            else
            {
                resultadoBinario = Operando.DecimalBinario(double.Parse(this.lblResultado.Text));
                lblResultado.Text = resultadoBinario;

                btnConvertirABinario.Enabled = false;
                btnConvertirADecimal.Enabled = true;
            }

        }

        /// <summary>
        /// Evento Click del boton que convierte un numero binario a decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string resultadoDecimal;

            if(string.IsNullOrEmpty(this.lblResultado.Text))
            {
                MessageBox.Show("ERROR, Realize alguna operacion");
            }
            else
            {
                resultadoDecimal = Operando.BinarioDecimal(this.lblResultado.Text);
                lblResultado.Text = resultadoDecimal;

                btnConvertirABinario.Enabled = true;
                btnConvertirADecimal.Enabled = false;
            }
        }

        /// <summary>
        /// Evento Click del boton limpiar que inicializa todos los parametros de la calculadora
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
            
        }

        /// <summary>
        /// Evento Click del boton Operar que llama a la funcion Operar con los operandos y el operador
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado;
            StringBuilder sb = new StringBuilder();

            if(!string.IsNullOrEmpty(this.txtNumero1.Text) && !string.IsNullOrEmpty(this.txtNumero2.Text) && !string.IsNullOrEmpty(this.cmbOperador.Text))
            {
                resultado= Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text);
                lblResultado.Text = resultado.ToString();

                sb.Append($"{this.txtNumero1.Text} {this.cmbOperador.Text} {this.txtNumero2.Text} = {this.lblResultado.Text}");
                lstOperaciones.Items.Add (sb.ToString());

                btnConvertirADecimal.Enabled = false;
                btnConvertirABinario.Enabled = true;
            }
            else
            {
                MessageBox.Show("ERROR, Ingrese parametros");
            }

        }

        /// <summary>
        /// Metodo Limpiar que es llamado por el evento Click del boton Limpiar y por el evento Load del formulario. Inicializa todos los valores
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.cmbOperador.SelectedIndex = 0;
            this.lblResultado.Text = "";
            btnConvertirADecimal.Enabled = true;
            btnConvertirABinario.Enabled = true;
            
        }

        /// <summary>
        /// Metodo Operar que es llamado por el evento Click del boton operar. Crea dos objetos Operando con los parametros recibidos y retorna el resultado del metodo Operar de la clase calculadora, pasando los dos objetos y el operador como parametro
        /// </summary>
        /// <param name="numero1"></param> string conteniendo el primer operando
        /// <param name="numero2"></param> string conteniendo el segundo operando
        /// <param name="operador"></param> string conteniendo el operador
        /// <returns></returns> El resultado en formato double del metodo operar de la clase calculadora
        public static double Operar(string numero1, string numero2, string operador)
        {
            Operando n1 = new Operando(numero1);
            Operando n2 = new Operando(numero2);

            return Calculadora.Operar(n1, n2, char.Parse(operador));
        }

        /// <summary>
        /// Evento Load del formulario, en el que se invoca a la funcion Limpiar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
