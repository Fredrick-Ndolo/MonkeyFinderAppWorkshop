using MonkeyFinder.ViewModel;

namespace MonkeyFinder;

public partial class MainPage : ContentPage
{
    
    public MainPage(MonkeyViewModel monkeysViewModel)
	{
		InitializeComponent();       
        BindingContext = monkeysViewModel;
    }
}