using hw_2.WebApi;

namespace WebApi.Validators
{
    public class UserCreateValidator : IValidator<UserCreateDto>
    {
        public ValidationResult Validate(UserCreateDto request)
        {
            var validatioResult = new ValidationResult();

            if (request.FirstName.Length > 15)
            {
                validatioResult.Errors.Add("FirstName is long.");
            }
            if (request.FirstName.Length < 3)
            {
                validatioResult.Errors.Add("FirstName is short.");
            }
            if (request.LastName.Length > 15)
            {
                validatioResult.Errors.Add("LastName is long.");
            }
            if (request.LastName.Length < 3)
            {
                validatioResult.Errors.Add("LastName is short.");
            }

            if (validatioResult.Errors.Count == 0)
            {
                validatioResult.IsValid = true;
            }

            return validatioResult;
        }

    }

 }
