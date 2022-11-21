using MySql.Data.MySqlClient;
using IIParcialMySQL.Models;
using System.Data;

namespace IIParcialMySQL.DatabaseHelper
{
    public class DatabaseHelper
    {
        const string user = "root";
        const string password = "Admin$1234";
        const string servidor = @"localhost";
        const string port = "3306";
        const string baseDatos = "IIParcialDB";
        const string strConexion = $"server={servidor};Port={port};uid={user};pwd={password};database={baseDatos}";


        public static void InsertUser(Usuarios user)
        {
            List<MySqlParameter> paramList = new List<MySqlParameter>()
            {
                new MySqlParameter("Cedula", user.Cedula),
                new MySqlParameter("Nombre",user.Nombre),
                new MySqlParameter("Apellido",user.Apellido),
                new MySqlParameter("Telefono",user.Telefono),
                new MySqlParameter("Email",user.Email),
                new MySqlParameter("Password",user.Password)
            };

                ExecStoreProcedure("spRegistrarUsuario", paramList);
            }



        public static void ResetPassword(Usuarios user)
        {
            List<MySqlParameter> paramList = new List<MySqlParameter>()
                {
                    new MySqlParameter("pEmail",user.Email),
                    new MySqlParameter("pPassword",user.Password)
                };

            ExecStoreProcedure("spResetPassword", paramList);
        }

        //Para select 
        public static DataTable ExecuteStoreProcedure(string procedure, List<MySqlParameter> param)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(strConexion))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = procedure;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;

                    if (param != null)
                    {
                        foreach (MySqlParameter item in param)
                        {
                            cmd.Parameters.Add(item);
                        }
                    }

                    cmd.ExecuteNonQuery();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ExecStoreProcedure(string procedure, List<MySqlParameter> param)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(strConexion))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = procedure;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;

                    if (param != null)
                    {
                        foreach (MySqlParameter item in param)
                        {
                            cmd.Parameters.Add(item);
                        }
                    }

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
