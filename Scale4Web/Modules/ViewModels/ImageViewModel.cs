using Scale4Web.Core;
using Scale4Web.Util;
using System.Collections.ObjectModel;

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

        public ImageViewModel()
        {
            Images = new RangeObservableCollection<ImageMetaData>();
        }
    }
}