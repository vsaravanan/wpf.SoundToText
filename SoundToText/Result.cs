using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace SoundToText
{
    class Result
    {
        [JsonProperty("RecordingDate")]
        public DateTime RecordingDate { get; set; }

        [JsonProperty("Duration")]
        public int Duration { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Attendees")]
        public int Attendees { get; set; }


    }
}
