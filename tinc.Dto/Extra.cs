using System;

namespace tinc.Dto
{
    public class Extra : Organization
    {
        public Guid ID { get; set; }
        public float Price { get; set; }
        public virtual Event Event { get; set; }
    }
}