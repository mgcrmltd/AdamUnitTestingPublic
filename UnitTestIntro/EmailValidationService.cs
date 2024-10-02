
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
            return true;
        }
    }
}
