using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace set_bing_wallpaper
{
    public class BingImage
    {
        public ResultImage GetImage()
        {
            string baseUri = "https://www.bing.com";

            using (var client = new HttpClient())
            {
                using (var jsonStream = client.GetStreamAsync("http://www.bing.com/HPImageArchive.aspx?format=js&idx=0&n=1&mkt=en-US"))
                {
                    var ser = new DataContractJsonSerializer(typeof(Results));
                    var res = (Results)ser.ReadObject(jsonStream.Result);

                    var image = res.images[0];
                    image.URL = baseUri + image.URL;
                    image.URLBase = baseUri + image.URLBase;
                    
                    return image;
                }
            }
        }
    }

    [DataContract]
    public class Results
    {
        [DataMember(Name = "images")]
        public ResultImage[] images { get; set; }
    }

    [DataContract]
    public class ResultImage
    {
        [DataMember(Name = "enddate")]
        public string EndDate { get; set; }
        [DataMember(Name = "url")]
        public string URL { get; set; }
        [DataMember(Name = "urlbase")]
        public string URLBase { get; set; }
        [DataMember(Name = "hsh")]
        public string Hash { get; set; }
        [DataMember(Name = "copyright")]
        public string Copyright { get; set; }
        [DataMember(Name = "copyrightlink")]
        public string CopyrightLink { get; set; }
    }
}
