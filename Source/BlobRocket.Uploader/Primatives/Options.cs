using BlobRocket.Uploader.Generics;
using System.Collections.Generic;

namespace BlobRocket.Uploader
{
    public class Options : OptionsBase
    {
        //[Option('s', "source", OptionKind.RequiredKeyValue, Properties.Resources.OptionSource)]
        public string Source { get; set; }

        //[Option('p', "pattern", OptionKind.OptionalKeyValue, Properties.Resources.OptionPattern)]
        public string Pattern { get; set; }

        //[Option('t', "target", OptionKind.RequiredKeyValue, Properties.Resources.OptionTarget)]
        public string Target { get; set; }

        //[Option('c', "casing", OptionKind.OptionalKeyValue, Properties.Resources.OptionCasing)]
        public Casing Casing { get; set; }

        //[Option('l', "logfolder", OptionKind.RequiredKeyValue, Properties.Resources.OptionLogFolder)]
        public string LogFolder { get; set; }

        //[Option('@', "paramfile", OptionKind.OptionalKeyValue, Properties.Resources.OptionParamFile)]
        public string ParamFile { get; set; }

        //[Option('v', "verbose", OptionKind.OptionalKeyOnly, Properties.Resources.OptionVerbose)]
        public bool Verbose { get; set; }

        //[Option('a', "account", OptionKind.RequiredKeyValue, Properties.Resources.OptionAccount)]
        public string Account { get; set; }

        //[Option('k', "accesskey", OptionKind.RequiredKeyValue, Properties.Resources.OptionAccessKey)]
        public string AccessKey { get; set; }

        //[Option('x', "alertsto", OptionKind.OptionalKeyValue, Properties.Resources.OptionAlertsTo)]
        public List<string> AlertsTo { get; set; }

        //[Option('h', "handling", OptionKind.OptionalKeyValue, Properties.Resources.OptionHandling)]
        public Handling Handling { get; set; }


        // shoudll be ignored
        public bool SomeFlag { get; set; }
    }
}
