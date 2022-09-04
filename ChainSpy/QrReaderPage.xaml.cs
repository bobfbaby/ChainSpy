using ChainSpy.ViewModels;
using ZXing.Net.Maui;

namespace ChainSpy;

public partial class QrReaderPage : ContentPage
{
	public QrReaderPage(QrReaderViewModel viewModel)
	{
        BindingContext = viewModel;

        InitializeComponent();
		 
    }

	 
}