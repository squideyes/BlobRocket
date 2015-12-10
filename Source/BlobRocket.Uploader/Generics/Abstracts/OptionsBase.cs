using System.Collections.Generic;

namespace BlobRocket.Uploader.Generics
{
    public abstract class OptionsBase
    {
        public OptionsBase()
        {
            Errors = new List<ParseError>();
            ExtraArgs = new List<string>();
        }

        public List<ParseError> Errors { get;  }
        public List<string> ExtraArgs { get;}
    }
}
