using CosoleApp;
using Moq;

namespace TDD_Tests
{
    public class PasswordTests
    {
        /*
        * Aceptance Criteria:
        * - Min. Length -> 8
        * - Include UpperCase
        */

        [Fact]
        public void Validate_GivenLongerThan8Char_ReturnTrue()
        {

            var passwordValidator = new PasswordValidator();
            var password = MakeStringLowerCase(9)+"A";
            var result = passwordValidator.Validate(password);

            Assert.True(result);
        }

        [Fact]
        public void Validate_GivenShorterThan8Char_ReturnFalse()
        {

            var passwordValidator = new PasswordValidator();
            var password = MakeStringUperLowerCase(4);
            var result = passwordValidator.Validate(password);

            Assert.False(result);
        }

        [Fact]
        public void Validate_GivenPassWithUppercase_ReturnTrue()
        {

            var passwordValidator = new PasswordValidator();
            var password = MakeStringUperLowerCase(9);
            var result = passwordValidator.Validate(password);

            Assert.True(result);
        }

        [Fact]
        public void Validate_GivenPassWithoutUppercase_ReturnTrue()
        {

            var passwordValidator = new PasswordValidator();
            var password = MakeStringLowerCase(9);
            var result = passwordValidator.Validate(password);

            Assert.False(result);
        }


        private string MakeStringLowerCase(int length)
        {
            string result = "";
            for (int i = 0; i < length; i++)
                result += "a";
            return result;
        }

        private string MakeStringUperCase(int length)
        {
            string result = "";
            for (int i = 0; i < length; i++)
                result += "A";
            return result;
        }

        private string MakeStringUperLowerCase(int length)
        {
            string result = "";
            for (int i = 0; i < length; i++)
            {
                if(i%2 == 0) result += "A";
                else result += "a";
            }
            return result;
        }
    }
}