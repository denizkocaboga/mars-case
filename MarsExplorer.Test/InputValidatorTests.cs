using MarsExplorer.Driver;
using MarsExplorer.InputValidator;
using NUnit.Framework;

namespace MarsExplorer.Test
{
    public class InputValidatorTests
    {
        private IFactory _factory;

        [SetUp]
        public void Setup()
        {
            _factory = new Factory();
        }

        #region PlatoInputValidator        
        [Test]
        public void PlatoInputValidator_Validate_Should_Confirm_When_Input_Is_Valid()
        {
            IInputValidator validator = _factory.GetInputValidator<IPlato>();

            string input = "7 5";

            IValidationResult result = validator.Validate(input);

            Assert.IsTrue(result.IsValid);
            Assert.That(result.Message, Is.Null.Or.Empty);
        }

        [Test]
        public void PlatoInputValidator_Validate_Should_Trim_And_Confirm_When_Input_Have_SpaceAtBegining_Or_End()
        {
            IInputValidator validator = _factory.GetInputValidator<IPlato>();

            string input = "    7 5   ";

            IValidationResult result = validator.Validate(input);

            Assert.IsTrue(result.IsValid);
            Assert.That(result.Message, Is.Null.Or.Empty);
        }

        [Test]
        public void PlatoInputValidator_Validate_Should_Confirm_When_ThereIs_MultipleSpaceBetween_X_And_Y()
        {
            IInputValidator validator = _factory.GetInputValidator<IPlato>();

            string input = "5  5";

            IValidationResult result = validator.Validate(input);

            Assert.IsTrue(result.IsValid);
            Assert.That(result.Message, Is.Null.Or.Empty);
        }

        [Test]
        public void PlatoInputValidator_Validate_Should_Not_Confirm_When_Imput_Is_Null()
        {
            IInputValidator validator = _factory.GetInputValidator<IPlato>();

            string input = null;

            IValidationResult result = validator.Validate(input);

            Assert.IsFalse(result.IsValid);
            Assert.That(result.Message, Is.Not.Null.Or.Not.Empty);
        }

        [Test]
        public void PlatoInputValidator_Validate_Should_Not_Confirm_When_Imput_Is_Empty()
        {
            IInputValidator validator = _factory.GetInputValidator<IPlato>();

            string input = null;

            IValidationResult result = validator.Validate(input);

            Assert.IsFalse(result.IsValid);
            Assert.That(result.Message, Is.Not.Null.Or.Not.Empty);
        }

        [Test]
        public void PlatoInputValidator_Validate_Should_Not_Confirm_When_Imput_Contains_Letter()
        {
            IInputValidator validator = _factory.GetInputValidator<IPlato>();

            string input = "5 A";

            IValidationResult result = validator.Validate(input);

            Assert.IsFalse(result.IsValid);
            Assert.That(result.Message, Is.Not.Null.Or.Not.Empty);
        }

        [Test]
        public void PlatoInputValidator_Validate_Should_Not_Confirm_When_ThereIsNo_SpaceBetween_X_And_Y()
        {
            IInputValidator validator = _factory.GetInputValidator<IPlato>();

            string input = "55";

            IValidationResult result = validator.Validate(input);

            Assert.IsFalse(result.IsValid);
            Assert.That(result.Message, Is.Not.Null.Or.Not.Empty);
        }

        [Test]
        public void PlatoInputValidator_Validate_Should_Not_Confirm_When_ThereIs_MoreAxis_OtherThen_X_And_Y()
        {
            IInputValidator validator = _factory.GetInputValidator<IPlato>();

            string input = "5 9 8";

            IValidationResult result = validator.Validate(input);

            Assert.IsFalse(result.IsValid);
            Assert.That(result.Message, Is.Not.Null.Or.Not.Empty);
        }
        #endregion

        #region PositionInputValidator        
        [Test]
        public void PositionInputValidator_Validate_Should_Confirm_When_Input_Is_Valid()
        {
            IInputValidator validator = _factory.GetInputValidator<IPosition>();

            string input = "7 5 E";

            IValidationResult result = validator.Validate(input);

            Assert.IsTrue(result.IsValid);
            Assert.That(result.Message, Is.Null.Or.Empty);
        }

