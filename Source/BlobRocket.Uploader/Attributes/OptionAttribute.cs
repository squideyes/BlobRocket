using System;
using System.ComponentModel.DataAnnotations;

namespace BlobRocket.Uploader
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class OptionAttribute : Attribute
    {
        public OptionAttribute(char key, string alias, OptionKind kind, string helpText)
        {
            Key = char.ToLower(key).ToString();
            Alias = alias;
            Kind = kind;
            HelpText = helpText;
        }

        public string Key { get;}
        public string Alias { get; }
        public OptionKind Kind { get; }  
        public string HelpText { get;  }
    }
}
