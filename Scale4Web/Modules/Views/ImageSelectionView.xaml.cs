using Scale4Web.Core;
using Scale4Web.Modules.ViewModels;
using Scale4Web.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Scale4Web.Modules.Views
{
    /// <summary>
    /// Interaction logic for ImageSelectionView.xaml
    /// </summary>
    public partial class ImageSelectionView : UserControl
    {
        public ImageSelectionView()
        {
            InitializeComponent();
        }

        private void ListBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var fileDrop = e.Data.GetData(DataFormats.FileDrop) as string[];

                var hasImageFiles = fileDrop.Any(f => ImageHelpers.IsImageFile(new Uri(f)));

                if (hasImageFiles)
                    e.Effects = DragDropEffects.Copy;
                else
                    e.Effects = DragDropEffects.None;

            }
        }

        private void ListBox_Drop(object sender, DragEventArgs e)
        {
            if (sender is ListBox listBox)
            {
                var dc = listBox.DataContext as ImageViewModel;

                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    var files = e.Data.GetData(DataFormats.FileDrop) as string[];

                    var records = files.Where(ImageHelpers.IsImageFile)
                                       .Select(f => new ImageMetaData(new Uri(f)));
                    dc.Images.AddRange(records);
                }
            }
        }
    }
}
