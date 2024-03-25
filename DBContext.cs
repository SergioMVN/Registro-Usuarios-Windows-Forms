using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroUsuarios
{
    internal class DBContext
    {
        private readonly string connectionString = "Server=SERGIO\\SQLSERVER2023;Database=UsuariosRegistro;Trusted_Connection=True;";

        public void AgregarUsuario(string nombre, string apellido, string telefono, string direccion)
        {
            try
            {
                // Establecer la conexión con la base de datos
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Abrir la conexión
                    connection.Open();

                    // Definir la consulta SQL para insertar los datos en la tabla Usuarios
                    string sqlQuery = "INSERT INTO Usuarios (Nombre, Apellido, Telefono, Direccion) VALUES (@Nombre, @Apellido, @Telefono, @Direccion)";

                    // Crear un comando SQL con la consulta y la conexión
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        // Asignar los valores de los parámetros de la consulta
                        command.Parameters.AddWithValue("@Nombre", nombre);
                        command.Parameters.AddWithValue("@Apellido", apellido);
                        command.Parameters.AddWithValue("@Telefono", telefono);
                        command.Parameters.AddWithValue("@Direccion", direccion);

                        // Ejecutar la consulta SQL para insertar los datos en la tabla
                        int rowsAffected = command.ExecuteNonQuery();

                        // Verificar si se insertaron correctamente los datos
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Los datos se han agregado correctamente a la base de datos.");
                        }
                        else
                        {
                            Console.WriteLine("No se pudo agregar los datos a la base de datos.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al intentar agregar datos a la base de datos: " + ex.Message);
            }
        }

    }
}
