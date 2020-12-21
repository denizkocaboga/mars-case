namespace MarsExplorer.InputValidator
{
    public interface IInputValidator
    {
        IValidationResult Validate(string input);
    }
}
