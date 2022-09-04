using ChainSpy.ViewModels;

namespace ChainSpy;

public partial class AddressDetailPage : ContentPage
{
	public AddressDetailPage(AddressDetailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}