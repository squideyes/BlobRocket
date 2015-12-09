using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlobRocket.Uploader.Tests
{
    [TestClass]
    public class ArgsParserTests
    {
        private class Options
        {
            public string SomeString { get; set; }
        }

        [TestMethod]
        public void TestMethod1()
        {
            var parser = new ArgsParser<Options>();
        }
    }
}
