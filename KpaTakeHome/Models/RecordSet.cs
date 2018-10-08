using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KpaTakeHome.Models
{
    public class RecordSet
    {
        public int Id { get; set; }
        public List<Person> Persons { get; set; } = new List<Person>();
    }
}
