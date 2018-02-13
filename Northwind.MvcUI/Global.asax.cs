
using Msb.Core.CrossCuttingConcerns.Logging;
using Msb.Core.CrossCuttingConcerns.Logging.Log4Net;
using Msb.Core.CrossCuttingConcerns.Logging.NLog;
using Msb.Core.Extensions;
using Northwind.Business.Abstract;
using Northwind.Business.Concrete;
using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concrete.EntityFramework;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Northwind.MvcUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            container.Register<IProductService, ProductManager>(Lifestyle.Scoped);
            container.Register<IProductDal, EfProductDal>(Lifestyle.Scoped);

            container.Register<ILogManager, Log4NetManager>(Lifestyle.Scoped);
            //container.Register<ILogManager, NLogManager>(Lifestyle.Scoped);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.Verify();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}
