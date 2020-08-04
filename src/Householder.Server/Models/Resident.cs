using Newtonsoft.Json;

namespace Householder.Server.Models
{
    public class Resident
    {
        [JsonProperty("name")]
        public string Name { get; }

        [JsonConstructor]
        public Resident(string name)
        {
            Name = name;
        }
    }
}