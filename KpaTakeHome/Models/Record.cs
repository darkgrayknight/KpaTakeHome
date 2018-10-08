using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KpaTakeHome.Models
{
    public class Record
    {
        public int Id { get; set; }
        public List<string> FieldDataList { get; set; } = new List<string>();
    }
}
