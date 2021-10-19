using System;
using System.Collections.Generic;

#nullable disable

namespace Equipment.Models
{
    public partial class Equipment
    {
        public Equipment()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int EquipmentId { get; set; }
        public string Type { get; set; }
        public bool IsAvailable { get; set; }
        public string EquipmentName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
