using System;
using System.Collections.Generic;
using System.Text;

namespace University.AppLogic.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public Guid EntityId { get; private set; }
        public EntityNotFoundException(Guid Id) : base($"Entity with id {Id} was not found")
        {
        }
    }
}
