using System;

namespace GS.Domain
{
    public abstract class GuidAggregateRoot<ObjectT> : AggregateRoot<ObjectT,Guid>
        where ObjectT : class 
    {
    }

    public abstract class AggregateRoot<ObjectT,T> : ValidatableObject<ObjectT>
        where ObjectT : class 
    {
        public T Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
    }
}
