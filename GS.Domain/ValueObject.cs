namespace GS.Domain
{
    public abstract class StringValueObject<ObjectT> : ValueObject<ObjectT,string>
        where ObjectT : class
    {
    }

    public abstract class ValueObject<ObjectT,IdT> : ValidatableObject<ObjectT>
        where ObjectT : class 
    {
        public IdT Value { get; protected set; }

        public override string ToString()
        {
            return string.Format("{0} ({1})", GetType().Name, Value);
        }

        public override bool Equals(object obj)
        {
            var typed = obj as ValueObject<ObjectT, IdT>;

            if (typed == null)
                return false;

            return typed.Value.Equals(Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
