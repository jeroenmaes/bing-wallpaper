using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace set_bing_wallpaper
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get Bing Image
            var bingImage = new BingImage();
            var image = bingImage.GetImage();

            //Save Image            
            var basepath = @"c:\_BingImages\";
            var imageHelper = new ImageHelper();
            var localImagePath = imageHelper.DownloadImageToFolder(image.URL, basepath, image.Hash + ".jpg");
            
            //Set Image as wallpaper
            var ws = new WallpaperSetter();
            ws.Set(localImagePath);            
        }                
    }
}
