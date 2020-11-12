using System.Collections.Generic;

namespace AuditTable
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastNamee { get; set; }
        public List<Contact> Contacts { get; set; }
    }

    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
