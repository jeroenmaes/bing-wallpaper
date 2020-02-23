using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace set_bing_wallpaper
{
    class ImageHelper
    {
        public string DownloadImageToFolder(string url, string folder, string filename)
        {            
            var fileInfo = new FileInfo(folder + filename);
            var _httpClient = new HttpClient();
            var response = _httpClient.GetAsync(url).Result;

            using (var ms = response.Content.ReadAsStreamAsync().Result)
            {
                using (var fs = File.Create(fileInfo.FullName))
                {
                    ms.Seek(0, SeekOrigin.Begin);
                    ms.CopyTo(fs);
                }
            }
                     
            return fileInfo.FullName;
        }
    }
}
