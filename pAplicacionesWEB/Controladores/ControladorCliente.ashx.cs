using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Agregar en el using, system.io para procesar el flujo de información que llega del cliente
using System.IO;
//Agregar en el using, la carpeta de modelos
using pAplicacionesWEB.Modelos;
//Agregar using Newtonsoft.Json: Procesar la información
using Newtonsoft.Json;

namespace pAplicacionesWEB.Controladores
{
    /// <summary>
    /// Summary description for ControladorCliente
    /// </summary>
    public class ControladorCliente : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                string DatosCliente;
                StreamReader reader = new StreamReader(context.Request.InputStream);
                DatosCliente = reader.ReadToEnd();
                //La información que se pasa desde el cliente html, llega en el inputstream y se guarda como texto (string) en la variable datos cliente
                //Vamos a convertir el texto que está en la variable DatosCliente, a una clase: del modelo Cliente
                //Se hace con las clases de Newtonsoft, utilizar la clase jsonconvert
                Cliente _Cliente = JsonConvert.DeserializeObject<Cliente>(DatosCliente);

                context.Response.Write("Buenas noches: " + _Cliente.Nombre + " " + _Cliente.PrimerApellido + " " + _Cliente.SegundoApellido);
            }
            catch(Exception ex)
            {
                context.Response.Write(ex.Message);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}