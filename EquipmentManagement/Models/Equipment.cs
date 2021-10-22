using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Column(TypeName = "nvarchar(200)")]
        public string Type { get; set; }
        public bool IsAvailable { get; set; } = true;
        [Column(TypeName = "nvarchar(200)")]
        public string EquipmentName { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string Description { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
