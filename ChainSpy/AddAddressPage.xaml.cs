using ChainSpy.ViewModels;

namespace ChainSpy;

public partial class AddAddressPage : ContentPage
{
	public AddAddressPage(AddAddressPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;

    }
}