using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using StructureMap;

namespace HotelClub.Web.Api
{
    public class BaseApiControler : ApiController
    {
        public BaseApiControler()
        {
            ObjectFactory.BuildUp(this);
        }
    }
}