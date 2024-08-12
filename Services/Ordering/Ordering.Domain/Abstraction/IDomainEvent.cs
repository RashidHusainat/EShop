using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Abstraction
{
    public interface IDomainEvent
    {
        Guid EventId => Guid.NewGuid();

        public string Type => GetType().AssemblyQualifiedName;

        public DateTime OccuredOn => DateTime.Now;
    }
}
