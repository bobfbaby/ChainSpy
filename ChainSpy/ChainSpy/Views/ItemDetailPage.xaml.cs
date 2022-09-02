using ChainSpy.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace ChainSpy.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}