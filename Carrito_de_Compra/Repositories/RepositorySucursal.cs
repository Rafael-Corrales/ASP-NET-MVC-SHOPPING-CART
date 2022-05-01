using Carrito_de_Compra.Data;
using Carrito_de_Compra.Models;
using CarroCompra1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Carrito_de_Compra.Repositories
{

    public class RepositorySucursal
    {
        ContextData contexto = new ContextData();
        public List<Sucursal> GetSucursals()
        {
            var consulta = contexto.Sucursal.ToList();

            return consulta;
        }
        public Sucursal GetSucursal(int id)
        {
            var consulta = contexto.Sucursal.FirstOrDefault(s => s.IdSucursal == id);

            return consulta;
        }
        public Sucursal CreateSucursal(Sucursal sucursal)
        {
            var misucursal = new Sucursal
            {
                NombreSucursal = sucursal.NombreSucursal,
                NombreDireccion = sucursal.NombreDireccion,
                IdCiudad = sucursal.IdCiudad,
                Activo = true
            };
            contexto.Sucursal.Add(misucursal);
            contexto.SaveChanges();
            return sucursal;
        }

        public Sucursal EditSucursal(int id, Sucursal miSucursal)
        {
            var sucursal = contexto.Sucursal.FirstOrDefault(s => s.IdSucursal == id);
            sucursal.NombreSucursal = miSucursal.NombreSucursal;
            sucursal.NombreDireccion = miSucursal.NombreDireccion;
            sucursal.IdCiudad = miSucursal.IdCiudad;
            sucursal.Activo = miSucursal.Activo;
            contexto.SaveChanges();
            return sucursal;
        }
    }
}