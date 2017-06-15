// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace AquarioVirtual.App.Helpers
{

    public static class Settings
    {
        private static ISettings AppSettings => CrossSettings.Current;

        const string UserIdKey = "userid";
        static readonly string UserIdDefault = string.Empty;

        const string AuthTokenKey = "authtoken";
        static readonly string AuthTokenDefault = string.Empty;

        public static string AuthToken
        {
            get
            {
                return AppSettings.GetValueOrDefault<string>(AuthTokenKey, AuthTokenDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue<string>(AuthToken, value);
                //AuthToken = value;
            }
        }

        public static string UserId
        {
            get
            {
                return AppSettings.GetValueOrDefault<string>(UserIdKey, UserIdDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue<string>(UserIdKey, value);
            }
        }

      
        const string NameKey = "UserName";

        static readonly string NameDefault = string.Empty;
        public static string Name
        {
            get { return AppSettings.GetValueOrDefault<string>(NameKey, NameDefault); }
            set { AppSettings.AddOrUpdateValue<string>(NameKey, value); }
        }

        const string ImageKey = "UserProfile";

        static readonly string ImageDefault = string.Empty;
        public static string Image
        {
            get { return AppSettings.GetValueOrDefault<string>(ImageKey, ImageDefault); }
            set { AppSettings.AddOrUpdateValue<string>(ImageKey, value); }
        }

        public static bool IsLoggedIn => (!string.IsNullOrWhiteSpace(UserId) && !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Image));

    }
}