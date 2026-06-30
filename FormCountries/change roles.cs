using claseLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;

namespace dbAmonic
{
    public partial class change_roles : Form
    {
        public change_roles()
        {
            InitializeComponent();
            mimetodo();
        }
        int roladmin;
        List<Users> user_lista;
        List<Offices> lista_offices;
        UsersDAO users = new UsersDAO();
        OfficesDAO officesDAO = new OfficesDAO();
        Users user = new Users();
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
            string email = txtemail.Text;
            string first_name = txtfirstname.Text;
            string last_name = txtlastname.Text;
            string office = combooffice.SelectedItem.ToString();

            if (radiouser.Checked && !radioadmin.Checked)
            {
                roladmin = 1;
            }
            else if (radioadmin.Checked && !radiouser.Checked)
            {

                roladmin = 2;

            }
            else
            {
                MessageBox.Show("checkeo invalido");
            }


            users.cambiar_rol(user);

        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            filtros filtros = new filtros();
            filtros.Show();
            this.Close();

        }
    }
}
