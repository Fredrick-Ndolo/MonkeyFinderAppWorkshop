using MonkeyFinder.ViewModel;

namespace MonkeyFinder;

public partial class MainPage : ContentPage
{
    private readonly MonkeyViewModel monkeysViewModel;

    public MainPage(MonkeyViewModel monkeysViewModel)
	{
		InitializeComponent();
        this.monkeysViewModel = monkeysViewModel;
        BindingContext = this.monkeysViewModel;
    }
}