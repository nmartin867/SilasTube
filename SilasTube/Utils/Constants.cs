namespace SilasTube.Utils
{
    internal static class Constants
    {
        public const string ApplicationId = "";
        internal static class Google
        {
            public const string ClientId = "";
            public const string AuthUri = "https://accounts.google.com/o/oauth2/auth";
            public const string TokenUri = "https://oauth2.googleapis.com/token";
            public const string RedirectUri = $"{ApplicationId}.login://";
        }
    }
}
