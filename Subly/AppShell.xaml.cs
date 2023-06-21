using Subly.Views;

namespace Subly;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(SubDetailsPage), typeof(SubDetailsPage));
        Routing.RegisterRoute(nameof(SubAddPage), typeof(SubAddPage));
    }
}
