﻿using Newtonsoft.Json;

namespace Repositories.Entities
{
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
}
