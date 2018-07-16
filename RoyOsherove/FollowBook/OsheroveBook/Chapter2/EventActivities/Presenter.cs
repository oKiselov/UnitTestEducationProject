using Chapter2.LogAnalyzer3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter2.EventActivities
{
    public class Presenter
    {
        private readonly IView view;

        public Presenter(IView view)
        {
            this.view = view;
            this.view.Loaded += OnLoaded;
        }

        private void OnLoaded()
        {
            view.Render("Hello World");
        }
    }

    public class Presenter2
    {
        private readonly IView _view;
        private readonly ILogger3 _log;

        public Presenter2(IView view, ILogger3 log)
        {
            _view = view;
            _log = log;
            this._view.Loaded += OnLoaded;
            this._view.ErrorOccured += OnError;
        }

        private void OnError(string text)
        {
            _log.LogError(text);
        }

        private void OnLoaded()
        {
            _view.Render("Hello World");
        }
    }
}
