using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visual_PowerShell.Models
{
    public  class Repository
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Website { get; set; }
        [JsonIgnore]
        public string Address { get; set; } = "No Address";
        public List<Command> Commands { get; set; } = new List<Command>();
    }
}