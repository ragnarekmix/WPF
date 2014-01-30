using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Ciklum.WpfApplication.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ciklum.WpfApplication.Tests
{
    [TestClass]
    public class ViewModelBaseTests
    {
        [TestMethod]
        public void TestPropertyChangedShouldRaiseCorrectly()
        {
            var target = new TestViewModel();
            bool eventWasRaised = false;
            target.PropertyChanged += (sender, e) => eventWasRaised = e.PropertyName == "SomeProperty";
            target.SomeProperty = "Some value";
            Assert.IsTrue(eventWasRaised, "PropertyChanged event was not raised correctly.");
        }

        [TestMethod]
        public void TestExceptionShouldBeThrownOnInvalidPropertyName()
        {
            var target = new TestViewModel();
            try
            {
                target.BadProperty = "Some value";
#if DEBUG
                Assert.Fail("Exception was not thrown when invalid property name was used in DEBUG build.");
#endif
            }
            catch (Exception)
            {
#if !DEBUG
                Assert.Fail("Exception was thrown when invalid property name was used in RELEASE build.");
#endif
            }
        }

        private class TestViewModel : ViewModelBase
        {
            protected override bool ThrowOnInvalidPropertyName
            {
                get { return true; }
            }

            public string SomeProperty
            {
                get { return null; }
                set
                {
                    base.OnPropertyChanged("SomeProperty");
                }
            }

            public string BadProperty
            {
                get { return null; }
                set
                {
                    base.OnPropertyChanged("ThisIsAnInvalidPropertyName!");
                }
            }
        }
    }
}

