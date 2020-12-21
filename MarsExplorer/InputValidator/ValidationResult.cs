namespace MarsExplorer.InputValidator
{
    public interface IValidationResult
    {
        bool IsValid { get; set; }
        string Message { get; set; }
    }
    public class ValidationResult : IValidationResult
    {
        public bool IsValid { get; set; }
        public string Message { get; set; }
    }
}