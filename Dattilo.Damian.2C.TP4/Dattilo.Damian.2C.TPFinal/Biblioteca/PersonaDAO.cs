using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Biblioteca;


namespace Biblioteca
{
    public class PersonaDAO
    {
        private static string connectionString;
        private SqlConnection connection;
        private SqlCommand command;


        static PersonaDAO()
        {
            connectionString = @"Server=.\SQLEXPRESS01;Database=TP-Final; Trusted_Connection=True;";

        }
        public PersonaDAO()
        {
            connection = new SqlConnection(PersonaDAO.connectionString);
            command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;

        }

        public void Guardar(Persona persona)
        {
            try
            {
                connection.Open();

                string query = "INSERT INTO Personas (id,nombre,apellido,edad,dni,cuentaCorriente) VALUES (@id, @nombre, @apellido, @edad, @dni, @cuentaCorriente)";

                command.CommandText = query;

                command.Parameters.Clear();
                command.Parameters.AddWithValue("id", persona.Id);
                command.Parameters.AddWithValue("nombre", persona.Nombre);
                command.Parameters.AddWithValue("apellido", persona.Apellido);
                command.Parameters.AddWithValue("edad", persona.Edad);
                command.Parameters.AddWithValue("dni", persona.Dni);
                command.Parameters.AddWithValue("cuentaCorriente", persona.CuentaCorriente);

                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection is not null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        public List<Persona> Leer()
        {
            List<Persona> lista = new List<Persona>();
            try
            {
                string query = "SELECT * FROM Personas";
                connection.Open();
                command.CommandText = query;

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    int id = dataReader.GetInt32(0);
                    string nombre = dataReader.GetString(1);
                    string apellido = dataReader.GetString(2);
                    int edad = dataReader.GetInt32(3);
                    int dni = dataReader.GetInt32(4);
                    bool cuentaCorriente = bool.Parse(dataReader.GetChar(5).ToString());
                    int tramiteInt = dataReader.GetInt32(6);

                    Persona.TramitesPersona tramite;

                    switch (tramiteInt)
                    {
                        case 1:
                            tramite = Persona.TramitesPersona.PlazoFijo;
                            break;
                        case 2:
                            tramite = Persona.TramitesPersona.Prestamo;
                            break;
                        case 3:
                            tramite = Persona.TramitesPersona.AperturaCajaAhorro;
                            break;
                        case 4:
                            tramite = Persona.TramitesPersona.TarjetasDeCredito;
                            break;
                        default:
                            tramite = Persona.TramitesPersona.PlazoFijo;
                            break;
                    }
                    

                    Persona persona = new Persona(id, dni, nombre, apellido, cuentaCorriente, edad, tramite);

                    lista.Add(persona);
                }
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (connection is not null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

        }
        public void Modificar(int id, Persona persona)
        {
            try
            {
                string query = "UPDATE Personas SET nombre =  @nombre, apellido = @apellido, edad = @edad, dni = @dni, cuentaCorriente = @cuentaCorriente WHERE id = @id";

                connection.Open();

                command.CommandText = query;

                command.Parameters.Clear();
                command.Parameters.AddWithValue("id", id);
                command.Parameters.AddWithValue("nombre", persona.Nombre);
                command.Parameters.AddWithValue("apellido", persona.Apellido);
                command.Parameters.AddWithValue("edad", persona.Edad);
                command.Parameters.AddWithValue("dni", persona.Dni);
                command.Parameters.AddWithValue("cuentaCorriente", persona.CuentaCorriente);

                command.ExecuteNonQuery();


            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (connection is not null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        public void Eliminar(int id)
        {
            try
            {
                string query = "DELETE FROM Personas WHERE id = @idBuscado";

                connection.Open();

                command.CommandText = query;

                command.Parameters.Clear();
                command.Parameters.AddWithValue("idBuscado", id);

                command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (connection is not null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

    }
}
