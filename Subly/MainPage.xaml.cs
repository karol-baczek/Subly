using Subly.ViewModel;
using Subly.Views;

namespace Subly;

public partial class MainPage : ContentPage
{

	public MainPage(SubListViewModel sub)
	{
		InitializeComponent();
		this.BindingContext = sub;
	}

	private async void OnAddClicked(object sender, EventArgs e)
	{
        await Shell.Current.GoToAsync(nameof(SubAddPage), true);
    }

    
}

