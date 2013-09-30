using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using HotelClub.Web.Filters;

namespace HotelClub.Web
{
    public class CustomGlobalConfig
    {
        public static void Customize(HttpConfiguration config)
        {
            config.Filters.Add(new ValidationActionFilter());
        }
    }
}