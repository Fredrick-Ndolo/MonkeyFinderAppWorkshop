using MonkeyFinder.Services;
using MonkeyFinder.View;
using MonkeyFinder.ViewModel;

namespace MonkeyFinder;

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
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		//Container Registration
		builder.Services.AddSingleton<MonkeyService>();
		builder.Services.AddSingleton<MonkeyViewModel>();
		builder.Services.AddTransient<MonkeyDetailsViewModel>();

		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddTransient<DetailsPage>();


		return builder.Build();
	}
}
