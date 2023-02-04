using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemApp.Models
{
    internal class Ticket:Entity
    {
        public Session Session { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }

        public override string ToString()
        {
            return $"{Session}\n{Row}x{Column}";
        }
    }
}
