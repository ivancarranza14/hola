using Microsoft.Data.SqlClient;
using misclases;
using System;
using System.Collections.Generic;
using System.Text;
using claseLogica;
using System.Windows.Forms;

namespace claseLogica
{
    public class UsersDAO : Conexion
    {
        Users users = new Users();

        public List<Users> mostrarUsers()
        {
            List<Users> lista_users = new List<Users>();

            using (SqlConnection conexionUser = obtenerConexion())
            {
                conexionUser.Open();
                string consulta = @"SELECT 
                    Users.User_id,
                    Offices.Title AS Office,
                    Roles.title AS Role,
                    Users.Email,
                    Users.Firstname,
                    Users.Lastname,
                    Users.Password,
                    Users.Birthdate,
                    Users.Active
                FROM Users
                JOIN Offices ON Users.Office_id = Offices.ID
                JOIN Roles ON Users.Role_id = Roles.Role_id";

                using (SqlCommand comandoUser = new SqlCommand(consulta, conexionUser))
                {
                    comandoUser.CommandType = System.Data.CommandType.Text;
                    using (SqlDataReader verUsers = comandoUser.ExecuteReader())
                    {
                        while (verUsers.Read())
                        {
                            Users users = new Users()
                            {
                                User_id = Convert.ToInt32(verUsers["User_id"]),
                                Office = verUsers["Office"].ToString(),
                                Role = verUsers["Role"].ToString(),
                                Email = verUsers["Email"].ToString(),
                                password = Convert.ToInt32(verUsers["Password"]),
                                Firstname = verUsers["Firstname"].ToString(),
                                Lastname = verUsers["Lastname"].ToString(),
                                Birthdate = Convert.ToDateTime(verUsers["Birthdate"]),
                                Active = Convert.ToBoolean(verUsers["active"]),
                            };
                            lista_users.Add(users);
                        }
                    }
                }
            }
            return lista_users;
        }

        public bool Login(string username, string password)
        {
            using (SqlConnection conexion = obtenerConexion())
            {
                conexion.Open();
                string consulta = "SELECT COUNT(1) FROM Users WHERE Email = @user AND Password = @pass AND active = 1";
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@user", username);

                    if (int.TryParse(password, out int passInt))
                        comando.Parameters.AddWithValue("@pass", passInt);
                    else
                        comando.Parameters.AddWithValue("@pass", password);

                    int cuenta = (int)comando.ExecuteScalar();
                    return cuenta > 0;
                }
            }
        }
        public bool EmailExiste(string email)
        {
            using (SqlConnection conexion = obtenerConexion())
            {
                conexion.Open();
                string consulta = "SELECT COUNT(1) FROM Users WHERE Email = @Email";
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@Email", email);
                    int cuenta = (int)comando.ExecuteScalar();
                    return cuenta > 0;
                }
            }
        }

        public bool PasswordExiste(int password)
        {
            using (SqlConnection conexion = obtenerConexion())
            {
                conexion.Open();
                string consulta = "SELECT COUNT(1) FROM Users WHERE Password = @Password";
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@Password", password);
                    int cuenta = (int)comando.ExecuteScalar();
                    return cuenta > 0;
                }
            }
        }

        public void agregar_usuario(Users usuario)
        {
            try
            {
                if (EmailExiste(usuario.Email))
                {
                    MessageBox.Show("Ya existe un usuario registrado con ese correo.",
                        "Correo duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (PasswordExiste(usuario.password))
                {
                    MessageBox.Show("Esa contraseña ya está en uso. Elige una diferente.",
                        "Contraseña duplicada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection conexion_usuario = obtenerConexion())
                {
                    conexion_usuario.Open();

                    string consulta_agregar_usuario = @"
                        INSERT INTO Users
                        (
                            Firstname,
                            Lastname,
                            Email,
                            Role_id,
                            Password,
                            Birthdate,
                            Office_ID,
                            Active        
                        )
                        VALUES
                        (
                            @Firstname,
                            @Lastname,
                            @Email,
                            @Role_id,
                            @Password,
                            @Birthdate,
                            @Office_ID,
                            @Active       
                        )";

                    SqlCommand command = new SqlCommand(consulta_agregar_usuario, conexion_usuario);

                    command.Parameters.AddWithValue("@Firstname", usuario.Firstname);
                    command.Parameters.AddWithValue("@Lastname", usuario.Lastname);
                    command.Parameters.AddWithValue("@Email", usuario.Email);
                    command.Parameters.AddWithValue("@Role_id", 1);
                    command.Parameters.AddWithValue("@Office_ID", 1);
                    command.Parameters.AddWithValue("@Password", usuario.password);
                    command.Parameters.AddWithValue("@Birthdate", usuario.Birthdate.Date);
                    command.Parameters.AddWithValue("@Active", 1); // ✅ Active = 1 por defecto

                    command.ExecuteNonQuery();

                    MessageBox.Show("Usuario registrado exitosamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void cambiar_rol(Users users)
        {
           
            using (SqlConnection conexion = obtenerConexion())
            {
                conexion.Open();
                string consulta_conexion = " @\"UPDATE Users\r\nSET Role_id = @Roladmin\r\nHERE Email = @Email\";";
                SqlCommand command=new SqlCommand(consulta_conexion, conexion);
                command.Parameters.AddWithValue("@roladmin", users.Role_id);
                command.Parameters.AddWithValue("@email", users.Email);
                command.ExecuteNonQuery();
                MessageBox.Show("rol modificado exitosamente");
            }


        }

    }
}