﻿using System;

namespace tinc.Dto
{
    public class Result : Organization
    {
        public Guid ID { get; set; }
        public virtual Competition Competition { get; set; }
        public virtual Category Category { get; set; }
    }
}