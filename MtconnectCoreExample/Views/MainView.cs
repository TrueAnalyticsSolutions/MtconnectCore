using ConsoulLibrary;
using ConsoulLibrary.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace MtconnectCoreExample.Views
{
    public class MainView : StaticView
    {
        public MainView()
        {
            Title = (new BannerEntry($"MTConnect Example")).Message;
        }

        [ViewOption("Test MTConnect Probe request")]
        public void TestProbe()
        {
            var view = new ProbeRequestView();
            view.Run();
        }

        [ViewOption("Test MTConnect Current request")]
        public void TestCurrent()
        {
            var view = new CurrentRequestView();
            view.Run();
        }

        [ViewOption("Test MTConnect Sample request")]
        public void TestSample()
        {
            var view = new SampleRequestView();
            view.Run();
        }

        [ViewOption("Test MTConnect Assets request")]
        public void TestAssets()
        {
            var view = new AssetsRequestView();
            view.Run();
        }

        [ViewOption("Test MTConnect Current Interval request")]
        public void TestCurrentInterval()
        {
            var view = new CurrentIntervalRequestView();
            view.Run();
        }

        [ViewOption("Test MTConnect Raw File validation")]
        public void TestRawFile()
        {
            var view = new TestFileView();
            view.Run();
        }

        [ViewOption("Audit MTConnect Agent")]
        public void AuditAgent()
        {
            var view = new AuditView();
            view.Run();
        }
    }
}
