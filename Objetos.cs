using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace EMIConectado_Servicio
{
    [DataContract]

    public class Respuesta<T>
    {
        [DataMember]
        public int StatusCode { get; set; }
        [DataMember]
        public string Mensaje { get; set; }
        [DataMember]
        public T Datos { get; set; }
    }

    public class Usuario
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string nombre { get; set; }
    }
}