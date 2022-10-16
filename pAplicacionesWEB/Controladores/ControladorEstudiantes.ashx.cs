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

    public class ControladorEstudiantes : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                string DatosEstudiante;
                StreamReader reader = new StreamReader(context.Request.InputStream);
                DatosEstudiante = reader.ReadToEnd();

                Estudiante estudiante = JsonConvert.DeserializeObject<Estudiante>(DatosEstudiante);

                context.Response.Write(ProcesarComando(estudiante));
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }
        }
        private string ProcesarComando(Estudiante estudiante)
        {
            clsEstudiante oEstudiante = new clsEstudiante();
            oEstudiante.estudiante = estudiante;
            switch (estudiante.Comando.ToUpper())
            {
                case "INSERTAR":
                    return oEstudiante.Insertar();
                default:
                    return "No se ha definido el comando";
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