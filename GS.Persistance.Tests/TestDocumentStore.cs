using System;
using System.Linq;

using GS.Services.Persistance;

using Raven.Client;
using Raven.Client.Embedded;

namespace GS.Persistance.Tests
{
    public class TestDocumentStore : ISessionProvider, IDisposable
    {
        private readonly Lazy<IDocumentStore> _store = new Lazy<IDocumentStore>(() =>
            {
                var store = new EmbeddableDocumentStore()
                    {
                        RunInMemory = true,
                    };

                store.Initialize();

                var documentStoreConfigurators = from type in typeof (IConfigureDocumentStore).Assembly.GetTypes()
                                                 where
                                                     typeof (IConfigureDocumentStore).IsAssignableFrom(type) &&
                                                     typeof (IConfigureDocumentStore).IsInterface == false
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
            return _store.Value.OpenSession();
        }

        public void Dispose()
        {
            if (_store.IsValueCreated)
                if (_store.Value != null)
                    _store.Value.Dispose();
        }
    }
}
