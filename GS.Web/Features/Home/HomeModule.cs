using Nancy;

namespace GS.Web.Features.Home
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = parameters => "Hej";
        }
    }
}