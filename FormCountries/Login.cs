using claseLogica;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using dbAmonic;

namespace FormCountries
{
    public partial class Login : Form
    {
        int tiempo = 10;
        int contador = 0;
        public Login()
        {
            InitializeComponent();
            timer1.Interval = 1000;
        }
        User usuario = new User();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            UsersDAO usuario = new UsersDAO();

            bool Ingresar = usuario.Login(

                txtUser.Text,
                txtPassword.Text
            );
            if (Ingresar)
            {
                MessageBox.Show("Bienvenido");
                Visible = false;
                filtros filtros = new filtros();
                filtros.Visible = true;
            }
            else
            {
                contador++;
                if (contador >= 3)
                {
                    tiempo = 10;
                    lblTiempo.Visible = true;
                    lblTiempo.Text = "Espere " + tiempo + " " + "Segundos";
                    timer1.Start();
                    btnLogin.Enabled = false;
                 
                }
                MessageBox.Show("Usuario o contrasena incorrecta");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tiempo--;
            lblTiempo.Text = "Espere " + tiempo + " " + "Segundos";
            if ( tiempo <= 0)
            {
                timer1.Stop();
                btnLogin.Enabled = true;
                lblTiempo.Text = "";
                lblTiempo.Visible = false;
                contador = 0;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
        }
    }
}
