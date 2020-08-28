using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Householder.Server.Models
{
    public class Reconciliation
    {
        [JsonProperty("id")]
        public int ID { get; }
        [JsonProperty("creator")]
        public Resident Creator { get; }
        [JsonProperty("action_date")]
        public DateTime CreationDate { get; }

        public Reconciliation(Resident creator, DateTime creationDate)
        {
            ID = -1;
            Creator = creator;
            CreationDate = creationDate;
        }

        [JsonConstructor]
        public Reconciliation(int id, Resident creator, DateTime creationDate)
        {
            ID = id;
            Creator = creator;
            CreationDate = creationDate;
        }
    }
}