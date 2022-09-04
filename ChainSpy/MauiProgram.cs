using ChainSpy.Extensions;
using ChainSpy.Intefaces;
using ChainSpy.Providers;
using ChainSpy.Services;
using ChainSpy.ViewModels;
using CommunityToolkit.Maui;
using ZXing.Net.Maui;

namespace ChainSpy;

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

        builder.Services.AddSingleton<MarketProvider>();
        builder.Services.AddSingleton<IAddressService, AddressService>();
        builder.UseDatabaseContext<IDatabaseContext, DatabaseContext>( );

        builder.UseMauiCommunityToolkit();
        builder.UseBarcodeReader();
        builder.Services.AddSingleton<IBlockchainProvider, BlockchainProvider>();
        builder.Services.AddSingleton<MainPageViewModel>();
		builder.Services.AddSingleton<MainPage>(); 
        builder.Services.AddSingleton<QrReaderViewModel>();
		builder.Services.AddSingleton<QrReaderPage>();

        builder.Services.AddSingleton<AddAddressPageViewModel>();
        builder.Services.AddSingleton<AddAddressPage>();

        builder.Services.AddSingleton<AddressDetailPage>();
        builder.Services.AddSingleton<AddressDetailViewModel>();



        return builder.Build();
	}
}
