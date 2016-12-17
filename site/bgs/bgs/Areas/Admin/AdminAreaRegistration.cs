using System.Web.Mvc;

namespace bgs.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "Admin_Products",
                url: "Admin/Products/{action}/{category}/{id}",
                defaults: new { controller = "Products", action = "Index", category = "Sleeves", id = UrlParameter.Optional },
                constraints: new { category = @"\w+" }
            );

            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}