using Newtonsoft.Json;

namespace Householder.Server.Models
{
    public class Resident
    {
        [JsonProperty("id")]
        public int ID { get; }
        [JsonProperty("name")]
        public string Name { get; }

        public Resident(string name)
        {
            ID = -1;
            Name = name;
        }

        [JsonConstructor]
        public Resident(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}