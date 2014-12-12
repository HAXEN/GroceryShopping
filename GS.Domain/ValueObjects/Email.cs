using FluentValidation;

namespace GS.Domain
{
    public class Email : StringValueObject<Email>
    {
        protected Email()
        {
            Validator.RuleFor(email => email.Value)
                     .NotNull()
                     .NotEmpty()
                     .EmailAddress();
        }

        public static Email Parse(string email)
        {
            var instance = new Email
                {
                    Value = email,
                };

            if (instance.IsValid() == false)
                return null;

            return instance;
        }
    }
}
