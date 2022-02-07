using Microsoft.AspNetCore.Components.WebView.Maui;
using Blazor.StackNavigation.Data;
using Maui.Blazor.StackNavigation;

namespace Blazor.StackNavigation;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.RegisterBlazorMauiWebView()
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddBlazorWebView();
		builder.Services.UseBlazorStackNavigation();
		

		return builder.Build();
	}
}
