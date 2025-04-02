using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using Refit;
using SetWhen.App.Api;
using SetWhen.App.Services;

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

           

            builder.Services.AddSingleton<TokenStorageService>();

            builder.Services.AddTransient<TokenAuthHandler>();


#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif
            ConfigureRefit(builder.Services);

            return builder.Build();
        }

        private static void ConfigureRefit(IServiceCollection services)
        {
                

            services.AddRefitClient<IAuthApi>(GetRefitSettings)
            .ConfigurePrimaryHttpMessageHandler(() =>
                new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
                })
            .ConfigureHttpClient(SetHttpclient);
                    static RefitSettings GetRefitSettings(IServiceProvider serviceProvider) 
            {
                var settings = new RefitSettings();
                settings.AuthorizationHeaderValueGetter = async (_, __) =>
                {
                    var tokenService = serviceProvider.GetRequiredService<TokenStorageService>();
                    var token = await tokenService.GetTokenAsync();

                    return string.IsNullOrWhiteSpace(token) ? null : token;

                }; 
                return settings;
            }

            static void SetHttpclient(HttpClient httpClient)
            {
                var baseApiUrl = DeviceInfo.Platform == DevicePlatform.Android
                    ? "https://10.0.2.2:7128"
                    : "https://localhost:7128";

                httpClient.BaseAddress = new Uri(baseApiUrl);
            }


        }
    }
}
