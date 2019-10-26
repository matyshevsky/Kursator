using Newtonsoft.Json;
using System;

namespace Repositories.Entities
{
    public class ExchangeTable
    {
        [JsonProperty("table")]
        public string Table { get; set; }

        [JsonProperty("no")]
        public string No { get; set; }

        [JsonProperty("effectiveDate")]
        public DateTimeOffset EffectiveDate { get; set; }

        [JsonProperty("rates")]
        public ExchangeTableRate[] Rates { get; set; }
    }
}
