using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlobRocket.Uploader.Tests
{
    //var commands = new string[] {
    //            @"-s:c:\Data",
    //            "-?" ,
    //            "-@:xxxx.xml" ,
    //            "-p:*.csv",
    //            "-c:LowerCase",
    //            "-h:Overwrite",
    //            "-a:abc123",
    //            "-l:LogFiles",
    //            "-k:XXXCCCVVV",
    //            "-v:true",
    //            "-t:blobs",
    //            "-x:lsb@bitmaven.com louis@bitmaven.com"
    //        };

    [TestClass]
    public class ArgsParserTests
    {
        private class Options : OptionsBase
        {
            public string SomeString { get; set; }
        }

        private string[] GetArgs(params object[] args)
        {
            return args.Cast<string>().ToArray();
        }

        [TestMethod]
        public void TestMethod1()
        {
            var parser = new ArgsParser<Options>();

            var args = GetArgs(@"-s:c:\data");

            var options = parser.Parse(args);
        }
    }
}
