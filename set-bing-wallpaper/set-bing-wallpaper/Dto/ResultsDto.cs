using System.Runtime.Serialization;

namespace set_bing_wallpaper.Dto
{

    [DataContract]
    public class Results
    {
        [DataMember(Name = "images")]
        public ResultImage[] Images { get; set; }
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
