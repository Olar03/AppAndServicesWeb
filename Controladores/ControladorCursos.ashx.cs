using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using pApp_Serv_WEB.Modelos;
using pApp_Serv_WEB.Clases;
using Newtonsoft.Json;

namespace pApp_Serv_WEB.Controladores
{
    /// <summary>
    /// Descripción breve de ControladorCursos
    /// </summary>
    public class ControladorCursos : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string Datos;
            StreamReader reader = new StreamReader(context.Request.InputStream);
            Datos = reader.ReadToEnd();

            CursosVacacionales cursos = JsonConvert.DeserializeObject<CursosVacacionales>(Datos);
            context.Response.ContentType = "text/plain";
            context.Response.Write(Procesar(cursos));
        }
        private string Procesar(CursosVacacionales cursos)
        {
            //Invocar la clase que hace el proceso en la base de datos
            clsCursos _cursos = new clsCursos();
            _cursos.cursos = cursos;

            switch (cursos.Comando.ToUpper())
            {
                case "INSERTAR":
                    return _cursos.Insertar();
                case "ACTUALIZAR":
                    return _cursos.Actualizar();
                case "ELIMINAR":
                    return _cursos.Eliminar();
                case "CONSULTAR":
                    return JsonConvert.SerializeObject(_cursos.Consultar());
                default:
                    return "Comando sin definir";
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