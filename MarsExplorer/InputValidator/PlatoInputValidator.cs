using System.Linq;

namespace MarsExplorer.InputValidator
{
    public class PlatoInputValidator : IInputValidator
    {
        public IValidationResult Validate(string input)
        {
            string[] lenghts = input?.Trim()?.Split(" ")?.Where(p => p != " " && p != string.Empty)?.ToArray() ?? new string[] { };

            ValidationResult result = new ValidationResult
            {
                IsValid = lenghts.Count() == 2 && lenghts.Select(p => p.IsNumber()).All(p => p)
            };

            if (!result.IsValid)
                result.Message = "Invalid input for Plato!";

            return result;

        }
    }
}
