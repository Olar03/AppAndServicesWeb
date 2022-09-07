using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Utiliza el namespace de cliente
using pAplicacionesWEB.Modelos;
//using Libcomunes.capadatos, para procesar comandos en la base de datos
using libComunes.CapaDatos;

namespace pAplicacionesWEB.Clases
{
    //Esta clase es la que va a gestionar los métodos del modelo cliente
    public class clsCliente
    {
        //Recibe la propiedad de cliente
        public Cliente _cliente { get; set; }
        public bool Insertar()
        {
            //Método para grabar en la base de datos
            string SQL = "INSERT INTO tblCliente (Documento, Nombre, PrimerApellido, SegundoApellido, Direccion, Telefono, Email, FechaNacimiento) " +
                         "VALUES (@prDocumento, @prNombre, @prPrimerApellido, @prSegundoApellido, @prDireccion, @prTelefono, @prEmail, @prFechaNacimiento)";

            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prDocumento", _cliente.Documento);
            oConexion.AgregarParametro("@prNombre", _cliente.Nombre);
            oConexion.AgregarParametro("@prPrimerApellido", _cliente.PrimerApellido);
            oConexion.AgregarParametro("@prSegundoApellido", _cliente.SegundoApellido);
            oConexion.AgregarParametro("@prDireccion", _cliente.Direccion);
            oConexion.AgregarParametro("@prTelefono", _cliente.Telefono);
            oConexion.AgregarParametro("@prEmail", _cliente.Email);
            oConexion.AgregarParametro("@prFechaNacimiento", _cliente.FechaNacimiento);

            if (oConexion.EjecutarSentencia())
            {
                return true;
            }
            else
            {
                string Error = oConexion.Error;
                return false;
            }
        }
    }
}