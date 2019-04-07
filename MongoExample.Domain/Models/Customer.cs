using System;

namespace MongoExample.Domain.Models
{
    public class Customer : BaseModel
    {
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
    }
}
