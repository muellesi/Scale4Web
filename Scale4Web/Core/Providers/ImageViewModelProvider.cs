using Scale4Web.Modules.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Scale4Web.Core.Providers
{
    class ImageViewModelProvider : IProvider<ImageViewModel>
    {
        IUnityContainer _container;

        public ImageViewModelProvider(IUnityContainer container)
        {
            _container = container;
        }

        public ImageViewModel Get()
        {
            return _container.Resolve<ImageViewModel>();
        }
    }
}
