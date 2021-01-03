using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public abstract class BaseClass
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
