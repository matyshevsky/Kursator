using Newtonsoft.Json;
using System;

namespace Repositories.Entities
{
    public class Rate
    {
        [JsonProperty("no")]
        public string No { get; set; }

        [JsonProperty("effectiveDate")]
        public DateTime EffectiveDate { get; set; }

        [JsonProperty("mid")]
        public double Mid { get; set; }
    }
}
