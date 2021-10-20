using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Equipment.Models
{
    public partial class User
    {
        public User()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int UserId { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string UserName { get; set; }
        public bool IsAdmin { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
