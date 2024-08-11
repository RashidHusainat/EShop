﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Abstraction
{
    public class Entity<T> : IEntity<T>
    {
        public T Id { get ; set ; }
        public DateTime? CreateAt { get; set; }
        public string? CreatedBy { get; set; }
        public string? LastModifiedBy { get; set ; }
        public DateTime? LastModifiedAt { get ; set; }
    }
}
