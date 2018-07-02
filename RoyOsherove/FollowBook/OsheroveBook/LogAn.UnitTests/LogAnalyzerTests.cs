using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAn.UnitTests
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        [Test]
        public void IsValidFileName_NameSupportedExtension_ReturnsTrue()
        {
            FakeExtensionManager manager = new FakeExtensionManager();
            manager.WillBeValid = true;

            LogAnalyzer logAnalyzer = new LogAnalyzer(manager);
            bool result = logAnalyzer.IsValidLogFileName("short.ext");
            Assert.True(result);
        }

        [Test]
        public void overrideTest()
        {
            FakeExtensionManager stub = new FakeExtensionManager();
            stub.WillBeValid = true;

            TestableLogAnalyzer logAnalyzer = new TestableLogAnalyzer(stub);
            bool result = logAnalyzer.IsValidLogFileName("file.txt");
            Assert.True(result);
        }
    }

    class TestableLogAnalyzer: LogAnalyzerUsingFactoryMethod
    {
        public IExtensionManager manager;

        public TestableLogAnalyzer(IExtensionManager manager)
        {
            this.manager = manager;
        }

        protected override IExtensionManager GetManager()
        {
            return this.manager;
        }
    }

    internal class FakeExtensionManager : IExtensionManager
    {
        public bool WillBeValid = false;

        public bool IsValid(string fileName)
        {
            return WillBeValid;
        }
    }
}
