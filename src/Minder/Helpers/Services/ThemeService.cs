using System;
using System.Windows;

namespace Minder.Helpers.Services
{
    public enum SkinType
    {
        Default,
        Dark,
    }

    public static class ThemeService
    {
        public static void SetTheme(SkinType skinType)
        {
            var themeDictionary = App.Current.Resources.MergedDictionaries[0];
            themeDictionary.Clear();

            themeDictionary.MergedDictionaries.Add(GetSkin(skinType));
            themeDictionary.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("pack://application:,,,/HandyControl;component/Themes/Theme.xaml")
            });

            App.Current.MainWindow.OnApplyTemplate();
        }

        private static ResourceDictionary GetSkin(SkinType skin) => new()
        {
            Source = new Uri($"pack://application:,,,/HandyControl;component/Themes/Skin{skin}.xaml")
        };
    }
}
