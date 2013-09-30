﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using HotelClub.Data;
using HotelClub.Web.App_Start;
using HotelClub.Web.DependencyResolution;
using StructureMap;

namespace HotelClub.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            StructuremapMvc.Start();
            
            CustomGlobalConfig.Customize(GlobalConfiguration.Configuration);

            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MainContext>());
        }
    }
}