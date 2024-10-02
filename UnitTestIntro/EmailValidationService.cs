using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //Call external web service
        }
    }
}
