using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemApp.Models
{
    internal class Hall:Entity
    {
        public string Name { get; set; }
        public int RowCount { get; set; }
        public int ColumnCount { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name} {RowCount}x{ColumnCount}";
        }
    }
}
