using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Abstractions
{
    public abstract class Aggregate<TId> : Entity<TId>, IAggregate<TId>
    {
        private readonly List<IDomainEvent> _domainsEvents = new();
        public IReadOnlyList<IDomainEvent> DomainEvents => _domainsEvents.AsReadOnly();

        public void AddDomainEvent(IDomainEvent domainEvent) { 
        _domainsEvents.Add(domainEvent);
        }
        
        
        public IDomainEvent[] ClearDomainEvents()
        {
            IDomainEvent[] dequeuedEvents = _domainsEvents.ToArray();  
            _domainsEvents.Clear();
            return dequeuedEvents;
        }


    }
}
