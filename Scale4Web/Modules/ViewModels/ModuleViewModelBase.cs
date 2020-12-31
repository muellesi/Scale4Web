using Scale4Web.Core.Providers;
using Scale4Web.Ui.Navigation;
using Scale4Web.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Scale4Web.Modules.ViewModels
{
    public class ModuleDescriptionAttribute : Attribute {


        public ModuleDescriptionAttribute(string Title)
        {
            this.Title = Title;
        }

        public string Title { get; }
    }

    public abstract class ModuleViewModelBase : ViewModelBase, IModule
    {
        private string _moduleTitle;

        protected INavigationManager NavigationManager
        {
            get; private set;
        }

        protected Func<string, IModule> ModuleFactory { get; private set; }

        public ModuleViewModelBase()
        {
            if(this.GetAttribute<ModuleDescriptionAttribute>() is ModuleDescriptionAttribute description)
            {
                ModuleTitle = description.Title;
            }
        }

        [InjectionMethod]
        public void Init(INavigationManager navigationManager, Func<string, IModule> moduleFactory)
        {
            NavigationManager = navigationManager;
            ModuleFactory = moduleFactory;

            OnInitComplete();
        }

        public virtual void OnInitComplete() { }

        public string ModuleTitle
        {
            get
            {
                return _moduleTitle;
            }
            protected set
            {
                _moduleTitle = value;
                RaisePropertyChanged();
            }
        }

    }
}
