using System.ComponentModel.DataAnnotations;

namespace WebApi.Validators
{
    public interface IValidator<T> where T : class
    {
        ValidationResult Validate(T request);
    }

}
