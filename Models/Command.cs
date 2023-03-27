using System.Collections.Generic;

namespace Visual_PowerShell.Models
{
    public class Command
    {
        public string Name { get; set; }
        public List<string> Scripts { get; set; } = new List<string>();
    }
}
