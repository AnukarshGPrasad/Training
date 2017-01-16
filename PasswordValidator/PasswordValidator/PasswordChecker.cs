using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PasswordValidator
{

    public class PasswordChecker
    {
        public int Verify(string PasswardInput , string UserType)
        {
            if(UserType == "Internal")
            {
                PasswordCheckerInternal ObjectForInternalClass = new PasswordCheckerInternal();
                int Output = ObjectForInternalClass.Verify(PasswardInput);
                return Output;         
            }
            if (UserType == "External")
            {
                PasswordCheckerExternal ObjectForExternalClass = new PasswordCheckerExternal();
                int output = ObjectForExternalClass.Verify(PasswardInput);
                return output;
            }
            else
                throw new ConditionFailedException("Wrong Class Called");
        }
    }


    public class PasswordCheckerInternal : PasswordChecker
    {
        public int Verify(string PasswordGiven)
        {
            if (PasswordGiven.Length >= 8)
                return 1;
            else
                return 0;
        }

    }

    public class PasswordCheckerExternal : PasswordChecker
    {
        private  bool _statusIsNull = true;
        private  bool _statusIsShort = true;
        private  bool _statusNoUpperCase = true;
        private bool _statusNoLowerCase = true;
        private bool _statusNoNumber = true;
        private int TestCasesPassed = 0;
        public void VerifyConditions(string Password)
        {
            if (Password != null)
            {
                _statusIsNull = false;
            }
            if (Password.Length > 8)
            {
                _statusIsShort = false;
            }
            for (int i = 0; i < Password.Length; i++)
            {
                if (Char.IsUpper(Password[i]))
                {
                    _statusNoUpperCase = false;
                }

                if (Char.IsLower(Password[i]))
                {
                    _statusNoLowerCase = false;
                }

                if (Char.IsNumber(Password[i]))
                {
                    _statusNoNumber = false;
                }
            }
        }

        public int Verify(string PasswordGiven)
        {

            VerifyConditions(PasswordGiven);

            if (!_statusIsNull)
            {
                TestCasesPassed++;
            }
            else
            {
                throw new ConditionFailedException("Password is Null");
            }
            if (!_statusIsShort)
            {
                TestCasesPassed++;
            }
            else
            {
                throw new ConditionFailedException("Password is too short");
            }
            if (!_statusNoUpperCase)
            {
                TestCasesPassed++;
            }
            else
            {
                throw new ConditionFailedException("Password has no upper case");
            }
            if (!_statusNoLowerCase)
            {
                TestCasesPassed++;
            }
            else
            {
                throw new ConditionFailedException("Password has no lower case");
            }
            if (!_statusNoNumber)
            {
                TestCasesPassed++;
            }
            else
            {
                throw new ConditionFailedException("Password has no number");
            }


            if (_statusNoUpperCase == false && TestCasesPassed >= 3)
                return 1;
            else
                return 0;
        }
    }

    public class ConditionFailedException : Exception
    {
        public ConditionFailedException(string message) : base(message)
        {
        }
    }
}
