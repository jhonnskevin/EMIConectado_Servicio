using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.UI.WebControls;

namespace EMIConectado_Servicio
{
    public class Comunicacion : IComunicacion
    {
        Logica logica = new Logica();

        #region no tocar
        public void HandleOptions()
        {
            WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Methods", "OPTIONS");
        }
        #endregion

        public Respuesta<Usuario> Login(string nombre, string contraseña)
        {
            var respuesta = new Respuesta<Usuario>();

            try
			{
                Usuario usuario = logica.AutenticarUsuario(nombre, contraseña);

                if (usuario != null)
                {
                    respuesta.StatusCode = 200;
                    respuesta.Mensaje = "Login exitoso";
                    respuesta.Datos = usuario;
                }
                else
                {
                    respuesta.StatusCode = 401; // Código de estado HTTP para no autorizado
                    respuesta.Mensaje = "Nombre de usuario o contraseña incorrectos";
                    respuesta.Datos = null;
                }
            }
			catch (Exception ex)
			{
                respuesta.StatusCode = 500;
                respuesta.Mensaje = $"Error interno del servidor: {ex.Message}";
                respuesta.Datos = null;
            }

            return respuesta;
        }
    }
}
