using System;
using System.Configuration;
using System.Linq;

using Raven.Client;
using Raven.Client.Document;

namespace GS.Services.Persistance
{
    public class RavenSessionProvider : ISessionProvider, IDisposable
    {
        private static readonly Lazy<DocumentStore> _lazyStore = new Lazy<DocumentStore>(() =>
            {
                var store = new DocumentStore();

                if (ConfigurationManager.ConnectionStrings["RavenDB"] != null)
                {
                    store.ConnectionStringName = "RavenDB";
                }

                store.Initialize();

                var documentStoreConfigurators = from type in typeof(IConfigureDocumentStore).Assembly.GetTypes()
                                                 where
                                                     typeof(IConfigureDocumentStore).IsAssignableFrom(type) &&
                                                     typeof(IConfigureDocumentStore).IsInterface == false
                                                 select type;

                foreach (var configuratorType in documentStoreConfigurators)
                {
                    var configurator = (IConfigureDocumentStore)Activator.CreateInstance(configuratorType);
                    configurator.Configure(store);
                }


                return store;
            });

        public IDocumentSession GetSession()
        {
            return _lazyStore.Value.OpenSession();
        }

        public void Dispose()
        {
            if (_lazyStore.IsValueCreated)
                if (_lazyStore.Value != null)
                    _lazyStore.Value.Dispose();
        }
    }

    public interface ISessionProvider
    {
        IDocumentSession GetSession();
    }
}
