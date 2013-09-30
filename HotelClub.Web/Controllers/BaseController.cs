using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StructureMap;

namespace HotelClub.Web.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            ObjectFactory.BuildUp(this);
        }

    }
}
