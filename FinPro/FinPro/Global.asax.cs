using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using FinPro;

namespace FinPro
{
	public class Global : HttpApplication
	{
		void Application_Start(object sender, EventArgs e)
		{
			//// Code that runs on application startup
			//AuthConfig.RegisterOpenAuth();
			//RouteConfig.RegisterRoutes(RouteTable.Routes);
		}

		void Application_End(object sender, EventArgs e)
		{
			//  Code that runs on application shutdown

		}

		void Application_Error(object sender, EventArgs e)
		{
			// Code that runs when an unhandled error occurs
        //    If (Context IsNot Nothing) And (Context.User.IsInRole("Developer")) Then
           
        //    Dim err As Exception = Server.GetLastError()
           
        //    Response.Clear()
           
        //    Response.Write("<h1>" & err.InnerException.Message & "</h1>")
        //    Response.Write("<pre>" & err.ToString & "</pre>")
           
        //    Server.ClearError()
           
        //End If

		}

		protected void Session_Start(object sender, EventArgs e)
		{
			
		}
	}
}
