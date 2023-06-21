using Plugin.LocalNotification;
using Subly.ViewModel;

namespace Subly.Views;

public partial class SubAddPage : ContentPage
{
    public SubAddPage(SubAddViewModel newsub)
    {
        InitializeComponent();
        BindingContext = newsub;

    }

    private void AddClicked(object sender, EventArgs e)
    {   
            var request = new NotificationRequest
            {
                NotificationId = 1337,
                Title = "One of your subscriptions will renew soon",
                Subtitle = "Hello",
                Description = "Hello",
                BadgeNumber = 42,
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = DateTime.Now.AddSeconds(6),
                    NotifyRepeatInterval = TimeSpan.FromDays(1)
                }
            };
        
        LocalNotificationCenter.Current.Show(request);
    }
}