        [Test]
        public void PositionInputValidator_Validate_Should_Trim_And_Confirm_When_Input_Have_SpaceAtBegining_Or_End()
        {
            IInputValidator validator = _factory.GetInputValidator<IPosition>();

            string input = "    7 5 N ";

            IValidationResult result = validator.Validate(input);

            Assert.IsTrue(result.IsValid);
            Assert.That(result.Message, Is.Null.Or.Empty);
        }

        [Test]
        public void PositionInputValidator_Validate_Should_Confirm_When_Input_UpperCase_Or_LoverCase()
        {
            IInputValidator validator = _factory.GetInputValidator<IPosition>();

            string input = "7 5 s";

            IValidationResult result = validator.Validate(input);

            Assert.IsTrue(result.IsValid);
            Assert.That(result.Message, Is.Null.Or.Empty);

            input = "7 5 S";

            result = validator.Validate(input);

            Assert.IsTrue(result.IsValid);
            Assert.That(result.Message, Is.Null.Or.Empty);
        }

        [Test]
        public void PositionInputValidator_Validate_Should_Confirm_When_ThereIs_MultipleSpaceBetween_X_And_Y()
        {
            IInputValidator validator = _factory.GetInputValidator<IPosition>();

            string input = "5  5 E";

            IValidationResult result = validator.Validate(input);

            Assert.IsTrue(result.IsValid);
            Assert.That(result.Message, Is.Null.Or.Empty);
        }
        [Test]
        public void PositionInputValidator_Validate_Should_Not_Confirm_When_ThereIs_MultipleSpaceBetween_Y_And_Direction()
        {
            IInputValidator validator = _factory.GetInputValidator<IPosition>();

            string input = "5 5  N";

            IValidationResult result = validator.Validate(input);

            Assert.IsTrue(result.IsValid);
            Assert.That(result.Message, Is.Null.Or.Empty);
        }

        [Test]
        public void PositionInputValidator_Validate_Should_Not_Confirm_When_Imput_Direction_IsNotInDefinedDirections()
        {
            IInputValidator validator = _factory.GetInputValidator<IPosition>();

            string input = "5 5 A";

            IValidationResult result = validator.Validate(input);

            Assert.IsFalse(result.IsValid);
            Assert.That(result.Message, Is.Not.Null.Or.Not.Empty);
        }

        [Test]
        public void PositionInputValidator_Validate_Should_Not_Confirm_When_Imput_Is_Null()
        {
            IInputValidator validator = _factory.GetInputValidator<IPosition>();

            string input = null;

            IValidationResult result = validator.Validate(input);

            Assert.IsFalse(result.IsValid);
            Assert.That(result.Message, Is.Not.Null.Or.Not.Empty);
        }

        [Test]
        public void PositionInputValidator_Validate_Should_Not_Confirm_When_Imput_Is_Empty()
        {
            IInputValidator validator = _factory.GetInputValidator<IPosition>();

            string input = null;

            IValidationResult result = validator.Validate(input);

            Assert.IsFalse(result.IsValid);
            Assert.That(result.Message, Is.Not.Null.Or.Not.Empty);
        }

        [Test]
        public void PositionInputValidator_Validate_Should_Not_Confirm_When_Imput_XorY_Contains_Letter()
        {
            IInputValidator validator = _factory.GetInputValidator<IPosition>();

            string input = "5 N E";

            IValidationResult result = validator.Validate(input);

            Assert.IsFalse(result.IsValid);
            Assert.That(result.Message, Is.Not.Null.Or.Not.Empty);
        }

        [Test]
        public void PositionInputValidator_Validate_Should_Not_Confirm_When_ThereIsNo_SpaceBetween_X_And_Y()
        {
            IInputValidator validator = _factory.GetInputValidator<IPosition>();

            string input = "55 E";

            IValidationResult result = validator.Validate(input);

            Assert.IsFalse(result.IsValid);
            Assert.That(result.Message, Is.Not.Null.Or.Not.Empty);
        }

