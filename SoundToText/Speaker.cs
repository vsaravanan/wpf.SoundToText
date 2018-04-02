using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SoundToText
{
    class Speaker 
    {
        [JsonProperty("Mic")]
        public string Mic { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Status")]
        public string Status { get; set; }

        public Speaker() { }

        //public Speaker(Speaker oldSpeaker)
        //{
        //    Mic = oldSpeaker.Mic;
        //    Name = oldSpeaker.Name;
        //    Status = oldSpeaker.Status;
        //}

    }
}
