using System;

using Raven.Client;

namespace GS.Persistance.Tests
{
    public abstract class PersistanceTest : IDisposable
    {
        private TestDocumentStore Provider;

        protected PersistanceTest()
        {
            Provider = new TestDocumentStore();
        }

        protected IDocumentSession NewSession()
        {
            return Provider.GetSession();
        }

        public void Dispose()
        {
            Provider.Dispose();
        }
    }
}