        [Test]
        public void PositionInputValidator_Validate_Should_Not_Confirm_When_ThereIsNo_SpaceBetween_Y_And_Direction()
        {
            IInputValidator validator = _factory.GetInputValidator<IPosition>();

            string input = "5 5E";

            IValidationResult result = validator.Validate(input);

            Assert.IsFalse(result.IsValid);
            Assert.That(result.Message, Is.Not.Null.Or.Not.Empty);
        }       

        [Test]
        public void PositionInputValidator_Validate_Should_Not_Confirm_When_ThereIs_MoreAxis_OtherThen_X_And_Y_Direction()
        {
            IInputValidator validator = _factory.GetInputValidator<IPosition>();

            string input = "5 9 S 7";

            IValidationResult result = validator.Validate(input);

            Assert.IsFalse(result.IsValid);
            Assert.That(result.Message, Is.Not.Null.Or.Not.Empty);
        }
        #endregion

        #region CommandListInputValidator        
        [Test]
        public void CommandListInputValidator_Validate_Should_Confirm_When_Input_Is_Valid()
        {
            IInputValidator validator = _factory.GetInputValidator<ICommandList>();

            string input = "MLRMRLMMR";

            IValidationResult result = validator.Validate(input);

            Assert.IsTrue(result.IsValid);
            Assert.That(result.Message, Is.Null.Or.Empty);
        }

        [Test]
        public void CommandListInputValidator_Validate_Should_Trim_And_Confirm_When_Input_Have_SpaceAtBegining_Or_End()
        {
            IInputValidator validator = _factory.GetInputValidator<ICommandList>();

            string input = " MRMLMMR ";

            IValidationResult result = validator.Validate(input);

            Assert.IsTrue(result.IsValid);
            Assert.That(result.Message, Is.Null.Or.Empty);
        }

        [Test]
        public void CommandListInputValidator_Validate_ShouldConfirm_When_ThereIs_SpaceBetweenCommands()
        {
            IInputValidator validator = _factory.GetInputValidator<ICommandList>();

            string input = "LML MR";

            IValidationResult result = validator.Validate(input);

            Assert.IsTrue(result.IsValid);
            Assert.That(result.Message, Is.Null.Or.Empty);
        }

        [Test]
        public void CommandListInputValidator_Validate_Should_Not_Confirm_When_Imput_Is_Null()
        {
            IInputValidator validator = _factory.GetInputValidator<ICommandList>();

            string input = null;

            IValidationResult result = validator.Validate(input);

            Assert.IsFalse(result.IsValid);
            Assert.That(result.Message, Is.Not.Null.Or.Not.Empty);
        }

        [Test]
        public void CommandListInputValidator_Validate_Should_Not_Confirm_When_Imput_Is_Empty()
        {
            IInputValidator validator = _factory.GetInputValidator<ICommandList>();

            string input = null;

            IValidationResult result = validator.Validate(input);

            Assert.IsFalse(result.IsValid);
            Assert.That(result.Message, Is.Not.Null.Or.Not.Empty);
        }

        [Test]
        public void CommandListInputValidator_Validate_Should_Not_Confirm_When_Imput_Contains_Numeric()
        {
            IInputValidator validator = _factory.GetInputValidator<ICommandList>();

            string input = "LML5MM";

            IValidationResult result = validator.Validate(input);

            Assert.IsFalse(result.IsValid);
            Assert.That(result.Message, Is.Not.Null.Or.Not.Empty);
        }

        [Test]
        public void CommandListInputValidator_Validate_Should_Not_Confirm_When_CommandsOutOfDefinedCommands()
        {
            IInputValidator validator = _factory.GetInputValidator<ICommandList>();

            string input = "LMMRMSMLM";

            IValidationResult result = validator.Validate(input);

            Assert.IsFalse(result.IsValid);
            Assert.That(result.Message, Is.Not.Null.Or.Not.Empty);
        }
        #endregion

    }
}