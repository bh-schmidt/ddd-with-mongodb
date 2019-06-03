using System;
using System.Collections.Generic;

namespace MongoExample.Domain.Models.Customers
{
    public class Customer : BaseModel
    {
        public string Name { get; set; }
        public DateTime? BirthDay { get; set; }
    }
}
