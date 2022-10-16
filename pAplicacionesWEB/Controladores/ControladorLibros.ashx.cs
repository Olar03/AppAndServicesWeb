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
using pAplicacionesWEB.Clases;

namespace pAplicacionesWEB.Controladores
{

    public class ControladorLibros : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                string DatosLibros;
                StreamReader reader = new StreamReader(context.Request.InputStream);
                DatosLibros = reader.ReadToEnd();

                Libros libros = JsonConvert.DeserializeObject<Libros>(DatosLibros);

                context.Response.Write(ProcesarComando(libros));
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }
        }


        private string ProcesarComando(Libros libros)
        {
            clsLibros oLibros = new clsLibros();
            oLibros.libros = libros;
            switch (libros.Comando.ToUpper())
            {
                case "INSERTAR":
                    return oLibros.Insertar();

                default:
                    return "NO SE HA DEFINIDO EL COMNADO";
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