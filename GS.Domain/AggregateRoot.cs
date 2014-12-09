using System;

namespace GS.Domain
{
    public abstract class AggregateRoot<T> : AggregateRoot
    {
        public T Id { get; protected set; }
    }

    public abstract class AggregateRoot
    {
        public DateTime CreatedAt { get; protected set; }
    }
}
