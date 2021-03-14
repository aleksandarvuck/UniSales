using Plugin.Settings;
using Plugin.Settings.Abstractions;
using UniSales.Core.Extensions;
using UniSales.Core.Models;

namespace UniSales.Core.Utility
{
    public static class AppSettings
    {
        private static ISettings Settings => CrossSettings.Current;

        public static User User
        {
            get => Settings.GetValueOrDefault(nameof(User), default(User));

            set => Settings.AddOrUpdateValue(nameof(User), value);
        }
    }
}