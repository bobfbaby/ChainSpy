using ChainSpy.ViewModels;
using CommunityToolkit.Mvvm.Input;

namespace ChainSpy;

public partial class MainPage : ContentPage
{

	public MainPage(MainPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

	
}

