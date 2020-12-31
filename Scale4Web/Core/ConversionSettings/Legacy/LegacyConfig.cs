using System.Collections.Generic;

namespace Scale4Web.Core
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Structs for deserializing legacy config.")]
    internal record LegacyConfig
    {
        internal enum SideSetting { 
            Longest = 0,
            Width = 1,
            Height = 2
        }

        internal record LegacyConfigItem
        {

            public string name { get; set; }
            public int quality { get; set; }
            public SideSetting limitSide { get; set; }
            public int selectedSideMaxLength { get; set; }
            public int id { get; set; }

        }

        public List<LegacyConfigItem> presets { get; set; }
    }
}
