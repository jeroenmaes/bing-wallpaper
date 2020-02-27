using set_bing_wallpaper.Dto;
using System;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace set_bing_wallpaper
{
    public class BingImage
    {
        public async Task<ResultImage> GetImage()
        {
            string baseUri = "https://www.bing.com";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUri);

                using (var jsonStream = await client.GetStreamAsync("HPImageArchive.aspx?format=js&idx=0&n=1&mkt=en-US"))
                {
                    var ser = new DataContractJsonSerializer(typeof(Results));
                    var res = (Results)ser.ReadObject(jsonStream);

                    var image = res.Images[0];
                    image.URL = baseUri + image.URL;
                    image.URLBase = baseUri + image.URLBase;
                    
                    return image;
                }
            }
        }
    }
}
