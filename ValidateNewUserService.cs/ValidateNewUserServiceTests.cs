using NUnit.Framework;
using FakeItEasy;
using UnitTestIntro;
using System;

namespace UnitTestIntro.Tests
{
    [TestFixture]
    public class ValidateNewUserServiceNUnitTests
    {
        private ValidateNewUserService _service;
        private IEmailValidationService _fakeEmailValidationService;

        [SetUp]
        public void SetUp()
        {
            // Create a fake IEmailValidationService using FakeItEasy
            _fakeEmailValidationService = A.Fake<IEmailValidationService>();

            // Pass the fake email validation service into the constructor
            _service = new ValidateNewUserService(_fakeEmailValidationService);
        }

        [Test]
        public void Email_Valid_ReturnsTrue()
        {
            A.CallTo(() => _fakeEmailValidationService.Valid("test@example.com")).Returns(true);
            var isValid = _service.Email("test@example.com");
            Assert.That(isValid, Is.EqualTo(true));
        }

        [Test]
        public void Email_Invalid_ReturnsFalse()
        {
            A.CallTo(() => _fakeEmailValidationService.Valid(A<string>._)).Returns(false);
            var isValid = _service.Email("test@example.com");
            Assert.That(isValid, Is.EqualTo(false));
        }

        [Test]
        public void FirstName_Valid_ReturnsTrue()
        {
            var result = _service.FirstName("John");
            Assert.That(result, Is.True);
        }

        [Test]
        public void FirstName_TooShort_ReturnsFalse()
        {
            var result = _service.FirstName("J");
            Assert.That(result, Is.False);
        }

        [Test]
        public void FirstName_Empty_ReturnsFalse()
        {
            var result = _service.FirstName(string.Empty);
            Assert.That(result, Is.False);
        }

        [Test]
        public void LastName_Valid_ReturnsTrue()
        {
            var result = _service.LastName("Doe");
            Assert.That(result, Is.True);
        }

        [Test]
        public void LastName_TooShort_ReturnsFalse()
        {
            var result = _service.LastName("D");
            Assert.That(result, Is.False);
        }

        [Test]
        public void LastName_Empty_ReturnsFalse()
        {
            var result = _service.LastName(string.Empty);
            Assert.That(result, Is.False);
        }

        
    }
}