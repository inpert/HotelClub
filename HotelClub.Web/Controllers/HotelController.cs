using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelClub.Web.Controllers
{
    public class HotelController : BaseController
    {
        //
        // GET: /Hotel/

        public ActionResult Index()
        {
            return View();
        }

    }
}
