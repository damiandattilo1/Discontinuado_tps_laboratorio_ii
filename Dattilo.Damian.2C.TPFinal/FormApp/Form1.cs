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
    public partial class rBtnEmpresa : Form
    {
        Cliente<Entidad> clientes;
        public rBtnEmpresa()
        {
            InitializeComponent();
            this.clientes = new Cliente<Entidad>(50);
        }


        private void btnMostrarListaClientes_Click(object sender, EventArgs e)
        {
            MostrarClientes lista = new MostrarClientes(clientes);
            lista.Show();

        }

        private void btnNuevaPersona_Click(object sender, EventArgs e)
        {
            FormPersona formPersona = new FormPersona(clientes);
            formPersona.Show();
        }

        private void btnNuevaEmpresa_Click(object sender, EventArgs e)
        {
            FormEmpresa formEmpresa = new FormEmpresa(clientes);
            formEmpresa.Show();
        }

        private void btngregarTramiteEmpresa_Click(object sender, EventArgs e)
        {
            FormAgregarTramite form = new FormAgregarTramite(clientes, false);
            form.Show();
        }

        private void btnAgregarTramitePersona_Click(object sender, EventArgs e)
        {
            FormAgregarTramite form = new FormAgregarTramite(clientes, true);
            form.Show();
        }
    }
}
