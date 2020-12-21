using MarsExplorer.Enums;
using System;
using System.Linq;

namespace MarsExplorer.InputValidator
{
    public class PositionInputValidator : IInputValidator
    {
        public IValidationResult Validate(string input)
        {
            string[] positionInputs = input?.ToUpperInvariant().Trim()?
                                            .Split(" ")?
                                            .Where(p => p != " " && p != string.Empty)?
                                            .ToArray()
                                            ?? new string[] { };

            ValidationResult result = new ValidationResult();

            if (positionInputs.Count() == 3)
            {
                string x = positionInputs[0];
                string y = positionInputs[1];
                char direction = positionInputs[2][0];

                char[] enums = Enum.GetValues(typeof(Direction))
                                   .Cast<Direction>()
                                   .Select(p => (char)p)
                                   .ToArray();

                result.IsValid = x.IsNumber() && y.IsNumber() && enums.Contains(direction);
            }

            if (!result.IsValid)
                result.Message = "Position input is not valid!";

            return result;
        }
    }
}
