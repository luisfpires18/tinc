using System;
using System.Collections.Generic;

namespace tinc.Dto
{
    public class Sport : Organization
    {
        public Guid ID { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}