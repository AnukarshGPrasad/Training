using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordValidator;

namespace PasswordValidatorTest
{
    [TestClass]
    public class PassCheckTests
    {
        PasswordChecker Obj = new PasswordChecker();
        

        [TestMethod]
        public void PasswordHasUppercaseLowerCaseNumbersNotNullLengthIsGreaterThanEight_Verified_PasswordIsExpected()
        {

            int actual = Obj.Verify("Password123", "External");
            Assert.AreEqual(1, actual, "Password is expected");

        }

        [TestMethod, ExpectedException(typeof(ConditionFailedException))]
        public void PasswordHasNoNullNoLowerCaseNoUpperCase_Verified_ThrowsMultiipleException()
        {

            int actual = Obj.Verify("123", "External");
            Assert.AreEqual(1, actual, "Password is expected");

        }


        [TestMethod]
        public void PasswordIsShortForExternalClass_Verified_ThrowsException()
        {
            try
            {
                Obj.Verify("Aa1","External");
            }
            catch (Exception e)
            {
                Assert.AreEqual("Password is too short", e.Message);
            }
        }

        [TestMethod]
        public void PasswordHasNoLowerCaseForExternalClass_Verified_ThrowsException()
        {
            try
            {
                Obj.Verify("AAAAAAA11233", "External");
            }
            catch (Exception e)
            {
                Assert.AreEqual("Password has no lower case", e.Message);
            }
        }

        [TestMethod]
        public void PasswordIsNullForExternalClass_Verified_ThrowsException()
        {
            try
            {
                Obj.Verify("", "External");
            }
            catch (Exception e)
            {
                Assert.AreEqual("Password is too short", e.Message);
            }
        }

        [TestMethod]
        public void PasswordHasNoUppeCaseForExternalClass_Verified_ThrowsException()
        {
            try
            {
                Obj.Verify("jkdlaflka12", "External");
            }
            catch (Exception e)
            {
                Assert.AreEqual("Password has no upper case", e.Message);
            }
        }

        [TestMethod]
        public void PasswordHasNoNumberForExternalClass_Verified_ThrowsException()
        {
            try
            {
                Obj.Verify("jkdlaflkaAHB","External");
            }
            catch (Exception e)
            {
                Assert.AreEqual("Password has no number", e.Message);
            }
        }
        [TestMethod]
        public void PasswordHasUpperCaseLowerCaseHasNumberForExternalClass_Verified()
        {
            int actual = Obj.Verify("Password123","External");
            Assert.AreEqual(1, actual, "Password Passes the constraints");
        }

        [TestMethod]
        public void PasswordHasUppercaseLowerCaseNumbersNotNullLengthIsGreaterThanEightForInternalClass_Verified_PasswordIsExpected()
        {
            int actual = Obj.Verify("Password123", "Internal");
            Assert.AreEqual(1, actual, "Password Passes the constraints");
        }

        [TestMethod]
        public void PasswordHasNoNumberNotNullNoUpperCaseInternalClass_Verified_PasswordDoesNotPassesConstraints()
        {
            int actual = Obj.Verify("passwo", "Internal");
            Assert.AreEqual(0, actual, "Password does Passes the constraints");
        }
    }
}
