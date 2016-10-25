using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sheep.VHall.Handlers
{
    public class DataFilterHandler
    {
        public static string JsonFilter(string source)
        {
            return Regex.Match(source, ".*?({[^}+].+}).*?")?.Groups[1].Value;
        }
    }
}
