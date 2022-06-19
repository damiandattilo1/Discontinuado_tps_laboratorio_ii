using Microsoft.VisualStudio.TestTools.UnitTesting;
using Biblioteca;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        Persona persona = new Persona(1234, 36065992, "Damian", "Dattilo", true, 31, Persona.TramitesPersona.AperturaCajaAhorro);
        Empresa empresa = new Empresa(1234, 151515, "WASD Inc", 45, Empresa.TramitesEmpresa.PagoSalarios);
        Cliente<Entidad> cliente = new Cliente<Entidad>(50);

        [TestMethod]
        public void IgualdadEntreEntidades()
        {

            Assert.IsTrue((Entidad)persona == (Entidad)empresa);
        }
        
        [TestMethod]
        public void AgregarALista()
        {
            Assert.IsTrue(cliente.Agregar(persona));
            Assert.IsFalse(cliente.Agregar(empresa));
        }

        [TestMethod]
        public void RemoverDeLista()
        {
            cliente.Agregar(persona);
            Assert.IsTrue(cliente.Remover(persona));
        }

        [TestMethod]

        public void RemoverUnObjetoQueNoExisteEnLaLista()
        {
            Persona falsa = new Persona(11, 25, "juan", "Perez", true, 29, Persona.TramitesPersona.Prestamo);
            Assert.IsFalse(cliente.Remover(falsa));
        }

        [TestMethod]

        public void AgregarUnObjetoAUnaListaCompleta()
        {
            cliente = new Cliente<Entidad>(1);

            Assert.IsTrue(cliente.Agregar(persona));
            Assert.IsFalse(cliente.Agregar(empresa));
        }


    }
}
