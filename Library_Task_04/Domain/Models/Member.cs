using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Member : Person
    {
        public MemberType MemberType { get; set; }
        public DateTime MemberDate { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
