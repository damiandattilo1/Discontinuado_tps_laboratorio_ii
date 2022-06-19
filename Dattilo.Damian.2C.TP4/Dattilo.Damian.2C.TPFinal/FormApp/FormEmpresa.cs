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
    public partial class FormEmpresa : Form
    {
        Cliente<Entidad> clientes;
        public FormEmpresa(Cliente<Entidad> clientes)
        {
            InitializeComponent();
            this.clientes = clientes;
        }

        private Empresa CrearEmpresa()
        {
            int id;
            int codigo;
            string nombre = txtNombre.Text;
            int edad;
            Empresa.TramitesEmpresa tramite;


            if (!int.TryParse(txtId.Text, out id) || !int.TryParse(txtCodigo.Text, out codigo) || !int.TryParse(txtEdad.Text, out edad) || nombre == null || cmbTramite == null)
            {
                MessageBox.Show("Ingrese valores validos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            switch(cmbTramite.Text)
            {
                case "Credito":
                    tramite = Empresa.TramitesEmpresa.Credito;
                    break;
                case "PagoSalarios":
                    tramite = Empresa.TramitesEmpresa.PagoSalarios;
                    break;
                case "CuentaCorriente":
                    tramite = Empresa.TramitesEmpresa.CuentaCorriente;
                    break;
                case "Inversiones":
                    tramite = Empresa.TramitesEmpresa.Inversiones;
                    break;
                default:
                    tramite = Empresa.TramitesEmpresa.PagoSalarios;
                    break;
            }

            return new Empresa(id, codigo, nombre, edad, tramite);

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Empresa empresa = CrearEmpresa();

            if (empresa is not null)
            {
                clientes.Agregar(empresa);
            }
            
            this.Close();
        }

        private void FormEmpresa_Load(object sender, EventArgs e)
        {
            this.cmbTramite.Items.AddRange(new String[] { "Credito", "Inversiones", "CuentaCorriente", "PagoSalarios" });
        }
    }
}
