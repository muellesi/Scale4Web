using System;
using Scale4Web.Core;
using Scale4Web.Core.ConversionSettings;
using Scale4Web.Util;
using System.Collections.ObjectModel;
using System.Linq;
using Scale4Web.Ui.Commands;

namespace Scale4Web.Modules.ViewModels
{
    public class ImageViewModel : ModuleViewModelBase
    {
        private RangeObservableCollection<ImageMetaData> _images;
        public RangeObservableCollection<ImageMetaData> Images
        {
            get { return _images; }
            set
            {
                _images = value;
                RaisePropertyChanged();
            }
        }

        private ImageMetaData _selectedImage;
        public ImageMetaData SelectedImage
        {
            get { return _selectedImage; }
            set
            {
                _selectedImage = value;
                RaisePropertyChanged();
            }
        }

        public ConversionSettings ConversionSettings { get; }

        private ConversionPreset _selectedConversionPreset;
        public ConversionPreset SelectedConversionPreset
        {
            get
            {
                return _selectedConversionPreset;
            }
            set
            {
                _selectedConversionPreset = value;
                RaisePropertyChanged();
            }
        }

        public DelegateCommand OpenSettingsViewCommand { get; private set; }

        public ImageViewModel(ConversionSettings settings)
        {
            Images = new RangeObservableCollection<ImageMetaData>();
            OpenSettingsViewCommand = new DelegateCommand(_ => NavigationManager.OpenModule(ModuleFactory(nameof(SettingsViewModel))));

            ConversionSettings = settings;
            SelectedConversionPreset =
                ConversionSettings.Presets.FirstOrDefault(preset => preset.Guid == ConversionSettings.DefaultPreset);
        }
    }
}