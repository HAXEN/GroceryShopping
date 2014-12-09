namespace GS.Domain
{
    public abstract class ValueObject<T> : ValueObject
    {
        public T Value { get; protected set; }
    }

    public abstract class ValueObject : IValidatable
    {
        public bool IsValid()
        {
            
        }
    }
}
