using Carrito_de_Compra.Models;
using Carrito_de_Compra.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Carrito_de_Compra.Controllers
{
    public class StatusController : Controller
    {
        // GET: Status
        public ActionResult Index()
        {
            List<Status> statuses = this.repo.GetStatuses();
            return View(statuses);
        }
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Detail()
        {
            return View();
        }
        RepositoryStatus repo;
        public StatusController()
        {
            repo = new RepositoryStatus();
        }
    }
}