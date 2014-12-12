using System;

using FluentValidation;

namespace GS.Domain
{
    public abstract class ValidatableObject<T> : IValidatable
        where T : class 
    {
        protected ValidatableObjectValidator Validator;

        protected ValidatableObject()
        {
            Validator = new ValidatableObjectValidator();
        }

        public bool IsValid()
        {
            return Validator.Validate(Instance()).IsValid;
        }

        protected T Instance()
        {
            return (T)Convert.ChangeType(this, typeof(T));
        }

        protected class ValidatableObjectValidator : AbstractValidator<T>
        {
             
        }
    }
}