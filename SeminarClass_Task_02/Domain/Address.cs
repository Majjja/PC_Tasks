using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Address
    {
        public int Id { get; private set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}
