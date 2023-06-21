using Microsoft.Extensions.Logging;
using Plugin.LocalNotification;
using Subly.Repository;
using Subly.ViewModel;
using Subly.Views;

namespace Subly;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseLocalNotification()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
        var dbPath = Path.Combine(FileSystem.AppDataDirectory, "subs.db3");
        builder.Services.AddSingleton(s => ActivatorUtilities.CreateInstance<SubRepository>(s, dbPath));

        builder.Services.AddSingleton<SubListViewModel>();
        builder.Services.AddTransient<SubDetailsViewModel>();
        builder.Services.AddTransient<SubAddViewModel>();

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<SubDetailsPage>();
        builder.Services.AddSingleton<SubAddPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
