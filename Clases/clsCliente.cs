using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using pApp_Serv_WEB.Modelos;

namespace pApp_Serv_WEB.Clases
{
    public class clsCliente
    {
        private DBClientesEntities dbClientes = new DBClientesEntities();
        public Cliente cliente { get; set; }
        public Cliente Consultar()
        {
            return dbClientes.Clientes.FirstOrDefault(x => x.Documento == cliente.Documento);
        }
        public string Eliminar()
        {
            Cliente _cliente = dbClientes.Clientes.FirstOrDefault(x => x.Documento == cliente.Documento);
            dbClientes.Clientes.Remove(_cliente);
            dbClientes.SaveChanges();
            return "Se eliminó el cliente en la base de datos";
        }
        public string Insertar()
        {
            //Agrega un objeto cliente a una lista de "Clientes"
            dbClientes.Clientes.Add(cliente);
            //Graba en la base de datos
            dbClientes.SaveChanges();
            return "Se insertó el cliente en la base de datos";
        }
        public string Actualizar()
        {
            //Se consulta el cliente, por la clave primaria (Documento)
            Cliente _cliente = dbClientes.Clientes.FirstOrDefault(x => x.Documento == cliente.Documento);
            _cliente.Nombre = cliente.Nombre;
            _cliente.PrimerApellido = cliente.PrimerApellido;
            _cliente.SegundoApellido = cliente.SegundoApellido;
            _cliente.FechaNacimiento = cliente.FechaNacimiento;
            _cliente.Direccion = cliente.Direccion;
            _cliente.Telefono = cliente.Telefono;
            _cliente.Usuario = cliente.Usuario;
            _cliente.Clave = cliente.Clave;

            dbClientes.SaveChanges();
            return "Se actualizó el cliente en la base de datos";
        }
    }
}