using Subly.Repository;

namespace Subly;

public partial class App : Application
{
    public static SubRepository SubRepository { get; private set; }

    public App(SubRepository subRepository)
    {
        InitializeComponent();

        MainPage = new AppShell();
        SubRepository = subRepository;
    }
}
