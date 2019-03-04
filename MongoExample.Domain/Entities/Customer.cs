using System;
using System.Collections.Generic;
using System.Text;

namespace MongoExample.Domain.Entities
{
    public class Customer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
    }
}
