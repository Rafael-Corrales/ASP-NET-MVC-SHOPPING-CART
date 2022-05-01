using Carrito_de_Compra.Data;
using Carrito_de_Compra.Models;
using CarroCompra1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarroCompra1.Repositories
{
    public class RepositoryArticulo
    {
        // Se declara el contexto donde estan las tablas de la base de datos
        ContextData contexto = new ContextData();

        // El metodo de obtener la lista de articulos
        public List<Articulo> GetArticulos(string Buscar)
        {
            // Se obtiene una lista de cadena de caracteres
            List<String> listStrLineElements;
            // Si no hay nada en el buscador
            if (Buscar == null)
            {
                // Se obtiene la lista de articulo de que estan activos
                var consulta = contexto.Articulo.Where(s => s.Activo).ToList();
                // Se returna el valor de la consulta
                return consulta;
            }
            else
            {
                // Si no hay nada en el buscador
                if(Buscar == "")
                {
                    // Se obtiene la lista de articulo de que estan activos
                    var consulta = contexto.Articulo.Where(s => s.Activo).ToList();
                    // Se returna el valor de la consulta
                    return consulta;
                }
                else
                {
                    // Se divide en pedazos lo que se escrbio en el buscador
                    listStrLineElements = Buscar.Split(' ').ToList();
                    // Se agrega a la consulta lo que escribio en el buscador que coincide en el Nombre Articulo
                    var consulta = contexto.Articulo.Where(s => s.Activo && listStrLineElements.Any(sl => s.NombreArticulo.Contains(sl))).ToList();
                    // Se returna el valor de la consulta
                    return consulta;
                }
            }


            
        }
        // El metodo para llamar el Articulo x ID
        public Articulo ArticuloXID(int id)
        {
            // Se hace la consulta de obtener un Articulo por el Id que se le pasa por parametro
            var consulta = from datos in contexto.Articulo
                           where datos.IdArticulo == id
                           select datos;
            // Se obtiene el primer registro de la lista
            return consulta.FirstOrDefault();
        }
        // El metodo para crear un articulo
        public Articulo CreateArticulo(Articulo articulo)
        {
            // Se crea una variable de TIPO ARTICULO (DE LA BASE DE DATOS)
            var miarticulo = new Articulo
            {
                NombreArticulo = articulo.NombreArticulo,
                Descripcion = articulo.Descripcion,
                Stock = articulo.Stock,
                Caracteristicas = articulo.Caracteristicas,
                IdMarca = articulo.IdMarca,
                IdSubCategoria = articulo.IdSubCategoria,
                StockMinimo = articulo.StockMinimo,
                Activo = true,
                Precio = articulo.Precio
            };

            // Se agrega el articulo a la tabla de articulos
            contexto.Articulo.Add(miarticulo);
            // Se guardan los cambios
            contexto.SaveChanges();
            return articulo;
        }
        // El metodo para editar un articulo
        public Articulo EditArticulo(int id, Articulo miArticulo)
        {
            // Se obtiene el articulo por el ID que se le pasa de parametro
            var articulo = contexto.Articulo.FirstOrDefault(s => s.IdArticulo == id);
            // Se establece el Nombre del articulo del articulo por el nuevo Nombre de Articulo establecido
            articulo.NombreArticulo = miArticulo.NombreArticulo;
            // Se establece la Descripcion del articulo por el nuevo Descripcion de Articulo establecido
            articulo.Descripcion = miArticulo.Descripcion;
            // Se establece la Stock del articulo por el nuevo del Stock del Articulo establecido
            articulo.Stock = miArticulo.Stock;
            // Se establece las Caracteristicas del articulo por las nuevas caracteristicas del Articulo establecido
            articulo.Caracteristicas = miArticulo.Caracteristicas;
            // Se establece el IdMarca del articulo por el nuevo IdMarca del Articulo establecido
            articulo.IdMarca = miArticulo.IdMarca;
            // Se establece el IdSubcategoria del articulo por el nuevo IdSubcategoria del Articulo establecido
            articulo.IdSubCategoria = miArticulo.IdSubCategoria;
            // Se establece el StockMinimo del articulo por el nuevo Stockminimo del articulo establecido
            articulo.StockMinimo = miArticulo.StockMinimo; 
            // Se establece el campo Activo del articulo por el nuevo campo Activo del articulo establecido
            articulo.Activo = miArticulo.Activo;
            // Se establece el campo Precio del articulo por el nuevo Precio del articulo establecido
            articulo.Precio = miArticulo.Precio;
            // Se guardan los cambios
            contexto.SaveChanges();
            // Se returna el articulo con los campos nuevos establecidos
            return articulo;
        }
        // El metodo donde se cambia la URL del articulo
        public Articulo ImageArticulo(int id, string url)
        {
            // Se obtiene el articulo al que se va a cambiar la URL de Imagn
            var articulo = contexto.Articulo.FirstOrDefault(s => s.IdArticulo == id);
            // Se establece la URLImagen por la nueva URL del articulo establecido
            articulo.UrlImagen = url;
            // Se guardan los cambios
            contexto.SaveChanges();
            // Se returna el articulo con los campos nuevos establecidos
            return articulo;
        }
        // El metodo donde se agrega la URL del 
        public Articulo AddArticuloToCart(int IdArticulo, string usuario, int cantidad)
        {
            // Se obtiene el articulo a agregar al carrito
            var miarticu = this.ArticuloXID(IdArticulo);
            // Se obiene el pedido del usuario
            var consulta = (from datos in contexto.Pedido
                            where datos.IdUsuario == usuario && datos.IdStatus == 1
                            select datos).OrderByDescending(s => s.IdPedido);
            // Se revisa si hay stock de ese articulo
            if (miarticu.Stock > 0)
            {
                // Si hay articulos en Stock, se crea el detalle del pedido con el articulo adicionado
                var detalle = new DetallePedido
                {
                    IdPedido = consulta.FirstOrDefault().IdPedido,
                    IdArticulo = IdArticulo,
                    Cantidad = cantidad,
                    // Se mutiplica la cantidad solicitada * el precio del articulo
                    Subtotal = (miarticu.Precio * cantidad)
                };
                // Se agrega el articulo al detalle del pedido
                contexto.DetallePedido.Add(detalle);
                // Se guardan los cambios realizados
                contexto.SaveChanges();
            }
            // Se obtiene el pedido
            var pedido = consulta.FirstOrDefault();
            // Se obtienen el detalle del pedido seleccionado
            var detallespedido = (from datos in contexto.DetallePedido
                                  where datos.IdPedido == pedido.IdPedido
                                  select datos);
            // Setear el isv el 15%
            decimal isv = (decimal)1.15;
            decimal isv15 = (decimal)0.15;
            // Se establece el subtotal, sumando el subtotal del detalle del pedido
            pedido.SubTotal = detallespedido.Sum(x => x.Subtotal);
            // Se multiplica la suma del subtotal del detalle del pedido * el 15%
            pedido.Impuesto = detallespedido.Sum(x => x.Subtotal) * isv15;
            // Se multiplca la suma del subtotal del detalle del pedido * el 115%
            pedido.Total = detallespedido.Sum(x => x.Subtotal) * isv;
            // Se guardan los cambios
            contexto.SaveChanges();
            // Se retorna el articulo
            return miarticu;
        }

        // Metodo donde se crea el Pedido
        public long CreatePedidoAndGetId(string usuario)
        {
            // Se hace la consulta donde se obtiene el Pedido del usuario
            var consulta1 = (from datos in contexto.Pedido
                            where datos.IdUsuario == usuario && datos.IdStatus == 1
                            select datos).OrderByDescending(s => s.IdPedido).ToList();
            // Se hace obtiene el primer registro de la consulta
            var pedido = consulta1.FirstOrDefault();
            // Si hay mas de un pedido
            if(consulta1.Count > 0)
            {
                // Se obtiene el Id del pedido existente
                return pedido.IdPedido;
            }
            // Si no hay ningun pedido creado para el usuario
            else
            {
                // Se crea el pedido
                var miPedido = new Pedido
                {
                    IdStatus = 1,
                    //     IdUsuario = usuario,
                    IdUsuario = usuario,
                    FechaRealizada = DateTime.Now,
                    FechaEntregaEstimada = DateTime.Now,
                    SubTotal = (decimal)1,
                    Descuento = (decimal)1,
                    Impuesto = (decimal)1,
                    Total = (decimal)1,
                    Nombre = "H",
                    DireccionEnvio = "H",
                    Telefono = "H",
                    Correo = "H",
                    IdSucursal = 1

                };
                // Se agrega el registro al pedido
                contexto.Pedido.Add(miPedido);
                // Se guarda la tabla
                contexto.SaveChanges();
                // Se hace la consulta de obtener el ultimo pedido creado
                var consulta = (from datos in contexto.Pedido
                                select datos).OrderByDescending(s => s.IdPedido);
                // Se retorna el pedido antes seleccionado
                return consulta.FirstOrDefault().IdPedido;
            }

        }
        // Metodo para obtener el pedido
        public Pedido GetElPedido(string usuario)
        {
            // Se hace la consulta de obtener el pedido actual
            var consulta = (from datos in contexto.Pedido
                            where datos.IdUsuario == usuario && datos.IdStatus == 1
                            select datos).OrderByDescending(s => s.IdPedido);
            var pedido = consulta.FirstOrDefault();
            // Se obtiene el detalle del pedido actual
            var detallespedido = (from datos in contexto.DetallePedido
                                  where datos.IdPedido == pedido.IdPedido
                                  select datos);
            // Se declara el pedido
            Pedido miPedido = new Pedido
            {
                IdPedido = pedido.IdPedido,
                IdStatus = pedido.IdStatus,
                IdUsuario = pedido.IdUsuario,
                FechaRealizada = pedido.FechaRealizada,
                FechaEntregaEstimada = pedido.FechaEntregaEstimada,
                SubTotal = pedido.SubTotal,
                Descuento = pedido.Descuento,
                Impuesto = pedido.Impuesto,
                Total = pedido.Total,
                Nombre = pedido.Nombre,
                DireccionEnvio = pedido.DireccionEnvio,
                Telefono = pedido.Telefono,
                Correo = pedido.Correo,
                IdSucursal = pedido.IdSucursal,
                Detalle = detallespedido.ToList()
            };
            // Se retorna el pedido 
            return miPedido;
        }
        // Metodo donde confirma el pedido
        public Pedido ConfirmarPedido(string usuario)
        {
            // Se obtiene el pedido del usuario conectado
            var consulta = (from datos in contexto.Pedido
                            where datos.IdUsuario == usuario && datos.IdStatus == 1
                            select datos).OrderByDescending(s => s.IdPedido);
            var pedido = consulta.FirstOrDefault();

            var consulta2 = contexto.Cliente.FirstOrDefault(s => s.Correo == usuario);
            // Se cambia de status el pedido
            pedido.IdStatus = 3;
            pedido.Correo = usuario;
            pedido.Nombre = consulta2.Nombre + " " + consulta2.Apellidos;
            pedido.DireccionEnvio = consulta2.Direccion;
            pedido.Telefono = consulta2.Telefono;  
            // Se guardan los cambios
            contexto.SaveChanges();
            // Se retorna el pedido
            return pedido;
        }
        // Metodo donde se valida si existe el articulo en el pedido
        public bool ExisteElArticulo(long idPedido, int idArticulo, string usuario)
        {
            // Se obtiene el pedido del usuario seleccionado
            var consulta = (from datos in contexto.Pedido
                            where datos.IdUsuario == usuario && datos.IdStatus == 1 && datos.IdPedido == idPedido
                            select datos).OrderByDescending(s => s.IdPedido);
            var pedido = consulta.FirstOrDefault();
            // Se obtiene el detalle del pedido
            var detallespedido = (from datos in contexto.DetallePedido
                                  where datos.IdPedido == pedido.IdPedido
                                  select datos);
            var detallepedido = detallespedido.FirstOrDefault(s => s.IdArticulo == idArticulo);
            // Si no existe el articulo en el pedido, se devuelve falso
            if(detallepedido != null)
            {
                return false;
            }
            // Si existe el articulo en el pedido, se devuelve verdadero
            else
            {
                return true;
            }

        }
        // Metodo para eliminar un articulo del detalle del pedido
        public bool EliminarPedido(string usuario, int idArticulo)
        {
            // Se obtiene el pedido
            var consulta1 = (from datos in contexto.Pedido
                             where datos.IdUsuario == usuario && datos.IdStatus == 1
                             select datos).OrderByDescending(s => s.IdPedido).ToList();
            var pedido = consulta1.FirstOrDefault();
            // Se obtiene el detalle del pedido
            var consulta2 = (from datos in contexto.DetallePedido
                             where datos.IdPedido == pedido.IdPedido
                             select datos).ToList();
            // Se obtiene el articulo a eliminar del pedido
            var detalle = (from datos in contexto.DetallePedido
                             where datos.IdPedido == pedido.IdPedido && datos.IdArticulo == idArticulo
                              select datos);
            var detalle1 = detalle.FirstOrDefault();
            // Se elimina el detalle del pedido
            contexto.DetallePedido.Remove(detalle1);
            // Se guardan los cambio en la tabla Detalle de Pedido
            contexto.SaveChanges();

            // Se obtiene nuevamente el detalle del pedido, con el articulo ya eliminado
            var detallespedido = (from datos in contexto.DetallePedido
                                  where datos.IdPedido == pedido.IdPedido
                                  select datos);
            // Se establecen los valores de IMPUESTo del pedido
            decimal isv = (decimal)1.15;
            decimal isv15 = (decimal)0.15;
            var counts = detallespedido.ToList().Count;
            // Si no hay ningun articulo en el pedido
            if (counts == 0)
            {
                // Los valores quedan en 0
                pedido.SubTotal = 0;
                pedido.Impuesto = 0;
                pedido.Total = 0;
            }
            // Si quedan articulos en el pedido
            else
            {
                // Se actualizan los valores del IMPUESTO del pedido
                pedido.SubTotal = detallespedido.Sum(x => x.Subtotal);
                pedido.Impuesto = detallespedido.Sum(x => x.Subtotal) * isv15;
                pedido.Total = detallespedido.Sum(x => x.Subtotal) * isv;
            }
            // Se guardan los cambios del PEDIDO
            contexto.SaveChanges();
            // Se retorna verdadero
            return true;

        }
    }
}