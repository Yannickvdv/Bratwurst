using Bratwurst.Content;
using Bratwurst.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Bratwurst.Controllers
{
    public class HomeController : Controller
    {
        SQLDataLayer sql = new SQLDataLayer();

        // GET: Home
        public ActionResult Index()
        {
            var model = new List<Photo>();

            foreach(Photo p in sql.getPictures())
            {
                model.Add(p);
            }

            return View(model);
        }
    }
}