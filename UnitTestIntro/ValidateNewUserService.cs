namespace UnitTestIntro
{
    public interface IValidateNewUserService
    {
        bool Email(string email);
        bool FirstName(string firstname);
        bool LastName(string lastname);
    }

    public class ValidateNewUserService : IValidateNewUserService
    {
        private const int MinimumFirstNameLength = 2;
        private const int MinimumLastNameLength = 2;
        private readonly IEmailValidationService _emailValidationService;

        public ValidateNewUserService()
        {
            _emailValidationService = new EmailValidationService();
        }

        // Updated constructor to accept IEmailValidationService
        public ValidateNewUserService(IEmailValidationService emailValidationService)
        {
            _emailValidationService = emailValidationService;
        }

        // Updated Email method
        public bool Email(string email)
        {
            return _emailValidationService.Valid(email);
        }

        public bool FirstName(string firstname)
        {
            if (string.IsNullOrEmpty(firstname)) return false;
            if (firstname.Length < MinimumFirstNameLength) return false;
            return true;
        }

        public bool LastName(string lastname)
        {
            if (string.IsNullOrEmpty(lastname)) return false;
            if (lastname.Length < MinimumLastNameLength) return false;
            return true;
        }
    }
}
