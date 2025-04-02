using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using Refit;
using SetWhen.App.Api;

namespace SetWhen.App
{
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

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddMudServices();
            builder.Services
            .AddRefitClient<IAuthApi>()
            .ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri("https://localhost:7128/");
            });

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
