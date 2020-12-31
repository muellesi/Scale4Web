using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Scale4Web.Core.Providers
{
    class ModuleProvider<TModule> : IProvider<TModule> where TModule : IModule
    {
        private IUnityContainer _container;

        public ModuleProvider(IUnityContainer container)
        {
            _container = container;
        }

        public TModule Get()
        {
            return _container.Resolve<TModule>();
        }
    }
}
