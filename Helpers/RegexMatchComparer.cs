using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Visual_PowerShell.Helpers
{
    internal class RegexMatchComparer : IEqualityComparer<Match>
    {
        bool IEqualityComparer<Match>.Equals(Match x, Match y)
        {
            return x.Value == y.Value;
        }

        int IEqualityComparer<Match>.GetHashCode(Match obj)
        {
            return obj.Value.GetHashCode();
        }
    }
}
