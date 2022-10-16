using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using pAplicacionesWEB.Modelos;
using libComunes.CapaDatos;

namespace pAplicacionesWEB.Clases
{
    public class clsLibros
    {

        public Libros libros { get; set; }
        public string Insertar()
        {

            string SQL = "Libros_Insertar";

            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.StoredProcedure = true;
            oConexion.AgregarParametro("@prCodigoEstudiante", libros.CodigoEstudiante);
            oConexion.AgregarParametro("@prNombre", libros.Nombre);
            oConexion.AgregarParametro("@prFechaPrestamo", libros.FechaPrestamo);
            oConexion.AgregarParametro("@   ", libros.FechaDevolucion);


            if (oConexion.EjecutarSentencia())
            {
                return "SE REGISTRO EL PRESTAMO EN LA BASE DE DATOS";
            }
            else
            {
                libros.Error = oConexion.Error;
                return libros.Error;
            }
        }

    }
}