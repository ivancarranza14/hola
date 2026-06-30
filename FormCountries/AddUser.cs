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

        public AddUser()
        {
            InitializeComponent();
            mimetodo();
        }

        public void mimetodo()
        {
            OfficesDAO officesDAO = new OfficesDAO();
            lista_offices = officesDAO.mostrarOffices();
            comboOfficeUser.DataSource = lista_offices;
            comboOfficeUser.DisplayMember = "Title";
            comboOfficeUser.ValueMember = "ID";
        }

        Users users = new Users();
        UsersDAO usersDAO = new UsersDAO();

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';

            string soloNumeros = "";
            foreach (char c in txtPassword.Text)
            {
                if (char.IsDigit(c))
                    soloNumeros += c;
            }

            if (soloNumeros != txtPassword.Text)
            {
                txtPassword.Text = soloNumeros;
                txtPassword.SelectionStart = txtPassword.Text.Length;
                MessageBox.Show("La contraseña solo puede contener números.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtName2.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtPassword.Text, out int passInt))
            {
                MessageBox.Show("La contraseña solo puede contener números.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dateTimePickerAge.Format = DateTimePickerFormat.Custom;
            dateTimePickerAge.CustomFormat = "yyyy-MM-dd";

            users.Email = txtEmail.Text;
            users.Firstname = txtName.Text;
            users.Lastname = txtName2.Text;
            users.Office = comboOfficeUser.SelectedItem.ToString();
            users.Birthdate = dateTimePickerAge.Value;
            users.password = passInt;
            usersDAO.agregar_usuario(users);
        }

        private void dateTimePickerAge_ValueChanged(object sender, EventArgs e)
        {
        }
    }
}