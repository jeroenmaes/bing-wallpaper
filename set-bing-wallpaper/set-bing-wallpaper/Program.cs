using System;
using System.Threading.Tasks;

namespace set_bing_wallpaper
{
    class Program
    {
        static async Task Main()
        {
            try
            {
                //Get Bing image of the day
                var bingImage = new BingImage();
                var image = await bingImage.GetImage();

                //Save image            
                var imagesFolder = @"c:\_BingImages\";
                var imageHelper = new ImageHelper();
                var pathToImage = await imageHelper.DownloadImageToFolder(image.URL, imagesFolder, image.Hash + ".jpg");

                //Set image as wallpaper
                var ws = new WallpaperSetter();
                ws.Set(pathToImage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            
        }
    }
}
