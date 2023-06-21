using Plugin.LocalNotification;
using Subly.ViewModel;

namespace Subly.Views;

public partial class SubAddPage : ContentPage
{
    public SubAddPage(SubAddViewModel newsub)
    {
        InitializeComponent();
        BindingContext = newsub;
        LocalNotificationCenter.Current.NotificationActionTapped += Current_NotificationActionTapped;

    }

    private void Current_NotificationActionTapped(Plugin.LocalNotification.EventArgs.NotificationActionEventArgs e)
    {
        if (e.IsDismissed)
        {

        }
        else if (e.IsTapped)
        {

        }
    }
    private void AddClicked(object sender, EventArgs e)
    {   
            var request = new NotificationRequest
            {
                NotificationId = 1337,
                Title = "One of your subscriptions will soon renew",
                Subtitle = "Hello",
                Description = "Hello",
                BadgeNumber = 42,
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = DateTime.Now.AddSeconds(6),
                    NotifyRepeatInterval = TimeSpan.FromDays(30)
                }
            };
        
        LocalNotificationCenter.Current.Show(request);
    }
}