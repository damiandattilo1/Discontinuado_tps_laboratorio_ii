using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblioteca;

namespace FormApp
{
    public partial class FormPersona : Form
    {
        Cliente<Entidad> clientes;
        public FormPersona(Cliente<Entidad> clientes)
        {
            InitializeComponent();
            this.clientes = clientes;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Persona persona = CrearPersona();

            //clientes.Agregar(persona); 

            if(persona is not null)
            {
                clientes.Agregar(persona);
            }
            this.Close();
        }

        private Persona CrearPersona()
        {
            int id;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            int dni;
            int edad;
            bool cuentaCorriente;

            if (!int.TryParse(txtId.Text, out id) || !int.TryParse(txtDni.Text, out dni) || !int.TryParse(txtEdad.Text, out edad) || nombre == null || apellido == null)
            {
                MessageBox.Show("Ingrese valores validos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            else
            {
                if (rBtnSi.Checked)
                {
                    cuentaCorriente = true;
                }
                else
                {
                    cuentaCorriente = false;
                }

                return new Persona(id, dni, nombre, apellido, cuentaCorriente, edad, Persona.TramitesPersona.PlazoFijo);
            }

        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormPersona_Load(object sender, EventArgs e)
        {
            this.cmbTramite.Items.AddRange(new String[] { "AperturaCajaAhorro", "PlazoFijo", "TarjetasDeCredito", "Prestamo" });
        }
    }
}
