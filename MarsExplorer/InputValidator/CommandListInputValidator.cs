using MarsExplorer.Enums;
using System;
using System.Linq;

namespace MarsExplorer.InputValidator
{

    public class CommandListInputValidator : IInputValidator
    {
        public IValidationResult Validate(string input)
        {
            char[] commands = input?.Trim()?
                                    .Replace(" ", string.Empty)?
                                    .Select(p => p)?
                                    .ToArray()
                                    ?? new char[] { };
            ValidationResult result = new ValidationResult() { IsValid = true };
            if (!commands.Any())
            {
                result.IsValid = false;
                result.Message = "There is no any command!";
            }
            else
            {
                char[] validCommands = Enum.GetValues(typeof(CommandType))
                                           .Cast<CommandType>()
                                           .Select(p => (char)p)
                                           .ToArray();

                char[] invalidCommands = commands.Where(p => !validCommands.Contains(p)).ToArray();

                if (invalidCommands.Any())
                {
                    result.IsValid = false;
                    result.Message = $"Invalid commands: '{string.Join(string.Empty, invalidCommands)}'";
                }
            }

            return result;
        }
    }
}
