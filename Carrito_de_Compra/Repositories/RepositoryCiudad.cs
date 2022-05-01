using Carrito_de_Compra.Data;
using Carrito_de_Compra.Models;
using CarroCompra1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Carrito_de_Compra.Repositories
{

    public class RepositoryCiudad
    {
        ContextData contexto = new ContextData();
        public List<Ciudad> GetCiudads()
        {
            var consulta = contexto.Ciudad.ToList();

            return consulta;
        }
        public Ciudad GetCiudad(int id)
        {
            var consulta = contexto.Ciudad.FirstOrDefault(s => s.IdCiudad == id);

            return consulta;
        }
        public Ciudad CreateCiudad(Ciudad miCiudad)
        {
            var ciudad = new Ciudad
            {
                NombreCiudad = miCiudad.NombreCiudad,
                Activo = true
            };
            contexto.Ciudad.Add(ciudad);
            contexto.SaveChanges();
            return ciudad;
        }
        public Ciudad EditCiudad(int id, Ciudad miCiudad)
        {
            var ciudad = contexto.Ciudad.FirstOrDefault(s => s.IdCiudad == id);
            ciudad.NombreCiudad = miCiudad.NombreCiudad;
            ciudad.Activo = miCiudad.Activo;
            contexto.SaveChanges();
            return ciudad;
        }
    }
}