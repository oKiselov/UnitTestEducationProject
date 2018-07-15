using Chapter2.FileNameRules;
using NSubstitute;
using NUnit.Framework;

namespace LogAn.UnitTests
{
    [TestFixture]
    public class LogAnalyzerFakeRulesTests
    {
        // usage as stub 
        [Test]
        public void Returns_ByDefault_WorksForHardCodedArgument()
        {
            IFileNameRules fakeRules = NSubstitute.Substitute.For<IFileNameRules>();
            fakeRules.IsValideLogFileName("strict.txt").Returns(true);
            Assert.IsTrue(fakeRules.IsValideLogFileName("strict.txt"));
        }

        // argument matcher - to use Arg class 
        [Test]
        public void Returns_ByDefault_WorksForHardCodedArgument_Refactored()
        {
            IFileNameRules fakeRules = Substitute.For<IFileNameRules>();
            fakeRules.IsValideLogFileName(Arg.Any<string>()).Returns(true);
            Assert.IsTrue(fakeRules.IsValideLogFileName("anything.SLF"));
        }

        // throw an exception
        [Test]
        public void Returns_ArgAny_Throws()
        {
            IFileNameRules fakeRules = Substitute.For<IFileNameRules>();
            fakeRules
                .When(x => x.IsValideLogFileName(Arg.Any<string>()))
                .Do(context => { throw new System.Exception("fake exception"); });

            Assert.Throws<System.Exception>(() => fakeRules.IsValideLogFileName("anything"));
        }
    }
}
