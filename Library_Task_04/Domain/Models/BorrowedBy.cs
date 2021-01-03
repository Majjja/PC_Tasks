using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class BorrowedBy
    {
        public int BorrowedByID { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Issue { get; set; }
        public int BookID { get; set; }
        public virtual Book Book{ get; set; }
        public int MemberID { get; set; }
        public virtual Member Member { get; set; }
    }
}
