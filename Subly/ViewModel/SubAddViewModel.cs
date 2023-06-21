using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Plugin.LocalNotification;
using Subly.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Subly.ViewModel
{
    public partial class SubAddViewModel : BasicViewModel
    {
        [ObservableProperty]
        public string name;
        [ObservableProperty]
        public decimal price;
        [ObservableProperty]
        public DateTime date;
        [ObservableProperty]
        public string addButtonText = "Add Subscription";

        public SubAddViewModel() { }

        [RelayCommand]
        async Task AddSub()
        {
            Vibration.Default.Vibrate(TimeSpan.FromSeconds(3));

            IsLoading = false; AddButtonText = "Adding";
            if (price == 0 || string.IsNullOrEmpty(name))
            {
                await Shell.Current.DisplayAlert("Invalid Data", "Please insert valid data", "Ok"); return;
            }

            var sub = new Subscription { Name = Name, Price = Price, Date = Date };
            App.SubRepository.AddSub(sub);
            await Shell.Current.DisplayAlert("Info", App.SubRepository.statusMessage, "Ok");

            ClearForm();

        }

        [RelayCommand]
        void ClearForm()
        {
            Name = string.Empty;
            Price = 0;
            Date = DateTime.Now;
            AddButtonText = "Add";
            IsLoading = true;
        }


    }
}
