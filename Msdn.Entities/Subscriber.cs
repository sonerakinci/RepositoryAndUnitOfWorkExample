using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msdn.Entities
{
    public class Subscriber
    {
        [Key]
        public Guid SubscriberId { get; set; }
        [MaxLength(75)]
        public string FullName { get; set; }
        public DateTime RegisterationDate { get; set; }
        public bool IsActive { get; set; }

        public virtual Address Address { get; set; }
    }
}
