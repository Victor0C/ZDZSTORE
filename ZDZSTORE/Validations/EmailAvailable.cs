using System.ComponentModel.DataAnnotations;
using ZDZSTORE.User;

namespace ZDZSTORE.Validations
{
    public class EmailAvailable : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return new ValidationResult("Email is required.");
            }

            if (!new EmailAddressAttribute().IsValid(value))
            {
                return new ValidationResult("Invalid email format.");
            }

            var userRepository = validationContext.GetService(typeof(UserRepository)) as UserRepository;

            if (userRepository == null)
            {
                throw new ArgumentException("UserRepository is not available.");
            }

            string email = value.ToString();
            var userTask = userRepository.GetOneByEmail(email);
            userTask.Wait();

            var user = userTask.Result;

            if (user != null)
            {
                return new ValidationResult("Email is already in use.");
            }

            return ValidationResult.Success;
        }
    }
}
