using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using pAplicacionesWEB.Modelos;
using libComunes.CapaDatos;

namespace pAplicacionesWEB.Clases
{
    public class clsEstudiante
    {
        public Estudiante estudiante { get; set; }
        public string Insertar()
        {
            //Invocar el método insertar
            //Método para grabar en la base de datos
            string SQL = "Estudiante_Ingresar"; //Nombre del procedimiento almacenado

            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.StoredProcedure = true;//Para indicar que es un procedimiento almacenado
            oConexion.AgregarParametro("@prDocumento", estudiante.Documento);
            oConexion.AgregarParametro("@prNombre", estudiante.Nombre);
            oConexion.AgregarParametro("@prApellidos", estudiante.Apellidos);
            oConexion.AgregarParametro("@prTelefono", estudiante.Telefono);
            oConexion.AgregarParametro("@prEmail", estudiante.Email);


            if (oConexion.EjecutarSentencia())
            {
                return "Se insertó el estudiante en la base de datos";
            }
            else
            {
                estudiante.Error = oConexion.Error;
                return estudiante.Error;
            }
        }

    }
}