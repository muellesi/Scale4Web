using Scale4Web.Core;
using Scale4Web.Core.ConversionSettings;
using Scale4Web.Core.Providers;
using Scale4Web.Ui.Navigation;
using Scale4Web.Util;
using System;

namespace Scale4Web.Modules.ViewModels
{
    class MainWindowViewModel : ModuleViewModelBase
    {
        private IModule _currentModule;

        public IModule CurrentModule
        {
            get { return _currentModule; }

            private set
            {
                _currentModule = value;
                RaisePropertyChanged();
            }
        }

        public override void OnInitComplete()
        {
            NavigationManager.ActiveModuleChanged += NavigationManager_ActiveModuleChanged;
            NavigationManager.OpenModule(ModuleFactory(nameof(ImageViewModel)));
        }

        private void NavigationManager_ActiveModuleChanged(INavigationManager sender, IModule oldModule, IModule newModule)
        {
            CurrentModule = newModule;
        }
    }
}
