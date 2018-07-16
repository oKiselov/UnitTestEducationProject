using Chapter2.EventActivities;
using Chapter2.LogAnalyzer3;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAn.UnitTests.EventActivitiesTests
{
    [TestFixture]
    public class EventRelatedTests
    {
        // testing the event listener
        [Test]
        public void ctor_WhenViewIsLoaded_CallsViewRender()
        {
            var mockView = NSubstitute.Substitute.For<IView>();
            Presenter presenter = new Presenter(mockView);

            // trigger event using NSub
            mockView.Loaded += Raise.Event<Action>();

            // Check that the view was called
            mockView.Received().Render(Arg.Is<string>(s => s.Contains("Hello World")));
        }

        [Test]
        public void ctor_WhenViewhasError_CallsLogger()
        {
            var stubView = Substitute.For<IView>();
            var mockLogger = Substitute.For<ILogger3>();

            Presenter2 presenter = new Presenter2(stubView, mockLogger);

            stubView.ErrorOccured += Raise.Event<Action<string>>("fake error");

            mockLogger.Received().LogError(Arg.Is<string>(s => s.Contains("fake error")));
        }

        // testing an event was triggered
        [Test]
        public void EventFiringManual()
        {
            bool loadFired = false;
            SomeView view = new SomeView();
            view.Loaded += delegate
                {
                    loadFired = true;
                };
            view.DoSomeThing();
            Assert.IsTrue(loadFired);
        }
    }

    public class SomeView : IView
    {
        public event Action Loaded;
        public event Action<string> ErrorOccured;

        public void Render(string text)
        {
            throw new NotImplementedException();
        }

        public void DoSomeThing()
        {
            Loaded.Invoke();
        }
    }
}
