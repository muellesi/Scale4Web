using Scale4Web.Core.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scale4Web.Ui.Navigation
{
    public delegate void ModuleChangedEventHandler(INavigationManager sender, IModule oldModule, IModule newModule);

    public interface INavigationManager
    {
        event ModuleChangedEventHandler ActiveModuleChanged;

        IModule CurrentModule { get; }

        void OpenModule(IModule module);

        void CloseModule();
    }

    public class NavigationManager : INavigationManager
    {
        private Stack<IModule> _openModules;

        public event ModuleChangedEventHandler ActiveModuleChanged;

        public IModule CurrentModule
        {
            get
            {
                if (_openModules.Count > 0)
                    return _openModules.Peek();

                return null;
            }
        }

        public NavigationManager()
        {
            _openModules = new Stack<IModule>();
        }

        public void CloseModule()
        {
            var oldModule = _openModules.Pop();
            OnActiveModuleChanged(oldModule, CurrentModule);
        }

        public void OpenModule(IModule module)
        {
            var oldModule = CurrentModule;
            _openModules.Push(module);
            OnActiveModuleChanged(oldModule, CurrentModule);
        }

        private void OnActiveModuleChanged(IModule oldModule, IModule newModule)
        {
            ActiveModuleChanged?.Invoke(this, oldModule, newModule);
        }
    }
}
