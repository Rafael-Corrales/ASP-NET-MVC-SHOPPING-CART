using Carrito_de_Compra.Data;
using Carrito_de_Compra.Models;
using CarroCompra1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Carrito_de_Compra.Repositories
{
    
    public class RepositoryCategoria
    {
        ContextData contexto = new ContextData();
        public List<Categoria> GetCategorias()
        {
            var consulta = contexto.Categoria.ToList();

            return consulta;
        }
        public Categoria GetCategoria(int id)
        {
            var consulta = contexto.Categoria.FirstOrDefault(s => s.IdCategoria == id);

            return consulta;
        }
        public Categoria CreateCategoria(Categoria miCategoria)
        {
            var categoria = new Categoria
            {
                NombreCategoria = miCategoria.NombreCategoria,
                Activo = true
            };
            contexto.Categoria.Add(categoria);
            contexto.SaveChanges();
            return categoria;
        }
        public Categoria EditCategoria(int id, Categoria miCategoria)
        {
            var categoria = contexto.Categoria.FirstOrDefault(s => s.IdCategoria == id);
            categoria.NombreCategoria = miCategoria.NombreCategoria;
            categoria.Activo = miCategoria.Activo;
            contexto.SaveChanges();
            return categoria;
        }
    }
}