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

    public class ExchangeTableRate
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("mid")]
        public double Mid { get; set; }
    }

    public class NbpModel
    {
        [JsonProperty("table")]
        public string Table { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("rates")]
        public Rate[] Rates { get; set; }
    }

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
