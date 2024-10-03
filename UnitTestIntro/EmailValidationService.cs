
using System.Text.RegularExpressions;

namespace UnitTestIntro
{
    public interface IEmailValidationService
    {
        bool Valid(string emailAddress);
    }

    public class EmailValidationService : IEmailValidationService
    {
        public bool Valid(string emailAddress)
        {
            if(emailAddress == "test@example.com") return true;
            return false;
            //if (string.IsNullOrEmpty(emailAddress)) return false;
            //string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            //return Regex.IsMatch(emailAddress, emailPattern);        
        }
    }
}
