using Ordering.Domain.Abstraction;
using Ordering.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Events;

    public class OrderUpdatedEvent(Order order):IDomainEvent
    {
    }

