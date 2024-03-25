using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistroUsuarios
{
    public partial class Agregar : Form
    {
        public Agregar()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string telefono = txtTelefono.Text;
            string direccion = txtDireccion.Text;

            // Crear una instancia de la clase DBContext para acceder a sus métodos
            DBContext dbContext = new DBContext();

            // Llamar al método AgregarUsuario para agregar el nuevo usuario a la base de datos
            dbContext.AgregarUsuario(nombre, apellido, telefono, direccion);

            MessageBox.Show("Usuario Guardado con Éxito");

            LimpiarCampos();

        }


        private void LimpiarCampos()
        {
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
