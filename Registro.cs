using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistroUsuarios
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Agregar agregar = new Agregar();
            agregar.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombreABuscar = textBox1.Text.Trim(); // Obtener el nombre a buscar desde un control TextBox (reemplaza "textBox1" con el nombre real de tu control TextBox)

            // Verificar si se proporcionó un nombre para buscar
            if (!string.IsNullOrEmpty(nombreABuscar))
            {
                MostrarUsuariosRegistrados(nombreABuscar);
            }
            else
            {
                MessageBox.Show("Por favor, ingresa un nombre para buscar.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void MostrarUsuariosRegistrados(string nombre)
        {
            using (SqlConnection conexion = new SqlConnection("Server=SERGIO\\SQLSERVER2023;Database=UsuariosRegistro;Trusted_Connection=True;"))
            {
                try
                {
                    conexion.Open();
                    string consulta = "SELECT * FROM Usuarios WHERE Nombre LIKE @Nombre"; // Filtrar usuarios por nombre"; 
                    SqlCommand comando = new SqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@Nombre", "%" + nombre + "%"); // Utilizar parámetros para prevenir inyección SQL
                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                    DataTable tablaUsuarios = new DataTable();
                    adaptador.Fill(tablaUsuarios);
                    dataGridView1.DataSource = tablaUsuarios;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los usuarios: " + ex.Message);
                }
            }
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonVerTodo_Click(object sender, EventArgs e)
        {
            MostrarUsuariosRegistrados();
        }

        private void MostrarUsuariosRegistrados()
        {
            using (SqlConnection conexion = new SqlConnection("Server=SERGIO\\SQLSERVER2023;Database=UsuariosRegistro;Trusted_Connection=True;"))
            {
                try
                {
                    conexion.Open();
                    string consulta = "SELECT * FROM Usuarios"; // Reemplaza "Usuarios" por el nombre real de tu tabla de usuarios
                    SqlCommand comando = new SqlCommand(consulta, conexion);
                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                    DataTable tablaUsuarios = new DataTable();
                    adaptador.Fill(tablaUsuarios);
                    dataGridView1.DataSource = tablaUsuarios;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los usuarios: " + ex.Message);
                }
            }
        }
    }
}
