using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
//Para manipular la información del json y pasarla a un formato de clase se utiliza la librería newtonsoft
using Newtonsoft.Json;
using pApp_Serv_WEB.Modelos;//Se requiere para utilizar la clase Cliente
using pApp_Serv_WEB.Clases;

namespace pApp_Serv_WEB.Controladores
{
    /// <summary>
    /// Summary description for ControladorCliente
    /// </summary>
    public class ControladorCliente : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //Recibe una información a través del objeto httpContext (context), y a partir de esa información,
            //el controlador define cuál o cuáles son los pasos para ejecutar el proceso requerido
            //Para capturar los datos del cliente, vamos a crear una variable tipo string
            string DatosCliente;
            //Capturamos el flujo de datos proveniente del cliente, se hace con un objeto denominado streamReader
            //El objeto StreamReader está en la librería System.IO
            StreamReader reader = new StreamReader(context.Request.InputStream);
            //Se asigna el flujo a la variable de datos cliente
            DatosCliente = reader.ReadToEnd();

            //Vamos a convertir los datos Cliente, que están como texto en un objeto Cliente
            //Se cambia el formato de tipo json, a un objeto (Clase de POO)
            Cliente cliente = JsonConvert.DeserializeObject<Cliente>(DatosCliente);

            //Con el objeto cliente, se procede a enviar la información para que sea procesada por una clase... 
            //Graba en base de datos, o hace una validación...

            //Entrega una respuesta al cliente que lo llama con el objeto Response
            //Response.Write, escribe la información en el cliente -browser-
            context.Response.ContentType = "text/plain";
            context.Response.Write(Procesar(cliente));
        }
        private string Procesar(Cliente cliente)
        {
            //Invocar la clase que hace el proceso en la base de datos
            clsCliente _cliente = new clsCliente();
            _cliente.cliente = cliente;
            
            switch(cliente.Comando.ToUpper())
            {
                case "INSERTAR":
                    return _cliente.Insertar();
                case "ACTUALIZAR":
                    return _cliente.Actualizar();
                case "ELIMINAR":
                    return _cliente.Eliminar();
                case "CONSULTAR":
                    return JsonConvert.SerializeObject(_cliente.Consultar());
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