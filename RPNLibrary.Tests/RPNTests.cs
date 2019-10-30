using NUnit.Framework;

namespace RPNLibrary.Tests
{
    public class RPNTests
    {

        [TestCase("5 1 2 + 4 * + 3 -", ExpectedResult = "14")]
        [TestCase("3 6 - 2 1 + *", ExpectedResult = "-9")]
        public string Test(string input)
        {
            RPN rpn = new RPN();
            return rpn.Input(input);
        }
    }
}