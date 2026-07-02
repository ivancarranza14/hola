using Microsoft.Data.SqlClient;
using misclases;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using claseLogica;
using System.Windows.Forms;
using System.IO;

namespace claseLogica
{
    public enum LoginResultado
    {
        Exito,
        CredencialesInvalidas,
        UsuarioInactivo,
        Error
    }

    public class UsersDAO : Conexion
    {
        Users users = new Users();

        private void LogError(Exception ex, string origen)
        {
            try
            {
                string carpetaLogs = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory, "Logs");

                if (!Directory.Exists(carpetaLogs))
                    Directory.CreateDirectory(carpetaLogs);

                string rutaArchivo = Path.Combine(carpetaLogs, "errores.log");

                string linea =
                    $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Origen: {origen}{Environment.NewLine}" +
                    $"{ex}{Environment.NewLine}" +
                    new string('-', 80) + Environment.NewLine;

                File.AppendAllText(rutaArchivo, linea);
            }
            catch
            {

            }
        }

        public static string EncriptarMD5(string texto)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] bytesEntrada = Encoding.UTF8.GetBytes(texto);
                byte[] bytesHash = md5.ComputeHash(bytesEntrada);

                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytesHash)
                    sb.Append(b.ToString("x2"));

                return sb.ToString();
            }
        }

        public List<Users> mostrarUsers()
        {
            List<Users> lista_users = new List<Users>();

            try
            {
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
                                    Firstname = verUsers["Firstname"].ToString(),
                                    Lastname = verUsers["Lastname"].ToString(),
                                    Birthdate = Convert.ToDateTime(verUsers["Birthdate"]),
                                    Active = Convert.ToBoolean(verUsers["Active"]),
                                };
                                lista_users.Add(users);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(mostrarUsers));
                MessageBox.Show(
                    "No se pudo cargar la lista de usuarios. Inténtalo de nuevo más tarde.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return lista_users;
        }

        public LoginResultado Login(string username, string password)
        {
            try
            {
                string passwordEncriptado = EncriptarMD5(password);

                using (SqlConnection conexion = obtenerConexion())
                {
                    conexion.Open();

                    string consultaCredenciales = @"SELECT active FROM Users 
                                         WHERE Email = @user 
                                         AND (Password = @passPlano OR Password = @passHash)";

                    using (SqlCommand comando = new SqlCommand(consultaCredenciales, conexion))
                    {
                        comando.Parameters.AddWithValue("@user", username);
                        comando.Parameters.AddWithValue("@passPlano", password);
                        comando.Parameters.AddWithValue("@passHash", passwordEncriptado);

                        object resultado = comando.ExecuteScalar();

                        if (resultado == null)
                        {

                            return LoginResultado.CredencialesInvalidas;
                        }

                        bool activo = Convert.ToBoolean(resultado);
                        return activo ? LoginResultado.Exito : LoginResultado.UsuarioInactivo;
                    }
                }
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(Login));
                MessageBox.Show(
                    "No se pudo iniciar sesión en este momento. Inténtalo de nuevo más tarde.",
                    "Error");
                return LoginResultado.Error;
            }
        }

        public bool EmailExiste(string email)
        {
            try
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
            catch (Exception ex)
            {
                LogError(ex, nameof(EmailExiste));
                MessageBox.Show(
                    "No se pudo verificar el correo. Inténtalo de nuevo más tarde.",
                    "Error");

                return true;
            }
        }

        // CORREGIDO: ya no se hardcodea Role_id=1 ni Office_ID=1.
        // Ahora se respeta lo que traiga el objeto 'usuario' (seteado desde el
        // formulario AddUser). Si vinieran en 0 o sin setear, se avisa en vez
        // de insertar datos incorrectos silenciosamente.
        public void agregar_usuario(Users usuario)
        {
            try
            {
                if (EmailExiste(usuario.Email))
                {
                    MessageBox.Show("Ya existe un usuario registrado con ese correo.",
                        "Correo duplicado");
                    return;
                }

                if (usuario.Role_id <= 0 || usuario.Office_ID <= 0)
                {
                    MessageBox.Show("Debes seleccionar un rol y una oficina válidos.",
                        "Datos incompletos");
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

                    using (SqlCommand command = new SqlCommand(consulta_agregar_usuario, conexion_usuario))
                    {
                        command.Parameters.AddWithValue("@Firstname", usuario.Firstname);
                        command.Parameters.AddWithValue("@Lastname", usuario.Lastname);
                        command.Parameters.AddWithValue("@Email", usuario.Email);
                        command.Parameters.AddWithValue("@Role_id", usuario.Role_id);
                        command.Parameters.AddWithValue("@Office_ID", usuario.Office_ID);
                        command.Parameters.AddWithValue("@Password", usuario.password);
                        command.Parameters.AddWithValue("@Birthdate", usuario.Birthdate.Date);
                        command.Parameters.AddWithValue("@Active", 1);

                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Usuario registrado exitosamente.",
                        "Éxito");
                }
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(agregar_usuario));
                MessageBox.Show(
                    "Ocurrió un problema al registrar el usuario. Por favor, inténtalo de nuevo o contacta al soporte.",
                    "Error");
            }
        }

        // CORREGIDO: se normaliza el texto del rol (mayúsculas/minúsculas y
        // espacios en blanco) para que la comparación no falle por diferencias
        // de formato entre lo que hay en la base de datos y el literal 'Administrator'.
        public bool EsAdministrador(string email)
        {
            try
            {
                using (SqlConnection conexion = obtenerConexion())
                {
                    conexion.Open();
                    string consulta = @"
                        SELECT COUNT(1)
                        FROM Users
                        JOIN Roles ON Users.Role_id = Roles.Role_id
                        WHERE UPPER(LTRIM(RTRIM(Users.Email))) = UPPER(LTRIM(RTRIM(@Email)))
                          AND UPPER(LTRIM(RTRIM(Roles.title))) = 'ADMINISTRATOR'
                          AND Users.active = 1";

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@Email", email ?? string.Empty);
                        int cuenta = (int)comando.ExecuteScalar();
                        return cuenta > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(EsAdministrador));

                return false;
            }
        }

        public void cambiar_rol(Users usuarioObjetivo, string emailQuienEjecuta)
        {
            try
            {
                if (!EsAdministrador(emailQuienEjecuta))
                {
                    MessageBox.Show("Solo un administrador puede cambiar roles de usuario.",
                        "Permiso denegado");
                    return;
                }

                using (SqlConnection conexion = obtenerConexion())
                {
                    conexion.Open();
                    string consulta_conexion = @"UPDATE Users
                                 SET Role_id = @Roladmin
                                 WHERE Email = @Email";
                    using (SqlCommand command = new SqlCommand(consulta_conexion, conexion))
                    {
                        command.Parameters.AddWithValue("@Roladmin", usuarioObjetivo.Role_id);
                        command.Parameters.AddWithValue("@Email", usuarioObjetivo.Email);
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Rol modificado exitosamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(cambiar_rol));
                MessageBox.Show(
                    "Ocurrió un problema al modificar el rol. Inténtalo de nuevo más tarde.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // CORREGIDO: ahora devuelve bool indicando si el cambio se aplicó,
        // para que la UI (filtros.cs) pueda decidir si recarga la grilla o no
        // en vez de asumir siempre que funcionó.
        public bool cambiar_estado(string emailObjetivo, bool nuevoEstado, string emailQuienEjecuta)
        {
            try
            {
                if (!EsAdministrador(emailQuienEjecuta))
                {
                    MessageBox.Show("Solo un administrador puede habilitar o deshabilitar usuarios.",
                        "Permiso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                using (SqlConnection conexion = obtenerConexion())
                {
                    conexion.Open();
                    string consulta = @"UPDATE Users
                                         SET Active = @Active
                                         WHERE UPPER(LTRIM(RTRIM(Email))) = UPPER(LTRIM(RTRIM(@Email)))";
                    using (SqlCommand command = new SqlCommand(consulta, conexion))
                    {
                        command.Parameters.AddWithValue("@Active", nuevoEstado);
                        command.Parameters.AddWithValue("@Email", emailObjetivo ?? string.Empty);
                        int filasAfectadas = command.ExecuteNonQuery();

                        if (filasAfectadas == 0)
                        {
                            MessageBox.Show("No se encontró el usuario a actualizar.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }

                    string mensaje = nuevoEstado
                        ? "Usuario habilitado exitosamente."
                        : "Usuario deshabilitado exitosamente.";

                    MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogError(ex, nameof(cambiar_estado));
                MessageBox.Show(
                    "Ocurrió un problema al cambiar el estado del usuario. Inténtalo de nuevo más tarde.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}