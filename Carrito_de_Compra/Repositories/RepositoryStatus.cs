using Carrito_de_Compra.Data;
using Carrito_de_Compra.Models;
using CarroCompra1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Carrito_de_Compra.Repositories
{

    public class RepositoryStatus
    {
        ContextData contexto = new ContextData();
        public List<Status> GetStatuses()
        {
            var consulta = contexto.Status.ToList();

            return consulta;
        }
    }
}