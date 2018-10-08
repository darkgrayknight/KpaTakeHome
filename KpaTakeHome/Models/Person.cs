using System.Collections.Generic;

namespace KpaTakeHome.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        private Person() { }

        public Person(IReadOnlyList<string> values) : this(values[0], values[1], values[2]) { }

        private Person(string email, string first, string last)
        {
            Email = email;
            FirstName = first;
            LastName = last;
        }
    }
}