using System;
using NUnit.Framework;  // NUnit
using FakeItEasy;      // For mocking with FakeItEasy
using UnitTestIntro;   // Reference to your main project

namespace UnitTestIntro.Tests
{
    [TestFixture]
    public class EmailValidationServiceTests
    {
        [TestCase("sadsadas", false)]
        [TestCase("sadsadas", false)]
        [TestCase("abcd@", false)]
        [TestCase("abcd@.", false)]
        [TestCase("abcd.com", false)]
        [TestCase("abcd@com", false)]
        [TestCase("abcd@mo.com", true)]
        [TestCase("abcd@mo.co.uk", true)]
        [TestCase("abcd@mo.org.uk", true)]
        [TestCase("", false)]
        [TestCase(null, false)]
        public void EmailIsValid(string emailAddress, bool isValid)
        {
            var emailService = new EmailValidationService();
            var result = emailService.Valid(emailAddress);
            Assert.That(isValid, Is.EqualTo(result));
        }
    }
}