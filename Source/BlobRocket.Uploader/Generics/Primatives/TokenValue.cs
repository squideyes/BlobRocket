namespace BlobRocket.Uploader.Generics
{
    public class TokenValue
    {
        public TokenValue(string chunk)
        {
            var index = chunk.IndexOf(':');

            if (index == -1)
            {
                Token = chunk.ToLower();
            }
            else
            {
                Token = chunk.Substring(0, index).ToLower();
                Value = chunk.Substring(index + 1);
            }
        }

        public string Token { get; }
        public string Value { get; }

        public bool HasValue
        {
            get
            {
                return !string.IsNullOrWhiteSpace(Value);
            }
        }

        public override string ToString()
        {
            return $"{Token}={Value}";
        }
    }
}
