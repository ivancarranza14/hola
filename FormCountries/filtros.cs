using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using claseLogica;
using FormCountries;
using Microsoft.VisualBasic.ApplicationServices;
using misclases;

namespace dbAmonic
{
    public partial class filtros : Form
    {
        List<Users> user_lista;
        List<Offices> lista_offices;

        public filtros()
        {
            InitializeComponent();
            mimetodo();
        }

        public void mimetodo()
        {
            UsersDAO users = new UsersDAO();
            OfficesDAO officesDAO = new OfficesDAO();

            user_lista = users.mostrarUsers();
            lista_offices = officesDAO.mostrarOffices();

            lista_offices.Insert(0, new Offices
            {
                ID = 0,
                Title = "All offices"
            });

            comboffice.DataSource = lista_offices;
            comboffice.DisplayMember = "Title";
            comboffice.ValueMember = "ID";

            datamostrar.DataSource = user_lista.Select(a => new
            {
                a.Firstname,
                a.Lastname,
                a.Birthdate,
                a.Role,
                a.Email,
                a.Office
            }).ToList();
        }

        private void comboffice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboffice.SelectedValue == null)
                return;

            int idOficina;

            if (!int.TryParse(comboffice.SelectedValue.ToString(), out idOficina))
                return;

            if (idOficina == 0)
            {
                datamostrar.DataSource = user_lista.Select(a => new
                {
                    a.Firstname,
                    a.Lastname,
                    a.Birthdate,
                    a.Role,
                    a.Email,
                    a.Office
                }).ToList();
            }
            else
            {
                var filtrados = user_lista
                .Where(a => a.Office == comboffice.Text)
                .Select(a => new
                {
                    a.Firstname,
                    a.Lastname,
                    a.Birthdate,
                    a.Role,
                    a.Email,
                    a.Office
                })
                .ToList();

                datamostrar.DataSource = filtrados;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUser addUser = new AddUser();
            addUser.Show();
            this.Close();
        }

        private void btnchange_Click(object sender, EventArgs e)
        {
            change_roles change_Roles = new change_roles();
            change_Roles.Show();
            this.Close();
        }
    }
}