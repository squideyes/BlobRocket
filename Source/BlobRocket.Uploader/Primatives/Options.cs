using System.Collections.Generic;

namespace BlobRocket.Uploader
{
    public class Options
    {
        [Option(Key = "s", Alias = "source", Kind = OptionKind.RequiredKeyValue,
            HelpText = "Specifies the file system directory from which to copy files from.  The directory must exist.")]
        public string Source { get; set; }

        [Option(Key = "p", Alias = "pattern", Kind = OptionKind.OptionalKeyValue,
            HelpText = "Specifies a file pattern that indicates which files to copy. The file pattern provided is matched against files within the directory specified by the -S option. BlobRocket.Uploader also matches the specified pattern against all files in any subfolders beneath the directory.  BlobRocket.Uploader uses uses case-insensitive matching in all cases. The default file pattern used when no file pattern is specified is \"*.*\". Specifying multiple file patterns is not supported.")]
        public string Pattern { get; set; }

        [Option(Key = "t", Alias = "target", Kind = OptionKind.RequiredKeyValue,
            HelpText = "Specifies the container to copy the files to.  If the container doesn't already exist, it will be created.  Container names must start with a letter or number, and can contain only letters, numbers, and the dash (-) character.  Every dash (-) character must be immediately preceded and followed by a letter or number; consecutive dashes are not permitted in container names.  All letters in a container name must be lowercase.  Container names must be from 3 through 63 characters long.")]
        public string Target { get; set; }

        [Option(Key = "c", Alias = "casing", Kind = OptionKind.OptionalKeyValue,
            HelpText = "Specifies the file-name casing (Normal, LowerCase, or UpperCase).")]
        public Casing Casing { get; set; }

        [Option(Key = "l", Alias = "logfolder", Kind = OptionKind.RequiredKeyValue,
            HelpText = "Specifies the file system directory to persist log files to.  If the directory doesn't exist it will be created.  A new log file will be created for each BlobRocket.Uploader run and have a unique and standard name (i.e. BlobRocket_20151224_123117999.log).")]
        public string LogFolder { get; set; }

        [Option(Key = "@", Alias = "paramfile", Kind = OptionKind.OptionalKeyValue,
            HelpText = "Specifies a file that contains parameters.  BlobRocket.Uploader processes the parameters in the file just as if they had been specified on the command line.  In a response file, you can either specify multiple parameters on a single line, or specify each parameter on its own line. Note that an individual parameter cannot span multiple lines.  Response files can include comments lines that begin with the # symbol.  You can specify multiple response files. However, note that BlobRocket.Uploader does not support nested response files.")]
        public string ParamFile { get; set; }

        [Option(Key = "v", Alias = "verbose", Kind = OptionKind.OptionalKeyOnly,
            HelpText = "Prints all messages to Standard Output.")]
        public bool Verbose { get; set; }

        [Option(Key = "a", Alias = "account", Kind = OptionKind.RequiredKeyValue,
            HelpText = "Specifies the Azure Storage account name.  Storage account names must be between 3 and 24 characters in length, may contain numbers and lowercase letters only and must match the name of an existing storage account within Azure.")]
        public string Account { get; set; }

        [Option(Key = "k", Alias = "accesskey", Kind = OptionKind.RequiredKeyValue,
            HelpText = "Specifies the pre-defined Azure Storage account access key.")]
        public string AccessKey { get; set; }

        [Option(Key = "x", Alias = "alertsto", Kind = OptionKind.OptionalKeyValue,
            HelpText = "Specifies one or more comma-separated email accounts to send status reports to.")]
        public List<string> AlertsTo { get; set; }

        [Option(Key = "h", Alias = "handling", Kind = OptionKind.OptionalKeyValue,
            HelpText = "Specifies the file handling mode (Sync or Overwrite).")]
        public Handling Handling { get; set; }


        // shoudll be ignored
        public bool SomeFlag { get; set; }
    }
}
