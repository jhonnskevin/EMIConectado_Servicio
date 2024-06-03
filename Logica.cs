using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace EMIConectado_Servicio
{
    public class Logica
    {

        #region Configuracion Conexion SQL
        private string connectionString;

        public Logica()
        {
            string servidor = ObtenerConfiguracion("servidor");
            string usuario = ObtenerConfiguracion("usuario");
            string contraseña = ObtenerConfiguracion("contraseña");
            string base_datos = ObtenerConfiguracion("base_datos");

            connectionString = $"Server={servidor};Database={base_datos};User Id={usuario};Password={contraseña};";
        }
        private string ObtenerConfiguracion(string key)
        {
            string value = WebConfigurationManager.AppSettings[key];
            if (string.IsNullOrEmpty(value))
            {
                throw new ConfigurationErrorsException($"La configuración \"{key}\" no se ha encontrado o está vacía.");
            }
            return value;
        }
        #endregion

        public Usuario AutenticarUsuario(string nombre, string contraseña)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string query = "Select * from usuario where nombre = @nombre and contraseña = @contraseña";
                return db.QueryFirstOrDefault<Usuario>(query, new { nombre = nombre, contraseña = contraseña });
            }
        }
    }
}