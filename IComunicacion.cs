using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EMIConectado_Servicio
{
    [ServiceContract]
    public interface IComunicacion
    {
        #region (NO TOCAR)
        [OperationContract]
        [WebInvoke(Method = "OPTIONS", UriTemplate = "*")]
        void HandleOptions();
        #endregion 

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/Login?nombre={nombre}&contraseña={contraseña}", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Respuesta<Usuario> Login(string nombre, string contraseña);
    }
}
