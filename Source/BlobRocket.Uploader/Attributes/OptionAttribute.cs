using System;
using System.ComponentModel.DataAnnotations;

namespace BlobRocket.Uploader
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class OptionAttribute : Attribute
    {
        public OptionAttribute()
        {
            Kind = OptionKind.RequiredKeyValue;
        }

        [Required]
        [StringLength(1, MinimumLength = 1)]
        public string Key { get; set; }

        [Required]
        [StringLength(1, MinimumLength = 16)]
        public string Alias { get; set; }

        [Required]
        public OptionKind Kind { get; set; }

        [Required]
        public string HelpText { get; set; }
    }
}
