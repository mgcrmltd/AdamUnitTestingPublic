using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public bool Email(string email)
        {
            throw new NotImplementedException();
        }

        public bool FirstName(string firstname)
        {
            if (string.IsNullOrEmpty(firstname)) return false;
            if(firstname.Length < MinimumFirstNameLength) return false;
            return true;
        }

        public bool LastName(string lastname)
        {
            if(string.IsNullOrEmpty(lastname)) return false;
            if(lastname.Length < MinimumLastNameLength) return false;
            return true;
        }
    }
}
