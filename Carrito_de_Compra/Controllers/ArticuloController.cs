using Carrito_de_Compra.Models;
using Carrito_de_Compra.Repositories;
using CarroCompra1.Models;
using CarroCompra1.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Carrito_de_Compra.Controllers
{
    public class ArticuloController : Controller
    {
        // GET: Articulo
        // Este metodo manda a llamar cuando se acciona la URL de Index
        public ActionResult Index()
        {
            // Se setea la variable string en nulo
            string Buscar = null; 
            // Se crea una variable de una lista de articulos y se obtiene la lista de articulos
            List<Articulo> articulos = this.repo.GetArticulos(Buscar);
            // Luego de obtener articulos se le pasa esa lista de articulos a la vista
            return View(articulos);
        }
        // Se declaran los repositorios (donde se guardan los registros de las tablas)
        RepositoryArticulo repo;
        RepositoryMarca repom;
        RepositorySubCategoria repos;
        RepositoryCliente repoc;
        public ArticuloController()
        { 
            // Se inicializan los repositorios como tipo repositorio
            repo = new RepositoryArticulo();
            repom = new RepositoryMarca();
            repos = new RepositorySubCategoria();
            repoc = new RepositoryCliente();
        }
        //GET: Articulo
        // Este metodo manda a llamar cuando se acciona la URL del buscador de articulo
        public ActionResult ListaArticulo(string Buscar)
        {
            // Se crea una variable de una lista de articulos y se obtiene la lista de articulos
            List<Articulo> articulos = this.repo.GetArticulos(Buscar);
            // Luego de obtener articulos se le pasa esa lista de articulos a la vista
            return View(articulos);
        }
        // El Authorize se utiliza para determinar que Roles tienen permiso a cada metodo
        [Authorize(Roles = "Admin")]

        // Este metodo manda a llamar cuando se acciona la URL de crear un articulo
        public ActionResult Create()
        { 
            // Se obtiene la lista de Marcas para poder llenar el Combobox de marca
            List<Marca> marcas = this.repom.GetMarcas();
            // Se pasa la lista de Marcas para poder utilizarlos en la Vista
            ViewBag.Marcas = marcas;
            // Se obtiene la lista de Subcategorias para poder llenar el combobox de subcategorias
            List<SubCategoria> subCategorias = this.repos.GetSubCategorias();
            // Se pasa la lista de Subcategorias para poder utilizarlos en la Vista
            ViewBag.Subcategorias = subCategorias;
            return View();
        }

        // Este metodo manda a llamar cuando se acciona la URL de crear un articulo por el Metodo Post
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(Articulo articulo)
        {
            // Se valida que el modelo ingresado sea valido
            if (ModelState.IsValid)
            {
                // Si el modelo es valido, se crea el ariculo en la base de datos
                Articulo miarticulo = this.repo.CreateArticulo(articulo);
                // Se redirecciona a la URL Index de Articulo
                return RedirectToAction("Index", "Articulo");
            }
            // Si el modelo no es valido se vuelven a obtener las marcas para llenar el combobox
            List<Marca> marcas = this.repom.GetMarcas();
            // Se pasa la lista de Marcas para poder utilizarlos en la Vista
            ViewBag.Marcas = marcas;
            // Si el modelo no es valido se vuelven a obtener las subcategorias para llenar el combobox
            List<SubCategoria> subCategorias = this.repos.GetSubCategorias();
            // Se pasa la lista de Subcategorias para poder utilizarlos en la Vista
            ViewBag.Subcategorias = subCategorias;
            return View(articulo);
        }
        [Authorize(Roles = "Admin")]
        // Este metodo manda a llamar cuando se acciona la URL de editar un articulo
        public ActionResult Edit(int id)
        {
            // Se obtiene la lista de Marcas para poder llenar el Combobox de marca
            List<Marca> marcas = this.repom.GetMarcas();
            // Se pasa la lista de Marcas para poder utilizarlos en la Vista
            ViewBag.Marcas = marcas;
            // Se obtiene la lista de Subcategorias para poder llenar el Combobox de marca
            List<SubCategoria> subCategorias = this.repos.GetSubCategorias();
            // Se pasa la lista de Subcategorias para poder utilizarlos en la Vista
            ViewBag.Subcategorias = subCategorias;
            // Se obtiene el articulo a EDITAR para poderlo pasar a la vista
            Articulo miarticulo = this.repo.ArticuloXID(id);
            // Se pasa el Articulo a EDITAR a la VISTA
            return View(miarticulo);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        // Este metodo manda a llamar cuando se acciona la URL de editar un articulo por el metodo POST
        public ActionResult Edit(Articulo miArticulo)
        {
            // Se valida que el modelo ingresado sea valido
            if (ModelState.IsValid)
            {
                // Si el modelo es valido, se edita el ariculo en la base de datos
                Articulo miarticulo = this.repo.EditArticulo(miArticulo.IdArticulo, miArticulo);
                // Se redirecciona a la URL Index de Articulo
                return RedirectToAction("Index");
            }
            // Se obtiene la lista de Marcas para poder llenar el Combobox de marca
            List<Marca> marcas = this.repom.GetMarcas();
            // Se pasa la lista de Marcas para poder utilizarlos en la Vista
            ViewBag.Marcas = marcas;
            // Se obtiene la lista de Subcategorias para poder llenar el Combobox de marca
            List<SubCategoria> subCategorias = this.repos.GetSubCategorias();
            // Se pasa la lista de Subcategorias para poder utilizarlos en la Vista
            ViewBag.Subcategorias = subCategorias;
            return View(miArticulo);
        }
        [Authorize(Roles = "Admin")]
        // Este metodo manda a llamar cuando se acciona la URL de ver el detalle de un articulo
        public ActionResult Detail(int id)
        {

            // Se obtiene el articulo del cual se va a ver el detalle para poderlo pasar a la vista
            Articulo miarticulo = this.repo.ArticuloXID(id);
            // Se pasa el articulo a la vista
            return View(miarticulo);
        }

        [Authorize(Roles = "Cliente")]
         // Este metodo manda a llamar cuando se acciona la URL de Agregar un articulo al pedido
        public ActionResult Agregar(int id)
        {
            // Se obtiene la lista de Marcas para poder llenar el Combobox de marca
            List<Marca> marcas = this.repom.GetMarcas();
            // Se pasa la lista de Marcas para poder utilizarlos en la Vista
            ViewBag.Marcas = marcas;
            // Se obtiene la lista de Subcategorias para poder llenar el Combobox de marca
            List<SubCategoria> subCategorias = this.repos.GetSubCategorias();
            // Se pasa la lista de Subcategorias para poder utilizarlos en la Vista
            ViewBag.Subcategorias = subCategorias;
            // Se obtiene el articulo que se va a agregar
            Articulo miarticulo = this.repo.ArticuloXID(id);
            // Se crea el pedido y se obtiene el id del pedido creado
            var idPedido = this.repo.CreatePedidoAndGetId(this.User.Identity.Name);
            // Se pasa el Id del pedido recien creado
            ViewBag.IdPedido = idPedido;
            // Se valida si existe el articulo en el pedido
                var valid = this.repo.ExisteElArticulo(idPedido, id, this.User.Identity.Name);
            // Si el articulo existe en el pedido, muestra el detalle del articulo
                if (valid)
                {
                    return View(miarticulo);

                }
                // Si el articulo no existe en el pedido, muestra el carrito con el detalle del pedido
                else
                {
                    return RedirectToAction("Carrito");
                }
        }

        [HttpPost]
        [Authorize(Roles = "Cliente")]
        // Este metodo se manda a llamar cuando se ejecuta la URL de Agregar el articulo definitivamente al carrito
        public ActionResult AgregarAlCarrito(Articulo articulo, int Cantidad)
        {
            // Se agrega el metodo al carrito de compras
            Articulo articulos = this.repo.AddArticuloToCart(articulo.IdArticulo, this.User.Identity.Name, Cantidad);
            // Se muestra el detalle del pedido
            return RedirectToAction("Carrito");
        }
        [Authorize(Roles = "Cliente")]
        // Este metodo se ejecuta cuando se ejecuta la URL del carrito
        public ActionResult Carrito()
        {
            // Se obtiene la informacion del Pedido junto al detalle del pedido
            Pedido miPedido = this.repo.GetElPedido(this.User.Identity.Name);
            Cliente miCliente = this.repoc.GetClienteByEmail(this.User.Identity.Name);
            ViewBag.Nombre = miCliente.Nombre;
            ViewBag.Apellido = miCliente.Apellidos;
            ViewBag.Direccion = miCliente.Direccion;
            ViewBag.Telefono = miCliente.Telefono;
            ViewBag.Correo = miCliente.Correo;
            // Se pasa el pedido a la vista
            return View(miPedido);
        }
        [Authorize(Roles = "Cliente")]
        // Este metodo se ejecuta cuando se ejecuta la URL de confirmar la compra del pedido
        public ActionResult Confirmar()
        {
            // Se confirma el pedido y se cambia el status del pedido
            Pedido miPedido = this.repo.ConfirmarPedido(this.User.Identity.Name);
            // Se muestra la vista del index
            return RedirectToAction("Index", "Home");
        }
        [Authorize(Roles = "Admin")]
        // Este metodo se manda a llamar cuando se ejecuta la URL de eliminar un articulo del pedido
        public ActionResult Eliminar(int id)
        { 
            // Se manda a llamar el metodo de eliminar el articulo del pedido
            var idPedido = this.repo.EliminarPedido(this.User.Identity.Name,id);
            // Se manda a llamar la vista del Carrito junto al detalle del pedido
            return RedirectToAction("Carrito", "Articulo");

        }
        [Authorize(Roles = "Admin")]
        // Este metodo se manda a llamar cuando se ejecuta la URL de asignar una imagen al articulo
        public ActionResult Image(int id)
        {
            // Se obtiene el articulo que se va a cambiar la imagen
            Articulo miarticulo = this.repo.ArticuloXID(id);
            return View(miarticulo);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        // Este metodo se manda a llamar cuando se ejecuta la URL de asignar una imagen al articulo por el metodo POST
        public ActionResult UploadFile(HttpPostedFileBase file, int IdArticulo)
        {
            // Se crea un try catch (para capturar errores al subir la imagen)
                try
                {
                // Se crea una variable de tipo cadena de texto y se le pasa el nombre del archivo
                    string fileName = file.FileName;
                // Se crea una variable de tipo de cadena de texto y se combina el nombre la ruta con el del archivo
                    string path = Path.Combine("C:/Users/*Tu Usuario*/Documents/Carrito_de_Compra/Carrito_de_Compra/Content/Imagenes/Articulos/", fileName);
                // Se guarda el archivo en la ruta establecida 
                file.SaveAs(path);
                // Se setea el campo de URL de la imagen con el archivo subido
                Articulo miarticulo = this.repo.ImageArticulo(IdArticulo, fileName);
                // Se redirige al index de articulo
                return RedirectToAction("Index", "Articulo");
                }
            // Se capturan los errores
                catch (Exception ex)
                {
                // Si hay errores se muestra la vista del index de articulo
                    return RedirectToAction("Index", "Articulo");
                }

            
        }
    }
}