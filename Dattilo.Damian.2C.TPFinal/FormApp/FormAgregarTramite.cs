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
    public partial class FormAgregarTramite : Form
    {
        
        Cliente<Entidad> lista;
        bool esPersona;
        public FormAgregarTramite(Cliente<Entidad> lista, bool esPersona)
        {
            InitializeComponent();
            this.esPersona = esPersona;
            this.lista = lista;
        }

        private void FormAgregarTramite_Load(object sender, EventArgs e)
        {
            if(!esPersona)
            {
                this.cmbTramiteAAgregar.Items.AddRange(new String[] { "Credito", "Inversiones", "CuentaCorriente", "PagoSalarios" });
            }
            else
            {
                this.cmbTramiteAAgregar.Items.AddRange(new String[] { "AperturaCajaAhorro", "PlazoFijo", "TarjetasDeCredito", "Prestamo" });
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int id;
            Empresa empresa;
            Persona persona;
            Empresa.TramitesEmpresa tEmpresa = Empresa.TramitesEmpresa.PagoSalarios;
            Persona.TramitesPersona tPersona = Persona.TramitesPersona.PlazoFijo;

            switch (cmbTramiteAAgregar.Text)// { AperturaCajaAhorro, PlazoFijo, TarjetasDeCredito, Prestamo}
            {
                case "Credito":
                    tEmpresa = Empresa.TramitesEmpresa.Credito;
                    break;
                case "PagoSalarios":
                    tEmpresa = Empresa.TramitesEmpresa.PagoSalarios;
                    break;
                case "CuentaCorriente":
                    tEmpresa = Empresa.TramitesEmpresa.CuentaCorriente;
                    break;
                case "Inversiones":
                    tEmpresa = Empresa.TramitesEmpresa.Inversiones;
                    break;
                case "AperturaCajaAhorro":
                    tPersona = Persona.TramitesPersona.AperturaCajaAhorro;
                    break;
                case "PlazoFijo":
                    tPersona = Persona.TramitesPersona.PlazoFijo;
                    break;
                case "TarjetasDeCredito":
                    tPersona = Persona.TramitesPersona.TarjetasDeCredito;
                    break;
                case "Prestamo":
                    tPersona = Persona.TramitesPersona.Prestamo;
                    break;
                default:
                    tEmpresa = Empresa.TramitesEmpresa.PagoSalarios;
                    tPersona = Persona.TramitesPersona.PlazoFijo;
                    break;
            }
            if (!esPersona)
            {
                if( Int32.TryParse(this.txtId.Text, out id))
                {
                    empresa = lista.BuscarEmpresa(id);
                    if(empresa == null)
                    {
                        MessageBox.Show("error", "error");
                    }
                    else
                    {
                        empresa.AgregarTramite(tEmpresa);
                    }
                }
                else
                {
                    MessageBox.Show("error", "error");
                }
            }
            else
            {
                if (Int32.TryParse(this.txtId.Text, out id))
                {
                    persona = lista.BuscarPersona(id);
                    if (persona == null)
                    {
                        MessageBox.Show("error", "error");
                    }
                    else
                    {
                        persona.AgregarTramite(tPersona);
                        
                    }
                }
                else
                {
                    MessageBox.Show("error", "error");
                }
            }
        }
    }
}
