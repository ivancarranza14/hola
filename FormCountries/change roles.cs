using claseLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;

namespace dbAmonic
{
    public partial class change_roles : Form
    {
        int roladmin;
        List<Users> user_lista;
        List<Offices> lista_offices;
        UsersDAO users = new UsersDAO();
        OfficesDAO officesDAO = new OfficesDAO();
        Users user = new Users();

        string emailOriginal;

        public change_roles(Users usuarioSeleccionado)
        {
            InitializeComponent();
            mimetodo();
            CargarDatosUsuario(usuarioSeleccionado);
        }

        private void CargarDatosUsuario(Users usuarioSeleccionado)
        {
            emailOriginal = usuarioSeleccionado.Email;

            txtfirstname.Text = usuarioSeleccionado.Firstname;
            txtlastname.Text = usuarioSeleccionado.Lastname;
            txtemail.Text = usuarioSeleccionado.Email;
            foreach (Offices oficina in lista_offices)
            {
                if (oficina.Title == usuarioSeleccionado.Office)
                {
                    combooffice.SelectedItem = oficina;
                    break;
                }
            }

            if (usuarioSeleccionado.Role != null &&
                usuarioSeleccionado.Role.Equals("Administrator", StringComparison.OrdinalIgnoreCase))
            {
                radioadmin.Checked = true;
            }
            else
            {
                radiouser.Checked = true;
            }
        }

        public void mimetodo()
        {
            user_lista = users.mostrarUsers();
            lista_offices = officesDAO.mostrarOffices();

            combooffice.DataSource = lista_offices;
            combooffice.DisplayMember = "Title";
            combooffice.ValueMember = "ID";
        }

        private void btnapply_Click(object sender, EventArgs e)
        {
            user.Firstname = txtfirstname.Text;
            user.Lastname = txtlastname.Text;
            user.Office = combooffice.SelectedItem.ToString();
            user.Email = emailOriginal;

            if (radiouser.Checked && !radioadmin.Checked)
            {
                roladmin = 2;
            }
            else if (radioadmin.Checked && !radiouser.Checked)
            {   
                roladmin = 1; 
            }
            else
            {
                MessageBox.Show("Selecciona un rol válido.",
                    "Aviso");
                return;
            }

            user.Role_id = roladmin;

            users.cambiar_rol(user, Sesion.EmailUsuarioActual);
            filtros filtros = new filtros();
            filtros.Show();
            this.Close();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            filtros filtros = new filtros();
            filtros.Show();
            this.Close();
        }
    }
}