using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visual_PowerShell.Models
{
    public class Command
    {
        public string Name { get; set; }
        public List<string> Scripts { get; set; }
    }
}
