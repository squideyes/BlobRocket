namespace BlobRocket.Uploader
{
    public class OptionInfo
    {
        public string Key { get; internal set; }
        public string Alias { get; internal set; }
        public OptionKind Kind { get; internal set; }
        public string HelpText { get; internal set; }
    }
}
