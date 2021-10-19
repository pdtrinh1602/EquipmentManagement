using System;
using System.Collections.Generic;

#nullable disable

namespace Equipment.Models
{
    public partial class Ticket
    {
        public int UserId { get; set; }
        public int EquipmentId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public virtual Equipment Equipment { get; set; }
        public virtual User User { get; set; }
    }
}
