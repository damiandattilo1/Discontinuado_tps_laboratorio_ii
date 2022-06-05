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
    public partial class MostrarClientes : Form
    {
        Cliente<Entidad> lista;
        public MostrarClientes(Cliente<Entidad> lista)
        {
            InitializeComponent();
            this.lista = lista;
        }

        private void MostrarClientes_Load(object sender, EventArgs e)
        {
            rtbLista.Text = lista.ToString();
        }
    }
}
