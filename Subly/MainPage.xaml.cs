namespace Subly;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnAddClicked(object sender, EventArgs e)
	{

		SemanticScreenReader.Announce(AddSubBtn.Text);
	}

}

