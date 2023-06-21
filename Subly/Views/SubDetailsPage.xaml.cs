using Subly.ViewModel;

namespace Subly;

public partial class SubDetailsPage : ContentPage
{
    public SubDetailsPage(SubDetailsViewModel sub)
    {
        InitializeComponent();
        BindingContext = sub;
    }

    private void InitializeComponent()
    {
        throw new NotImplementedException();
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}