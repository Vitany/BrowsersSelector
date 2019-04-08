using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowsersSelector
{
    public class Browser
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Image")]
        public string Image { get; set; }

        [JsonProperty("Path")]
        public string Path { get; set; }

        [JsonProperty("Profiles")]
        public Profiles Profiles { get; set; }
    }

    public class Profiles
    {
        [JsonProperty("ProfileName")]

        public string ProfileName { get; set; }
    }
}
