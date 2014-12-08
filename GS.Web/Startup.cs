using Microsoft.Owin.Extensions;

using Owin;

namespace GS.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseNancy(options => 
                options.Bootstrapper = new Bootstrapper());
        
            app.UseStageMarker(PipelineStage.MapHandler);
        }
    }
}