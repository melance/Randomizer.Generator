using Randomizer.Generator.Mobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Randomizer.Generator.Mobile.Views
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