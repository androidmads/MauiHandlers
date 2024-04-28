
#if ANDROID
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
#endif

namespace MauiHandlers;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("BorderlessEntry", (handler, view) =>
        {
            if (view is Entry)
            {
#if ANDROID
                handler.PlatformView.SetBackgroundColor(Microsoft.Maui.Graphics.Colors.Beige.ToAndroid());
#elif IOS
                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#elif WINDOWS
                handler.PlatformView.BorderThickness = new Microsoft.UI.Xaml.Thickness(10);
#endif
            }
        });
    }
}