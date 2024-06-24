using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Abstractions
{
    public interface  IDomainEvent : INotification
    {
        Guid EvenId => Guid.NewGuid();
        public DateTime OccrredOn => DateTime.Now;

        public string EventType => GetType().AssemblyQualifiedName;
    }
}
