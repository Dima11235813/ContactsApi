using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsApiTests
{
    //public class TestUtilities
    //{
    //    public static ControllerContext GenerateControllerContext()
    //    {
    //        ControllerContext controllerContext = new ControllerContext();
    //        HttpContextBase currContext = TestUtilities.GenerateHttpContext();
    //        controllerContext.HttpContext = currContext;
    //        HttpContext.Current = new HttpContext(
    //            new HttpRequest("", "http://tempuri.org", ""),
    //            new HttpResponse(new StringWriter())
    //            );

    //        // User is logged in
    //        HttpContext.Current.User = new GenericPrincipal(
    //            new GenericIdentity(ConfigurationManager.AppSettings["test_WebUser_Email"]),
    //            new string[0]
    //            );
    //        AddFakeSession(currContext, asUser);

    //        return controllerContext;

    //    }
    //}
}
