using Carrito_de_Compra.Data;
using Carrito_de_Compra.Models;
using CarroCompra1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Carrito_de_Compra.Repositories
{

    public class RepositorySubCategoria
    {
        ContextData contexto = new ContextData();
        public List<SubCategoria> GetSubCategorias()
        {
            var consulta = contexto.SubCategoria.ToList();

            return consulta;
        }
        public SubCategoria GetSubcategoria(int id)
        {
            var consulta = contexto.SubCategoria.FirstOrDefault(s => s.IdSubCategoria == id);

            return consulta;
        }
        public SubCategoria CreateSubcategoria(SubCategoria subCategoria)
        {
            var subcategoria = new SubCategoria
            {
                NombreSubCategoria = subCategoria.NombreSubCategoria,
                IdCategoria = subCategoria.IdCategoria,
                Activo = true
            };
            contexto.SubCategoria.Add(subCategoria);
            contexto.SaveChanges();
            return subCategoria;
        }

        public SubCategoria EditSubcategoria(int id, SubCategoria miSubCategoria)
        {
            var subcategoria = contexto.SubCategoria.FirstOrDefault(s => s.IdSubCategoria == id);
            subcategoria.NombreSubCategoria = miSubCategoria.NombreSubCategoria;
            subcategoria.IdCategoria = miSubCategoria.IdCategoria;
            subcategoria.Activo = miSubCategoria.Activo;
            contexto.SaveChanges();
            return subcategoria;
        }
    }
}