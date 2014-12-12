using Raven.Client;

namespace GS.Services.Persistance
{
    public interface IConfigureDocumentStore
    {
        void Configure(IDocumentStore documentStore);
    }
}
