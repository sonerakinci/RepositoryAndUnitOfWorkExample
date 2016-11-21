using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msdn.Entities
{
    public class Address
    {
        [Key,ForeignKey("Subscriber")]
        public Guid SubscriberId { get; set; }
        [MaxLength(250)]
        public string Detail { get; set; }

        public virtual Subscriber Subscriber{ get; set; }
    }
}
