namespace SilasTube.Utils
{
    internal static class Constants
    {
        public const string ApplicationId = "com.nmartindev.silastube";
        internal static class Google
        {
            public const string ClientId = "860945642074-nec2uqdq2i6noi55hnensols2qfm7d9h.apps.googleusercontent.com";
            public const string AuthUri = "https://accounts.google.com/o/oauth2/auth";
            public const string TokenUri = "https://oauth2.googleapis.com/token";
            public const string RedirectUri = $"{ApplicationId}.login://";
        }
    }
}
