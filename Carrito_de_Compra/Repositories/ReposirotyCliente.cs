using Carrito_de_Compra.Data;
using Carrito_de_Compra.Models;
using CarroCompra1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Carrito_de_Compra.Repositories
{

    public class RepositoryCliente
    {
        ContextData contexto = new ContextData();
        public List<Cliente> GetClientes()
        {
            var consulta = contexto.Cliente.ToList();

            return consulta;
        }
        public Cliente GetCliente(int id)
        {
            var consulta = contexto.Cliente.FirstOrDefault(s => s.IdCliente == id);

            return consulta;
        }

        public Cliente GetClienteByEmail(string email)
        {
            var consulta = contexto.Cliente.FirstOrDefault(s => s.Correo == email);

            return consulta;
        }
        public Cliente CreateCliente(Cliente cliente)
        {
            var miCliente = new Cliente
            {
                Nombre = cliente.Nombre,
                Apellidos = cliente.Apellidos,
                Direccion = cliente.Direccion,
                Telefono = cliente.Telefono,
            };
            contexto.Cliente.Add(miCliente);
            contexto.SaveChanges();
            return miCliente;
        }

        public Cliente EditCliente(int id, Cliente miCliente)
        { 
            var cliente= contexto.Cliente.FirstOrDefault(s => s.IdCliente == id);
            cliente.Nombre = miCliente.Nombre;
            cliente.Apellidos = miCliente.Apellidos;
            cliente.Direccion= miCliente.Direccion;
            cliente.Telefono= miCliente.Telefono;
            cliente.Correo = miCliente.Correo;
            contexto.SaveChanges();
            return cliente;
        }
    }
}