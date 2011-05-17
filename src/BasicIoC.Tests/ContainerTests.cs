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
        public void ResolveType()
        {
            var container = new Container();
            container.Register<ILog, TextLog>();

            var log = container.Resolve<ILog>();
            Assert.IsInstanceOfType(log, typeof(TextLog));
        }
    }

    
}
