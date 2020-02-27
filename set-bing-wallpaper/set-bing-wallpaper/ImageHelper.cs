using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace set_bing_wallpaper
{
    class ImageHelper
    {
        public async Task<string> DownloadImageToFolder(string url, string folder, string filename)
        {            
            var fileInfo = new FileInfo(folder + filename);

            if (!File.Exists(fileInfo.FullName))
            {
                var _httpClient = new HttpClient();
                var response = await _httpClient.GetAsync(url);

                using (var ms = await response.Content.ReadAsStreamAsync())
                {
                    using (var fs = File.Create(fileInfo.FullName))
                    {
                        ms.Seek(0, SeekOrigin.Begin);
                        ms.CopyTo(fs);
                    }
                }
            }
                     
            return fileInfo.FullName;
        }
    }
}
