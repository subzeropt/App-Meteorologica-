using Microsoft.Extensions.Logging;
using LabApp.Services;
using LabApp.Controllers;
using LabApp.ViewModels;

namespace LabApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        // Framework
        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        // Serviços
        builder.Services.AddSingleton<IAuthService, AuthService>();
        builder.Services.AddSingleton<IWeatherService, WeatherService>();

        // Controlador
        builder.Services.AddSingleton<IAppController, AppController>();

        // ViewModel
        builder.Services.AddSingleton<IWeatherViewModel, WeatherViewModel>();

        return builder.Build();
    }
}

