namespace ChainSpy;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(MainPage),typeof(MainPage));
        Routing.RegisterRoute(nameof(QrReaderPage), typeof(QrReaderPage));
		Routing.RegisterRoute(nameof(AddAddressPage), typeof(AddAddressPage));
		Routing.RegisterRoute(nameof(AddressDetailPage), typeof(AddressDetailPage));
       
    }
}
