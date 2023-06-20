using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subly.Model;

namespace Subly.ViewModel
{
        [QueryProperty(nameof(Subscription), "Subscription")]
        public partial class SubDetailsViewModel : BasicViewModel
        {
            [ObservableProperty]
            public Subscription subscription;

            public SubDetailsViewModel()
            {
            }

            public override string ToString()
            {
                return $"Subscription details: {(this.Subscription != null ? this.Subscription.Name : "")}";
            }
        }
}
