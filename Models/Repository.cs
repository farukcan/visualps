using Newtonsoft.Json;
using System.Collections.Generic;

namespace Visual_PowerShell.Models
{
    public class Repository
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Website { get; set; }
        [JsonIgnore]
        public string Address { get; set; } = "No Address";
        public List<Command> Commands { get; set; } = new List<Command>();
    }
}