using System.Web.Mvc;

namespace VidlyTakeTwo
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute());

            //The [Authorize] filter can be applied to an action, a class, or applied globally by using the
            //AuthorizeAttribute() method above. Whenever a action/class/page is requested that has this filter 
            //MVC will check to see whether the user is logged in. If not, it will redirect the user to the login 
            //page.
        }
    }
}
