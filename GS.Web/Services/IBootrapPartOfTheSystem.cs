using Nancy.TinyIoc;

namespace GS.Web.Services
{
    interface IBootrapPartOfTheSystem
    {
        void ConfigureApplicationContainer(TinyIoCContainer container);
    }
}
