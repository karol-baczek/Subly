using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Subly.Model;
using Subly.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subly.ViewModel
{
    public partial class SubListViewModel : BasicViewModel
    {
        private readonly SubRepository _subRepository;
        public ObservableCollection<Subscription> Subs { get; private set; } = new();

        public SubListViewModel(SubRepository subRepository)
        {
            Title = "Subs";
            this._subRepository = subRepository;
        }

        [ObservableProperty]
        bool isRefreshing;

        [ObservableProperty]
        bool isLoading;

        [RelayCommand]
        async Task GetList()
        {
            if (IsLoading) return;
            try
            {
                IsLoading = true;
                if (Subs.Any()) Subs.Clear();

                var subs = App.SubRepository.GetSubs();
                foreach (var sub in subs) Subs.Add(sub);
            }
            catch (Exception ex) { await Shell.Current.DisplayAlert("Error", ex.Message, "Ok"); }
            finally { IsLoading = false; IsRefreshing = false; }
        }

        [RelayCommand]
        async Task ShowSubDetails(Subscription subscription)
        {
            if (subscription == null) return;

            await Shell.Current.GoToAsync(nameof(SubDetailsPage), true, new Dictionary<string, object>
            {
                {nameof(Subscription), subscription},
            });
        }

        [RelayCommand]
        async Task DeleteSub(Subscription subscription)
        {
            if (subscription.Id == 0)
            {
                await Shell.Current.DisplayAlert("Invalid Record", "Please try again", "Ok");
                return;
            }
            var result = App.SubRepository.DeleteSub(subscription.Id);
            if (result == 0) await Shell.Current.DisplayAlert("Failed", "Please insert valid data", "Ok");
            else
            {
                await Shell.Current.DisplayAlert("Deletion Successful", "Record Removed Successfully", "Ok");
                Subs.Remove(subscription);
            }
        }
    }
}
