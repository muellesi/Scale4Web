using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scale4Web.Core.ConversionSettings;
using Scale4Web.Core.Providers;

namespace Scale4Web.Modules.ViewModels
{
    public class SettingsViewModel : ModuleViewModelBase
    {
        public ConversionSettings AvailableConfigurations
        {
            get;
        }

        public SettingsViewModel(ConversionSettings settings)
        {
            AvailableConfigurations = settings;
        }

    }
}
