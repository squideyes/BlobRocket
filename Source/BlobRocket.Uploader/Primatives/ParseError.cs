namespace BlobRocket.Uploader
{
    public class ParseError
    {
        public ParseError(TokenValue tokenValue, 
            string format, params object[] args)
        {
            TokenValue = tokenValue;
            Message = string.Format(format, args);
        }

        public TokenValue TokenValue { get; }
        public string Message { get; }
    }
}
