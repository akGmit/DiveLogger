using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
/// <summary>
/// Settings class to work with native platform preferences/settings.
/// </summary>
namespace DiveLogger.Utils
{
    public static class Settings
    {
        /// <summary>
        /// Get/set firebase auth token in app data storage.
        /// </summary>
        public static string FirebaseAuthJson
        {
            get => Preferences.Get(nameof(FirebaseAuthJson), string.Empty);
            set => Preferences.Set(nameof(FirebaseAuthJson), value);
        }
    }
}
