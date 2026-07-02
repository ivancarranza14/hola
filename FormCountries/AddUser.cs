using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using claseLogica;
using Microsoft.VisualBasic.ApplicationServices;
using misclases;

namespace dbAmonic
{
    public partial class AddUser : Form
    {
        List<Offices> lista_offices;

        Users users = new Users();
        UsersDAO usersDAO = new UsersDAO();

        public AddUser()
        {
            InitializeComponent();
            CargarOffices();
        }


        private void CargarOffices()
        {
            OfficesDAO officesDAO = new OfficesDAO();
            lista_offices = officesDAO.mostrarOffices();

            comboOfficeUser.DataSource = lista_offices;
            comboOfficeUser.DisplayMember = "Title";
            comboOfficeUser.ValueMember = "ID";
        }


        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtName2.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }

            if (comboOfficeUser.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una oficina.",
                    "Error");
                return;
            }

            dateTimePickerAge.Format = DateTimePickerFormat.Custom;
            dateTimePickerAge.CustomFormat = "yyyy-MM-dd";

            try
            {
                users.Email = txtEmail.Text;
                users.Firstname = txtName.Text;
                users.Lastname = txtName2.Text;
                users.Office = ((Offices)comboOfficeUser.SelectedItem).Title;
                users.Birthdate = dateTimePickerAge.Value;
                users.password = UsersDAO.EncriptarMD5(txtPassword.Text);
                usersDAO.agregar_usuario(users);

                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al guardar el usuario: " + ex.Message,
                    "Error");
            }
            filtros filtros = new filtros();
            filtros.Show();
            this.Close();
        }


        private void LimpiarFormulario()
        {
            txtName.Clear();
            txtName2.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            dateTimePickerAge.Value = DateTime.Now;
            if (comboOfficeUser.Items.Count > 0)
                comboOfficeUser.SelectedIndex = 0;

            users = new Users();
        }

        private void dateTimePickerAge_ValueChanged(object sender, EventArgs e)
        {
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            filtros filtros = new filtros();
            filtros.Show();
            this.Close();
        }
    }
}