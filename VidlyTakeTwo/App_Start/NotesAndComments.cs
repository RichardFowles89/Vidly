using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VidlyTakeTwo.App_Start
{
    public class NotesAndComments
    {/*
MODEL: Application data and behaviour in terms of its problem domain, and independent of
the UI. A model will consist of classes such as 'customer' and 'movie'. These classes have
properties and methods that purely represent the application's state and rules. These 
classes are not tied to the UI, so you can take these classes and use them in different
apps (not just web apps either, can be desktop apps, all sorts...). They are PLAIN
OLD CLR OBJECTS. 

VIEW: The HTML markup that we display to the user. 

CONTROLLER: Responsible for handling HTTP requests. Methods of a controller are called
ACTIONS <<<<<<<<<<==================================== Quick to create an action:
type mvc4action then hit tab twice.

It is more accurate to say that it is an action in a controller that handles a HTTP request.
******************EXAMPLE************************
Imagine our app is hosted at vidly.com. When a request is sent to http://vidly.com/movies
a controller will be selected to handle (deal with) this request. This controller will get 
all the movies from the database (model), put them in a view and return the view to the 
client/browser. 
*************************************************

There is one more piece to the architecture that is not in the acronym but is nearly 
always there...

ROUTER: Responsible for selecting the right controller to handle the HTTP request. 

******************************************************************************************
Here is the Solution Explorer in ASP.NET MVC explained:
-App_Data - where our database file is stored.
-App_Start - contains classes that get called when the application is started. For example,
-RouteConfig.cs sets the default 'controller', 'path' and 'id'. 
-Content - where we store our css files, images and any other clientside assets. 
-Controllers - our default project template has 3 controllers: AccountController has actions
(methods) for sign up, sign in, log out etc, HomeController represents the home page, 
ManageController provides a number of actions for handling requests around a user's 
profile, like changing password, enabling two factor authentication, using socal logins...
-Models - all our domain classes are here. 
-Scripts - where we store our Javascript files. 
-Views - Here we have folders named after controllers in our application. When we use a 
view in a controller, ASP.NET will look for that view in a folder with the same name as 
the controller. We also have a view called 'Shared' which includes the views that can
be used across different controllers. 
-Favicon.ico - the icon of the application displayed in the browser.  
Global.asax - been in VS for a long time. A class that provides hooks for various events
in an application's lifecycle. 
-Packages.config - used by NuGet Package Manager. Package Managers are used to manage the
dependencies of our application. E.g. let's say an application has a dependency to 5
external libraries. Instead of going to 5 different websites to download these packages,
we use a Package Manager to download these dependencies from its central repository. 
Package Managers can also maintain the upgrades of these packages so we don't have to chase
them up manually. 
-Startup.cs - A new approach MS is taking to starting the application. In the coming 
versions of ASP.NET, Global.asax will be dropped and its logic will be in Startup.cs.
-Web.config - an xml that includes the configuration of our application. Out of all of the
elements you will find in this xml, you will only normally be working with 2: 
<connectionstrings> (which is where we specify DB connstrs) and <appSettings> (which is
where we define configuration settings for our application).

*************************************************************************************

When creating a view, you have a tickbox option called "Use a layout page". You can use 
this to ensure all web pages have the same layout (if that's what you want). The "default"
can be found by browsing - views/shared/_Layout.cshtml.

*****************************************************************************************
To change the style, go to bootswatch.com. Copy the code of the style you like into a .css
file and put that file in the Content folder (right click, Add/Existing item...). Then edit
the BundleConfig.cs file in App_Start.
*******************************************************************************************
                             ACTION RESULTS
ActionResult is the base class for all action results in MVC. Here are some common 
subclasses of ActionResult and the corresponding helper method that returns that result.
ViewResult -> View()
PartialViewResult -> PartialView()
ContentResult -> Content()
RedirectResult -> Redirect()
RedirectToRouteResult -> RedirectToAction()
JsonResult -> Json()
FileResult -> File()
HttpNotFoundResult -> HttpNotFound()
EmptyResult -> no helper method. Used when an action does not need to return any values.
********************************************************************************************
                            ACTION PARAMETERS
The are the inputs of our actions. When a request comes in the application, MVC 
automatically maps request data to parameter values for actions (methods). So, if an action
takes a parameter, the MVC framework looks for a parameter with the same name in the 
request data. If a parameter with that name exists, the framework will automatically 
pass the value of that parameter to the target action.

This parameter value can be embedded in the url: /movies/edit/1
                                     in the query string: /movies/edit?id=1
                                     in the form data: id=1


    */
    }
}
