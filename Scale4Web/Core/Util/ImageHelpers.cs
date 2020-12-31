using System;
using System.Linq;

namespace Scale4Web.Util
{
    public static class ImageHelpers
    {
        public static bool IsImageFile(string filePath)
        {
            return IsImageFile(new Uri(filePath));
        }


        public static bool IsImageFile(Uri fileUri)
        {
            return fileUri.IsFile && HasImageFileExtension(fileUri);
        }

        public static bool HasImageFileExtension(Uri fileUri)
        {
            var absPath = fileUri.AbsoluteUri;

            var extensions = new[] {
                ".jpg", ".png", ".bmp", ".jpeg"
            };

            return extensions.Any(absPath.ToLower().EndsWith);
        }
    }
}
