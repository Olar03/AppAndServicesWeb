using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using pApp_Serv_WEB.Modelos;

namespace pApp_Serv_WEB.Clases
{
    public class clsCursos
    {
        private DBCursosEntities dbCursos = new DBCursosEntities();
        public CursosVacacionales cursos { get; set; }
        private void CalcularPago()
        {
            clsPagoCursos pago = new clsPagoCursos();
            pago.curso = cursos;
            pago.CalcularPago();
            cursos = pago.curso;
        }
        public string Insertar()
        {
            CalcularPago();
            dbCursos.CursosVacacionales.Add(cursos);
            dbCursos.SaveChanges();
            return "Se insertó el curso en la base de datos";
        }
        public string Actualizar()
        {
            CalcularPago();
            CursosVacacionales _cursos = dbCursos.CursosVacacionales.FirstOrDefault(x => x.Documento == cursos.Documento);
            _cursos.NombreDocente = cursos.NombreDocente;
            _cursos.CantidadCursos = cursos.CantidadCursos;
            _cursos.ValorPagoAntesDcto = cursos.ValorPagoAntesDcto;
            _cursos.ValorDescuento = cursos.ValorDescuento;
            _cursos.PorcentajeDescuento = cursos.PorcentajeDescuento;
            _cursos.TotalPagar = cursos.TotalPagar;
            dbCursos.SaveChanges();
            return "Se actualizó el curso en la base de datos";
        }
        public string Eliminar()
        {
            CursosVacacionales _cursos = dbCursos.CursosVacacionales.FirstOrDefault(x => x.Documento == cursos.Documento);
            dbCursos.CursosVacacionales.Remove(_cursos);
            dbCursos.SaveChanges();
            return "Se eliminó el curso en la base de datos";
        }
        public CursosVacacionales Consultar()
        {
            return dbCursos.CursosVacacionales.FirstOrDefault(x => x.Documento == cursos.Documento);
        }
    }
}