using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemApp.Models
{
    internal class Cinema:Entity
    {
        public string Name { get; set; }
        public List<Hall> Halls { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}\tName: {Name}";
        }
    }
}
