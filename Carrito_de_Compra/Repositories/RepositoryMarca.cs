using Carrito_de_Compra.Data;
using Carrito_de_Compra.Models;
using CarroCompra1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Carrito_de_Compra.Repositories
{

    public class RepositoryMarca
    {
        ContextData contexto = new ContextData();
        public List<Marca> GetMarcas()
        {
            var consulta = contexto.Marca.ToList();

            return consulta;
        }
        public Marca GetMarca(int id)
        {
            var consulta = contexto.Marca.FirstOrDefault(s => s.IdMarca == id);

            return consulta;
        }
        public Marca CreateMarca(Marca miMarca)
        {
            var marca = new Marca
            {
                NombreMarca = miMarca.NombreMarca,
                Activo = true
            };
            contexto.Marca.Add(marca);
            contexto.SaveChanges();
            return marca;
        }
        public Marca EditMarca(int id, Marca miMarca)
        {
            var marca = contexto.Marca.FirstOrDefault(s => s.IdMarca == id);
            marca.NombreMarca = miMarca.NombreMarca;
            marca.Activo = miMarca.Activo;
            contexto.SaveChanges();
            return marca;
        }
    }
}