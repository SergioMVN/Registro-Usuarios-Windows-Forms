using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroUsuarios
{
    internal class GestorBD
    {
        private readonly string connectionString = "Server=SERGIO\\SQLSERVER2023;Database=RegistroUsuariosDB;";

        public void consultarDatos()
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                //abrimos la conexion
                conexion.Open();
            }
        }
    }
}
