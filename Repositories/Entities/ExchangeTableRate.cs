using Newtonsoft.Json;

namespace Repositories.Entities
{
    public class ExchangeTableRate
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("mid")]
        public double Mid { get; set; }
    }
}
