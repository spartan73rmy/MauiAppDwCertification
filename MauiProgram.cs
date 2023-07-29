using AppDWCert.Controls;
using Material.Components.Maui.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Compatibility.Hosting;

namespace AppDWCert;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiMaps()
            .UseMauiCompatibility()
            .ConfigureMauiHandlers((handler) =>
            {
#if ANDROID
                handler.AddCompatibilityRenderer(typeof(CustomEntry), typeof(Platforms.Android.Renders.CustomEntryRenderAndroid));
#elif IOS
#endif
            })
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
            .UseMaterialComponents(new List<string> { "OpenSans-Regular.ttf", "OpenSans-Semibold.ttf" });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
