using Scale4Web.Core.Providers;
using Scale4Web.Ui.Navigation;
using Scale4Web.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
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

        public bool IsInitialized { get; private set; }

        protected ModuleViewModelBase()
        {
            if(this.GetAttribute<ModuleDescriptionAttribute>() is { } description)
            {
                ModuleTitle = description.Title;
            }
        }

        [InjectionMethod]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Init(INavigationManager navigationManager, Func<string, IModule> moduleFactory)
        {
            NavigationManager = navigationManager;
            ModuleFactory = moduleFactory;

            OnInitComplete();
            IsInitialized = true;
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
