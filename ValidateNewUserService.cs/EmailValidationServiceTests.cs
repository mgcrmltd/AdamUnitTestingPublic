using System;
using NUnit.Framework;  // NUnit
using FakeItEasy;      // For mocking with FakeItEasy
using UnitTestIntro;   // Reference to your main project

namespace UnitTestIntro.Tests
{
    [TestFixture]
    public class EmailValidationServiceTests
    {
        private IEmailValidationService _fakeEmailValidationService;

        [SetUp]
        public void SetUp()
        {
            // Create a fake IEmailValidationService using FakeItEasy
            _fakeEmailValidationService = A.Fake<IEmailValidationService>();
        }

        // Test 1: Valid email should return true
        [Test]
        public void EmailValidationService_ValidEmail_ReturnsTrue()
        {
            // Arrange: Set up the fake method to return true for a valid email
            A.CallTo(() => _fakeEmailValidationService.Valid("test@example.com")).Returns(true);

            // Act: Call the Valid method
            var result = _fakeEmailValidationService.Valid("test@example.com");

            // Assert: Ensure that the method returns true
            Assert.That(result, Is.True);
        }

        // Test 2: Invalid email should return false
        [Test]
        public void EmailValidationService_InvalidEmail_ReturnsFalse()
        {
            // Arrange: Set up the fake method to return false for an invalid email
            A.CallTo(() => _fakeEmailValidationService.Valid("invalid-email")).Returns(false);

            // Act: Call the Valid method
            var result = _fakeEmailValidationService.Valid("invalid-email");

            // Assert: Ensure that the method returns false
            Assert.That(result, Is.False);
        }

        // Test 3: Check that Valid is called with a specific argument
        [Test]
        public void EmailValidationService_ValidEmail_CallsValidMethod()
        {
            // Arrange: Set up the fake method to return true
            A.CallTo(() => _fakeEmailValidationService.Valid(A<string>.Ignored)).Returns(true);

            // Act: Call the Valid method with a valid email
            _fakeEmailValidationService.Valid("test@example.com");

            // Assert: Ensure that the Valid method was called with the specified email
            A.CallTo(() => _fakeEmailValidationService.Valid("test@example.com")).MustHaveHappened();
        }
        [Test]
        public void EmailValidationService_ThrowsException_WhenEmailValidationFails()
        {
            // Arrange: Set up the fake method to throw an exception
            A.CallTo(() => _fakeEmailValidationService.Valid("test@example.com"))
                .Throws(new InvalidOperationException("Email validation failed"));

            var service = new ValidateNewUserService(_fakeEmailValidationService);

            // Act & Assert: Ensure that the exception is thrown when Email is called
            Assert.Throws<InvalidOperationException>(() => service.Email("test@example.com"));
        }
    }
}