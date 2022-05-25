using MonkeyFinder.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonkeyFinder.Services;
using System.Diagnostics;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MonkeyFinder.ViewModel
{
    public partial class MonkeyViewModel : BaseViewModel
    {
        //Backing field             
        private readonly MonkeyService monkeyService;

        public ObservableCollection<Monkey> Monkeys { get; } = new();
        public Command GetMonkeysCommand { get; }
        public MonkeyViewModel(MonkeyService monkeyService)
        {
            Title = "Monkey Finder";
            this.monkeyService = monkeyService;
            //GetMonkeysCommand = new Command(async () => await GetMonkeyAsync());
        }

        [ICommand]
        async Task GetMonkeyAsync()
        {
            if (IsBusy)
            {
                return;
            }

            try
            {
                IsBusy = true;
                var monkeys = await monkeyService.GetMonkeys();
                Monkeys.Clear();
                foreach (var monkey in monkeys)
                    Monkeys.Add(monkey);

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get monkeys {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
