using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelClub.Web.Controllers
{
    public class AboutController : BaseController
    {
        public ActionResult Author()
        {
            return View();
        }

        public ActionResult Project()
        {
            return View();
        }

    }
}
