using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Raven.Client;

namespace RavenBooks.Controllers
{
    public class RavenController : Controller
    {
        public IDocumentSession RavenSession;

         protected override void OnActionExecuting(ActionExecutingContext filterContext) 
        { 
            RavenSession = MvcApplication.bookDocumentStore.OpenSession(); 
        } 
 
        protected override void OnActionExecuted(ActionExecutedContext filterContext) 
        { 
            if (filterContext.IsChildAction) 
                return; 
 
            using (RavenSession) 
            { 
                if (filterContext.Exception == null) 
                    RavenSession.SaveChanges(); 
            } 
        } 
    }
}
