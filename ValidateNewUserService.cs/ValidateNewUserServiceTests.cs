using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;  // MSTest
using NUnit.Framework;  // NUnit
using UnitTestIntro;    // Reference to the main project

namespace UnitTestIntro.Tests
{
   
    [TestFixture]
    public class ValidateNewUserServiceNUnitTests
    {
        private ValidateNewUserService _service;

        [SetUp]
        public void SetUp()
        {
            _service = new ValidateNewUserService();
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

        
        [Test]
        public void Email_ThrowsNotImplementedException()
        {
            Assert.Throws<NotImplementedException>(() => _service.Email("test@example.com"));
        }
    }

    
} 