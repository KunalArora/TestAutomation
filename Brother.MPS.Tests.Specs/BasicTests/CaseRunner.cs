using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Brother.Tests.Specs.BasicTests
{
    /// <summary>
    /// Basic tests to prove NUnit command line ability to target individual cases
    /// </summary>
    [TestFixture]
    public class CaseRunner
    {
        [Test]
        [TestCase(1,1,2)]
        [TestCase(1,1,3)]
        public void SumOf(int one, int two, int total)
        {
            var calculated = one + two;
            Assert.That(calculated == total);
        }

        [Test]
        [TestCase("one", "ONE", new string[] { "FOO" })]
        [TestCase("one", "oNe", new string[] { "BAR" })]
        [TestCase("one", "Fish", null)]
        public void StringsEqual(string one, string expected, string[] someNonsense)
        {
            var output = one.ToUpper();
            Assert.That(output == expected);
        }
    }
}
