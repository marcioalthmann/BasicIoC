using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BasicIoC.Tests
{
    interface ILog
    {
        void Write();
    }

    class TextLog : ILog
    {
        public void Write()
        {
            throw new NotImplementedException();
        }
    }

    [TestClass]
    public class ContainerTests
    {
        [TestMethod]
        public void RegisterAndResoleClassByInterface()
        {
            var container = new Container();
            container.Register<ILog>().To<TextLog>();

            var log = container.Resolve<ILog>();
            Assert.IsInstanceOfType(log, typeof(TextLog));
        }

        [TestMethod]
        public void RegisterAndResolveClassByType()
        {
            var container = new Container();
            container.Register<TextLog>().ToSelf();

            var log = container.Resolve<TextLog>();
            Assert.IsInstanceOfType(log, typeof(TextLog));
        }

        [TestMethod]
        public void WhenResolveAClassTwoTimesReturnTheSameInstanceWithSingletonLifeStyle()
        {
            var container = new Container();
            container.Register<ILog>().To<TextLog>(LifeStyle.Singleton);

            var firstInstance = container.Resolve<ILog>();
            var secondInstance = container.Resolve<ILog>();

            Assert.AreSame(firstInstance, secondInstance);
        }

        [TestMethod]
        public void WhenResolveAClassTwoTimesReturnTwoDiferentInstancesWithTransientLifeStyle()
        {
            var container = new Container();
            container.Register<ILog>().To<TextLog>(LifeStyle.Transient);

            var firstInstance = container.Resolve<ILog>();
            var secondInstance = container.Resolve<ILog>();

            Assert.AreNotSame(firstInstance, secondInstance);
        }
    }
}
