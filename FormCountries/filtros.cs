using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            AplicarPermisosSegunRol();


            datamostrar.DataBindingComplete += datamostrar_DataBindingComplete;
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
                a.Office,
                a.Active
            }).ToList();
        }

        private void datamostrar_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (datamostrar.Columns["Active"] != null)
                datamostrar.Columns["Active"].Visible = false;

            foreach (DataGridViewRow fila in datamostrar.Rows)
            {
                if (fila.IsNewRow)
                    continue;

                bool activo = Convert.ToBoolean(fila.Cells["Active"].Value);
                string rol = fila.Cells["Role"].Value?.ToString() ?? "";

                Color colorFondo;

                if (!activo)
                {
                    colorFondo = Color.Red;
                }
                else if (rol.Equals("Administrator", StringComparison.OrdinalIgnoreCase))
                {
                    colorFondo = Color.LightGreen;
                }
                else
                {
                    colorFondo = Color.White;
                }

                fila.DefaultCellStyle.BackColor = colorFondo;
            }
        }

        private void AplicarPermisosSegunRol()
        {
            UsersDAO usersDAO = new UsersDAO();
            bool esAdmin = usersDAO.EsAdministrador(Sesion.EmailUsuarioActual);

            if (!esAdmin)
            {
                addUserToolStripMenuItem.Visible = false;
                btnchange.Visible = false;
                button2.Visible = false;
            }
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
                    a.Office,
                    a.Active
                }).ToList();
            }
            else
            {
                var oficinaSeleccionada = lista_offices.FirstOrDefault(o => o.ID == idOficina);
                string nombreOficina = oficinaSeleccionada?.Title ?? comboffice.Text;

                var filtrados = user_lista
                .Where(a => a.Office == nombreOficina)
                .Select(a => new
                {
                    a.Firstname,
                    a.Lastname,
                    a.Edad,
                    a.Role,
                    a.Email,
                    a.Office,
                    a.Active
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
            if (datamostrar.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un usuario primero.",
                    "Aviso");
                return;
            }

            string emailSeleccionado = datamostrar.CurrentRow.Cells["Email"].Value.ToString();
            Users usuarioSeleccionado = user_lista.FirstOrDefault(u => u.Email == emailSeleccionado);

            if (usuarioSeleccionado == null)
            {
                MessageBox.Show("No se encontró el usuario seleccionado.",
                    "Error");
                return;
            }

            change_roles change_Roles = new change_roles(usuarioSeleccionado);
            change_Roles.Show();
            this.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
           
            if (datamostrar.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un usuario primero.",
                    "Aviso");
                return;
            }

            string emailSeleccionado = datamostrar.CurrentRow.Cells["Email"].Value.ToString();
            Users usuarioSeleccionado = user_lista.FirstOrDefault(u => u.Email == emailSeleccionado);
            /*linda prueba */
            if (usuarioSeleccionado.Email.Equals(Sesion.EmailUsuarioActual, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(
                    "No puedes desabilitarte como administrador.");
                return;
            }
            if (usuarioSeleccionado == null)
            {
                MessageBox.Show("No se encontró el usuario seleccionado.",
                    "Error");
                return;
            }
            
            bool nuevoEstado = !usuarioSeleccionado.Active;

            string accion = nuevoEstado ? "habilitar" : "deshabilitar";
            DialogResult confirmacion = MessageBox.Show(
                $"¿Seguro que quieres {accion} el login de {usuarioSeleccionado.Email}?",
                "Confirmar");

            if (confirmacion != DialogResult.Yes)
            {
                UsersDAO usersDAO = new UsersDAO();
                bool exito = usersDAO.cambiar_estado(usuarioSeleccionado.Email, nuevoEstado, Sesion.EmailUsuarioActual);

                if (exito)
                {
                    mimetodo();

                }
            }
            return;
        }
    }
}
