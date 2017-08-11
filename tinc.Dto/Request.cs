using System;

namespace tinc.Dto
{
    public class Request
    {
        public Guid ID { get; set; }

        public string RequestType { get; set; }
        public string Subject { get; set; }

        public DateTime RequestDate { get; set; }
    }
}
