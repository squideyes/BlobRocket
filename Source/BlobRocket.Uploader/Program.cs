using System;

namespace BlobRocket.Uploader
{
    class Program
    {
        static void Main(string[] args)
        {
            //  -s:C:\Data\File1.txt C:\Data\file2.txt -? -h -@ -c:LowerCase -h:true -n:999

            var commands = new string[] {
                @"-s:c:\Data",
                "-?" ,
                "-@:xxxx.xml" ,
                "-p:*.csv",
                "-c:LowerCase",
                "-h:Overwrite",
                "-a:abc123",
                "-l:LogFiles",
                "-k:XXXCCCVVV",
                "-v:true",
                "-t:blobs",
                "-x:lsb@bitmaven.com louis@bitmaven.com"
            };

            //var parser = new ArgsParser<Options>();

            //parser.Parse(commands);
        }
    }
}
